// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.ExecuteMultipleRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class ExecuteMultipleRequest : OrganizationRequest
  {
    public OrganizationRequestCollection Requests
    {
      get => this.Parameters.Contains(nameof (Requests)) ? (OrganizationRequestCollection) this.Parameters[nameof (Requests)] : (OrganizationRequestCollection) null;
      set => this.Parameters[nameof (Requests)] = (object) value;
    }

    public ExecuteMultipleSettings Settings
    {
      get => this.Parameters.Contains(nameof (Settings)) ? (ExecuteMultipleSettings) this.Parameters[nameof (Settings)] : (ExecuteMultipleSettings) null;
      set => this.Parameters[nameof (Settings)] = (object) value;
    }

    public ExecuteMultipleRequest()
    {
      this.RequestName = "ExecuteMultiple";
      this.Requests = (OrganizationRequestCollection) null;
      this.Settings = (ExecuteMultipleSettings) null;
    }
  }
}
