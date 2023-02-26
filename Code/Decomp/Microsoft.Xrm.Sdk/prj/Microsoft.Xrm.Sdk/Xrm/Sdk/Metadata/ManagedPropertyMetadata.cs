// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.ManagedPropertyMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "ManagedPropertyMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalCollectionName = "ManagedPropertyDefinitions", LogicalName = "ManagedPropertyMetadata")]
  public sealed class ManagedPropertyMetadata : MetadataBase
  {
    private string _logicalName;
    private Label _displayName;
    private Label _description;
    private Microsoft.Xrm.Sdk.Metadata.ManagedPropertyType? _managedPropertyType;
    private ManagedPropertyOperation? _operation;
    private ManagedPropertyEvaluationPriority? _evaluationPriority;
    private string _enablesAttributeName;
    private string _enablesEntityName;
    private int? _errorCode;
    private bool? _isPrivate;
    private bool? _isGlobalForOperation;
    private string _introducedVersion;

    [DataMember]
    [Alternatekey]
    public string LogicalName
    {
      get => this._logicalName;
      internal set => this._logicalName = value;
    }

    [DataMember]
    public Label DisplayName
    {
      get => this._displayName;
      internal set => this._displayName = value;
    }

    [DataMember]
    public Microsoft.Xrm.Sdk.Metadata.ManagedPropertyType? ManagedPropertyType
    {
      get => this._managedPropertyType;
      internal set => this._managedPropertyType = value;
    }

    [DataMember]
    public ManagedPropertyOperation? Operation
    {
      get => this._operation;
      internal set => this._operation = value;
    }

    [DataMember]
    public bool? IsGlobalForOperation
    {
      get => this._isGlobalForOperation;
      internal set => this._isGlobalForOperation = value;
    }

    [DataMember]
    public ManagedPropertyEvaluationPriority? EvaluationPriority
    {
      get => this._evaluationPriority;
      internal set => this._evaluationPriority = value;
    }

    [DataMember]
    public bool? IsPrivate
    {
      get => this._isPrivate;
      internal set => this._isPrivate = value;
    }

    [DataMember]
    public int? ErrorCode
    {
      get => this._errorCode;
      internal set => this._errorCode = value;
    }

    [DataMember]
    public string EnablesEntityName
    {
      get => this._enablesEntityName;
      internal set => this._enablesEntityName = value;
    }

    [DataMember]
    public string EnablesAttributeName
    {
      get => this._enablesAttributeName;
      internal set => this._enablesAttributeName = value;
    }

    [DataMember]
    public Label Description
    {
      get => this._description;
      internal set => this._description = value;
    }

    [DataMember(Order = 60)]
    public string IntroducedVersion
    {
      get => this._introducedVersion;
      internal set => this._introducedVersion = value;
    }
  }
}
