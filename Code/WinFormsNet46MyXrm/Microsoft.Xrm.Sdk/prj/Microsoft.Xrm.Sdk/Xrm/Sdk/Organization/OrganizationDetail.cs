// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Organization.OrganizationDetail
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Organization
{
  [DataContract(Name = "OrganizationDetail", Namespace = "http://schemas.microsoft.com/xrm/2014/Contracts")]
  public class OrganizationDetail : IExtensibleDataObject
  {
    private EndpointCollection _endpoints = new EndpointCollection();
    private Guid _organizationId;
    private string _friendlyName;
    private string _organizationVersion;
    private ExtensionDataObject _extensionDataObject;

    public static OrganizationDetail FromDiscovery(Microsoft.Xrm.Sdk.Discovery.OrganizationDetail detail) => new OrganizationDetail()
    {
      OrganizationId = detail.OrganizationId,
      FriendlyName = detail.FriendlyName,
      OrganizationVersion = detail.OrganizationVersion,
      UrlName = detail.UrlName,
      UniqueName = detail.UniqueName,
      Endpoints = EndpointCollection.FromDiscovery(detail.Endpoints),
      State = (OrganizationState) detail.State,
      EnvironmentId = detail.EnvironmentId,
      Geo = detail.Geo,
      TenantId = detail.TenantId
    };

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
    public string EnvironmentId { get; set; }

    [DataMember]
    public string Geo { get; set; }

    [DataMember]
    public string TenantId { get; set; }

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
