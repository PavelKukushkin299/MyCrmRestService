// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.DeleteRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class DeleteRequest : OrganizationRequest
  {
    public EntityReference Target
    {
      get => this.Parameters.Contains(nameof (Target)) ? (EntityReference) this.Parameters[nameof (Target)] : (EntityReference) null;
      set => this.Parameters[nameof (Target)] = (object) value;
    }

    public ConcurrencyBehavior ConcurrencyBehavior
    {
      get => this.Parameters.Contains(nameof (ConcurrencyBehavior)) ? (ConcurrencyBehavior) this.Parameters[nameof (ConcurrencyBehavior)] : ConcurrencyBehavior.Default;
      set => this.Parameters[nameof (ConcurrencyBehavior)] = (object) value;
    }

    public DeleteRequest()
    {
      this.RequestName = "Delete";
      this.Target = (EntityReference) null;
    }
  }
}
