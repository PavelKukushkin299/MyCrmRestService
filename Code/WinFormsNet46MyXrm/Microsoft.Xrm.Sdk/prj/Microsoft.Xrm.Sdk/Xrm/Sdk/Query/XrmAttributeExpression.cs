// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.XrmAttributeExpression
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
  [DataContract(Name = "AttributeExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class XrmAttributeExpression : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;
    private XrmAggregateType _aggregateType;
    private string _attributeName;
    private string _alias;
    private bool _hasGroupBy;
    private XrmDateTimeGrouping _dateTimeGroupingType;

    public XrmAttributeExpression()
      : this((string) null, XrmAggregateType.None, (string) null)
    {
    }

    public XrmAttributeExpression(string attributeName) => this._attributeName = attributeName;

    public XrmAttributeExpression(string attributeName, XrmAggregateType aggregateType) => this._attributeName = attributeName;

    public XrmAttributeExpression(
      string attributeName,
      XrmAggregateType aggregateType,
      string alias)
    {
      this._attributeName = attributeName;
      this._aggregateType = aggregateType;
      this._alias = alias;
    }

    public XrmAttributeExpression(
      string attributeName,
      XrmAggregateType aggregateType,
      string alias,
      XrmDateTimeGrouping dateTimeGrouping)
    {
      this._attributeName = attributeName;
      this._aggregateType = aggregateType;
      this._alias = alias;
      this._dateTimeGroupingType = dateTimeGrouping;
    }

    [DataMember]
    public string AttributeName
    {
      get => this._attributeName;
      set => this._attributeName = value;
    }

    [DataMember]
    public XrmAggregateType AggregateType
    {
      get => this._aggregateType;
      set => this._aggregateType = value;
    }

    [DataMember]
    public string Alias
    {
      get => this._alias;
      set => this._alias = value;
    }

    [DataMember]
    public bool HasGroupBy
    {
      get => this._hasGroupBy;
      set => this._hasGroupBy = value;
    }

    [DataMember]
    public XrmDateTimeGrouping DateTimeGrouping
    {
      get => this._dateTimeGroupingType;
      set => this._dateTimeGroupingType = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
