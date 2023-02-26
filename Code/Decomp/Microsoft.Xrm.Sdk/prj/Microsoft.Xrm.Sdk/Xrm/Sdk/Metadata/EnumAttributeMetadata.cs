// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.EnumAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [KnownType(typeof (MultiSelectPicklistAttributeMetadata))]
  [KnownType(typeof (EntityNameAttributeMetadata))]
  [KnownType(typeof (PicklistAttributeMetadata))]
  [KnownType(typeof (StateAttributeMetadata))]
  [KnownType(typeof (StatusAttributeMetadata))]
  [DataContract(Name = "EnumAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalCollectionName = "EnumAttributeDefinitions", LogicalName = "EnumAttributeMetadata")]
  public abstract class EnumAttributeMetadata : AttributeMetadata
  {
    private OptionSetMetadata _optionSetMetadata;
    private int? _defaultValue;

    protected EnumAttributeMetadata()
    {
    }

    protected EnumAttributeMetadata(AttributeTypeCode attributeType, string schemaName)
      : base(attributeType, schemaName)
    {
    }

    [DataMember]
    public int? DefaultFormValue
    {
      get => this._defaultValue;
      set => this._defaultValue = value;
    }

    [DataMember]
    public OptionSetMetadata OptionSet
    {
      get => this._optionSetMetadata;
      set => this._optionSetMetadata = value;
    }

    [DataMember(Order = 91)]
    internal string ParentEnumAttributeLogicalName { get; set; }
  }
}
