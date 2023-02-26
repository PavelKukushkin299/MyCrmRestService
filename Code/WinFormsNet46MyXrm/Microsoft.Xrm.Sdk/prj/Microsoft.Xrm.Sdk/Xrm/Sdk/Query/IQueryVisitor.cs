// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.IQueryVisitor
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.ComponentModel;

namespace Microsoft.Xrm.Sdk.Query
{
  [EditorBrowsable(EditorBrowsableState.Never)]
  internal interface IQueryVisitor
  {
    void Visit(QueryExpression query);

    void Visit(QueryByAttribute query);

    void Visit(FetchExpression query);

    void Visit(ColumnSet columnSet);

    void Visit(PagingInfo pageInfo);

    void Visit(OrderExpression order);

    void Visit(LinkEntity linkEntity);

    void Visit(FilterExpression filter);

    void Visit(ConditionExpression condition);
  }
}
