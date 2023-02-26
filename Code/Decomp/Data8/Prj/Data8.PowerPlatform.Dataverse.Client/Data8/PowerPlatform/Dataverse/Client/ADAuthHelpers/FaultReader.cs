// Decompiled with JetBrains decompiler
// Type: Data8.PowerPlatform.Dataverse.Client.ADAuthHelpers.FaultReader
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Xml;

namespace Data8.PowerPlatform.Dataverse.Client.ADAuthHelpers
{
  internal static class FaultReader
  {
    public static Exception ReadFault(XmlDictionaryReader bodyReader, string action)
    {
      bodyReader.ReadStartElement("Fault", "http://www.w3.org/2003/05/soap-envelope");
      bodyReader.ReadStartElement("Code", "http://www.w3.org/2003/05/soap-envelope");
      bodyReader.ReadStartElement("Value", "http://www.w3.org/2003/05/soap-envelope");
      string[] strArray1 = bodyReader.ReadString().Split(':');
      string name1 = strArray1[0];
      string ns1 = "";
      if (strArray1.Length > 1)
      {
        ns1 = bodyReader.LookupNamespace(strArray1[0]);
        name1 = strArray1[1];
      }
      bodyReader.ReadEndElement();
      FaultCode subCode = (FaultCode) null;
      if (bodyReader.NodeType == XmlNodeType.Element && bodyReader.LocalName == "Subcode" && bodyReader.NamespaceURI == "http://www.w3.org/2003/05/soap-envelope")
      {
        bodyReader.ReadStartElement("Subcode", "http://www.w3.org/2003/05/soap-envelope");
        bodyReader.ReadStartElement("Value", "http://www.w3.org/2003/05/soap-envelope");
        string[] strArray2 = bodyReader.ReadString().Split(':');
        string name2 = strArray2[0];
        string ns2 = "";
        if (strArray2.Length > 1)
        {
          ns2 = bodyReader.LookupNamespace(strArray2[0]);
          name2 = strArray2[1];
        }
        bodyReader.ReadEndElement();
        bodyReader.ReadEndElement();
        subCode = new FaultCode(name2, ns2);
      }
      bodyReader.ReadEndElement();
      bodyReader.ReadStartElement("Reason", "http://www.w3.org/2003/05/soap-envelope");
      bodyReader.ReadStartElement("Text", "http://www.w3.org/2003/05/soap-envelope");
      string text = bodyReader.ReadString();
      bodyReader.ReadEndElement();
      bodyReader.ReadEndElement();
      if (bodyReader.NodeType == XmlNodeType.Element && bodyReader.LocalName == "Detail" && bodyReader.NamespaceURI == "http://www.w3.org/2003/05/soap-envelope")
      {
        bodyReader.ReadStartElement("Detail", "http://www.w3.org/2003/05/soap-envelope");
        if (bodyReader.NodeType == XmlNodeType.Element && bodyReader.LocalName == "OrganizationServiceFault" && bodyReader.NamespaceURI == "http://schemas.microsoft.com/xrm/2011/Contracts")
          return (Exception) new FaultException<OrganizationServiceFault>((OrganizationServiceFault) new DataContractSerializer(typeof (OrganizationServiceFault)).ReadObject(bodyReader), new FaultReason(text), new FaultCode(name1, ns1, subCode), action);
        bodyReader.ReadSubtree();
        bodyReader.ReadEndElement();
      }
      bodyReader.ReadEndElement();
      return (Exception) new FaultException(new FaultReason(text), new FaultCode(name1, ns1, subCode), action);
    }
  }
}
