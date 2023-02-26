// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.EntityKeyMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "EntityKeyMetadata", Namespace = "http://schemas.microsoft.com/xrm/7.1/Metadata")]
  [MetadataName(LogicalCollectionName = "EntityKeyDefinitions", LogicalName = "EntityKeyMetadata")]
  public sealed class EntityKeyMetadata : MetadataBase
  {
    private Label _displayName;
    private string _logicalName;
    private string _schemaName;
    private string _entityLogicalName;
    private string[] _keyAttributes;
    private BooleanManagedProperty _isCustomizable;
    private bool? _isManaged;
    private bool? _isSynchronous;
    private bool? _isExportKey;
    private string _introducedVersion;
    private EntityKeyIndexStatus _entityKeyIndexStatus;
    private EntityReference _asyncJob;

    [DataMember]
    public Label DisplayName
    {
      get => this._displayName;
      set => this._displayName = value;
    }

    [DataMember]
    [Alternatekey]
    public string LogicalName
    {
      get => this._logicalName;
      set => this._logicalName = value;
    }

    [DataMember]
    public string SchemaName
    {
      get => this._schemaName;
      set => this._schemaName = value;
    }

    [DataMember]
    public string EntityLogicalName
    {
      get => this._entityLogicalName;
      internal set => this._entityLogicalName = value;
    }

    [DataMember]
    public string[] KeyAttributes
    {
      get => this._keyAttributes;
      set => this._keyAttributes = value;
    }

    [DataMember]
    public BooleanManagedProperty IsCustomizable
    {
      get => this._isCustomizable;
      internal set => this._isCustomizable = value;
    }

    [DataMember]
    public bool? IsManaged
    {
      get => this._isManaged;
      internal set => this._isManaged = value;
    }

    [DataMember]
    public string IntroducedVersion
    {
      get => this._introducedVersion;
      internal set => this._introducedVersion = value;
    }

    [DataMember]
    public EntityKeyIndexStatus EntityKeyIndexStatus
    {
      get => this._entityKeyIndexStatus;
      internal set => this._entityKeyIndexStatus = value;
    }

    [DataMember]
    public EntityReference AsyncJob
    {
      get => this._asyncJob;
      internal set => this._asyncJob = value;
    }

    [DataMember]
    public bool? IsSynchronous
    {
      get => this._isSynchronous;
      internal set => this._isSynchronous = value;
    }

    [DataMember]
    public bool? IsExportKey
    {
      get => this._isExportKey;
      internal set => this._isExportKey = value;
    }
  }
}
