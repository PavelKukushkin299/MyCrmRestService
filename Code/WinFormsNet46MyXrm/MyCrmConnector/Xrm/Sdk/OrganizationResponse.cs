// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.OrganizationResponse
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace MyCrmConnector
{
  [DataContract(Name = "OrganizationResponse", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public class OrganizationResponse : IExtensibleDataObject
  {
    private ParameterCollection _propertyBag;
    private string _messageName;
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public string ResponseName
    {
      get => this._messageName;
      set => this._messageName = value;
    }

    public object this[string parameterName]
    {
      get => this.Results[parameterName];
      set => this.Results[parameterName] = value;
    }

    [DataMember]
    public ParameterCollection Results
    {
      get
      {
        if (this._propertyBag == null)
          this._propertyBag = new ParameterCollection();
        return this._propertyBag;
      }
      set => this._propertyBag = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
