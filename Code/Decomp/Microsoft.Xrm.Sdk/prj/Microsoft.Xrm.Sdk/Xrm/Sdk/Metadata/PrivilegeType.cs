// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.PrivilegeType
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "PrivilegeType", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  public enum PrivilegeType
  {
    [EnumMember(Value = "None")] None,
    [EnumMember(Value = "Create")] Create,
    [EnumMember(Value = "Read")] Read,
    [EnumMember(Value = "Write")] Write,
    [EnumMember(Value = "Delete")] Delete,
    [EnumMember(Value = "Assign")] Assign,
    [EnumMember(Value = "Share")] Share,
    [EnumMember(Value = "Append")] Append,
    [EnumMember(Value = "AppendTo")] AppendTo,
  }
}
