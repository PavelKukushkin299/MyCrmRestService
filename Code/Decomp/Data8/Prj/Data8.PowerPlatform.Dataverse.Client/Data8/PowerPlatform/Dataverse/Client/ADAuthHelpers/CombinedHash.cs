// Decompiled with JetBrains decompiler
// Type: Data8.PowerPlatform.Dataverse.Client.ADAuthHelpers.CombinedHash
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System;
using System.Xml;

namespace Data8.PowerPlatform.Dataverse.Client.ADAuthHelpers
{
  internal class CombinedHash
  {
    private CombinedHash(byte[] token) => this.Token = token;

    public byte[] Token { get; private set; }

    public static CombinedHash Read(XmlDictionaryReader reader)
    {
      reader.ReadStartElement(nameof (CombinedHash), "http://schemas.xmlsoap.org/ws/2005/02/trust");
      string s = reader.ReadString();
      reader.ReadEndElement();
      return new CombinedHash(Convert.FromBase64String(s));
    }
  }
}
