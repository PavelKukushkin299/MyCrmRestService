// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.CreateAttributeRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class CreateAttributeRequest : OrganizationRequest
  {
    public AttributeMetadata Attribute
    {
      get => this.Parameters.Contains(nameof (Attribute)) ? (AttributeMetadata) this.Parameters[nameof (Attribute)] : (AttributeMetadata) null;
      set => this.Parameters[nameof (Attribute)] = (object) value;
    }

    public string EntityName
    {
      get => this.Parameters.Contains(nameof (EntityName)) ? (string) this.Parameters[nameof (EntityName)] : (string) null;
      set => this.Parameters[nameof (EntityName)] = (object) value;
    }

    public string SolutionUniqueName
    {
      get => this.Parameters.Contains(nameof (SolutionUniqueName)) ? (string) this.Parameters[nameof (SolutionUniqueName)] : (string) null;
      set => this.Parameters[nameof (SolutionUniqueName)] = (object) value;
    }

    public CreateAttributeRequest()
    {
      this.RequestName = "CreateAttribute";
      this.Attribute = (AttributeMetadata) null;
      this.EntityName = (string) null;
    }
  }
}
