// Decompiled with JetBrains decompiler
// Type: Data8.PowerPlatform.Dataverse.Client.OnPremiseClient
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using Data8.PowerPlatform.Dataverse.Client.Wsdl;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Threading;
using System.Threading.Tasks;

namespace Data8.PowerPlatform.Dataverse.Client
{
    public class OnPremiseClient :
      IOrganizationServiceAsync2,
      IOrganizationServiceAsync,
      IOrganizationService
    {
        private readonly IInnerOrganizationService _innerService;
        private readonly IOrganizationServiceAsync _service;
        private static readonly string _sdkVersion;
        private static readonly int _sdkMajorVersion;

        static OnPremiseClient()
        {
            Assembly assembly = typeof(IOrganizationService).Assembly;
            if (!string.IsNullOrEmpty(assembly.Location) && File.Exists(assembly.Location))
            {
                FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
                OnPremiseClient._sdkVersion = versionInfo.FileVersion;
                OnPremiseClient._sdkMajorVersion = versionInfo.FileMajorPart;
            }
            else
            {
                OnPremiseClient._sdkVersion = "9.1.2.3";
                OnPremiseClient._sdkMajorVersion = 9;
            }
        }

        public OnPremiseClient(string url)
          : this(url, new ClientCredentials())
        {
        }

        public OnPremiseClient(string url, string username, string password)
          : this(url, new ClientCredentials()
          {
              UserName = {
          UserName = username,
          Password = password
            }
          })
        {
        }



        public OnPremiseClient(string url, ClientCredentials credentials)
        {
            List<Definitions> source = new Uri(url).Scheme.Equals("https", StringComparison.OrdinalIgnoreCase) ? WsdlLoader.Load(url + "?wsdl&sdkversion=" + OnPremiseClient._sdkMajorVersion.ToString()).ToList<Definitions>() : throw new NotSupportedException("Only https connections are supported");
            List<Data8.PowerPlatform.Dataverse.Client.Wsdl.Policy> list = source.Where<Definitions>((Func<Definitions, bool>)(w => w.Policies != null)).SelectMany<Definitions, Data8.PowerPlatform.Dataverse.Client.Wsdl.Policy>((Func<Definitions, IEnumerable<Data8.PowerPlatform.Dataverse.Client.Wsdl.Policy>>)(w => (IEnumerable<Data8.PowerPlatform.Dataverse.Client.Wsdl.Policy>)w.Policies)).ToList<Data8.PowerPlatform.Dataverse.Client.Wsdl.Policy>();
            AuthenticationPolicy authenticationPolicy = list.Select<Data8.PowerPlatform.Dataverse.Client.Wsdl.Policy, AuthenticationPolicy>((Func<Data8.PowerPlatform.Dataverse.Client.Wsdl.Policy, AuthenticationPolicy>)(p => p.FindPolicyItem<AuthenticationPolicy>())).Where<AuthenticationPolicy>((Func<AuthenticationPolicy, bool>)(t => t != null)).FirstOrDefault<AuthenticationPolicy>();
            if (authenticationPolicy == null)
                throw new InvalidOperationException("Unable to find authentication policy");
            switch (authenticationPolicy.Authentication)
            {
                // тут
                case Data8.PowerPlatform.Dataverse.Client.Wsdl.AuthenticationType.ActiveDirectory:
                    Identity identity = ((IEnumerable<Port>)source.Where<Definitions>((Func<Definitions, bool>)(w => w.Services != null)).SelectMany<Definitions, Service>((Func<Definitions, IEnumerable<Service>>)(w => (IEnumerable<Service>)w.Services)).Single<Service>().Ports).Where<Port>((Func<Port, bool>)(port => new Uri(port.Address.Location).Scheme.Equals(new Uri(url).Scheme, StringComparison.OrdinalIgnoreCase))).Single<Port>().EndpointReference.Identity;
                    this._innerService = (IInnerOrganizationService)this.ConnectAD(url, credentials, identity?.Upn ?? identity?.Spn);
                    break;
                // тут
                case Data8.PowerPlatform.Dataverse.Client.Wsdl.AuthenticationType.Federation:
                    this._innerService = (IInnerOrganizationService)this.ConnectFederated(url, credentials, list);
                    break;
                default:
                    throw new NotSupportedException("Unknown authentication policy " + authenticationPolicy.Authentication.ToString());
            }
            this._service = !(this._innerService is IOrganizationServiceAsync innerService) ? (IOrganizationServiceAsync)new OrgServiceAsyncWrapper((IOrganizationService)this._innerService) : innerService;
            this.Timeout = TimeSpan.FromMinutes(2.0);
        }

        private ClaimsBasedAuthClient ConnectFederated(
          string url,
          ClientCredentials credentials,
          List<Data8.PowerPlatform.Dataverse.Client.Wsdl.Policy> policies)
        {
            List<Definitions> list = WsdlLoader.Load(policies.Select<Data8.PowerPlatform.Dataverse.Client.Wsdl.Policy, EndorsingSupportingTokens>((Func<Data8.PowerPlatform.Dataverse.Client.Wsdl.Policy, EndorsingSupportingTokens>)(p => p.FindPolicyItem<EndorsingSupportingTokens>())).Where<EndorsingSupportingTokens>((Func<EndorsingSupportingTokens, bool>)(t => t != null)).FirstOrDefault<EndorsingSupportingTokens>().Policy.FindPolicyItem<IssuedToken>().Issuer.Metadata.Metadata.MetadataSection.MetadataReference.Address).ToList<Definitions>();
            Data8.PowerPlatform.Dataverse.Client.Wsdl.Policy usernameWsTrust13Policy = list.Where<Definitions>((Func<Definitions, bool>)(wsdl => wsdl.Policies != null)).SelectMany<Definitions, Data8.PowerPlatform.Dataverse.Client.Wsdl.Policy>((Func<Definitions, IEnumerable<Data8.PowerPlatform.Dataverse.Client.Wsdl.Policy>>)(wsdl => (IEnumerable<Data8.PowerPlatform.Dataverse.Client.Wsdl.Policy>)wsdl.Policies)).ToList<Data8.PowerPlatform.Dataverse.Client.Wsdl.Policy>().Where<Data8.PowerPlatform.Dataverse.Client.Wsdl.Policy>((Func<Data8.PowerPlatform.Dataverse.Client.Wsdl.Policy, bool>)(p => p.FindPolicyItem<SignedEncryptedSupportingTokens>()?.Policy.FindPolicyItem<UsernameToken>() != null && p.FindPolicyItem<Trust13>() != null)).FirstOrDefault<Data8.PowerPlatform.Dataverse.Client.Wsdl.Policy>();
            Data8.PowerPlatform.Dataverse.Client.Wsdl.Binding usernameWsTrust13Binding = list.Where<Definitions>((Func<Definitions, bool>)(wsdl => wsdl.Bindings != null)).SelectMany<Definitions, Data8.PowerPlatform.Dataverse.Client.Wsdl.Binding>((Func<Definitions, IEnumerable<Data8.PowerPlatform.Dataverse.Client.Wsdl.Binding>>)(wsdl => (IEnumerable<Data8.PowerPlatform.Dataverse.Client.Wsdl.Binding>)wsdl.Bindings)).ToList<Data8.PowerPlatform.Dataverse.Client.Wsdl.Binding>().Where<Data8.PowerPlatform.Dataverse.Client.Wsdl.Binding>((Func<Data8.PowerPlatform.Dataverse.Client.Wsdl.Binding, bool>)(b => b.PolicyReference.Uri == "#" + usernameWsTrust13Policy.Id)).FirstOrDefault<Data8.PowerPlatform.Dataverse.Client.Wsdl.Binding>();
            Port port = list.Where<Definitions>((Func<Definitions, bool>)(wsdl => wsdl.Services != null)).SelectMany<Definitions, Service>((Func<Definitions, IEnumerable<Service>>)(wsdl => (IEnumerable<Service>)wsdl.Services)).SelectMany<Service, Port>((Func<Service, IEnumerable<Port>>)(svc => (IEnumerable<Port>)svc.Ports)).ToList<Port>().Where<Port>((Func<Port, bool>)(p => p.Binding == "tns:" + usernameWsTrust13Binding.Name)).FirstOrDefault<Port>();
            ClaimsBasedAuthClient claimsBasedAuthClient = new ClaimsBasedAuthClient(url, port.Address.Location);
            claimsBasedAuthClient.ChannelFactory.Credentials.UserName.UserName = credentials.UserName.UserName;
            claimsBasedAuthClient.ChannelFactory.Credentials.UserName.Password = credentials.UserName.Password;
            return claimsBasedAuthClient;
        }

        private ADAuthClient ConnectAD(
          string url,
          ClientCredentials credentials,
          string identity)
        {
            return new ADAuthClient(url, credentials.UserName.UserName, credentials.UserName.Password, identity);
        }

        public Guid CallerId { get; set; }

        public TimeSpan Timeout
        {
            get => this._innerService.Timeout;
            set => this._innerService.Timeout = value;
        }

        public void EnableProxyTypes()
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (assembly.GetCustomAttribute<ProxyTypesAssemblyAttribute>() != null)
                {
                    this.EnableProxyTypes(assembly);
                    break;
                }
            }
        }

        public void EnableProxyTypes(Assembly assembly) => this._innerService.EnableProxyTypes(assembly);

        private IDisposable StartScope() => (IDisposable)new OnPremiseClient.OrgServiceScope(this._innerService, this.CallerId);

        public virtual void Associate(
          string entityName,
          Guid entityId,
          Relationship relationship,
          EntityReferenceCollection relatedEntities)
        {
            using (this.StartScope())
                ((IOrganizationService)this._service).Associate(entityName, entityId, relationship, relatedEntities);
        }

        public virtual Guid Create(Entity entity)
        {
            using (this.StartScope())
                return ((IOrganizationService)this._service).Create(entity);
        }

        public virtual void Delete(string entityName, Guid id)
        {
            using (this.StartScope())
                ((IOrganizationService)this._service).Delete(entityName, id);
        }

        public virtual void Disassociate(
          string entityName,
          Guid entityId,
          Relationship relationship,
          EntityReferenceCollection relatedEntities)
        {
            using (this.StartScope())
                ((IOrganizationService)this._service).Disassociate(entityName, entityId, relationship, relatedEntities);
        }

        public virtual OrganizationResponse Execute(OrganizationRequest request)
        {
            using (this.StartScope())
                return ((IOrganizationService)this._service).Execute(request);
        }

        public virtual Entity Retrieve(string entityName, Guid id, ColumnSet columnSet)
        {
            using (this.StartScope())
                return ((IOrganizationService)this._service).Retrieve(entityName, id, columnSet);
        }

        public virtual EntityCollection RetrieveMultiple(QueryBase query)
        {
            using (this.StartScope())
                return ((IOrganizationService)this._service).RetrieveMultiple(query);
        }

        public virtual void Update(Entity entity)
        {
            using (this.StartScope())
                ((IOrganizationService)this._service).Update(entity);
        }

        public Task AssociateAsync(
          string entityName,
          Guid entityId,
          Relationship relationship,
          EntityReferenceCollection relatedEntities,
          CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return this.AssociateAsync(entityName, entityId, relationship, relatedEntities);
        }

        public Task<Guid> CreateAsync(Entity entity, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return this.CreateAsync(entity);
        }

        public Task<Entity> CreateAndReturnAsync(
          Entity entity,
          CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string entityName, Guid id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return this.DeleteAsync(entityName, id);
        }

        public Task DisassociateAsync(
          string entityName,
          Guid entityId,
          Relationship relationship,
          EntityReferenceCollection relatedEntities,
          CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return this.DisassociateAsync(entityName, entityId, relationship, relatedEntities);
        }

        public Task<OrganizationResponse> ExecuteAsync(
          OrganizationRequest request,
          CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return this.ExecuteAsync(request);
        }

        public Task<Entity> RetrieveAsync(
          string entityName,
          Guid id,
          ColumnSet columnSet,
          CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return this.RetrieveAsync(entityName, id, columnSet);
        }

        public Task<EntityCollection> RetrieveMultipleAsync(
          QueryBase query,
          CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return this.RetrieveMultipleAsync(query);
        }

        public Task UpdateAsync(Entity entity, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return this.UpdateAsync(entity);
        }

        public Task<Guid> CreateAsync(Entity entity)
        {
            using (this.StartScope())
                return this._service.CreateAsync(entity);
        }

        public Task<Entity> RetrieveAsync(string entityName, Guid id, ColumnSet columnSet)
        {
            using (this.StartScope())
                return this._service.RetrieveAsync(entityName, id, columnSet);
        }

        public Task UpdateAsync(Entity entity)
        {
            using (this.StartScope())
                return this._service.UpdateAsync(entity);
        }

        public Task DeleteAsync(string entityName, Guid id)
        {
            using (this.StartScope())
                return this._service.DeleteAsync(entityName, id);
        }

        public Task<OrganizationResponse> ExecuteAsync(
          OrganizationRequest request)
        {
            using (this.StartScope())
                return this._service.ExecuteAsync(request);
        }

        public Task AssociateAsync(
          string entityName,
          Guid entityId,
          Relationship relationship,
          EntityReferenceCollection relatedEntities)
        {
            using (this.StartScope())
                return this._service.AssociateAsync(entityName, entityId, relationship, relatedEntities);
        }

        public Task DisassociateAsync(
          string entityName,
          Guid entityId,
          Relationship relationship,
          EntityReferenceCollection relatedEntities)
        {
            using (this.StartScope())
                return this._service.DisassociateAsync(entityName, entityId, relationship, relatedEntities);
        }

        public Task<EntityCollection> RetrieveMultipleAsync(QueryBase query)
        {
            using (this.StartScope())
                return this._service.RetrieveMultipleAsync(query);
        }

        private class OrgServiceScope : IDisposable
        {
            private readonly OperationContextScope _scope;

            public OrgServiceScope(IInnerOrganizationService svc, Guid callerId)
            {
                if (svc is ClaimsBasedAuthClient claimsBasedAuthClient)
                {
                    this._scope = new OperationContextScope((IContextChannel)claimsBasedAuthClient.InnerChannel);
                    OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("SdkClientVersion", "http://schemas.microsoft.com/xrm/2011/Contracts", (object)OnPremiseClient._sdkVersion));
                    OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("UserType", "http://schemas.microsoft.com/xrm/2011/Contracts", (object)"CrmUser"));
                    if (!(callerId != Guid.Empty))
                        return;
                    OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("CallerId", "http://schemas.microsoft.com/xrm/2011/Contracts", (object)callerId));
                }
                else
                {
                    ((ADAuthClient)svc).SdkClientVersion = OnPremiseClient._sdkVersion;
                    ((ADAuthClient)svc).CallerId = callerId;
                }
            }

            public void Dispose() => this._scope?.Dispose();
        }

        #region My code

        public OnPremiseClient(string url, string domain, string username, string password)
        {
            var orgServiceManagement = ServiceConfigurationFactory.CreateManagement<IOrganizationService>(new Uri(url));
            var clientCredentials = GetCredentials(domain, username, password).ClientCredentials;

            var orgService = new OrganizationServiceProxy(orgServiceManagement, clientCredentials);
            this._innerService = orgService as IOrganizationService;
            //this._service = (IOrganizationService)(new OrganizationServiceProxy(orgServiceManagement, clientCredentials));

        }

        private AuthenticationCredentials GetCredentials(string domain, string username, string password)
        {
            
            var authCredentials = new AuthenticationCredentials();
            authCredentials.ClientCredentials.Windows.ClientCredential =
                new System.Net.NetworkCredential(username, password, domain);
            return authCredentials;
        }

        #endregion
    }
}
