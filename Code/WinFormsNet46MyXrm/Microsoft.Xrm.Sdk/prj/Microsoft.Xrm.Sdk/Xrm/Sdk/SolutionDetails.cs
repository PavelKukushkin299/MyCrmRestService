// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.SolutionDetails
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "SolutionDetails", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public class SolutionDetails
  {
    [DataMember]
    public string SolutionUniqueName { get; set; }

    [DataMember]
    public string SolutionFriendlyName { get; set; }

    [DataMember]
    public string SolutionDescription { get; set; }

    [DataMember]
    public string PublisherUniqueName { get; set; }

    [DataMember]
    public string PublisherFriendlyName { get; set; }

    [DataMember]
    public string PreviousSolutionUniqueName { get; set; }

    [DataMember]
    public string PreviousSolutionFriendlyName { get; set; }

    [DataMember]
    public string PreviousPublisherUniqueName { get; set; }

    [DataMember]
    public string PreviousPublisherFriendlyName { get; set; }

    [DataMember]
    public bool IsPatchSolution { get; set; }

    [DataMember]
    public bool IsManaged { get; set; }

    [DataMember]
    public bool PreviousIsManaged { get; set; }

    [DataMember]
    public string SolutionVersion { get; set; }

    [DataMember]
    public string PreviousSolutionVersion { get; set; }

    [DataMember]
    public List<string> PreviousPatchSolutionsNames { get; set; }
  }
}
