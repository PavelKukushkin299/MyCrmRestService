// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.FilterExpression
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
  [DataContract(Name = "FilterExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class FilterExpression : IExtensibleDataObject
  {
    private LogicalOperator _filterOperator;
    private string _filterHint;
    private DataCollection<ConditionExpression> _conditions;
    private DataCollection<FilterExpression> _filters;
    private bool _isQuickFindFilter;
    private ExtensionDataObject _extensionDataObject;

    public FilterExpression()
    {
    }

    public FilterExpression(LogicalOperator filterOperator) => this.FilterOperator = filterOperator;

    [DataMember]
    public LogicalOperator FilterOperator
    {
      get => this._filterOperator;
      set => this._filterOperator = value;
    }

    [DataMember(EmitDefaultValue = false, Order = 82)]
    public string FilterHint
    {
      get => this._filterHint;
      set => this._filterHint = value;
    }

    [DataMember]
    public DataCollection<ConditionExpression> Conditions
    {
      get
      {
        if (this._conditions == null)
          this._conditions = new DataCollection<ConditionExpression>();
        return this._conditions;
      }
      private set => this._conditions = value;
    }

    [DataMember]
    public DataCollection<FilterExpression> Filters
    {
      get
      {
        if (this._filters == null)
          this._filters = new DataCollection<FilterExpression>();
        return this._filters;
      }
      private set => this._filters = value;
    }

    [DataMember(EmitDefaultValue = false, Order = 51)]
    public bool IsQuickFindFilter
    {
      get => this._isQuickFindFilter;
      set => this._isQuickFindFilter = value;
    }

    public void AddCondition(
      string attributeName,
      ConditionOperator conditionOperator,
      params object[] values)
    {
      this.Conditions.Add(new ConditionExpression(attributeName, conditionOperator, values));
    }

    public void AddCondition(
      string entityName,
      string attributeName,
      ConditionOperator conditionOperator,
      params object[] values)
    {
      this.Conditions.Add(new ConditionExpression(entityName, attributeName, conditionOperator, values));
    }

    public void AddCondition(
      string attributeName,
      ConditionOperator conditionOperator,
      bool compareColumns,
      object[] values)
    {
      this.Conditions.Add(new ConditionExpression(attributeName, conditionOperator, compareColumns, values));
    }

    public void AddCondition(
      string entityName,
      string attributeName,
      ConditionOperator conditionOperator,
      bool compareColumns,
      object[] values)
    {
      this.Conditions.Add(new ConditionExpression(entityName, attributeName, conditionOperator, compareColumns, values));
    }

    public void AddCondition(
      string attributeName,
      ConditionOperator conditionOperator,
      bool compareColumns,
      object value)
    {
      this.Conditions.Add(new ConditionExpression(attributeName, conditionOperator, (compareColumns ? 1 : 0) != 0, new object[1]
      {
        value
      }));
    }

    public void AddCondition(
      string entityName,
      string attributeName,
      ConditionOperator conditionOperator,
      bool compareColumns,
      object value)
    {
      this.Conditions.Add(new ConditionExpression(entityName, attributeName, conditionOperator, (compareColumns ? 1 : 0) != 0, new object[1]
      {
        value
      }));
    }

    public void AddCondition(ConditionExpression condition) => this.Conditions.Add(condition);

    public FilterExpression AddFilter(LogicalOperator logicalOperator)
    {
      FilterExpression filterExpression = new FilterExpression();
      filterExpression.FilterOperator = logicalOperator;
      this.Filters.Add(filterExpression);
      return filterExpression;
    }

    public void AddFilter(FilterExpression childFilter)
    {
      if (childFilter == null)
        return;
      this.Filters.Add(childFilter);
    }

    internal void Accept(IQueryVisitor visitor) => visitor.Visit(this);

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
