// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.FetchExpression
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
  [DataContract(Name = "FetchExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class FetchExpression : QueryBase
  {
    private string _query;

    public FetchExpression()
      : this((string) null)
    {
    }

    public FetchExpression(string query) => this._query = query;

    [DataMember]
    public string Query
    {
      get => this._query;
      set => this._query = value;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal override void Accept(IQueryVisitor visitor) => visitor.Visit(this);
  }
}
