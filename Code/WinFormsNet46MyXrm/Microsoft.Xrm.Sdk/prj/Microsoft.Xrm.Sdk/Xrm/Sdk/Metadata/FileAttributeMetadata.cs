// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.FileAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "FileAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/9.0/Metadata")]
  [MetadataName(LogicalCollectionName = "FileAttributeDefinitions", LogicalName = "FileAttributeMetadata")]
  public sealed class FileAttributeMetadata : AttributeMetadata
  {
    public FileAttributeMetadata()
      : this((string) null)
    {
    }

    public FileAttributeMetadata(string schemaName)
    {
      this.AttributeType = new AttributeTypeCode?(AttributeTypeCode.Virtual);
      this.AttributeTypeName = AttributeTypeDisplayName.FileType;
      this.IsValidForUpdate = new bool?(false);
      this.IsValidForCreate = new bool?(false);
      this.RequiredLevel = new AttributeRequiredLevelManagedProperty(AttributeRequiredLevel.None);
      this.SchemaName = schemaName;
    }

    [DataMember]
    public int? MaxSizeInKB { get; set; }
  }
}
