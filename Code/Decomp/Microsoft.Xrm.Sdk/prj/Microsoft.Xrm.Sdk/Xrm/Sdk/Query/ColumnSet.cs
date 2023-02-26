// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.ColumnSet
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
  [DataContract(Name = "ColumnSet", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class ColumnSet : IExtensibleDataObject
  {
    private bool _allColumns;
    private DataCollection<string> _columns;
    private DataCollection<XrmAttributeExpression> _attributeExpressions;
    private ExtensionDataObject _extensionDataObject;

    public ColumnSet() => this.HasLazyFileAttribute = false;

    public ColumnSet(bool allColumns)
    {
      this._allColumns = allColumns;
      this.HasLazyFileAttribute = false;
    }

    public ColumnSet(params string[] columns)
    {
      this._columns = new DataCollection<string>((IList<string>) columns);
      this.HasLazyFileAttribute = false;
    }

    public void AddColumns(params string[] columns)
    {
      foreach (string column in columns)
        this.Columns.Add(column);
    }

    public void AddColumn(string column) => this.Columns.Add(column);

    [DataMember]
    public bool AllColumns
    {
      get => this._allColumns;
      set => this._allColumns = value;
    }

    [DataMember]
    public DataCollection<string> Columns
    {
      get
      {
        if (this._columns == null)
          this._columns = new DataCollection<string>();
        return this._columns;
      }
    }

    [DataMember]
    public DataCollection<XrmAttributeExpression> AttributeExpressions
    {
      get
      {
        if (this._attributeExpressions == null)
          this._attributeExpressions = new DataCollection<XrmAttributeExpression>();
        return this._attributeExpressions;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal void Accept(IQueryVisitor visitor) => visitor.Visit(this);

    public bool HasLazyFileAttribute { get; set; }

    public string LazyFileAttributeEntityName { get; set; }

    public string LazyFileAttributeKey { get; set; }

    public Lazy<object> LazyFileAttributeValue { get; set; }

    public int LazyFileAttributeSizeLimit { get; set; }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
