// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.MailboxTrackingFolderMapping
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "MailboxTrackingFolderMapping", Namespace = "http://schemas.microsoft.com/xrm/7.1/Contracts")]
  [Serializable]
  public sealed class MailboxTrackingFolderMapping : IExtensibleDataObject
  {
    private string _exchangeFolderId;
    private string _exchangeFolderName;
    private Guid _regardingObjectId;
    private string _regardingObjectName;
    private int _regardingObjectTypeCode;
    private bool _isFolderOnboarded;
    [NonSerialized]
    private ExtensionDataObject _extensionDataObject;

    public MailboxTrackingFolderMapping()
    {
    }

    public MailboxTrackingFolderMapping(
      string exchangeFolderId,
      string exchangeFolderName,
      Guid regardingObjectId,
      string regardingObjectName,
      int regardingObjectTypeCode,
      bool isFolderOnboarded)
    {
      this._exchangeFolderId = exchangeFolderId;
      this._exchangeFolderName = exchangeFolderName;
      this._regardingObjectId = regardingObjectId;
      this._regardingObjectName = regardingObjectName;
      this._regardingObjectTypeCode = regardingObjectTypeCode;
      this._isFolderOnboarded = isFolderOnboarded;
    }

    [DataMember]
    public string ExchangeFolderId
    {
      get => this._exchangeFolderId;
      internal set => this._exchangeFolderId = value;
    }

    [DataMember]
    public string ExchangeFolderName
    {
      get => this._exchangeFolderName;
      internal set => this._exchangeFolderName = value;
    }

    [DataMember]
    public Guid RegardingObjectId
    {
      get => this._regardingObjectId;
      internal set => this._regardingObjectId = value;
    }

    [DataMember]
    public string RegardingObjectName
    {
      get => this._regardingObjectName;
      internal set => this._regardingObjectName = value;
    }

    [DataMember]
    public int RegardingObjectTypeCode
    {
      get => this._regardingObjectTypeCode;
      internal set => this._regardingObjectTypeCode = value;
    }

    [DataMember]
    public bool IsFolderOnboarded
    {
      get => this._isFolderOnboarded;
      internal set => this._isFolderOnboarded = value;
    }

    ExtensionDataObject IExtensibleDataObject.ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
