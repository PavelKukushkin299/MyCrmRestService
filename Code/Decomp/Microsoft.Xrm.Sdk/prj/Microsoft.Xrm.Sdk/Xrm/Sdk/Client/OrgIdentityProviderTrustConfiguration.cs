// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.OrgIdentityProviderTrustConfiguration
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
  public sealed class OrgIdentityProviderTrustConfiguration : IdentityProviderTrustConfiguration
  {
    internal OrgIdentityProviderTrustConfiguration(AuthenticationPolicy xrmPolicy)
      : base(xrmPolicy)
    {
      this.AppliesTo = PolicyHelper.GetPolicyValue(this.XrmPolicy, "OrgIdAppliesTo", "");
      this.Policy = PolicyHelper.GetPolicyValue(this.XrmPolicy, "OrgIdPolicy", LiveIdAuthenticationConfiguration.DefaultPolicy);
      this.LiveIdAppliesTo = PolicyHelper.GetPolicyValue(this.XrmPolicy, "OrgIdDeviceAppliesTo", "http://Passport.NET/tb");
    }

    public override Uri Endpoint
    {
      get
      {
        string policyValue = PolicyHelper.GetPolicyValue(this.XrmPolicy, "OrgIdEndpoint", (string) null);
        return !string.IsNullOrWhiteSpace(policyValue) ? new Uri(policyValue) : (Uri) null;
      }
    }

    public Uri Identifier
    {
      get
      {
        string policyValue = PolicyHelper.GetPolicyValue(this.XrmPolicy, "OrgIdIdentifier", (string) null);
        return !string.IsNullOrWhiteSpace(policyValue) ? new Uri(policyValue) : (Uri) null;
      }
    }

    public string LivePartnerIdentifier => PolicyHelper.GetPolicyValue(this.XrmPolicy, nameof (LivePartnerIdentifier), (string) null);
  }
}
