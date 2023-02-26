// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.DiscoveryServiceFault
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "DiscoveryServiceFault", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  [Serializable]
  public sealed class DiscoveryServiceFault : BaseServiceFault
  {
    private DiscoveryServiceFault _innerFault;

    [DataMember]
    public DiscoveryServiceFault InnerFault
    {
      get => this._innerFault;
      set => this._innerFault = value;
    }

    [IgnoreDataMember]
    internal override BaseServiceFault InnerServiceFault
    {
      get => (BaseServiceFault) this._innerFault;
      set => this._innerFault = (DiscoveryServiceFault) value;
    }
  }
}
