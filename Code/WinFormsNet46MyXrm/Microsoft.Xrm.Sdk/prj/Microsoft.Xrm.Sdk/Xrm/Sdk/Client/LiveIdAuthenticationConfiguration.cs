// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.LiveIdAuthenticationConfiguration
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

namespace Microsoft.Xrm.Sdk.Client
{
  internal static class LiveIdAuthenticationConfiguration
  {
    internal static string DeviceTokenId = "urn:liveid:device";
    internal static string UserNameTokenId = "user";
    internal static string DeviceUserNameTokenId = "devicesoftware";
    internal static string PolicyReference = "http://schemas.xmlsoap.org/ws/2004/09/policy";
    internal static string SecurityTokenSchema = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";
    internal static string DefaultPolicy = "MBI_FED_SSL";
  }
}
