// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.ServiceConfiguration`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

//using Microsoft.Crm.Protocols.WSTrust.Bindings;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.Text;
using Microsoft.Xrm.Sdk;

namespace MyCrmConnector.Client
{
    [SecuritySafeCritical]
    [SecurityPermission(SecurityAction.Demand, Unrestricted = true)]
    internal sealed class ServiceConfiguration<TService> : IEndpointSwitch
    {
        private ServiceEndpoint currentServiceEndpoint;
        public Uri ServiceUri { get; internal set; }
        public ServiceEndpointMetadata ServiceEndpointMetadata { get; private set; }
        public ServiceEndpointDictionary ServiceEndpoints { get; internal set; }
        public CrossRealmIssuerEndpointCollection CrossRealmIssuerEndpoints { get; internal set; }
        public IssuerEndpointDictionary IssuerEndpoints { get; internal set; }
        public PolicyConfiguration PolicyConfiguration { get; set; }
        
        public ServiceEndpoint CurrentServiceEndpoint
        {
            get
            {
                if (this.currentServiceEndpoint == null)
                {
                    foreach (ServiceEndpoint serviceEndpoint in this.ServiceEndpoints.Values)
                    {
                        if (this.ServiceUri.Port == serviceEndpoint.Address.Uri.Port && this.ServiceUri.Scheme == serviceEndpoint.Address.Uri.Scheme)
                        {
                            this.currentServiceEndpoint = serviceEndpoint;
                            break;
                        }
                    }
                }
                return this.currentServiceEndpoint;
            }
            set => this.currentServiceEndpoint = value;
        }

        
        internal ServiceConfiguration(Uri serviceUri, bool checkForSecondary)
        {
            this.ServiceUri = serviceUri;
            this.ServiceEndpointMetadata = ServiceMetadataUtility.RetrieveServiceEndpointMetadata(typeof(TService), this.ServiceUri, checkForSecondary);
            ClientExceptionHelper.ThrowIfNull((object)this.ServiceEndpointMetadata, nameof(ServiceEndpointMetadata));
            if (this.ServiceEndpointMetadata.ServiceEndpoints.Count == 0)
            {
                StringBuilder stringBuilder = new StringBuilder();
                if (this.ServiceEndpointMetadata.MetadataConversionErrors.Count > 0)
                {
                    foreach (MetadataConversionError metadataConversionError in this.ServiceEndpointMetadata.MetadataConversionErrors)
                        stringBuilder.Append(metadataConversionError.Message);
                }
                throw new InvalidOperationException(ClientExceptionHelper.FormatMessage(0, (object)"The provided uri did not return any Service Endpoints!\n{0}", (object)stringBuilder.ToString()));
            }
            this.ServiceEndpoints = this.ServiceEndpointMetadata.ServiceEndpoints;
            if (this.CurrentServiceEndpoint == null)
            {
                return;
            }
            this.CrossRealmIssuerEndpoints = new CrossRealmIssuerEndpointCollection();
            this.SetAuthenticationConfiguration();
            if (checkForSecondary)
            {
                throw new NotImplementedException(); 
                //this.SetEndpointSwitchingBehavior();
            }
            else
            {
                if (this.CurrentServiceEndpoint.Address.Uri != serviceUri)
                {
                    ServiceMetadataUtility.ReplaceEndpointAddress(this.CurrentServiceEndpoint, serviceUri);
                }
                this.PrimaryEndpoint = serviceUri;
            }
        }

        internal ChannelFactory<IOrganizationService> CreateChannelFactory(TokenServiceCredentialType endpointType)
        {
            //ClientExceptionHelper.ThrowIfNull((object)this.CurrentServiceEndpoint, "CurrentServiceEndpoint");
            //if (this.ClaimsEnabledService)
            //{
            //    IssuerEndpoint issuerEndpoint = this.IssuerEndpoints.GetIssuerEndpoint(endpointType);
            //    if (issuerEndpoint != null)
            //    {
            //        lock (ServiceConfiguration<TService>._lockObject)
            //            this.CurrentServiceEndpoint.Binding = (Binding)ServiceMetadataUtility.SetIssuer(this.CurrentServiceEndpoint.Binding, issuerEndpoint);
            //    }
            //}
            //ChannelFactory<TService> localChannelFactory = this.CreateLocalChannelFactory();
            //localChannelFactory.Credentials.SupportInteractive = false;
            //return localChannelFactory;
            throw new NotImplementedException();
        }

