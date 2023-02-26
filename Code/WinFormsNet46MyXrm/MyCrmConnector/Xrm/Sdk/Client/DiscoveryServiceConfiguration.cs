// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.DiscoveryServiceConfiguration
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

//using Microsoft.Xrm.Sdk.Discovery;
//using Microsoft.Xrm.Sdk.Discovery;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Discovery;
using System;
using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace MyCrmConnector.Client
{
    internal sealed class DiscoveryServiceConfiguration :
      Microsoft.Xrm.Sdk.Client.IServiceConfiguration<Microsoft.Xrm.Sdk.Discovery.IDiscoveryService>,
      //IWebAuthentication<IDiscoveryService>,
      Microsoft.Xrm.Sdk.Client.IServiceManagement<Microsoft.Xrm.Sdk.Discovery.IDiscoveryService>,
      Microsoft.Xrm.Sdk.Client.IEndpointSwitch
    {
        public Microsoft.Xrm.Sdk.Client.IssuerEndpoint CurrentIssuer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ServiceEndpoint CurrentServiceEndpoint { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Microsoft.Xrm.Sdk.Client.AuthenticationProviderType AuthenticationType => throw new NotImplementedException();

        public ServiceEndpointDictionary ServiceEndpoints => throw new NotImplementedException();

        public Microsoft.Xrm.Sdk.Client.IssuerEndpointDictionary IssuerEndpoints => throw new NotImplementedException();

        public Microsoft.Xrm.Sdk.Client.CrossRealmIssuerEndpointCollection CrossRealmIssuerEndpoints => throw new NotImplementedException();

        public Microsoft.Xrm.Sdk.Client.PolicyConfiguration PolicyConfiguration => throw new NotImplementedException();

        public bool EndpointAutoSwitchEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Uri AlternateEndpoint => throw new NotImplementedException();

        public Uri PrimaryEndpoint => throw new NotImplementedException();

        public bool IsPrimaryEndpoint => throw new NotImplementedException();

        private DiscoveryServiceConfiguration()
        {
        }

        internal DiscoveryServiceConfiguration(Uri serviceUri)
        {
            //this.service = new ServiceConfiguration<IDiscoveryService>(serviceUri, false);
            Console.WriteLine("DiscoveryServiceConfiguration");
            throw new NotImplementedException();
        }

        public event EventHandler<EndpointSwitchEventArgs> EndpointSwitched;
        public event EventHandler<EndpointSwitchEventArgs> EndpointSwitchRequired;

        public ChannelFactory<IDiscoveryService> CreateChannelFactory()
        {
            throw new NotImplementedException();
        }

        public ChannelFactory<IDiscoveryService> CreateChannelFactory(ClientAuthenticationType clientAuthenticationType)
        {
            throw new NotImplementedException();
        }

        public ChannelFactory<IDiscoveryService> CreateChannelFactory(Microsoft.Xrm.Sdk.Client.TokenServiceCredentialType endpointType)
        {
            throw new NotImplementedException();
        }

        public ChannelFactory<IDiscoveryService> CreateChannelFactory(ClientCredentials clientCredentials)
        {
            throw new NotImplementedException();
        }

        public SecurityTokenResponse Authenticate(ClientCredentials clientCredentials)
        {
            throw new NotImplementedException();
        }

        public SecurityTokenResponse Authenticate(SecurityToken securityToken)
        {
            throw new NotImplementedException();
        }

        public SecurityTokenResponse AuthenticateCrossRealm(ClientCredentials clientCredentials, string appliesTo, Uri crossRealmSts)
        {
            throw new NotImplementedException();
        }

        public SecurityTokenResponse AuthenticateCrossRealm(SecurityToken securityToken, string appliesTo, Uri crossRealmSts)
        {
            throw new NotImplementedException();
        }

        public SecurityTokenResponse Authenticate(ClientCredentials clientCredentials, SecurityTokenResponse deviceSecurityToken)
        {
            throw new NotImplementedException();
        }

        public SecurityTokenResponse AuthenticateDevice(ClientCredentials clientCredentials)
        {
            throw new NotImplementedException();
        }

        public Microsoft.Xrm.Sdk.Client.IdentityProvider GetIdentityProvider(string userPrincipalName)
        {
            throw new NotImplementedException();
        }

        public DiscoveryResponse Execute(DiscoveryRequest request)
        {
            throw new NotImplementedException();
        }

        public bool CanSwitch(Uri currentUri)
        {
            throw new NotImplementedException();
        }

        public void SwitchEndpoint()
        {
            throw new NotImplementedException();
        }

        public bool HandleEndpointSwitch()
        {
            throw new NotImplementedException();
        }

        public AuthenticationCredentials Authenticate(AuthenticationCredentials authenticationCredentials)
        {
            throw new NotImplementedException();
        }
    }
}
