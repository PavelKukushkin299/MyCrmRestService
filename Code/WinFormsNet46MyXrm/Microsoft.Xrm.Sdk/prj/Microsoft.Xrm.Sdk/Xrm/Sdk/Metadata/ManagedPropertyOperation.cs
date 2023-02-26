// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.ManagedPropertyOperation
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "ManagedPropertyOperation", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  public enum ManagedPropertyOperation
  {
    [EnumMember(Value = "None")] None = 0,
    [EnumMember(Value = "Create")] Create = 1,
    [EnumMember(Value = "Update")] Update = 2,
    [EnumMember(Value = "CreateUpdate")] CreateUpdate = 3,
    [EnumMember(Value = "Delete")] Delete = 4,
    [EnumMember(Value = "UpdateDelete")] UpdateDelete = 6,
    [EnumMember(Value = "All")] All = 7,
  }
}
