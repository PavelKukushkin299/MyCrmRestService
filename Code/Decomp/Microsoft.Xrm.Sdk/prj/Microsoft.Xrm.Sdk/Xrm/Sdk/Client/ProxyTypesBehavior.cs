// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.ProxyTypesBehavior
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Microsoft.Xrm.Sdk.Client
{
  public sealed class ProxyTypesBehavior : IEndpointBehavior
  {
    private Assembly _proxyTypesAssembly;
    private readonly object _lockObject = new object();

    public ProxyTypesBehavior()
    {
    }

    public ProxyTypesBehavior(Assembly proxyTypesAssembly) => this._proxyTypesAssembly = proxyTypesAssembly;

    void IEndpointBehavior.AddBindingParameters(
      ServiceEndpoint serviceEndpoint,
      BindingParameterCollection bindingParameters)
    {
    }

    void IEndpointBehavior.ApplyClientBehavior(
      ServiceEndpoint serviceEndpoint,
      ClientRuntime behavior)
    {
      foreach (OperationDescription operation in (Collection<OperationDescription>) serviceEndpoint.Contract.Operations)
        this.UpdateFormatterBehavior(operation);
    }

    void IEndpointBehavior.ApplyDispatchBehavior(
      ServiceEndpoint serviceEndpoint,
      EndpointDispatcher endpointDispatcher)
    {
    }

    void IEndpointBehavior.Validate(ServiceEndpoint serviceEndpoint)
    {
    }

    private void UpdateFormatterBehavior(OperationDescription operationDescription)
    {
      lock (this._lockObject)
      {
        DataContractSerializerOperationBehavior operationBehavior1 = operationDescription.Behaviors.Find<DataContractSerializerOperationBehavior>();
        if (operationBehavior1 != null)
        {
          operationBehavior1.DataContractSurrogate = (IDataContractSurrogate) new ProxySerializationSurrogate(this._proxyTypesAssembly);
        }
        else
        {
          DataContractSerializerOperationBehavior operationBehavior2 = new DataContractSerializerOperationBehavior(operationDescription);
          operationDescription.Behaviors.Add((IOperationBehavior) operationBehavior2);
        }
      }
    }
  }
}
