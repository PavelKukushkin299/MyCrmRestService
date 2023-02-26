// Decompiled with JetBrains decompiler
// Type: Data8.PowerPlatform.Dataverse.Client.ADAuthHelpers.Lifetime
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System;
using System.Xml;

namespace Data8.PowerPlatform.Dataverse.Client.ADAuthHelpers
{
  internal class Lifetime
  {
    public Lifetime()
      : this(DateTime.UtcNow, DateTime.UtcNow.AddMinutes(5.0))
    {
    }

    public Lifetime(DateTime created, DateTime expires)
    {
      this.Created = created;
      this.Expires = expires;
    }

    public DateTime Created { get; private set; }

    public DateTime Expires { get; private set; }

    public static Lifetime Read(XmlDictionaryReader reader)
    {
      reader.ReadStartElement("Created", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
      DateTime created = reader.ReadContentAsDateTime();
      reader.ReadEndElement();
      reader.ReadStartElement("Expires", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
      DateTime dateTime = reader.ReadContentAsDateTime();
      reader.ReadEndElement();
      DateTime expires = dateTime;
      return new Lifetime(created, expires);
    }
  }
}
