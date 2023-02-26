// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.WebServiceClient.WebProxyClientContextInitializer`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.Xrm.Sdk.WebServiceClient
{
  public abstract class WebProxyClientContextInitializer<TService> : IDisposable where TService : class
  {
    private OperationContextScope _operationScope;

    protected WebProxyClientContextInitializer(WebProxyClient<TService> proxy)
    {
      this.ServiceProxy = proxy;
      this.Initialize((ClientBase<TService>) proxy);
    }

    public WebProxyClient<TService> ServiceProxy { get; private set; }

    protected void AddTokenToHeaders()
    {
      HttpRequestMessageProperty requestMessageProperty = new HttpRequestMessageProperty();
      requestMessageProperty.Headers[HttpRequestHeader.Authorization.ToString()] = "Bearer " + this.ServiceProxy.HeaderToken;
      OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = (object) requestMessageProperty;
    }

    protected void AddCommonHeaders()
    {
      if (!string.IsNullOrEmpty(this.ServiceProxy.ClientAppName))
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("ClientAppName", "http://schemas.microsoft.com/xrm/2011/Contracts", (object) this.ServiceProxy.ClientAppName));
      if (!string.IsNullOrEmpty(this.ServiceProxy.ClientAppVersion))
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("ClientAppVersion", "http://schemas.microsoft.com/xrm/2011/Contracts", (object) this.ServiceProxy.ClientAppVersion));
      if (!string.IsNullOrEmpty(this.ServiceProxy.SdkClientVersion))
      {
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("SdkClientVersion", "http://schemas.microsoft.com/xrm/2011/Contracts", (object) this.ServiceProxy.SdkClientVersion));
      }
      else
      {
        string assemblyFileVersion = this.ServiceProxy.GetXrmSdkAssemblyFileVersion();
        if (string.IsNullOrEmpty(assemblyFileVersion))
          return;
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("SdkClientVersion", "http://schemas.microsoft.com/xrm/2011/Contracts", (object) assemblyFileVersion));
      }
    }

    protected void Initialize(ClientBase<TService> proxy) => this._operationScope = new OperationContextScope((IContextChannel) proxy.InnerChannel);

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposing || this._operationScope == null)
        return;
      this._operationScope.Dispose();
    }

    ~WebProxyClientContextInitializer() => this.Dispose(false);
  }
}
