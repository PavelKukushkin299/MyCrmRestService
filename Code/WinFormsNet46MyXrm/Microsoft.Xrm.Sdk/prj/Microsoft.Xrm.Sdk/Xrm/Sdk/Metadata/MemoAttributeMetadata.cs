// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.MemoAttributeMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "MemoAttributeMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  [MetadataName(LogicalCollectionName = "MemoAttributeDefinitions", LogicalName = "MemoAttributeMetadata")]
  public sealed class MemoAttributeMetadata : AttributeMetadata
  {
    public const int MinSupportedLength = 1;
    public const int MaxSupportedLength = 1048576;
    private StringFormat? _format;
    private Microsoft.Xrm.Sdk.Metadata.ImeMode? _imeMode;
    private int? _maxLength;
    private bool? _isLocalizable;

    public MemoAttributeMetadata()
      : this((string) null)
    {
    }

    public MemoAttributeMetadata(string schemaName)
      : base(AttributeTypeCode.Memo, schemaName)
    {
    }

    [DataMember]
    public StringFormat? Format
    {
      get => this._format;
      set => this._format = value;
    }

    [DataMember]
    public Microsoft.Xrm.Sdk.Metadata.ImeMode? ImeMode
    {
      get => this._imeMode;
      set => this._imeMode = value;
    }

    [DataMember]
    public int? MaxLength
    {
      get => this._maxLength;
      set => this._maxLength = value;
    }

    [DataMember(Order = 70)]
    public bool? IsLocalizable
    {
      get => this._isLocalizable;
      internal set => this._isLocalizable = value;
    }
  }
}
