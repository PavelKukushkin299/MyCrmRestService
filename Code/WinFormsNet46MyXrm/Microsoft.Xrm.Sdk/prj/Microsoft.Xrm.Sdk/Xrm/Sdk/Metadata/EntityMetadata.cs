// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.EntityMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "EntityMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalCollectionName = "EntityDefinitions", LogicalName = "EntityMetadata")]
  public sealed class EntityMetadata : MetadataBase
  {
    private int? _activityTypeMask;
    private AttributeMetadata[] _attributes;
    private bool? _canTriggerWorkflow;
    private Label _description;
    private Label _displayCollectionName;
    private Label _displayName;
    private bool? _isDocumentMangementEnabled;
    private bool? _isOneNoteIntegrationEnabled;
    private bool? _isInteractionCentricEnabled;
    private bool? _isKnowledgeManagementEnabled;
    private bool? _isSLAEnabled;
    private bool? _isBpfEntity;
    private bool? _isDocumentRecommendationsEnabled;
    private bool? _isMSTeamsIntegrationEnabled;
    private string _settingOf;
    private Guid? _dataProviderId;
    private Guid? _dataSourceId;
    private bool? _isSolutionAware;
    private bool? _isActivity;
    private bool? _isActivityParty;
    private BooleanManagedProperty _isAuditEnabled;
    private bool? _isAvailableOffline;
    private bool? _isChildEntity;
    private bool? _isAIRUpdated;
    private bool? _autoCreateAccessTeams;
    private BooleanManagedProperty _isValidForQueue;
    private BooleanManagedProperty _isConnectionsEnabled;
    private string _iconLargeName;
    private string _iconMediumName;
    private string _iconSmallName;
    private string _iconVectorName;
    private bool? _isCustomEntity;
    private bool? _isBusinessProcessEnabled;
    private BooleanManagedProperty _isCustomizable;
    private BooleanManagedProperty _isRenameable;
    private BooleanManagedProperty _isMappable;
    private BooleanManagedProperty _isDuplicateDetectionEnabled;
    private bool? _isImportable;
    private bool? _isIntersect;
    private BooleanManagedProperty _isMailMergeEnabled;
    private bool? autoRouteToOwnerQueue;
    private bool? _isEnabledForCharts;
    private bool? _isEnabledForTrace;
    private bool? _isValidForAdvancedFind;
    private string _entityHelpUrl;
    private bool? _entityHelpUrlEnabled;
    private BooleanManagedProperty _isVisibleInMobile;
    private BooleanManagedProperty _isVisibleInMobileClient;
    private BooleanManagedProperty _isReadOnlyInMobileClient;
    private string _logicalName;
    private ManyToManyRelationshipMetadata[] _manyToManyRelationships;
    private OneToManyRelationshipMetadata[] _manyToOneRelationships;
    private int? _objectTypeCode;
    private OneToManyRelationshipMetadata[] _oneToManyRelationships;
    private OwnershipTypes? _ownershipType;
    private string _primaryNameAttribute;
    private string _primaryImageAttribute;
    private string _primaryIdAttribute;
    private SecurityPrivilegeMetadata[] _privileges;
    private string _recurrenceBaseEntityLogicalName;
    private string _reportViewName;
    private string _schemaName;
    private string _physicalName;
    private string _externalName;
    private int? _workflowSupport;
    private bool? _isManaged;
    private bool? _isReadingPaneEnabled;
    private bool? _isQuickCreateEnabled;
    private string _introducedVersion;
    private bool? _isStateModelAware;
    private bool? _enforceStateTransitions;
    private BooleanManagedProperty _canCreateAttributes;
    private BooleanManagedProperty _canCreateForms;
    private BooleanManagedProperty _canCreateCharts;
    private BooleanManagedProperty _canCreateViews;
    private BooleanManagedProperty _canBeRelatedEntityInRelationship;
    private BooleanManagedProperty _canBePrimaryEntityInRelationship;
    private BooleanManagedProperty _canBeInManyToMany;
    private BooleanManagedProperty _canBeInCustomEntityAssociation;
    private BooleanManagedProperty _canModifyAdditionalSettings;
    private BooleanManagedProperty _canChangeHierarchicalRelationship;
    private BooleanManagedProperty _canChangeTrackingBeEnabled;
    private BooleanManagedProperty _canEnableSyncToExternalSearchIndex;
    private bool? _syncToExternalSearchIndex;
    private bool? _changeTrackingEnabled;
    private bool? _isOptimisticConcurrencyEnabled;
    private string _entityColor;
    private EntityKeyMetadata[] _keys;
    private string _logicalCollectionName;
    private string _externalCollectionName;
    private string _collectionSchemaName;
    private BooleanManagedProperty _isOfflineInMobileClient;
    private int? _daysSinceRecordLastModified;
    private string _mobileOfflineFilters;
    private string _entitySetName;
    private bool? _isEnabledForExternalChannels;
    private bool? _isPrivate;
    private bool? _usesBusinessDataLabelTable;
    private bool? _isLogicalEntity;
    private int? _availableForRetrieve;
    private int? _availableForRetrieveMultiple;
    private int? _availableForCreate;
    private int? _availableForUpdate;
    private int? _availableForDelete;
    private bool? _hasNotes;
    private bool? _hasActivities;
    private bool? _hasFeedback;

    [DataMember]
    public int? ActivityTypeMask
    {
      get => this._activityTypeMask;
      set => this._activityTypeMask = value;
    }

    [DataMember]
    public AttributeMetadata[] Attributes
    {
      get => this._attributes;
      internal set => this._attributes = value;
    }

    [DataMember]
    public bool? AutoRouteToOwnerQueue
    {
      get => this.autoRouteToOwnerQueue;
      set => this.autoRouteToOwnerQueue = value;
    }

    [DataMember]
    public bool? CanTriggerWorkflow
    {
      get => this._canTriggerWorkflow;
      internal set => this._canTriggerWorkflow = value;
    }

    [DataMember]
    public Label Description
    {
      get => this._description;
      set => this._description = value;
    }

    [DataMember]
    public Label DisplayCollectionName
    {
      get => this._displayCollectionName;
      set => this._displayCollectionName = value;
    }

    [DataMember]
    public Label DisplayName
    {
      get => this._displayName;
      set => this._displayName = value;
    }

    [DataMember(Order = 70)]
    public bool? EntityHelpUrlEnabled
    {
      get => this._entityHelpUrlEnabled;
      set => this._entityHelpUrlEnabled = value;
    }

    [DataMember(Order = 70)]
    public string EntityHelpUrl
    {
      get => this._entityHelpUrl;
      set => this._entityHelpUrl = value;
    }

    [DataMember]
    public bool? IsDocumentManagementEnabled
    {
      get => this._isDocumentMangementEnabled;
      set => this._isDocumentMangementEnabled = value;
    }

    [DataMember]
    public bool? IsOneNoteIntegrationEnabled
    {
      get => this._isOneNoteIntegrationEnabled;
      set => this._isOneNoteIntegrationEnabled = value;
    }

    [DataMember]
    public bool? IsInteractionCentricEnabled
    {
      get => this._isInteractionCentricEnabled;
      set => this._isInteractionCentricEnabled = value;
    }

    [DataMember]
    public bool? IsKnowledgeManagementEnabled
    {
      get => this._isKnowledgeManagementEnabled;
      set => this._isKnowledgeManagementEnabled = value;
    }

    [DataMember(Order = 81)]
    public bool? IsSLAEnabled
    {
      get => this._isSLAEnabled;
      set => this._isSLAEnabled = value;
    }

    [DataMember(Order = 82)]
    public bool? IsBPFEntity
    {
      get => this._isBpfEntity;
      set => this._isBpfEntity = value;
    }

    [DataMember]
    public bool? IsDocumentRecommendationsEnabled
    {
      get => this._isDocumentRecommendationsEnabled;
      set => this._isDocumentRecommendationsEnabled = value;
    }

    [DataMember]
    public bool? IsMSTeamsIntegrationEnabled
    {
      get => this._isMSTeamsIntegrationEnabled;
      set => this._isMSTeamsIntegrationEnabled = value;
    }

    [DataMember]
    public string SettingOf
    {
      get => this._settingOf;
      set => this._settingOf = value;
    }

    [DataMember]
    public Guid? DataProviderId
    {
      get => this._dataProviderId;
      set => this._dataProviderId = value;
    }

    [DataMember]
    public Guid? DataSourceId
    {
      get => this._dataSourceId;
      set => this._dataSourceId = value;
    }

    [DataMember]
    public bool? AutoCreateAccessTeams
    {
      get => this._autoCreateAccessTeams;
      set => this._autoCreateAccessTeams = value;
    }

    [DataMember]
    public bool? IsActivity
    {
      get => this._isActivity;
      set => this._isActivity = value;
    }

    [DataMember]
    public bool? IsActivityParty
    {
      get => this._isActivityParty;
      set => this._isActivityParty = value;
    }

    [DataMember]
    public BooleanManagedProperty IsAuditEnabled
    {
      get => this._isAuditEnabled;
      set => this._isAuditEnabled = value;
    }

    [DataMember]
    public bool? IsAvailableOffline
    {
      get => this._isAvailableOffline;
      set => this._isAvailableOffline = value;
    }

    [DataMember]
    public bool? IsChildEntity
    {
      get => this._isChildEntity;
      internal set => this._isChildEntity = value;
    }

    [DataMember]
    public bool? IsAIRUpdated
    {
      get => this._isAIRUpdated;
      internal set => this._isAIRUpdated = value;
    }

    [DataMember]
    public BooleanManagedProperty IsValidForQueue
    {
      get => this._isValidForQueue;
      set => this._isValidForQueue = value;
    }

    [DataMember]
    public BooleanManagedProperty IsConnectionsEnabled
    {
      get => this._isConnectionsEnabled;
      set => this._isConnectionsEnabled = value;
    }

    [DataMember]
    public string IconLargeName
    {
      get => this._iconLargeName;
      set => this._iconLargeName = value;
    }

    [DataMember]
    public string IconMediumName
    {
      get => this._iconMediumName;
      set => this._iconMediumName = value;
    }

    [DataMember]
    public string IconSmallName
    {
      get => this._iconSmallName;
      set => this._iconSmallName = value;
    }

    [DataMember]
    public string IconVectorName
    {
      get => this._iconVectorName;
      set => this._iconVectorName = value;
    }

    [DataMember]
    public bool? IsCustomEntity
    {
      get => this._isCustomEntity;
      internal set => this._isCustomEntity = value;
    }

    [DataMember]
    public bool? IsBusinessProcessEnabled
    {
      get => this._isBusinessProcessEnabled;
      set => this._isBusinessProcessEnabled = value;
    }

    [DataMember]
    public BooleanManagedProperty IsCustomizable
    {
      get => this._isCustomizable;
      set => this._isCustomizable = value;
    }

    [DataMember]
    public BooleanManagedProperty IsRenameable
    {
      get => this._isRenameable;
      set => this._isRenameable = value;
    }

    [DataMember]
    public BooleanManagedProperty IsMappable
    {
      get => this._isMappable;
      set => this._isMappable = value;
    }

    [DataMember]
    public BooleanManagedProperty IsDuplicateDetectionEnabled
    {
      get => this._isDuplicateDetectionEnabled;
      set => this._isDuplicateDetectionEnabled = value;
    }

    [DataMember]
    public BooleanManagedProperty CanCreateAttributes
    {
      get => this._canCreateAttributes;
      set => this._canCreateAttributes = value;
    }

    [DataMember]
    public BooleanManagedProperty CanCreateForms
    {
      get => this._canCreateForms;
      set => this._canCreateForms = value;
    }

    [DataMember]
    public BooleanManagedProperty CanCreateViews
    {
      get => this._canCreateViews;
      set => this._canCreateViews = value;
    }

    [DataMember]
    public BooleanManagedProperty CanCreateCharts
    {
      get => this._canCreateCharts;
      set => this._canCreateCharts = value;
    }

    [DataMember]
    public BooleanManagedProperty CanBeRelatedEntityInRelationship
    {
      get => this._canBeRelatedEntityInRelationship;
      internal set => this._canBeRelatedEntityInRelationship = value;
    }

    [DataMember]
    public BooleanManagedProperty CanBePrimaryEntityInRelationship
    {
      get => this._canBePrimaryEntityInRelationship;
      internal set => this._canBePrimaryEntityInRelationship = value;
    }

    [DataMember]
    public BooleanManagedProperty CanBeInManyToMany
    {
      get => this._canBeInManyToMany;
      internal set => this._canBeInManyToMany = value;
    }

    [DataMember]
    public BooleanManagedProperty CanBeInCustomEntityAssociation
    {
      get => this._canBeInCustomEntityAssociation;
      internal set => this._canBeInCustomEntityAssociation = value;
    }

    [DataMember]
    public BooleanManagedProperty CanEnableSyncToExternalSearchIndex
    {
      get => this._canEnableSyncToExternalSearchIndex;
      set => this._canEnableSyncToExternalSearchIndex = value;
    }

    [DataMember]
    public bool? SyncToExternalSearchIndex
    {
      get => this._syncToExternalSearchIndex;
      set => this._syncToExternalSearchIndex = value;
    }

    [DataMember]
    public BooleanManagedProperty CanModifyAdditionalSettings
    {
      get => this._canModifyAdditionalSettings;
      set => this._canModifyAdditionalSettings = value;
    }

    [DataMember(Order = 70)]
    public BooleanManagedProperty CanChangeHierarchicalRelationship
    {
      get => this._canChangeHierarchicalRelationship;
      set => this._canChangeHierarchicalRelationship = value;
    }

    [DataMember(Order = 71)]
    public bool? IsOptimisticConcurrencyEnabled
    {
      get => this._isOptimisticConcurrencyEnabled;
      internal set => this._isOptimisticConcurrencyEnabled = value;
    }

    [DataMember]
    public bool? ChangeTrackingEnabled
    {
      get => this._changeTrackingEnabled;
      set => this._changeTrackingEnabled = value;
    }

    [DataMember]
    public BooleanManagedProperty CanChangeTrackingBeEnabled
    {
      get => this._canChangeTrackingBeEnabled;
      set => this._canChangeTrackingBeEnabled = value;
    }

    [DataMember]
    public bool? IsImportable
    {
      get => this._isImportable;
      internal set => this._isImportable = value;
    }

    [DataMember]
    public bool? IsIntersect
    {
      get => this._isIntersect;
      internal set => this._isIntersect = value;
    }

    [DataMember]
    public BooleanManagedProperty IsMailMergeEnabled
    {
      get => this._isMailMergeEnabled;
      set => this._isMailMergeEnabled = value;
    }

    [DataMember]
    public bool? IsManaged
    {
      get => this._isManaged;
      internal set => this._isManaged = value;
    }

    [DataMember]
    public bool? IsEnabledForCharts
    {
      get => this._isEnabledForCharts;
      internal set => this._isEnabledForCharts = value;
    }

    [DataMember]
    public bool? IsEnabledForTrace
    {
      get => this._isEnabledForTrace;
      internal set => this._isEnabledForTrace = value;
    }

    [DataMember]
    public bool? IsValidForAdvancedFind
    {
      get => this._isValidForAdvancedFind;
      internal set => this._isValidForAdvancedFind = value;
    }

    [DataMember]
    public BooleanManagedProperty IsVisibleInMobile
    {
      get => this._isVisibleInMobile;
      set => this._isVisibleInMobile = value;
    }

    [DataMember]
    public BooleanManagedProperty IsVisibleInMobileClient
    {
      get => this._isVisibleInMobileClient;
      set => this._isVisibleInMobileClient = value;
    }

    [DataMember]
    public BooleanManagedProperty IsReadOnlyInMobileClient
    {
      get => this._isReadOnlyInMobileClient;
      set => this._isReadOnlyInMobileClient = value;
    }

    [DataMember(Order = 72)]
    public BooleanManagedProperty IsOfflineInMobileClient
    {
      get => this._isOfflineInMobileClient;
      set => this._isOfflineInMobileClient = value;
    }

    [DataMember(Order = 72)]
    public int? DaysSinceRecordLastModified
    {
      get => this._daysSinceRecordLastModified;
      set => this._daysSinceRecordLastModified = value;
    }

    [DataMember(Order = 81)]
    public string MobileOfflineFilters
    {
      get => this._mobileOfflineFilters;
      set => this._mobileOfflineFilters = value;
    }

    [DataMember]
    public bool? IsReadingPaneEnabled
    {
      get => this._isReadingPaneEnabled;
      set => this._isReadingPaneEnabled = value;
    }

    [DataMember]
    public bool? IsQuickCreateEnabled
    {
      get => this._isQuickCreateEnabled;
      set => this._isQuickCreateEnabled = value;
    }

    [DataMember]
    [Alternatekey]
    public string LogicalName
    {
      get => this._logicalName;
      set => this._logicalName = value;
    }

    [DataMember]
    public ManyToManyRelationshipMetadata[] ManyToManyRelationships
    {
      get => this._manyToManyRelationships;
      internal set => this._manyToManyRelationships = value;
    }

    [DataMember]
    public OneToManyRelationshipMetadata[] ManyToOneRelationships
    {
      get => this._manyToOneRelationships;
      internal set => this._manyToOneRelationships = value;
    }

    [DataMember]
    public OneToManyRelationshipMetadata[] OneToManyRelationships
    {
      get => this._oneToManyRelationships;
      internal set => this._oneToManyRelationships = value;
    }

    [DataMember]
    public int? ObjectTypeCode
    {
      get => this._objectTypeCode;
      internal set => this._objectTypeCode = value;
    }

    [DataMember]
    public OwnershipTypes? OwnershipType
    {
      get => this._ownershipType;
      set => this._ownershipType = value;
    }

    [DataMember]
    public string PrimaryNameAttribute
    {
      get => this._primaryNameAttribute;
      internal set => this._primaryNameAttribute = value;
    }

    [DataMember(Order = 60)]
    public string PrimaryImageAttribute
    {
      get => this._primaryImageAttribute;
      internal set => this._primaryImageAttribute = value;
    }

    [DataMember]
    public string PrimaryIdAttribute
    {
      get => this._primaryIdAttribute;
      internal set => this._primaryIdAttribute = value;
    }

    [DataMember]
    public SecurityPrivilegeMetadata[] Privileges
    {
      get => this._privileges;
      internal set => this._privileges = value;
    }

    [DataMember]
    public string RecurrenceBaseEntityLogicalName
    {
      get => this._recurrenceBaseEntityLogicalName;
      internal set => this._recurrenceBaseEntityLogicalName = value;
    }

    [DataMember]
    public string ReportViewName
    {
      get => this._reportViewName;
      internal set => this._reportViewName = value;
    }

    [DataMember]
    public string SchemaName
    {
      get => this._schemaName;
      set => this._schemaName = value;
    }

    [DataMember(Order = 60)]
    public string IntroducedVersion
    {
      get => this._introducedVersion;
      internal set => this._introducedVersion = value;
    }

    [DataMember]
    public bool? IsStateModelAware
    {
      get => this._isStateModelAware;
      internal set => this._isStateModelAware = value;
    }

    [DataMember]
    public bool? EnforceStateTransitions
    {
      get => this._enforceStateTransitions;
      internal set => this._enforceStateTransitions = value;
    }

    internal int? WorkflowSupport
    {
      get => this._workflowSupport;
      set => this._workflowSupport = value;
    }

    internal string PhysicalName
    {
      get => this._physicalName;
      set => this._physicalName = value;
    }

    [DataMember]
    public string ExternalName
    {
      get => this._externalName;
      set => this._externalName = value;
    }

    [DataMember(Order = 71)]
    public string EntityColor
    {
      get => this._entityColor;
      set => this._entityColor = value;
    }

    [DataMember(Order = 71)]
    public EntityKeyMetadata[] Keys
    {
      get => this._keys;
      internal set => this._keys = value;
    }

    [DataMember(Order = 71)]
    public string LogicalCollectionName
    {
      get => this._logicalCollectionName;
      set => this._logicalCollectionName = value;
    }

    [DataMember(Order = 71)]
    public string ExternalCollectionName
    {
      get => this._externalCollectionName;
      set => this._externalCollectionName = value;
    }

    [DataMember(Order = 71)]
    public string CollectionSchemaName
    {
      get => this._collectionSchemaName;
      internal set => this._collectionSchemaName = value;
    }

    [DataMember(Order = 72)]
    public string EntitySetName
    {
      get => this._entitySetName;
      set => this._entitySetName = value;
    }

    [DataMember(Order = 72)]
    public bool? IsEnabledForExternalChannels
    {
      get => this._isEnabledForExternalChannels;
      set => this._isEnabledForExternalChannels = value;
    }

    [DataMember(Order = 72)]
    public bool? IsPrivate
    {
      get => this._isPrivate;
      internal set => this._isPrivate = value;
    }

    [DataMember]
    public bool? UsesBusinessDataLabelTable
    {
      get => this._usesBusinessDataLabelTable;
      set => this._usesBusinessDataLabelTable = value;
    }

    [DataMember(Order = 82)]
    public bool? IsLogicalEntity
    {
      get => this._isLogicalEntity;
      internal set => this._isLogicalEntity = value;
    }

    [DataMember]
    public bool? HasNotes
    {
      get => this._hasNotes;
      set => this._hasNotes = value;
    }

    [DataMember]
    public bool? HasActivities
    {
      get => this._hasActivities;
      set => this._hasActivities = value;
    }

    [DataMember]
    public bool? HasFeedback
    {
      get => this._hasFeedback;
      set => this._hasFeedback = value;
    }

    [DataMember]
    public bool? IsSolutionAware
    {
      get => this._isSolutionAware;
      set => this._isSolutionAware = value;
    }

    [DataMember]
    public EntitySetting[] Settings { get; set; }

    internal int? AvailableForRetrieve
    {
      get => this._availableForRetrieve;
      set => this._availableForRetrieve = value;
    }

    internal int? AvailableForRetrieveMultiple
    {
      get => this._availableForRetrieveMultiple;
      set => this._availableForRetrieveMultiple = value;
    }

    internal int? AvailableForCreate
    {
      get => this._availableForCreate;
      set => this._availableForCreate = value;
    }

    internal int? AvailableForUpdate
    {
      get => this._availableForUpdate;
      set => this._availableForUpdate = value;
    }

    internal int? AvailableForDelete
    {
      get => this._availableForDelete;
      set => this._availableForDelete = value;
    }
  }
}
