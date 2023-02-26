// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.OrganizationServiceConfiguration
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Net;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;

namespace Microsoft.Xrm.Sdk.Client
//namespace CrmConnector.Client
{
  internal sealed class OrganizationServiceConfiguration : 
    IServiceConfiguration<IOrganizationService>,
    IWebAuthentication<IOrganizationService>,
    IServiceManagement<IOrganizationService>,
    IEndpointSwitch
  {
    private const string XrmServicesRoot = "xrmservices/";
    private ServiceConfiguration<IOrganizationService> service;
    private object _lockObject = new object();

    private OrganizationServiceConfiguration()
    {
    }

    internal OrganizationServiceConfiguration(Uri serviceUri)
      : this(serviceUri, false, (Assembly) null)
    {
    }

    internal OrganizationServiceConfiguration(
      Uri serviceUri,
      bool enableProxyTypes,
      Assembly assembly)
    {
      try
      {
        this.service = new ServiceConfiguration<IOrganizationService>(serviceUri, false);
        if (enableProxyTypes && assembly != (Assembly) null)
        {
          this.EnableProxyTypes(assembly);
        }
        else
        {
          if (!enableProxyTypes)
            return;
          this.EnableProxyTypes();
        }
      }
      catch (InvalidOperationException ex)
      {
        bool flag = true;
        if (ex.InnerException is WebException innerException && innerException.Response is HttpWebResponse response && response.StatusCode == HttpStatusCode.Unauthorized)
          flag = !this.AdjustServiceEndpoint(serviceUri);
        if (!flag)
          return;
        throw;
      }
    }

    public void EnableProxyTypes()
    {
      ClientExceptionHelper.ThrowIfNull((object) this.CurrentServiceEndpoint, "CurrentServiceEndpoint");
      lock (this._lockObject)
      {
        ProxyTypesBehavior proxyTypesBehavior = this.CurrentServiceEndpoint.Behaviors.Find<ProxyTypesBehavior>();
        if (proxyTypesBehavior != null)
          this.CurrentServiceEndpoint.Behaviors.Remove((IEndpointBehavior) proxyTypesBehavior);
        this.CurrentServiceEndpoint.Behaviors.Add((IEndpointBehavior) new ProxyTypesBehavior());
      }
    }

    public void EnableProxyTypes(Assembly assembly)
    {
      ClientExceptionHelper.ThrowIfNull((object) assembly, nameof (assembly));
      ClientExceptionHelper.ThrowIfNull((object) this.CurrentServiceEndpoint, "CurrentServiceEndpoint");
      lock (this._lockObject)
      {
        ProxyTypesBehavior proxyTypesBehavior = this.CurrentServiceEndpoint.Behaviors.Find<ProxyTypesBehavior>();
        if (proxyTypesBehavior != null)
          this.CurrentServiceEndpoint.Behaviors.Remove((IEndpointBehavior) proxyTypesBehavior);
        this.CurrentServiceEndpoint.Behaviors.Add((IEndpointBehavior) new ProxyTypesBehavior(assembly));
      }
    }

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

    public ChannelFactory<IOrganizationService> CreateChannelFactory() => this.service.CreateChannelFactory(ClientAuthenticationType.Kerberos);

    public ChannelFactory<IOrganizationService> CreateChannelFactory(
      ClientAuthenticationType clientAuthenticationType)
    {
      return this.service.CreateChannelFactory(clientAuthenticationType);
    }

    public ChannelFactory<IOrganizationService> CreateChannelFactory(
      TokenServiceCredentialType endpointType)
    {
      return this.service.CreateChannelFactory(endpointType);
    }

    public ChannelFactory<IOrganizationService> CreateChannelFactory(
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

    private bool AdjustServiceEndpoint(Uri serviceUri)
    {
      Uri serviceUri1 = OrganizationServiceConfiguration.RemoveOrgName(serviceUri);
      if (serviceUri1 != (Uri) null)
      {
        this.service = new ServiceConfiguration<IOrganizationService>(serviceUri1);
        if (this.service != null && this.service.ServiceEndpoints != null)
        {
          foreach (KeyValuePair<string, ServiceEndpoint> serviceEndpoint in (Dictionary<string, ServiceEndpoint>) this.service.ServiceEndpoints)
            ServiceMetadataUtility.ReplaceEndpointAddress(serviceEndpoint.Value, serviceUri);
          return true;
        }
      }
      return false;
    }

    private static Uri RemoveOrgName(Uri serviceUri)
    {
      if (!serviceUri.AbsolutePath.StartsWith("/xrmservices/", StringComparison.OrdinalIgnoreCase))
      {
        StringBuilder stringBuilder = new StringBuilder();
        for (int index = 2; index < serviceUri.Segments.Length; ++index)
          stringBuilder.Append(serviceUri.Segments[index]);
        if (stringBuilder.Length > 0)
        {
          serviceUri = new UriBuilder(serviceUri.GetComponents(UriComponents.SchemeAndServer, UriFormat.UriEscaped))
          {
            Path = stringBuilder.ToString()
          }.Uri;
          return serviceUri;
        }
      }
      return (Uri) null;
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

    public bool HandleEndpointSwitch() => this.service.HandleEndpointSwitch();

    public bool IsPrimaryEndpoint => this.service.IsPrimaryEndpoint;

    public bool CanSwitch(Uri currentUri) => this.service.CanSwitch(currentUri);
  }
}
