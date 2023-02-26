// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Linq.Query`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

namespace Microsoft.Xrm.Sdk.Linq
{
  internal sealed class Query<T> : 
    IOrderedQueryable<T>,
    IQueryable<T>,
    IEnumerable<T>,
    IEnumerable,
    IQueryable,
    IOrderedQueryable,
    IEntityQuery
  {
    public string EntityLogicalName { get; private set; }

    public Query(IQueryProvider provider, string entityLogicalName)
    {
      if (provider == null)
        throw new ArgumentNullException(nameof (provider));
      if (string.IsNullOrWhiteSpace(entityLogicalName))
        throw new ArgumentNullException(nameof (entityLogicalName));
      this.Provider = provider;
      this.EntityLogicalName = entityLogicalName;
      this.Expression = (Expression) Expression.Constant((object) this);
    }

    public Query(IQueryProvider provider, Expression expression)
    {
      if (provider == null)
        throw new ArgumentNullException(nameof (provider));
      if (expression == null)
        throw new ArgumentNullException(nameof (expression));
      this.Provider = provider;
      this.Expression = expression;
    }

    public IEnumerator<T> GetEnumerator() => this.Provider is QueryProvider provider ? provider.GetEnumerator<T>(this.Expression) : throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The provider '{0}' is not of the expected type '{1}'.", (object) this.Provider, (object) typeof (QueryProvider)));

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

    public Type ElementType => typeof (T);

    public IQueryProvider Provider { get; private set; }

    public Expression Expression { get; private set; }
  }
}
