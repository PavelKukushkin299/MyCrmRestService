// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.ClientEntityMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "ClientEntityMetadata", Namespace = "http://schemas.microsoft.com/xrm/8.2/Contracts")]
  public sealed class ClientEntityMetadata : IExtensibleDataObject
  {
    private EntityMetadata _entityMetadata;
    private string[] _attributeNames;
    private ExtensionDataObject _extensionDataObject;

    [DataMember(EmitDefaultValue = false)]
    public EntityMetadata EntityMetadata
    {
      get => this._entityMetadata;
      set => this._entityMetadata = value;
    }

    [DataMember(EmitDefaultValue = false)]
    public string[] AttributeNames
    {
      get => this._attributeNames;
      set => this._attributeNames = value;
    }

    [DataMember(EmitDefaultValue = false)]
    public EntityClientSetting EntityClientSetting { get; set; }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
