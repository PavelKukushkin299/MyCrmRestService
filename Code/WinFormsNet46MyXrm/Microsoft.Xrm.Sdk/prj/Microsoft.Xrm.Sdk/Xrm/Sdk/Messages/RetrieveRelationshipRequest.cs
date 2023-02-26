// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.RetrieveRelationshipRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveRelationshipRequest : OrganizationRequest
  {
    public Guid MetadataId
    {
      get => this.Parameters.Contains(nameof (MetadataId)) ? (Guid) this.Parameters[nameof (MetadataId)] : new Guid();
      set => this.Parameters[nameof (MetadataId)] = (object) value;
    }

    public string Name
    {
      get => this.Parameters.Contains(nameof (Name)) ? (string) this.Parameters[nameof (Name)] : (string) null;
      set => this.Parameters[nameof (Name)] = (object) value;
    }

    public bool RetrieveAsIfPublished
    {
      get => this.Parameters.Contains(nameof (RetrieveAsIfPublished)) && (bool) this.Parameters[nameof (RetrieveAsIfPublished)];
      set => this.Parameters[nameof (RetrieveAsIfPublished)] = (object) value;
    }

    public RetrieveRelationshipRequest()
    {
      this.RequestName = "RetrieveRelationship";
      this.MetadataId = new Guid();
      this.RetrieveAsIfPublished = false;
    }
  }
}
