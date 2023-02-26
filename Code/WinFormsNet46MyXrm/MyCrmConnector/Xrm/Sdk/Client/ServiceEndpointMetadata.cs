// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.ServiceEndpointMetadata
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Client;
using System.Collections.ObjectModel;
using System.ServiceModel.Description;

namespace MyCrmConnector.Client
{
  public sealed class ServiceEndpointMetadata
  {
    private ServiceEndpointDictionary _serviceEndpoints = new ServiceEndpointDictionary();
    private Collection<MetadataConversionError> _metadataConversionErrors = new Collection<MetadataConversionError>();

    public ServiceEndpointDictionary ServiceEndpoints => this._serviceEndpoints;

    public MetadataSet ServiceMetadata { get; set; }

    public Collection<MetadataConversionError> MetadataConversionErrors => this._metadataConversionErrors;

    public ServiceUrls ServiceUrls { get; internal set; }
  }
}
