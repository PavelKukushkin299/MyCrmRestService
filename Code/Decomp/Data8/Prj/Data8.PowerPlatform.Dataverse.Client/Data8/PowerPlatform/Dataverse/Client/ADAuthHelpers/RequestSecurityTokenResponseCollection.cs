// Decompiled with JetBrains decompiler
// Type: Data8.PowerPlatform.Dataverse.Client.ADAuthHelpers.RequestSecurityTokenResponseCollection
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System.Collections.Generic;
using System.Xml;

namespace Data8.PowerPlatform.Dataverse.Client.ADAuthHelpers
{
  internal class RequestSecurityTokenResponseCollection
  {
    private RequestSecurityTokenResponseCollection(List<RequestSecurityTokenResponse> rstrs) => this.Responses = (IReadOnlyList<RequestSecurityTokenResponse>) rstrs.AsReadOnly();

    public IReadOnlyList<RequestSecurityTokenResponse> Responses { get; private set; }

    public static RequestSecurityTokenResponseCollection Read(
      XmlDictionaryReader reader,
      Authenticator auth)
    {
      List<RequestSecurityTokenResponse> rstrs = new List<RequestSecurityTokenResponse>();
      reader.ReadStartElement(nameof (RequestSecurityTokenResponseCollection), "http://schemas.xmlsoap.org/ws/2005/02/trust");
      while (reader.NodeType == XmlNodeType.Element)
        rstrs.Add(RequestSecurityTokenResponse.Read(reader, rstrs.Count == 0 ? auth : (Authenticator) null, true));
      reader.ReadEndElement();
      return new RequestSecurityTokenResponseCollection(rstrs);
    }
  }
}
