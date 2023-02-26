// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.ManyToManyRelationshipMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "ManyToManyRelationshipMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalCollectionName = "ManyToManyRelationshipDefinitions", LogicalName = "ManyToManyRelationshipMetadata")]
  public sealed class ManyToManyRelationshipMetadata : RelationshipMetadataBase
  {
    private AssociatedMenuConfiguration _entity1AssociatedMenuConfiguration;
    private AssociatedMenuConfiguration _entity2AssociatedMenuConfiguration;
    private string _entity1LogicalName;
    private string _entity2LogicalName;
    private string _intersectEntityName;
    private string _entity1IntersectAttribute;
    private string _entity2IntersectAttribute;
    private string _entity1NavigationPropertyName;
    private string _entity2NavigationPropertyName;

    public ManyToManyRelationshipMetadata()
      : base(RelationshipType.ManyToManyRelationship)
    {
    }

    [DataMember]
    public AssociatedMenuConfiguration Entity1AssociatedMenuConfiguration
    {
      get => this._entity1AssociatedMenuConfiguration;
      set => this._entity1AssociatedMenuConfiguration = value;
    }

    [DataMember]
    public AssociatedMenuConfiguration Entity2AssociatedMenuConfiguration
    {
      get => this._entity2AssociatedMenuConfiguration;
      set => this._entity2AssociatedMenuConfiguration = value;
    }

    [DataMember]
    public string Entity1LogicalName
    {
      get => this._entity1LogicalName;
      set => this._entity1LogicalName = value;
    }

    [DataMember]
    public string Entity2LogicalName
    {
      get => this._entity2LogicalName;
      set => this._entity2LogicalName = value;
    }

    [DataMember]
    public string IntersectEntityName
    {
      get => this._intersectEntityName;
      set => this._intersectEntityName = value;
    }

    [DataMember]
    public string Entity1IntersectAttribute
    {
      get => this._entity1IntersectAttribute;
      set => this._entity1IntersectAttribute = value;
    }

    [DataMember]
    public string Entity2IntersectAttribute
    {
      get => this._entity2IntersectAttribute;
      set => this._entity2IntersectAttribute = value;
    }

    [DataMember]
    public string Entity1NavigationPropertyName
    {
      get => this._entity1NavigationPropertyName;
      set => this._entity1NavigationPropertyName = value;
    }

    [DataMember]
    public string Entity2NavigationPropertyName
    {
      get => this._entity2NavigationPropertyName;
      set => this._entity2NavigationPropertyName = value;
    }
  }
}
