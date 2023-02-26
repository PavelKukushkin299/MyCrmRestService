// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.LookupDataRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "LookupDataRequest", Namespace = "http://schemas.microsoft.com/xrm/8.2/Contracts")]
  public sealed class LookupDataRequest : IExtensibleDataObject
  {
    private LookupEntityInfo[] _lookupEntityByName;
    private EntityAndAttribute _entityAndAttribute;
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public LookupEntityInfo[] LookupEntityByName
    {
      get => this._lookupEntityByName;
      set => this._lookupEntityByName = value;
    }

    [DataMember]
    public EntityAndAttribute EntityAndAttribute
    {
      get
      {
        if (this._entityAndAttribute == null)
          this._entityAndAttribute = new EntityAndAttribute();
        return this._entityAndAttribute;
      }
      set => this._entityAndAttribute = value;
    }

    [DataMember]
    public Guid? AppId { get; set; }

    [DataMember]
    public Guid? RelatedRecordId { get; set; }

    [DataMember]
    public string QueryString { get; set; }

    [DataMember]
    public bool ReturnMetadata { get; set; }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
