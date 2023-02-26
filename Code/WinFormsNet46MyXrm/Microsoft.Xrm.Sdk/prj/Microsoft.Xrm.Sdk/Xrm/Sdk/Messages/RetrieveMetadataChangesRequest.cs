// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.RetrieveMetadataChangesRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Metadata.Query;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveMetadataChangesRequest : OrganizationRequest
  {
    public EntityQueryExpression Query
    {
      get => this.Parameters.Contains(nameof (Query)) ? (EntityQueryExpression) this.Parameters[nameof (Query)] : (EntityQueryExpression) null;
      set => this.Parameters[nameof (Query)] = (object) value;
    }

    public DeletedMetadataFilters DeletedMetadataFilters
    {
      get => this.Parameters.Contains(nameof (DeletedMetadataFilters)) ? (DeletedMetadataFilters) this.Parameters[nameof (DeletedMetadataFilters)] : (DeletedMetadataFilters) 0;
      set => this.Parameters[nameof (DeletedMetadataFilters)] = (object) value;
    }

    public string ClientVersionStamp
    {
      get => this.Parameters.Contains(nameof (ClientVersionStamp)) ? (string) this.Parameters[nameof (ClientVersionStamp)] : (string) null;
      set => this.Parameters[nameof (ClientVersionStamp)] = (object) value;
    }

    public bool RetrieveAllSettings
    {
      get => this.Parameters.Contains(nameof (RetrieveAllSettings)) && (bool) this.Parameters[nameof (RetrieveAllSettings)];
      set => this.Parameters[nameof (RetrieveAllSettings)] = (object) value;
    }

    public RetrieveMetadataChangesRequest() => this.RequestName = "RetrieveMetadataChanges";
  }
}
