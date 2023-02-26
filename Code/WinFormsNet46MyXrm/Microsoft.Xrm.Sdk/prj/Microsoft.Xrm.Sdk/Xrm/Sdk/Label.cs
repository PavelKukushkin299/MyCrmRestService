// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Label
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "Label", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class Label : IExtensibleDataObject
  {
    private LocalizedLabelCollection _locLabels;
    private LocalizedLabel _userLocLabel;
    private ExtensionDataObject _extensionDataObject;

    public Label()
    {
    }

    public Label(string label, int languageCode)
    {
      this._locLabels = new LocalizedLabelCollection();
      this._locLabels.Add(new LocalizedLabel(label, languageCode));
    }

    public Label(LocalizedLabel userLocalizedLabel, LocalizedLabel[] labels)
    {
      this._userLocLabel = userLocalizedLabel;
      if (labels == null)
        return;
      this._locLabels = new LocalizedLabelCollection((IList<LocalizedLabel>) labels);
    }

    [DataMember]
    public LocalizedLabelCollection LocalizedLabels
    {
      get
      {
        if (this._locLabels == null)
          this._locLabels = new LocalizedLabelCollection();
        return this._locLabels;
      }
      private set => this._locLabels = value;
    }

    [DataMember]
    public LocalizedLabel UserLocalizedLabel
    {
      get => this._userLocLabel;
      set => this._userLocLabel = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
