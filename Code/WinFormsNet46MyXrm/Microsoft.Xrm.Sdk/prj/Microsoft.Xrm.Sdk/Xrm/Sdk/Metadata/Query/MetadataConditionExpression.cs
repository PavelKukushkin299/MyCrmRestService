// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.Query.MetadataConditionExpression
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
  [KnownType("GetKnownConditionValueTypes")]
  [DataContract(Name = "MetadataConditionExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata/Query")]
  public sealed class MetadataConditionExpression : IExtensibleDataObject
  {
    public MetadataConditionExpression()
    {
    }

    public MetadataConditionExpression(
      string propertyName,
      MetadataConditionOperator conditionOperator,
      object value)
    {
      this.PropertyName = propertyName;
      this.ConditionOperator = conditionOperator;
      this.Value = value;
    }

    [DataMember]
    public string PropertyName { get; set; }

    [DataMember]
    public MetadataConditionOperator ConditionOperator { get; set; }

    [DataMember]
    public object Value { get; set; }

    public ExtensionDataObject ExtensionData { get; set; }

    private static IEnumerable<Type> GetKnownConditionValueTypes() => (IEnumerable<Type>) KnownTypesProvider.GetKnownMetadataEnumTypes();
  }
}
