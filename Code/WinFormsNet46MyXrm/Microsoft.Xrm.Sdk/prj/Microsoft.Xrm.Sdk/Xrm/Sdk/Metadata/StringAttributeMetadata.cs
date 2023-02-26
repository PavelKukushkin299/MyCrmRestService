// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.StringAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "StringAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalCollectionName = "StringAttributeDefinitions", LogicalName = "StringAttributeMetadata")]
  public sealed class StringAttributeMetadata : AttributeMetadata
  {
    public const int MinSupportedLength = 1;
    public const int MaxSupportedLength = 4000;

    public StringAttributeMetadata()
      : this((string) null)
    {
    }

    public StringAttributeMetadata(string schemaName)
      : base(AttributeTypeCode.String, schemaName)
    {
    }

    [DataMember]
    public StringFormat? Format { get; set; }

    [DataMember(Order = 60)]
    public StringFormatName FormatName { get; set; }

    [DataMember]
    public Microsoft.Xrm.Sdk.Metadata.ImeMode? ImeMode { get; set; }

    [DataMember]
    public int? MaxLength { get; set; }

    [DataMember]
    public string YomiOf { get; set; }

    [DataMember(Order = 70)]
    public bool? IsLocalizable { get; internal set; }

    [DataMember(Order = 90)]
    public int? DatabaseLength { get; internal set; }

    [DataMember(Order = 70)]
    public string FormulaDefinition { get; set; }

    [DataMember(Order = 70)]
    public int? SourceTypeMask { get; internal set; }
  }
}
