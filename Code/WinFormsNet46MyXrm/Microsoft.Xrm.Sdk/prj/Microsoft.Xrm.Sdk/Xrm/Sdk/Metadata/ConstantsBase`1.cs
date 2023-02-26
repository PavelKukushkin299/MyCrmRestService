// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.ConstantsBase`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "ConstantsBase", Namespace = "http://schemas.microsoft.com/xrm/2013/Metadata")]
  [KnownType(typeof (DateTimeBehavior))]
  [KnownType(typeof (StringFormatName))]
  [KnownType(typeof (AttributeTypeDisplayName))]
  public abstract class ConstantsBase<T> : IExtensibleDataObject
  {
    protected static readonly IList<T> ValidValues = (IList<T>) new List<T>();
    private T _value;
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public T Value
    {
      get => this._value;
      set => this._value = value;
    }

    protected abstract bool ValueExistsInList(T value);

    protected static T2 Create<T2>(T value) where T2 : ConstantsBase<T>, new()
    {
      T2 obj = new T2();
      obj._value = value;
      return obj;
    }

    protected static T2 Add<T2>(T value) where T2 : ConstantsBase<T>, new()
    {
      ConstantsBase<T>.ValidValues.Add(value);
      return ConstantsBase<T>.Create<T2>(value);
    }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
