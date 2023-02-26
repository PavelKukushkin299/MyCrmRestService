﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.Query.LabelQueryExpression
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
  [DataContract(Name = "LabelQueryExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata/Query")]
  public sealed class LabelQueryExpression : MetadataQueryBase
  {
    private DataCollection<int> _filterLanguages;
    private int? _missingLabelBehavior;

    [DataMember]
    public DataCollection<int> FilterLanguages
    {
      get => this._filterLanguages ?? (this._filterLanguages = new DataCollection<int>());
      private set => this._filterLanguages = value;
    }

    [DataMember(Order = 60)]
    public int? MissingLabelBehavior
    {
      get => this._missingLabelBehavior;
      set => this._missingLabelBehavior = value;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal override void Accept(IMetadataQueryExpressionVisitor visitor) => visitor.Visit(this);
  }
}
