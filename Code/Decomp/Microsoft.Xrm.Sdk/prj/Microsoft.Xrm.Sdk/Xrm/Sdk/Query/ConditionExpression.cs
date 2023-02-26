// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.ConditionExpression
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
  [DataContract(Name = "ConditionExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class ConditionExpression : IExtensibleDataObject
  {
    private string _attributeName;
    private ConditionOperator _conditionOperator;
    private DataCollection<object> _values;
    private string _entityName;
    private bool _compareColumns;
    internal bool IsDocumentBodyFilter;
    private ExtensionDataObject _extensionDataObject;

    public ConditionExpression()
    {
    }

    public ConditionExpression(
      string attributeName,
      ConditionOperator conditionOperator,
      params object[] values)
      : this((string) null, attributeName, conditionOperator, values)
    {
    }

    public ConditionExpression(
      string entityName,
      string attributeName,
      ConditionOperator conditionOperator,
      params object[] values)
    {
      this._entityName = entityName;
      this._attributeName = attributeName;
      this._conditionOperator = conditionOperator;
      if (values == null)
        return;
      this._values = new DataCollection<object>((IList<object>) values);
    }

    public ConditionExpression(
      string entityName,
      string attributeName,
      ConditionOperator conditionOperator,
      bool compareColumns,
      object[] values)
      : this(entityName, attributeName, conditionOperator, values)
    {
      this._compareColumns = compareColumns;
    }

    public ConditionExpression(
      string entityName,
      string attributeName,
      ConditionOperator conditionOperator,
      bool compareColumns,
      object value)
      : this(entityName, attributeName, conditionOperator, (compareColumns ? 1 : 0) != 0, new object[1]
      {
        value
      })
    {
    }

    public ConditionExpression(
      string attributeName,
      ConditionOperator conditionOperator,
      bool compareColumns,
      object value)
      : this((string) null, attributeName, conditionOperator, (compareColumns ? 1 : 0) != 0, new object[1]
      {
        value
      })
    {
    }

    public ConditionExpression(
      string attributeName,
      ConditionOperator conditionOperator,
      bool compareColumns,
      object[] values)
      : this((string) null, attributeName, conditionOperator, compareColumns, values)
    {
    }

    public ConditionExpression(
      string attributeName,
      ConditionOperator conditionOperator,
      object value)
      : this(attributeName, conditionOperator, new object[1]
      {
        value
      })
    {
    }

    public ConditionExpression(
      string entityName,
      string attributeName,
      ConditionOperator conditionOperator,
      object value)
      : this(entityName, attributeName, conditionOperator, new object[1]
      {
        value
      })
    {
    }

    public ConditionExpression(string attributeName, ConditionOperator conditionOperator)
      : this((string) null, attributeName, conditionOperator, Array.Empty<object>())
    {
    }

    public ConditionExpression(
      string entityName,
      string attributeName,
      ConditionOperator conditionOperator)
      : this(entityName, attributeName, conditionOperator, Array.Empty<object>())
    {
    }

    public ConditionExpression(
      string attributeName,
      ConditionOperator conditionOperator,
      ICollection values)
    {
      this._attributeName = attributeName;
      this._conditionOperator = conditionOperator;
      if (values == null)
        return;
      this._values = new DataCollection<object>();
      foreach (object obj in (IEnumerable) values)
        this._values.Add(obj);
    }

    [DataMember(Order = 60)]
    public string EntityName
    {
      get => this._entityName;
      set => this._entityName = value;
    }

    [DataMember]
    public bool CompareColumns
    {
      get => this._compareColumns;
      set => this._compareColumns = value;
    }

    [DataMember]
    public string AttributeName
    {
      get => this._attributeName;
      set => this._attributeName = value;
    }

    [DataMember]
    public ConditionOperator Operator
    {
      get => this._conditionOperator;
      set => this._conditionOperator = value;
    }

    [DataMember]
    public DataCollection<object> Values
    {
      get
      {
        if (this._values == null)
          this._values = new DataCollection<object>();
        return this._values;
      }
      private set => this._values = value;
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
