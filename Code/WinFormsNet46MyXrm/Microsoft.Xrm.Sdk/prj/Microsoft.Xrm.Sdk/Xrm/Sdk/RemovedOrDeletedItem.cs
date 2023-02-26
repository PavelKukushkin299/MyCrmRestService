// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.RemovedOrDeletedItem
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "RemovedOrDeletedItem", Namespace = "http://schemas.microsoft.com/xrm/7.1/Contracts")]
  public sealed class RemovedOrDeletedItem : IChangedItem, IExtensibleDataObject
  {
    private ChangeType _type;
    private EntityReference _removedItem;
    [NonSerialized]
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public ChangeType Type
    {
      get => this._type;
      set => this._type = value;
    }

    [DataMember]
    public EntityReference RemovedItem
    {
      get => this._removedItem;
      set => this._removedItem = value;
    }

    public RemovedOrDeletedItem(ChangeType type, EntityReference entityReference)
    {
      this._type = type;
      this._removedItem = entityReference;
    }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
