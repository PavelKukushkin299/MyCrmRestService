// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Organization.Solution
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Organization
{
  [DataContract(Name = "Solution", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public sealed class Solution : IExtensibleDataObject
  {
    [DataMember(IsRequired = true, Order = 1)]
    public Guid Id { get; set; }

    [DataMember(IsRequired = true, Order = 2)]
    public string VersionNumber { get; set; }

    [DataMember(IsRequired = true, Order = 3)]
    public string SolutionUniqueName { get; set; }

    [DataMember(IsRequired = true, Order = 4)]
    public string FriendlyName { get; set; }

    [DataMember(IsRequired = true, Order = 5)]
    public Guid PublisherId { get; set; }

    [DataMember(IsRequired = true, Order = 6)]
    public string PublisherIdName { get; set; }

    [DataMember(IsRequired = true, Order = 7)]
    public string PublisherUniqueName { get; set; }

    public ExtensionDataObject ExtensionData { get; set; }
  }
}
