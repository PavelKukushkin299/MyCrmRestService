// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.AttributePrivilege
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "AttributePrivilege", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  [Serializable]
  public sealed class AttributePrivilege : IExtensibleDataObject
  {
    private Guid _attributeId;
    private int _canCreate;
    private int _canRead;
    private int _canUpdate;
    [NonSerialized]
    private ExtensionDataObject _extensionDataObject;

    public AttributePrivilege()
    {
    }

    public AttributePrivilege(Guid attributeId, int canCreate, int canRead, int canUpdate)
    {
      this._attributeId = attributeId;
      this._canCreate = canCreate;
      this._canRead = canRead;
      this._canUpdate = canUpdate;
    }

    [DataMember]
    public Guid AttributeId
    {
      get => this._attributeId;
      internal set => this._attributeId = value;
    }

    [DataMember]
    public int CanCreate
    {
      get => this._canCreate;
      internal set => this._canCreate = value;
    }

    [DataMember]
    public int CanRead
    {
      get => this._canRead;
      internal set => this._canRead = value;
    }

    [DataMember]
    public int CanUpdate
    {
      get => this._canUpdate;
      internal set => this._canUpdate = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
