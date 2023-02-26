// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.EntityReference
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "EntityReference", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  [Serializable]
  public sealed class EntityReference : IExtensibleDataObject
  {
    private string _logicalName;
    private string _name;
    private Guid _id;
    private KeyAttributeCollection _keyCollection;
    private string _rowVersion;
    [NonSerialized]
    private ExtensionDataObject _extensionDataObject;

    public EntityReference()
    {
    }

    public EntityReference(string logicalName) => this._logicalName = logicalName;

    public EntityReference(string logicalName, Guid id)
    {
      this._logicalName = logicalName;
      this._id = id;
    }

    public EntityReference(string logicalName, string keyName, object keyValue)
    {
      this._logicalName = logicalName;
      this.KeyAttributes.Add(new KeyValuePair<string, object>(keyName, keyValue));
    }

    public EntityReference(string logicalName, KeyAttributeCollection keyAttributeCollection)
    {
      this._logicalName = logicalName;
      this._keyCollection = keyAttributeCollection;
    }

    [DataMember]
    public Guid Id
    {
      get => this._id;
      set => this._id = value;
    }

    [DataMember]
    public string LogicalName
    {
      get => this._logicalName;
      set => this._logicalName = value;
    }

    [DataMember]
    public string Name
    {
      get => this._name;
      set => this._name = value;
    }

    [DataMember]
    public KeyAttributeCollection KeyAttributes
    {
      get
      {
        if (this._keyCollection == null)
          this._keyCollection = new KeyAttributeCollection();
        return this._keyCollection;
      }
      set => this._keyCollection = value;
    }

    [DataMember]
    public string RowVersion
    {
      get => this._rowVersion;
      set => this._rowVersion = value;
    }

    public override bool Equals(object obj)
    {
      if (!(obj is EntityReference entityReference))
        return false;
      if (this == entityReference)
        return true;
      return this._id.Equals(entityReference._id) && string.Compare(this._logicalName, entityReference._logicalName, StringComparison.Ordinal) == 0 && this.KeyAttributes.Count == entityReference.KeyAttributes.Count && this.KeyAttributes.Intersect<KeyValuePair<string, object>>((IEnumerable<KeyValuePair<string, object>>) entityReference.KeyAttributes).Count<KeyValuePair<string, object>>() == this.KeyAttributes.Count;
    }

    public override int GetHashCode()
    {
      int hashCode = string.IsNullOrEmpty(this._logicalName) ? 0 : this._logicalName.GetHashCode() ^ this._id.GetHashCode();
      foreach (KeyValuePair<string, object> keyAttribute in (DataCollection<string, object>) this.KeyAttributes)
        hashCode ^= string.IsNullOrEmpty(keyAttribute.Key) ? 0 : keyAttribute.Key.GetHashCode() ^ keyAttribute.Value.GetHashCode();
      return hashCode;
    }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
