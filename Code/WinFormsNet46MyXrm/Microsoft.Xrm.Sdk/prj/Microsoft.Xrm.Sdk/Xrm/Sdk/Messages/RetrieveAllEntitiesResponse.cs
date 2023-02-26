// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.RetrieveAllEntitiesResponse
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveAllEntitiesResponse : OrganizationResponse
  {
    public Microsoft.Xrm.Sdk.Metadata.EntityMetadata[] EntityMetadata => this.Results.Contains(nameof (EntityMetadata)) ? (Microsoft.Xrm.Sdk.Metadata.EntityMetadata[]) this.Results[nameof (EntityMetadata)] : (Microsoft.Xrm.Sdk.Metadata.EntityMetadata[]) null;

    public string Timestamp => this.Results.Contains(nameof (Timestamp)) ? (string) this.Results[nameof (Timestamp)] : (string) null;
  }
}
