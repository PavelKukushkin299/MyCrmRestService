// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.ManagedProperty`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "ManagedProperty{0}", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  [KnownType(typeof (BooleanManagedProperty))]
  [KnownType(typeof (AttributeRequiredLevel))]
  public abstract class ManagedProperty<T> : IExtensibleDataObject
  {
    private T _value;
    private bool _canBeChanged;
    private string _logicalName;
    private ExtensionDataObject _extensionDataObject;

    protected ManagedProperty()
      : this((string) null)
    {
    }

    protected ManagedProperty(string managedPropertyLogicalName)
    {
      this._logicalName = managedPropertyLogicalName;
      this._canBeChanged = true;
    }

    [DataMember]
    public T Value
    {
      get => this._value;
      set => this._value = value;
    }

    [DataMember]
    public bool CanBeChanged
    {
      get => this._canBeChanged;
      set => this._canBeChanged = value;
    }

    [DataMember]
    public string ManagedPropertyLogicalName
    {
      get => this._logicalName;
      internal set => this._logicalName = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
