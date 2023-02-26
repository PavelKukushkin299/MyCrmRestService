// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.UpdatePointersRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "UpdatePointersRequest", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  public sealed class UpdatePointersRequest
  {
    [DataMember]
    public string Prefix { get; set; }

    [DataMember]
    public int StoragePointer { get; set; }

    [DataMember]
    public Guid FilePointer { get; set; }

    [DataMember]
    public long FileSize { get; set; }

    [DataMember]
    public int Otc { get; set; }

    [DataMember]
    public Guid TargetObjectId { get; set; }

    [DataMember]
    public bool SetBodyToNull { get; set; }

    public ExtensionDataObject ExtensionData { get; set; }
  }
}
