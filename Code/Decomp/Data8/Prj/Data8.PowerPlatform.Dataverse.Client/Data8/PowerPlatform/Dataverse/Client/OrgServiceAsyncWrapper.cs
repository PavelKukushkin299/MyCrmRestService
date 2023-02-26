// Decompiled with JetBrains decompiler
// Type: Data8.PowerPlatform.Dataverse.Client.OrgServiceAsyncWrapper
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Threading.Tasks;

namespace Data8.PowerPlatform.Dataverse.Client
{
  internal class OrgServiceAsyncWrapper : IOrganizationServiceAsync, IOrganizationService
  {
    private readonly IOrganizationService _service;

    public OrgServiceAsyncWrapper(IOrganizationService service) => this._service = service;

    public void Associate(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities)
    {
      this._service.Associate(entityName, entityId, relationship, relatedEntities);
    }

    public Task AssociateAsync(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities)
    {
      return Task.Run((Action) (() => this.Associate(entityName, entityId, relationship, relatedEntities)));
    }

    public Guid Create(Entity entity) => this._service.Create(entity);

    public Task<Guid> CreateAsync(Entity entity) => Task.Run<Guid>((Func<Guid>) (() => this.Create(entity)));

    public void Delete(string entityName, Guid id) => this._service.Delete(entityName, id);

    public Task DeleteAsync(string entityName, Guid id) => Task.Run((Action) (() => this.Delete(entityName, id)));

    public void Disassociate(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities)
    {
      this._service.Disassociate(entityName, entityId, relationship, relatedEntities);
    }

    public Task DisassociateAsync(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities)
    {
      return Task.Run((Action) (() => this._service.Disassociate(entityName, entityId, relationship, relatedEntities)));
    }

    public OrganizationResponse Execute(OrganizationRequest request) => this._service.Execute(request);

    public Task<OrganizationResponse> ExecuteAsync(
      OrganizationRequest request)
    {
      return Task.Run<OrganizationResponse>((Func<OrganizationResponse>) (() => this._service.Execute(request)));
    }

    public Entity Retrieve(string entityName, Guid id, ColumnSet columnSet) => this._service.Retrieve(entityName, id, columnSet);

    public Task<Entity> RetrieveAsync(string entityName, Guid id, ColumnSet columnSet) => Task.Run<Entity>((Func<Entity>) (() => this.Retrieve(entityName, id, columnSet)));

    public EntityCollection RetrieveMultiple(QueryBase query) => this._service.RetrieveMultiple(query);

    public Task<EntityCollection> RetrieveMultipleAsync(QueryBase query) => Task.Run<EntityCollection>((Func<EntityCollection>) (() => this.RetrieveMultiple(query)));

    public void Update(Entity entity) => this._service.Update(entity);

    public Task UpdateAsync(Entity entity) => Task.Run((Action) (() => this.Update(entity)));
  }
}
