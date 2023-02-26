// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.ServiceEndpointDictionary
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel.Description;

namespace Microsoft.Xrm.Sdk.Client
{
  [Serializable]
  public sealed class ServiceEndpointDictionary : Dictionary<string, ServiceEndpoint>
  {
    public ServiceEndpointDictionary()
    {
    }

    private ServiceEndpointDictionary(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}
