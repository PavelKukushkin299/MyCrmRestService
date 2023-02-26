// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.PolicyConfiguration
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

namespace MyCrmConnector.Client
{
  public abstract class PolicyConfiguration
  {
    internal PolicyConfiguration(AuthenticationPolicy xrmPolicy)
    {
      this.XrmPolicy = xrmPolicy;
      this.Initialize();
    }

    private void Initialize() => this.SecureTokenServiceIdentifier = PolicyHelper.GetPolicyValue(this.XrmPolicy, "SecureTokenServiceIdentifier", string.Empty);

    internal AuthenticationPolicy XrmPolicy { get; private set; }

    public string SecureTokenServiceIdentifier { get; private set; }
  }
}
