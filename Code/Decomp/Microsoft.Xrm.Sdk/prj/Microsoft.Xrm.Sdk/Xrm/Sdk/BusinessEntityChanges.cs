// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.BusinessEntityChanges
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "BusinessEntityChanges", Namespace = "http://schemas.microsoft.com/xrm/7.1/Contracts")]
  public sealed class BusinessEntityChanges : IExtensibleDataObject
  {
    private string _dataToken;
    private BusinessEntityChangesCollection _changes;
    private bool _moreRecords;
    private string _pagingCookie;
    private string _globalMetadataVersion;
    [NonSerialized]
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public bool MoreRecords
    {
      get => this._moreRecords;
      set => this._moreRecords = value;
    }

    [DataMember]
    public string PagingCookie
    {
      get => this._pagingCookie;
      set => this._pagingCookie = value;
    }

    [DataMember]
    public string DataToken
    {
      get => this._dataToken;
      set => this._dataToken = value;
    }

    [DataMember]
    public BusinessEntityChangesCollection Changes
    {
      get => this._changes;
      set => this._changes = value;
    }

    [DataMember]
    public string GlobalMetadataVersion
    {
      get => this._globalMetadataVersion;
      set => this._globalMetadataVersion = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
