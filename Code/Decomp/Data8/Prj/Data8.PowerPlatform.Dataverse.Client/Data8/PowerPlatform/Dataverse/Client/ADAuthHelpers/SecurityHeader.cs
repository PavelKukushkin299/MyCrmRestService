// Decompiled with JetBrains decompiler
// Type: Data8.PowerPlatform.Dataverse.Client.ADAuthHelpers.SecurityHeader
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.ServiceModel.Channels;
using System.Xml;

namespace Data8.PowerPlatform.Dataverse.Client.ADAuthHelpers
{
  internal class SecurityHeader : MessageHeader
  {
    private readonly SecurityContextToken _securityContextToken;
    private readonly byte[] _proofToken;

    public SecurityHeader(SecurityContextToken securityContextToken, byte[] proofToken)
    {
      this._securityContextToken = securityContextToken;
      this._proofToken = proofToken;
    }

    public override string Name => "Security";

    public override string Namespace => "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";

    protected override void OnWriteStartHeader(
      XmlDictionaryWriter writer,
      MessageVersion messageVersion)
    {
      writer.WriteStartElement("o", this.Name, this.Namespace);
      writer.WriteAttributeString("s", "mustUnderstand", "http://www.w3.org/2003/05/soap-envelope", "1");
    }

    public override bool MustUnderstand => true;

