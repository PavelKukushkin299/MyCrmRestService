// Decompiled with JetBrains decompiler
// Type: NSspi.Credentials.NativeAuthData
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System.Runtime.InteropServices;

namespace NSspi.Credentials
{
  internal struct NativeAuthData
  {
    [MarshalAs(UnmanagedType.LPWStr)]
    public string User;
    public int UserLength;
    [MarshalAs(UnmanagedType.LPWStr)]
    public string Domain;
    public int DomainLength;
    [MarshalAs(UnmanagedType.LPWStr)]
    public string Password;
    public int PasswordLength;
    public NativeAuthDataFlag Flags;

    public NativeAuthData(
      string domain,
      string username,
      string password,
      NativeAuthDataFlag flag)
    {
      this.Domain = domain;
      this.DomainLength = domain.Length;
      this.User = username;
      this.UserLength = username.Length;
      this.Password = password;
      this.PasswordLength = password.Length;
      this.Flags = flag;
    }
  }
}
