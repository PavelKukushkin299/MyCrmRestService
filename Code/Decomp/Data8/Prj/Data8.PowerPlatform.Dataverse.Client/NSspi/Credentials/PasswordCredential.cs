// Decompiled with JetBrains decompiler
// Type: NSspi.Credentials.PasswordCredential
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System;
using System.Runtime.CompilerServices;

namespace NSspi.Credentials
{
  public class PasswordCredential : Credential
  {
    public PasswordCredential(
      string domain,
      string username,
      string password,
      string secPackage,
      CredentialUse use)
      : base(secPackage)
    {
      this.Init(new NativeAuthData(domain, username, password, NativeAuthDataFlag.Unicode), secPackage, use);
    }

    private void Init(NativeAuthData authData, string secPackage, CredentialUse use)
    {
      TimeStamp expiry = new TimeStamp();
      SecurityStatus errorCode = SecurityStatus.InternalError;
      string securityPackage = this.SecurityPackage;
      this.Handle = new SafeCredentialHandle();
      RuntimeHelpers.PrepareConstrainedRegions();
      try
      {
      }
      finally
      {
        errorCode = CredentialNativeMethods.AcquireCredentialsHandle_AuthData((string) null, securityPackage, use, IntPtr.Zero, ref authData, IntPtr.Zero, IntPtr.Zero, ref this.Handle.rawHandle, ref expiry);
      }
      if (errorCode != SecurityStatus.OK)
        throw new SSPIException("Failed to call AcquireCredentialHandle", errorCode);
      this.Expiry = expiry.ToDateTime();
    }
  }
}
