// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.OptionSetMetadataBase
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "OptionSetMetadataBase", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [KnownType(typeof (OptionSetMetadata))]
  [KnownType(typeof (BooleanOptionSetMetadata))]
  [MetadataName(LogicalCollectionName = "GlobalOptionSetDefinitions", LogicalName = "OptionSetMetadataBase")]
  public abstract class OptionSetMetadataBase : MetadataBase
  {
    private Label _description;
    private Label _displayName;
    private bool? _isCustomOptionSet;
    private bool? _isGlobal;
    private bool? _isManaged;
    private string _name;
    private string _externalTypeName;
    private Microsoft.Xrm.Sdk.Metadata.OptionSetType? _optionSetType;
    private BooleanManagedProperty _isCustomizable;
    private string _introducedVersion;

    [DataMember]
    public Label Description
    {
      get => this._description;
      set => this._description = value;
    }

    [DataMember]
    public Label DisplayName
    {
      get => this._displayName;
      set => this._displayName = value;
    }

    [DataMember]
    public bool? IsCustomOptionSet
    {
      get => this._isCustomOptionSet;
      set => this._isCustomOptionSet = value;
    }

    [DataMember]
    public bool? IsGlobal
    {
      get => this._isGlobal;
      set => this._isGlobal = value;
    }

    [DataMember]
    public bool? IsManaged
    {
      get => this._isManaged;
      internal set => this._isManaged = value;
    }

    [DataMember]
    public BooleanManagedProperty IsCustomizable
    {
      get => this._isCustomizable;
      set => this._isCustomizable = value;
    }

    [DataMember]
    [Alternatekey]
    public string Name
    {
      get => this._name;
      set => this._name = value;
    }

    [DataMember]
    public string ExternalTypeName
    {
      get => this._externalTypeName;
      set => this._externalTypeName = value;
    }

    [DataMember]
    public Microsoft.Xrm.Sdk.Metadata.OptionSetType? OptionSetType
    {
      get => this._optionSetType;
      set => this._optionSetType = value;
    }

    [DataMember(Order = 60)]
    public string IntroducedVersion
    {
      get => this._introducedVersion;
      internal set => this._introducedVersion = value;
    }
  }
}
