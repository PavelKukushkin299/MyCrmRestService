// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.Query.MetadataFilterExpression
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Query;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
  [DataContract(Name = "MetadataFilterExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata/Query")]
  public sealed class MetadataFilterExpression : IExtensibleDataObject
  {
    private DataCollection<MetadataConditionExpression> _conditions;
    private DataCollection<MetadataFilterExpression> _filters;

    public ExtensionDataObject ExtensionData { get; set; }

    public MetadataFilterExpression()
    {
    }

    public MetadataFilterExpression(LogicalOperator filterOperator) => this.FilterOperator = filterOperator;

    [DataMember]
    public DataCollection<MetadataConditionExpression> Conditions
    {
      get => this._conditions ?? (this._conditions = new DataCollection<MetadataConditionExpression>());
      private set => this._conditions = value;
    }

    [DataMember]
    public LogicalOperator FilterOperator { get; set; }

    [DataMember]
    public DataCollection<MetadataFilterExpression> Filters
    {
      get => this._filters ?? (this._filters = new DataCollection<MetadataFilterExpression>());
      private set => this._filters = value;
    }
  }
}
