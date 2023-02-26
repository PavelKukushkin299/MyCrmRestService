﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Discovery.DiscoveryResponse
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Discovery
{
  [DataContract(Name = "DiscoveryResponse", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Discovery")]
  [KnownType(typeof (RetrieveOrganizationResponse))]
  [KnownType(typeof (RetrieveOrganizationsResponse))]
  [KnownType(typeof (RetrieveUserIdByExternalIdResponse))]
  public abstract class DiscoveryResponse : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
