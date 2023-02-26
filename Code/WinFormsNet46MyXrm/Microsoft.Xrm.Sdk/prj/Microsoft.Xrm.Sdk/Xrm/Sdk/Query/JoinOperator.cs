// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.JoinOperator
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
  [DataContract(Name = "JoinOperator", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public enum JoinOperator
  {
    [EnumMember] Inner,
    [EnumMember] LeftOuter,
    [EnumMember] Natural,
    [EnumMember] MatchFirstRowUsingCrossApply,
    [EnumMember] In,
    [EnumMember] Exists,
    [EnumMember] Any,
    [EnumMember] NotAny,
    [EnumMember] All,
    [EnumMember] NotAll,
  }
}
