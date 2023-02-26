// Decompiled with JetBrains decompiler
// Type: Data8.PowerPlatform.Dataverse.Client.ADAuthHelpers.RequestSecurityTokenResponse
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System;
using System.Xml;

namespace Data8.PowerPlatform.Dataverse.Client.ADAuthHelpers
{
  internal class RequestSecurityTokenResponse : BaseAuthRequest
  {
    public RequestSecurityTokenResponse(string context, byte[] token)
    {
      if (string.IsNullOrEmpty(context))
        throw new ArgumentNullException(nameof (context));
      if (token == null)
        throw new ArgumentNullException(nameof (token));
      this.Context = context;
      this.BinaryExchange = new BinaryExchange(token);
    }

    private RequestSecurityTokenResponse()
    {
    }

    protected override string Action => "http://schemas.xmlsoap.org/ws/2005/02/trust/RSTR/Issue";

    public string Context { get; private set; }

    public string TokenType { get; private set; }

    public SecurityContextToken RequestedSecurityToken { get; private set; }

    public SecurityTokenReference RequestedAttachedReference { get; private set; }

    public SecurityTokenReference RequestedUnattachedReference { get; private set; }

    public EncryptedKey RequestedProofToken { get; private set; }

    public Lifetime Lifetime { get; private set; }

    public int? KeySize { get; private set; }

    public BinaryExchange BinaryExchange { get; private set; }

    public CombinedHash Authenticator { get; private set; }

    protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
    {
      writer.WriteStartElement("t", nameof (RequestSecurityTokenResponse), "http://schemas.xmlsoap.org/ws/2005/02/trust");
      writer.WriteAttributeString("Context", this.Context);
      this.BinaryExchange.WriteBodyContents(writer);
      writer.WriteEndElement();
    }

    public static RequestSecurityTokenResponse Read(
      XmlDictionaryReader reader,
      Data8.PowerPlatform.Dataverse.Client.ADAuthHelpers.Authenticator auth,
      bool isFinal)
    {
      if (reader.LocalName != nameof (RequestSecurityTokenResponse) || reader.NamespaceURI != "http://schemas.xmlsoap.org/ws/2005/02/trust")
        throw new InvalidOperationException();
      if (auth != null)
      {
        XmlReader reader1 = reader.ReadSubtree();
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(reader1);
        reader.ReadEndElement();
        if (isFinal)
        {
          XmlDocument xmlDoc = (XmlDocument) xmlDocument.Clone();
          XmlNode oldChild1 = xmlDoc.SelectSingleNode("//*[local-name()='RequestedSecurityToken']");
          XmlNode oldChild2 = xmlDoc.SelectSingleNode("//*[local-name()='RequestedProofToken']");
          oldChild1.ParentNode.RemoveChild(oldChild1);
          oldChild2.ParentNode.RemoveChild(oldChild2);
          auth.AddToDigest(xmlDoc);
        }
        else
          auth.AddToDigest(xmlDocument);
        reader = XmlDictionaryReader.CreateDictionaryReader((XmlReader) new XmlNodeReader((XmlNode) xmlDocument));
        int content = (int) reader.MoveToContent();
      }
      RequestSecurityTokenResponse securityTokenResponse = new RequestSecurityTokenResponse();
      securityTokenResponse.Context = reader.GetAttribute("Context");
      reader.ReadStartElement(nameof (RequestSecurityTokenResponse), "http://schemas.xmlsoap.org/ws/2005/02/trust");
      while (reader.NodeType == XmlNodeType.Element)
      {
        if (reader.NamespaceURI != "http://schemas.xmlsoap.org/ws/2005/02/trust")
        {
          reader.ReadSubtree();
        }
        else
        {
          switch (reader.LocalName)
          {
            case "Authenticator":
              reader.ReadStartElement();
              securityTokenResponse.Authenticator = CombinedHash.Read(reader);
              reader.ReadEndElement();
              continue;
            case "BinaryExchange":
              securityTokenResponse.BinaryExchange = BinaryExchange.Read(reader);
              continue;
            case "KeySize":
              reader.ReadStartElement();
              securityTokenResponse.KeySize = new int?(reader.ReadContentAsInt());
              reader.ReadEndElement();
              continue;
            case "Lifetime":
              reader.ReadStartElement();
              securityTokenResponse.Lifetime = Lifetime.Read(reader);
              reader.ReadEndElement();
              continue;
            case "RequestedAttachedReference":
              reader.ReadStartElement();
              securityTokenResponse.RequestedAttachedReference = SecurityTokenReference.Read(reader);
              reader.ReadEndElement();
              continue;
            case "RequestedProofToken":
              reader.ReadStartElement();
              securityTokenResponse.RequestedProofToken = EncryptedKey.Read(reader);
              reader.ReadEndElement();
              continue;
            case "RequestedSecurityToken":
              reader.ReadStartElement();
              securityTokenResponse.RequestedSecurityToken = SecurityContextToken.Read(reader);
              reader.ReadEndElement();
              continue;
            case "RequestedUnattachedReference":
              reader.ReadStartElement();
              securityTokenResponse.RequestedUnattachedReference = SecurityTokenReference.Read(reader);
              reader.ReadEndElement();
              continue;
            case "TokenType":
              reader.ReadStartElement();
              securityTokenResponse.TokenType = reader.ReadString();
              reader.ReadEndElement();
              continue;
            default:
              reader.ReadSubtree();
              continue;
          }
        }
      }
      reader.ReadEndElement();
      return securityTokenResponse;
    }
  }
}
