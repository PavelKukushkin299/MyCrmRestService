// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.CreateEntityKeyRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class CreateEntityKeyRequest : OrganizationRequest
  {
    public EntityKeyMetadata EntityKey
    {
      get => this.Parameters.Contains(nameof (EntityKey)) ? (EntityKeyMetadata) this.Parameters[nameof (EntityKey)] : (EntityKeyMetadata) null;
      set => this.Parameters[nameof (EntityKey)] = (object) value;
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

    public CreateEntityKeyRequest()
    {
      this.RequestName = "CreateEntityKey";
      this.EntityKey = (EntityKeyMetadata) null;
      this.EntityName = (string) null;
    }
  }
}
