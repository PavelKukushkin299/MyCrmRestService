// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.OptionSetMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "OptionSetMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalCollectionName = "OptionSetDefinitions", LogicalName = "OptionSetMetadata")]
  public sealed class OptionSetMetadata : OptionSetMetadataBase
  {
    private OptionMetadataCollection _options;

    public OptionSetMetadata()
    {
    }

    public OptionSetMetadata(OptionMetadataCollection options) => this._options = options;

    [DataMember]
    public OptionMetadataCollection Options
    {
      get
      {
        if (this._options == null)
          this._options = new OptionMetadataCollection();
        return this._options;
      }
      private set => this._options = value;
    }

    [DataMember(Order = 91)]
    public string ParentOptionSetName { get; set; }
  }
}
