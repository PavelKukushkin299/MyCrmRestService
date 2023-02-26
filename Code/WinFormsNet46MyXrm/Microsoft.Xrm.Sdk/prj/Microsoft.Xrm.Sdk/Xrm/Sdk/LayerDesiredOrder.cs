// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.LayerDesiredOrder
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "LayerDesiredOrder", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public sealed class LayerDesiredOrder : IExtensibleDataObject
  {
    private LayerDesiredOrderType _type;
    private List<SolutionInfo> _solutions;
    [NonSerialized]
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public LayerDesiredOrderType Type
    {
      get => this._type;
      set => this._type = value;
    }

    [DataMember]
    public List<SolutionInfo> Solutions
    {
      get => this._solutions;
      set => this._solutions = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
