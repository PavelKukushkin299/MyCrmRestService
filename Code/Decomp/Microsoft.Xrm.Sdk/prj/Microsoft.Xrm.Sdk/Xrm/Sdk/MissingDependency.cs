// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.MissingDependency
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "MissingDependency", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public class MissingDependency
  {
    [DataMember]
    public string RequiredComponentSchemaName { get; set; }

    [DataMember]
    public string RequiredComponentDisplayName { get; set; }

    [DataMember]
    public string RequiredComponentParentSchemaName { get; set; }

    [DataMember]
    public string RequiredComponentParentDisplayName { get; set; }

    [DataMember]
    public Guid RequiredComponentId { get; set; }

    [DataMember]
    public string RequiredSolutionName { get; set; }

    [DataMember]
    public string RequiredComponentType { get; set; }

    [DataMember]
    public string DependentComponentSchemaName { get; set; }

    [DataMember]
    public string DependentComponentDisplayName { get; set; }

    [DataMember]
    public string DependentComponentParentSchemaName { get; set; }

    [DataMember]
    public string DependentComponentParentDisplayName { get; set; }

    [DataMember]
    public string DependentComponentType { get; set; }

    [DataMember]
    public Guid DependentComponentId { get; set; }
  }
}
