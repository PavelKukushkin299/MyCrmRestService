// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.OrderExpression
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
  [DataContract(Name = "OrderExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class OrderExpression : IExtensibleDataObject
  {
    private string _attributeName;
    private OrderType _orderType;
    private string _alias;
    private ExtensionDataObject _extensionDataObject;

    public OrderExpression()
    {
    }

    public OrderExpression(string attributeName, OrderType orderType)
    {
      this._attributeName = attributeName;
      this._orderType = orderType;
    }

    public OrderExpression(string attributeName, OrderType orderType, string alias)
    {
      this._attributeName = attributeName;
      this._orderType = orderType;
      this._alias = alias;
    }

    [DataMember]
    public string AttributeName
    {
      get => this._attributeName;
      set => this._attributeName = value;
    }

    [DataMember]
    public OrderType OrderType
    {
      get => this._orderType;
      set => this._orderType = value;
    }

    [DataMember]
    public string Alias
    {
      get => this._alias;
      set => this._alias = value;
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
