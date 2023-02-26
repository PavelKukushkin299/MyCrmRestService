// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.AuthenticationPolicyImporter
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Xml;
using System.Xml.XPath;

namespace MyCrmConnector.Client
{
  internal sealed class AuthenticationPolicyImporter : IPolicyImportExtension
  {
    internal const string MsXrm = "ms-xrm";
    internal readonly string MsXrmAuthentication = "//ms-xrm:Authentication";
    internal const string MsXrmSecureTokenServiceMsXrmIdentifier = "//ms-xrm:SecureTokenService/ms-xrm:Identifier";
    internal const string MsXrmLiveTrust = "//ms-xrm:LiveTrust/";
    internal const string MsXrmOrgTrust = "//ms-xrm:OrgTrust/";
    internal const string AuthenticationPolicy = "AuthenticationPolicy";
    internal const string LivePartnerIdentifier = "LivePartnerIdentifier";
    internal const string AppliesTo = "AppliesTo";
    internal const string TrustVersion = "TrustVersion";
    internal const string SecurityMode = "SecurityMode";
    internal const string LivePolicy = "LivePolicy";
    internal const string AuthenticationType = "AuthenticationType";
    internal const string SecureTokenServiceIdentifier = "SecureTokenServiceIdentifier";
    internal const string LiveIdAppliesTo = "LiveIdAppliesTo";
    internal const string LiveTrustTrustVersion = "LiveTrustTrustVersion";
    internal const string LiveTrustSecurityMode = "LiveTrustSecurityMode";
    internal const string LiveTrustLivePolicy = "LiveTrustLivePolicy";
    internal const string LiveTrustLiveIdAppliesTo = "LiveTrustLiveIdAppliesTo";
    internal const string LiveEndpoint = "LiveEndpoint";
    internal const string OrgIdAppliesTo = "OrgIdAppliesTo";
    internal const string OrgIdTrustVersion = "OrgIdTrustVersion";
    internal const string OrgIdSecurityMode = "OrgIdSecurityMode";
    internal const string OrgIdPolicy = "OrgIdPolicy";
    internal const string OrgIdDeviceAppliesTo = "OrgIdDeviceAppliesTo";
    internal const string OrgIdEndpoint = "OrgIdEndpoint";
    internal const string Identifier = "Identifier";
    internal const string OrgIdIdentifier = "OrgIdIdentifier";
    private const string HttpDocsOasisOpenOrgWsSxWsSecuritypolicy = "http://docs.oasis-open.org/ws-sx/ws-securitypolicy/200702";
    private const string HttpSchemasXmlsoapOrgWsPolicy = "http://schemas.xmlsoap.org/ws/2004/09/policy";
    private const string HttpWwwW3OrgAddressing = "http://www.w3.org/2005/08/addressing";
    private readonly IPolicyImportExtension _importer;
    private readonly object _lockObject = new object();

    public AuthenticationPolicyImporter(SecurityBindingElementImporter importer) => this._importer = (IPolicyImportExtension) importer;

    public void ImportPolicy(MetadataImporter importer, PolicyConversionContext context)
    {
      this.ImportXrmAuthenticationPolicy(context);
      this.ImportSecurityPolicy(importer, context);
    }

