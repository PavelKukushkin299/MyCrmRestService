// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.GlobalSearchConfigurations
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "GlobalSearchConfigurations", Namespace = "http://schemas.microsoft.com/xrm/9.0/Contracts")]
  [Serializable]
  public sealed class GlobalSearchConfigurations : IExtensibleDataObject
  {
    private string searchProviderName;
    private string searchProviderResultsPage;
    private bool isLocalized;
    private bool isEnabled;
    private bool isSearchBoxVisible;
    [NonSerialized]
    private ExtensionDataObject _extensionDataObject;

    public GlobalSearchConfigurations()
    {
    }

    public GlobalSearchConfigurations(
      string searchProviderName,
      string searchProviderResultsPage,
      bool isLocalized,
      bool isEnabled,
      bool isSearchBoxVisible)
    {
      this.searchProviderName = searchProviderName;
      this.searchProviderResultsPage = searchProviderResultsPage;
      this.isLocalized = isLocalized;
      this.isEnabled = isEnabled;
      this.isSearchBoxVisible = isSearchBoxVisible;
    }

    [DataMember]
    public string SearchProviderName
    {
      get => this.searchProviderName;
      internal set => this.searchProviderName = value;
    }

    [DataMember]
    public string SearchProviderResultsPage
    {
      get => this.searchProviderResultsPage;
      internal set => this.searchProviderResultsPage = value;
    }

    [DataMember]
    public bool IsLocalized
    {
      get => this.isLocalized;
      internal set => this.isLocalized = value;
    }

    [DataMember]
    public bool IsEnabled
    {
      get => this.isEnabled;
      internal set => this.isEnabled = value;
    }

    [DataMember]
    public bool IsSearchBoxVisible
    {
      get => this.isSearchBoxVisible;
      internal set => this.isSearchBoxVisible = value;
    }

    ExtensionDataObject IExtensibleDataObject.ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
