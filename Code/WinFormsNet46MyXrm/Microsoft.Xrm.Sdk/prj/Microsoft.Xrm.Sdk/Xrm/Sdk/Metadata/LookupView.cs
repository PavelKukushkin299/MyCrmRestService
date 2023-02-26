﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.LookupView
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "LookupView", Namespace = "http://schemas.microsoft.com/xrm/8.2/Contracts")]
  public sealed class LookupView : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public Guid? ViewId { get; set; }

    [DataMember]
    public string ViewName { get; set; }

    [DataMember]
    public ViewColumn[] Columns { get; set; }

    [DataMember]
    public string FetchXml { get; set; }

    [DataMember]
    public string LayoutJson { get; set; }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
