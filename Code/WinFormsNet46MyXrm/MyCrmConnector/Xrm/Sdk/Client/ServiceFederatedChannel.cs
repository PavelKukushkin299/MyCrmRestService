// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.ServiceFederatedChannel`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.IdentityModel.Tokens;
using System.Security;
using System.Security.Permissions;
using System.ServiceModel;

namespace MyCrmConnector.Client
{
  [SecuritySafeCritical]
  [SecurityPermission(SecurityAction.Demand, Unrestricted = true)]
  internal sealed class ServiceFederatedChannel<TChannel> : ServiceChannel<TChannel> where TChannel : class
  {
    private readonly SecurityToken _token;

    public ServiceFederatedChannel(ChannelFactory<TChannel> factory, SecurityToken token)
      : base(factory)
    {
      ClientExceptionHelper.ThrowIfNull((object) token, nameof (token));
      this._token = token;
    }

    [SecuritySafeCritical]
    protected override TChannel CreateChannel() => this.Factory.CreateChannelWithIssuedToken(this._token);
  }
}
