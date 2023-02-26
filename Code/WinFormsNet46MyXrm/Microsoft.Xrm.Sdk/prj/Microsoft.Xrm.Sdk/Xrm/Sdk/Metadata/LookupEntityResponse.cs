// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.LookupEntityResponse
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "LookupEntityResponse", Namespace = "http://schemas.microsoft.com/xrm/8.2/Contracts")]
  public sealed class LookupEntityResponse : IExtensibleDataObject
  {
    private LookupMetadata _metadata;
    private EntityCollection _data;
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public LookupMetadata Metadata
    {
      get
      {
        if (this._metadata == null)
          this._metadata = new LookupMetadata();
        return this._metadata;
      }
      set => this._metadata = value;
    }

    [DataMember]
    public string EntityLogicalName { get; set; }

    [DataMember]
    public EntityCollection Data
    {
      get
      {
        if (this._data == null)
          this._data = new EntityCollection();
        return this._data;
      }
      set => this._data = value;
    }

    [DataMember]
    public int TotalRecordCount { get; set; }

    [DataMember]
    public string PagingCookie { get; set; }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
