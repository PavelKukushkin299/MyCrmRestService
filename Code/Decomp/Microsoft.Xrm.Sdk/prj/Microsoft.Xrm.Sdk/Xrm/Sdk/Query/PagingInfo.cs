// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.PagingInfo
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
  [DataContract(Name = "PagingInfo", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class PagingInfo : IExtensibleDataObject
  {
    private int _pageNumber;
    private int _count;
    private string _pagingCookie;
    private bool _returnTotalRecordCount;
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public int PageNumber
    {
      get => this._pageNumber;
      set => this._pageNumber = value;
    }

    [DataMember]
    public int Count
    {
      get => this._count;
      set => this._count = value;
    }

    [DataMember]
    public bool ReturnTotalRecordCount
    {
      get => this._returnTotalRecordCount;
      set => this._returnTotalRecordCount = value;
    }

    [DataMember]
    public string PagingCookie
    {
      get => this._pagingCookie;
      set => this._pagingCookie = value;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal void Accept(IQueryVisitor visitor) => visitor.Visit(this);

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
