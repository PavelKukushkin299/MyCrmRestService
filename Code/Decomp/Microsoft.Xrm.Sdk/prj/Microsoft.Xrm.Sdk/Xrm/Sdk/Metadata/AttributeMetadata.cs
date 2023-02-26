// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.AttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "AttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [KnownType(typeof (MultiSelectPicklistAttributeMetadata))]
  [KnownType(typeof (BooleanAttributeMetadata))]
  [KnownType(typeof (DateTimeAttributeMetadata))]
  [KnownType(typeof (DecimalAttributeMetadata))]
  [KnownType(typeof (DoubleAttributeMetadata))]
  [KnownType(typeof (EntityNameAttributeMetadata))]
  [KnownType(typeof (ImageAttributeMetadata))]
  [KnownType(typeof (IntegerAttributeMetadata))]
  [KnownType(typeof (BigIntAttributeMetadata))]
  [KnownType(typeof (LookupAttributeMetadata))]
  [KnownType(typeof (MemoAttributeMetadata))]
  [KnownType(typeof (MoneyAttributeMetadata))]
  [KnownType(typeof (PicklistAttributeMetadata))]
  [KnownType(typeof (StateAttributeMetadata))]
  [KnownType(typeof (StatusAttributeMetadata))]
  [KnownType(typeof (StringAttributeMetadata))]
  [KnownType(typeof (ManagedPropertyAttributeMetadata))]
  [KnownType(typeof (UniqueIdentifierAttributeMetadata))]
  [KnownType(typeof (FileAttributeMetadata))]
  [MetadataName(LogicalCollectionName = "AttributeDefinitions", LogicalName = "AttributeMetadata")]
  public class AttributeMetadata : MetadataBase
  {
    private string _attributeOf;
    private AttributeTypeCode? _attributeType;
    private AttributeTypeDisplayName _attributeTypeDisplayName;
    private int? _columnNumber;
    private Label _description;
    private Label _displayName;
    private string _entityLogicalName;
    private BooleanManagedProperty _isAuditEnabled;
    private bool? _isCustomAttribute;
    private bool? _isPrimaryId;
    private bool? _isPrimaryAttribute;
    private Guid? _linkedAttributeId;
    private string _logicalName;
    private string _schemaName;
    private string _externalName;
    private bool? _validForCreate;
    private bool? _validForRead;
    private bool? _validForUpdate;
    private bool? _isSecured;
    private bool? _canBeSecuredForRead;
    private bool? _canBeSecuredForCreate;
    private bool? _canBeSecuredForUpdate;
    private bool? _isManaged;
    private string _deprecatedVersion;
    private string _introducedVersion;
    private BooleanManagedProperty _isGlobalFilterEnabled;
    private BooleanManagedProperty _isSortableEnabled;
    private bool? _isSearchable;
    private bool? _isFilterable;
    private bool? _isRetrievable;
    private string _inheritsFrom;
    private bool? _isDataSourceSecret;
    private bool? _isValidForForm;
    private bool? _isRequiredForForm;
    private bool? _isValidForGrid;
    private BooleanManagedProperty _isCustomizable;
    private BooleanManagedProperty _isRenameable;
    private BooleanManagedProperty _isValidForAdvancedFind;
    private AttributeRequiredLevelManagedProperty _requiredLevel;
    private BooleanManagedProperty _canModifyAdditionalSettings;
    private string _aggregateOf;
    private bool? _isLogical;
    private int _displayMask;

    public AttributeMetadata()
    {
    }

    protected AttributeMetadata(AttributeTypeCode attributeType)
      : this()
    {
      this.AttributeType = new AttributeTypeCode?(attributeType);
      this.AttributeTypeName = this.GetAttributeTypeDisplayName(attributeType);
    }

    protected AttributeMetadata(AttributeTypeCode attributeType, string schemaName)
      : this(attributeType)
    {
      this.SchemaName = schemaName;
    }

    private AttributeTypeDisplayName GetAttributeTypeDisplayName(
      AttributeTypeCode attributeType)
    {
      switch (attributeType)
      {
        case AttributeTypeCode.Boolean:
          return AttributeTypeDisplayName.BooleanType;
        case AttributeTypeCode.Customer:
          return AttributeTypeDisplayName.CustomerType;
        case AttributeTypeCode.DateTime:
          return AttributeTypeDisplayName.DateTimeType;
        case AttributeTypeCode.Decimal:
          return AttributeTypeDisplayName.DecimalType;
        case AttributeTypeCode.Double:
          return AttributeTypeDisplayName.DoubleType;
        case AttributeTypeCode.Integer:
          return AttributeTypeDisplayName.IntegerType;
        case AttributeTypeCode.Lookup:
          return AttributeTypeDisplayName.LookupType;
        case AttributeTypeCode.Memo:
          return AttributeTypeDisplayName.MemoType;
        case AttributeTypeCode.Money:
          return AttributeTypeDisplayName.MoneyType;
        case AttributeTypeCode.Owner:
          return AttributeTypeDisplayName.OwnerType;
        case AttributeTypeCode.PartyList:
          return AttributeTypeDisplayName.PartyListType;
        case AttributeTypeCode.Picklist:
          return AttributeTypeDisplayName.PicklistType;
        case AttributeTypeCode.State:
          return AttributeTypeDisplayName.StateType;
        case AttributeTypeCode.Status:
          return AttributeTypeDisplayName.StatusType;
        case AttributeTypeCode.String:
          return AttributeTypeDisplayName.StringType;
        case AttributeTypeCode.Uniqueidentifier:
          return AttributeTypeDisplayName.UniqueidentifierType;
        case AttributeTypeCode.CalendarRules:
          return AttributeTypeDisplayName.CalendarRulesType;
        case AttributeTypeCode.Virtual:
          return AttributeTypeDisplayName.VirtualType;
        case AttributeTypeCode.BigInt:
          return AttributeTypeDisplayName.BigIntType;
        case AttributeTypeCode.ManagedProperty:
          return AttributeTypeDisplayName.ManagedPropertyType;
        case AttributeTypeCode.EntityName:
          return AttributeTypeDisplayName.EntityNameType;
        default:
          return (AttributeTypeDisplayName) null;
      }
    }

    [DataMember]
    public string AttributeOf
    {
      get => this._attributeOf;
      internal set => this._attributeOf = value;
    }

    [DataMember]
    public AttributeTypeCode? AttributeType
    {
      get => this._attributeType;
      internal set => this._attributeType = value;
    }

    [DataMember(Order = 60)]
    public AttributeTypeDisplayName AttributeTypeName
    {
      get => this._attributeTypeDisplayName;
      internal set => this._attributeTypeDisplayName = value;
    }

    [DataMember]
    public int? ColumnNumber
    {
      get => this._columnNumber;
      internal set => this._columnNumber = value;
    }

    [DataMember]
    public Label Description
    {
      get => this._description;
      set => this._description = value;
    }

    [DataMember]
    public Label DisplayName
    {
      get => this._displayName;
      set => this._displayName = value;
    }

    [DataMember]
    public string DeprecatedVersion
    {
      get => this._deprecatedVersion;
      internal set => this._deprecatedVersion = value;
    }

    [DataMember(Order = 60)]
    public string IntroducedVersion
    {
      get => this._introducedVersion;
      internal set => this._introducedVersion = value;
    }

    [DataMember]
    public string EntityLogicalName
    {
      get => this._entityLogicalName;
      internal set => this._entityLogicalName = value;
    }

    [DataMember]
    public BooleanManagedProperty IsAuditEnabled
    {
      get => this._isAuditEnabled;
      set => this._isAuditEnabled = value;
    }

    [DataMember]
    public bool? IsCustomAttribute
    {
      get => this._isCustomAttribute;
      internal set => this._isCustomAttribute = value;
    }

    [DataMember]
    public bool? IsPrimaryId
    {
      get => this._isPrimaryId;
      internal set => this._isPrimaryId = value;
    }

    public bool IsValidODataAttribute { get; internal set; }

    [DataMember]
    public bool? IsPrimaryName
    {
      get => this._isPrimaryAttribute;
      internal set => this._isPrimaryAttribute = value;
    }

    [DataMember]
    public bool? IsValidForCreate
    {
      get => this._validForCreate;
      set => this._validForCreate = value;
    }

    [DataMember]
    public bool? IsValidForRead
    {
      get => this._validForRead;
      internal set => this._validForRead = value;
    }

    [DataMember]
    public bool? IsValidForUpdate
    {
      get => this._validForUpdate;
      set => this._validForUpdate = value;
    }

    [DataMember]
    public bool? CanBeSecuredForRead
    {
      get => this._canBeSecuredForRead;
      internal set => this._canBeSecuredForRead = value;
    }

    [DataMember]
    public bool? CanBeSecuredForCreate
    {
      get => this._canBeSecuredForCreate;
      internal set => this._canBeSecuredForCreate = value;
    }

    [DataMember]
    public bool? CanBeSecuredForUpdate
    {
      get => this._canBeSecuredForUpdate;
      internal set => this._canBeSecuredForUpdate = value;
    }

    [DataMember]
    public bool? IsSecured
    {
      get => this._isSecured;
      set => this._isSecured = value;
    }

    [DataMember]
    public bool? IsRetrievable
    {
      get => this._isRetrievable;
      internal set => this._isRetrievable = value;
    }

    [DataMember]
    public bool? IsFilterable
    {
      get => this._isFilterable;
      internal set => this._isFilterable = value;
    }

    [DataMember]
    public bool? IsSearchable
    {
      get => this._isSearchable;
      internal set => this._isSearchable = value;
    }

    [DataMember]
    public bool? IsManaged
    {
      get => this._isManaged;
      internal set => this._isManaged = value;
    }

    [DataMember]
    public BooleanManagedProperty IsGlobalFilterEnabled
    {
      get => this._isGlobalFilterEnabled;
      set => this._isGlobalFilterEnabled = value;
    }

    [DataMember]
    public BooleanManagedProperty IsSortableEnabled
    {
      get => this._isSortableEnabled;
      set => this._isSortableEnabled = value;
    }

    [DataMember]
    public Guid? LinkedAttributeId
    {
      get => this._linkedAttributeId;
      set => this._linkedAttributeId = value;
    }

    [DataMember]
    [Alternatekey]
    public string LogicalName
    {
      get => this._logicalName;
      set => this._logicalName = value;
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
    public BooleanManagedProperty IsValidForAdvancedFind
    {
      get => this._isValidForAdvancedFind;
      set => this._isValidForAdvancedFind = value;
    }

    [DataMember]
    public bool? IsValidForForm
    {
      get => this._isValidForForm;
      set => this._isValidForForm = value;
    }

    [DataMember]
    public bool? IsRequiredForForm
    {
      get => this._isRequiredForForm;
      set => this._isRequiredForForm = value;
    }

    [DataMember]
    public bool? IsValidForGrid
    {
      get => this._isValidForGrid;
      set => this._isValidForGrid = value;
    }

    [DataMember]
    public AttributeRequiredLevelManagedProperty RequiredLevel
    {
      get => this._requiredLevel;
      set => this._requiredLevel = value;
    }

    [DataMember]
    public BooleanManagedProperty CanModifyAdditionalSettings
    {
      get => this._canModifyAdditionalSettings;
      set => this._canModifyAdditionalSettings = value;
    }

    [DataMember]
    public string SchemaName
    {
      get => this._schemaName;
      set => this._schemaName = value;
    }

    [DataMember]
    public string ExternalName
    {
      get => this._externalName;
      set => this._externalName = value;
    }

    internal int DisplayMask
    {
      get => this._displayMask;
      set => this._displayMask = value;
    }

    internal string AggregateOf
    {
      get => this._aggregateOf;
      set => this._aggregateOf = value;
    }

    [DataMember(Order = 70)]
    public bool? IsLogical
    {
      get => this._isLogical;
      internal set => this._isLogical = value;
    }

    [DataMember]
    public bool? IsDataSourceSecret
    {
      get => this._isDataSourceSecret;
      set => this._isDataSourceSecret = value;
    }

    [DataMember]
    public string InheritsFrom
    {
      get => this._inheritsFrom;
      internal set => this._inheritsFrom = value;
    }

    [DataMember(Order = 70)]
    public int? SourceType { get; set; }

    [DataMember(Order = 90)]
    public string AutoNumberFormat { get; set; }
  }
}
