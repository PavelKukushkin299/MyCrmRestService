// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.SyncSubscriptionMetadataResponse
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/9.0/Metadata")]
  public sealed class SyncSubscriptionMetadataResponse
  {
    [DataMember(EmitDefaultValue = false, IsRequired = false, Order = 0)]
    public SubscriptionEntitiesMetadata Metadata { get; set; }

    [DataMember(EmitDefaultValue = false, IsRequired = false, Order = 1)]
    public string SyncToken { get; set; }

    [DataMember(EmitDefaultValue = false, IsRequired = false, Order = 2)]
    public bool IsFinalPage { get; set; }

    [DataMember(EmitDefaultValue = false, IsRequired = false, Order = 3)]
    public string MetadataVersion { get; set; }

    [DataMember(EmitDefaultValue = false, IsRequired = false, Order = 4)]
    public string ProfileVersion { get; set; }
  }
}
