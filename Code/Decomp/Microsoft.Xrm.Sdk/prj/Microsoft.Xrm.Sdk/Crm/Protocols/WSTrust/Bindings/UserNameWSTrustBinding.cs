// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Protocols.WSTrust.Bindings.UserNameWSTrustBinding
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.Crm.Protocols.WSTrust.Bindings
{
  internal sealed class UserNameWSTrustBinding : WSTrustBindingBase
  {
    private HttpClientCredentialType _clientCredentialType;

    public UserNameWSTrustBinding()
      : this(SecurityMode.Message, HttpClientCredentialType.None)
    {
    }

    public UserNameWSTrustBinding(SecurityMode securityMode)
      : base(securityMode)
    {
      if (SecurityMode.Message != securityMode)
        return;
      this._clientCredentialType = HttpClientCredentialType.None;
    }

    public UserNameWSTrustBinding(SecurityMode mode, HttpClientCredentialType clientCredentialType)
      : base(mode)
    {
      if (!UserNameWSTrustBinding.IsHttpClientCredentialTypeDefined(clientCredentialType))
        throw new ArgumentOutOfRangeException(nameof (clientCredentialType));
      this._clientCredentialType = SecurityMode.Transport != mode || HttpClientCredentialType.Digest == clientCredentialType || HttpClientCredentialType.Basic == clientCredentialType ? clientCredentialType : throw new InvalidOperationException(ClientExceptionHelper.GetString("ID3225: UserNameWSTrustBinding in SecurityMode.Transport SecurityMode, clientCredentialType must be Digest or Basic. But actual value is '{0}'", (object) clientCredentialType));
    }

    protected override void ApplyTransportSecurity(HttpTransportBindingElement transport)
    {
      if (this._clientCredentialType == HttpClientCredentialType.Basic)
        transport.AuthenticationScheme = AuthenticationSchemes.Basic;
      else
        transport.AuthenticationScheme = AuthenticationSchemes.Digest;
    }

    protected override SecurityBindingElement CreateSecurityBindingElement()
    {
      if (SecurityMode.Message == this.SecurityMode)
        return (SecurityBindingElement) SecurityBindingElement.CreateUserNameForCertificateBindingElement();
      return SecurityMode.TransportWithMessageCredential == this.SecurityMode ? (SecurityBindingElement) SecurityBindingElement.CreateUserNameOverTransportBindingElement() : (SecurityBindingElement) null;
    }

    private static bool IsHttpClientCredentialTypeDefined(HttpClientCredentialType value) => value == HttpClientCredentialType.None || value == HttpClientCredentialType.Basic || value == HttpClientCredentialType.Digest || value == HttpClientCredentialType.Ntlm || value == HttpClientCredentialType.Windows || value == HttpClientCredentialType.Certificate;

    public HttpClientCredentialType ClientCredentialType
    {
      get => this._clientCredentialType;
      set
      {
        if (!UserNameWSTrustBinding.IsHttpClientCredentialTypeDefined(value))
          throw new ArgumentOutOfRangeException(nameof (value));
        this._clientCredentialType = SecurityMode.Transport != this.SecurityMode || HttpClientCredentialType.Digest == value || HttpClientCredentialType.Basic == value ? value : throw new InvalidOperationException(ClientExceptionHelper.GetString("ID3225: UserNameWSTrustBinding in SecurityMode.Transport SecurityMode, clientCredentialType must be Digest or Basic. But actual value is '{0}'", (object) value));
      }
    }
  }
}
