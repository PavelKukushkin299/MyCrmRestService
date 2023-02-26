// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.Query.MetadataPropertiesExpression
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
  [DataContract(Name = "MetadataPropertiesExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata/Query")]
  public sealed class MetadataPropertiesExpression : IExtensibleDataObject
  {
    private DataCollection<string> _propertyNames;

    public MetadataPropertiesExpression()
    {
    }

    public MetadataPropertiesExpression(params string[] propertyNames) => this.PropertyNames.AddRange(propertyNames);

    public ExtensionDataObject ExtensionData { get; set; }

    [DataMember]
    public bool AllProperties { get; set; }

    [DataMember]
    public DataCollection<string> PropertyNames
    {
      get => this._propertyNames ?? (this._propertyNames = new DataCollection<string>());
      internal set => this._propertyNames = value;
    }
  }
}
