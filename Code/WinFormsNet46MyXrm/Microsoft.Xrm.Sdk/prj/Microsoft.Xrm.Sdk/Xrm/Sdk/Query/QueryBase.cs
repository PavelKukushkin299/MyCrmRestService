// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.QueryBase
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
  [KnownType(typeof (QueryExpression))]
  [KnownType(typeof (QueryByAttribute))]
  [KnownType(typeof (FetchExpression))]
  [DataContract(Name = "QueryBase", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public abstract class QueryBase : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal abstract void Accept(IQueryVisitor visitor);

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
