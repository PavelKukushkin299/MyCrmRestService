// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.MetadataBase
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "MetadataBase", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [KnownType(typeof (AttributeMetadata))]
  [KnownType(typeof (EntityMetadata))]
  [KnownType(typeof (OptionSetMetadata))]
  [KnownType(typeof (RelationshipMetadataBase))]
  public abstract class MetadataBase : IExtensibleDataObject
  {
    private Guid? _id;
    private bool? _hasChanged;
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public Guid? MetadataId
    {
      get => this._id;
      set => this._id = value;
    }

    [DataMember(Order = 60)]
    public bool? HasChanged
    {
      get => this._hasChanged;
      set => this._hasChanged = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
