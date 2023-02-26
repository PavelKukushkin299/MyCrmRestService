// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.DiscoveryServiceConfiguration
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Discovery;
using System;
using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Microsoft.Xrm.Sdk.Client
{
  internal sealed class DiscoveryServiceConfiguration : 
    IServiceConfiguration<IDiscoveryService>,
    IWebAuthentication<IDiscoveryService>,
    IServiceManagement<IDiscoveryService>,
    IEndpointSwitch
  {
    private readonly ServiceConfiguration<IDiscoveryService> service;

    private DiscoveryServiceConfiguration()
    {
    }

    internal DiscoveryServiceConfiguration(Uri serviceUri) => this.service = new ServiceConfiguration<IDiscoveryService>(serviceUri, false);

    public ServiceEndpoint CurrentServiceEndpoint
    {
      get => this.service.CurrentServiceEndpoint;
      set => this.service.CurrentServiceEndpoint = value;
    }

    public IssuerEndpoint CurrentIssuer
    {
      get => this.service.CurrentIssuer;
      set => this.service.CurrentIssuer = value;
    }

    public AuthenticationProviderType AuthenticationType => this.service.AuthenticationType;

    public ServiceEndpointDictionary ServiceEndpoints => this.service.ServiceEndpoints;

    public IssuerEndpointDictionary IssuerEndpoints => this.service.IssuerEndpoints;

    public CrossRealmIssuerEndpointCollection CrossRealmIssuerEndpoints => this.service.CrossRealmIssuerEndpoints;

    public ChannelFactory<IDiscoveryService> CreateChannelFactory() => this.service.CreateChannelFactory(ClientAuthenticationType.Kerberos);

    public ChannelFactory<IDiscoveryService> CreateChannelFactory(
      ClientAuthenticationType clientAuthenticationType)
    {
      return this.service.CreateChannelFactory(clientAuthenticationType);
    }

    public ChannelFactory<IDiscoveryService> CreateChannelFactory(
      TokenServiceCredentialType endpointType)
    {
      return this.service.CreateChannelFactory(endpointType);
    }

    public ChannelFactory<IDiscoveryService> CreateChannelFactory(
      ClientCredentials clientCredentials)
    {
      return this.service.CreateChannelFactory(clientCredentials);
    }

    public SecurityTokenResponse Authenticate(
      ClientCredentials clientCredentials)
    {
      return this.service.Authenticate(clientCredentials);
    }

    public SecurityTokenResponse Authenticate(SecurityToken securityToken) => this.service.Authenticate(securityToken);

    public SecurityTokenResponse AuthenticateCrossRealm(
      ClientCredentials clientCredentials,
      string appliesTo,
      Uri crossRealmSts)
    {
      return this.service.AuthenticateCrossRealm(clientCredentials, appliesTo, crossRealmSts);
    }

    public SecurityTokenResponse AuthenticateCrossRealm(
      SecurityToken securityToken,
      string appliesTo,
      Uri crossRealmSts)
    {
      return this.service.AuthenticateCrossRealm(securityToken, appliesTo, crossRealmSts);
    }

    public SecurityTokenResponse Authenticate(
      ClientCredentials clientCredentials,
      SecurityTokenResponse deviceSecurityTokenResponse)
    {
      throw new InvalidOperationException("Authentication to MSA services is not supported.");
    }

    public SecurityTokenResponse AuthenticateDevice(
      ClientCredentials clientCredentials)
    {
      throw new InvalidOperationException("Authentication to MSA services is not supported.");
    }

    public PolicyConfiguration PolicyConfiguration => this.service.PolicyConfiguration;

    public IdentityProvider GetIdentityProvider(string userPrincipalName) => this.service.GetIdentityProvider(userPrincipalName);

    public SecurityTokenResponse Authenticate(
      ClientCredentials clientCredentials,
      Uri uri,
      string keyType)
    {
      return this.service.Authenticate(clientCredentials, uri, keyType);
    }

    public SecurityTokenResponse Authenticate(
      SecurityToken securityToken,
      Uri uri,
      string keyType)
    {
      return this.service.Authenticate(securityToken, uri, keyType);
    }

    public AuthenticationCredentials Authenticate(
      AuthenticationCredentials authenticationCredentials)
    {
      return this.service.Authenticate(authenticationCredentials);
    }

    public bool EndpointAutoSwitchEnabled
    {
      get => this.service.EndpointAutoSwitchEnabled;
      set => this.service.EndpointAutoSwitchEnabled = value;
    }

    public Uri AlternateEndpoint => this.service.AlternateEndpoint;

    public Uri PrimaryEndpoint => this.service.PrimaryEndpoint;

    public void SwitchEndpoint() => this.service.SwitchEndpoint();

    public bool HandleEndpointSwitch() => this.service.HandleEndpointSwitch();

    public event EventHandler<EndpointSwitchEventArgs> EndpointSwitched
    {
      add => this.service.EndpointSwitched += value;
      remove => this.service.EndpointSwitched -= value;
    }

    public event EventHandler<EndpointSwitchEventArgs> EndpointSwitchRequired
    {
      add => this.service.EndpointSwitchRequired += value;
      remove => this.service.EndpointSwitchRequired -= value;
    }

    public bool IsPrimaryEndpoint => this.service.IsPrimaryEndpoint;

    public bool CanSwitch(Uri currentUri) => this.service.CanSwitch(currentUri);
  }
}
