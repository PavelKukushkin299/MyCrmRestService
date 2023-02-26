// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.RetrieveEntityChangesRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Query;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveEntityChangesRequest : OrganizationRequest
  {
    public string EntityName
    {
      get => this.Parameters.Contains(nameof (EntityName)) ? (string) this.Parameters[nameof (EntityName)] : (string) null;
      set => this.Parameters[nameof (EntityName)] = (object) value;
    }

    public string DataVersion
    {
      get => this.Parameters.Contains(nameof (DataVersion)) ? (string) this.Parameters[nameof (DataVersion)] : (string) null;
      set => this.Parameters[nameof (DataVersion)] = (object) value;
    }

    public PagingInfo PageInfo
    {
      get => this.Parameters.Contains(nameof (PageInfo)) ? (PagingInfo) this.Parameters[nameof (PageInfo)] : (PagingInfo) null;
      set => this.Parameters[nameof (PageInfo)] = (object) value;
    }

    public ColumnSet Columns
    {
      get => this.Parameters.Contains(nameof (Columns)) ? (ColumnSet) this.Parameters[nameof (Columns)] : (ColumnSet) null;
      set => this.Parameters[nameof (Columns)] = (object) value;
    }

    public bool GetGlobalMetadataVersion
    {
      get => this.Parameters.Contains(nameof (GetGlobalMetadataVersion)) && (bool) this.Parameters[nameof (GetGlobalMetadataVersion)];
      set => this.Parameters[nameof (GetGlobalMetadataVersion)] = (object) value;
    }

    public RetrieveEntityChangesRequest()
    {
      this.RequestName = "RetrieveEntityChanges";
      this.EntityName = (string) null;
      this.DataVersion = (string) null;
      this.PageInfo = (PagingInfo) null;
      this.Columns = (ColumnSet) null;
    }
  }
}
