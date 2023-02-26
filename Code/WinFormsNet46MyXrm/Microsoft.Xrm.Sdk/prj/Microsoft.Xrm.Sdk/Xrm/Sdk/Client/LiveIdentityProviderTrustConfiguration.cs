// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.LiveIdentityProviderTrustConfiguration
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Security;
using System.Security.Permissions;

namespace Microsoft.Xrm.Sdk.Client
{
  [SecuritySafeCritical]
  [SecurityPermission(SecurityAction.Demand, Unrestricted = true)]
  public sealed class LiveIdentityProviderTrustConfiguration : IdentityProviderTrustConfiguration
  {
    internal LiveIdentityProviderTrustConfiguration(AuthenticationPolicy xrmPolicy)
      : base(xrmPolicy)
    {
      this.AppliesTo = PolicyHelper.GetPolicyValue(this.XrmPolicy, "AppliesTo", "");
      this.Policy = PolicyHelper.GetPolicyValue(this.XrmPolicy, "LiveTrustLivePolicy", LiveIdAuthenticationConfiguration.DefaultPolicy);
      this.LiveIdAppliesTo = PolicyHelper.GetPolicyValue(this.XrmPolicy, "LiveIdAppliesTo", "http://Passport.NET/tb");
    }

    public override Uri Endpoint
    {
      get
      {
        string policyValue = PolicyHelper.GetPolicyValue(this.XrmPolicy, "LiveEndpoint", (string) null);
        return !string.IsNullOrWhiteSpace(policyValue) ? new Uri(policyValue) : (Uri) null;
      }
    }
  }
}
