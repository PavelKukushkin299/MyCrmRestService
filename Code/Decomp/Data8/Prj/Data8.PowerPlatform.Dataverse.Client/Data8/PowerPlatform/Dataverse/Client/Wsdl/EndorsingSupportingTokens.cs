// Decompiled with JetBrains decompiler
// Type: Data8.PowerPlatform.Dataverse.Client.Wsdl.EndorsingSupportingTokens
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System.Xml.Serialization;

namespace Data8.PowerPlatform.Dataverse.Client.Wsdl
{
  public class EndorsingSupportingTokens : PolicyItem
  {
    [XmlElement("Policy", Namespace = "http://schemas.xmlsoap.org/ws/2004/09/policy")]
    public Policy Policy { get; set; }
  }
}
