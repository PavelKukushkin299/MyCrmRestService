﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.ExecuteMultipleResponse
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class ExecuteMultipleResponse : OrganizationResponse
  {
    public bool IsFaulted => this.Results.Contains(nameof (IsFaulted)) && (bool) this.Results[nameof (IsFaulted)];

    public ExecuteMultipleResponseItemCollection Responses => this.Results.Contains(nameof (Responses)) ? (ExecuteMultipleResponseItemCollection) this.Results[nameof (Responses)] : (ExecuteMultipleResponseItemCollection) null;
  }
}
