// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.ServiceProxy`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

//using Microsoft.Xrm.Sdk;
//using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;


namespace MyCrmConnector.Client
{
    public abstract class ServiceProxy<TService> : IDisposable where TService : class
    {
        private ServiceChannel<TService> _serviceChannel;
        private ChannelFactory<TService> _channelFactory;
        private TimeSpan _timeout = ServiceDefaults.DefaultTimeout;
        private bool _autoCloseChannel;
        public Microsoft.Xrm.Sdk.Client.IServiceConfiguration<TService> ServiceConfiguration { get; private set; }
        public ClientCredentials ClientCredentials { get; private set; }
        public bool IsAuthenticated { get; private set; }
        public Microsoft.Xrm.Sdk.Client.IEndpointSwitch EndpointSwitch => this.ServiceConfiguration as Microsoft.Xrm.Sdk.Client.IEndpointSwitch;
        public Microsoft.Xrm.Sdk.Client.SecurityTokenResponse SecurityTokenResponse { get; protected set; }
        public Uri HomeRealmUri { get; private set; }
        public string UserPrincipalName { get; set; }
        public Microsoft.Xrm.Sdk.Client.IServiceManagement<TService> ServiceManagement => this.ServiceConfiguration as Microsoft.Xrm.Sdk.Client.IServiceManagement<TService>;
        public Microsoft.Xrm.Sdk.Client.SecurityTokenResponse HomeRealmSecurityTokenResponse { get; protected set; }
        public TimeSpan Timeout
        {
            get => this._timeout;
            set
            {
                this._timeout = value;
                this.RefreshChannelManagers();
            }
        }

        internal bool AutoCloseChannel
        {
            get => this._autoCloseChannel;
            set => this._autoCloseChannel = value;
        }

        public bool EndpointAutoSwitchEnabled
        {
            get => this.EndpointSwitch.EndpointAutoSwitchEnabled;
            set => this.EndpointSwitch.EndpointAutoSwitchEnabled = value;
        }

        public ServiceChannel<TService> ServiceChannel
        {
            get
            {
                this.ValidateAuthentication();
                return this._serviceChannel;
            }
        }

        protected System.ServiceModel.ChannelFactory<TService> ChannelFactory
        {
            get
            {
                if (this.IsChannelFactoryInvalid())
                {
                    this._channelFactory = this.SecurityTokenResponse != null ? (this.SecurityTokenResponse.EndpointType == Microsoft.Xrm.Sdk.Client.TokenServiceCredentialType.None || !(this.HomeRealmUri == (Uri)null) ? this.ServiceConfiguration.CreateChannelFactory(Microsoft.Xrm.Sdk.Client.ClientAuthenticationType.SecurityToken) : this.ServiceConfiguration.CreateChannelFactory(this.SecurityTokenResponse.EndpointType)) : this.ServiceConfiguration.CreateChannelFactory(this.ClientCredentials);
                    ServiceProxy<TService>.ConfigureEndpoint(this._channelFactory.Endpoint, this);
                }
                return this._channelFactory;
            }
        }

        public event EventHandler<ChannelFaultedEventArgs> FactoryFaulted;
        public event EventHandler<ChannelEventArgs> FactoryOpened;
        public event EventHandler<ChannelEventArgs> FactoryClosed;

        protected ServiceProxy(Microsoft.Xrm.Sdk.Client.IServiceConfiguration<TService> serviceConfiguration, ClientCredentials clientCredentials)
        {
            ClientExceptionHelper.ThrowIfNull((object)serviceConfiguration, nameof(serviceConfiguration));
            ClientExceptionHelper.ThrowIfNull((object)serviceConfiguration.CurrentServiceEndpoint, "serviceConfiguration.CurrentServiceEndpoint");
            this.ServiceConfiguration = serviceConfiguration;
            this.SetClientCredentials(clientCredentials);
            this.IsAuthenticated = true;
            this.SetDefaultEndpointSwitchBehavior();
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose");
            throw new NotImplementedException();
        }

        private void SetClientCredentials(ClientCredentials clientCredentials)
        {
            this.ClientCredentials = clientCredentials ?? new ClientCredentials();
            if (this.ServiceConfiguration.AuthenticationType != Microsoft.Xrm.Sdk.Client.AuthenticationProviderType.ActiveDirectory)
            {
                return;
            }
            ServiceMetadataUtility.AdjustUserNameForWindows(this.ClientCredentials);
        }

