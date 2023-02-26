// Decompiled with JetBrains decompiler
// Type: NSspi.Contexts.ContextNativeMethods
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using NSspi.Buffers;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace NSspi.Contexts
{
  internal static class ContextNativeMethods
  {
    [DllImport("Secur32.dll", EntryPoint = "AcceptSecurityContext", CharSet = CharSet.Unicode)]
    internal static extern SecurityStatus AcceptSecurityContext_1(
      ref RawSspiHandle credHandle,
      IntPtr oldContextHandle,
      IntPtr inputBuffer,
      ContextAttrib requestedAttribs,
      SecureBufferDataRep dataRep,
      ref RawSspiHandle newContextHandle,
      IntPtr outputBuffer,
      ref ContextAttrib outputAttribs,
      ref TimeStamp expiry);

    [DllImport("Secur32.dll", EntryPoint = "AcceptSecurityContext", CharSet = CharSet.Unicode)]
    internal static extern SecurityStatus AcceptSecurityContext_2(
      ref RawSspiHandle credHandle,
      ref RawSspiHandle oldContextHandle,
      IntPtr inputBuffer,
      ContextAttrib requestedAttribs,
      SecureBufferDataRep dataRep,
      ref RawSspiHandle newContextHandle,
      IntPtr outputBuffer,
      ref ContextAttrib outputAttribs,
      ref TimeStamp expiry);

    [DllImport("Secur32.dll", EntryPoint = "InitializeSecurityContext", CharSet = CharSet.Unicode)]
    internal static extern SecurityStatus InitializeSecurityContext_1(
      ref RawSspiHandle credentialHandle,
      IntPtr zero,
      string serverPrincipleName,
      ContextAttrib requiredAttribs,
      int reserved1,
      SecureBufferDataRep dataRep,
      IntPtr inputBuffer,
      int reserved2,
      ref RawSspiHandle newContextHandle,
      IntPtr outputBuffer,
      ref ContextAttrib contextAttribs,
      ref TimeStamp expiry);

    [DllImport("Secur32.dll", EntryPoint = "InitializeSecurityContext", CharSet = CharSet.Unicode)]
    internal static extern SecurityStatus InitializeSecurityContext_2(
      ref RawSspiHandle credentialHandle,
      ref RawSspiHandle previousHandle,
      string serverPrincipleName,
      ContextAttrib requiredAttribs,
      int reserved1,
      SecureBufferDataRep dataRep,
      IntPtr inputBuffer,
      int reserved2,
      ref RawSspiHandle newContextHandle,
      IntPtr outputBuffer,
      ref ContextAttrib contextAttribs,
      ref TimeStamp expiry);

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    [DllImport("Secur32.dll", CharSet = CharSet.Unicode)]
    internal static extern SecurityStatus DeleteSecurityContext(
      ref RawSspiHandle contextHandle);

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [DllImport("Secur32.dll", CharSet = CharSet.Unicode)]
    internal static extern SecurityStatus EncryptMessage(
      ref RawSspiHandle contextHandle,
      int qualityOfProtection,
      IntPtr bufferDescriptor,
      int sequenceNumber);

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [DllImport("Secur32.dll", CharSet = CharSet.Unicode)]
    internal static extern SecurityStatus DecryptMessage(
      ref RawSspiHandle contextHandle,
      IntPtr bufferDescriptor,
      int sequenceNumber,
      int qualityOfProtection);

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [DllImport("Secur32.dll", CharSet = CharSet.Unicode)]
    internal static extern SecurityStatus MakeSignature(
      ref RawSspiHandle contextHandle,
      int qualityOfProtection,
      IntPtr bufferDescriptor,
      int sequenceNumber);

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [DllImport("Secur32.dll", CharSet = CharSet.Unicode)]
    internal static extern SecurityStatus VerifySignature(
      ref RawSspiHandle contextHandle,
      IntPtr bufferDescriptor,
      int sequenceNumber,
      int qualityOfProtection);

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    [DllImport("Secur32.dll", EntryPoint = "QueryContextAttributes", CharSet = CharSet.Unicode)]
    internal static extern SecurityStatus QueryContextAttributes_Sizes(
      ref RawSspiHandle contextHandle,
      ContextQueryAttrib attrib,
      ref SecPkgContext_Sizes sizes);

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    [DllImport("Secur32.dll", EntryPoint = "QueryContextAttributes", CharSet = CharSet.Unicode)]
    internal static extern SecurityStatus QueryContextAttributes_String(
      ref RawSspiHandle contextHandle,
      ContextQueryAttrib attrib,
      ref SecPkgContext_String names);

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    [DllImport("Secur32.dll", CharSet = CharSet.Unicode)]
    internal static extern SecurityStatus QueryContextAttributes(
      ref RawSspiHandle contextHandle,
      ContextQueryAttrib attrib,
      IntPtr attribute);

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    [DllImport("Secur32.dll", CharSet = CharSet.Unicode)]
    internal static extern SecurityStatus FreeContextBuffer(IntPtr handle);

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    [DllImport("Secur32.dll", CharSet = CharSet.Unicode)]
    internal static extern SecurityStatus ImpersonateSecurityContext(
      ref RawSspiHandle contextHandle);

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    [DllImport("Secur32.dll", CharSet = CharSet.Unicode)]
    internal static extern SecurityStatus RevertSecurityContext(
      ref RawSspiHandle contextHandle);

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    [DllImport("Secur32.dll", SetLastError = true)]
    internal static extern SecurityStatus QuerySecurityContextToken(
      ref RawSspiHandle contextHandle,
      out SafeTokenHandle handle);

    internal static SecurityStatus SafeQueryContextAttribute(
      SafeContextHandle handle,
      ContextQueryAttrib attribute,
      ref byte[] buffer)
    {
      bool success = false;
      SecurityStatus securityStatus = SecurityStatus.InternalError;
      RuntimeHelpers.PrepareConstrainedRegions();
      IntPtr num = Marshal.AllocHGlobal(4 + (Environment.Is64BitOperatingSystem ? 8 : 4));
      try
      {
        handle.DangerousAddRef(ref success);
      }
      catch (Exception ex)
      {
        if (success)
        {
          handle.DangerousRelease();
          success = false;
          buffer = (byte[]) null;
        }
        throw;
      }
      finally
      {
        if (success)
        {
          securityStatus = ContextNativeMethods.QueryContextAttributes(ref handle.rawHandle, attribute, num);
          if (securityStatus == SecurityStatus.OK)
          {
            ContextNativeMethods.KeyStruct structure = new ContextNativeMethods.KeyStruct();
            Marshal.PtrToStructure<ContextNativeMethods.KeyStruct>(num, structure);
            byte[] numArray = new byte[structure.size];
            for (int ofs = 0; ofs < structure.size; ++ofs)
              numArray[ofs] = Marshal.ReadByte(structure.data, ofs);
            buffer = numArray;
          }
          handle.DangerousRelease();
        }
      }
      Marshal.FreeHGlobal(num);
      return securityStatus;
    }

    internal static SecurityStatus SafeEncryptMessage(
      SafeContextHandle handle,
      int qualityOfProtection,
      SecureBufferAdapter bufferAdapter,
      int sequenceNumber)
    {
      SecurityStatus securityStatus = SecurityStatus.InternalError;
      bool success = false;
      RuntimeHelpers.PrepareConstrainedRegions();
      try
      {
        handle.DangerousAddRef(ref success);
      }
      catch (Exception ex)
      {
        if (success)
        {
          handle.DangerousRelease();
          success = false;
        }
        throw;
      }
      finally
      {
        if (success)
        {
          securityStatus = ContextNativeMethods.EncryptMessage(ref handle.rawHandle, qualityOfProtection, bufferAdapter.Handle, sequenceNumber);
          handle.DangerousRelease();
        }
      }
      return securityStatus;
    }

    internal static SecurityStatus SafeDecryptMessage(
      SafeContextHandle handle,
      int qualityOfProtection,
      SecureBufferAdapter bufferAdapter,
      int sequenceNumber)
    {
      SecurityStatus securityStatus = SecurityStatus.InvalidHandle;
      bool success = false;
      RuntimeHelpers.PrepareConstrainedRegions();
      try
      {
        handle.DangerousAddRef(ref success);
      }
      catch (Exception ex)
      {
        if (success)
        {
          handle.DangerousRelease();
          success = false;
        }
        throw;
      }
      finally
      {
        if (success)
        {
          securityStatus = ContextNativeMethods.DecryptMessage(ref handle.rawHandle, bufferAdapter.Handle, sequenceNumber, qualityOfProtection);
          handle.DangerousRelease();
        }
      }
      return securityStatus;
    }

    internal static SecurityStatus SafeMakeSignature(
      SafeContextHandle handle,
      int qualityOfProtection,
      SecureBufferAdapter adapter,
      int sequenceNumber)
    {
      bool success = false;
      SecurityStatus securityStatus = SecurityStatus.InternalError;
      RuntimeHelpers.PrepareConstrainedRegions();
      try
      {
        handle.DangerousAddRef(ref success);
      }
      catch (Exception ex)
      {
        if (success)
        {
          handle.DangerousRelease();
          success = false;
        }
        throw;
      }
      finally
      {
        if (success)
        {
          securityStatus = ContextNativeMethods.MakeSignature(ref handle.rawHandle, qualityOfProtection, adapter.Handle, sequenceNumber);
          handle.DangerousRelease();
        }
      }
      return securityStatus;
    }

    internal static SecurityStatus SafeVerifySignature(
      SafeContextHandle handle,
      int qualityOfProtection,
      SecureBufferAdapter adapter,
      int sequenceNumber)
    {
      bool success = false;
      SecurityStatus securityStatus = SecurityStatus.InternalError;
      RuntimeHelpers.PrepareConstrainedRegions();
      try
      {
        handle.DangerousAddRef(ref success);
      }
      catch (Exception ex)
      {
        if (success)
        {
          handle.DangerousRelease();
          success = false;
        }
        throw;
      }
      finally
      {
        if (success)
        {
          securityStatus = ContextNativeMethods.VerifySignature(ref handle.rawHandle, adapter.Handle, sequenceNumber, qualityOfProtection);
          handle.DangerousRelease();
        }
      }
      return securityStatus;
    }

    [StructLayout(LayoutKind.Sequential)]
    private class KeyStruct
    {
      public int size;
      public IntPtr data;
    }
  }
}
