// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.ViewColumn
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "ViewColumn", Namespace = "http://schemas.microsoft.com/xrm/8.2/Contracts")]
  public sealed class ViewColumn : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public string EntityLogicalName { get; set; }

    [DataMember]
    public string AttributeLogicalName { get; set; }

    [DataMember]
    public string DataType { get; set; }

    [DataMember]
    public string Format { get; set; }

    [DataMember]
    public string Alias { get; set; }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
