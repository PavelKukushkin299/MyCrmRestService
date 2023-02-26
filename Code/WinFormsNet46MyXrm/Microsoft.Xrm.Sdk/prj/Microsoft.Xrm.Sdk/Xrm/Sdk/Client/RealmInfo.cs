// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.RealmInfo
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Xml.Serialization;

namespace Microsoft.Xrm.Sdk.Client
{
  public sealed class RealmInfo
  {
    public string State { get; set; }

    public string UserState { get; set; }

    public string LogOn { get; set; }

    public string FederationGlobalVersion { get; set; }

    public string DomainName { get; set; }

    [XmlElement("AuthURL")]
    public string AuthorizationUrl { get; set; }

    [XmlElement("IsFederatedNS")]
    public bool IsFederatedNamespace { get; set; }

    [XmlElement("STSAuthURL")]
    public string TokenServiceAuthenticationUrl { get; set; }

    public int FederationTier { get; set; }

    public string FederationBrandName { get; set; }

    [XmlElement("AllowFedUsersWLIDSignIn")]
    public bool AllowFedUsersLiveIdSignIn { get; set; }

    public string Certificate { get; set; }

    [XmlElement("MEXURL")]
    public string MetadataUrl { get; set; }

    [XmlElement("SAML_AuthURL")]
    public string SamlAuthUrl { get; set; }

    public int PreferredProtocol { get; set; }

    [XmlIgnore]
    [XmlElement("EDUDomainFlags")]
    public int EduDomains { get; set; }

    [XmlElement("NameSpaceType")]
    public string NamespaceType { get; set; }
  }
}
