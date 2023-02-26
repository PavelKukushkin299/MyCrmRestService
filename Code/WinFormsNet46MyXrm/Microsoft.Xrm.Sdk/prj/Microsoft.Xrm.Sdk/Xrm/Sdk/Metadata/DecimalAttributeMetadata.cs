// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.DecimalAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "DecimalAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalCollectionName = "DecimalAttributeMetadataDefinitions", LogicalName = "DecimalAttributeMetadata")]
  public sealed class DecimalAttributeMetadata : AttributeMetadata
  {
    public const double MinSupportedValue = -100000000000.0;
    public const double MaxSupportedValue = 100000000000.0;
    public const int MinSupportedPrecision = 0;
    public const int MaxSupportedPrecision = 10;

    public DecimalAttributeMetadata()
      : this((string) null)
    {
    }

    public DecimalAttributeMetadata(string schemaName)
      : base(AttributeTypeCode.Decimal, schemaName)
    {
    }

    [DataMember]
    public Decimal? MaxValue { get; set; }

    [DataMember]
    public Decimal? MinValue { get; set; }

    [DataMember]
    public int? Precision { get; set; }

    [DataMember]
    public Microsoft.Xrm.Sdk.Metadata.ImeMode? ImeMode { get; set; }

    [DataMember(Order = 70)]
    public string FormulaDefinition { get; set; }

    [DataMember(Order = 70)]
    public int? SourceTypeMask { get; internal set; }
  }
}
