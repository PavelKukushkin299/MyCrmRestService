// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.IssuerEndpoint
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;

namespace MyCrmConnector.Client
{
  public sealed class IssuerEndpoint
  {
    public Microsoft.Xrm.Sdk.Client.TokenServiceCredentialType CredentialType { get; set; }

    public TrustVersion TrustVersion { get; set; }

    public EndpointAddress IssuerAddress { get; set; }

    public Binding IssuerBinding { get; set; }

    public EndpointAddress IssuerMetadataAddress { get; set; }
  }
}
