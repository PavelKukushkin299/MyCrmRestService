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

namespace Microsoft.Xrm.Sdk.Client
//namespace CrmConnector.Client
{
  [SecuritySafeCritical]
  [SecurityPermission(SecurityAction.Demand, Unrestricted = true)]
  internal sealed class ServiceConfiguration<TService> : IEndpointSwitch
  {
    private ServiceEndpoint currentServiceEndpoint;
    private TokenServiceCredentialType _tokenEndpointType = TokenServiceCredentialType.AsymmetricToken;
    private static object _lockObject = new object();
    internal const string DefaultRequestType = "http://schemas.microsoft.com/idfx/requesttype/issue";

    public bool EndpointAutoSwitchEnabled { get; set; }

    public string GetAlternateEndpointAddress(string host)
    {
      int startIndex = host.IndexOf('.');
      return host.Insert(startIndex, "." + this.AlternateEndpointToken);
    }

    public void OnEndpointSwitchRequiredEvent() => this.HandleEndpointEvent(this.EndpointSwitchRequired, this.CurrentServiceEndpoint.Address.Uri == this.PrimaryEndpoint ? this.AlternateEndpoint : this.PrimaryEndpoint, this.CurrentServiceEndpoint.Address.Uri);

    public void OnEndpointSwitchedEvent() => this.HandleEndpointEvent(this.EndpointSwitched, this.CurrentServiceEndpoint.Address.Uri, this.CurrentServiceEndpoint.Address.Uri == this.PrimaryEndpoint ? this.AlternateEndpoint : this.PrimaryEndpoint);

    private void HandleEndpointEvent(
      EventHandler<EndpointSwitchEventArgs> tmp,
      Uri newUrl,
      Uri previousUrl)
    {
      if (tmp == null)
        return;
      EndpointSwitchEventArgs e = new EndpointSwitchEventArgs();
      lock (ServiceConfiguration<TService>._lockObject)
      {
        e.NewUrl = newUrl;
        e.PreviousUrl = previousUrl;
      }
      tmp((object) this, e);
    }

    public event EventHandler<EndpointSwitchEventArgs> EndpointSwitched;

    public event EventHandler<EndpointSwitchEventArgs> EndpointSwitchRequired;

    public string AlternateEndpointToken { get; set; }

    public Uri AlternateEndpoint { get; internal set; }

    public Uri PrimaryEndpoint { get; internal set; }

    private void SetEndpointSwitchingBehavior()
    {
      if (this.ServiceEndpointMetadata.ServiceUrls == null)
        return;
      this.PrimaryEndpoint = this.ServiceEndpointMetadata.ServiceUrls.PrimaryEndpoint;
      bool flag1 = false;
      bool flag2 = true;
      if (!this.ServiceEndpointMetadata.ServiceUrls.GeneratedFromAlternate)
      {
        FailoverPolicy failoverPolicy = this.CurrentServiceEndpoint.Binding.CreateBindingElements().Find<FailoverPolicy>();
        if (failoverPolicy != null && failoverPolicy.PolicyElements.ContainsKey("FailoverAvailable"))
        {
          flag1 = Convert.ToBoolean(failoverPolicy.PolicyElements["FailoverAvailable"], (IFormatProvider) CultureInfo.InvariantCulture);
          flag2 = Convert.ToBoolean(failoverPolicy.PolicyElements["EndpointEnabled"], (IFormatProvider) CultureInfo.InvariantCulture);
        }
      }
      else
        flag1 = true;
      if (!flag1)
        return;
      this.AlternateEndpoint = this.ServiceEndpointMetadata.ServiceUrls.AlternateEndpoint;
      if (flag2)
        return;
      this.SwitchEndpoint();
    }

    public bool IsPrimaryEndpoint
    {
      get
      {
        lock (ServiceConfiguration<TService>._lockObject)
          return this.AlternateEndpoint == (Uri) null || this.CurrentServiceEndpoint.Address.Uri != this.AlternateEndpoint;
      }
    }

    public bool CanSwitch(Uri currentUri)
    {
      ClientExceptionHelper.ThrowIfNull((object) currentUri, nameof (currentUri));
      lock (ServiceConfiguration<TService>._lockObject)
        return currentUri == this.CurrentServiceEndpoint.Address.Uri;
    }

    public bool HandleEndpointSwitch()
    {
      if (this.AlternateEndpoint != (Uri) null)
      {
        this.OnEndpointSwitchRequiredEvent();
        if (this.EndpointAutoSwitchEnabled)
        {
          this.SwitchEndpoint();
          return true;
        }
      }
      return false;
    }

    public void SwitchEndpoint()
    {
      if (this.AlternateEndpoint == (Uri) null)
        return;
      lock (ServiceConfiguration<TService>._lockObject)
      {
        this.CurrentServiceEndpoint.Address = !(this.CurrentServiceEndpoint.Address.Uri != this.AlternateEndpoint) ? new EndpointAddress(this.PrimaryEndpoint, this.CurrentServiceEndpoint.Address.Identity, this.CurrentServiceEndpoint.Address.Headers) : new EndpointAddress(this.AlternateEndpoint, this.CurrentServiceEndpoint.Address.Identity, this.CurrentServiceEndpoint.Address.Headers);
        this.OnEndpointSwitchedEvent();
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

    public PolicyConfiguration PolicyConfiguration { get; set; }

    public ServiceEndpointMetadata ServiceEndpointMetadata { get; private set; }

    private ServiceConfiguration()
    {
    }

    private bool ClaimsEnabledService => this.AuthenticationType == AuthenticationProviderType.Federation || this.AuthenticationType == AuthenticationProviderType.OnlineFederation;

    public ServiceConfiguration(Uri serviceUri)
      : this(serviceUri, false)
    {
    }

    internal ServiceConfiguration(Uri serviceUri, bool checkForSecondary)
    {
      this.ServiceUri = serviceUri;
      this.ServiceEndpointMetadata = ServiceMetadataUtility.RetrieveServiceEndpointMetadata(typeof (TService), this.ServiceUri, checkForSecondary);
      ClientExceptionHelper.ThrowIfNull((object) this.ServiceEndpointMetadata, nameof (ServiceEndpointMetadata));
      if (this.ServiceEndpointMetadata.ServiceEndpoints.Count == 0)
      {
        StringBuilder stringBuilder = new StringBuilder();
        if (this.ServiceEndpointMetadata.MetadataConversionErrors.Count > 0)
        {
          foreach (MetadataConversionError metadataConversionError in this.ServiceEndpointMetadata.MetadataConversionErrors)
            stringBuilder.Append(metadataConversionError.Message);
        }
        throw new InvalidOperationException(ClientExceptionHelper.FormatMessage(0, (object) "The provided uri did not return any Service Endpoints!\n{0}", (object) stringBuilder.ToString()));
      }
      this.ServiceEndpoints = this.ServiceEndpointMetadata.ServiceEndpoints;
      if (this.CurrentServiceEndpoint == null)
        return;
      this.CrossRealmIssuerEndpoints = new CrossRealmIssuerEndpointCollection();
      this.SetAuthenticationConfiguration();
      if (checkForSecondary)
      {
        this.SetEndpointSwitchingBehavior();
      }
      else
      {
        if (this.CurrentServiceEndpoint.Address.Uri != serviceUri)
          ServiceMetadataUtility.ReplaceEndpointAddress(this.CurrentServiceEndpoint, serviceUri);
        this.PrimaryEndpoint = serviceUri;
      }
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
          this.PolicyConfiguration = (PolicyConfiguration) new ClaimsPolicyConfiguration(xrmPolicy);
          break;
        case AuthenticationProviderType.OnlineFederation:
          this.PolicyConfiguration = (PolicyConfiguration) new OnlineFederationPolicyConfiguration(xrmPolicy);
          using (Dictionary<Uri, IdentityProviderTrustConfiguration>.ValueCollection.Enumerator enumerator = ((OnlinePolicyConfiguration) this.PolicyConfiguration).OnlineProviders.Values.GetEnumerator())
          {
            while (enumerator.MoveNext())
              this.IssuerEndpoints = ServiceMetadataUtility.RetrieveLiveIdIssuerEndpoints(enumerator.Current);
            break;
          }
        default:
          this.PolicyConfiguration = (PolicyConfiguration) new WindowsPolicyConfiguration(xrmPolicy);
          break;
      }
    }

    public Uri ServiceUri { get; internal set; }

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

    public IssuerEndpoint CurrentIssuer
    {
      get => this.CurrentServiceEndpoint != null ? ServiceMetadataUtility.GetIssuer(this.CurrentServiceEndpoint.Binding) : (IssuerEndpoint) null;
      set
      {
        if (this.CurrentServiceEndpoint == null)
          return;
        this.CurrentServiceEndpoint.Binding = (Binding) ServiceMetadataUtility.SetIssuer(this.CurrentServiceEndpoint.Binding, value);
      }
    }

    public AuthenticationProviderType AuthenticationType
    {
      get
      {
        if (this.PolicyConfiguration is WindowsPolicyConfiguration)
          return AuthenticationProviderType.ActiveDirectory;
        if (this.PolicyConfiguration is ClaimsPolicyConfiguration)
          return AuthenticationProviderType.Federation;
        if (this.PolicyConfiguration is LiveIdPolicyConfiguration)
          return AuthenticationProviderType.LiveId;
        return this.PolicyConfiguration is OnlineFederationPolicyConfiguration ? AuthenticationProviderType.OnlineFederation : AuthenticationProviderType.None;
      }
    }

    public ServiceEndpointDictionary ServiceEndpoints { get; internal set; }

    public IssuerEndpointDictionary IssuerEndpoints { get; internal set; }

    public CrossRealmIssuerEndpointCollection CrossRealmIssuerEndpoints { get; internal set; }

    public ChannelFactory<TService> CreateChannelFactory(
      TokenServiceCredentialType endpointType)
    {
      ClientExceptionHelper.ThrowIfNull((object) this.CurrentServiceEndpoint, "CurrentServiceEndpoint");
      if (this.ClaimsEnabledService)
      {
        IssuerEndpoint issuerEndpoint = this.IssuerEndpoints.GetIssuerEndpoint(endpointType);
        if (issuerEndpoint != null)
        {
          lock (ServiceConfiguration<TService>._lockObject)
            this.CurrentServiceEndpoint.Binding = (Binding) ServiceMetadataUtility.SetIssuer(this.CurrentServiceEndpoint.Binding, issuerEndpoint);
        }
      }
      ChannelFactory<TService> localChannelFactory = this.CreateLocalChannelFactory();
      localChannelFactory.Credentials.SupportInteractive = false;
      return localChannelFactory;
    }

    public ChannelFactory<TService> CreateChannelFactory(
      ClientAuthenticationType clientAuthenticationType)
    {
      ClientExceptionHelper.ThrowIfNull((object) this.CurrentServiceEndpoint, "CurrentServiceEndpoint");
      if (this.ClaimsEnabledService)
      {
        IssuerEndpoint issuerEndpoint = this.IssuerEndpoints.GetIssuerEndpoint(clientAuthenticationType != ClientAuthenticationType.SecurityToken ? TokenServiceCredentialType.Kerberos : (this.AuthenticationType == AuthenticationProviderType.OnlineFederation ? TokenServiceCredentialType.SymmetricToken : this._tokenEndpointType));
        if (issuerEndpoint != null)
        {
          lock (ServiceConfiguration<TService>._lockObject)
            this.CurrentServiceEndpoint.Binding = (Binding) ServiceMetadataUtility.SetIssuer(this.CurrentServiceEndpoint.Binding, issuerEndpoint);
        }
      }
      ChannelFactory<TService> localChannelFactory = this.CreateLocalChannelFactory();
      localChannelFactory.Credentials.SupportInteractive = false;
      return localChannelFactory;
    }

    public ChannelFactory<TService> CreateChannelFactory(
      ClientCredentials clientCredentials)
    {
      ClientExceptionHelper.ThrowIfNull((object) this.CurrentServiceEndpoint, "CurrentServiceEndpoint");
      if (this.ClaimsEnabledService)
      {
        IssuerEndpoint issuerEndpoint = this.IssuerEndpoints.GetIssuerEndpoint(this.GetCredentialsEndpointType(clientCredentials));
        if (issuerEndpoint != null)
        {
          lock (ServiceConfiguration<TService>._lockObject)
            this.CurrentServiceEndpoint.Binding = (Binding) ServiceMetadataUtility.SetIssuer(this.CurrentServiceEndpoint.Binding, issuerEndpoint);
        }
      }
      ChannelFactory<TService> localChannelFactory = this.CreateLocalChannelFactory();
      this.ConfigureCredentials((ChannelFactory) localChannelFactory, clientCredentials);
      localChannelFactory.Credentials.SupportInteractive = clientCredentials != null && clientCredentials.SupportInteractive;
      return localChannelFactory;
    }

    public SecurityTokenResponse AuthenticateCrossRealm(
      ClientCredentials clientCredentials,
      string appliesTo,
      Uri crossRealmSts)
    {
      if (!(crossRealmSts != (Uri) null))
        return (SecurityTokenResponse) null;
      AuthenticationCredentials authenticationCredentials = new AuthenticationCredentials();
      authenticationCredentials.AppliesTo = !string.IsNullOrWhiteSpace(appliesTo) ? new Uri(appliesTo) : (Uri) null;
      authenticationCredentials.KeyType = string.Empty;
      authenticationCredentials.ClientCredentials = clientCredentials;
      authenticationCredentials.SecurityTokenResponse = (SecurityTokenResponse) null;
      IdentityProviderTrustConfiguration trustConfiguration = this.TryGetOnlineTrustConfiguration(crossRealmSts);
      authenticationCredentials.EndpointType = trustConfiguration != null ? TokenServiceCredentialType.Username : this.GetCredentialsEndpointType(clientCredentials);
      authenticationCredentials.IssuerEndpoints = this.CrossRealmIssuerEndpoints[crossRealmSts];
      if (this.AuthenticationType == AuthenticationProviderType.OnlineFederation && trustConfiguration == null)
        authenticationCredentials.KeyType = "http://schemas.microsoft.com/idfx/keytype/bearer";
      return this.AuthenticateInternal(authenticationCredentials);
    }

    public SecurityTokenResponse AuthenticateCrossRealm(
      SecurityToken securityToken,
      string appliesTo,
      Uri crossRealmSts)
    {
      if (!(crossRealmSts != (Uri) null))
        return (SecurityTokenResponse) null;
      AuthenticationCredentials authenticationCredentials = new AuthenticationCredentials();
      authenticationCredentials.AppliesTo = !string.IsNullOrWhiteSpace(appliesTo) ? new Uri(appliesTo) : (Uri) null;
      authenticationCredentials.KeyType = string.Empty;
      authenticationCredentials.ClientCredentials = (ClientCredentials) null;
      authenticationCredentials.SecurityTokenResponse = new SecurityTokenResponse()
      {
        Token = securityToken
      };
      bool flag = true;
      if (this.AuthenticationType == AuthenticationProviderType.OnlineFederation)
      {
        IdentityProviderTrustConfiguration trustConfiguration = this.TryGetOnlineTrustConfiguration(crossRealmSts);
        if (trustConfiguration != null && trustConfiguration.Endpoint.GetServiceRoot() == crossRealmSts)
        {
          authenticationCredentials.EndpointType = TokenServiceCredentialType.SymmetricToken;
          flag = false;
        }
      }
      if (flag)
        authenticationCredentials.EndpointType = this._tokenEndpointType;
      authenticationCredentials.IssuerEndpoints = this.CrossRealmIssuerEndpoints[crossRealmSts];
      return this.AuthenticateInternal(authenticationCredentials);
    }

    private IdentityProviderTrustConfiguration TryGetOnlineTrustConfiguration() => !(this.PolicyConfiguration is OnlinePolicyConfiguration policyConfiguration) ? (IdentityProviderTrustConfiguration) null : (IdentityProviderTrustConfiguration) policyConfiguration.OnlineProviders.Values.OfType<OrgIdentityProviderTrustConfiguration>().FirstOrDefault<OrgIdentityProviderTrustConfiguration>();

    private IdentityProviderTrustConfiguration GetLiveTrustConfig<T>() where T : IdentityProviderTrustConfiguration
    {
      OnlinePolicyConfiguration policyConfiguration = this.PolicyConfiguration as OnlinePolicyConfiguration;
      ClientExceptionHelper.ThrowIfNull((object) policyConfiguration, "liveConfiguration");
            // тут
            //// ISSUE: variable of a boxed type
            //__Boxed<T> parameter = (object) policyConfiguration.OnlineProviders.Values.OfType<T>().FirstOrDefault<T>();
            var parameter = (object)policyConfiguration.OnlineProviders.Values.OfType<T>().FirstOrDefault<T>();
            ClientExceptionHelper.ThrowIfNull((object) parameter, "liveTrustConfig");
      return (IdentityProviderTrustConfiguration) parameter;
    }

    private IdentityProviderTrustConfiguration GetOnlineTrustConfiguration(
      Uri crossRealmSts)
    {
      OnlineFederationPolicyConfiguration policyConfiguration = this.PolicyConfiguration as OnlineFederationPolicyConfiguration;
      ClientExceptionHelper.ThrowIfNull((object) policyConfiguration, "liveFederationConfiguration");
      return policyConfiguration.OnlineProviders.ContainsKey(crossRealmSts) ? policyConfiguration.OnlineProviders[crossRealmSts] : (IdentityProviderTrustConfiguration) null;
    }

    private IdentityProviderTrustConfiguration TryGetOnlineTrustConfiguration(
      Uri crossRealmSts)
    {
      return this.PolicyConfiguration is OnlineFederationPolicyConfiguration policyConfiguration && policyConfiguration.OnlineProviders.ContainsKey(crossRealmSts) ? policyConfiguration.OnlineProviders[crossRealmSts] : (IdentityProviderTrustConfiguration) null;
    }

    public SecurityTokenResponse Authenticate(
      ClientCredentials clientCredentials)
    {
      if (this.CurrentServiceEndpoint != null)
      {
        AuthenticationCredentials authenticationCredentials = this.Authenticate(new AuthenticationCredentials()
        {
          ClientCredentials = clientCredentials
        });
        if (authenticationCredentials != null && authenticationCredentials.SecurityTokenResponse != null)
          return authenticationCredentials.SecurityTokenResponse;
      }
      return (SecurityTokenResponse) null;
    }

    internal SecurityTokenResponse Authenticate(
      ClientCredentials clientCredentials,
      Uri uri,
      string keyType)
    {
      return this.AuthenticateInternal(new AuthenticationCredentials()
      {
        AppliesTo = uri,
        EndpointType = this.GetCredentialsEndpointType(clientCredentials),
        KeyType = keyType,
        IssuerEndpoints = this.IssuerEndpoints,
        ClientCredentials = clientCredentials,
        SecurityTokenResponse = (SecurityTokenResponse) null
      });
    }

    public SecurityTokenResponse Authenticate(SecurityToken securityToken)
    {
      ClientExceptionHelper.ThrowIfNull((object) securityToken, nameof (securityToken));
      if (this.AuthenticationType == AuthenticationProviderType.OnlineFederation)
      {
        IdentityProviderTrustConfiguration trustConfiguration = this.TryGetOnlineTrustConfiguration();
        return trustConfiguration == null ? (SecurityTokenResponse) null : this.AuthenticateCrossRealm(securityToken, trustConfiguration.AppliesTo, trustConfiguration.Endpoint.GetServiceRoot());
      }
      if (this.CurrentServiceEndpoint == null)
        return (SecurityTokenResponse) null;
      return this.AuthenticateInternal(new AuthenticationCredentials()
      {
        AppliesTo = this.CurrentServiceEndpoint.Address.Uri,
        EndpointType = this._tokenEndpointType,
        KeyType = string.Empty,
        IssuerEndpoints = this.IssuerEndpoints,
        ClientCredentials = (ClientCredentials) null,
        SecurityTokenResponse = new SecurityTokenResponse()
        {
          Token = securityToken
        }
      });
    }

    internal SecurityTokenResponse Authenticate(
      SecurityToken securityToken,
      Uri uri,
      string keyType)
    {
      ClientExceptionHelper.ThrowIfNull((object) securityToken, nameof (securityToken));
      if (!(uri != (Uri) null))
        return (SecurityTokenResponse) null;
      return this.AuthenticateInternal(new AuthenticationCredentials()
      {
        AppliesTo = uri.GetServiceRoot(),
        EndpointType = this._tokenEndpointType,
        KeyType = keyType,
        IssuerEndpoints = this.IssuerEndpoints,
        ClientCredentials = (ClientCredentials) null,
        SecurityTokenResponse = new SecurityTokenResponse()
        {
          Token = securityToken
        }
      });
    }

    public SecurityTokenResponse AuthenticateDevice(
      ClientCredentials clientCredentials)
    {
      ClientExceptionHelper.ThrowIfNull((object) clientCredentials, nameof (clientCredentials));
      throw new InvalidOperationException("Authentication to MSA services is not supported.");
    }

    public SecurityTokenResponse Authenticate(
      ClientCredentials clientCredentials,
      SecurityTokenResponse deviceTokenResponse)
    {
      ClientExceptionHelper.ThrowIfNull((object) clientCredentials, nameof (clientCredentials));
      ClientExceptionHelper.ThrowIfNull((object) deviceTokenResponse, nameof (deviceTokenResponse));
      throw new InvalidOperationException("Authentication to MSA services is not supported.");
    }

    public SecurityTokenResponse Authenticate(
      ClientCredentials clientCredentials,
      SecurityTokenResponse deviceTokenResponse,
      string keyType)
    {
      ClientExceptionHelper.ThrowIfNull((object) clientCredentials, nameof (clientCredentials));
      ClientExceptionHelper.ThrowIfNull((object) deviceTokenResponse, nameof (deviceTokenResponse));
      ClientExceptionHelper.ThrowIfNullOrEmpty(keyType, nameof (keyType));
      throw new InvalidOperationException("Authentication to MSA services is not supported.");
    }

    public IdentityProvider GetIdentityProvider(string userPrincipalName)
    {
      IdentityProviderTrustConfiguration trustConfiguration = this.TryGetOnlineTrustConfiguration();
      return trustConfiguration == null ? (IdentityProvider) null : IdentityProviderLookup.Instance.GetIdentityProvider(trustConfiguration.Endpoint.GetServiceRoot(), trustConfiguration.Endpoint.GetServiceRoot(), userPrincipalName);
    }

    private SecurityTokenResponse AuthenticateInternal(
      AuthenticationCredentials authenticationCredentials)
    {
      ClientExceptionHelper.Assert(this.AuthenticationType == AuthenticationProviderType.Federation || this.AuthenticationType == AuthenticationProviderType.OnlineFederation, "Authenticate is not supported when not in claims mode!");
      if (this.ClaimsEnabledService)
      {
        if (authenticationCredentials.IssuerEndpoint.CredentialType != TokenServiceCredentialType.Kerberos)
          return this.Issue(authenticationCredentials);
        bool flag = false;
        int num = 0;
        do
        {
          try
          {
            return this.Issue(authenticationCredentials);
          }
          catch (SecurityTokenValidationException ex)
          {
            flag = false;
            if (authenticationCredentials.IssuerEndpoints.ContainsKey(TokenServiceCredentialType.Windows.ToString()))
            {
              authenticationCredentials.EndpointType = TokenServiceCredentialType.Windows;
              flag = ++num < 2;
            }
          }
          catch (SecurityNegotiationException ex)
          {
            flag = ++num < 2;
          }
          catch (FaultException ex)
          {
            if (authenticationCredentials.IssuerEndpoints.ContainsKey(TokenServiceCredentialType.Windows.ToString()))
            {
              authenticationCredentials.EndpointType = TokenServiceCredentialType.Windows;
              flag = ++num < 2;
            }
          }
        }
        while (flag);
      }
      return (SecurityTokenResponse) null;
    }

    private SecurityTokenResponse Issue(
      AuthenticationCredentials authenticationCredentials)
    {
      ClientExceptionHelper.ThrowIfNull((object) authenticationCredentials, nameof (authenticationCredentials));
      ClientExceptionHelper.ThrowIfNull((object) authenticationCredentials.IssuerEndpoint, "authenticationCredentials.IssuerEndpoint");
      ClientExceptionHelper.ThrowIfNull((object) authenticationCredentials.AppliesTo, "authenticationCredentials.AppliesTo");
      WSTrustChannelFactory communicationObject1 = (WSTrustChannelFactory) null;
      WSTrustChannel communicationObject2 = (WSTrustChannel) null;
      try
      {
        authenticationCredentials.RequestType = "http://schemas.microsoft.com/idfx/requesttype/issue";
        communicationObject1 = new WSTrustChannelFactory(authenticationCredentials.IssuerEndpoint.IssuerBinding, authenticationCredentials.IssuerEndpoint.IssuerAddress);
        SecurityToken issuedToken = authenticationCredentials.SecurityTokenResponse == null || authenticationCredentials.SecurityTokenResponse.Token == null ? (authenticationCredentials.SupportingCredentials == null || authenticationCredentials.SupportingCredentials.SecurityTokenResponse == null || authenticationCredentials.SupportingCredentials.SecurityTokenResponse.Token == null ? (SecurityToken) null : authenticationCredentials.SupportingCredentials.SecurityTokenResponse.Token) : authenticationCredentials.SecurityTokenResponse.Token;
        if (issuedToken != null)
          communicationObject1.Credentials.SupportInteractive = false;
        else
          this.ConfigureCredentials((ChannelFactory) communicationObject1, authenticationCredentials.ClientCredentials);
        communicationObject2 = issuedToken != null ? (WSTrustChannel) communicationObject1.CreateChannelWithIssuedToken(issuedToken) : (WSTrustChannel) communicationObject1.CreateChannel();
        if (communicationObject2 != null)
        {
          System.IdentityModel.Protocols.WSTrust.RequestSecurityToken requestSecurityToken = new System.IdentityModel.Protocols.WSTrust.RequestSecurityToken(authenticationCredentials.RequestType);
          requestSecurityToken.AppliesTo = new EndpointReference(authenticationCredentials.AppliesTo.AbsoluteUri);
          System.IdentityModel.Protocols.WSTrust.RequestSecurityToken rst = requestSecurityToken;
          if (!string.IsNullOrEmpty(authenticationCredentials.KeyType))
            rst.KeyType = authenticationCredentials.KeyType;
          System.IdentityModel.Protocols.WSTrust.RequestSecurityTokenResponse rstr;
          SecurityToken securityToken = communicationObject2.Issue(rst, out rstr);
          return new SecurityTokenResponse()
          {
            Token = securityToken,
            Response = rstr,
            EndpointType = authenticationCredentials.EndpointType
          };
        }
      }
      finally
      {
        if (communicationObject2 != null)
          ChannelExtensions.Close(communicationObject2);
        if (communicationObject1 != null)
          ChannelExtensions.Close(communicationObject1);
      }
      return (SecurityTokenResponse) null;
    }

    private void ConfigureCredentials(
      ChannelFactory channelFactory,
      ClientCredentials clientCredentials)
    {
      if (clientCredentials == null)
        return;
      if (clientCredentials.ClientCertificate != null && clientCredentials.ClientCertificate.Certificate != null)
        channelFactory.Credentials.ClientCertificate.Certificate = clientCredentials.ClientCertificate.Certificate;
      else if (clientCredentials.UserName != null && !string.IsNullOrEmpty(clientCredentials.UserName.UserName))
      {
        channelFactory.Credentials.UserName.UserName = clientCredentials.UserName.UserName;
        channelFactory.Credentials.UserName.Password = clientCredentials.UserName.Password;
      }
      else
      {
        if (clientCredentials.Windows == null || clientCredentials.Windows.ClientCredential == null)
          return;
        channelFactory.Credentials.Windows.ClientCredential = clientCredentials.Windows.ClientCredential;
        channelFactory.Credentials.Windows.AllowedImpersonationLevel = clientCredentials.Windows.AllowedImpersonationLevel;
      }
    }

    private TokenServiceCredentialType GetCredentialsEndpointType(
      ClientCredentials clientCredentials)
    {
      if (clientCredentials != null)
      {
        if (clientCredentials.UserName != null && !string.IsNullOrEmpty(clientCredentials.UserName.UserName))
          return TokenServiceCredentialType.Username;
        if (clientCredentials.ClientCertificate != null && clientCredentials.ClientCertificate.Certificate != null)
          return TokenServiceCredentialType.Certificate;
        if (clientCredentials.Windows != null)
        {
          NetworkCredential clientCredential = clientCredentials.Windows.ClientCredential;
          return TokenServiceCredentialType.Kerberos;
        }
      }
      return TokenServiceCredentialType.Kerberos;
    }

    private ChannelFactory<TService> CreateLocalChannelFactory()
    {
      lock (ServiceConfiguration<TService>._lockObject)
      {
        ServiceEndpoint endpoint = new ServiceEndpoint(this.CurrentServiceEndpoint.Contract, this.CurrentServiceEndpoint.Binding, this.CurrentServiceEndpoint.Address);
        foreach (IEndpointBehavior behavior in (Collection<IEndpointBehavior>) this.CurrentServiceEndpoint.Behaviors)
          endpoint.Behaviors.Add(behavior);
        endpoint.IsSystemEndpoint = this.CurrentServiceEndpoint.IsSystemEndpoint;
        endpoint.ListenUri = this.CurrentServiceEndpoint.ListenUri;
        endpoint.ListenUriMode = this.CurrentServiceEndpoint.ListenUriMode;
        endpoint.Name = this.CurrentServiceEndpoint.Name;
        ChannelFactory<TService> localChannelFactory = new ChannelFactory<TService>(endpoint);
        localChannelFactory.Credentials.IssuedToken.CacheIssuedTokens = true;
        return localChannelFactory;
      }
    }

    public AuthenticationCredentials Authenticate(
      AuthenticationCredentials authenticationCredentials)
    {
      ClientExceptionHelper.ThrowIfNull((object) authenticationCredentials, nameof (authenticationCredentials));
      switch (this.AuthenticationType)
      {
        case AuthenticationProviderType.ActiveDirectory:
          ServiceMetadataUtility.AdjustUserNameForWindows(authenticationCredentials.ClientCredentials);
          return authenticationCredentials;
        case AuthenticationProviderType.Federation:
          return this.AuthenticateFederationInternal(authenticationCredentials);
        case AuthenticationProviderType.OnlineFederation:
          return this.AuthenticateOnlineFederationInternal(authenticationCredentials);
        default:
          return authenticationCredentials;
      }
    }

    private AuthenticationCredentials AuthenticateFederationInternal(
      AuthenticationCredentials authenticationCredentials)
    {
      if (authenticationCredentials.SecurityTokenResponse != null)
        return this.AuthenticateFederationTokenInternal(authenticationCredentials);
      if (authenticationCredentials.AppliesTo == (Uri) null)
        authenticationCredentials.AppliesTo = this.CurrentServiceEndpoint.Address.Uri;
      authenticationCredentials.EndpointType = this.GetCredentialsEndpointType(authenticationCredentials.ClientCredentials);
      authenticationCredentials.IssuerEndpoints = authenticationCredentials.HomeRealm != (Uri) null ? this.CrossRealmIssuerEndpoints[authenticationCredentials.HomeRealm] : this.IssuerEndpoints;
      authenticationCredentials.SecurityTokenResponse = this.AuthenticateInternal(authenticationCredentials);
      return authenticationCredentials;
    }

    private AuthenticationCredentials AuthenticateFederationTokenInternal(
      AuthenticationCredentials authenticationCredentials)
    {
      AuthenticationCredentials authenticationCredentials1 = new AuthenticationCredentials();
      authenticationCredentials1.SupportingCredentials = authenticationCredentials;
      if (authenticationCredentials.AppliesTo == (Uri) null)
        authenticationCredentials.AppliesTo = this.CurrentServiceEndpoint.Address.Uri;
      authenticationCredentials.EndpointType = this._tokenEndpointType;
      authenticationCredentials.KeyType = string.Empty;
      authenticationCredentials.IssuerEndpoints = this.IssuerEndpoints;
      authenticationCredentials1.SecurityTokenResponse = this.AuthenticateInternal(authenticationCredentials);
      return authenticationCredentials1;
    }

    private AuthenticationCredentials AuthenticateOnlineFederationInternal(
      AuthenticationCredentials authenticationCredentials)
    {
      OnlinePolicyConfiguration policyConfiguration = this.PolicyConfiguration as OnlinePolicyConfiguration;
      ClientExceptionHelper.ThrowIfNull((object) policyConfiguration, "onlinePolicy");
      OrgIdentityProviderTrustConfiguration trustConfiguration = policyConfiguration.OnlineProviders.Values.OfType<OrgIdentityProviderTrustConfiguration>().FirstOrDefault<OrgIdentityProviderTrustConfiguration>();
      ClientExceptionHelper.ThrowIfNull((object) trustConfiguration, "liveTrustConfig");
      if (authenticationCredentials.SecurityTokenResponse != null)
        return this.AuthenticateOnlineFederationTokenInternal((IdentityProviderTrustConfiguration) trustConfiguration, authenticationCredentials);
      bool flag = true;
      if (authenticationCredentials.HomeRealm == (Uri) null)
      {
        IdentityProvider parameter = !string.IsNullOrEmpty(authenticationCredentials.UserPrincipalName) ? this.GetIdentityProvider(authenticationCredentials.UserPrincipalName) : this.GetIdentityProvider(authenticationCredentials.ClientCredentials);
        ClientExceptionHelper.ThrowIfNull((object) parameter, "identityProvider");
        authenticationCredentials.HomeRealm = parameter.ServiceUrl;
        flag = parameter.IdentityProviderType == IdentityProviderType.OrgId;
        if (flag)
          ClientExceptionHelper.Assert((policyConfiguration.OnlineProviders.ContainsKey(authenticationCredentials.HomeRealm) ? 1 : 0) != 0, "Online Identity Provider NOT found!  {0}", (object) parameter.ServiceUrl);
      }
      authenticationCredentials.AppliesTo = new Uri(trustConfiguration.AppliesTo);
      authenticationCredentials.IssuerEndpoints = this.IssuerEndpoints;
      authenticationCredentials.KeyType = "http://schemas.microsoft.com/idfx/keytype/bearer";
      authenticationCredentials.EndpointType = TokenServiceCredentialType.Username;
      return flag ? this.AuthenticateTokenWithOrgIdForCrm(authenticationCredentials) : this.AuthenticateFederatedTokenWithOrgIdForCRM(this.AuthenticateWithADFSForOrgId(authenticationCredentials, trustConfiguration.Identifier));
    }

    private AuthenticationCredentials AuthenticateFederatedTokenWithOrgIdForCRM(
      AuthenticationCredentials authenticationCredentials)
    {
      ClientExceptionHelper.ThrowIfNull((object) authenticationCredentials, nameof (authenticationCredentials));
      ClientExceptionHelper.ThrowIfNull((object) authenticationCredentials.SecurityTokenResponse, "authenticationCredentials.SecurityTokenResponse");
      AuthenticationCredentials authenticationCredentials1 = new AuthenticationCredentials()
      {
        SupportingCredentials = authenticationCredentials,
        AppliesTo = authenticationCredentials.AppliesTo,
        IssuerEndpoints = authenticationCredentials.IssuerEndpoints,
        EndpointType = TokenServiceCredentialType.SymmetricToken
      };
      authenticationCredentials1.SecurityTokenResponse = this.AuthenticateInternal(authenticationCredentials1);
      return authenticationCredentials1;
    }

    private AuthenticationCredentials AuthenticateWithADFSForOrgId(
      AuthenticationCredentials authenticationCredentials,
      Uri identifier)
    {
      AuthenticationCredentials authenticationCredentials1 = new AuthenticationCredentials()
      {
        AppliesTo = authenticationCredentials.AppliesTo,
        SupportingCredentials = authenticationCredentials
      };
      authenticationCredentials1.AppliesTo = authenticationCredentials.AppliesTo;
      authenticationCredentials1.IssuerEndpoints = authenticationCredentials.IssuerEndpoints;
      authenticationCredentials1.EndpointType = TokenServiceCredentialType.SymmetricToken;
      authenticationCredentials.AppliesTo = identifier;
      authenticationCredentials.KeyType = "http://schemas.microsoft.com/idfx/keytype/bearer";
      authenticationCredentials.EndpointType = this.GetCredentialsEndpointType(authenticationCredentials.ClientCredentials);
      authenticationCredentials.IssuerEndpoints = this.CrossRealmIssuerEndpoints[authenticationCredentials.HomeRealm];
      authenticationCredentials1.SecurityTokenResponse = this.AuthenticateInternal(authenticationCredentials);
      return authenticationCredentials1;
    }

    private AuthenticationCredentials AuthenticateTokenWithOrgIdForCrm(
      AuthenticationCredentials authenticationCredentials)
    {
      ClientExceptionHelper.ThrowIfNull((object) authenticationCredentials, nameof (authenticationCredentials));
      return new AuthenticationCredentials()
      {
        SupportingCredentials = authenticationCredentials,
        AppliesTo = authenticationCredentials.AppliesTo,
        IssuerEndpoints = authenticationCredentials.IssuerEndpoints,
        KeyType = "http://schemas.microsoft.com/idfx/keytype/bearer",
        EndpointType = TokenServiceCredentialType.Username,
        SecurityTokenResponse = this.AuthenticateInternal(authenticationCredentials)
      };
    }

    private AuthenticationCredentials AuthenticateOnlineFederationTokenInternal(
      IdentityProviderTrustConfiguration liveTrustConfig,
      AuthenticationCredentials authenticationCredentials)
    {
      AuthenticationCredentials authenticationCredentials1 = new AuthenticationCredentials();
      authenticationCredentials1.SupportingCredentials = authenticationCredentials;
      string appliesTo = authenticationCredentials.AppliesTo != (Uri) null ? authenticationCredentials.AppliesTo.AbsoluteUri : liveTrustConfig.AppliesTo;
      Uri uri = authenticationCredentials.HomeRealm;
      if ((object) uri == null)
        uri = liveTrustConfig.Endpoint.GetServiceRoot();
      Uri crossRealmSts = uri;
      authenticationCredentials1.SecurityTokenResponse = this.AuthenticateCrossRealm(authenticationCredentials.SecurityTokenResponse.Token, appliesTo, crossRealmSts);
      return authenticationCredentials1;
    }

    internal IdentityProvider GetIdentityProvider(
      ClientCredentials clientCredentials)
    {
      string userPrincipalName = string.Empty;
      if (!string.IsNullOrWhiteSpace(clientCredentials.UserName.UserName))
        userPrincipalName = this.ExtractUserName(clientCredentials.UserName.UserName);
      else if (!string.IsNullOrWhiteSpace(clientCredentials.Windows.ClientCredential.UserName))
        userPrincipalName = this.ExtractUserName(clientCredentials.Windows.ClientCredential.UserName);
      ClientExceptionHelper.Assert(!string.IsNullOrEmpty(userPrincipalName), "clientCredentials.UserName.UserName or clientCredentials.Windows.ClientCredential.UserName MUST be populated!");
      return this.GetIdentityProvider(userPrincipalName);
    }

    private string ExtractUserName(string userName) => !userName.Contains<char>('@') ? string.Empty : userName;
  }
}
