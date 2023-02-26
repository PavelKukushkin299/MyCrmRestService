// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.SecurityTypes
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [Flags]
  [DataContract(Name = "SecurityTypes", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  public enum SecurityTypes
  {
    [EnumMember(Value = "None")] None = 0,
    [EnumMember(Value = "Append")] Append = 1,
    [EnumMember(Value = "ParentChild")] ParentChild = 2,
    [EnumMember(Value = "Pointer")] Pointer = 4,
    [EnumMember(Value = "Inheritance")] Inheritance = 8,
  }
}
