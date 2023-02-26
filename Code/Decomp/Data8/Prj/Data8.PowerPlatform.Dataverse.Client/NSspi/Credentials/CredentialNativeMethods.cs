// Decompiled with JetBrains decompiler
// Type: NSspi.Credentials.CredentialNativeMethods
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace NSspi.Credentials
{
  internal static class CredentialNativeMethods
  {
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [DllImport("Secur32.dll", CharSet = CharSet.Unicode)]
    internal static extern SecurityStatus AcquireCredentialsHandle(
      string principleName,
      string packageName,
      CredentialUse credentialUse,
      IntPtr loginId,
      IntPtr packageData,
      IntPtr getKeyFunc,
      IntPtr getKeyData,
      ref RawSspiHandle credentialHandle,
      ref TimeStamp expiry);

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [DllImport("Secur32.dll", EntryPoint = "AcquireCredentialsHandle", CharSet = CharSet.Unicode)]
    internal static extern SecurityStatus AcquireCredentialsHandle_AuthData(
      string principleName,
      string packageName,
      CredentialUse credentialUse,
      IntPtr loginId,
      ref NativeAuthData authData,
      IntPtr getKeyFunc,
      IntPtr getKeyData,
      ref RawSspiHandle credentialHandle,
      ref TimeStamp expiry);

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    [DllImport("Secur32.dll", CharSet = CharSet.Unicode)]
    internal static extern SecurityStatus FreeCredentialsHandle(
      ref RawSspiHandle credentialHandle);

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    [DllImport("Secur32.dll", EntryPoint = "QueryCredentialsAttributes", CharSet = CharSet.Unicode)]
    internal static extern SecurityStatus QueryCredentialsAttribute_Name(
      ref RawSspiHandle credentialHandle,
      CredentialQueryAttrib attributeName,
      ref QueryNameAttribCarrier name);
  }
}
