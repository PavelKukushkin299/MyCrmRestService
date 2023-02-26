// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.CascadeSPGenerationRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract]
  public sealed class CascadeSPGenerationRequest
  {
    [DataMember]
    public bool IsBackedByXdb { get; set; }

    [DataMember]
    public ArrayList CascadingChangeList { get; set; }

    [DataMember]
    public HashSet<Guid> CascadeRollupEntities { get; set; }

    [DataMember]
    public HashSet<int> EntitiesBeingChanged { get; set; }

    [DataMember]
    public Guid RequestCorrelationId { get; set; }
  }
}
