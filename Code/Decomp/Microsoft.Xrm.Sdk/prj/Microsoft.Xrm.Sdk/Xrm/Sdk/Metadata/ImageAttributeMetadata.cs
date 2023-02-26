// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.ImageAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "ImageAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2013/Metadata")]
  [MetadataName(LogicalCollectionName = "ImageAttributeDefinitions", LogicalName = "ImageAttributeMetadata")]
  public sealed class ImageAttributeMetadata : AttributeMetadata
  {
    private bool? _isPrimaryImageAttribute;
    private short? _maxHeight;
    private short? _maxWidth;

    public ImageAttributeMetadata()
      : this((string) null)
    {
    }

    public ImageAttributeMetadata(string schemaName)
    {
      this.AttributeType = new AttributeTypeCode?(AttributeTypeCode.Virtual);
      this.AttributeTypeName = AttributeTypeDisplayName.ImageType;
      this.SchemaName = schemaName;
    }

    [DataMember]
    public bool? IsPrimaryImage
    {
      get => this._isPrimaryImageAttribute;
      set => this._isPrimaryImageAttribute = value;
    }

    [DataMember]
    public short? MaxHeight
    {
      get => this._maxHeight;
      internal set => this._maxHeight = value;
    }

    [DataMember]
    public short? MaxWidth
    {
      get => this._maxWidth;
      internal set => this._maxWidth = value;
    }

    [DataMember]
    public int? MaxSizeInKB { get; set; }

    [DataMember]
    public bool? CanStoreFullImage { get; set; }
  }
}
