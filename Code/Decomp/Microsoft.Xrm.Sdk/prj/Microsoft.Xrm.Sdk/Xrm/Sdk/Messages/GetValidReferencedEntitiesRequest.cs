// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.GetValidReferencedEntitiesRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class GetValidReferencedEntitiesRequest : OrganizationRequest
  {
    public string ReferencingEntityName
    {
      get => this.Parameters.Contains(nameof (ReferencingEntityName)) ? (string) this.Parameters[nameof (ReferencingEntityName)] : (string) null;
      set => this.Parameters[nameof (ReferencingEntityName)] = (object) value;
    }

    public GetValidReferencedEntitiesRequest() => this.RequestName = "GetValidReferencedEntities";
  }
}
