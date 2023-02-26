// Decompiled with JetBrains decompiler
// Type: NSspi.SecurityStatusExtensions
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

namespace NSspi
{
  public static class SecurityStatusExtensions
  {
    public static bool IsError(this SecurityStatus status) => status > (SecurityStatus) 2147483648;
  }
}
