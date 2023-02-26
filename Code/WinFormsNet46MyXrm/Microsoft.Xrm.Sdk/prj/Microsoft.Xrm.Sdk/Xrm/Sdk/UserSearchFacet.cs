// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.UserSearchFacet
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "UserSearchFacet", Namespace = "http://schemas.microsoft.com/xrm/8.2/Contracts")]
  [Serializable]
  public sealed class UserSearchFacet : IExtensibleDataObject
  {
    private string attributeLogicalName;
    private string attributeTypeName;
    private string attributeDisplayName;
    private int facetOrder;
    [NonSerialized]
    private ExtensionDataObject _extensionDataObject;

    public UserSearchFacet()
    {
    }

    public UserSearchFacet(
      string attributeLogicalName,
      string attributeTypeName,
      string attributeDisplayName,
      int facetOrder)
    {
      this.attributeLogicalName = attributeLogicalName;
      this.attributeTypeName = attributeTypeName;
      this.attributeDisplayName = attributeDisplayName;
      this.facetOrder = facetOrder;
    }

    [DataMember]
    public string AttributeLogicalName
    {
      get => this.attributeLogicalName;
      internal set => this.attributeLogicalName = value;
    }

    [DataMember]
    public string AttributeTypeName
    {
      get => this.attributeTypeName;
      internal set => this.attributeTypeName = value;
    }

    [DataMember]
    public string AttributeDisplayName
    {
      get => this.attributeDisplayName;
      internal set => this.attributeDisplayName = value;
    }

    [DataMember]
    public int FacetOrder
    {
      get => this.facetOrder;
      internal set => this.facetOrder = value;
    }

    ExtensionDataObject IExtensibleDataObject.ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
