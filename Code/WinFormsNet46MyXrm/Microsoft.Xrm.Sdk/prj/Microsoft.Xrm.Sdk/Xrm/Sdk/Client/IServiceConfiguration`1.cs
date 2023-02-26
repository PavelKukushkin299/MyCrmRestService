// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.IServiceConfiguration`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Microsoft.Xrm.Sdk.Client
{
  public interface IServiceConfiguration<TService>
  {
    IssuerEndpoint CurrentIssuer { get; set; }

    ServiceEndpoint CurrentServiceEndpoint { get; set; }

    AuthenticationProviderType AuthenticationType { get; }

    ServiceEndpointDictionary ServiceEndpoints { get; }

    IssuerEndpointDictionary IssuerEndpoints { get; }

    CrossRealmIssuerEndpointCollection CrossRealmIssuerEndpoints { get; }

    PolicyConfiguration PolicyConfiguration { get; }

    ChannelFactory<TService> CreateChannelFactory();

    ChannelFactory<TService> CreateChannelFactory(
      ClientAuthenticationType clientAuthenticationType);

    ChannelFactory<TService> CreateChannelFactory(
      TokenServiceCredentialType endpointType);

    ChannelFactory<TService> CreateChannelFactory(ClientCredentials clientCredentials);

    SecurityTokenResponse Authenticate(ClientCredentials clientCredentials);

    SecurityTokenResponse Authenticate(SecurityToken securityToken);

    SecurityTokenResponse AuthenticateCrossRealm(
      ClientCredentials clientCredentials,
      string appliesTo,
      Uri crossRealmSts);

    SecurityTokenResponse AuthenticateCrossRealm(
      SecurityToken securityToken,
      string appliesTo,
      Uri crossRealmSts);

    SecurityTokenResponse Authenticate(
      ClientCredentials clientCredentials,
      SecurityTokenResponse deviceSecurityToken);

    SecurityTokenResponse AuthenticateDevice(
      ClientCredentials clientCredentials);

    IdentityProvider GetIdentityProvider(string userPrincipalName);
  }
}
