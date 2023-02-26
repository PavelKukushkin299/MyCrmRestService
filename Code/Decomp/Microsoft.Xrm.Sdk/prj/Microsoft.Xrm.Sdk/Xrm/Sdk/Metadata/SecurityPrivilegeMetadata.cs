// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.SecurityPrivilegeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "SecurityPrivilegeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  public sealed class SecurityPrivilegeMetadata : IExtensibleDataObject
  {
    private string _name;
    private Guid _privilegeId;
    private PrivilegeType _privilegeType;
    private bool _canBeBasic;
    private bool _canBeLocal;
    private bool _canBeDeep;
    private bool _canBeGlobal;
    private bool _canBeEntityReference;
    private bool _canBeParentEntityReference;
    private ExtensionDataObject _extensionDataObject;

    internal SecurityPrivilegeMetadata()
    {
    }

    [DataMember]
    public bool CanBeBasic
    {
      get => this._canBeBasic;
      internal set => this._canBeBasic = value;
    }

    [DataMember]
    public bool CanBeDeep
    {
      get => this._canBeDeep;
      internal set => this._canBeDeep = value;
    }

    [DataMember]
    public bool CanBeGlobal
    {
      get => this._canBeGlobal;
      internal set => this._canBeGlobal = value;
    }

    [DataMember]
    public bool CanBeLocal
    {
      get => this._canBeLocal;
      internal set => this._canBeLocal = value;
    }

    [DataMember]
    public bool CanBeEntityReference
    {
      get => this._canBeEntityReference;
      internal set => this._canBeEntityReference = value;
    }

    [DataMember]
    public bool CanBeParentEntityReference
    {
      get => this._canBeParentEntityReference;
      internal set => this._canBeParentEntityReference = value;
    }

    [DataMember]
    public string Name
    {
      get => this._name;
      internal set => this._name = value;
    }

    [DataMember]
    public Guid PrivilegeId
    {
      get => this._privilegeId;
      internal set => this._privilegeId = value;
    }

    [DataMember]
    public PrivilegeType PrivilegeType
    {
      get => this._privilegeType;
      internal set => this._privilegeType = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
