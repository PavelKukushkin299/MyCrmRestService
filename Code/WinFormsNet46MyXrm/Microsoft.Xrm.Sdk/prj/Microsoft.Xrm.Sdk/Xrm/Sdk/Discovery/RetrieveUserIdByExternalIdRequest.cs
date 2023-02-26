// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Discovery.RetrieveUserIdByExternalIdRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Discovery
{
  [DataContract(Name = "RetrieveUserIdByExternalIdRequest", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Discovery")]
  public sealed class RetrieveUserIdByExternalIdRequest : DiscoveryRequest
  {
    private string _organizationName;
    private Guid _organizationId;
    private string _externalId;
    private string _release;

    [DataMember]
    public string ExternalId
    {
      get => this._externalId;
      set => this._externalId = value;
    }

    [DataMember]
    public string OrganizationName
    {
      get => this._organizationName;
      set => this._organizationName = value;
    }

    [DataMember]
    public Guid OrganizationId
    {
      get => this._organizationId;
      set => this._organizationId = value;
    }

    [DataMember]
    public string Release
    {
      get => this._release;
      set => this._release = value;
    }
  }
}
