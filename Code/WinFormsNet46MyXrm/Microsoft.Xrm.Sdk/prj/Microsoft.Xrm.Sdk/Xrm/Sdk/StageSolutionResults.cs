// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.StageSolutionResults
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "StageSolutionResults", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public sealed class StageSolutionResults : IExtensibleDataObject
  {
    [DataMember]
    public Guid StageSolutionUploadId { get; set; }

    [DataMember]
    public List<SolutionComponentDetails> SolutionComponentsDetails { get; set; }

    [DataMember]
    public SolutionDetails SolutionDetails { get; set; }

    [DataMember]
    public List<MissingDependency> MissingDependencies { get; set; }

    [DataMember]
    public StageSolutionStatus StageSolutionStatus { get; set; }

    [DataMember]
    public List<SolutionValidationResult> SolutionValidationResults { get; set; }

    public ExtensionDataObject ExtensionData { get; set; }
  }
}
