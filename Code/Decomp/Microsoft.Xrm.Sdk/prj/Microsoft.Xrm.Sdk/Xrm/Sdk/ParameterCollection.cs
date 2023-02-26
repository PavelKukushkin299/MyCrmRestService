// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.ParameterCollection
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [KnownType("GetKnownParameterTypes")]
  [CollectionDataContract(Name = "ParameterCollection", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public class ParameterCollection : DataCollection<string, object>
  {
    public ParameterCollection()
    {
    }

    protected ParameterCollection(IDictionary<string, object> collection)
      : base(collection)
    {
    }

    public void AddOrUpdateIfNotNull(string key, object obj)
    {
      if (obj == null)
        return;
      this[key] = obj;
    }

    private static IEnumerable<Type> GetKnownParameterTypes() => KnownTypesProvider.RetrieveKnownValueTypes();
  }
}
