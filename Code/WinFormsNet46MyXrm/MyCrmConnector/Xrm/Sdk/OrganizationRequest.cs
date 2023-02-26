﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.OrganizationRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace MyCrmConnector
{
  [DataContract(Name = "OrganizationRequest", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public class OrganizationRequest : IExtensibleDataObject
  {
    private ParameterCollection _propertyBag;
    private string _messageName;
    private Guid? _requestId;
    private ExtensionDataObject _extensionDataObject;

    public OrganizationRequest()
    {
    }

    public OrganizationRequest(string requestName) => this._messageName = requestName;

    [DataMember]
    public string RequestName
    {
      get => this._messageName;
      set => this._messageName = value;
    }

    public object this[string parameterName]
    {
      get => this.Parameters[parameterName];
      set => this.Parameters[parameterName] = value;
    }

    [DataMember]
    public ParameterCollection Parameters
    {
      get
      {
        if (this._propertyBag == null)
          this._propertyBag = new ParameterCollection();
        return this._propertyBag;
      }
      set => this._propertyBag = value;
    }

    [DataMember]
    public Guid? RequestId
    {
      get => this._requestId;
      set => this._requestId = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
