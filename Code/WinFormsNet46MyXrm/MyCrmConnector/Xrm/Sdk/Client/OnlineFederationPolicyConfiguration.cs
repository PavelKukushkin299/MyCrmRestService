// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.OnlineFederationPolicyConfiguration
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Linq;
using System.Security;
using System.Security.Permissions;

namespace MyCrmConnector.Client
{
  [SecuritySafeCritical]
  [SecurityPermission(SecurityAction.Demand, Unrestricted = true)]
  public sealed class OnlineFederationPolicyConfiguration : OnlinePolicyConfiguration
  {
    private object _lockObject = new object();

    internal OnlineFederationPolicyConfiguration(AuthenticationPolicy xrmPolicy)
      : base(xrmPolicy)
    {
            //if (!string.IsNullOrEmpty(PolicyHelper.GetPolicyValue(xrmPolicy, "LiveTrustLivePolicy", string.Empty)))
            //{
            //  LiveIdentityProviderTrustConfiguration trustConfiguration = new LiveIdentityProviderTrustConfiguration(xrmPolicy);
            //  this.OnlineProviders.Add(trustConfiguration.Endpoint.GetServiceRoot(), (IdentityProviderTrustConfiguration) trustConfiguration);
            //}
            //if (string.IsNullOrEmpty(PolicyHelper.GetPolicyValue(xrmPolicy, "OrgIdPolicy", string.Empty)))
            //  return;
            //OrgIdentityProviderTrustConfiguration trustConfiguration1 = new OrgIdentityProviderTrustConfiguration(xrmPolicy);
            //this.OnlineProviders.Add(trustConfiguration1.Endpoint.GetServiceRoot(), (IdentityProviderTrustConfiguration) trustConfiguration1);
            throw new NotImplementedException();
        }

    internal void InitializeLiveTrustConfiguration(IdentityProvider identityProvider)
    {
            //OrgIdentityProviderTrustConfiguration trustConfiguration1 = this.OnlineProviders.Values.OfType<OrgIdentityProviderTrustConfiguration>().FirstOrDefault<OrgIdentityProviderTrustConfiguration>();
            //if (trustConfiguration1 == null || string.IsNullOrWhiteSpace(trustConfiguration1.LivePartnerIdentifier) || this.OnlineProviders.Values.OfType<LiveIdentityProviderTrustConfiguration>().Any<LiveIdentityProviderTrustConfiguration>())
            //  return;
            //lock (this._lockObject)
            //{
            //  if (this.OnlineProviders.Values.OfType<LiveIdentityProviderTrustConfiguration>().Any<LiveIdentityProviderTrustConfiguration>())
            //    return;
            //  AuthenticationPolicy xrmPolicy = new AuthenticationPolicy();
            //  xrmPolicy.PolicyElements.Add("AppliesTo", trustConfiguration1.LivePartnerIdentifier);
            //  string absoluteUri = identityProvider.ServiceUrl.AbsoluteUri;
            //  xrmPolicy.PolicyElements["LiveEndpoint"] = absoluteUri;
            //  LiveIdentityProviderTrustConfiguration trustConfiguration2 = new LiveIdentityProviderTrustConfiguration(xrmPolicy);
            //  this.OnlineProviders.Add(new Uri(absoluteUri), (IdentityProviderTrustConfiguration) trustConfiguration2);
            //}
            throw new NotImplementedException();
        }
  }
}
