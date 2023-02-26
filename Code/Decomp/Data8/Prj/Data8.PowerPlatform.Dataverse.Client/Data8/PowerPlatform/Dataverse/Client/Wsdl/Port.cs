// Decompiled with JetBrains decompiler
// Type: Data8.PowerPlatform.Dataverse.Client.Wsdl.Port
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System.Xml.Serialization;

namespace Data8.PowerPlatform.Dataverse.Client.Wsdl
{
  public class Port
  {
    [XmlAttribute("binding")]
    public string Binding { get; set; }

    [XmlElement("address", Namespace = "http://schemas.xmlsoap.org/wsdl/soap12/")]
    public SoapAddress Address { get; set; }

    [XmlElement("EndpointReference", Namespace = "http://www.w3.org/2005/08/addressing")]
    public EndpointReference EndpointReference { get; set; }
  }
}
