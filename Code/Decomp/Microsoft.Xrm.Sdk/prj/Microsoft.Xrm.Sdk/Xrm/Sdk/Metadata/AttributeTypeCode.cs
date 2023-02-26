// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.AttributeTypeCode
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "AttributeTypeCode", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  public enum AttributeTypeCode
  {
    [EnumMember(Value = "Boolean")] Boolean,
    [EnumMember(Value = "Customer")] Customer,
    [EnumMember(Value = "DateTime")] DateTime,
    [EnumMember(Value = "Decimal")] Decimal,
    [EnumMember(Value = "Double")] Double,
    [EnumMember(Value = "Integer")] Integer,
    [EnumMember(Value = "Lookup")] Lookup,
    [EnumMember(Value = "Memo")] Memo,
    [EnumMember(Value = "Money")] Money,
    [EnumMember(Value = "Owner")] Owner,
    [EnumMember(Value = "PartyList")] PartyList,
    [EnumMember(Value = "Picklist")] Picklist,
    [EnumMember(Value = "State")] State,
    [EnumMember(Value = "Status")] Status,
    [EnumMember(Value = "String")] String,
    [EnumMember(Value = "Uniqueidentifier")] Uniqueidentifier,
    [EnumMember(Value = "CalendarRules")] CalendarRules,
    [EnumMember(Value = "Virtual")] Virtual,
    [EnumMember(Value = "BigInt")] BigInt,
    [EnumMember(Value = "ManagedProperty")] ManagedProperty,
    [EnumMember(Value = "EntityName")] EntityName,
  }
}