        private void SetDefaultEndpointSwitchBehavior() => this.EndpointAutoSwitchEnabled = this.EndpointSwitch.AlternateEndpoint != (Uri)null;

        protected virtual void ValidateAuthentication()
        {
            if (!this.IsAuthenticated)
                this.Authenticate();
            if (this._serviceChannel != null && !this._serviceChannel.IsChannelInvalid)
                return;
            this.CreateNewServiceChannel();
        }

        public void Authenticate()
        {
            if (this._serviceChannel != null)
            {
                this._serviceChannel.Close();
                this._serviceChannel.Dispose();
                this._serviceChannel = (ServiceChannel<TService>)null;
            }
            if (this._channelFactory != null)
            {
                this.RemoveChannelFactoryEvents();
                ChannelExtensions.Close(this._channelFactory);
                this._channelFactory = (System.ServiceModel.ChannelFactory<TService>)null;
            }
            this.AuthenticateCore();
        }

        private void CreateNewServiceChannel()
        {
            this.ChannelFactory.Faulted += new EventHandler(this.Factory_Faulted);
            this.ChannelFactory.Opened += new EventHandler(this.Factory_Opened);
            this.ChannelFactory.Closed += new EventHandler(this.Factory_Closed);
            this._serviceChannel = this.SecurityTokenResponse == null || this.SecurityTokenResponse.Token == null ? 
                new ServiceChannel<TService>(this.ChannelFactory) : (ServiceChannel<TService>)new ServiceFederatedChannel<TService>(this.ChannelFactory, this.SecurityTokenResponse.Token);
            this._serviceChannel.Timeout = this.Timeout;
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

        internal static void ConfigureEndpoint(
            ServiceEndpoint endpoint,
            ServiceProxy<TService> serviceProxy)
        {
            ClientExceptionHelper.ThrowIfNull((object)endpoint, nameof(endpoint));
            ClientExceptionHelper.ThrowIfNull((object)serviceProxy, nameof(serviceProxy));
            foreach (OperationDescription operation in (Collection<OperationDescription>)endpoint.Contract.Operations)
            {
                DataContractSerializerOperationBehavior operationBehavior = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
                if (operationBehavior != null)
                    operationBehavior.MaxItemsInObjectGraph = int.MaxValue;
            }
            XrmBinding xrmBinding = new XrmBinding(endpoint.Binding);
            endpoint.Binding = (Binding)xrmBinding;
            xrmBinding.MaxReceivedMessageSize = (long)int.MaxValue;
            xrmBinding.MaxBufferSize = int.MaxValue;
            xrmBinding.ReaderQuotas.MaxStringContentLength = int.MaxValue;
            xrmBinding.ReaderQuotas.MaxArrayLength = int.MaxValue;
            xrmBinding.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
            xrmBinding.ReaderQuotas.MaxNameTableCharCount = int.MaxValue;
            ServiceProxy<TService>.SetBindingTimeout((Binding)xrmBinding, serviceProxy.Timeout, serviceProxy.Timeout, serviceProxy.Timeout);
        }

        protected static void SetBindingTimeout(
            Binding binding,
            TimeSpan sendTimeout,
            TimeSpan openTimeout,
            TimeSpan closeTimeout)
        {
            ClientExceptionHelper.ThrowIfNull((object)binding, nameof(binding));
            binding.OpenTimeout = openTimeout;
            binding.CloseTimeout = closeTimeout;
            binding.SendTimeout = sendTimeout;
        }

        private void RefreshChannelManagers()
        {
            if (this._channelFactory != null)
                ServiceProxy<TService>.SetBindingTimeout(this._channelFactory.Endpoint.Binding, this._timeout, this._timeout, this._timeout);
            if (this._serviceChannel == null)
                return;
            this._serviceChannel.Timeout = this._timeout;
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
            this.OnFactoryFaulted(new ChannelFaultedEventArgs("The Factory has entered a faulted state.", (Exception)null));
            if (this._channelFactory == null)
                return;
            this.RemoveChannelFactoryEvents();
            ChannelExtensions.Close(this._channelFactory);
            this._channelFactory = (System.ServiceModel.ChannelFactory<TService>)null;
        }

        protected virtual void OnFactoryFaulted(ChannelFaultedEventArgs args)
        {
            if (this.FactoryFaulted == null)
                return;
            this.FactoryFaulted((object)this, args);
        }

        private void Factory_Opened(object sender, EventArgs e) => this.OnFactoryOpened(new ChannelEventArgs("The Factory has entered an opened state."));

        protected virtual void OnFactoryOpened(ChannelEventArgs args)
        {
            if (this.FactoryOpened == null)
                return;
            this.FactoryOpened((object)this, args);
        }

        private void Factory_Closed(object sender, EventArgs e) => this.OnFactoryClosed(new ChannelEventArgs("The Factory has entered a closed state."));

        protected virtual void OnFactoryClosed(ChannelEventArgs args)
        {
            if (this.FactoryClosed == null)
                return;
            this.FactoryClosed((object)this, args);
        }

        protected virtual void AuthenticateCore()
        {
            ClientExceptionHelper.ThrowIfNull((object)this.ServiceConfiguration, "ServiceConfiguration");
            if (this.ServiceConfiguration.AuthenticationType == Microsoft.Xrm.Sdk.Client.AuthenticationProviderType.None)
                this.IsAuthenticated = true;
            else if (this.ServiceConfiguration.AuthenticationType == Microsoft.Xrm.Sdk.Client.AuthenticationProviderType.ActiveDirectory)
            {
                this.IsAuthenticated = true;
            }
            else
            {
                if (this.ClientCredentials == null)
                    return;
                Microsoft.Xrm.Sdk.Client.SecurityTokenResponse securityTokenResponse = (Microsoft.Xrm.Sdk.Client.SecurityTokenResponse)null;
                switch (this.ServiceConfiguration.AuthenticationType)
                {
                    case Microsoft.Xrm.Sdk.Client.AuthenticationProviderType.Federation:
                        securityTokenResponse = this.AuthenticateClaims();
                        break;
                    case Microsoft.Xrm.Sdk.Client.AuthenticationProviderType.LiveId:
                        throw new InvalidOperationException("Authentication to MSA services is not supported.");
                    case Microsoft.Xrm.Sdk.Client.AuthenticationProviderType.OnlineFederation:
                        securityTokenResponse = this.AuthenticateOnlineFederation();
                        break;
                }
                ClientExceptionHelper.Assert(securityTokenResponse != null && securityTokenResponse.Token != null, "The user authentication failed!");
                this.SecurityTokenResponse = securityTokenResponse;
                this.IsAuthenticated = true;
            }
        }

        private Microsoft.Xrm.Sdk.Client.SecurityTokenResponse AuthenticateOnlineFederation()
        {
            Microsoft.Xrm.Sdk.Client.AuthenticationCredentials authenticationCredentials = new Microsoft.Xrm.Sdk.Client.AuthenticationCredentials();
            authenticationCredentials.ClientCredentials = this.ClientCredentials;
            if (this.HomeRealmUri == (Uri)null)
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

        private Microsoft.Xrm.Sdk.Client.SecurityTokenResponse AuthenticateClaims()
        {
            if (!(this.HomeRealmUri != (Uri)null))
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

        public Microsoft.Xrm.Sdk.Client.SecurityTokenResponse AuthenticateCrossRealm() => this.AuthenticateCrossRealmCore();

        protected virtual Microsoft.Xrm.Sdk.Client.SecurityTokenResponse AuthenticateCrossRealmCore()
        {
            //ClientExceptionHelper.ThrowIfNull((object)this.ServiceConfiguration, "ServiceConfiguration");
            //ClientExceptionHelper.ThrowIfNull((object)this.HomeRealmUri, "HomeRealmUri");
            //if (this.AppliesTo == null)
            //{
            //    ClientExceptionHelper.ThrowIfNull((object)this.ServiceConfiguration.PolicyConfiguration, "ServiceConfiguration.PolicyConfiguration");
            //    ClientExceptionHelper.ThrowIfNullOrEmpty(this.ServiceConfiguration.PolicyConfiguration.SecureTokenServiceIdentifier, "ServiceConfiguration.PolicyConfiguration.SecureTokenServiceIdentifier");
            //    this.AppliesTo = this.ServiceConfiguration.PolicyConfiguration.SecureTokenServiceIdentifier;
            //}
            //return this.ServiceConfiguration.AuthenticateCrossRealm(this.ClientCredentials, this.AppliesTo, this.HomeRealmUri);
            //тут
            Console.WriteLine("AuthenticateCrossRealmCore");
            throw new NotImplementedException();
        }





















    }
}
