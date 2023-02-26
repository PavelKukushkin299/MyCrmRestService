// Decompiled with JetBrains decompiler
// Type: Data8.PowerPlatform.Dataverse.Client.ClaimsBasedAuthClient
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
//using System.ServiceModel.Federation;
using System.ServiceModel.Security;

namespace Data8.PowerPlatform.Dataverse.Client
{
  internal class ClaimsBasedAuthClient : 
    ClientBase<IOrganizationService>,
    IOrganizationService,
    IInnerOrganizationService
  {
    private readonly ProxySerializationSurrogate _serializationSurrogate;

    public ClaimsBasedAuthClient(string url, string issuerEndpoint)
      : base(ClaimsBasedAuthClient.CreateServiceEndpoint(url, issuerEndpoint))
    {
      this._serializationSurrogate = new ProxySerializationSurrogate();
      foreach (OperationDescription operation in (Collection<OperationDescription>) this.Endpoint.Contract.Operations)
        operation.Behaviors.Find<DataContractSerializerOperationBehavior>().DataContractSurrogate = (IDataContractSurrogate) this._serializationSurrogate;
    }

    private static ServiceEndpoint CreateServiceEndpoint(
      string url,
      string issuerEndpoint)
    {
      Binding federatedBinding = ClaimsBasedAuthClient.CreateFederatedBinding(issuerEndpoint);
      EndpointAddress address = new EndpointAddress(url);
      ServiceEndpoint serviceEndpoint = new ServiceEndpoint(ContractDescription.GetContract(typeof (ClaimsBasedAuthClient).BaseType.GetGenericArguments()[0]), federatedBinding, address);
      foreach (OperationDescription operation in (Collection<OperationDescription>) serviceEndpoint.Contract.Operations)
        operation.Behaviors.Find<DataContractSerializerOperationBehavior>().MaxItemsInObjectGraph = int.MaxValue;
      return serviceEndpoint;
    }

    public TimeSpan Timeout
    {
      get => this.InnerChannel.OperationTimeout;
      set => this.InnerChannel.OperationTimeout = value;
    }

    public void EnableProxyTypes(Assembly assembly) => this._serializationSurrogate.LoadAssembly(assembly);

    private static Binding CreateFederatedBinding(string issuerEndpoint)
    {
      ClaimsBasedAuthClient.ServerEntropyWS2007HttpBinding ws2007HttpBinding = new ClaimsBasedAuthClient.ServerEntropyWS2007HttpBinding(SecurityMode.TransportWithMessageCredential);
      ws2007HttpBinding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
      ws2007HttpBinding.Security.Message.EstablishSecurityContext = false;
            //тут
      var federatedBinding = new System.ServiceModel.Federation.WSFederationHttpBinding(System.ServiceModel.Federation.WSTrustTokenParameters.CreateWS2007FederationTokenParameters((Binding) ws2007HttpBinding, new EndpointAddress(issuerEndpoint)));
      ((WSHttpBinding) federatedBinding).Security.Message.EstablishSecurityContext = false;
      ((WSHttpBindingBase) federatedBinding).MaxReceivedMessageSize = (long) int.MaxValue;
      ((WSHttpBindingBase) federatedBinding).MaxBufferPoolSize = (long) int.MaxValue;
      ((WSHttpBindingBase) federatedBinding).ReaderQuotas.MaxStringContentLength = int.MaxValue;
      ((WSHttpBindingBase) federatedBinding).ReaderQuotas.MaxArrayLength = int.MaxValue;
      ((WSHttpBindingBase) federatedBinding).ReaderQuotas.MaxBytesPerRead = int.MaxValue;
      ((WSHttpBindingBase) federatedBinding).ReaderQuotas.MaxNameTableCharCount = int.MaxValue;
      return (Binding) federatedBinding;
    }

    public Guid Create(Entity entity) => this.Channel.Create(entity);

    public Entity Retrieve(string entityName, Guid id, ColumnSet columnSet) => this.Channel.Retrieve(entityName, id, columnSet);

    public void Update(Entity entity) => this.Channel.Update(entity);

    public void Delete(string entityName, Guid id) => this.Channel.Delete(entityName, id);

    public OrganizationResponse Execute(OrganizationRequest request) => this.Channel.Execute(request);

    public void Associate(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities)
    {
      this.Channel.Associate(entityName, entityId, relationship, relatedEntities);
    }

    public void Disassociate(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities)
    {
      this.Channel.Disassociate(entityName, entityId, relationship, relatedEntities);
    }

    public EntityCollection RetrieveMultiple(QueryBase query) => this.Channel.RetrieveMultiple(query);

    private class ServerEntropyWS2007HttpBinding : WS2007HttpBinding
    {
      public ServerEntropyWS2007HttpBinding(SecurityMode securityMode)
        : base(securityMode)
      {
      }

      protected override SecurityBindingElement CreateMessageSecurity()
      {
        SecurityBindingElement messageSecurity = base.CreateMessageSecurity();
        messageSecurity.KeyEntropyMode = SecurityKeyEntropyMode.ServerEntropy;
        return messageSecurity;
      }
    }
  }
}
