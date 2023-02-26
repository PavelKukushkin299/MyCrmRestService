// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.ImportFileUploadResponse
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/8.2/Contracts")]
  public sealed class ImportFileUploadResponse : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public bool HasError { get; set; }

    [DataMember]
    public string ImportId { get; set; }

    [DataMember]
    public string FileName { get; set; }

    [DataMember]
    public string ImportFileId { get; set; }

    [DataMember]
    public string ImportType { get; set; }

    [DataMember]
    public string HeaderColumnIndexesToBeIgnoredCsv { get; set; }

    [DataMember]
    public string ErrorCode { get; set; }

    [DataMember]
    public string ErrorMessage { get; set; }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
