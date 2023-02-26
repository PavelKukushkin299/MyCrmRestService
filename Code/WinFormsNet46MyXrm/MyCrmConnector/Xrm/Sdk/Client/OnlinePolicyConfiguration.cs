// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.OnlinePolicyConfiguration
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Security;
using System.Security.Permissions;

namespace MyCrmConnector.Client
{
  [SecuritySafeCritical]
  [SecurityPermission(SecurityAction.Demand, Unrestricted = true)]
  public abstract class OnlinePolicyConfiguration : PolicyConfiguration
  {
    private IdentityProviderTypeDictionary _onlineProviders = new IdentityProviderTypeDictionary();

    public IdentityProviderTypeDictionary OnlineProviders => this._onlineProviders;

    internal OnlinePolicyConfiguration(AuthenticationPolicy xrmPolicy)
      : base(xrmPolicy)
    {
    }
  }
}
