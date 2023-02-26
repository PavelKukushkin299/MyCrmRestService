// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.ManagedPropertyAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "ManagedPropertyAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalCollectionName = "ManagedPropertyAttributeDefinitions", LogicalName = "ManagedPropertyAttributeMetadata")]
  public sealed class ManagedPropertyAttributeMetadata : AttributeMetadata
  {
    public const int EmptyParentComponentType = 0;
    private string _managedPropertyLogicalName;
    private int? _parentComponentType;
    private string _parentAttributeName;
    private AttributeTypeCode _typeCode;

    public ManagedPropertyAttributeMetadata()
      : this((string) null)
    {
    }

    public ManagedPropertyAttributeMetadata(string schemaName)
      : base(AttributeTypeCode.ManagedProperty, schemaName)
    {
    }

    [DataMember]
    public string ManagedPropertyLogicalName
    {
      get => this._managedPropertyLogicalName;
      internal set => this._managedPropertyLogicalName = value;
    }

    [DataMember]
    public int? ParentComponentType
    {
      get => this._parentComponentType;
      internal set => this._parentComponentType = value;
    }

    [DataMember]
    public string ParentAttributeName
    {
      get => this._parentAttributeName;
      internal set => this._parentAttributeName = value;
    }

    [DataMember]
    public AttributeTypeCode ValueAttributeTypeCode
    {
      get => this._typeCode;
      internal set => this._typeCode = value;
    }
  }
}
