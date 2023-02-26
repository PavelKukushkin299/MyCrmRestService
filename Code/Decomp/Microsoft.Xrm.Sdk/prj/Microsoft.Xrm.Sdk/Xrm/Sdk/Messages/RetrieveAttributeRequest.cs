﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.RetrieveAttributeRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveAttributeRequest : OrganizationRequest
  {
    public string EntityLogicalName
    {
      get => this.Parameters.Contains(nameof (EntityLogicalName)) ? (string) this.Parameters[nameof (EntityLogicalName)] : (string) null;
      set => this.Parameters[nameof (EntityLogicalName)] = (object) value;
    }

    public string LogicalName
    {
      get => this.Parameters.Contains(nameof (LogicalName)) ? (string) this.Parameters[nameof (LogicalName)] : (string) null;
      set => this.Parameters[nameof (LogicalName)] = (object) value;
    }

    public int ColumnNumber
    {
      get => this.Parameters.Contains(nameof (ColumnNumber)) ? (int) this.Parameters[nameof (ColumnNumber)] : 0;
      set => this.Parameters[nameof (ColumnNumber)] = (object) value;
    }

    public Guid MetadataId
    {
      get => this.Parameters.Contains(nameof (MetadataId)) ? (Guid) this.Parameters[nameof (MetadataId)] : new Guid();
      set => this.Parameters[nameof (MetadataId)] = (object) value;
    }

    public bool RetrieveAsIfPublished
    {
      get => this.Parameters.Contains(nameof (RetrieveAsIfPublished)) && (bool) this.Parameters[nameof (RetrieveAsIfPublished)];
      set => this.Parameters[nameof (RetrieveAsIfPublished)] = (object) value;
    }

    public RetrieveAttributeRequest()
    {
      this.RequestName = "RetrieveAttribute";
      this.MetadataId = new Guid();
      this.RetrieveAsIfPublished = false;
    }
  }
}
