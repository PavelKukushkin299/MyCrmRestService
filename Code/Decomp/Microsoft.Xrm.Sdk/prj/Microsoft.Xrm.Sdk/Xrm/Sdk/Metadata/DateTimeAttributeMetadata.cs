// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.DateTimeAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "DateTimeAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalCollectionName = "DateTimeAttributeDefinitions", LogicalName = "DateTimeAttributeMetadata")]
  public sealed class DateTimeAttributeMetadata : AttributeMetadata
  {
    private static readonly DateTime _minDateTime = new DateTime(1753, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    private static readonly DateTime _maxDateTime = new DateTime(9999, 12, 30, 23, 59, 59, DateTimeKind.Utc);

    public DateTimeAttributeMetadata()
      : this(new DateTimeFormat?())
    {
    }

    public DateTimeAttributeMetadata(DateTimeFormat? format)
      : this(format, (string) null)
    {
    }

    public DateTimeAttributeMetadata(DateTimeFormat? format, string schemaName)
      : base(AttributeTypeCode.DateTime, schemaName)
    {
      this.Format = format;
    }

    public static DateTime MinSupportedValue => DateTimeAttributeMetadata._minDateTime;

    public static DateTime MaxSupportedValue => DateTimeAttributeMetadata._maxDateTime;

    [DataMember]
    public DateTimeFormat? Format { get; set; }

    [DataMember]
    public Microsoft.Xrm.Sdk.Metadata.ImeMode? ImeMode { get; set; }

    [DataMember(Order = 70)]
    public int? SourceTypeMask { get; internal set; }

    [DataMember(Order = 70)]
    public string FormulaDefinition { get; set; }

    [DataMember(Order = 71)]
    public DateTimeBehavior DateTimeBehavior { get; set; }

    [DataMember(Order = 71)]
    public BooleanManagedProperty CanChangeDateTimeBehavior { get; set; }
  }
}
