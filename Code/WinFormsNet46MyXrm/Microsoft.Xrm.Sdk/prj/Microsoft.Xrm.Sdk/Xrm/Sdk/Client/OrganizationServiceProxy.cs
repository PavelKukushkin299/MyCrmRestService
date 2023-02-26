// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.OrganizationServiceProxy
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Query;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;

namespace Microsoft.Xrm.Sdk.Client
{
  public class OrganizationServiceProxy : ServiceProxy<IOrganizationService>, IOrganizationService
  {
    private static string _xrmSdkAssemblyFileVersion;

    internal bool OfflinePlayback { get; set; }

    public Guid CallerId { get; set; }

    public UserType UserType { get; set; }

    public Guid CallerRegardingObjectId { get; set; }

    internal int LanguageCodeOverride { get; set; }

    public string SyncOperationType { get; set; }

    internal string ClientAppName { get; set; }

    internal string ClientAppVersion { get; set; }

    public string SdkClientVersion { get; set; }

    internal OrganizationServiceProxy()
    {
    }

    public OrganizationServiceProxy(
      Uri uri,
      Uri homeRealmUri,
      ClientCredentials clientCredentials,
      ClientCredentials deviceCredentials)
      : base(uri, homeRealmUri, clientCredentials, deviceCredentials)
    {
    }

    public OrganizationServiceProxy(
      IServiceConfiguration<IOrganizationService> serviceConfiguration,
      SecurityTokenResponse securityTokenResponse)
      : base(serviceConfiguration, securityTokenResponse)
    {
    }

    public OrganizationServiceProxy(
      IServiceConfiguration<IOrganizationService> serviceConfiguration,
      ClientCredentials clientCredentials)
      : base(serviceConfiguration, clientCredentials)
    {
    }

    public OrganizationServiceProxy(
      IServiceManagement<IOrganizationService> serviceManagement,
      SecurityTokenResponse securityTokenResponse)
      : this(serviceManagement as IServiceConfiguration<IOrganizationService>, securityTokenResponse)
    {
    }

    public OrganizationServiceProxy(
      IServiceManagement<IOrganizationService> serviceManagement,
      ClientCredentials clientCredentials)
      : this(serviceManagement as IServiceConfiguration<IOrganizationService>, clientCredentials)
    {
    }

    public void EnableProxyTypes()
    {
      ClientExceptionHelper.ThrowIfNull((object) this.ServiceConfiguration, "ServiceConfiguration");
      OrganizationServiceConfiguration serviceConfiguration = this.ServiceConfiguration as OrganizationServiceConfiguration;
      ClientExceptionHelper.ThrowIfNull((object) serviceConfiguration, "orgConfig");
      serviceConfiguration.EnableProxyTypes();
    }

    public void EnableProxyTypes(Assembly assembly)
    {
      ClientExceptionHelper.ThrowIfNull((object) assembly, nameof (assembly));
      ClientExceptionHelper.ThrowIfNull((object) this.ServiceConfiguration, "ServiceConfiguration");
      OrganizationServiceConfiguration serviceConfiguration = this.ServiceConfiguration as OrganizationServiceConfiguration;
      ClientExceptionHelper.ThrowIfNull((object) serviceConfiguration, "orgConfig");
      serviceConfiguration.EnableProxyTypes(assembly);
    }

