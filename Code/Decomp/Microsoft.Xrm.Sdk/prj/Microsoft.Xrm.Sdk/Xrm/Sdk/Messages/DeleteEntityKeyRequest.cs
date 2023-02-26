// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.DeleteEntityKeyRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class DeleteEntityKeyRequest : OrganizationRequest
  {
    public string Name
    {
      get => this.Parameters.Contains(nameof (Name)) ? (string) this.Parameters[nameof (Name)] : (string) null;
      set => this.Parameters[nameof (Name)] = (object) value;
    }

    public string EntityLogicalName
    {
      get => this.Parameters.Contains(nameof (EntityLogicalName)) ? (string) this.Parameters[nameof (EntityLogicalName)] : (string) null;
      set => this.Parameters[nameof (EntityLogicalName)] = (object) value;
    }

    public DeleteEntityKeyRequest()
    {
      this.RequestName = "DeleteEntityKey";
      this.Name = (string) null;
      this.EntityLogicalName = (string) null;
    }
  }
}
