// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.IWebAuthentication`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.IdentityModel.Tokens;
using System.ServiceModel.Description;

namespace Microsoft.Xrm.Sdk.Client
{
  internal interface IWebAuthentication<TService>
  {
    SecurityTokenResponse Authenticate(
      ClientCredentials clientCredentials,
      Uri uri,
      string keyType);

    SecurityTokenResponse Authenticate(
      SecurityToken securityToken,
      Uri uri,
      string keyType);
  }
}
