// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.EntityNameAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "EntityNameAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalCollectionName = "EntityNameAttributeDefinitions", LogicalName = "EntityNameAttributeMetadata")]
  public sealed class EntityNameAttributeMetadata : EnumAttributeMetadata
  {
    public EntityNameAttributeMetadata()
      : this((string) null)
    {
    }

    public EntityNameAttributeMetadata(string schemaName)
      : base(AttributeTypeCode.EntityName, schemaName)
    {
    }

    [DataMember(Order = 90)]
    public bool IsEntityReferenceStored { get; internal set; }
  }
}
