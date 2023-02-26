// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.RetrieveMetadataChangesResponse
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveMetadataChangesResponse : OrganizationResponse
  {
    public EntityMetadataCollection EntityMetadata => this.Results.Contains(nameof (EntityMetadata)) ? (EntityMetadataCollection) this.Results[nameof (EntityMetadata)] : (EntityMetadataCollection) null;

    public DeletedMetadataCollection DeletedMetadata => this.Results.Contains(nameof (DeletedMetadata)) ? (DeletedMetadataCollection) this.Results[nameof (DeletedMetadata)] : (DeletedMetadataCollection) null;

    public string ServerVersionStamp => this.Results.Contains(nameof (ServerVersionStamp)) ? (string) this.Results[nameof (ServerVersionStamp)] : (string) null;
  }
}
