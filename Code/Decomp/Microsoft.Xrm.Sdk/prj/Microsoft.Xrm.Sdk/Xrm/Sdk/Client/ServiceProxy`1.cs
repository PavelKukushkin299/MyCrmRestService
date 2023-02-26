// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.ServiceProxy`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;

namespace Microsoft.Xrm.Sdk.Client
{
  public abstract class ServiceProxy<TService> : IDisposable where TService : class
  {
    private Microsoft.Xrm.Sdk.Client.ServiceChannel<TService> _serviceChannel;
    private System.ServiceModel.ChannelFactory<TService> _channelFactory;
    private TimeSpan _timeout = ServiceDefaults.DefaultTimeout;
    private bool _autoCloseChannel;

    internal ServiceProxy()
    {
    }

    protected ServiceProxy(
      IServiceManagement<TService> serviceManagement,
      SecurityTokenResponse securityTokenResponse)
      : this(serviceManagement as IServiceConfiguration<TService>, securityTokenResponse)
    {
    }

    protected ServiceProxy(
      IServiceConfiguration<TService> serviceConfiguration,
      SecurityTokenResponse securityTokenResponse)
    {
      ClientExceptionHelper.ThrowIfNull((object) serviceConfiguration, nameof (serviceConfiguration));
      ClientExceptionHelper.ThrowIfNull((object) serviceConfiguration.CurrentServiceEndpoint, "serviceConfiguration.CurrentServiceEndpoint");
      ClientExceptionHelper.ThrowIfNull((object) securityTokenResponse, nameof (securityTokenResponse));
      ClientExceptionHelper.ThrowIfNull((object) securityTokenResponse.Token, "securityTokenResponse.Token");
      this.ServiceConfiguration = serviceConfiguration;
      this.SecurityTokenResponse = securityTokenResponse;
      this.IsAuthenticated = true;
      this.SetDefaultEndpointSwitchBehavior();
    }

    protected ServiceProxy(
      IServiceManagement<TService> serviceManagement,
      ClientCredentials clientCredentials)
      : this(serviceManagement as IServiceConfiguration<TService>, clientCredentials)
    {
    }

    protected ServiceProxy(
      IServiceConfiguration<TService> serviceConfiguration,
      ClientCredentials clientCredentials)
    {
      ClientExceptionHelper.ThrowIfNull((object) serviceConfiguration, nameof (serviceConfiguration));
      ClientExceptionHelper.ThrowIfNull((object) serviceConfiguration.CurrentServiceEndpoint, "serviceConfiguration.CurrentServiceEndpoint");
      this.ServiceConfiguration = serviceConfiguration;
      this.SetClientCredentials(clientCredentials);
      this.IsAuthenticated = true;
      this.SetDefaultEndpointSwitchBehavior();
    }

    protected ServiceProxy(
      Uri uri,
      Uri homeRealmUri,
      ClientCredentials clientCredentials,
      ClientCredentials deviceCredentials)
    {
      ClientExceptionHelper.ThrowIfNull((object) uri, nameof (uri));
      this.IsAuthenticated = false;
      this.ServiceConfiguration = ServiceConfigurationFactory.CreateConfiguration<TService>(uri);
      this.SetClientCredentials(clientCredentials);
      this.HomeRealmUri = homeRealmUri;
      this.DeviceCredentials = deviceCredentials;
      this.SetDefaultEndpointSwitchBehavior();
    }

    public void Authenticate()
    {
      if (this._serviceChannel != null)
      {
        this._serviceChannel.Close();
        this._serviceChannel.Dispose();
        this._serviceChannel = (Microsoft.Xrm.Sdk.Client.ServiceChannel<TService>) null;
      }
      if (this._channelFactory != null)
      {
        this.RemoveChannelFactoryEvents();
        ChannelExtensions.Close(this._channelFactory);
        this._channelFactory = (System.ServiceModel.ChannelFactory<TService>) null;
      }
      this.AuthenticateCore();
    }