        public ChannelFactory<TService> CreateChannelFactory(
            ClientAuthenticationType clientAuthenticationType)
        {
            //ClientExceptionHelper.ThrowIfNull((object)this.CurrentServiceEndpoint, "CurrentServiceEndpoint");
            //if (this.ClaimsEnabledService)
            //{
            //    IssuerEndpoint issuerEndpoint = this.IssuerEndpoints.GetIssuerEndpoint(clientAuthenticationType != ClientAuthenticationType.SecurityToken ? TokenServiceCredentialType.Kerberos : (this.AuthenticationType == AuthenticationProviderType.OnlineFederation ? TokenServiceCredentialType.SymmetricToken : this._tokenEndpointType));
            //    if (issuerEndpoint != null)
            //    {
            //        lock (ServiceConfiguration<TService>._lockObject)
            //            this.CurrentServiceEndpoint.Binding = (Binding)ServiceMetadataUtility.SetIssuer(this.CurrentServiceEndpoint.Binding, issuerEndpoint);
            //    }
            //}
            //ChannelFactory<TService> localChannelFactory = this.CreateLocalChannelFactory();
            //localChannelFactory.Credentials.SupportInteractive = false;
            //return localChannelFactory;
            throw new NotImplementedException();
        }

        public SecurityTokenResponse AuthenticateCrossRealm(
            SecurityToken securityToken,
            string appliesTo,
            Uri crossRealmSts)
        {
            //if (!(crossRealmSts != (Uri)null))
            //    return (SecurityTokenResponse)null;
            //AuthenticationCredentials authenticationCredentials = new AuthenticationCredentials();
            //authenticationCredentials.AppliesTo = !string.IsNullOrWhiteSpace(appliesTo) ? new Uri(appliesTo) : (Uri)null;
            //authenticationCredentials.KeyType = string.Empty;
            //authenticationCredentials.ClientCredentials = (ClientCredentials)null;
            //authenticationCredentials.SecurityTokenResponse = new SecurityTokenResponse()
            //{
            //    Token = securityToken
            //};
            //bool flag = true;
            //if (this.AuthenticationType == AuthenticationProviderType.OnlineFederation)
            //{
            //    IdentityProviderTrustConfiguration trustConfiguration = this.TryGetOnlineTrustConfiguration(crossRealmSts);
            //    if (trustConfiguration != null && trustConfiguration.Endpoint.GetServiceRoot() == crossRealmSts)
            //    {
            //        authenticationCredentials.EndpointType = TokenServiceCredentialType.SymmetricToken;
            //        flag = false;
            //    }
            //}
            //if (flag)
            //    authenticationCredentials.EndpointType = this._tokenEndpointType;
            //authenticationCredentials.IssuerEndpoints = this.CrossRealmIssuerEndpoints[crossRealmSts];
            //return this.AuthenticateInternal(authenticationCredentials);
            throw new NotImplementedException();
        }

        public IdentityProvider GetIdentityProvider(string userPrincipalName)
        {
            //IdentityProviderTrustConfiguration trustConfiguration = this.TryGetOnlineTrustConfiguration();
            //return trustConfiguration == null ? (IdentityProvider)null : IdentityProviderLookup.Instance.GetIdentityProvider(trustConfiguration.Endpoint.GetServiceRoot(), trustConfiguration.Endpoint.GetServiceRoot(), userPrincipalName);
            throw new NotImplementedException();
        }

        public ChannelFactory<TService> CreateChannelFactory(
            ClientCredentials clientCredentials)
        {
            //ClientExceptionHelper.ThrowIfNull((object)this.CurrentServiceEndpoint, "CurrentServiceEndpoint");
            //if (this.ClaimsEnabledService)
            //{
            //    IssuerEndpoint issuerEndpoint = this.IssuerEndpoints.GetIssuerEndpoint(this.GetCredentialsEndpointType(clientCredentials));
            //    if (issuerEndpoint != null)
            //    {
            //        lock (ServiceConfiguration<TService>._lockObject)
            //            this.CurrentServiceEndpoint.Binding = (Binding)ServiceMetadataUtility.SetIssuer(this.CurrentServiceEndpoint.Binding, issuerEndpoint);
            //    }
            //}
            //ChannelFactory<TService> localChannelFactory = this.CreateLocalChannelFactory();
            //this.ConfigureCredentials((ChannelFactory)localChannelFactory, clientCredentials);
            //localChannelFactory.Credentials.SupportInteractive = clientCredentials != null && clientCredentials.SupportInteractive;
            //return localChannelFactory;
            throw new NotImplementedException();
        }

