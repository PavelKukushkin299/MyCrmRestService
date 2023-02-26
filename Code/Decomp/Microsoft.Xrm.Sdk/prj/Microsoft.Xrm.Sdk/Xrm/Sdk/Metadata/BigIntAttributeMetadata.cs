// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.BigIntAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "BigIntAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalCollectionName = "BigIntAttributeDefinitions", LogicalName = "BigIntAttributeMetadata")]
  public sealed class BigIntAttributeMetadata : AttributeMetadata
  {
    public const long MinSupportedValue = -9223372036854775808;
    public const long MaxSupportedValue = 9223372036854775807;
    private long? _maxValue;
    private long? _minValue;

    public BigIntAttributeMetadata()
      : this((string) null)
    {
    }

    public BigIntAttributeMetadata(string schemaName)
      : base(AttributeTypeCode.BigInt, schemaName)
    {
    }

    [DataMember]
    public long? MaxValue
    {
      get => this._maxValue;
      internal set => this._maxValue = value;
    }

    [DataMember]
    public long? MinValue
    {
      get => this._minValue;
      internal set => this._minValue = value;
    }
  }
}
