// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Money
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "Money", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class Money : IExtensibleDataObject
  {
    private Decimal _value;
    private ExtensionDataObject _extensionDataObject;

    public Money()
    {
    }

    public Money(Decimal value) => this._value = value;

    [DataMember]
    public Decimal Value
    {
      get => this._value;
      set => this._value = value;
    }

    public override bool Equals(object obj)
    {
      if (!(obj is Money money))
        return false;
      return this == money || this._value.Equals(money._value);
    }

    public override int GetHashCode() => this._value.GetHashCode();

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
