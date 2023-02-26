// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.MoneyAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "MoneyAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalCollectionName = "MoneyAttributeDefinitions", LogicalName = "MoneyAttributeMetadata")]
  public sealed class MoneyAttributeMetadata : AttributeMetadata
  {
    public const double MinSupportedValue = -922337203685477.0;
    public const double MaxSupportedValue = 922337203685477.0;
    public const int MinSupportedPrecision = 0;
    public const int MaxSupportedPrecision = 4;
    public const int MaxSupportedPrecisionAfterCurrencyConversion = 10;

    public MoneyAttributeMetadata()
      : this((string) null)
    {
    }

    public MoneyAttributeMetadata(string schemaName)
      : base(AttributeTypeCode.Money, schemaName)
    {
    }

    [DataMember]
    public Microsoft.Xrm.Sdk.Metadata.ImeMode? ImeMode { get; set; }

    [DataMember]
    public double? MaxValue { get; set; }

    [DataMember]
    public double? MinValue { get; set; }

    [DataMember]
    public int? Precision { get; set; }

    [DataMember]
    public int? PrecisionSource { get; set; }

    [DataMember]
    public string CalculationOf { get; set; }

    [DataMember(Order = 70)]
    public string FormulaDefinition { get; set; }

    [DataMember(Order = 70)]
    public int? SourceTypeMask { get; internal set; }

    [DataMember(Order = 70)]
    public bool? IsBaseCurrency { get; internal set; }
  }
}