    public SecurityTokenResponse AuthenticateCrossRealm() => this.AuthenticateCrossRealmCore();

    public SecurityTokenResponse AuthenticateDevice() => this.AuthenticateDeviceCore();

    public IServiceConfiguration<TService> ServiceConfiguration { get; private set; }

    public IServiceManagement<TService> ServiceManagement => this.ServiceConfiguration as IServiceManagement<TService>;

    public IEndpointSwitch EndpointSwitch => this.ServiceConfiguration as IEndpointSwitch;

    public ClientCredentials ClientCredentials { get; private set; }

    public string UserPrincipalName { get; set; }

    public SecurityTokenResponse SecurityTokenResponse { get; protected set; }

    public SecurityTokenResponse HomeRealmSecurityTokenResponse { get; protected set; }

    public Uri HomeRealmUri { get; private set; }

    public ClientCredentials DeviceCredentials { get; private set; }

    public Microsoft.Xrm.Sdk.Client.ServiceChannel<TService> ServiceChannel
    {
      get
      {
        this.ValidateAuthentication();
        return this._serviceChannel;
      }
    }

    public TimeSpan Timeout
    {
      get => this._timeout;
      set
      {
        this._timeout = value;
        this.RefreshChannelManagers();
      }
    }

    public bool IsAuthenticated { get; private set; }

    internal bool AutoCloseChannel
    {
      get => this._autoCloseChannel;
      set => this._autoCloseChannel = value;
    }

    internal string AppliesTo { get; set; }

    protected virtual SecurityTokenResponse AuthenticateCrossRealmCore()
    {
      ClientExceptionHelper.ThrowIfNull((object) this.ServiceConfiguration, "ServiceConfiguration");
      ClientExceptionHelper.ThrowIfNull((object) this.HomeRealmUri, "HomeRealmUri");
      if (this.AppliesTo == null)
      {
        ClientExceptionHelper.ThrowIfNull((object) this.ServiceConfiguration.PolicyConfiguration, "ServiceConfiguration.PolicyConfiguration");
        ClientExceptionHelper.ThrowIfNullOrEmpty(this.ServiceConfiguration.PolicyConfiguration.SecureTokenServiceIdentifier, "ServiceConfiguration.PolicyConfiguration.SecureTokenServiceIdentifier");
        this.AppliesTo = this.ServiceConfiguration.PolicyConfiguration.SecureTokenServiceIdentifier;
      }
      return this.ServiceConfiguration.AuthenticateCrossRealm(this.ClientCredentials, this.AppliesTo, this.HomeRealmUri);
    }

    protected bool? ShouldRetry(MessageSecurityException messageSecurityException, bool? retry) => !retry.HasValue && messageSecurityException.InnerException is FaultException innerException && innerException.Code.IsSenderFault && innerException.Code.SubCode.Name == "BadContextToken" ? new bool?(true) : new bool?(false);

    protected virtual void ValidateAuthentication()
    {
      if (!this.IsAuthenticated)
        this.Authenticate();
      if (this._serviceChannel != null && !this._serviceChannel.IsChannelInvalid)
        return;
      this.CreateNewServiceChannel();
    }

    protected virtual SecurityTokenResponse AuthenticateDeviceCore()
    {
      if (this.ServiceConfiguration.AuthenticationType != AuthenticationProviderType.LiveId)
        return (SecurityTokenResponse) null;
      ClientExceptionHelper.ThrowIfNull((object) this.DeviceCredentials, "DeviceCredentials");
      return this.ServiceConfiguration.AuthenticateDevice(this.DeviceCredentials);
    }

