// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.WebServiceClient.DiscoveryWebProxyClient
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Discovery;
using System;

namespace Microsoft.Xrm.Sdk.WebServiceClient
{
  public class DiscoveryWebProxyClient : WebProxyClient<IDiscoveryService>, IDiscoveryService
  {
    public DiscoveryWebProxyClient(Uri serviceUrl)
      : base(serviceUrl, Utilites.DefaultTimeout, false)
    {
    }

    public DiscoveryWebProxyClient(Uri serviceUrl, TimeSpan timeout)
      : base(serviceUrl, timeout, false)
    {
    }

    public DiscoveryResponse Execute(DiscoveryRequest request) => this.ExecuteCore(request);

    protected override WebProxyClientContextInitializer<IDiscoveryService> CreateNewInitializer() => (WebProxyClientContextInitializer<IDiscoveryService>) new DiscoveryWebProxyClientContextInitializer(this);

    protected internal virtual DiscoveryResponse ExecuteCore(
      DiscoveryRequest request)
    {
      return this.ExecuteAction<DiscoveryResponse>((Func<DiscoveryResponse>) (() => this.Channel.Execute(request)));
    }
  }
}
