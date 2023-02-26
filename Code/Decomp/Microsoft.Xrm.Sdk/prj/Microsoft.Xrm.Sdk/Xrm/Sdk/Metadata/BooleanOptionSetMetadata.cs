// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.BooleanOptionSetMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "BooleanOptionSetMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalCollectionName = "BooleanOptionSetDefinitions", LogicalName = "BooleanOptionSetMetadata")]
  public sealed class BooleanOptionSetMetadata : OptionSetMetadataBase
  {
    private OptionMetadata _trueOption;
    private OptionMetadata _falseOption;

    public BooleanOptionSetMetadata()
    {
    }

    public BooleanOptionSetMetadata(OptionMetadata trueOption, OptionMetadata falseOption)
    {
      this.TrueOption = trueOption;
      this.FalseOption = falseOption;
    }

    [DataMember]
    public OptionMetadata TrueOption
    {
      get => this._trueOption;
      set => this._trueOption = value;
    }

    [DataMember]
    public OptionMetadata FalseOption
    {
      get => this._falseOption;
      set => this._falseOption = value;
    }
  }
}
