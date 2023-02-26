// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.InsertStatusValueRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class InsertStatusValueRequest : OrganizationRequest
  {
    public string OptionSetName
    {
      get => this.Parameters.Contains(nameof (OptionSetName)) ? (string) this.Parameters[nameof (OptionSetName)] : (string) null;
      set => this.Parameters[nameof (OptionSetName)] = (object) value;
    }

    public string AttributeLogicalName
    {
      get => this.Parameters.Contains(nameof (AttributeLogicalName)) ? (string) this.Parameters[nameof (AttributeLogicalName)] : (string) null;
      set => this.Parameters[nameof (AttributeLogicalName)] = (object) value;
    }

    public string EntityLogicalName
    {
      get => this.Parameters.Contains(nameof (EntityLogicalName)) ? (string) this.Parameters[nameof (EntityLogicalName)] : (string) null;
      set => this.Parameters[nameof (EntityLogicalName)] = (object) value;
    }

    public int? Value
    {
      get => this.Parameters.Contains(nameof (Value)) ? (int?) this.Parameters[nameof (Value)] : new int?();
      set => this.Parameters[nameof (Value)] = (object) value;
    }

    public Label Label
    {
      get => this.Parameters.Contains(nameof (Label)) ? (Label) this.Parameters[nameof (Label)] : (Label) null;
      set => this.Parameters[nameof (Label)] = (object) value;
    }

    public Label Description
    {
      get => this.Parameters.Contains(nameof (Description)) ? (Label) this.Parameters[nameof (Description)] : (Label) null;
      set => this.Parameters[nameof (Description)] = (object) value;
    }

    public int StateCode
    {
      get => this.Parameters.Contains(nameof (StateCode)) ? (int) this.Parameters[nameof (StateCode)] : 0;
      set => this.Parameters[nameof (StateCode)] = (object) value;
    }

    public string SolutionUniqueName
    {
      get => this.Parameters.Contains(nameof (SolutionUniqueName)) ? (string) this.Parameters[nameof (SolutionUniqueName)] : (string) null;
      set => this.Parameters[nameof (SolutionUniqueName)] = (object) value;
    }

    public InsertStatusValueRequest()
    {
      this.RequestName = "InsertStatusValue";
      this.Label = (Label) null;
      this.StateCode = 0;
    }
  }
}
