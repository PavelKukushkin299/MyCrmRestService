// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Protocols.WSTrust.Bindings.WSTrustBindingBase
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;

namespace Microsoft.Crm.Protocols.WSTrust.Bindings
{
  internal abstract class WSTrustBindingBase : Binding
  {
    private bool _enableRsaProofKeys;
    private SecurityMode _securityMode;
    private TrustVersion _trustVersion;

    protected WSTrustBindingBase(SecurityMode securityMode)
      : this(securityMode, TrustVersion.WSTrust13)
    {
    }

    protected WSTrustBindingBase(SecurityMode securityMode, TrustVersion trustVersion)
    {
      this._securityMode = SecurityMode.Message;
      this._trustVersion = TrustVersion.WSTrust13;
      if (trustVersion == null)
        throw new ArgumentNullException(nameof (trustVersion));
      WSTrustBindingBase.ValidateTrustVersion(trustVersion);
      WSTrustBindingBase.ValidateSecurityMode(securityMode);
      this._securityMode = securityMode;
      this._trustVersion = trustVersion;
    }

    protected virtual SecurityBindingElement ApplyMessageSecurity(
      SecurityBindingElement securityBindingElement)
    {
      if (securityBindingElement == null)
        throw new ArgumentNullException(nameof (securityBindingElement));
      securityBindingElement.MessageSecurityVersion = TrustVersion.WSTrustFeb2005 != this._trustVersion ? MessageSecurityVersion.WSSecurity11WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10 : MessageSecurityVersion.WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10;
      if (this._enableRsaProofKeys)
      {
        RsaSecurityTokenParameters securityTokenParameters1 = new RsaSecurityTokenParameters();
        securityTokenParameters1.InclusionMode = SecurityTokenInclusionMode.Never;
        securityTokenParameters1.RequireDerivedKeys = false;
        RsaSecurityTokenParameters securityTokenParameters2 = securityTokenParameters1;
        securityBindingElement.OptionalEndpointSupportingTokenParameters.Endorsing.Add((SecurityTokenParameters) securityTokenParameters2);
      }
      return securityBindingElement;
    }

    protected abstract void ApplyTransportSecurity(HttpTransportBindingElement transport);

    public override BindingElementCollection CreateBindingElements()
    {
      BindingElementCollection elementCollection = new BindingElementCollection();
      elementCollection.Clear();
      if (SecurityMode.Message == this._securityMode || SecurityMode.TransportWithMessageCredential == this._securityMode)
        elementCollection.Add((BindingElement) this.ApplyMessageSecurity(this.CreateSecurityBindingElement()));
      elementCollection.Add((BindingElement) this.CreateEncodingBindingElement());
      elementCollection.Add((BindingElement) this.CreateTransportBindingElement());
      return elementCollection.Clone();
    }

    protected virtual MessageEncodingBindingElement CreateEncodingBindingElement() => (MessageEncodingBindingElement) new TextMessageEncodingBindingElement()
    {
      ReaderQuotas = {
        MaxArrayLength = 2097152,
        MaxStringContentLength = 2097152
      }
    };

    protected abstract SecurityBindingElement CreateSecurityBindingElement();

    protected virtual HttpTransportBindingElement CreateTransportBindingElement()
    {
      HttpTransportBindingElement transport = SecurityMode.Message != this._securityMode ? (HttpTransportBindingElement) new HttpsTransportBindingElement() : new HttpTransportBindingElement();
      transport.MaxReceivedMessageSize = 2097152L;
      if (SecurityMode.Transport == this._securityMode)
        this.ApplyTransportSecurity(transport);
      return transport;
    }

    protected static void ValidateSecurityMode(SecurityMode securityMode)
    {
      if (securityMode != SecurityMode.None && securityMode != SecurityMode.Message && securityMode != SecurityMode.Transport && securityMode != SecurityMode.TransportWithMessageCredential)
        throw new ArgumentOutOfRangeException(nameof (securityMode));
      if (securityMode == SecurityMode.None)
        throw new InvalidOperationException(ClientExceptionHelper.GetString("ID3224: SecurityMode cannot be SecurityMode.None."));
    }

    protected static void ValidateTrustVersion(TrustVersion trustVersion)
    {
      if (trustVersion != TrustVersion.WSTrust13 && trustVersion != TrustVersion.WSTrustFeb2005)
        throw new ArgumentOutOfRangeException(nameof (trustVersion));
    }

    public bool EnableRsaProofKeys
    {
      get => this._enableRsaProofKeys;
      set => this._enableRsaProofKeys = value;
    }

    public override string Scheme
    {
      get
      {
        TransportBindingElement transportBindingElement = this.CreateBindingElements().Find<TransportBindingElement>();
        return transportBindingElement == null ? string.Empty : transportBindingElement.Scheme;
      }
    }

    public SecurityMode SecurityMode
    {
      get => this._securityMode;
      set
      {
        WSTrustBindingBase.ValidateSecurityMode(value);
        this._securityMode = value;
      }
    }

    public TrustVersion TrustVersion
    {
      get => this._trustVersion;
      set
      {
        if (value == null)
          throw new ArgumentNullException(nameof (value));
        WSTrustBindingBase.ValidateTrustVersion(value);
        this._trustVersion = value;
      }
    }
  }
}
