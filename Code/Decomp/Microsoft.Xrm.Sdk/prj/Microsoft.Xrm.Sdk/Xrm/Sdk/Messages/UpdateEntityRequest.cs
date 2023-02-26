// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.UpdateEntityRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class UpdateEntityRequest : OrganizationRequest
  {
    public EntityMetadata Entity
    {
      get => this.Parameters.Contains(nameof (Entity)) ? (EntityMetadata) this.Parameters[nameof (Entity)] : (EntityMetadata) null;
      set => this.Parameters[nameof (Entity)] = (object) value;
    }

    public bool MergeLabels
    {
      get => this.Parameters.Contains(nameof (MergeLabels)) && (bool) this.Parameters[nameof (MergeLabels)];
      set => this.Parameters[nameof (MergeLabels)] = (object) value;
    }

    public bool? HasNotes
    {
      get => this.Parameters.Contains(nameof (HasNotes)) ? (bool?) this.Parameters[nameof (HasNotes)] : new bool?();
      set => this.Parameters[nameof (HasNotes)] = (object) value;
    }

    public bool? HasFeedback
    {
      get => this.Parameters.Contains(nameof (HasFeedback)) ? (bool?) this.Parameters[nameof (HasFeedback)] : new bool?();
      set => this.Parameters[nameof (HasFeedback)] = (object) value;
    }

    public bool? HasActivities
    {
      get => this.Parameters.Contains(nameof (HasActivities)) ? (bool?) this.Parameters[nameof (HasActivities)] : new bool?();
      set => this.Parameters[nameof (HasActivities)] = (object) value;
    }

    public string SolutionUniqueName
    {
      get => this.Parameters.Contains(nameof (SolutionUniqueName)) ? (string) this.Parameters[nameof (SolutionUniqueName)] : (string) null;
      set => this.Parameters[nameof (SolutionUniqueName)] = (object) value;
    }

    public UpdateEntityRequest()
    {
      this.RequestName = "UpdateEntity";
      this.Entity = (EntityMetadata) null;
      this.MergeLabels = false;
    }
  }
}
