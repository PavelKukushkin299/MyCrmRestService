// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.CascadeConfiguration
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "CascadeConfiguration", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  public sealed class CascadeConfiguration : IExtensibleDataObject
  {
    private CascadeType? _cascadeAssign;
    private CascadeType? _cascadeDelete;
    private CascadeType? _cascadeMerge;
    private CascadeType? _cascadeReparent;
    private CascadeType? _cascadeShare;
    private CascadeType? _cascadeUnshare;
    private CascadeType? _cascadeRollupView;
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public CascadeType? Assign
    {
      get => this._cascadeAssign;
      set => this._cascadeAssign = value;
    }

    [DataMember]
    public CascadeType? Delete
    {
      get => this._cascadeDelete;
      set => this._cascadeDelete = value;
    }

    [DataMember]
    public CascadeType? Merge
    {
      get => this._cascadeMerge;
      set => this._cascadeMerge = value;
    }

    [DataMember]
    public CascadeType? Reparent
    {
      get => this._cascadeReparent;
      set => this._cascadeReparent = value;
    }

    [DataMember]
    public CascadeType? Share
    {
      get => this._cascadeShare;
      set => this._cascadeShare = value;
    }

    [DataMember]
    public CascadeType? Unshare
    {
      get => this._cascadeUnshare;
      set => this._cascadeUnshare = value;
    }

    [DataMember(Order = 82)]
    public CascadeType? RollupView
    {
      get => this._cascadeRollupView;
      set => this._cascadeRollupView = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
