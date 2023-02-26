// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.AliasedValue
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [KnownType("GetKnownAliasedValueTypes")]
  [DataContract(Name = "AliasedValue", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class AliasedValue : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    public AliasedValue()
    {
    }

    public AliasedValue(string entityLogicalName, string attributeLogicalName, object value)
    {
      this.AttributeLogicalName = attributeLogicalName;
      this.EntityLogicalName = entityLogicalName;
      this.Value = value;
    }

    [DataMember]
    public string AttributeLogicalName { get; internal set; }

    [DataMember]
    public string EntityLogicalName { get; internal set; }

    [DataMember]
    public object Value { get; internal set; }

    internal bool NeedFormatting { get; set; }

    internal int ReturnType { get; set; }

    private static IEnumerable<Type> GetKnownAliasedValueTypes()
    {
      List<Type> knownTypes = new List<Type>();
      KnownTypesProvider.AddKnownAttributeTypes(knownTypes);
      return (IEnumerable<Type>) knownTypes;
    }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
