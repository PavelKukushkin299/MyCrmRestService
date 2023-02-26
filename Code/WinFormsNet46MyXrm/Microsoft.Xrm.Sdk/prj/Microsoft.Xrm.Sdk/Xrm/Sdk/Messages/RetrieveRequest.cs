// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.RetrieveRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Query;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveRequest : OrganizationRequest
  {
    public EntityReference Target
    {
      get => this.Parameters.Contains(nameof (Target)) ? (EntityReference) this.Parameters[nameof (Target)] : (EntityReference) null;
      set => this.Parameters[nameof (Target)] = (object) value;
    }

    public ColumnSet ColumnSet
    {
      get => this.Parameters.Contains(nameof (ColumnSet)) ? (ColumnSet) this.Parameters[nameof (ColumnSet)] : (ColumnSet) null;
      set => this.Parameters[nameof (ColumnSet)] = (object) value;
    }

    public RelationshipQueryCollection RelatedEntitiesQuery
    {
      get => this.Parameters.Contains(nameof (RelatedEntitiesQuery)) ? (RelationshipQueryCollection) this.Parameters[nameof (RelatedEntitiesQuery)] : (RelationshipQueryCollection) null;
      set => this.Parameters[nameof (RelatedEntitiesQuery)] = (object) value;
    }

    public bool ReturnNotifications
    {
      get => this.Parameters.Contains(nameof (ReturnNotifications)) && (bool) this.Parameters[nameof (ReturnNotifications)];
      set => this.Parameters[nameof (ReturnNotifications)] = (object) value;
    }

    public RetrieveRequest()
    {
      this.RequestName = "Retrieve";
      this.Target = (EntityReference) null;
      this.ColumnSet = (ColumnSet) null;
    }
  }
}
