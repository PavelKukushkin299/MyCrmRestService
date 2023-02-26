// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.Query.DeletedMetadataFilters
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
  [Flags]
  [DataContract(Name = "DeletedMetadataFilters", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata/Query")]
  public enum DeletedMetadataFilters
  {
    [EnumMember(Value = "Entity")] Entity = 1,
    [EnumMember(Value = "Attribute")] Attribute = 2,
    [EnumMember(Value = "Relationship")] Relationship = 4,
    [EnumMember(Value = "Label")] Label = 8,
    [EnumMember(Value = "OptionSet")] OptionSet = 16, // 0x00000010
    Default = Entity, // 0x00000001
    All = Default | OptionSet | Label | Relationship | Attribute, // 0x0000001F
  }
}
