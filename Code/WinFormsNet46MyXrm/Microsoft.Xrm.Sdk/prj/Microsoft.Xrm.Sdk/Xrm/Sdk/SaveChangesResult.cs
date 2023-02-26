// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.SaveChangesResult
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;

namespace Microsoft.Xrm.Sdk
{
  public sealed class SaveChangesResult
  {
    public OrganizationRequest Request { get; private set; }

    public OrganizationResponse Response { get; private set; }

    public Exception Error { get; private set; }

    internal SaveChangesResult(OrganizationRequest request, OrganizationResponse response)
    {
      this.Request = request;
      this.Response = response;
    }

    internal SaveChangesResult(OrganizationRequest request, Exception error)
    {
      this.Request = request;
      this.Error = error;
    }
  }
}
