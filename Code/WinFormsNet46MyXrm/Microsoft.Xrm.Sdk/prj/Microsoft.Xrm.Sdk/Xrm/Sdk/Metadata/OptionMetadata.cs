// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.OptionMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "OptionMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [KnownType(typeof (StateOptionMetadata))]
  [KnownType(typeof (StatusOptionMetadata))]
  [MetadataName(LogicalCollectionName = "OptionDefinitions", LogicalName = "OptionMetadata")]
  public class OptionMetadata : MetadataBase
  {
    private int? _optionValue;
    private Label _label;
    private Label _description;
    private string _color;
    private bool? _isManaged;
    private int[] _parentValues;
    private string _externalValue;

    public OptionMetadata() => this._externalValue = string.Empty;

    public OptionMetadata(int value)
      : this()
    {
      this.Value = new int?(value);
    }

    public OptionMetadata(int value, IEnumerable<int> parentOptionValues)
      : this((Label) null, new int?(value), parentOptionValues)
    {
    }

    public OptionMetadata(Label label, int? value)
    {
      this.Label = label;
      this.Value = value;
    }

    public OptionMetadata(Label label, int? value, IEnumerable<int> parentOptionValues)
    {
      this.Label = label;
      this.Value = value;
      this._externalValue = string.Empty;
      if (parentOptionValues == null)
        return;
      if (!(parentOptionValues is int[] numArray))
        numArray = parentOptionValues.ToArray<int>();
      this.ParentValues = numArray;
    }

    [DataMember]
    public int? Value
    {
      get => this._optionValue;
      set => this._optionValue = value;
    }

    [DataMember]
    public Label Label
    {
      get => this._label;
      set => this._label = value;
    }

    [DataMember]
    public Label Description
    {
      get => this._description;
      set => this._description = value;
    }

    [DataMember]
    public string Color
    {
      get => this._color;
      set => this._color = value;
    }

    [DataMember]
    public bool? IsManaged
    {
      get => this._isManaged;
      internal set => this._isManaged = value;
    }

    [DataMember]
    public string ExternalValue
    {
      get => this._externalValue;
      set => this._externalValue = value;
    }

    [DataMember(Order = 91)]
    public int[] ParentValues
    {
      get => this._parentValues;
      set => this._parentValues = value;
    }
  }
}
