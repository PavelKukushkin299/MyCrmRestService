﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Organization.OrganizationType
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Organization
{
  [DataContract(Name = "OrganizationType", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public enum OrganizationType
  {
    [EnumMember] Customer,
    [EnumMember] Monitoring,
    [EnumMember] Support,
    [EnumMember] BackEnd,
    [EnumMember] Secondary,
    [EnumMember] CustomerTest,
    [EnumMember] CustomerFreeTest,
    [EnumMember] CustomerPreview,
    [EnumMember] Placeholder,
    [EnumMember] TestDrive,
    [EnumMember] MsftInvestigation,
    [EnumMember] EmailTrial,
    [EnumMember] Default,
    [EnumMember] Developer,
    [EnumMember] Trial,
  }
}
