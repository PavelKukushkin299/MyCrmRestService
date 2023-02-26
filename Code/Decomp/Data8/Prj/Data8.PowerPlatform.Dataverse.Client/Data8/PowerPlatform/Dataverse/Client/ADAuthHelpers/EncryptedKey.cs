// Decompiled with JetBrains decompiler
// Type: Data8.PowerPlatform.Dataverse.Client.ADAuthHelpers.EncryptedKey
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System;
using System.Xml;

namespace Data8.PowerPlatform.Dataverse.Client.ADAuthHelpers
{
  internal class EncryptedKey
  {
    private const string GSS_WRAP = "http://schemas.xmlsoap.org/2005/02/trust/spnego#GSS_Wrap";

    private EncryptedKey()
    {
    }

    public byte[] CipherValue { get; private set; }

    public static EncryptedKey Read(XmlDictionaryReader reader)
    {
      reader.ReadStartElement(nameof (EncryptedKey), "http://www.w3.org/2001/04/xmlenc#");
      if (reader.GetAttribute("Algorithm") != "http://schemas.xmlsoap.org/2005/02/trust/spnego#GSS_Wrap")
        throw new NotSupportedException();
      reader.ReadStartElement("EncryptionMethod", "http://www.w3.org/2001/04/xmlenc#");
      reader.ReadEndElement();
      reader.ReadStartElement("CipherData", "http://www.w3.org/2001/04/xmlenc#");
      reader.ReadStartElement("CipherValue", "http://www.w3.org/2001/04/xmlenc#");
      string s = reader.ReadString();
      reader.ReadEndElement();
      reader.ReadEndElement();
      reader.ReadEndElement();
      return new EncryptedKey()
      {
        CipherValue = Convert.FromBase64String(s)
      };
    }
  }
}
