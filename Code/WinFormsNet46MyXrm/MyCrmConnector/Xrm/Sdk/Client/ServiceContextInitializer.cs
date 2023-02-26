// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.ServiceContextInitializer`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.ServiceModel;

namespace MyCrmConnector.Client
{
    internal abstract class ServiceContextInitializer<TService> : IDisposable where TService : class
    {
        private OperationContextScope _operationScope;

        protected ServiceContextInitializer(ServiceProxy<TService> proxy)
        {
            ClientExceptionHelper.ThrowIfNull((object)proxy, nameof(proxy));
            this.ServiceProxy = proxy;
            this.Initialize(proxy);
        }

        public ServiceProxy<TService> ServiceProxy { get; private set; }

        protected void Initialize(ServiceProxy<TService> proxy)
        {
            this._operationScope = new OperationContextScope((IContextChannel)(object)proxy.ServiceChannel.Channel);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize((object)this);
        }

        ~ServiceContextInitializer() => this.Dispose(false);

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing || this._operationScope == null)
                return;
            this._operationScope.Dispose();
        }
    }
}
