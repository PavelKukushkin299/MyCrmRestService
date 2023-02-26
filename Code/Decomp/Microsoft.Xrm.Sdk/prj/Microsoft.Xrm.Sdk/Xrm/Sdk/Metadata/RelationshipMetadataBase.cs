// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.RelationshipMetadataBase
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "RelationshipMetadataBase", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [KnownType(typeof (OneToManyRelationshipMetadata))]
  [KnownType(typeof (ManyToManyRelationshipMetadata))]
  [MetadataName(LogicalCollectionName = "RelationshipDefinitions", LogicalName = "RelationshipMetadataBase")]
  public abstract class RelationshipMetadataBase : MetadataBase
  {
    private bool? _isCustomRelationship;
    private bool? _isValidForAdvancedFind;
    private string _schemaName;
    private Microsoft.Xrm.Sdk.Metadata.SecurityTypes? _securityTypes;
    private bool? _isManaged;
    private BooleanManagedProperty _isCustomizable;
    private RelationshipType _type;
    private string _introducedVersion;

    protected RelationshipMetadataBase()
    {
    }

    protected RelationshipMetadataBase(RelationshipType type) => this._type = type;

    [DataMember]
    public bool? IsCustomRelationship
    {
      get => this._isCustomRelationship;
      set => this._isCustomRelationship = value;
    }

    [DataMember]
    public BooleanManagedProperty IsCustomizable
    {
      get => this._isCustomizable;
      set => this._isCustomizable = value;
    }

    [DataMember]
    public bool? IsValidForAdvancedFind
    {
      get => this._isValidForAdvancedFind;
      set => this._isValidForAdvancedFind = value;
    }

    [DataMember]
    [Alternatekey]
    public string SchemaName
    {
      get => this._schemaName;
      set => this._schemaName = value;
    }

    [DataMember]
    public Microsoft.Xrm.Sdk.Metadata.SecurityTypes? SecurityTypes
    {
      get => this._securityTypes;
      set => this._securityTypes = value;
    }

    [DataMember]
    public bool? IsManaged
    {
      get => this._isManaged;
      internal set => this._isManaged = value;
    }

    [DataMember(Order = 60)]
    public RelationshipType RelationshipType
    {
      get => this._type;
      internal set => this._type = value;
    }

    [DataMember(Order = 60)]
    public string IntroducedVersion
    {
      get => this._introducedVersion;
      internal set => this._introducedVersion = value;
    }
  }
}
