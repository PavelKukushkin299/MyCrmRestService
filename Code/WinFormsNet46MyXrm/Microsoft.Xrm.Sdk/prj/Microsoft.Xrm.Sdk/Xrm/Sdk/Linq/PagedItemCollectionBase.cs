// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Linq.PagedItemCollectionBase
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Xrm.Sdk.Linq
{
  internal abstract class PagedItemCollectionBase
  {
    private QueryExpression query;
    private bool moreRecords;
    private string pagingCookie;

    public PagedItemCollectionBase(QueryExpression query, string pagingCookie, bool moreRecords)
    {
      this.query = query;
      this.pagingCookie = pagingCookie;
      this.moreRecords = moreRecords;
    }

    public QueryExpression Query => this.query;

    public bool MoreRecords => this.moreRecords;

    public string PagingCookie => this.pagingCookie;
  }
}
