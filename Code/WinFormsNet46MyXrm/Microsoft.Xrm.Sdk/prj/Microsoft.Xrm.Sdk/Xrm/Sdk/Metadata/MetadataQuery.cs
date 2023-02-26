// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.MetadataQuery
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "MetadataQuery", Namespace = "http://schemas.microsoft.com/xrm/8.2/Contracts")]
  public sealed class MetadataQuery : IExtensibleDataObject
  {
    private string _metadataType;
    private string _metadataSubtype;
    private string _entityLogicalName;
    private Guid? _metadataId;
    private string _metadataName;
    private string[] _metadataNames;
    private bool _getDefault;
    private DependencyDepth _dependencyDepth;
    private string _changedAfter;
    private Guid?[] _exclude;
    private Guid? _appId;
    private string _systemMetadataDelta;
    private string _userMetadataDelta;
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public string MetadataType
    {
      get => this._metadataType;
      set => this._metadataType = value;
    }

    [DataMember]
    public string MetadataSubtype
    {
      get => this._metadataSubtype;
      set => this._metadataSubtype = value;
    }

    [DataMember]
    public string EntityLogicalName
    {
      get => this._entityLogicalName;
      set => this._entityLogicalName = value;
    }

    [DataMember]
    public Guid? MetadataId
    {
      get => this._metadataId;
      set => this._metadataId = value;
    }

    [DataMember]
    public string MetadataName
    {
      get => this._metadataName;
      set => this._metadataName = value;
    }

    [DataMember]
    public string[] MetadataNames
    {
      get => this._metadataNames;
      set => this._metadataNames = value;
    }

    [DataMember]
    public bool GetDefault
    {
      get => this._getDefault;
      set => this._getDefault = value;
    }

    [DataMember]
    public DependencyDepth DependencyDepth
    {
      get => this._dependencyDepth;
      set => this._dependencyDepth = value;
    }

    [DataMember]
    public string ChangedAfter
    {
      get => this._changedAfter;
      set => this._changedAfter = value;
    }

    [DataMember]
    public Guid?[] Exclude
    {
      get => this._exclude;
      set => this._exclude = value;
    }

    [DataMember]
    public Guid? AppId
    {
      get => this._appId;
      set => this._appId = value;
    }

    [DataMember]
    public string UserMetadataDelta
    {
      get => this._userMetadataDelta;
      set => this._userMetadataDelta = value;
    }

    [DataMember]
    public string SystemMetadataDelta
    {
      get => this._systemMetadataDelta;
      set => this._systemMetadataDelta = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
