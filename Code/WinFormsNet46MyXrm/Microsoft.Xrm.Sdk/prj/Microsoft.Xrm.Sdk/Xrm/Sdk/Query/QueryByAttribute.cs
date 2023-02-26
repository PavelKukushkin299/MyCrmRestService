// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.QueryByAttribute
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
  [DataContract(Name = "QueryByAttribute", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class QueryByAttribute : QueryBase
  {
    private string _entityName;
    private DataCollection<string> _attributes;
    private DataCollection<object> _attributeValues;
    private PagingInfo _pageInfo;
    private ColumnSet _columnSet;
    private DataCollection<OrderExpression> _orders;
    private int? _topCount;

    public QueryByAttribute()
    {
      this._columnSet = new ColumnSet();
      this._pageInfo = new PagingInfo();
    }

    public QueryByAttribute(string entityName) => this.EntityName = entityName;

    [DataMember]
    public string EntityName
    {
      get => this._entityName;
      set => this._entityName = value;
    }

    [DataMember]
    public DataCollection<string> Attributes
    {
      get
      {
        if (this._attributes == null)
          this._attributes = new DataCollection<string>();
        return this._attributes;
      }
      private set => this._attributes = value;
    }

    [DataMember]
    public DataCollection<object> Values
    {
      get
      {
        if (this._attributeValues == null)
          this._attributeValues = new DataCollection<object>();
        return this._attributeValues;
      }
      private set => this._attributeValues = value;
    }

    [DataMember]
    public PagingInfo PageInfo
    {
      get => this._pageInfo;
      set => this._pageInfo = value;
    }

    [DataMember]
    public ColumnSet ColumnSet
    {
      get => this._columnSet;
      set => this._columnSet = value;
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

    [DataMember(Order = 50)]
    public int? TopCount
    {
      get => this._topCount;
      set => this._topCount = value;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal override void Accept(IQueryVisitor visitor) => visitor.Visit(this);

    public void AddOrder(string attributeName, OrderType orderType) => this.Orders.Add(new OrderExpression(attributeName, orderType));

    public void AddAttributeValue(string attributeName, object value)
    {
      this.Attributes.Add(attributeName);
      this.Values.Add(value);
    }
  }
}