    protected virtual void AuthenticateCore()
    {
      ClientExceptionHelper.ThrowIfNull((object) this.ServiceConfiguration, "ServiceConfiguration");
      if (this.ServiceConfiguration.AuthenticationType == AuthenticationProviderType.None)
        this.IsAuthenticated = true;
      else if (this.ServiceConfiguration.AuthenticationType == AuthenticationProviderType.ActiveDirectory)
      {
        this.IsAuthenticated = true;
      }
      else
      {
        if (this.ClientCredentials == null)
          return;
        SecurityTokenResponse securityTokenResponse = (SecurityTokenResponse) null;
        switch (this.ServiceConfiguration.AuthenticationType)
        {
          case AuthenticationProviderType.Federation:
            securityTokenResponse = this.AuthenticateClaims();
            break;
          case AuthenticationProviderType.LiveId:
            throw new InvalidOperationException("Authentication to MSA services is not supported.");
          case AuthenticationProviderType.OnlineFederation:
            securityTokenResponse = this.AuthenticateOnlineFederation();
            break;
        }
        ClientExceptionHelper.Assert(securityTokenResponse != null && securityTokenResponse.Token != null, "The user authentication failed!");
        this.SecurityTokenResponse = securityTokenResponse;
        this.IsAuthenticated = true;
      }
    }

    private SecurityTokenResponse AuthenticateOnlineFederation()
    {
      AuthenticationCredentials authenticationCredentials = new AuthenticationCredentials();
      authenticationCredentials.ClientCredentials = this.ClientCredentials;
      if (this.HomeRealmUri == (Uri) null)
      {
        string str = this.UserPrincipalName;
        if (string.IsNullOrEmpty(str))
        {
          if (string.IsNullOrEmpty(this.ClientCredentials.Windows.ClientCredential.UserName))
          {
            ClientExceptionHelper.ThrowIfNullOrEmpty(this.ClientCredentials.UserName.UserName, "ClientCredentials.UserName.UserName");
            str = this.ClientCredentials.UserName.UserName;
          }
          else
            str = this.ClientCredentials.Windows.ClientCredential.UserName;
        }
        authenticationCredentials.UserPrincipalName = str;
      }
      return this.ServiceManagement.Authenticate(authenticationCredentials)?.SecurityTokenResponse;
    }

    private SecurityTokenResponse AuthenticateClaims()
    {
      if (!(this.HomeRealmUri != (Uri) null))
        return this.ServiceConfiguration.Authenticate(this.ClientCredentials);
      this.HomeRealmSecurityTokenResponse = this.AuthenticateCrossRealm();
      ClientExceptionHelper.Assert(this.HomeRealmSecurityTokenResponse != null && this.HomeRealmSecurityTokenResponse.Token != null, "The user authentication failed!");
      return this.ServiceConfiguration.Authenticate(this.HomeRealmSecurityTokenResponse.Token);
    }

    protected virtual void CloseChannel(bool forceClose)
    {
      if (!forceClose && !this.AutoCloseChannel || this._serviceChannel == null)
        return;
      this._serviceChannel.Close();
    }

    protected static void SetBindingTimeout(
      Binding binding,
      TimeSpan sendTimeout,
      TimeSpan openTimeout,
      TimeSpan closeTimeout)
    {
      ClientExceptionHelper.ThrowIfNull((object) binding, nameof (binding));
      binding.OpenTimeout = openTimeout;
      binding.CloseTimeout = closeTimeout;
      binding.SendTimeout = sendTimeout;
    }

    protected System.ServiceModel.ChannelFactory<TService> ChannelFactory
    {
      get
      {
        if (this.IsChannelFactoryInvalid())
        {
          this._channelFactory = this.SecurityTokenResponse != null ? (this.SecurityTokenResponse.EndpointType == TokenServiceCredentialType.None || !(this.HomeRealmUri == (Uri) null) ? this.ServiceConfiguration.CreateChannelFactory(ClientAuthenticationType.SecurityToken) : this.ServiceConfiguration.CreateChannelFactory(this.SecurityTokenResponse.EndpointType)) : this.ServiceConfiguration.CreateChannelFactory(this.ClientCredentials);
          ServiceProxy<TService>.ConfigureEndpoint(this._channelFactory.Endpoint, this);
        }
        return this._channelFactory;
      }
    }

