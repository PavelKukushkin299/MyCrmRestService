// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.AttributeMapping
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "AttributeMapping", Namespace = "http://schemas.microsoft.com/xrm/2014/Contracts")]
  [Serializable]
  public sealed class AttributeMapping : IExtensibleDataObject
  {
    private Guid _attributeMappingId;
    private string _mappingName;
    private string _attributeCrmName;
    private string _attributeExchangeName;
    private int _entityTypeCode;
    private int _syncDirection;
    private int _defaultSyncDirection;
    private int _allowedSyncDirection;
    private bool _isComputed;
    private Collection<string> _computedProperties;
    private string _attributeCrmDisplayName;
    private string _attributeExchangeDisplayName;
    [NonSerialized]
    private ExtensionDataObject _extensionDataObject;

    public AttributeMapping()
    {
    }

    public AttributeMapping(
      Guid attributeMappingId,
      string mappingName,
      string attributeCrmName,
      string attributeExchangeName,
      int entityTypeCode,
      int syncDirection,
      int defaultSyncDirection,
      int allowedSyncDirection,
      bool isComputed,
      Collection<string> computedProperties,
      string attributeCrmDisplayName,
      string attributeExchangeDisplayName)
    {
      this._attributeMappingId = attributeMappingId;
      this._mappingName = mappingName;
      this._attributeCrmName = attributeCrmName;
      this._attributeExchangeName = attributeExchangeName;
      this._entityTypeCode = entityTypeCode;
      this._syncDirection = syncDirection;
      this._defaultSyncDirection = defaultSyncDirection;
      this._allowedSyncDirection = allowedSyncDirection;
      this._isComputed = isComputed;
      this._computedProperties = computedProperties;
      this._attributeCrmDisplayName = attributeCrmDisplayName;
      this._attributeExchangeDisplayName = attributeExchangeDisplayName;
    }

    [DataMember]
    public Guid AttributeMappingId
    {
      get => this._attributeMappingId;
      internal set => this._attributeMappingId = value;
    }

    [DataMember]
    public string MappingName
    {
      get => this._mappingName;
      internal set => this._mappingName = value;
    }

    [DataMember]
    public string AttributeCrmName
    {
      get => this._attributeCrmName;
      internal set => this._attributeCrmName = value;
    }

    [DataMember]
    public string AttributeExchangeName
    {
      get => this._attributeExchangeName;
      internal set => this._attributeExchangeName = value;
    }

    [DataMember]
    public int SyncDirection
    {
      get => this._syncDirection;
      internal set => this._syncDirection = value;
    }

    [DataMember]
    public int DefaultSyncDirection
    {
      get => this._defaultSyncDirection;
      internal set => this._defaultSyncDirection = value;
    }

    [DataMember]
    public int AllowedSyncDirection
    {
      get => this._allowedSyncDirection;
      internal set => this._allowedSyncDirection = value;
    }

    [DataMember]
    public bool IsComputed
    {
      get => this._isComputed;
      internal set => this._isComputed = value;
    }

    [DataMember]
    public int EntityTypeCode
    {
      get => this._entityTypeCode;
      internal set => this._entityTypeCode = value;
    }

    [DataMember]
    public Collection<string> ComputedProperties
    {
      get => this._computedProperties;
      internal set => this._computedProperties = value;
    }

    [DataMember]
    public string AttributeCrmDisplayName
    {
      get => this._attributeCrmDisplayName;
      internal set => this._attributeCrmDisplayName = value;
    }

    [DataMember]
    public string AttributeExchangeDisplayName
    {
      get => this._attributeExchangeDisplayName;
      internal set => this._attributeExchangeDisplayName = value;
    }

    ExtensionDataObject IExtensibleDataObject.ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
