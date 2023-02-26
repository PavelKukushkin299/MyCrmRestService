// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.NewOrUpdatedItem
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "NewOrUpdatedItem", Namespace = "http://schemas.microsoft.com/xrm/7.1/Contracts")]
  public sealed class NewOrUpdatedItem : IChangedItem, IExtensibleDataObject
  {
    private ChangeType _type;
    private Entity _newOrUpdatedEntity;
    [NonSerialized]
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public ChangeType Type
    {
      get => this._type;
      set => this._type = value;
    }

    [DataMember]
    public Entity NewOrUpdatedEntity
    {
      get => this._newOrUpdatedEntity;
      set => this._newOrUpdatedEntity = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }

    public NewOrUpdatedItem(ChangeType type, Entity entity)
    {
      this._type = type;
      this._newOrUpdatedEntity = entity;
    }
  }
}
