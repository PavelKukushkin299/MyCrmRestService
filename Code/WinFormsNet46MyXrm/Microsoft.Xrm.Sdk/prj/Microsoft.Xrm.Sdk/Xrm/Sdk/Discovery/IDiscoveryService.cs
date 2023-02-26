// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Discovery.IDiscoveryService
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.ServiceModel;

namespace Microsoft.Xrm.Sdk.Discovery
{
  [ServiceContract(Name = "IDiscoveryService", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Discovery")]
  [ServiceKnownType(typeof (DiscoveryServiceFault))]
  public interface IDiscoveryService
  {
    [OperationContract]
    [FaultContract(typeof (DiscoveryServiceFault))]
    DiscoveryResponse Execute(DiscoveryRequest request);
  }
}
