// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.KnownAssemblyAttribute
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Microsoft.Xrm.Sdk
{
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
  internal sealed class KnownAssemblyAttribute : Attribute, IContractBehavior
  {
    private KnownTypesResolver resolver;

    public KnownAssemblyAttribute() => this.resolver = new KnownTypesResolver();

    public void AddBindingParameters(
      ContractDescription contractDescription,
      ServiceEndpoint endpoint,
      BindingParameterCollection bindingParameters)
    {
    }

    public void ApplyClientBehavior(
      ContractDescription contractDescription,
      ServiceEndpoint endpoint,
      ClientRuntime clientRuntime)
    {
      this.CreateMyDataContractSerializerOperationBehaviors(contractDescription);
    }

    public void ApplyDispatchBehavior(
      ContractDescription contractDescription,
      ServiceEndpoint endpoint,
      DispatchRuntime dispatchRuntime)
    {
      this.CreateMyDataContractSerializerOperationBehaviors(contractDescription);
    }

    public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
    {
    }

    private void CreateMyDataContractSerializerOperationBehaviors(
      ContractDescription contractDescription)
    {
      foreach (OperationDescription operation in (Collection<OperationDescription>) contractDescription.Operations)
        this.CreateMyDataContractSerializerOperationBehavior(operation);
    }

    private void CreateMyDataContractSerializerOperationBehavior(OperationDescription operation)
    {
      DataContractSerializerOperationBehavior operationBehavior = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
      if (operationBehavior == null)
        return;
      operationBehavior.DataContractResolver = (DataContractResolver) this.resolver;
    }
  }
}
