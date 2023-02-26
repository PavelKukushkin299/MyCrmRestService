// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.ServiceChannel`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Security;
using System.Security.Permissions;
using System.ServiceModel;

namespace MyCrmConnector.Client
{
  [SecuritySafeCritical]
  [SecurityPermission(SecurityAction.Demand, Unrestricted = true)]
  public class ServiceChannel<TChannel> : IDisposable where TChannel : class
  {
    private readonly object _lockObject = new object();
    private TChannel _channel;
    private TimeSpan _timeout = ServiceDefaults.DefaultTimeout;
    private bool _updateTimeout = true;
    private bool _disposed;

    public ServiceChannel(ChannelFactory<TChannel> factory)
    {
      ClientExceptionHelper.ThrowIfNull((object) factory, nameof (factory));
      this.Factory = factory;
    }

    public TChannel Channel
    {
      get
      {
        if ((object) this._channel == null || this._disposed || !ServiceChannel<TChannel>.IsCommunicationObjectValid(this.CommunicationObject))
        {
          ClientExceptionHelper.ThrowIfNull((object) this.Factory, "Factory");
          this.ConfigureNewChannel();
        }
        lock (this._lockObject)
        {
          if (this._updateTimeout)
          {
            ((object) this._channel as IContextChannel).OperationTimeout = this._timeout;
            this._updateTimeout = false;
          }
        }
        return this._channel;
      }
    }

    protected ChannelFactory<TChannel> Factory { get; private set; }

    [SecuritySafeCritical]
    [SecurityPermission(SecurityAction.Demand, Unrestricted = true)]
    protected virtual TChannel CreateChannel() => this.Factory.CreateChannel();

    protected ICommunicationObject CommunicationObject => (object) this._channel as ICommunicationObject;

    internal static bool IsCommunicationObjectValid(ICommunicationObject communicationObject)
    {
      if (communicationObject != null)
      {
        switch (communicationObject.State)
        {
          case CommunicationState.Created:
          case CommunicationState.Opening:
          case CommunicationState.Opened:
            return true;
        }
      }
      return false;
    }

    internal TimeSpan Timeout
    {
      get => this._timeout;
      set
      {
        this._timeout = value;
        this._updateTimeout = true;
      }
    }

    internal bool IsChannelInvalid => this._disposed || this.Factory == null;

    private void ConfigureNewChannel()
    {
      this._channel = this.CreateChannel();
      this.CommunicationObject.Opened += new EventHandler(this.Channel_Opened);
      this.CommunicationObject.Faulted += new EventHandler(this.Channel_Faulted);
      this.CommunicationObject.Closed += new EventHandler(this.Channel_Closed);
    }

    private void RemoveChannelEvents()
    {
      if (this.CommunicationObject == null)
        return;
      this.CommunicationObject.Opened -= new EventHandler(this.Channel_Opened);
      this.CommunicationObject.Faulted -= new EventHandler(this.Channel_Faulted);
      this.CommunicationObject.Closed -= new EventHandler(this.Channel_Closed);
    }

    public void Open()
    {
      if (this.CommunicationObject == null)
        return;
      if (this.CommunicationObject.State != CommunicationState.Created)
        return;
      try
      {
        this.CommunicationObject.Open();
      }
      catch (Exception ex)
      {
        ChannelFaultedEventArgs args = new ChannelFaultedEventArgs("Exception when opening an SDK channel", ex);
        this.OnChannelFaulted(args);
        if (args.Cancel)
          return;
        throw;
      }
    }

    public void Abort()
    {
      if (this.CommunicationObject == null)
        return;
      this.CommunicationObject.Abort();
    }

    public void Close()
    {
      if (this.CommunicationObject == null)
        return;
      this.RemoveChannelEvents();
      ChannelExtensions.Close(this.CommunicationObject);
    }

    private void Channel_Faulted(object sender, EventArgs e)
    {
      ICommunicationObject channel = (object) this._channel as ICommunicationObject;
      this._channel = default (TChannel);
      this.OnChannelFaulted(new ChannelFaultedEventArgs("The channel has entered a faulted state.", (Exception) null));
      if (channel == null)
        return;
      this.RemoveChannelEvents();
      ChannelExtensions.Close(channel);
    }

    private void Channel_Closed(object sender, EventArgs e) => this.OnChannelClosed(new ChannelEventArgs("The channel has entered a closed state."));

    private void Channel_Opened(object sender, EventArgs e) => this.OnChannelOpened(new ChannelEventArgs("The channel has entered an opened state."));

    protected virtual void OnChannelFaulted(ChannelFaultedEventArgs args)
    {
      if (this.ChannelFaulted == null)
        return;
      this.ChannelFaulted((object) this, args);
    }

    protected virtual void OnChannelClosed(ChannelEventArgs args)
    {
      if (this.ChannelClosed == null)
        return;
      this.ChannelClosed((object) this, args);
    }

    protected virtual void OnChannelOpened(ChannelEventArgs args)
    {
      if (this.ChannelOpened == null)
        return;
      this.ChannelOpened((object) this, args);
    }

    public event EventHandler<ChannelFaultedEventArgs> ChannelFaulted;

    public event EventHandler<ChannelEventArgs> ChannelOpened;

    public event EventHandler<ChannelEventArgs> ChannelClosed;

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    ~ServiceChannel() => this.Dispose(false);

    private void Dispose(bool disposing)
    {
      if (this._disposed)
        return;
      if ((object) this._channel != null)
      {
        try
        {
          this.Close();
        }
        finally
        {
          this._channel = default (TChannel);
        }
      }
      this.Factory = (ChannelFactory<TChannel>) null;
      if (!disposing)
        return;
      this._disposed = true;
    }
  }
}
