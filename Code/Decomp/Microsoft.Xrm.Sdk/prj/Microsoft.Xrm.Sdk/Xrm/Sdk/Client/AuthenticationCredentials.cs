// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.AuthenticationCredentials
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.ServiceModel.Description;

namespace Microsoft.Xrm.Sdk.Client
{
  public sealed class AuthenticationCredentials
  {
    private ClientCredentials _clientCredentials = new ClientCredentials();

    public Uri AppliesTo { get; set; }

    public Uri HomeRealm { get; set; }

    public string UserPrincipalName { get; set; }

    public ClientCredentials ClientCredentials
    {
      get => this._clientCredentials;
      set => this._clientCredentials = value;
    }

    public SecurityTokenResponse SecurityTokenResponse { get; set; }

    public AuthenticationCredentials SupportingCredentials { get; set; }

    internal IssuerEndpoint IssuerEndpoint => this.IssuerEndpoints == null ? (IssuerEndpoint) null : this.IssuerEndpoints.GetIssuerEndpoint(this.EndpointType);

    internal TokenServiceCredentialType EndpointType { get; set; }

    internal string RequestType { get; set; }

    internal string KeyType { get; set; }

    internal IssuerEndpointDictionary IssuerEndpoints { get; set; }
  }
}
