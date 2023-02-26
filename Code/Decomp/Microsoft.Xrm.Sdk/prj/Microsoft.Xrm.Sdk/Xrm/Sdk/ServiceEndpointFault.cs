// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.ServiceEndpointFault
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "ServiceEndpointFault", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  [Serializable]
  public sealed class ServiceEndpointFault : IExtensibleDataObject
  {
    private string _message;
    private ErrorDetailCollection _details;
    [NonSerialized]
    private ExtensionDataObject _extensionDataObject;

    public ServiceEndpointFault()
    {
    }

    public ServiceEndpointFault(string message) => this._message = message;

    [DataMember]
    public string Message
    {
      get => this._message;
      set => this._message = value;
    }

    [DataMember]
    public ErrorDetailCollection ErrorDetails
    {
      get
      {
        if (this._details == null)
          this._details = new ErrorDetailCollection();
        return this._details;
      }
      set => this._details = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
