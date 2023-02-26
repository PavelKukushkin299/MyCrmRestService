// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Discovery.ClientInfo
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;

namespace Microsoft.Xrm.Sdk.Discovery
{
  public sealed class ClientInfo
  {
    private Guid[] _patchIds;
    private ClientTypes _clientType;
    private Guid _userId;
    private Guid _organizationId;
    private int _languageCode;
    private string _officeVersion;
    private string _osVersion;
    private string _crmVersion;

    public Guid[] PatchIds
    {
      get => this._patchIds;
      set => this._patchIds = value;
    }

    public ClientTypes ClientType
    {
      get => this._clientType;
      set => this._clientType = value;
    }

    public Guid UserId
    {
      get => this._userId;
      set => this._userId = value;
    }

    public Guid OrganizationId
    {
      get => this._organizationId;
      set => this._organizationId = value;
    }

    public int LanguageCode
    {
      get => this._languageCode;
      set => this._languageCode = value;
    }

    public string OfficeVersion
    {
      get => this._officeVersion;
      set => this._officeVersion = value;
    }

    public string OSVersion
    {
      get => this._osVersion;
      set => this._osVersion = value;
    }

    public string CrmVersion
    {
      get => this._crmVersion;
      set => this._crmVersion = value;
    }
  }
}
