// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.DoubleAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "DoubleAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalCollectionName = "DoubleAttributeDefinitions", LogicalName = "DoubleAttributeMetadata")]
  public sealed class DoubleAttributeMetadata : AttributeMetadata
  {
    public const double MinSupportedValue = -100000000000.0;
    public const double MaxSupportedValue = 100000000000.0;
    public const int MinSupportedPrecision = 0;
    public const int MaxSupportedPrecision = 5;

    public DoubleAttributeMetadata()
      : this((string) null)
    {
    }

    public DoubleAttributeMetadata(string schemaName)
      : base(AttributeTypeCode.Double, schemaName)
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
  }
}
