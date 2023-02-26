﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.PolicyHelper
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

namespace MyCrmConnector.Client
{
  internal static class PolicyHelper
  {
    internal static string GetPolicyValue(
      AuthenticationPolicy xrmPolicy,
      string elementName,
      string defaultValue)
    {
      string str;
      return xrmPolicy != null && xrmPolicy.PolicyElements.TryGetValue(elementName, out str) ? str : defaultValue;
    }
  }
}
