// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.ExecuteTransactionRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class ExecuteTransactionRequest : OrganizationRequest
  {
    public OrganizationRequestCollection Requests
    {
      get => this.Parameters.Contains(nameof (Requests)) ? (OrganizationRequestCollection) this.Parameters[nameof (Requests)] : (OrganizationRequestCollection) null;
      set => this.Parameters[nameof (Requests)] = (object) value;
    }

    public bool? ReturnResponses
    {
      get => this.Parameters.Contains(nameof (ReturnResponses)) ? (bool?) this.Parameters[nameof (ReturnResponses)] : new bool?();
      set => this.Parameters[nameof (ReturnResponses)] = (object) value;
    }

    public ExecuteTransactionRequest()
    {
      this.RequestName = "ExecuteTransaction";
      this.Requests = (OrganizationRequestCollection) null;
    }
  }
}
