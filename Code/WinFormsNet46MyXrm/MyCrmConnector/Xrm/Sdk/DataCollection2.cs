// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.DataCollection`2
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Collections;
using System.Collections.Generic;

namespace MyCrmConnector
{
  [Serializable]
  public abstract class DataCollection<TKey, TValue> : 
    IEnumerable<KeyValuePair<TKey, TValue>>,
    IEnumerable
  {
    private IDictionary<TKey, TValue> _innerDictionary = (IDictionary<TKey, TValue>) new Dictionary<TKey, TValue>();
    private bool _isReadOnly;

    protected internal DataCollection(IDictionary<TKey, TValue> collection) => this._innerDictionary = collection;

    protected internal DataCollection()
    {
    }

    public void Add(KeyValuePair<TKey, TValue> item)
    {
      this.CheckIsReadOnly();
      this._innerDictionary.Add(item);
    }

    public void AddRange(params KeyValuePair<TKey, TValue>[] items)
    {
      this.CheckIsReadOnly();
      this.AddRange((IEnumerable<KeyValuePair<TKey, TValue>>) items);
    }

    public void AddRange(IEnumerable<KeyValuePair<TKey, TValue>> items)
    {
      if (items == null)
        return;
      this.CheckIsReadOnly();
      ICollection<KeyValuePair<TKey, TValue>> innerDictionary = (ICollection<KeyValuePair<TKey, TValue>>) this._innerDictionary;
      foreach (KeyValuePair<TKey, TValue> keyValuePair in items)
        innerDictionary.Add(keyValuePair);
    }

    public void Add(TKey key, TValue value)
    {
      this.CheckIsReadOnly();
      this._innerDictionary.Add(key, value);
    }

    public virtual TValue this[TKey key]
    {
      get => this._innerDictionary[key];
      set
      {
        this.CheckIsReadOnly();
        this._innerDictionary[key] = value;
      }
    }

    public void Clear()
    {
      this.CheckIsReadOnly();
      this._innerDictionary.Clear();
    }

    public bool Contains(TKey key) => this._innerDictionary.ContainsKey(key);

    public bool Contains(KeyValuePair<TKey, TValue> key) => this._innerDictionary.Contains(key);

    public bool TryGetValue(TKey key, out TValue value) => this._innerDictionary.TryGetValue(key, out value);

    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => this._innerDictionary.CopyTo(array, arrayIndex);

    public bool ContainsKey(TKey key) => this._innerDictionary.ContainsKey(key);

    public bool Remove(TKey key)
    {
      this.CheckIsReadOnly();
      return this._innerDictionary.Remove(key);
    }

    public bool Remove(KeyValuePair<TKey, TValue> item)
    {
      this.CheckIsReadOnly();
      return ((ICollection<KeyValuePair<TKey, TValue>>) this._innerDictionary).Remove(item);
    }

    public int Count => this._innerDictionary.Count;

    public ICollection<TKey> Keys => this._innerDictionary.Keys;

    public ICollection<TValue> Values => this._innerDictionary.Values;

    public virtual bool IsReadOnly
    {
      get => this._isReadOnly;
      internal set => this._isReadOnly = value;
    }

    internal void SetItemInternal(TKey key, TValue value) => this._innerDictionary[key] = value;

    internal void ClearInternal() => this._innerDictionary.Clear();

    internal bool RemoveInternal(TKey key) => this._innerDictionary.Remove(key);

    private void CheckIsReadOnly()
    {
      if (this.IsReadOnly)
        throw new InvalidOperationException("The collection is read-only.");
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => this._innerDictionary.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this._innerDictionary.GetEnumerator();

    private static IEnumerable<Type> GetKnownParameterTypes() => KnownTypesProvider.RetrieveKnownValueTypes();
  }
}
