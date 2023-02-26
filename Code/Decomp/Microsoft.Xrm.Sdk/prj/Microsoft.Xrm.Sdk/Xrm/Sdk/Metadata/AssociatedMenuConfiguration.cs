// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.AssociatedMenuConfiguration
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "AssociatedMenuConfiguration", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
  public sealed class AssociatedMenuConfiguration : IExtensibleDataObject
  {
    private AssociatedMenuBehavior? _associatedMenuBehavior;
    private AssociatedMenuGroup? _associatedMenuGroup;
    private Label _associatedMenuLabel;
    private int? _associatedMenuOrder;
    private bool _associatedMenuIsCustomizable;
    private string _associatedMenuIcon;
    private Guid _associatedMenuViewId;
    private bool _associatedMenuAvailableOffline;
    private string _associatedMenuMenuId;
    private string _associatedMenuQueryApi;
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public AssociatedMenuBehavior? Behavior
    {
      get => this._associatedMenuBehavior;
      set => this._associatedMenuBehavior = value;
    }

    [DataMember]
    public AssociatedMenuGroup? Group
    {
      get => this._associatedMenuGroup;
      set => this._associatedMenuGroup = value;
    }

    [DataMember]
    public Label Label
    {
      get => this._associatedMenuLabel;
      set => this._associatedMenuLabel = value;
    }

    [DataMember]
    public int? Order
    {
      get => this._associatedMenuOrder;
      set => this._associatedMenuOrder = value;
    }

    [DataMember(Order = 90)]
    public bool IsCustomizable
    {
      get => this._associatedMenuIsCustomizable;
      internal set => this._associatedMenuIsCustomizable = value;
    }

    [DataMember(Order = 90)]
    public string Icon
    {
      get => this._associatedMenuIcon;
      internal set => this._associatedMenuIcon = value;
    }

    [DataMember(Order = 90)]
    public Guid ViewId
    {
      get => this._associatedMenuViewId;
      internal set => this._associatedMenuViewId = value;
    }

    [DataMember(Order = 90)]
    public bool AvailableOffline
    {
      get => this._associatedMenuAvailableOffline;
      internal set => this._associatedMenuAvailableOffline = value;
    }

    [DataMember(Order = 90)]
    public string MenuId
    {
      get => this._associatedMenuMenuId;
      internal set => this._associatedMenuMenuId = value;
    }

    [DataMember(Order = 90)]
    public string QueryApi
    {
      get => this._associatedMenuQueryApi;
      internal set => this._associatedMenuQueryApi = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
