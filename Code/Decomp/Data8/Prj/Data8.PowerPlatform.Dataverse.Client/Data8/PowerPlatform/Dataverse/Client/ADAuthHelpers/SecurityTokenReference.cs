// Decompiled with JetBrains decompiler
// Type: Data8.PowerPlatform.Dataverse.Client.ADAuthHelpers.SecurityTokenReference
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System.Xml;

namespace Data8.PowerPlatform.Dataverse.Client.ADAuthHelpers
{
  internal class SecurityTokenReference
  {
    private SecurityTokenReference()
    {
    }

    public string ValueType { get; private set; }

    public string URI { get; private set; }

    public static SecurityTokenReference Read(XmlDictionaryReader reader)
    {
      reader.ReadStartElement(nameof (SecurityTokenReference), "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
      string attribute1 = reader.GetAttribute("ValueType");
      string attribute2 = reader.GetAttribute("URI");
      reader.ReadStartElement("Reference", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
      reader.ReadEndElement();
      reader.ReadEndElement();
      return new SecurityTokenReference()
      {
        ValueType = attribute1,
        URI = attribute2
      };
    }
  }
}
