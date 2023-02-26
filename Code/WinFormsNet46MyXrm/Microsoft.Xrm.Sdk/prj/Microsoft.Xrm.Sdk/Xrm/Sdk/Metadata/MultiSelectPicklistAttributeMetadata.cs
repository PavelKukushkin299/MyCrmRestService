// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.MultiSelectPicklistAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "MultiSelectPicklistAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/9.0/Metadata")]
  [MetadataName(LogicalCollectionName = "MultiSelectPicklistAttributeDefinitions", LogicalName = "MultiSelectPicklistAttributeMetadata")]
  public sealed class MultiSelectPicklistAttributeMetadata : EnumAttributeMetadata
  {
    public MultiSelectPicklistAttributeMetadata()
      : this((string) null)
    {
    }

    public MultiSelectPicklistAttributeMetadata(string schemaName)
    {
      this.AttributeType = new AttributeTypeCode?(AttributeTypeCode.Virtual);
      this.AttributeTypeName = AttributeTypeDisplayName.MultiSelectPicklistType;
      this.SchemaName = schemaName;
    }

    [DataMember]
    public string FormulaDefinition { get; set; }

    [DataMember]
    public int? SourceTypeMask { get; internal set; }

    [DataMember(Order = 91)]
    public string ParentPicklistLogicalName
    {
      get => this.ParentEnumAttributeLogicalName;
      set => this.ParentEnumAttributeLogicalName = value;
    }

    [DataMember(Order = 91)]
    public List<string> ChildPicklistLogicalNames { get; internal set; }
  }
}
