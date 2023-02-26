// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.LocalizedLabel
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "LocalizedLabel", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  [MetadataName(LogicalCollectionName = "LocalizedLabelDefinitions", LogicalName = "LocalizedLabel")]
  public sealed class LocalizedLabel : MetadataBase
  {
    private string _label;
    private int _languageCode;
    private bool? _isManaged;

    public LocalizedLabel()
    {
    }

    public LocalizedLabel(string label, int languageCode)
    {
      this.Label = label;
      this.LanguageCode = languageCode;
    }

    [DataMember]
    public string Label
    {
      get => this._label;
      set => this._label = value;
    }

    [DataMember]
    public int LanguageCode
    {
      get => this._languageCode;
      set => this._languageCode = value;
    }

    [DataMember]
    public bool? IsManaged
    {
      get => this._isManaged;
      internal set => this._isManaged = value;
    }
  }
}
