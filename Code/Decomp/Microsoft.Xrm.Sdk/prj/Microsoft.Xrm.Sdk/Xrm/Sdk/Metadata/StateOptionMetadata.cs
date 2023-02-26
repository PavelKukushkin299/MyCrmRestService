// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.StateOptionMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "StateOptionMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalCollectionName = "StateOptionDefinitions", LogicalName = "StateOptionMetadata")]
  public sealed class StateOptionMetadata : OptionMetadata
  {
    private int? _defaultStatus;
    private string _invariantName;

    [DataMember]
    public int? DefaultStatus
    {
      get => this._defaultStatus;
      set => this._defaultStatus = value;
    }

    [DataMember]
    public string InvariantName
    {
      get => this._invariantName;
      set => this._invariantName = value;
    }
  }
}
