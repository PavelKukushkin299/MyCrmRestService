// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.ClientMetadataResults
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "ClientMetadataResults", Namespace = "http://schemas.microsoft.com/xrm/8.2/Contracts")]
  public sealed class ClientMetadataResults : IExtensibleDataObject
  {
    private List<ClientEntityMetadata> _entities;
    private List<ClientEntityMetadata> _relationshipNavigationEntities;
    private string _otherMetadata;
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public List<ClientEntityMetadata> Entities
    {
      get => this._entities;
      set => this._entities = value;
    }

    [DataMember]
    public List<ClientEntityMetadata> RelationshipNavigationEntities
    {
      get => this._relationshipNavigationEntities;
      set => this._relationshipNavigationEntities = value;
    }

    [DataMember]
    public string OtherMetadata
    {
      get => this._otherMetadata;
      set => this._otherMetadata = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
