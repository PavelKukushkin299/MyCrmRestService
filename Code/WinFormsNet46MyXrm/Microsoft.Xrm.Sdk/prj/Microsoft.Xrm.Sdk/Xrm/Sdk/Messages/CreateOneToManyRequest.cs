// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.CreateOneToManyRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class CreateOneToManyRequest : OrganizationRequest
  {
    public LookupAttributeMetadata Lookup
    {
      get => this.Parameters.Contains(nameof (Lookup)) ? (LookupAttributeMetadata) this.Parameters[nameof (Lookup)] : (LookupAttributeMetadata) null;
      set => this.Parameters[nameof (Lookup)] = (object) value;
    }

    public OneToManyRelationshipMetadata OneToManyRelationship
    {
      get => this.Parameters.Contains(nameof (OneToManyRelationship)) ? (OneToManyRelationshipMetadata) this.Parameters[nameof (OneToManyRelationship)] : (OneToManyRelationshipMetadata) null;
      set => this.Parameters[nameof (OneToManyRelationship)] = (object) value;
    }

    public string SolutionUniqueName
    {
      get => this.Parameters.Contains(nameof (SolutionUniqueName)) ? (string) this.Parameters[nameof (SolutionUniqueName)] : (string) null;
      set => this.Parameters[nameof (SolutionUniqueName)] = (object) value;
    }

    public CreateOneToManyRequest()
    {
      this.RequestName = "CreateOneToMany";
      this.Lookup = (LookupAttributeMetadata) null;
      this.OneToManyRelationship = (OneToManyRelationshipMetadata) null;
    }
  }
}
