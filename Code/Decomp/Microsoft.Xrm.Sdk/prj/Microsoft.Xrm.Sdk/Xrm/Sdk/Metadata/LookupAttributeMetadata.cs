// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.LookupAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "LookupAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalCollectionName = "LookupAttributeDefinitions", LogicalName = "LookupAttributeMetadata")]
  public sealed class LookupAttributeMetadata : AttributeMetadata
  {
    private string[] _targets;

    public LookupAttributeMetadata()
      : this(new LookupFormat?())
    {
    }

    public LookupAttributeMetadata(LookupFormat? format)
      : base(AttributeTypeCode.Lookup)
    {
      this.Format = format;
    }

    [DataMember]
    public string[] Targets
    {
      get => this._targets;
      set => this._targets = value;
    }

    [DataMember]
    public LookupFormat? Format { get; set; }
  }
}
