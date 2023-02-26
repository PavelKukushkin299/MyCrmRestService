// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.AssociateRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class AssociateRequest : OrganizationRequest
  {
    public EntityReference Target
    {
      get => this.Parameters.Contains(nameof (Target)) ? (EntityReference) this.Parameters[nameof (Target)] : (EntityReference) null;
      set => this.Parameters[nameof (Target)] = (object) value;
    }

    public Relationship Relationship
    {
      get => this.Parameters.Contains(nameof (Relationship)) ? (Relationship) this.Parameters[nameof (Relationship)] : (Relationship) null;
      set => this.Parameters[nameof (Relationship)] = (object) value;
    }

    public EntityReferenceCollection RelatedEntities
    {
      get => this.Parameters.Contains(nameof (RelatedEntities)) ? (EntityReferenceCollection) this.Parameters[nameof (RelatedEntities)] : (EntityReferenceCollection) null;
      set => this.Parameters[nameof (RelatedEntities)] = (object) value;
    }

    public AssociateRequest()
    {
      this.RequestName = "Associate";
      this.Target = (EntityReference) null;
      this.Relationship = (Relationship) null;
      this.RelatedEntities = (EntityReferenceCollection) null;
    }
  }
}
