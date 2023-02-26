// Decompiled with JetBrains decompiler
// Type: Data8.PowerPlatform.Dataverse.Client.ADAuthHelpers.BinaryExchange
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System;
using System.ServiceModel.Channels;
using System.Xml;

namespace Data8.PowerPlatform.Dataverse.Client.ADAuthHelpers
{
  internal class BinaryExchange : BodyWriter
  {
    private const string SPNEGO = "http://schemas.xmlsoap.org/ws/2005/02/trust/spnego";
    private const string BASE64 = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary";

    public BinaryExchange(byte[] token)
      : base(true)
    {
      this.Token = token != null ? token : throw new ArgumentNullException(nameof (token));
    }

    public byte[] Token { get; private set; }

    protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
    {
      writer.WriteStartElement("t", nameof (BinaryExchange), "http://schemas.xmlsoap.org/ws/2005/02/trust");
      writer.WriteAttributeString("ValueType", "http://schemas.xmlsoap.org/ws/2005/02/trust/spnego");
      writer.WriteAttributeString("EncodingType", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary");
      writer.WriteString(Convert.ToBase64String(this.Token));
      writer.WriteEndElement();
    }

    public static BinaryExchange Read(XmlDictionaryReader reader)
    {
      string attribute1 = reader.GetAttribute("ValueType");
      string attribute2 = reader.GetAttribute("EncodingType");
      if (attribute1 != "http://schemas.xmlsoap.org/ws/2005/02/trust/spnego" || attribute2 != "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary")
        throw new NotSupportedException();
      reader.ReadStartElement();
      string s = reader.ReadString();
      reader.ReadEndElement();
      return new BinaryExchange(Convert.FromBase64String(s));
    }
  }
}
