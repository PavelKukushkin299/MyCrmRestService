// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.IntegerAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "IntegerAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalCollectionName = "IntegerAttributeDefinitions", LogicalName = "IntegerAttributeMetadata")]
  public sealed class IntegerAttributeMetadata : AttributeMetadata
  {
    public const int MinSupportedValue = -2147483648;
    public const int MaxSupportedValue = 2147483647;

    public IntegerAttributeMetadata()
      : this((string) null)
    {
    }

    public IntegerAttributeMetadata(string schemaName)
      : base(AttributeTypeCode.Integer, schemaName)
    {
    }

    [DataMember]
    public IntegerFormat? Format { get; set; }

    [DataMember]
    public int? MaxValue { get; set; }

    [DataMember]
    public int? MinValue { get; set; }

    [DataMember(Order = 70)]
    public string FormulaDefinition { get; set; }

    [DataMember(Order = 70)]
    public int? SourceTypeMask { get; internal set; }
  }
}
