// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.BooleanAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "BooleanAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalCollectionName = "BooleanAttributeDefinitions", LogicalName = "BooleanAttributeMetadata")]
  public sealed class BooleanAttributeMetadata : AttributeMetadata
  {
    public BooleanAttributeMetadata()
      : this((string) null, (BooleanOptionSetMetadata) null)
    {
    }

    public BooleanAttributeMetadata(string schemaName)
      : this(schemaName, (BooleanOptionSetMetadata) null)
    {
    }

    public BooleanAttributeMetadata(BooleanOptionSetMetadata optionSet)
      : this((string) null, optionSet)
    {
    }

    public BooleanAttributeMetadata(string schemaName, BooleanOptionSetMetadata optionSet)
      : base(AttributeTypeCode.Boolean, schemaName)
    {
      this.OptionSet = optionSet;
    }

    [DataMember]
    public bool? DefaultValue { get; set; }

    [DataMember(Order = 70)]
    public string FormulaDefinition { get; set; }

    [DataMember(Order = 70)]
    public int? SourceTypeMask { get; internal set; }

    [DataMember]
    public BooleanOptionSetMetadata OptionSet { get; set; }
  }
}
