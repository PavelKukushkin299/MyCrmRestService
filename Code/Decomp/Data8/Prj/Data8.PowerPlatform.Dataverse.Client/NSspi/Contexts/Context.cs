// Decompiled with JetBrains decompiler
// Type: NSspi.Contexts.Context
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using NSspi.Buffers;
using NSspi.Credentials;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace NSspi.Contexts
{
  public abstract class Context : IDisposable
  {
    protected Context(Credential cred)
    {
      this.Credential = cred;
      this.ContextHandle = new SafeContextHandle();
      this.Disposed = false;
      this.Initialized = false;
    }

    public bool Initialized { get; private set; }

    protected Credential Credential { get; private set; }

    public SafeContextHandle ContextHandle { get; private set; }

    public string AuthorityName
    {
      get
      {
        this.CheckLifecycle();
        return this.QueryContextString(ContextQueryAttrib.Authority);
      }
    }

    public string ContextUserName
    {
      get
      {
        this.CheckLifecycle();
        return this.QueryContextString(ContextQueryAttrib.Names);
      }
    }

    public DateTime Expiry { get; private set; }

    public bool Disposed { get; private set; }

    protected void Initialize(DateTime expiry)
    {
      this.Expiry = expiry;
      this.Initialized = true;
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (this.Disposed)
        return;
      if (disposing)
        this.ContextHandle.Dispose();
      this.Disposed = true;
    }

    public IIdentity GetRemoteIdentity()
    {
      IIdentity remoteIdentity = (IIdentity) null;
      using (SafeTokenHandle contextToken = this.GetContextToken())
      {
        bool success = false;
        RuntimeHelpers.PrepareConstrainedRegions();
        try
        {
          contextToken.DangerousAddRef(ref success);
        }
        catch (Exception ex)
        {
          if (success)
            contextToken.DangerousRelease();
          throw;
        }
        finally
        {
          try
          {
            remoteIdentity = (IIdentity) new WindowsIdentity(contextToken.DangerousGetHandle(), this.Credential.SecurityPackage);
          }
          finally
          {
            contextToken.DangerousRelease();
          }
        }
      }
      return remoteIdentity;
    }

    private SafeTokenHandle GetContextToken()
    {
      bool success = false;
      SecurityStatus errorCode = SecurityStatus.InternalError;
      RuntimeHelpers.PrepareConstrainedRegions();
      SafeTokenHandle handle;
      try
      {
        this.ContextHandle.DangerousAddRef(ref success);
      }
      catch (Exception ex)
      {
        if (success)
        {
          this.ContextHandle.DangerousRelease();
          success = false;
        }
        throw;
      }
      finally
      {
        if (success)
        {
          try
          {
            errorCode = ContextNativeMethods.QuerySecurityContextToken(ref this.ContextHandle.rawHandle, out handle);
          }
          finally
          {
            this.ContextHandle.DangerousRelease();
          }
        }
        else
          handle = (SafeTokenHandle) null;
      }
      if (errorCode != SecurityStatus.OK)
        throw new SSPIException("Failed to query context token.", errorCode);
      return handle;
    }

    public byte[] Encrypt(byte[] input, bool stream)
    {
      SecurityStatus errorCode = SecurityStatus.InvalidHandle;
      this.CheckLifecycle();
      SecPkgContext_Sizes secPkgContextSizes = this.QueryBufferSizes();
      SecureBuffer secureBuffer1 = new SecureBuffer(new byte[secPkgContextSizes.SecurityTrailer], BufferType.Token);
      SecureBuffer secureBuffer2 = new SecureBuffer(new byte[input.Length], BufferType.Data);
      SecureBuffer secureBuffer3 = new SecureBuffer(new byte[secPkgContextSizes.BlockSize], BufferType.Padding);
      Array.Copy((Array) input, (Array) secureBuffer2.Buffer, input.Length);
      SecureBuffer[] buffers = new SecureBuffer[3]
      {
        secureBuffer1,
        secureBuffer2,
        secureBuffer3
      };
      SecureBufferAdapter bufferAdapter;
      using (bufferAdapter = new SecureBufferAdapter((IList<SecureBuffer>) buffers))
        errorCode = ContextNativeMethods.SafeEncryptMessage(this.ContextHandle, 0, bufferAdapter, 0);
      if (errorCode != SecurityStatus.OK)
        throw new SSPIException("Failed to encrypt message", errorCode);
      int num1 = 0;
      byte[] numArray = new byte[(stream ? 0 : 8) + secureBuffer1.Length + secureBuffer2.Length + secureBuffer3.Length];
      if (!stream)
      {
        ByteWriter.WriteInt16_BE((short) secureBuffer1.Length, numArray, num1);
        int position1 = num1 + 2;
        ByteWriter.WriteInt32_BE(secureBuffer2.Length, numArray, position1);
        int position2 = position1 + 4;
        ByteWriter.WriteInt16_BE((short) secureBuffer3.Length, numArray, position2);
        num1 = position2 + 2;
      }
      Array.Copy((Array) secureBuffer1.Buffer, 0, (Array) numArray, num1, secureBuffer1.Length);
      int destinationIndex1 = num1 + secureBuffer1.Length;
      Array.Copy((Array) secureBuffer2.Buffer, 0, (Array) numArray, destinationIndex1, secureBuffer2.Length);
      int destinationIndex2 = destinationIndex1 + secureBuffer2.Length;
      Array.Copy((Array) secureBuffer3.Buffer, 0, (Array) numArray, destinationIndex2, secureBuffer3.Length);
      int num2 = destinationIndex2 + secureBuffer3.Length;
      return numArray;
    }

    public byte[] Encrypt(byte[] input) => this.Encrypt(input, false);

    public byte[] Decrypt(byte[] input, bool stream)
    {
      if (!stream)
        return this.Decrypt(input);
      byte[] numArray = new byte[input.Length];
      Array.Copy((Array) input, 0, (Array) numArray, 0, input.Length);
      SecureBuffer[] buffers = new SecureBuffer[2]
      {
        new SecureBuffer(numArray, BufferType.Stream),
        new SecureBuffer((byte[]) null, BufferType.Data)
      };
      SecureBufferAdapter bufferAdapter;
      using (bufferAdapter = new SecureBufferAdapter((IList<SecureBuffer>) buffers))
      {
        int num = (int) ContextNativeMethods.SafeDecryptMessage(this.ContextHandle, 0, bufferAdapter, 0);
        return bufferAdapter.ExtractData(1);
      }
    }

    public byte[] Decrypt(byte[] input)
    {
      this.CheckLifecycle();
      SecPkgContext_Sizes secPkgContextSizes = this.QueryBufferSizes();
      if (input.Length < 8 + secPkgContextSizes.SecurityTrailer)
        throw new ArgumentException("Buffer is too small to possibly contain an encrypted message");
      int position1 = 0;
      int length1 = (int) ByteWriter.ReadInt16_BE(input, position1);
      int position2 = position1 + 2;
      int length2 = ByteWriter.ReadInt32_BE(input, position2);
      int position3 = position2 + 4;
      int length3 = (int) ByteWriter.ReadInt16_BE(input, position3);
      int sourceIndex1 = position3 + 2;
      if (length1 + length2 + length3 + 2 + 4 + 2 > input.Length)
        throw new ArgumentException("The buffer contains invalid data - the embedded length data does not add up.");
      SecureBuffer secureBuffer1 = new SecureBuffer(new byte[length1], BufferType.Token);
      SecureBuffer secureBuffer2 = new SecureBuffer(new byte[length2], BufferType.Data);
      SecureBuffer secureBuffer3 = new SecureBuffer(new byte[length3], BufferType.Padding);
      int num1 = input.Length - sourceIndex1;
      if (secureBuffer1.Length > num1)
        throw new ArgumentException("Input is missing data - it is not long enough to contain a fully encrypted message");
      Array.Copy((Array) input, sourceIndex1, (Array) secureBuffer1.Buffer, 0, secureBuffer1.Length);
      int sourceIndex2 = sourceIndex1 + secureBuffer1.Length;
      int num2 = num1 - secureBuffer1.Length;
      if (secureBuffer2.Length > num2)
        throw new ArgumentException("Input is missing data - it is not long enough to contain a fully encrypted message");
      Array.Copy((Array) input, sourceIndex2, (Array) secureBuffer2.Buffer, 0, secureBuffer2.Length);
      int sourceIndex3 = sourceIndex2 + secureBuffer2.Length;
      int num3 = num2 - secureBuffer2.Length;
      if (secureBuffer3.Length <= num3)
        Array.Copy((Array) input, sourceIndex3, (Array) secureBuffer3.Buffer, 0, secureBuffer3.Length);
      SecureBuffer[] buffers = new SecureBuffer[3]
      {
        secureBuffer1,
        secureBuffer2,
        secureBuffer3
      };
      SecureBufferAdapter bufferAdapter;
      SecurityStatus errorCode;
      using (bufferAdapter = new SecureBufferAdapter((IList<SecureBuffer>) buffers))
        errorCode = ContextNativeMethods.SafeDecryptMessage(this.ContextHandle, 0, bufferAdapter, 0);
      if (errorCode != SecurityStatus.OK)
        throw new SSPIException("Failed to encrypt message", errorCode);
      byte[] destinationArray = new byte[secureBuffer2.Length];
      Array.Copy((Array) secureBuffer2.Buffer, 0, (Array) destinationArray, 0, secureBuffer2.Length);
      return destinationArray;
    }

    public byte[] MakeSignature(byte[] message)
    {
      SecurityStatus errorCode = SecurityStatus.InternalError;
      this.CheckLifecycle();
      SecPkgContext_Sizes secPkgContextSizes = this.QueryBufferSizes();
      SecureBuffer secureBuffer1 = new SecureBuffer(new byte[message.Length], BufferType.Data);
      SecureBuffer secureBuffer2 = new SecureBuffer(new byte[secPkgContextSizes.MaxSignature], BufferType.Token);
      Array.Copy((Array) message, (Array) secureBuffer1.Buffer, message.Length);
      SecureBuffer[] buffers = new SecureBuffer[2]
      {
        secureBuffer1,
        secureBuffer2
      };
      SecureBufferAdapter adapter;
      using (adapter = new SecureBufferAdapter((IList<SecureBuffer>) buffers))
        errorCode = ContextNativeMethods.SafeMakeSignature(this.ContextHandle, 0, adapter, 0);
      if (errorCode != SecurityStatus.OK)
        throw new SSPIException("Failed to create message signature.", errorCode);
      int position1 = 0;
      byte[] numArray = new byte[6 + secureBuffer1.Length + secureBuffer2.Length];
      ByteWriter.WriteInt32_BE(secureBuffer1.Length, numArray, position1);
      int position2 = position1 + 4;
      ByteWriter.WriteInt16_BE((short) secureBuffer2.Length, numArray, position2);
      int destinationIndex1 = position2 + 2;
      Array.Copy((Array) secureBuffer1.Buffer, 0, (Array) numArray, destinationIndex1, secureBuffer1.Length);
      int destinationIndex2 = destinationIndex1 + secureBuffer1.Length;
      Array.Copy((Array) secureBuffer2.Buffer, 0, (Array) numArray, destinationIndex2, secureBuffer2.Length);
      int num = destinationIndex2 + secureBuffer2.Length;
      return numArray;
    }

    public byte[] QuerySessionKey()
    {
      byte[] buffer = (byte[]) null;
      SecurityStatus errorCode = ContextNativeMethods.SafeQueryContextAttribute(this.ContextHandle, ContextQueryAttrib.SessionKey, ref buffer);
      if (errorCode != SecurityStatus.OK)
        throw new SSPIException("Failed to query session key.", errorCode);
      return buffer;
    }

    public bool VerifySignature(byte[] signedMessage, out byte[] origMessage)
    {
      SecurityStatus errorCode = SecurityStatus.InternalError;
      this.CheckLifecycle();
      SecPkgContext_Sizes secPkgContextSizes = this.QueryBufferSizes();
      if (signedMessage.Length < 6 + secPkgContextSizes.MaxSignature)
        throw new ArgumentException("Input message is too small to possibly fit a valid message");
      int num1 = 0;
      int length1 = ByteWriter.ReadInt32_BE(signedMessage, 0);
      int position = num1 + 4;
      int length2 = (int) ByteWriter.ReadInt16_BE(signedMessage, position);
      int sourceIndex1 = position + 2;
      if (length1 + length2 + 2 + 4 > signedMessage.Length)
        throw new ArgumentException("The buffer contains invalid data - the embedded length data does not add up.");
      SecureBuffer secureBuffer1 = new SecureBuffer(new byte[length1], BufferType.Data);
      Array.Copy((Array) signedMessage, sourceIndex1, (Array) secureBuffer1.Buffer, 0, length1);
      int sourceIndex2 = sourceIndex1 + length1;
      SecureBuffer secureBuffer2 = new SecureBuffer(new byte[length2], BufferType.Token);
      Array.Copy((Array) signedMessage, sourceIndex2, (Array) secureBuffer2.Buffer, 0, length2);
      int num2 = sourceIndex2 + length2;
      SecureBuffer[] buffers = new SecureBuffer[2]
      {
        secureBuffer1,
        secureBuffer2
      };
      SecureBufferAdapter adapter;
      using (adapter = new SecureBufferAdapter((IList<SecureBuffer>) buffers))
        errorCode = ContextNativeMethods.SafeVerifySignature(this.ContextHandle, 0, adapter, 0);
      if (errorCode == SecurityStatus.OK)
      {
        origMessage = secureBuffer1.Buffer;
        return true;
      }
      if (errorCode != SecurityStatus.MessageAltered && errorCode != SecurityStatus.OutOfSequence)
        throw new SSPIException("Failed to determine the veracity of a signed message.", errorCode);
      origMessage = (byte[]) null;
      return false;
    }

    private SecPkgContext_Sizes QueryBufferSizes()
    {
      SecPkgContext_Sizes sizes = new SecPkgContext_Sizes();
      SecurityStatus errorCode = SecurityStatus.InternalError;
      bool success = false;
      RuntimeHelpers.PrepareConstrainedRegions();
      try
      {
        this.ContextHandle.DangerousAddRef(ref success);
      }
      catch (Exception ex)
      {
        if (success)
        {
          this.ContextHandle.DangerousRelease();
          success = false;
        }
        throw;
      }
      finally
      {
        if (success)
        {
          errorCode = ContextNativeMethods.QueryContextAttributes_Sizes(ref this.ContextHandle.rawHandle, ContextQueryAttrib.Sizes, ref sizes);
          this.ContextHandle.DangerousRelease();
        }
      }
      if (errorCode != SecurityStatus.OK)
        throw new SSPIException("Failed to query context buffer size attributes", errorCode);
      return sizes;
    }

    private string QueryContextString(ContextQueryAttrib attrib)
    {
      SecurityStatus errorCode = SecurityStatus.InternalError;
      string str = (string) null;
      bool success = false;
      if (attrib != ContextQueryAttrib.Names && attrib != ContextQueryAttrib.Authority)
        throw new InvalidOperationException("QueryContextString can only be used to query context Name and Authority attributes");
      SecPkgContext_String names = new SecPkgContext_String();
      RuntimeHelpers.PrepareConstrainedRegions();
      try
      {
        this.ContextHandle.DangerousAddRef(ref success);
      }
      catch (Exception ex)
      {
        if (success)
        {
          this.ContextHandle.DangerousRelease();
          success = false;
        }
        throw;
      }
      finally
      {
        if (success)
        {
          errorCode = ContextNativeMethods.QueryContextAttributes_String(ref this.ContextHandle.rawHandle, attrib, ref names);
          this.ContextHandle.DangerousRelease();
          if (errorCode == SecurityStatus.OK)
          {
            str = Marshal.PtrToStringUni(names.StringResult);
            int num = (int) ContextNativeMethods.FreeContextBuffer(names.StringResult);
          }
        }
      }
      if (errorCode == SecurityStatus.Unsupported)
        return (string) null;
      if (errorCode != SecurityStatus.OK)
        throw new SSPIException("Failed to query the context's associated user name", errorCode);
      return str;
    }

    private void CheckLifecycle()
    {
      if (!this.Initialized)
        throw new InvalidOperationException("The context is not yet fully formed.");
      if (this.Disposed)
        throw new ObjectDisposedException(nameof (Context));
    }
  }
}
