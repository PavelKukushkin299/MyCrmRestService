// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.LookupMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "LookupMetadata", Namespace = "http://schemas.microsoft.com/xrm/8.2/Contracts")]
  public sealed class LookupMetadata : IExtensibleDataObject
  {
    private LookupEntityMetadata _entity;
    private LookupView _view;
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public LookupEntityMetadata Entity
    {
      get
      {
        if (this._entity == null)
          this._entity = new LookupEntityMetadata();
        return this._entity;
      }
      set => this._entity = value;
    }

    [DataMember]
    public LookupView View
    {
      get
      {
        if (this._view == null)
          this._view = new LookupView();
        return this._view;
      }
      set => this._view = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
