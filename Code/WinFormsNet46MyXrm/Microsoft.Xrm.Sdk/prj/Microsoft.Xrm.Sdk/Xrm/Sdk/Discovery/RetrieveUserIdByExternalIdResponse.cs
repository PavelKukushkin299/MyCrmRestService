﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Discovery.RetrieveUserIdByExternalIdResponse
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Discovery
{
  [DataContract(Name = "RetrieveUserIdByExternalIdResponse", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Discovery")]
  public sealed class RetrieveUserIdByExternalIdResponse : DiscoveryResponse
  {
    private Guid _userId;

    [DataMember]
    public Guid UserId
    {
      get => this._userId;
      set => this._userId = value;
    }
  }
}
