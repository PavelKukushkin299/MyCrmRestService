// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.LinkEntity
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
  [DataContract(Name = "LinkEntity", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class LinkEntity : IExtensibleDataObject
  {
    private string _linkFromEntityName;
    private string _linkFromAttributeName;
    private string _linkToEntityName;
    private string _linkToAttributeName;
    private JoinOperator _joinOperator;
    private FilterExpression _linkCriteria;
    private string _entityAlias;
    private ColumnSet _columns;
    private DataCollection<LinkEntity> _linkEntities;
    private DataCollection<OrderExpression> _orders;
    private ExtensionDataObject _extensionDataObject;

    public LinkEntity()
      : this((string) null, (string) null, (string) null, (string) null, JoinOperator.Inner)
    {
    }

    public LinkEntity(
      string linkFromEntityName,
      string linkToEntityName,
      string linkFromAttributeName,
      string linkToAttributeName,
      JoinOperator joinOperator)
    {
      this._linkFromEntityName = linkFromEntityName;
      this._linkToEntityName = linkToEntityName;
      this._linkFromAttributeName = linkFromAttributeName;
      this._linkToAttributeName = linkToAttributeName;
      this._joinOperator = joinOperator;
      this._columns = new ColumnSet();
      this._linkCriteria = new FilterExpression();
    }

    [DataMember]
    public string LinkFromAttributeName
    {
      get => this._linkFromAttributeName;
      set => this._linkFromAttributeName = value;
    }

    [DataMember]
    public string LinkFromEntityName
    {
      get => this._linkFromEntityName;
      set => this._linkFromEntityName = value;
    }

    [DataMember]
    public string LinkToEntityName
    {
      get => this._linkToEntityName;
      set => this._linkToEntityName = value;
    }

    [DataMember]
    public string LinkToAttributeName
    {
      get => this._linkToAttributeName;
      set => this._linkToAttributeName = value;
    }

    [DataMember]
    public JoinOperator JoinOperator
    {
      get => this._joinOperator;
      set => this._joinOperator = value;
    }

    [DataMember]
    public FilterExpression LinkCriteria
    {
      get => this._linkCriteria;
      set => this._linkCriteria = value;
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
    public ColumnSet Columns
    {
      get
      {
        if (this._columns == null)
          this._columns = new ColumnSet();
        return this._columns;
      }
      set => this._columns = value;
    }

    [DataMember]
    public string EntityAlias
    {
      get => this._entityAlias;
      set => this._entityAlias = value;
    }

    internal void Accept(IQueryVisitor visitor) => visitor.Visit(this);

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
      LinkEntity linkEntity = new LinkEntity(this._linkFromEntityName, linkToEntityName, linkFromAttributeName, linkToAttributeName, joinOperator);
      this.LinkEntities.Add(linkEntity);
      return linkEntity;
    }

    [DataMember(Order = 80)]
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

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
