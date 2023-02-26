// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.CreateCustomerRelationshipsRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/8.1/Contracts")]
  public sealed class CreateCustomerRelationshipsRequest : OrganizationRequest
  {
    public LookupAttributeMetadata Lookup
    {
      get => this.Parameters.Contains(nameof (Lookup)) ? (LookupAttributeMetadata) this.Parameters[nameof (Lookup)] : (LookupAttributeMetadata) null;
      set => this.Parameters[nameof (Lookup)] = (object) value;
    }

    public OneToManyRelationshipMetadata[] OneToManyRelationships
    {
      get => this.Parameters.Contains(nameof (OneToManyRelationships)) ? (OneToManyRelationshipMetadata[]) this.Parameters[nameof (OneToManyRelationships)] : (OneToManyRelationshipMetadata[]) null;
      set => this.Parameters[nameof (OneToManyRelationships)] = (object) value;
    }

    public string SolutionUniqueName
    {
      get => this.Parameters.Contains(nameof (SolutionUniqueName)) ? (string) this.Parameters[nameof (SolutionUniqueName)] : (string) null;
      set => this.Parameters[nameof (SolutionUniqueName)] = (object) value;
    }

    public CreateCustomerRelationshipsRequest()
    {
      this.RequestName = "CreateCustomerRelationships";
      this.Lookup = (LookupAttributeMetadata) null;
      this.OneToManyRelationships = (OneToManyRelationshipMetadata[]) null;
    }
  }
}
