// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.OrganizationServiceProxy
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;

namespace MyCrmConnector.Client
{
    public class OrganizationServiceProxy : MyCrmConnector.Client.ServiceProxy<IOrganizationService>, IOrganizationService
    {
        

        public OrganizationServiceProxy(
          IServiceConfiguration<IOrganizationService> serviceConfiguration,
          ClientCredentials clientCredentials)
          : base(serviceConfiguration, clientCredentials)
        {
        }

        public OrganizationServiceProxy(
            IServiceManagement<IOrganizationService> serviceManagement,
            ClientCredentials clientCredentials)
            : this(serviceManagement as IServiceConfiguration<IOrganizationService>, clientCredentials)
        {
        }


        #region IOrganizationService

        public void Associate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities)
        {
            throw new NotImplementedException();
        }

        public Guid Create(Entity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string entityName, Guid id)
        {
            throw new NotImplementedException();
        }

        public void Disassociate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities)
        {
            throw new NotImplementedException();
        }

        public Microsoft.Xrm.Sdk.OrganizationResponse Execute(Microsoft.Xrm.Sdk.OrganizationRequest request)
        {
            throw new NotImplementedException();
        }

        public Entity Retrieve(string entityName, Guid id, ColumnSet columnSet)
        {
            throw new NotImplementedException();
        }

        public EntityCollection RetrieveMultiple(QueryBase query)
        {
            var res = this.RetrieveMultipleCore(query);
            return res;
        }

        public void Update(Entity entity)
        {
            throw new NotImplementedException();
        }

        #endregion #region IOrganizationService

        protected internal virtual EntityCollection RetrieveMultipleCore(QueryBase query)
        {
            bool? retry = new bool?();
            do
            {
                bool forceClose = false;
                try
                {
                    using (new OrganizationServiceContextInitializer(this))
                    {
                        return this.ServiceChannel.Channel.RetrieveMultiple(query);
                    }
                }
                catch (MessageSecurityException ex)
                {
                    forceClose = true;
                    retry = this.ShouldRetry(ex, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (EndpointNotFoundException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (TimeoutException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (FaultException<OrganizationServiceFault> ex)
                {
                    forceClose = true;
                    retry = this.HandleFailover((BaseServiceFault)ex.Detail, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch
                {
                    forceClose = true;
                    throw;
                }
                finally
                {
                    this.CloseChannel(forceClose);
                }
            }
            while (retry.HasValue && retry.Value);
            return (EntityCollection)null;
        }
    }
}
