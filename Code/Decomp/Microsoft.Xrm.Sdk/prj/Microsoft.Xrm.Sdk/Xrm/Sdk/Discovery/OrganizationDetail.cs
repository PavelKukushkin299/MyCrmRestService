// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Discovery.OrganizationDetail
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Discovery
{
  [DataContract(Name = "OrganizationDetail", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Discovery")]
  public class OrganizationDetail : IExtensibleDataObject
  {
    private EndpointCollection _endpoints = new EndpointCollection();
    private Guid _organizationId;
    private string _friendlyName;
    private string _organizationVersion;
    private string _environmentId;
    private string _geo;
    private string _tenantId;
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public Guid OrganizationId
    {
      get => this._organizationId;
      set => this._organizationId = value;
    }

    [DataMember]
    public string FriendlyName
    {
      get => this._friendlyName;
      set => this._friendlyName = value;
    }

    [DataMember]
    public string OrganizationVersion
    {
      get => this._organizationVersion;
      set => this._organizationVersion = value;
    }

    [DataMember]
    public string EnvironmentId
    {
      get => this._environmentId;
      set => this._environmentId = value;
    }

    [DataMember]
    public string Geo
    {
      get => this._geo;
      set => this._geo = value;
    }

    [DataMember]
    public string TenantId
    {
      get => this._tenantId;
      set => this._tenantId = value;
    }

    [DataMember]
    public string UrlName { get; set; }

    [DataMember]
    public string UniqueName { get; set; }

    [DataMember]
    public EndpointCollection Endpoints
    {
      get => this._endpoints;
      internal set => this._endpoints = value;
    }

    [DataMember]
    public OrganizationState State { get; set; }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
