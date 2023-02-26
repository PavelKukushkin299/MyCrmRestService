// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.CrossRealmIssuerEndpointCollection
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.Xrm.Sdk.Client
{
  public sealed class CrossRealmIssuerEndpointCollection : 
    DataCollection<Uri, IssuerEndpointDictionary>
  {
    public override IssuerEndpointDictionary this[Uri key]
    {
      get
      {
        if (this.ContainsKey(key))
          return base[key];
        IssuerEndpointDictionary endpointDictionary = ServiceMetadataUtility.RetrieveIssuerEndpoints(new EndpointAddress(key, Array.Empty<AddressHeader>()));
        if (endpointDictionary == null)
          return (IssuerEndpointDictionary) null;
        base[key] = endpointDictionary;
        return endpointDictionary;
      }
      set => base[key] = value;
    }
  }
}