    [PermissionSet(SecurityAction.Demand, Unrestricted = true)]
    internal static string GetXrmSdkAssemblyFileVersion()
    {
      if (string.IsNullOrEmpty(OrganizationServiceProxy._xrmSdkAssemblyFileVersion))
      {
        string[] strArray = new string[1]
        {
          "Microsoft.Xrm.Sdk.dll"
        };
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (string str in strArray)
        {
          foreach (Assembly assembly in assemblies)
          {
            if (assembly.ManifestModule.Name.Equals(str, StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(assembly.Location) && File.Exists(assembly.Location))
            {
              OrganizationServiceProxy._xrmSdkAssemblyFileVersion = FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
              break;
            }
          }
        }
      }
      if (string.IsNullOrEmpty(OrganizationServiceProxy._xrmSdkAssemblyFileVersion))
        OrganizationServiceProxy._xrmSdkAssemblyFileVersion = "9.1.2.3";
      return OrganizationServiceProxy._xrmSdkAssemblyFileVersion;
    }

    protected internal virtual Guid CreateCore(Entity entity)
    {
      bool? retry = new bool?();
      do
      {
        bool forceClose = false;
        try
        {
          using (new OrganizationServiceContextInitializer(this))
            return this.ServiceChannel.Channel.Create(entity);
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
          retry = this.HandleFailover((BaseServiceFault) ex.Detail, retry);
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
      return Guid.Empty;
    }

    protected internal virtual Entity RetrieveCore(
      string entityName,
      Guid id,
      ColumnSet columnSet)
    {
      bool? retry = new bool?();
      do
      {
        bool forceClose = false;
        try
        {
          using (new OrganizationServiceContextInitializer(this))
            return this.ServiceChannel.Channel.Retrieve(entityName, id, columnSet);
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
          retry = this.HandleFailover((BaseServiceFault) ex.Detail, retry);
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
      return (Entity) null;
    }

    protected internal virtual void UpdateCore(Entity entity)
    {
      bool? retry = new bool?();
      do
      {
        bool forceClose = false;
        try
        {
          using (new OrganizationServiceContextInitializer(this))
          {
            this.ServiceChannel.Channel.Update(entity);
            break;
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
          retry = this.HandleFailover((BaseServiceFault) ex.Detail, retry);
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
    }

    protected internal virtual void DeleteCore(string entityName, Guid id)
    {
      bool? retry = new bool?();
      do
      {
        bool forceClose = false;
        try
        {
          using (new OrganizationServiceContextInitializer(this))
          {
            this.ServiceChannel.Channel.Delete(entityName, id);
            break;
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
          retry = this.HandleFailover((BaseServiceFault) ex.Detail, retry);
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
    }

    protected internal virtual OrganizationResponse ExecuteCore(
      OrganizationRequest request)
    {
      bool? retry = new bool?();
      do
      {
        bool forceClose = false;
        try
        {
          using (new OrganizationServiceContextInitializer(this))
            return this.ServiceChannel.Channel.Execute(request);
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
          retry = this.HandleFailover((BaseServiceFault) ex.Detail, retry);
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
      return (OrganizationResponse) null;
    }

    protected internal virtual void AssociateCore(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities)
    {
      bool? retry = new bool?();
      do
      {
        bool forceClose = false;
        try
        {
          using (new OrganizationServiceContextInitializer(this))
          {
            this.ServiceChannel.Channel.Associate(entityName, entityId, relationship, relatedEntities);
            break;
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
          retry = this.HandleFailover((BaseServiceFault) ex.Detail, retry);
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
    }

    protected internal virtual void DisassociateCore(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities)
    {
      bool? retry = new bool?();
      do
      {
        bool forceClose = false;
        try
        {
          using (new OrganizationServiceContextInitializer(this))
          {
            this.ServiceChannel.Channel.Disassociate(entityName, entityId, relationship, relatedEntities);
            break;
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
          retry = this.HandleFailover((BaseServiceFault) ex.Detail, retry);
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
    }

    protected internal virtual EntityCollection RetrieveMultipleCore(QueryBase query)
    {
      bool? retry = new bool?();
      do
      {
        bool forceClose = false;
        try
        {
          using (new OrganizationServiceContextInitializer(this))
            return this.ServiceChannel.Channel.RetrieveMultiple(query);
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
          retry = this.HandleFailover((BaseServiceFault) ex.Detail, retry);
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
      return (EntityCollection) null;
    }

    public Guid Create(Entity entity) => this.CreateCore(entity);

    public Entity Retrieve(string entityName, Guid id, ColumnSet columnSet) => this.RetrieveCore(entityName, id, columnSet);

    public void Update(Entity entity) => this.UpdateCore(entity);

    public void Delete(string entityName, Guid id) => this.DeleteCore(entityName, id);

    public OrganizationResponse Execute(OrganizationRequest request) => this.ExecuteCore(request);

    public void Associate(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities)
    {
      this.AssociateCore(entityName, entityId, relationship, relatedEntities);
    }

    public void Disassociate(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities)
    {
      this.DisassociateCore(entityName, entityId, relationship, relatedEntities);
    }

    public EntityCollection RetrieveMultiple(QueryBase query) => this.RetrieveMultipleCore(query);
  }
}
