// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.IdentityProviderTrustConfiguration
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Crm.Protocols.WSTrust.Bindings;
using System;
using System.Security;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;

namespace MyCrmConnector.Client
{
  [SecuritySafeCritical]
  [SecurityPermission(SecurityAction.Demand, Unrestricted = true)]
  public abstract class IdentityProviderTrustConfiguration
  {
    private TrustVersion _trustVersion = TrustVersion.WSTrustFeb2005;
    private SecurityMode _securityMode = SecurityMode.TransportWithMessageCredential;

    internal AuthenticationPolicy XrmPolicy { get; private set; }

    internal IdentityProviderTrustConfiguration()
    {
    }

    internal IdentityProviderTrustConfiguration(AuthenticationPolicy xrmPolicy) => this.XrmPolicy = xrmPolicy;

    public abstract Uri Endpoint { get; }

    internal Binding Binding
    {
      get
      {
                //UserNameWSTrustBinding binding = new UserNameWSTrustBinding();
                //binding.TrustVersion = this._trustVersion;
                //binding.SecurityMode = this._securityMode;
                //return (Binding) binding;
                throw new NotImplementedException();
      }
    }

    public string Policy { get; set; }

    public string LiveIdAppliesTo { get; set; }

    public string AppliesTo { get; set; }

    internal TrustVersion TrustVersion
    {
      get => this._trustVersion;
      set => this._trustVersion = value;
    }

    internal SecurityMode SecurityMode
    {
      get => this._securityMode;
      set => this._securityMode = value;
    }
  }
}
