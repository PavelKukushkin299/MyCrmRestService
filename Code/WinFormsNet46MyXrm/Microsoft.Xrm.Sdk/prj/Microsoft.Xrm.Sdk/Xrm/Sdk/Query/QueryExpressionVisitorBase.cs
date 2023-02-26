// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.QueryExpressionVisitorBase
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Microsoft.Xrm.Sdk.Query
{
  public abstract class QueryExpressionVisitorBase : IQueryExpressionVisitor
  {
    public virtual QueryExpression Visit(QueryExpression query)
    {
      FilterExpression filterExpression = query != null ? this.VisitFilterExpression(query.Criteria) : throw new ArgumentException(nameof (query));
      IReadOnlyList<OrderExpression> items1 = this.VisitAndConvert<OrderExpression>((IReadOnlyList<OrderExpression>) query.Orders, new Func<OrderExpression, OrderExpression>(this.VisitOrderExpression));
      IReadOnlyList<LinkEntity> items2 = this.VisitAndConvert<LinkEntity>((IReadOnlyList<LinkEntity>) query.LinkEntities, new Func<LinkEntity, LinkEntity>(this.VisitLinkEntity));
      PagingInfo pagingInfo = this.VisitPagingInfo(query.PageInfo);
      ColumnSet columnSet = this.VisitColumnSet(query.ColumnSet);
      if (filterExpression == query.Criteria && items1 == query.Orders && items2 == query.LinkEntities && pagingInfo == query.PageInfo && columnSet == query.ColumnSet)
        return query;
      QueryExpression queryExpression = new QueryExpression(query.EntityName);
      queryExpression.Criteria = filterExpression;
      queryExpression.Orders.AddRange((IEnumerable<OrderExpression>) items1);
      queryExpression.LinkEntities.AddRange((IEnumerable<LinkEntity>) items2);
      queryExpression.PageInfo = pagingInfo;
      queryExpression.ColumnSet = columnSet;
      queryExpression.TopCount = query.TopCount;
      queryExpression.Distinct = query.Distinct;
      queryExpression.NoLock = query.NoLock;
      queryExpression.ExtensionData = query.ExtensionData;
      return queryExpression;
    }

    protected virtual PagingInfo VisitPagingInfo(PagingInfo pageInfo) => pageInfo;

    protected virtual LinkEntity VisitLinkEntity(LinkEntity linkEntity)
    {
      FilterExpression filterExpression = this.VisitFilterExpression(linkEntity.LinkCriteria);
      IReadOnlyList<OrderExpression> items1 = this.VisitAndConvert<OrderExpression>((IReadOnlyList<OrderExpression>) linkEntity.Orders, new Func<OrderExpression, OrderExpression>(this.VisitOrderExpression));
      IReadOnlyList<LinkEntity> items2 = this.VisitAndConvert<LinkEntity>((IReadOnlyList<LinkEntity>) linkEntity.LinkEntities, new Func<LinkEntity, LinkEntity>(this.VisitLinkEntity));
      ColumnSet columnSet = this.VisitColumnSet(linkEntity.Columns);
      if (items2 == linkEntity.LinkEntities && filterExpression == linkEntity.LinkCriteria && items1 == linkEntity.Orders && columnSet == linkEntity.Columns)
        return linkEntity;
      LinkEntity linkEntity1 = new LinkEntity();
      linkEntity1.LinkFromEntityName = linkEntity.LinkFromEntityName;
      linkEntity1.LinkToEntityName = linkEntity.LinkToEntityName;
      linkEntity1.LinkFromAttributeName = linkEntity.LinkFromAttributeName;
      linkEntity1.LinkToAttributeName = linkEntity.LinkToAttributeName;
      linkEntity1.JoinOperator = linkEntity.JoinOperator;
      linkEntity1.LinkCriteria = filterExpression;
      linkEntity1.Columns = columnSet;
      linkEntity1.EntityAlias = linkEntity.EntityAlias;
      linkEntity1.ExtensionData = linkEntity.ExtensionData;
      linkEntity1.Orders.AddRange((IEnumerable<OrderExpression>) items1);
      linkEntity1.LinkEntities.AddRange((IEnumerable<LinkEntity>) items2);
      return linkEntity1;
    }

    protected virtual ConditionExpression VisitConditionExpression(
      ConditionExpression condition)
    {
      return condition;
    }

    protected virtual FilterExpression VisitFilterExpression(FilterExpression filter)
    {
      IReadOnlyList<FilterExpression> items1 = this.VisitAndConvert<FilterExpression>((IReadOnlyList<FilterExpression>) filter.Filters, new Func<FilterExpression, FilterExpression>(this.VisitFilterExpression));
      IReadOnlyList<ConditionExpression> items2 = this.VisitAndConvert<ConditionExpression>((IReadOnlyList<ConditionExpression>) filter.Conditions, new Func<ConditionExpression, ConditionExpression>(this.VisitConditionExpression));
      if (items1 == filter.Filters && items2 == filter.Conditions)
        return filter;
      FilterExpression filterExpression = new FilterExpression(filter.FilterOperator);
      filterExpression.IsQuickFindFilter = filter.IsQuickFindFilter;
      filterExpression.ExtensionData = filter.ExtensionData;
      filterExpression.Filters.AddRange((IEnumerable<FilterExpression>) items1);
      filterExpression.Conditions.AddRange((IEnumerable<ConditionExpression>) items2);
      return filterExpression;
    }

    protected virtual OrderExpression VisitOrderExpression(OrderExpression order) => order;

    protected virtual ColumnSet VisitColumnSet(ColumnSet columnSet) => columnSet;

    private IReadOnlyList<T> VisitAndConvert<T>(
      IReadOnlyList<T> nodes,
      Func<T, T> visit)
    {
      T[] list = (T[]) null;
      int index1 = 0;
      for (int count = nodes.Count; index1 < count; ++index1)
      {
        T obj = visit(nodes[index1]);
        if ((object) obj == null)
          throw new InvalidOperationException("Visit returned null");
        if (list != null)
          list[index1] = obj;
        else if ((object) obj != (object) nodes[index1])
        {
          list = new T[count];
          for (int index2 = 0; index2 < index1; ++index2)
            list[index2] = nodes[index2];
          list[index1] = obj;
        }
      }
      return list == null ? nodes : (IReadOnlyList<T>) new ReadOnlyCollection<T>((IList<T>) list);
    }
  }
}
