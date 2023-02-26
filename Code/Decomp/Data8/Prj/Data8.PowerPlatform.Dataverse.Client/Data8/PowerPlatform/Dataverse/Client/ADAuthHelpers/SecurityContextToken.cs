// Decompiled with JetBrains decompiler
// Type: Data8.PowerPlatform.Dataverse.Client.ADAuthHelpers.SecurityContextToken
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System.Xml;

namespace Data8.PowerPlatform.Dataverse.Client.ADAuthHelpers
{
  internal class SecurityContextToken
  {
    private SecurityContextToken()
    {
    }

    public string Id { get; private set; }

    public string Identifier { get; private set; }

    public static SecurityContextToken Read(XmlDictionaryReader reader)
    {
      string attribute = reader.GetAttribute("Id", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
      reader.ReadStartElement(nameof (SecurityContextToken), "http://schemas.xmlsoap.org/ws/2005/02/sc");
      reader.ReadStartElement("Identifier", "http://schemas.xmlsoap.org/ws/2005/02/sc");
      string str = reader.ReadString();
      reader.ReadEndElement();
      reader.ReadEndElement();
      return new SecurityContextToken()
      {
        Id = attribute,
        Identifier = str
      };
    }
  }
}
