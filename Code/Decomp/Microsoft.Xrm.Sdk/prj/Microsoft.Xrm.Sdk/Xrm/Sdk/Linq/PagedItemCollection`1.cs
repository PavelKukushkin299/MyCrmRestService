// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Linq.PagedItemCollection`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Xrm.Sdk.Linq
{
  internal sealed class PagedItemCollection<TSource> : 
    PagedItemCollectionBase,
    IEnumerable<TSource>,
    IEnumerable,
    IEnumerator<TSource>,
    IDisposable,
    IEnumerator
  {
    private TSource current;
    private IEnumerator<TSource> enumerator;
    private IEnumerable<TSource> source;

    public PagedItemCollection(
      IEnumerable<TSource> source,
      QueryExpression query,
      string pagingCookie,
      bool moreRecords)
      : base(query, pagingCookie, moreRecords)
    {
      this.source = source;
    }

    public PagedItemCollection<TSource> Clone() => new PagedItemCollection<TSource>(this.source, this.Query, this.PagingCookie, this.MoreRecords);

    public IEnumerator<TSource> GetEnumerator() => (IEnumerator<TSource>) this.Clone();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

    public TSource Current => this.current;

    public void Dispose()
    {
      if (this.enumerator != null)
        this.enumerator.Dispose();
      this.enumerator = (IEnumerator<TSource>) null;
      this.current = default (TSource);
    }

    object IEnumerator.Current => (object) this.Current;

    public bool MoveNext()
    {
      if (this.enumerator == null)
        this.enumerator = this.source.GetEnumerator();
      if (!this.enumerator.MoveNext())
        return false;
      this.current = this.enumerator.Current;
      return true;
    }

    public void Reset() => throw new NotImplementedException();
  }
}