        public SecurityTokenResponse Authenticate(
            ClientCredentials clientCredentials)
        {
            //if (this.CurrentServiceEndpoint != null)
            //{
            //    AuthenticationCredentials authenticationCredentials = this.Authenticate(new AuthenticationCredentials()
            //    {
            //        ClientCredentials = clientCredentials
            //    });
            //    if (authenticationCredentials != null && authenticationCredentials.SecurityTokenResponse != null)
            //        return authenticationCredentials.SecurityTokenResponse;
            //}
            //return (SecurityTokenResponse)null;
            throw new NotImplementedException();
        }

        internal SecurityTokenResponse Authenticate(
            ClientCredentials clientCredentials,
            Uri uri,
            string keyType)
        {
            //return this.AuthenticateInternal(new AuthenticationCredentials()
            //{
            //    AppliesTo = uri,
            //    EndpointType = this.GetCredentialsEndpointType(clientCredentials),
            //    KeyType = keyType,
            //    IssuerEndpoints = this.IssuerEndpoints,
            //    ClientCredentials = clientCredentials,
            //    SecurityTokenResponse = (SecurityTokenResponse)null
            //});
            throw new NotImplementedException();
        }

        public SecurityTokenResponse AuthenticateCrossRealm(
            ClientCredentials clientCredentials,
            string appliesTo,
            Uri crossRealmSts)
        {
            //if (!(crossRealmSts != (Uri)null))
            //    return (SecurityTokenResponse)null;
            //AuthenticationCredentials authenticationCredentials = new AuthenticationCredentials();
            //authenticationCredentials.AppliesTo = !string.IsNullOrWhiteSpace(appliesTo) ? new Uri(appliesTo) : (Uri)null;
            //authenticationCredentials.KeyType = string.Empty;
            //authenticationCredentials.ClientCredentials = clientCredentials;
            //authenticationCredentials.SecurityTokenResponse = (SecurityTokenResponse)null;
            //IdentityProviderTrustConfiguration trustConfiguration = this.TryGetOnlineTrustConfiguration(crossRealmSts);
            //authenticationCredentials.EndpointType = trustConfiguration != null ? TokenServiceCredentialType.Username : this.GetCredentialsEndpointType(clientCredentials);
            //authenticationCredentials.IssuerEndpoints = this.CrossRealmIssuerEndpoints[crossRealmSts];
            //if (this.AuthenticationType == AuthenticationProviderType.OnlineFederation && trustConfiguration == null)
            //    authenticationCredentials.KeyType = "http://schemas.microsoft.com/idfx/keytype/bearer";
            //return this.AuthenticateInternal(authenticationCredentials);
            throw new NotImplementedException();
        }

        public SecurityTokenResponse Authenticate(SecurityToken securityToken)
        {
            //ClientExceptionHelper.ThrowIfNull((object)securityToken, nameof(securityToken));
            //if (this.AuthenticationType == AuthenticationProviderType.OnlineFederation)
            //{
            //    IdentityProviderTrustConfiguration trustConfiguration = this.TryGetOnlineTrustConfiguration();
            //    return trustConfiguration == null ? (SecurityTokenResponse)null : this.AuthenticateCrossRealm(securityToken, trustConfiguration.AppliesTo, trustConfiguration.Endpoint.GetServiceRoot());
            //}
            //if (this.CurrentServiceEndpoint == null)
            //    return (SecurityTokenResponse)null;
            //return this.AuthenticateInternal(new AuthenticationCredentials()
            //{
            //    AppliesTo = this.CurrentServiceEndpoint.Address.Uri,
            //    EndpointType = this._tokenEndpointType,
            //    KeyType = string.Empty,
            //    IssuerEndpoints = this.IssuerEndpoints,
            //    ClientCredentials = (ClientCredentials)null,
            //    SecurityTokenResponse = new SecurityTokenResponse()
            //    {
            //        Token = securityToken
            //    }
            //});
            throw new NotImplementedException();
        }

        internal SecurityTokenResponse Authenticate(
            SecurityToken securityToken,
            Uri uri,
            string keyType)
        {
            //ClientExceptionHelper.ThrowIfNull((object)securityToken, nameof(securityToken));
            //if (!(uri != (Uri)null))
            //    return (SecurityTokenResponse)null;
            //return this.AuthenticateInternal(new AuthenticationCredentials()
            //{
            //    AppliesTo = uri.GetServiceRoot(),
            //    EndpointType = this._tokenEndpointType,
            //    KeyType = keyType,
            //    IssuerEndpoints = this.IssuerEndpoints,
            //    ClientCredentials = (ClientCredentials)null,
            //    SecurityTokenResponse = new SecurityTokenResponse()
            //    {
            //        Token = securityToken
            //    }
            //});
            throw new NotImplementedException();
        }

