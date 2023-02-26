// Decompiled with JetBrains decompiler
// Type: NSspi.Contexts.ClientContext
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using NSspi.Buffers;
using NSspi.Credentials;
using System;

namespace NSspi.Contexts
{
  public class ClientContext : Context
  {
    private ContextAttrib requestedAttribs;
    private ContextAttrib finalAttribs;
    private string serverPrinc;

    public ClientContext(Credential cred, string serverPrinc, ContextAttrib requestedAttribs)
      : base(cred)
    {
      this.serverPrinc = serverPrinc;
      this.requestedAttribs = requestedAttribs;
    }

    public SecurityStatus Init(byte[] serverToken, out byte[] outToken)
    {
      TimeStamp expiry = new TimeStamp();
      if (this.Disposed)
        throw new ObjectDisposedException(nameof (ClientContext));
      if (serverToken != null && this.ContextHandle.IsInvalid)
        throw new InvalidOperationException("Out-of-order usage detected - have a server token, but no previous client token had been created.");
      if (serverToken == null && !this.ContextHandle.IsInvalid)
        throw new InvalidOperationException("Must provide the server's response when continuing the init process.");
      SecureBuffer buffer1 = new SecureBuffer(new byte[this.Credential.PackageInfo.MaxTokenLength], BufferType.Token);
      SecureBuffer buffer2 = (SecureBuffer) null;
      if (serverToken != null)
        buffer2 = new SecureBuffer(serverToken, BufferType.Token);
      SecureBufferAdapter secureBufferAdapter1;
      SecurityStatus securityStatus;
      using (secureBufferAdapter1 = new SecureBufferAdapter(buffer1))
      {
        if (this.ContextHandle.IsInvalid)
        {
          securityStatus = ContextNativeMethods.InitializeSecurityContext_1(ref this.Credential.Handle.rawHandle, IntPtr.Zero, this.serverPrinc, this.requestedAttribs, 0, SecureBufferDataRep.Network, IntPtr.Zero, 0, ref this.ContextHandle.rawHandle, secureBufferAdapter1.Handle, ref this.finalAttribs, ref expiry);
        }
        else
        {
          SecureBufferAdapter secureBufferAdapter2;
          using (secureBufferAdapter2 = new SecureBufferAdapter(buffer2))
            securityStatus = ContextNativeMethods.InitializeSecurityContext_2(ref this.Credential.Handle.rawHandle, ref this.ContextHandle.rawHandle, this.serverPrinc, this.requestedAttribs, 0, SecureBufferDataRep.Network, secureBufferAdapter2.Handle, 0, ref this.ContextHandle.rawHandle, secureBufferAdapter1.Handle, ref this.finalAttribs, ref expiry);
        }
      }
      if (securityStatus.IsError())
        throw new SSPIException("Failed to invoke InitializeSecurityContext for a client", securityStatus);
      if (securityStatus == SecurityStatus.OK)
        this.Initialize(expiry.ToDateTime());
      outToken = (byte[]) null;
      if (buffer1.Length != 0)
      {
        outToken = new byte[buffer1.Length];
        Array.Copy((Array) buffer1.Buffer, (Array) outToken, outToken.Length);
      }
      return securityStatus;
    }
  }
}