    private bool ImportPolicyLegacy(PolicyConversionContext context)
    {
      this.ImportFailoverPolicy(context);
      XmlElement xmlElement = context.GetBindingAssertions().Find("AuthenticationPolicy", "http://schemas.microsoft.com/xrm/2011/Contracts/Services");
      if (xmlElement == null)
        return false;
      bool flag = true;
            MyCrmConnector.Client.AuthenticationPolicy xrmPolicyBindingElement = context.BindingElements.Find<MyCrmConnector.Client.AuthenticationPolicy>();
      if (xrmPolicyBindingElement == null)
      {
        xrmPolicyBindingElement = new MyCrmConnector.Client.AuthenticationPolicy();
        context.BindingElements.Insert(0, (BindingElement) xrmPolicyBindingElement);
      }
      else if (xrmPolicyBindingElement.PolicyElements.ContainsKey("OrgIdAppliesTo"))
        flag = false;
      context.GetBindingAssertions().Remove(xmlElement);
      if (flag)
      {
        XPathNavigator navigator = xmlElement.CreateNavigator();
        if (navigator != null)
        {
          XmlNamespaceManager nsmgr = new XmlNamespaceManager(navigator.NameTable);
          nsmgr.AddNamespace("ms-xrm", "http://schemas.microsoft.com/xrm/2011/Contracts/Services");
          AuthenticationPolicyImporter.ExtractValue((XrmPolicy) xrmPolicyBindingElement, navigator, nsmgr, this.MsXrmAuthentication, "AuthenticationType");
          AuthenticationPolicyImporter.ExtractValue((XrmPolicy) xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:SecureTokenService/ms-xrm:Identifier", "SecureTokenServiceIdentifier");
          AuthenticationPolicyImporter.ExtractLiveTrustElements(xrmPolicyBindingElement, navigator, nsmgr);
        }
      }
      return true;
    }

    private bool ImportFailoverPolicy(PolicyConversionContext context)
    {
      XmlElement xmlElement = context.GetBindingAssertions().Find("FailoverPolicy", "http://schemas.microsoft.com/xrm/2012/Contracts/Services");
      if (xmlElement == null)
        return false;
      FailoverPolicy failoverPolicy = context.BindingElements.Find<FailoverPolicy>();
      if (failoverPolicy == null)
      {
        failoverPolicy = new FailoverPolicy();
        context.BindingElements.Insert(0, (BindingElement) failoverPolicy);
      }
      context.GetBindingAssertions().Remove(xmlElement);
      if (true)
      {
        XPathNavigator navigator = xmlElement.CreateNavigator();
        if (navigator != null)
        {
          XmlNamespaceManager nsmgr = new XmlNamespaceManager(navigator.NameTable);
          nsmgr.AddNamespace("ms-xrm", "http://schemas.microsoft.com/xrm/2012/Contracts/Services");
          AuthenticationPolicyImporter.ExtractValue((XrmPolicy) failoverPolicy, navigator, nsmgr, "ms-xrm:FailoverAvailable", "FailoverAvailable");
          AuthenticationPolicyImporter.ExtractValue((XrmPolicy) failoverPolicy, navigator, nsmgr, "ms-xrm:EndpointEnabled", "EndpointEnabled");
        }
      }
      return true;
    }

    private void ImportXrmAuthenticationPolicy(PolicyConversionContext context)
    {
      bool flag = this.ImportPolicyLegacy(context);
      this.ImportFailoverPolicy(context);
      XmlElement xmlElement = context.GetBindingAssertions().Find("AuthenticationPolicy", "http://schemas.microsoft.com/xrm/2012/Contracts/Services");
      if (xmlElement == null)
        return;
            MyCrmConnector.Client.AuthenticationPolicy xrmPolicyBindingElement = context.BindingElements.Find<MyCrmConnector.Client.AuthenticationPolicy>();
      string str = (string) null;
      if (xrmPolicyBindingElement == null | flag)
      {
        if (flag)
          context.BindingElements.Remove((BindingElement) xrmPolicyBindingElement);
        xrmPolicyBindingElement?.PolicyElements.TryGetValue("AppliesTo", out str);
        xrmPolicyBindingElement = new MyCrmConnector.Client.AuthenticationPolicy();
        if (!string.IsNullOrWhiteSpace(str))
          xrmPolicyBindingElement.PolicyElements.Add("LivePartnerIdentifier", str);
        context.BindingElements.Insert(0, (BindingElement) xrmPolicyBindingElement);
      }
      context.GetBindingAssertions().Remove(xmlElement);
      XPathNavigator navigator = xmlElement.CreateNavigator();
      if (navigator == null)
        return;
      XmlNamespaceManager nsmgr = new XmlNamespaceManager(navigator.NameTable);
      nsmgr.AddNamespace("ms-xrm", "http://schemas.microsoft.com/xrm/2012/Contracts/Services");
      AuthenticationPolicyImporter.ExtractValue((XrmPolicy) xrmPolicyBindingElement, navigator, nsmgr, this.MsXrmAuthentication, "AuthenticationType");
      AuthenticationPolicyImporter.ExtractValue((XrmPolicy) xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:SecureTokenService/ms-xrm:Identifier", "SecureTokenServiceIdentifier");
      AuthenticationPolicyImporter.ExtractLiveTrustElements(xrmPolicyBindingElement, navigator, nsmgr);
      AuthenticationPolicyImporter.ExtractOrgTrustElements(xrmPolicyBindingElement, navigator, nsmgr);
    }

    private static void ExtractLiveTrustElements(
      MyCrmConnector.Client.AuthenticationPolicy xrmPolicyBindingElement,
      XPathNavigator navigator,
      XmlNamespaceManager nsmgr)
    {
      AuthenticationPolicyImporter.ExtractValue((XrmPolicy) xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:LiveTrust/ms-xrm:AppliesTo", "AppliesTo");
      AuthenticationPolicyImporter.ExtractValue((XrmPolicy) xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:LiveTrust/ms-xrm:TrustVersion", "LiveTrustTrustVersion");
      AuthenticationPolicyImporter.ExtractValue((XrmPolicy) xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:LiveTrust/ms-xrm:SecurityMode", "LiveTrustSecurityMode");
      AuthenticationPolicyImporter.ExtractValue((XrmPolicy) xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:LiveTrust/ms-xrm:LivePolicy", "LiveTrustLivePolicy");
      AuthenticationPolicyImporter.ExtractValue((XrmPolicy) xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:LiveTrust/ms-xrm:LiveIdAppliesTo", "LiveTrustLiveIdAppliesTo");
      AuthenticationPolicyImporter.ExtractValue((XrmPolicy) xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:LiveTrust/ms-xrm:LiveEndpoint", "LiveEndpoint");
    }

    private static void ExtractOrgTrustElements(
      MyCrmConnector.Client.AuthenticationPolicy xrmPolicyBindingElement,
      XPathNavigator navigator,
      XmlNamespaceManager nsmgr)
    {
      AuthenticationPolicyImporter.ExtractValue((XrmPolicy) xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:OrgTrust/ms-xrm:AppliesTo", "OrgIdAppliesTo");
      AuthenticationPolicyImporter.ExtractValue((XrmPolicy) xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:OrgTrust/ms-xrm:TrustVersion", "OrgIdTrustVersion");
      AuthenticationPolicyImporter.ExtractValue((XrmPolicy) xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:OrgTrust/ms-xrm:SecurityMode", "OrgIdSecurityMode");
      AuthenticationPolicyImporter.ExtractValue((XrmPolicy) xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:OrgTrust/ms-xrm:LivePolicy", "OrgIdPolicy");
      AuthenticationPolicyImporter.ExtractValue((XrmPolicy) xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:OrgTrust/ms-xrm:LiveIdAppliesTo", "OrgIdDeviceAppliesTo");
      AuthenticationPolicyImporter.ExtractValue((XrmPolicy) xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:OrgTrust/ms-xrm:LiveEndpoint", "OrgIdEndpoint");
      AuthenticationPolicyImporter.ExtractValue((XrmPolicy) xrmPolicyBindingElement, navigator, nsmgr, "//ms-xrm:OrgTrust/ms-xrm:Identifier", "OrgIdIdentifier");
    }

    private static void ExtractValue(
      XrmPolicy xrmPolicy,
      XPathNavigator navigator,
      XmlNamespaceManager nsmgr,
      string query,
      string name)
    {
      XPathNavigator xpathNavigator = navigator.SelectSingleNode(query, (IXmlNamespaceResolver) nsmgr);
      if (xpathNavigator == null)
        return;
      xrmPolicy.PolicyElements[name] = xpathNavigator.Value;
    }

    private void ImportSecurityPolicy(
      MetadataImporter metadataImporter,
      PolicyConversionContext context)
    {
            bool flag = true;
            MyCrmConnector.Client.AuthenticationPolicy authenticationPolicy = context.BindingElements.Find<MyCrmConnector.Client.AuthenticationPolicy>();
            AuthenticationProviderType result;
            if (authenticationPolicy != null && authenticationPolicy.PolicyElements.ContainsKey("AuthenticationType") && Enum.TryParse<AuthenticationProviderType>(authenticationPolicy.PolicyElements["AuthenticationType"], out result))
                flag = result != AuthenticationProviderType.OnlineFederation && result != AuthenticationProviderType.LiveId;
            if (this._importer == null)
                return;
            if (flag)
                this._importer.ImportPolicy(metadataImporter, context);
            else
                this.ImportSecurityPolicyWithoutMetadata(metadataImporter, context);
            //throw new NotImplementedException(); 
    }

    private void ImportSecurityPolicyWithoutMetadata(
      MetadataImporter metadataImporter,
      PolicyConversionContext context)
    {
      AuthenticationPolicyImporter.RemoveIssuerMetadataForOnline(context);
      MetadataExchangeClient metadataExchangeClient = new MetadataExchangeClient(new EndpointAddress(new Uri("http://schemas.xmlsoap.org/ws/2005/05/identity/issuer/self"), Array.Empty<AddressHeader>()));
      metadataExchangeClient.ResolveMetadataReferences = false;
      lock (this._lockObject)
      {
        try
        {
          if (metadataImporter.State != null)
            metadataImporter.State[(object) "MetadataExchangeClientKey"] = (object) metadataExchangeClient;
          this._importer.ImportPolicy(metadataImporter, context);
        }
        finally
        {
          if (metadataImporter.State != null)
            metadataImporter.State.Remove((object) "MetadataExchangeClientKey");
        }
      }
    }

    private static void RemoveIssuerMetadataForOnline(PolicyConversionContext context)
    {
      XmlElement xmlElement1 = context.GetBindingAssertions().Find("SignedSupportingTokens", "http://docs.oasis-open.org/ws-sx/ws-securitypolicy/200702");
      if (xmlElement1 == null)
        return;
      XmlElement xmlElement2 = xmlElement1["Policy", "http://schemas.xmlsoap.org/ws/2004/09/policy"];
      if (xmlElement2 == null)
        return;
      XmlElement xmlElement3 = xmlElement2["IssuedToken", "http://docs.oasis-open.org/ws-sx/ws-securitypolicy/200702"];
      if (xmlElement3 == null)
        return;
      XmlElement xmlElement4 = xmlElement3["Issuer", "http://docs.oasis-open.org/ws-sx/ws-securitypolicy/200702"];
      if (xmlElement4 == null)
        return;
      XmlElement xmlElement5 = xmlElement4["Metadata", "http://www.w3.org/2005/08/addressing"];
      if (xmlElement5 != null)
        xmlElement5.InnerText = string.Empty;
      XmlElement xmlElement6 = xmlElement4["Address", "http://www.w3.org/2005/08/addressing"];
      if (xmlElement6 == null)
        return;
      xmlElement6.InnerText = "urn://none";
    }
  }
}
