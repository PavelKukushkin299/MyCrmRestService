// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.EntityFilters
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [Flags]
  [DataContract(Name = "EntityFilters", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  public enum EntityFilters
  {
    [EnumMember(Value = "Entity")] Entity = 1,
    [EnumMember(Value = "Attributes")] Attributes = 2,
    [EnumMember(Value = "Privileges")] Privileges = 4,
    [EnumMember(Value = "Relationships")] Relationships = 8,
    Default = Entity, // 0x00000001
    All = Default | Relationships | Privileges | Attributes, // 0x0000000F
  }
}
