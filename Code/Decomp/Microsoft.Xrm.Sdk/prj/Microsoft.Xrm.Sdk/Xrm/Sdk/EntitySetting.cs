// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.EntitySetting
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "EntitySetting", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class EntitySetting : IExtensibleDataObject
  {
    private string _name;
    private Entity _value;
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public string Name
    {
      get => this._name;
      set => this._name = value;
    }

    [DataMember]
    public Entity Value
    {
      get => this._value;
      set => this._value = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
