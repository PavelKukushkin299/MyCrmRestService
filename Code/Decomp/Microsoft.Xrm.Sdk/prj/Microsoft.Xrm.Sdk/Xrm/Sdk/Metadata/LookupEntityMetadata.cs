// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.LookupEntityMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "LookupEntityMetadata", Namespace = "http://schemas.microsoft.com/xrm/8.2/Contracts")]
  public sealed class LookupEntityMetadata : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public bool IsReadOnlyInMobileClient { get; set; }

    [DataMember]
    public bool IsEnabledInUnifiedInterface { get; set; }

    [DataMember]
    public string DisplayName { get; set; }

    [DataMember]
    public string PrimaryNameAttribute { get; set; }

    [DataMember]
    public string PrimaryIdAttribute { get; set; }

    [DataMember]
    public string LogicalName { get; set; }

    [DataMember]
    public string DisplayCollectionName { get; set; }

    [DataMember]
    public string IconVectorName { get; set; }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
