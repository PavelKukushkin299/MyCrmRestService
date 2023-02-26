// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.StatusOptionMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "StatusOptionMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalCollectionName = "StatusOptionDefinitions", LogicalName = "StatusOptionMetadata")]
  public sealed class StatusOptionMetadata : OptionMetadata
  {
    private int? _state;
    private string _transitionData;

    public StatusOptionMetadata()
    {
    }

    public StatusOptionMetadata(int value, int? state)
      : base(value)
    {
      this.State = state;
    }

    [DataMember]
    public int? State
    {
      get => this._state;
      set => this._state = value;
    }

    [DataMember]
    public string TransitionData
    {
      get => this._transitionData;
      set => this._transitionData = value;
    }
  }
}
