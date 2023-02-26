// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.DataCollection`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Microsoft.Xrm.Sdk
{
  [Serializable]
  public class DataCollection<T> : Collection<T>
  {
    internal DataCollection()
    {
    }

    internal DataCollection(IList<T> list) => this.AddRange((IEnumerable<T>) list);

    public void AddRange(params T[] items)
    {
      if (items == null)
        return;
      this.AddRange((IEnumerable<T>) items);
    }

    public void AddRange(IEnumerable<T> items)
    {
      if (items == null)
        return;
      foreach (T obj in items)
        this.Add(obj);
    }

    public T[] ToArray()
    {
      T[] array = new T[this.Count];
      this.CopyTo(array, 0);
      return array;
    }
  }
}
