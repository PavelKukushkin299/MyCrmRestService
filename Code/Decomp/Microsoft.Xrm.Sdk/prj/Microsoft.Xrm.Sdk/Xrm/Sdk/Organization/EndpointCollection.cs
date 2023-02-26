// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Organization.EndpointCollection
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Organization
{
  [CollectionDataContract(Name = "EndpointCollection", Namespace = "http://schemas.microsoft.com/xrm/2014/Contracts")]
  public sealed class EndpointCollection : DataCollection<EndpointType, string>
  {
    public static EndpointCollection FromDiscovery(Microsoft.Xrm.Sdk.Discovery.EndpointCollection collection)
    {
      EndpointCollection endpointCollection = new EndpointCollection();
      foreach (KeyValuePair<Microsoft.Xrm.Sdk.Discovery.EndpointType, string> keyValuePair in (DataCollection<Microsoft.Xrm.Sdk.Discovery.EndpointType, string>) collection)
        endpointCollection.Add((EndpointType) keyValuePair.Key, keyValuePair.Value);
      return endpointCollection;
    }
  }
}
