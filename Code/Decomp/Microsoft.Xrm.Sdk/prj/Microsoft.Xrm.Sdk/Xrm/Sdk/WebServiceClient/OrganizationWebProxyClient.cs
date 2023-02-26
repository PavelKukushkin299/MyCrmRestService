// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.WebServiceClient.OrganizationWebProxyClient
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Query;
using System;
using System.Reflection;

namespace Microsoft.Xrm.Sdk.WebServiceClient
{
  public class OrganizationWebProxyClient : 
    WebProxyClient<IOrganizationService>,
    IOrganizationService
  {
    public OrganizationWebProxyClient(Uri serviceUrl, bool useStrongTypes)
      : base(serviceUrl, useStrongTypes)
    {
    }

    public OrganizationWebProxyClient(Uri serviceUrl, Assembly strongTypeAssembly)
      : base(serviceUrl, strongTypeAssembly)
    {
    }

    public OrganizationWebProxyClient(Uri serviceUrl, TimeSpan timeout, bool useStrongTypes)
      : base(serviceUrl, timeout, useStrongTypes)
    {
    }

    public OrganizationWebProxyClient(Uri uri, TimeSpan timeout, Assembly strongTypeAssembly)
      : base(uri, timeout, strongTypeAssembly)
    {
    }

    internal bool OfflinePlayback { get; set; }

    public string SyncOperationType { get; set; }

    public Guid CallerId { get; set; }

    public UserType userType { get; set; }

    public Guid CallerRegardingObjectId { get; set; }

    internal int LanguageCodeOverride { get; set; }

    public void Associate(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities)
    {
      this.AssociateCore(entityName, entityId, relationship, relatedEntities);
    }

    public Guid Create(Entity entity) => this.CreateCore(entity);

    public void Delete(string entityName, Guid id) => this.DeleteCore(entityName, id);

    public void Disassociate(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities)
    {
      this.DisassociateCore(entityName, entityId, relationship, relatedEntities);
    }

    public OrganizationResponse Execute(OrganizationRequest request) => this.ExecuteCore(request);

    public Entity Retrieve(string entityName, Guid id, ColumnSet columnSet) => this.RetrieveCore(entityName, id, columnSet);

    public EntityCollection RetrieveMultiple(QueryBase query) => this.RetrieveMultipleCore(query);

    public void Update(Entity entity) => this.UpdateCore(entity);

    protected internal virtual Guid CreateCore(Entity entity) => this.ExecuteAction<Guid>((Func<Guid>) (() => this.Channel.Create(entity)));

    protected internal virtual Entity RetrieveCore(
      string entityName,
      Guid id,
      ColumnSet columnSet)
    {
      return this.ExecuteAction<Entity>((Func<Entity>) (() => this.Channel.Retrieve(entityName, id, columnSet)));
    }

    protected internal virtual void UpdateCore(Entity entity) => this.ExecuteAction((Action) (() => this.Channel.Update(entity)));

    protected internal virtual void DeleteCore(string entityName, Guid id) => this.ExecuteAction((Action) (() => this.Channel.Delete(entityName, id)));

    protected internal virtual OrganizationResponse ExecuteCore(
      OrganizationRequest request)
    {
      return this.ExecuteAction<OrganizationResponse>((Func<OrganizationResponse>) (() => this.Channel.Execute(request)));
    }

    protected internal virtual void AssociateCore(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities)
    {
      this.ExecuteAction((Action) (() => this.Channel.Associate(entityName, entityId, relationship, relatedEntities)));
    }

    protected internal virtual void DisassociateCore(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities)
    {
      this.ExecuteAction((Action) (() => this.Channel.Disassociate(entityName, entityId, relationship, relatedEntities)));
    }

    protected internal virtual EntityCollection RetrieveMultipleCore(QueryBase query) => this.ExecuteAction<EntityCollection>((Func<EntityCollection>) (() => this.Channel.RetrieveMultiple(query)));

    protected override WebProxyClientContextInitializer<IOrganizationService> CreateNewInitializer() => (WebProxyClientContextInitializer<IOrganizationService>) new OrganizationWebProxyClientContextInitializer(this);
  }
}
