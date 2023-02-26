// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.OneToManyRelationshipMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "OneToManyRelationshipMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalCollectionName = "OneToManyRelationshipDefinitions", LogicalName = "OneToManyRelationshipMetadata")]
  public sealed class OneToManyRelationshipMetadata : RelationshipMetadataBase
  {
    private AssociatedMenuConfiguration _associatedMenuConfiguration;
    private CascadeConfiguration _cascadeConfiguration;
    private string _referencedAttribute;
    private string _referencedEntity;
    private string _referencedEntityNavigationPropertyName;
    private string _referencingAttribute;
    private string _referencingEntity;
    private string _referencingEntityNavigationPropertyName;
    private bool? _isHierarchical;
    private int? _relationshipBehavior;

    public OneToManyRelationshipMetadata()
      : base(RelationshipType.OneToManyRelationship)
    {
    }

    [DataMember]
    public AssociatedMenuConfiguration AssociatedMenuConfiguration
    {
      get => this._associatedMenuConfiguration;
      set => this._associatedMenuConfiguration = value;
    }

    [DataMember]
    public CascadeConfiguration CascadeConfiguration
    {
      get => this._cascadeConfiguration;
      set => this._cascadeConfiguration = value;
    }

    [DataMember]
    public string ReferencedAttribute
    {
      get => this._referencedAttribute;
      set => this._referencedAttribute = value;
    }

    [DataMember]
    public string ReferencedEntity
    {
      get => this._referencedEntity;
      set => this._referencedEntity = value;
    }

    [DataMember]
    public string ReferencingAttribute
    {
      get => this._referencingAttribute;
      set => this._referencingAttribute = value;
    }

    [DataMember]
    public string ReferencingEntity
    {
      get => this._referencingEntity;
      set => this._referencingEntity = value;
    }

    [DataMember]
    public bool? IsHierarchical
    {
      get => this._isHierarchical;
      set => this._isHierarchical = value;
    }

    [DataMember]
    public string ReferencedEntityNavigationPropertyName
    {
      get => this._referencedEntityNavigationPropertyName;
      set => this._referencedEntityNavigationPropertyName = value;
    }

    [DataMember]
    public string ReferencingEntityNavigationPropertyName
    {
      get => this._referencingEntityNavigationPropertyName;
      set => this._referencingEntityNavigationPropertyName = value;
    }

    [DataMember]
    public int? RelationshipBehavior
    {
      get => this._relationshipBehavior;
      set => this._relationshipBehavior = value;
    }
  }
}