        public AuthenticationCredentials Authenticate(
            AuthenticationCredentials authenticationCredentials)
        {
            //ClientExceptionHelper.ThrowIfNull((object)authenticationCredentials, nameof(authenticationCredentials));
            //switch (this.AuthenticationType)
            //{
            //    case AuthenticationProviderType.ActiveDirectory:
            //        ServiceMetadataUtility.AdjustUserNameForWindows(authenticationCredentials.ClientCredentials);
            //        return authenticationCredentials;
            //    case AuthenticationProviderType.Federation:
            //        return this.AuthenticateFederationInternal(authenticationCredentials);
            //    case AuthenticationProviderType.OnlineFederation:
            //        return this.AuthenticateOnlineFederationInternal(authenticationCredentials);
            //    default:
            //        return authenticationCredentials;
            //}
            throw new NotImplementedException();
        }


        private void SetAuthenticationConfiguration()
        {
            if (this.CurrentServiceEndpoint.Binding == null)
                return;
            AuthenticationPolicy xrmPolicy = this.CurrentServiceEndpoint.Binding.CreateBindingElements().Find<AuthenticationPolicy>();
            if (xrmPolicy == null || !xrmPolicy.PolicyElements.ContainsKey("AuthenticationType"))
                return;
            string policyElement = xrmPolicy.PolicyElements["AuthenticationType"];
            AuthenticationProviderType result;
            if (string.IsNullOrEmpty(policyElement) || !System.Enum.TryParse<AuthenticationProviderType>(policyElement, out result))
                return;
            switch (result)
            {
                case AuthenticationProviderType.Federation:
                    this.IssuerEndpoints = ServiceMetadataUtility.RetrieveIssuerEndpoints(AuthenticationProviderType.Federation, this.ServiceEndpoints, true);
                    this.PolicyConfiguration = (PolicyConfiguration)new ClaimsPolicyConfiguration(xrmPolicy);
                    break;
                //case AuthenticationProviderType.OnlineFederation:
                //    this.PolicyConfiguration = (PolicyConfiguration)new OnlineFederationPolicyConfiguration(xrmPolicy);
                //    using (Dictionary<Uri, IdentityProviderTrustConfiguration>.ValueCollection.Enumerator enumerator = ((OnlinePolicyConfiguration)this.PolicyConfiguration).OnlineProviders.Values.GetEnumerator())
                //    {
                //        while (enumerator.MoveNext())
                //            this.IssuerEndpoints = ServiceMetadataUtility.RetrieveLiveIdIssuerEndpoints(enumerator.Current);
                //        break;
                //    }
                default:
                    this.PolicyConfiguration = (PolicyConfiguration)new WindowsPolicyConfiguration(xrmPolicy);
                    break;
            }
        }

        internal static ServiceUrls CalculateEndpoints(Uri serviceUri)
        {
            ServiceUrls endpoints = new ServiceUrls();
            UriBuilder uriBuilder = new UriBuilder(serviceUri);
            string[] strArray = uriBuilder.Host.Split('.');
            if (strArray[0].EndsWith("--s", StringComparison.OrdinalIgnoreCase))
            {
                endpoints.AlternateEndpoint = uriBuilder.Uri;
                strArray[0] = strArray[0].Remove(strArray[0].Length - 3);
                uriBuilder.Host = string.Join(".", strArray);
                endpoints.PrimaryEndpoint = uriBuilder.Uri;
                endpoints.GeneratedFromAlternate = true;
            }
            else
            {
                endpoints.PrimaryEndpoint = uriBuilder.Uri;
                // тут
                //// ISSUE: explicit reference operation
                //^ref strArray[0] += "--s";

                uriBuilder.Host = string.Join(".", strArray);
                endpoints.AlternateEndpoint = uriBuilder.Uri;
            }
            return endpoints;
        }

        #region interface

        public bool EndpointAutoSwitchEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Uri AlternateEndpoint => throw new NotImplementedException();
        //public Uri PrimaryEndpoint => throw new NotImplementedException();
        public Uri PrimaryEndpoint { get; internal set; }
        public bool IsPrimaryEndpoint => throw new NotImplementedException();
        public event EventHandler<EndpointSwitchEventArgs> EndpointSwitched;
        public event EventHandler<EndpointSwitchEventArgs> EndpointSwitchRequired;

        public bool CanSwitch(Uri currentUri)
        {
            throw new NotImplementedException();
        }

        public bool HandleEndpointSwitch()
        {
            throw new NotImplementedException();
        }

        public void SwitchEndpoint()
        {
            throw new NotImplementedException();
        }

        #endregion interface
    }
}