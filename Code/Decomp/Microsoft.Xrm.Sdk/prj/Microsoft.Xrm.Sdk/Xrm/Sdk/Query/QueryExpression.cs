// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.QueryExpression
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
  [DataContract(Name = "QueryExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class QueryExpression : QueryBase
  {
    public static readonly QueryExpression Empty = new QueryExpression();
    private ColumnSet _columnSet;
    private string _entityName;
    private string _queryHints;
    private bool _distinct;
    private bool _noLock;
    private PagingInfo _pageInfo;
    private DataCollection<LinkEntity> _linkEntities;
    private FilterExpression _criteria;
    private DataCollection<OrderExpression> _orders;
    private int? _topCount;

    public QueryExpression()
      : this((string) null)
    {
    }

    public QueryExpression(string entityName)
    {
      this._entityName = entityName;
      this._criteria = new FilterExpression();
      this._pageInfo = new PagingInfo();
      this._columnSet = new ColumnSet();
    }

    [DataMember]
    public bool Distinct
    {
      get => this._distinct;
      set => this._distinct = value;
    }

    [DataMember(Order = 50)]
    public bool NoLock
    {
      get => this._noLock;
      set => this._noLock = value;
    }

    [DataMember]
    public PagingInfo PageInfo
    {
      get => this._pageInfo;
      set => this._pageInfo = value;
    }

    [DataMember(EmitDefaultValue = false, Order = 92)]
    public string QueryHints
    {
      get => this._queryHints;
      set => this._queryHints = value;
    }

    [DataMember]
    public DataCollection<LinkEntity> LinkEntities
    {
      get
      {
        if (this._linkEntities == null)
          this._linkEntities = new DataCollection<LinkEntity>();
        return this._linkEntities;
      }
      private set => this._linkEntities = value;
    }

    [DataMember]
    public FilterExpression Criteria
    {
      get => this._criteria;
      set => this._criteria = value;
    }

    [DataMember]
    public DataCollection<OrderExpression> Orders
    {
      get
      {
        if (this._orders == null)
          this._orders = new DataCollection<OrderExpression>();
        return this._orders;
      }
      private set => this._orders = value;
    }

    [DataMember]
    public string EntityName
    {
      get => this._entityName;
      set => this._entityName = value;
    }

    [DataMember]
    public ColumnSet ColumnSet
    {
      get => this._columnSet;
      set => this._columnSet = value;
    }

    [DataMember(EmitDefaultValue = false, Order = 50)]
    public int? TopCount
    {
      get => this._topCount;
      set => this._topCount = value;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal override void Accept(IQueryVisitor visitor) => visitor.Visit(this);

    public QueryExpression Accept(IQueryExpressionVisitor visitor) => visitor.Visit(this);

    public void AddOrder(string attributeName, OrderType orderType) => this.Orders.Add(new OrderExpression(attributeName, orderType));

    public LinkEntity AddLink(
      string linkToEntityName,
      string linkFromAttributeName,
      string linkToAttributeName)
    {
      return this.AddLink(linkToEntityName, linkFromAttributeName, linkToAttributeName, JoinOperator.Inner);
    }

    public LinkEntity AddLink(
      string linkToEntityName,
      string linkFromAttributeName,
      string linkToAttributeName,
      JoinOperator joinOperator)
    {
      LinkEntity linkEntity = new LinkEntity(this.EntityName, linkToEntityName, linkFromAttributeName, linkToAttributeName, joinOperator);
      this.LinkEntities.Add(linkEntity);
      return linkEntity;
    }
  }
}
