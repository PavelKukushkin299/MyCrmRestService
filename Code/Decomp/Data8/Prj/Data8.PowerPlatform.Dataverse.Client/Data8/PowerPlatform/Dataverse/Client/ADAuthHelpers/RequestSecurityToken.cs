// Decompiled with JetBrains decompiler
// Type: Data8.PowerPlatform.Dataverse.Client.ADAuthHelpers.RequestSecurityToken
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System;
using System.Xml;

namespace Data8.PowerPlatform.Dataverse.Client.ADAuthHelpers
{
  internal class RequestSecurityToken : BaseAuthRequest
  {
    private readonly string _context;

    public RequestSecurityToken(byte[] token)
    {
      this._context = "uuid-" + Guid.NewGuid().ToString();
      this.Token = new BinaryExchange(token);
    }

    protected override string Action => "http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue";

    public BinaryExchange Token { get; private set; }

    protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
    {
      writer.WriteStartElement("t", nameof (RequestSecurityToken), "http://schemas.xmlsoap.org/ws/2005/02/trust");
      writer.WriteAttributeString("Context", this._context);
      writer.WriteStartElement("t", "TokenType", "http://schemas.xmlsoap.org/ws/2005/02/trust");
      writer.WriteString("http://schemas.xmlsoap.org/ws/2005/02/sc/sct");
      writer.WriteEndElement();
      writer.WriteStartElement("t", "RequestType", "http://schemas.xmlsoap.org/ws/2005/02/trust");
      writer.WriteString("http://schemas.xmlsoap.org/ws/2005/02/trust/Issue");
      writer.WriteEndElement();
      writer.WriteStartElement("t", "KeySize", "http://schemas.xmlsoap.org/ws/2005/02/trust");
      writer.WriteString("256");
      writer.WriteEndElement();
      this.Token.WriteBodyContents(writer);
      writer.WriteEndElement();
    }
  }
}