    internal static void ConfigureEndpoint(
      ServiceEndpoint endpoint,
      ServiceProxy<TService> serviceProxy)
    {
      ClientExceptionHelper.ThrowIfNull((object) endpoint, nameof (endpoint));
      ClientExceptionHelper.ThrowIfNull((object) serviceProxy, nameof (serviceProxy));
      foreach (OperationDescription operation in (Collection<OperationDescription>) endpoint.Contract.Operations)
      {
        DataContractSerializerOperationBehavior operationBehavior = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
        if (operationBehavior != null)
          operationBehavior.MaxItemsInObjectGraph = int.MaxValue;
      }
      XrmBinding xrmBinding = new XrmBinding(endpoint.Binding);
      endpoint.Binding = (Binding) xrmBinding;
      xrmBinding.MaxReceivedMessageSize = (long) int.MaxValue;
      xrmBinding.MaxBufferSize = int.MaxValue;
      xrmBinding.ReaderQuotas.MaxStringContentLength = int.MaxValue;
      xrmBinding.ReaderQuotas.MaxArrayLength = int.MaxValue;
      xrmBinding.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
      xrmBinding.ReaderQuotas.MaxNameTableCharCount = int.MaxValue;
      ServiceProxy<TService>.SetBindingTimeout((Binding) xrmBinding, serviceProxy.Timeout, serviceProxy.Timeout, serviceProxy.Timeout);
    }

    private void SetClientCredentials(ClientCredentials clientCredentials)
    {
      this.ClientCredentials = clientCredentials ?? new ClientCredentials();
      if (this.ServiceConfiguration.AuthenticationType != AuthenticationProviderType.ActiveDirectory)
        return;
      ServiceMetadataUtility.AdjustUserNameForWindows(this.ClientCredentials);
    }

    private void CreateNewServiceChannel()
    {
      this.ChannelFactory.Faulted += new EventHandler(this.Factory_Faulted);
      this.ChannelFactory.Opened += new EventHandler(this.Factory_Opened);
      this.ChannelFactory.Closed += new EventHandler(this.Factory_Closed);
      this._serviceChannel = this.SecurityTokenResponse == null || this.SecurityTokenResponse.Token == null ? new Microsoft.Xrm.Sdk.Client.ServiceChannel<TService>(this.ChannelFactory) : (Microsoft.Xrm.Sdk.Client.ServiceChannel<TService>) new ServiceFederatedChannel<TService>(this.ChannelFactory, this.SecurityTokenResponse.Token);
      this._serviceChannel.Timeout = this.Timeout;
    }

    private void RefreshChannelManagers()
    {
      if (this._channelFactory != null)
        ServiceProxy<TService>.SetBindingTimeout(this._channelFactory.Endpoint.Binding, this._timeout, this._timeout, this._timeout);
      if (this._serviceChannel == null)
        return;
      this._serviceChannel.Timeout = this._timeout;
    }

    private bool IsChannelFactoryInvalid()
    {
      if (this._channelFactory != null)
      {
        switch (this._channelFactory.State)
        {
          case CommunicationState.Created:
          case CommunicationState.Opening:
          case CommunicationState.Opened:
            return false;
        }
      }
      return true;
    }

    private void RemoveChannelFactoryEvents()
    {
      if (this._channelFactory == null)
        return;
      this._channelFactory.Faulted -= new EventHandler(this.Factory_Faulted);
      this._channelFactory.Opened -= new EventHandler(this.Factory_Opened);
      this._channelFactory.Closed -= new EventHandler(this.Factory_Closed);
    }

