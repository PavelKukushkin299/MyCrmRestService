// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Query.ValidatorIssue
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
  [DataContract(Name = "ValidatorIssue", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public class ValidatorIssue
  {
    [DataMember]
    public int TypeCode { get; set; }

    [DataMember]
    public int Severity { get; set; }

    [DataMember]
    public string LocalizedMessageText { get; set; }

    [DataMember]
    public Dictionary<string, string> OptionalPropertyBag { get; set; }
  }
}
