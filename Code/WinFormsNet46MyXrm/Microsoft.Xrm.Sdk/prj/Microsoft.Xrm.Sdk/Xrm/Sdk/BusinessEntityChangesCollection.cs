// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.BusinessEntityChangesCollection
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [CollectionDataContract(Name = "BusinessEntityChangesCollection", Namespace = "http://schemas.microsoft.com/xrm/7.1/Contracts")]
  public sealed class BusinessEntityChangesCollection : DataCollection<IChangedItem>
  {
    public BusinessEntityChangesCollection()
    {
    }

    public BusinessEntityChangesCollection(IList<IChangedItem> list)
      : base(list)
    {
    }
  }
}