    private void Factory_Faulted(object sender, EventArgs e)
    {
      this.OnFactoryFaulted(new ChannelFaultedEventArgs("The Factory has entered a faulted state.", (Exception) null));
      if (this._channelFactory == null)
        return;
      this.RemoveChannelFactoryEvents();
      ChannelExtensions.Close(this._channelFactory);
      this._channelFactory = (System.ServiceModel.ChannelFactory<TService>) null;
    }

    protected virtual void OnFactoryFaulted(ChannelFaultedEventArgs args)
    {
      if (this.FactoryFaulted == null)
        return;
      this.FactoryFaulted((object) this, args);
    }

    private void Factory_Closed(object sender, EventArgs e) => this.OnFactoryClosed(new ChannelEventArgs("The Factory has entered a closed state."));

    protected virtual void OnFactoryClosed(ChannelEventArgs args)
    {
      if (this.FactoryClosed == null)
        return;
      this.FactoryClosed((object) this, args);
    }

    private void Factory_Opened(object sender, EventArgs e) => this.OnFactoryOpened(new ChannelEventArgs("The Factory has entered an opened state."));

    protected virtual void OnFactoryOpened(ChannelEventArgs args)
    {
      if (this.FactoryOpened == null)
        return;
      this.FactoryOpened((object) this, args);
    }

    public event EventHandler<ChannelFaultedEventArgs> FactoryFaulted;

    public event EventHandler<ChannelEventArgs> FactoryOpened;

    public event EventHandler<ChannelEventArgs> FactoryClosed;

    protected bool? HandleFailover(BaseServiceFault fault, bool? retry) => fault.ErrorCode == -2147176347 && this.HandleFailover(retry) ? new bool?(true) : new bool?(false);

    protected bool HandleFailover(bool? retry)
    {
      if (!retry.HasValue)
      {
        if (!this.EndpointSwitch.CanSwitch(this.ChannelFactory.Endpoint.Address.Uri))
        {
          this.Dispose(true);
          return true;
        }
        if (this.EndpointSwitch.HandleEndpointSwitch())
        {
          this.Dispose(true);
          return true;
        }
      }
      return false;
    }

    public event EventHandler<EndpointSwitchEventArgs> EndpointSwitched
    {
      add => this.EndpointSwitch.EndpointSwitched += value;
      remove => this.EndpointSwitch.EndpointSwitched -= value;
    }

    public event EventHandler<EndpointSwitchEventArgs> EndpointSwitchRequired
    {
      add => this.EndpointSwitch.EndpointSwitchRequired += value;
      remove => this.EndpointSwitch.EndpointSwitchRequired -= value;
    }

    public bool EndpointAutoSwitchEnabled
    {
      get => this.EndpointSwitch.EndpointAutoSwitchEnabled;
      set => this.EndpointSwitch.EndpointAutoSwitchEnabled = value;
    }

    public bool SwitchToAlternateEndpoint()
    {
      if (!this.EndpointAutoSwitchEnabled || !(this.EndpointSwitch.AlternateEndpoint != (Uri) null))
        return false;
      this.EndpointSwitch.SwitchEndpoint();
      return true;
    }

    private void SetDefaultEndpointSwitchBehavior() => this.EndpointAutoSwitchEnabled = this.EndpointSwitch.AlternateEndpoint != (Uri) null;

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    ~ServiceProxy() => this.Dispose(false);

    internal void DisposeFactory(bool disposing)
    {
      if (!disposing)
        return;
      if (this._channelFactory != null)
      {
        this.RemoveChannelFactoryEvents();
        ChannelExtensions.Close(this._channelFactory);
      }
      this._channelFactory = (System.ServiceModel.ChannelFactory<TService>) null;
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposing)
        return;
      this.DisposeFactory(disposing);
      if (this._serviceChannel != null)
        this._serviceChannel.Dispose();
      this._serviceChannel = (Microsoft.Xrm.Sdk.Client.ServiceChannel<TService>) null;
    }
  }
}
