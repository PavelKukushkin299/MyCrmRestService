// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.UpdateRelationshipRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class UpdateRelationshipRequest : OrganizationRequest
  {
    public RelationshipMetadataBase Relationship
    {
      get => this.Parameters.Contains(nameof (Relationship)) ? (RelationshipMetadataBase) this.Parameters[nameof (Relationship)] : (RelationshipMetadataBase) null;
      set => this.Parameters[nameof (Relationship)] = (object) value;
    }

    public bool MergeLabels
    {
      get => this.Parameters.Contains(nameof (MergeLabels)) && (bool) this.Parameters[nameof (MergeLabels)];
      set => this.Parameters[nameof (MergeLabels)] = (object) value;
    }

    public string SolutionUniqueName
    {
      get => this.Parameters.Contains(nameof (SolutionUniqueName)) ? (string) this.Parameters[nameof (SolutionUniqueName)] : (string) null;
      set => this.Parameters[nameof (SolutionUniqueName)] = (object) value;
    }

    public UpdateRelationshipRequest()
    {
      this.RequestName = "UpdateRelationship";
      this.Relationship = (RelationshipMetadataBase) null;
      this.MergeLabels = false;
    }
  }
}