    protected override void OnWriteHeaderContents(
      XmlDictionaryWriter writer,
      MessageVersion messageVersion)
    {
      XmlDocument xmlDoc1 = new XmlDocument();
      xmlDoc1.PreserveWhitespace = false;
      XmlElement element1 = xmlDoc1.CreateElement("u", "Timestamp", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
      element1.SetAttribute("u:Id", "_0");
      xmlDoc1.AppendChild((XmlNode) element1);
      XmlElement element2 = xmlDoc1.CreateElement("u", "Created", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
      element1.AppendChild((XmlNode) element2);
      element2.AppendChild((XmlNode) xmlDoc1.CreateTextNode(DateTime.UtcNow.ToString("s") + ".000Z"));
      XmlElement element3 = xmlDoc1.CreateElement("u", "Expires", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
      element1.AppendChild((XmlNode) element3);
      XmlElement xmlElement = element3;
      XmlDocument xmlDocument = xmlDoc1;
      DateTime dateTime = DateTime.UtcNow;
      dateTime = dateTime.AddMinutes(5.0);
      string text = dateTime.ToString("s") + ".000Z";
      XmlText textNode = xmlDocument.CreateTextNode(text);
      xmlElement.AppendChild((XmlNode) textNode);
      writer.WriteStartElement("u", "Timestamp", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
      writer.WriteAttributeString("u", "Id", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd", "_0");
      writer.WriteStartElement("u", "Created", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
      writer.WriteString(element2.FirstChild.Value);
      writer.WriteEndElement();
      writer.WriteStartElement("u", "Expires", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
      writer.WriteString(element3.FirstChild.Value);
      writer.WriteEndElement();
      writer.WriteEndElement();
      writer.WriteStartElement("c", "SecurityContextToken", "http://schemas.xmlsoap.org/ws/2005/02/sc");
      writer.WriteAttributeString("u", "Id", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd", this._securityContextToken.Id);
      writer.WriteStartElement("c", "Identifier", "http://schemas.xmlsoap.org/ws/2005/02/sc");
      writer.WriteString(this._securityContextToken.Identifier);
      writer.WriteEndElement();
      writer.WriteEndElement();
      byte[] digest = this.GetDigest(xmlDoc1);
      XmlDocument xmlDoc2 = new XmlDocument();
      xmlDoc2.PreserveWhitespace = false;
      XmlElement element4 = xmlDoc2.CreateElement("SignedInfo", "http://www.w3.org/2000/09/xmldsig#");
      xmlDoc2.AppendChild((XmlNode) element4);
      XmlElement element5 = xmlDoc2.CreateElement("CanonicalizationMethod", "http://www.w3.org/2000/09/xmldsig#");
      element5.SetAttribute("Algorithm", "http://www.w3.org/2001/10/xml-exc-c14n#");
      element4.AppendChild((XmlNode) element5);
      XmlElement element6 = xmlDoc2.CreateElement("SignatureMethod", "http://www.w3.org/2000/09/xmldsig#");
      element6.SetAttribute("Algorithm", "http://www.w3.org/2000/09/xmldsig#hmac-sha1");
      element4.AppendChild((XmlNode) element6);
      XmlElement element7 = xmlDoc2.CreateElement("Reference", "http://www.w3.org/2000/09/xmldsig#");
      element7.SetAttribute("URI", "#_0");
      element4.AppendChild((XmlNode) element7);
      XmlElement element8 = xmlDoc2.CreateElement("Transforms", "http://www.w3.org/2000/09/xmldsig#");
      element7.AppendChild((XmlNode) element8);
      XmlElement element9 = xmlDoc2.CreateElement("Transform", "http://www.w3.org/2000/09/xmldsig#");
      element9.SetAttribute("Algorithm", "http://www.w3.org/2001/10/xml-exc-c14n#");
      element8.AppendChild((XmlNode) element9);
      XmlElement element10 = xmlDoc2.CreateElement("DigestMethod", "http://www.w3.org/2000/09/xmldsig#");
      element10.SetAttribute("Algorithm", "http://www.w3.org/2000/09/xmldsig#sha1");
      element7.AppendChild((XmlNode) element10);
      XmlElement element11 = xmlDoc2.CreateElement("DigestValue", "http://www.w3.org/2000/09/xmldsig#");
      element7.AppendChild((XmlNode) element11);
      element11.AppendChild((XmlNode) xmlDoc2.CreateTextNode(Convert.ToBase64String(digest)));
      byte[] signature = this.GetSignature(xmlDoc2, this._proofToken);
      writer.WriteStartElement((string) null, "Signature", "http://www.w3.org/2000/09/xmldsig#");
      this.CopyXmlDoc(xmlDoc2.DocumentElement, writer);
      writer.WriteStartElement("SignatureValue");
      writer.WriteString(Convert.ToBase64String(signature));
      writer.WriteEndElement();
      writer.WriteStartElement("KeyInfo");
      writer.WriteStartElement("o", "SecurityTokenReference", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
      writer.WriteStartElement("o", "Reference", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
      writer.WriteAttributeString("ValueType", "http://schemas.xmlsoap.org/ws/2005/02/sc/sct");
      writer.WriteAttributeString("URI", "#" + this._securityContextToken.Id);
      writer.WriteEndElement();
      writer.WriteEndElement();
      writer.WriteEndElement();
      writer.WriteEndElement();
    }

    private byte[] GetDigest(XmlDocument xmlDoc)
    {
      XmlDsigExcC14NTransform excC14Ntransform = new XmlDsigExcC14NTransform();
      excC14Ntransform.LoadInput((object) xmlDoc);
      return excC14Ntransform.GetDigestedOutput((HashAlgorithm) SHA1.Create());
    }

    private byte[] GetSignature(XmlDocument xmlDoc, byte[] key)
    {
      XmlDsigC14NTransform dsigC14Ntransform = new XmlDsigC14NTransform();
      dsigC14Ntransform.LoadInput((object) xmlDoc);
      return dsigC14Ntransform.GetDigestedOutput((HashAlgorithm) new HMACSHA1(key));
    }

    private void CopyXmlDoc(XmlElement element, XmlDictionaryWriter writer)
    {
      writer.WriteStartElement(element.Prefix, element.LocalName, element.NamespaceURI);
      foreach (XmlAttribute attribute in (XmlNamedNodeMap) element.Attributes)
        writer.WriteAttributeString(attribute.Prefix, attribute.LocalName, attribute.NamespaceURI, attribute.Value);
      foreach (object childNode in element.ChildNodes)
      {
        switch (childNode)
        {
          case XmlText xmlText:
            writer.WriteString(xmlText.Value);
            continue;
          case XmlElement element1:
            this.CopyXmlDoc(element1, writer);
            continue;
          default:
            throw new NotSupportedException();
        }
      }
      writer.WriteEndElement();
    }
  }
}
