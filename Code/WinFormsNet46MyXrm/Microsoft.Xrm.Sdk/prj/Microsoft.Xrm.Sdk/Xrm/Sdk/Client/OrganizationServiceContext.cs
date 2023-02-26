// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.OrganizationServiceContext
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Linq;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Security.Permissions;

namespace Microsoft.Xrm.Sdk.Client
{
  public class OrganizationServiceContext : IDisposable
  {
    private readonly IOrganizationService _service;
    private readonly Dictionary<Entity, EntityDescriptor> _descriptors;
    private readonly Dictionary<EntityReference, EntityDescriptor> _identityToDescriptor;
    private readonly Dictionary<LinkDescriptor, LinkDescriptor> _bindings;
    private readonly HashSet<Entity> _roots;
    private readonly bool _trackEntityChanges;
    private ConcurrencyBehavior _concurrencyBehavior;
    internal static OrganizationServiceContext.SequentialGuidOverrideDelegate SequentialGuidOverride;

    protected virtual IQueryProvider QueryProvider { get; private set; }

    public MergeOption MergeOption { get; set; }

    public SaveChangesOptions SaveChangesDefaultOptions { get; set; }

    public ConcurrencyBehavior ConcurrencyBehavior
    {
      get => this._concurrencyBehavior;
      set => this._concurrencyBehavior = value;
    }

    public OrganizationServiceContext(IOrganizationService service)
      : this(service, true)
    {
    }

    internal OrganizationServiceContext(IOrganizationService service, bool trackEntityChanges)
    {
      this._service = service != null ? service : throw new ArgumentNullException(nameof (service));
      this._descriptors = new Dictionary<Entity, EntityDescriptor>((IEqualityComparer<Entity>) EqualityComparer<Entity>.Default);
      this._identityToDescriptor = new Dictionary<EntityReference, EntityDescriptor>((IEqualityComparer<EntityReference>) EqualityComparer<EntityReference>.Default);
      this._bindings = new Dictionary<LinkDescriptor, LinkDescriptor>(LinkDescriptor.EquivalenceComparer);
      this._roots = new HashSet<Entity>((IEqualityComparer<Entity>) EqualityComparer<Entity>.Default);
      this._trackEntityChanges = trackEntityChanges;
      this.QueryProvider = (IQueryProvider) new Microsoft.Xrm.Sdk.Linq.QueryProvider(this);
      this.MergeOption = MergeOption.AppendOnly;
      this._concurrencyBehavior = ConcurrencyBehavior.Default;
    }

    ~OrganizationServiceContext() => this.Dispose(false);

    public IQueryable<TEntity> CreateQuery<TEntity>() where TEntity : Entity
    {
      OrganizationServiceContext.CheckEntitySubclass(typeof (TEntity));
      return this.CreateQuery<TEntity>(this.QueryProvider, KnownProxyTypesProvider.GetInstance(true).GetNameForType(typeof (TEntity)));
    }

    public IQueryable<Entity> CreateQuery(string entityLogicalName) => !string.IsNullOrWhiteSpace(entityLogicalName) ? this.CreateQuery<Entity>(this.QueryProvider, entityLogicalName) : throw new ArgumentNullException(nameof (entityLogicalName));

    protected virtual IQueryable<TEntity> CreateQuery<TEntity>(
      IQueryProvider provider,
      string entityLogicalName)
    {
      return (IQueryable<TEntity>) new Microsoft.Xrm.Sdk.Linq.Query<TEntity>(provider, entityLogicalName);
    }

    public void LoadProperty(Entity entity, string propertyName)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof (entity));
      if (string.IsNullOrWhiteSpace(propertyName))
        throw new ArgumentNullException(nameof (propertyName));
      Type type = entity.GetType();
      OrganizationServiceContext.CheckEntitySubclass(type);
      PropertyInfo property = type.GetProperty(propertyName);
      RelationshipSchemaNameAttribute schemaNameAttribute = !(property == (PropertyInfo) null) ? property.GetFirstOrDefaultCustomAttribute<RelationshipSchemaNameAttribute>() : throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The property '{0}' does not exist on the entity '{1}'.", (object) propertyName, (object) entity));
      if (schemaNameAttribute != null)
      {
        Relationship relationship = schemaNameAttribute.Relationship;
        this.LoadProperty(entity, relationship);
      }
      else
        this.LoadProperty(entity, property.GetFirstOrDefaultCustomAttribute<AttributeLogicalNameAttribute>() ?? throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The closed type '{0}' does not have a corresponding '{1}' settable property.", (object) type, (object) propertyName)));
    }

    public void LoadProperty(Entity entity, Relationship relationship)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof (entity));
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      EntityDescriptor entityDescriptor;
      bool isAttached = this._descriptors.TryGetValue(entity, out entityDescriptor);
      if (isAttached)
      {
        if (this.MergeOption == MergeOption.NoTracking)
          throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The context can not load the related collection or reference for tracked entities while the 'MergeOption' is set to 'NoTracking'. Change the 'MergeOption' value or detach the '{0}' entity.", (object) entity.LogicalName));
        if (entityDescriptor.State == EntityStates.Added)
          throw new InvalidOperationException("The context can not load the related collection or reference for entities in the added state.");
      }
      else if (this.MergeOption != MergeOption.NoTracking)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The context can not load the related collection or reference for untracked entities while the 'MergeOption' is not set to 'NoTracking'. Change the 'MergeOption' to 'NoTracking' or attach the '{0}' entity.", (object) entity.LogicalName));
      EntityCollection relatedEntities = this.GetRelatedEntities(entity, relationship);
      if (relatedEntities == null)
        return;
      foreach (Entity entity1 in (Collection<Entity>) relatedEntities.Entities)
      {
        Entity target = this.MergeEntity(entity1);
        this.MergeRelationship(entity, relationship, target, isAttached);
      }
    }

    private void LoadProperty(Entity entity, AttributeLogicalNameAttribute attribute)
    {
      if (this.MergeOption != MergeOption.NoTracking && this.EnsureTracked(entity, nameof (entity)).State == EntityStates.Added)
        throw new InvalidOperationException("The context can not load the related collection or reference for entities in the added state.");
      string logicalName = attribute.LogicalName;
      RetrieveResponse retrieveResponse = (RetrieveResponse) this.Execute((OrganizationRequest) new RetrieveRequest()
      {
        Target = new EntityReference(entity.LogicalName, entity.Id),
        ColumnSet = new ColumnSet(new string[1]
        {
          logicalName
        })
      });
      if (retrieveResponse == null || retrieveResponse.Entity == null || !retrieveResponse.Entity.Attributes.Contains(logicalName))
        return;
      entity.Attributes[logicalName] = retrieveResponse.Entity.Attributes[logicalName];
    }

    public void Attach(Entity entity)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof (entity));
      this.ValidateAttach(entity, EntityStates.Unchanged);
      this.AttachEntityGraph(entity, EntityStates.Unchanged);
    }

    public bool Detach(Entity entity) => entity != null ? this.Detach(entity, true) : throw new ArgumentNullException(nameof (entity));

    public bool Detach(Entity entity, bool recursive)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof (entity));
      EntityDescriptor existingEntity;
      if (!this._descriptors.TryGetValue(entity, out existingEntity))
        return false;
      if (!recursive)
      {
        this.DetachEntityTracking(existingEntity);
        foreach (Tuple<Entity, Relationship, Entity> traverseRelatedEntity in OrganizationServiceContext.TraverseRelatedEntities(entity))
        {
          LinkDescriptor existingLink;
          if (this._bindings.TryGetValue(new LinkDescriptor(traverseRelatedEntity.Item1, traverseRelatedEntity.Item2, traverseRelatedEntity.Item3), out existingLink))
            this.DetachLinkTracking(existingLink);
        }
        foreach (LinkDescriptor existingLink in this.GetTargetingLinks(entity).ToList<LinkDescriptor>())
          this.DetachLinkTrackingAndRemoveEntity(existingLink);
      }
      else
      {
        foreach (Entity target in this.DetachEntityGraph(entity))
        {
          foreach (LinkDescriptor existingLink in this.GetTargetingLinks(target).ToList<LinkDescriptor>())
            this.DetachLinkTrackingAndRemoveEntity(existingLink);
        }
      }
      return true;
    }

    public void AttachLink(Entity source, Relationship relationship, Entity target)
    {
      if (source == null)
        throw new ArgumentNullException(nameof (source));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      this.EnsureRelatable(source, relationship, target, EntityStates.Unchanged);
      LinkDescriptor linkDescriptor = new LinkDescriptor(source, relationship, target);
      if (this.IsAttached(linkDescriptor))
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The context is already tracking the '{0}' relationship.", (object) relationship.SchemaName));
      this.AttachLinkTracking(linkDescriptor);
      OrganizationServiceContext.AddRelationshipIfNotContains(source, relationship, target);
    }

    public bool DetachLink(Entity source, Relationship relationship, Entity target)
    {
      if (source == null)
        throw new ArgumentNullException(nameof (source));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      LinkDescriptor existingLink;
      if (!this._bindings.TryGetValue(new LinkDescriptor(source, relationship, target), out existingLink))
        return false;
      this.DetachLinkTrackingAndRemoveEntity(existingLink);
      return true;
    }

    public IEnumerable<Entity> GetAttachedEntities() => this._descriptors.Values.Select<EntityDescriptor, Entity>((Func<EntityDescriptor, Entity>) (d => d.Entity));

    public bool IsAttached(Entity entity) => entity != null ? this._descriptors.ContainsKey(entity) : throw new ArgumentNullException(nameof (entity));

    public bool IsDeleted(Entity entity)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof (entity));
      EntityDescriptor entityDescriptor;
      return this._descriptors.TryGetValue(entity, out entityDescriptor) && entityDescriptor.State == EntityStates.Deleted;
    }

    public bool IsAttached(Entity source, Relationship relationship, Entity target)
    {
      if (source == null)
        throw new ArgumentNullException(nameof (source));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      return this.IsAttached(new LinkDescriptor(source, relationship, target));
    }

    private bool IsAttached(LinkDescriptor link) => this._bindings.ContainsKey(link);

    public bool IsDeleted(Entity source, Relationship relationship, Entity target)
    {
      if (source == null)
        throw new ArgumentNullException(nameof (source));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      LinkDescriptor linkDescriptor;
      return this._bindings.TryGetValue(new LinkDescriptor(source, relationship, target), out linkDescriptor) && linkDescriptor.State == EntityStates.Deleted;
    }

    private void ValidateAttach(Entity graph, EntityStates state) => OrganizationServiceContext.TraverseEntityGraph(graph, (Action<Entity>) (entity =>
    {
      if (entity == graph)
      {
        if (this.IsAttached(entity))
          throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The context is already tracking the '{0}' entity.", (object) entity.LogicalName));
      }
      else if (this.IsAttached(entity))
        return;
      EntityState? entityState1;
      if (state == EntityStates.Unchanged)
      {
        entityState1 = entity.EntityState;
        if (entityState1.HasValue)
        {
          entityState1 = entity.EntityState;
          EntityState entityState2 = EntityState.Unchanged;
          if (!(entityState1.GetValueOrDefault() == entityState2 & entityState1.HasValue))
            throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The '{0}' entity must be in the default (null) or unchanged state.", (object) entity.LogicalName));
        }
      }
      if (state == EntityStates.Added)
      {
        entityState1 = entity.EntityState;
        if (entityState1.HasValue)
        {
          entityState1 = entity.EntityState;
          EntityState entityState3 = EntityState.Created;
          if (!(entityState1.GetValueOrDefault() == entityState3 & entityState1.HasValue))
            throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The '{0}' entity must be in the default (null) or created state.", (object) entity.LogicalName));
        }
      }
      if (state != EntityStates.Added && entity.Id == Guid.Empty)
        throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The '{0}' entity has an empty ID.", (object) entity.LogicalName));
      if (entity.Id != Guid.Empty && this._identityToDescriptor.TryGetValue(entity.ToEntityReference(), out EntityDescriptor _))
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The context is already tracking a different '{0}' entity with the same identity.", (object) entity.LogicalName));
      if (entity.IsReadOnly)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The '{0}' entity is already attached to a context.", (object) entity.LogicalName));
    }), (Action<Entity, Relationship, Entity>) ((source, relationship, target) => { })).ToList<Entity>();

    private void AttachEntityGraph(Entity graph, EntityStates state) => OrganizationServiceContext.TraverseEntityGraph(graph, (Action<Entity>) (entity => this.AttachEntityTracking(new EntityDescriptor(state, entity.ToEntityReference(), entity))), (Action<Entity, Relationship, Entity>) ((source, relationship, target) => this.AttachLinkTracking(state, source, relationship, target))).ToList<Entity>();

    private void AttachEntityTracking(EntityDescriptor newEntity)
    {
      if (this.IsAttached(newEntity.Entity))
        return;
      if (newEntity.Identity.Id != Guid.Empty)
        this._identityToDescriptor.Add(newEntity.Identity, newEntity);
      this._descriptors.Add(newEntity.Entity, newEntity);
      if (this._trackEntityChanges)
        newEntity.Entity.IsReadOnly = true;
      newEntity.Entity.SetEntityStateInternal(OrganizationServiceContext.MapEntityState(newEntity.State) ?? newEntity.Entity.EntityState);
      this.OnBeginEntityTracking(newEntity.Entity);
    }

    private static EntityState? MapEntityState(EntityStates state)
    {
      switch (state)
      {
        case EntityStates.Unchanged:
          return new EntityState?(EntityState.Unchanged);
        case EntityStates.Added:
          return new EntityState?(EntityState.Created);
        case EntityStates.Modified:
          return new EntityState?(EntityState.Changed);
        default:
          return new EntityState?();
      }
    }

    private void AttachLinkTracking(
      EntityStates state,
      Entity source,
      Relationship relationship,
      Entity target)
    {
      EntityState? entityState1 = source.EntityState;
      EntityState entityState2 = EntityState.Created;
      int num;
      if (!(entityState1.GetValueOrDefault() == entityState2 & entityState1.HasValue))
      {
        EntityState? entityState3 = target.EntityState;
        EntityState entityState4 = EntityState.Created;
        if (!(entityState3.GetValueOrDefault() == entityState4 & entityState3.HasValue))
        {
          num = (int) state;
          goto label_4;
        }
      }
      num = 4;
label_4:
      EntityStates state1 = (EntityStates) num;
      if (state1 == EntityStates.Added)
        this._roots.Add(source);
      this.AttachLinkTracking(new LinkDescriptor(state1, source, relationship, target));
    }

    private void AttachLinkTracking(LinkDescriptor newLink)
    {
      if (this.IsAttached(newLink.Source, newLink.Relationship, newLink.Target))
        return;
      this._bindings.Add(newLink, newLink);
      this.OnBeginLinkTracking(newLink.Source, newLink.Relationship, newLink.Target);
    }

    private IEnumerable<Entity> DetachEntityGraph(Entity graph) => (IEnumerable<Entity>) this.TraverseEntityGraph(graph, new Action<EntityDescriptor>(this.DetachEntityTracking), new Action<LinkDescriptor>(this.DetachLinkTracking)).ToList<Entity>();

    private void DetachEntityTracking(EntityDescriptor existingEntity)
    {
      if (this._trackEntityChanges)
        existingEntity.Entity.IsReadOnly = false;
      existingEntity.State = EntityStates.Detached;
      int num = this._descriptors.Remove(existingEntity.Entity) ? 1 : 0;
      this._identityToDescriptor.Remove(existingEntity.Entity.ToEntityReference());
      this._roots.Remove(existingEntity.Entity);
      if (num == 0)
        return;
      this.OnEndEntityTracking(existingEntity.Entity);
    }

    private void DetachLinkTracking(LinkDescriptor existingLink)
    {
      existingLink.State = EntityStates.Detached;
      if (!this._bindings.Remove(existingLink))
        return;
      this.OnEndLinkTracking(existingLink.Source, existingLink.Relationship, existingLink.Target);
    }

    private void DetachLinkTrackingAndRemoveEntity(LinkDescriptor existingLink)
    {
      this.DetachLinkTracking(existingLink);
      OrganizationServiceContext.RemoveRelationshipIfContains(existingLink);
    }

    public void AddLink(Entity source, Relationship relationship, Entity target)
    {
      if (source == null)
        throw new ArgumentNullException(nameof (source));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      this.EnsureRelatable(source, relationship, target, EntityStates.Added);
      LinkDescriptor linkDescriptor = new LinkDescriptor(EntityStates.Added, source, relationship, target);
      if (this.IsAttached(linkDescriptor))
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The context is already tracking the '{0}' relationship.", (object) relationship.SchemaName));
      this.AttachLinkTracking(linkDescriptor);
      OrganizationServiceContext.AddRelationshipIfNotContains(source, relationship, target);
      this._roots.Add(source);
    }

    public void DeleteLink(Entity source, Relationship relationship, Entity target)
    {
      if (source == null)
        throw new ArgumentNullException(nameof (source));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      bool flag = this.EnsureRelatable(source, relationship, target, EntityStates.Deleted);
      LinkDescriptor linkDescriptor = new LinkDescriptor(source, relationship, target);
      LinkDescriptor existingLink;
      if (this._bindings.TryGetValue(linkDescriptor, out existingLink) && existingLink.State == EntityStates.Added)
      {
        this.DeleteLinkTrackingAndRemoveEntity(existingLink);
      }
      else
      {
        if (flag)
          throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "One or both of the ends of the '{0}' relationship is in the added state.", (object) relationship.SchemaName));
        if (existingLink == null)
        {
          this.AttachLinkTracking(linkDescriptor);
          existingLink = linkDescriptor;
        }
        if (existingLink.State == EntityStates.Deleted)
          return;
        existingLink.State = EntityStates.Deleted;
        OrganizationServiceContext.RemoveRelationshipIfContains(existingLink);
      }
    }

    public void AddObject(Entity entity)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof (entity));
      this.ValidateAttach(entity, EntityStates.Added);
      this.AttachEntityGraph(entity, EntityStates.Added);
      this._roots.Add(entity);
    }

    public void AddRelatedObject(Entity source, Relationship relationship, Entity target)
    {
      if (source == null)
        throw new ArgumentNullException(nameof (source));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      if (this.EnsureTracked(source, nameof (source)).State == EntityStates.Deleted)
        throw new InvalidOperationException("AddRelatedObject method only works if the source entity is in a non-deleted state.");
      this.AddObject(target);
      this.AddLink(source, relationship, target);
    }

    public void DeleteObject(Entity entity)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof (entity));
      this.DeleteObject(entity, false);
    }

    public void DeleteObject(Entity entity, bool recursive)
    {
      EntityDescriptor existingEntity = entity != null ? this.EnsureTracked(entity, nameof (entity)) : throw new ArgumentNullException(nameof (entity));
      if (!recursive)
      {
        this.DeleteEntityTracking(existingEntity);
        foreach (Tuple<Entity, Relationship, Entity> traverseRelatedEntity in OrganizationServiceContext.TraverseRelatedEntities(entity))
        {
          LinkDescriptor linkDescriptor;
          if (this._bindings.TryGetValue(new LinkDescriptor(traverseRelatedEntity.Item1, traverseRelatedEntity.Item2, traverseRelatedEntity.Item3), out linkDescriptor))
            linkDescriptor.State = EntityStates.Deleted;
        }
        foreach (LinkDescriptor existingLink in this.GetTargetingLinks(entity).ToList<LinkDescriptor>())
          this.DeleteLinkTrackingAndRemoveEntity(existingLink);
      }
      else
      {
        foreach (Entity target in this.DeleteEntityGraph(entity))
        {
          foreach (LinkDescriptor existingLink in this.GetTargetingLinks(target).ToList<LinkDescriptor>())
            this.DeleteLinkTrackingAndRemoveEntity(existingLink);
        }
      }
    }

    private IEnumerable<Entity> DeleteEntityGraph(Entity entity) => (IEnumerable<Entity>) this.TraverseEntityGraph(entity, new Action<EntityDescriptor>(this.DeleteEntityTracking), new Action<LinkDescriptor>(this.DeleteLinkTracking)).ToList<Entity>();

    private void DeleteEntityTracking(EntityDescriptor existingEntity)
    {
      switch (existingEntity.State)
      {
        case EntityStates.Added:
          this.DetachEntityTracking(existingEntity);
          goto case EntityStates.Deleted;
        case EntityStates.Deleted:
          this._roots.Remove(existingEntity.Entity);
          break;
        default:
          existingEntity.State = EntityStates.Deleted;
          goto case EntityStates.Deleted;
      }
    }

    private void DeleteLinkTracking(LinkDescriptor existingLink)
    {
      switch (existingLink.State)
      {
        case EntityStates.Added:
          this.DetachLinkTracking(existingLink);
          break;
        case EntityStates.Deleted:
          break;
        default:
          existingLink.State = EntityStates.Deleted;
          break;
      }
    }

    private void DeleteLinkTrackingAndRemoveEntity(LinkDescriptor existingLink)
    {
      this.DeleteLinkTracking(existingLink);
      OrganizationServiceContext.RemoveRelationshipIfContains(existingLink);
    }

    public void UpdateObject(Entity entity)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof (entity));
      this.UpdateObject(entity, false);
    }

    public void UpdateObject(Entity entity, bool recursive)
    {
      EntityDescriptor existingEntity = entity != null ? this.EnsureTracked(entity, nameof (entity)) : throw new ArgumentNullException(nameof (entity));
      if (!recursive)
      {
        this.InternalUpdate(existingEntity);
      }
      else
      {
        this.ValidateUpdate(entity);
        this.UpdateEntityGraph(entity);
      }
    }

    private void ValidateUpdate(Entity graph) => OrganizationServiceContext.TraverseEntityGraph(graph, (Action<Entity>) (entity =>
    {
      if (!this.IsAttached(entity))
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The context is not currently tracking the '{0}' entity.", (object) entity.LogicalName));
    }), (Action<Entity, Relationship, Entity>) ((source, relationship, target) => { })).ToList<Entity>();

    private void UpdateEntityGraph(Entity entity) => this.TraverseEntityGraph(entity, new Action<EntityDescriptor>(this.InternalUpdate), (Action<LinkDescriptor>) (link => { })).ToList<Entity>();

    private void InternalUpdate(EntityDescriptor existingEntity)
    {
      if (existingEntity.State != EntityStates.Unchanged)
        return;
      existingEntity.State = EntityStates.Modified;
      existingEntity.Entity.SetEntityStateInternal(new EntityState?(EntityState.Changed));
      this._roots.Add(existingEntity.Entity);
    }

    public OrganizationResponse Execute(OrganizationRequest request)
    {
      if (request == null)
        throw new ArgumentNullException(nameof (request));
      this.OnExecuting(request);
      OrganizationResponse response;
      try
      {
        response = this._service.Execute(request);
      }
      catch (Exception ex)
      {
        this.OnExecute(request, ex);
        throw;
      }
      this.OnExecute(request, response);
      return response;
    }

    public void ClearChanges()
    {
      foreach (LinkDescriptor existingLink in this._bindings.Values.ToList<LinkDescriptor>())
        this.DetachLinkTracking(existingLink);
      foreach (EntityDescriptor existingEntity in this._descriptors.Values.ToList<EntityDescriptor>())
        this.DetachEntityTracking(existingEntity);
      this._bindings.Clear();
      this._descriptors.Clear();
      this._identityToDescriptor.Clear();
      this._roots.Clear();
    }

    public SaveChangesResultCollection SaveChanges() => this.SaveChanges(this.SaveChangesDefaultOptions);

    public SaveChangesResultCollection SaveChanges(
      SaveChangesOptions options)
    {
      this.OnSavingChanges(options);
      SaveChangesResultCollection results = new SaveChangesResultCollection(options);
      foreach (Tuple<DisassociateRequest, IEnumerable<LinkDescriptor>> tuple in this.GetDisassociateRequests().ToList<Tuple<DisassociateRequest, IEnumerable<LinkDescriptor>>>())
      {
        SaveChangesResult result = this.SaveChange((OrganizationRequest) tuple.Item1, (IList<SaveChangesResult>) results);
        if (!OrganizationServiceContext.CanContinue(options, result))
        {
          this.OnSaveChanges(results);
          throw new SaveChangesException(result.Error, results);
        }
        foreach (LinkDescriptor existingLink in tuple.Item2)
          this.DetachLinkTracking(existingLink);
      }
      foreach (EntityDescriptor existingEntity in this.GetDeletedEntities().ToList<EntityDescriptor>())
      {
        EntityReference entityReference = existingEntity.Entity.ToEntityReference();
        SaveChangesResult result = this.SaveChange((OrganizationRequest) new DeleteRequest()
        {
          Target = entityReference,
          ConcurrencyBehavior = this._concurrencyBehavior
        }, (IList<SaveChangesResult>) results);
        if (!OrganizationServiceContext.CanContinue(options, result))
        {
          this.OnSaveChanges(results);
          throw new SaveChangesException(result.Error, results);
        }
        this.DetachEntityTracking(existingEntity);
        foreach (LinkDescriptor existingLink in this.GetTargetingLinks(existingEntity.Entity).ToList<LinkDescriptor>())
          this.DetachLinkTracking(existingLink);
      }
      foreach (Entity entity in OrganizationServiceContext.FilterRoots((ICollection<Entity>) new HashSet<Entity>((IEnumerable<Entity>) this._roots)).ToList<Entity>())
      {
        foreach (SaveChangesResult changeRequest in this.GetChangeRequests(results, entity))
        {
          if (!OrganizationServiceContext.CanContinue(options, changeRequest))
          {
            this.OnSaveChanges(results);
            throw new SaveChangesException(changeRequest.Error, results);
          }
        }
      }
      this.DetachAllOnSave();
      this.OnSaveChanges(results);
      return results;
    }

    private static IEnumerable<Entity> FilterRoots(ICollection<Entity> roots)
    {
      HashSet<Entity> filtered = new HashSet<Entity>();
      while (roots.Any<Entity>())
        OrganizationServiceContext.FilterRoots((ICollection<Entity>) filtered, roots);
      return (IEnumerable<Entity>) filtered;
    }

    private static void FilterRoots(ICollection<Entity> filtered, ICollection<Entity> unfiltered)
    {
      Entity root = unfiltered.First<Entity>();
      OrganizationServiceContext.TraverseEntityGraph(root, (Action<Entity>) (entity =>
      {
        if (entity == root)
          return;
        filtered.Remove(entity);
        unfiltered.Remove(entity);
      }), (Action<Entity, Relationship, Entity>) ((s, r, t) => { })).ToList<Entity>();
      unfiltered.Remove(root);
      filtered.Add(root);
    }

    private bool CanDeleteRelationship(LinkDescriptor link)
    {
      EntityDescriptor entityDescriptor1;
      EntityDescriptor entityDescriptor2;
      return link.State == EntityStates.Deleted && this._descriptors.TryGetValue(link.Source, out entityDescriptor1) && entityDescriptor1.State != EntityStates.Deleted && this._descriptors.TryGetValue(link.Target, out entityDescriptor2) && entityDescriptor2.State != EntityStates.Deleted;
    }

    private static bool CanContinue(SaveChangesOptions options, SaveChangesResult result) => (options & SaveChangesOptions.ContinueOnError) == SaveChangesOptions.ContinueOnError || result.Error == null;

    private SaveChangesResult SaveChange(
      OrganizationRequest request,
      IList<SaveChangesResult> results)
    {
      SaveChangesResult saveChangesResult;
      try
      {
        OrganizationResponse response = this.Execute(request);
        saveChangesResult = new SaveChangesResult(request, response);
      }
      catch (Exception ex)
      {
        saveChangesResult = new SaveChangesResult(request, ex);
      }
      results.Add(saveChangesResult);
      return saveChangesResult;
    }

    private IEnumerable<Tuple<DisassociateRequest, IEnumerable<LinkDescriptor>>> GetDisassociateRequests()
    {
            //OrganizationServiceContext organizationServiceContext = this;
            //foreach (IGrouping<\u003C\u003Ef__AnonymousType4<Entity, Relationship>, LinkDescriptor> source in organizationServiceContext._bindings.Values.Where<LinkDescriptor>(new Func<LinkDescriptor, bool>(organizationServiceContext.CanDeleteRelationship)).GroupBy(b => new
            //{
            //  Source = b.Source,
            //  Relationship = b.Relationship
            //}))
            //{
            //  EntityReference entityReference = source.Key.Source.ToEntityReference();
            //  Relationship relationship = source.Key.Relationship;
            //  List<LinkDescriptor> list = source.ToList<LinkDescriptor>();
            //  EntityReferenceCollection referenceCollection = new EntityReferenceCollection();
            //  referenceCollection.AddRange(list.Select<LinkDescriptor, EntityReference>((Func<LinkDescriptor, EntityReference>) (grouping => grouping.Target.ToEntityReference())));
            //  yield return new Tuple<DisassociateRequest, IEnumerable<LinkDescriptor>>(new DisassociateRequest()
            //  {
            //    Target = entityReference,
            //    Relationship = relationship,
            //    RelatedEntities = referenceCollection
            //  }, (IEnumerable<LinkDescriptor>) list);
            //}
            // тут
            throw new NotImplementedException();
        }

    private IEnumerable<EntityDescriptor> GetDeletedEntities() => this._descriptors.Values.Where<EntityDescriptor>((Func<EntityDescriptor, bool>) (d => d.State == EntityStates.Deleted));

    private IEnumerable<SaveChangesResult> GetChangeRequests(
      SaveChangesResultCollection results,
      Entity entity)
    {
      List<Entity> path = new List<Entity>()
      {
        entity
      };
      List<LinkDescriptor> localCircularLinks = new List<LinkDescriptor>();
      EntityState? entityState1 = entity.EntityState;
      EntityState entityState2 = EntityState.Unchanged;
      foreach (SaveChangesResult saveChangesResult in entityState1.GetValueOrDefault() == entityState2 & entityState1.HasValue ? this.GetChangeRequestsFromUnchangedTree(results, entity, (IEnumerable<Entity>) path, (IList<LinkDescriptor>) localCircularLinks) : this.GetChangeRequestsFromChangedTree(results, entity, (IEnumerable<Entity>) path, (IList<LinkDescriptor>) localCircularLinks))
        yield return saveChangesResult;
      if (localCircularLinks.Any<LinkDescriptor>())
      {
        foreach (SaveChangesResult associateResult in this.ToAssociateResults((IEnumerable<LinkDescriptor>) localCircularLinks, (IList<SaveChangesResult>) results))
          yield return associateResult;
      }
    }

    private IEnumerable<SaveChangesResult> GetChangeRequestsFromChangedTree(
      SaveChangesResultCollection results,
      Entity entity,
      IEnumerable<Entity> path,
      IList<LinkDescriptor> circularLinks)
    {
      List<Entity> localPath = new List<Entity>()
      {
        entity
      };
      List<LinkDescriptor> localCircularLinks = new List<LinkDescriptor>();
      foreach (SaveChangesResult saveChangesResult in this.GetChangeRequestsFromSubtree(results, entity, (IEnumerable<Entity>) localPath, (IList<LinkDescriptor>) localCircularLinks, path, circularLinks))
        yield return saveChangesResult;
      yield return this.GetSaveChangesResult(results, entity);
      this.DetachOnSave(entity);
      if (localCircularLinks.Any<LinkDescriptor>())
      {
        foreach (SaveChangesResult associateResult in this.ToAssociateResults((IEnumerable<LinkDescriptor>) localCircularLinks, (IList<SaveChangesResult>) results))
          yield return associateResult;
      }
    }

    private IEnumerable<SaveChangesResult> GetChangeRequestsFromUnchangedTree(
      SaveChangesResultCollection results,
      Entity entity,
      IEnumerable<Entity> path,
      IList<LinkDescriptor> circularLinks)
    {
      List<LinkDescriptor> relatedLinks = new List<LinkDescriptor>();
      foreach (var data in entity.RelatedEntities.SelectMany((Func<KeyValuePair<Relationship, EntityCollection>, IEnumerable<Entity>>) (relationship => (IEnumerable<Entity>) relationship.Value.Entities), (relationship, target) => new
      {
        relationship = relationship,
        target = target
      }).GroupBy(_param1 => _param1.target, _param1 => new
      {
        Relationship = _param1.relationship,
        Target = _param1.target
      }).Select(grp => new
      {
        Target = grp.Key,
        Relationships = grp.Select(g => g.Relationship).ToList<KeyValuePair<Relationship, EntityCollection>>()
      }).ToList())
      {
        Entity target = data.Target;
        List<LinkDescriptor> addedLinks = new List<LinkDescriptor>();
        foreach (KeyValuePair<Relationship, EntityCollection> relationship in data.Relationships)
        {
          LinkDescriptor linkDescriptor;
          if (this._bindings.TryGetValue(new LinkDescriptor(entity, relationship.Key, target), out linkDescriptor) && linkDescriptor.State == EntityStates.Added)
            addedLinks.Add(linkDescriptor);
        }
        if (!path.Contains<Entity>(target))
        {
          IEnumerable<Entity> path1 = path.Concat<Entity>((IEnumerable<Entity>) new Entity[1]
          {
            target
          });
          EntityState? entityState1 = target.EntityState;
          EntityState entityState2 = EntityState.Unchanged;
          foreach (SaveChangesResult saveChangesResult in entityState1.GetValueOrDefault() == entityState2 & entityState1.HasValue ? this.GetChangeRequestsFromUnchangedTree(results, target, path1, circularLinks) : this.GetChangeRequestsFromChangedTree(results, target, path1, circularLinks))
            yield return saveChangesResult;
          if (addedLinks.Any<LinkDescriptor>())
            relatedLinks.AddRange((IEnumerable<LinkDescriptor>) addedLinks);
        }
        else if (addedLinks.Any<LinkDescriptor>())
        {
          foreach (LinkDescriptor linkDescriptor in addedLinks)
          {
            circularLinks.Add(linkDescriptor);
            OrganizationServiceContext.SetNewId(linkDescriptor.Source);
            OrganizationServiceContext.SetNewId(linkDescriptor.Target);
          }
        }
        addedLinks = (List<LinkDescriptor>) null;
      }
      if (relatedLinks.Any<LinkDescriptor>())
      {
        foreach (SaveChangesResult associateResult in this.ToAssociateResults((IEnumerable<LinkDescriptor>) relatedLinks, (IList<SaveChangesResult>) results))
          yield return associateResult;
        foreach (LinkDescriptor linkDescriptor in relatedLinks)
        {
          LinkDescriptor link = linkDescriptor;
          this.DetachLinkTrackingAndRemoveEntity(link);
          EntityDescriptor existingEntity;
          if (!this._bindings.Values.Any<LinkDescriptor>((Func<LinkDescriptor, bool>) (b => b.Target == link.Target)) && this._descriptors.TryGetValue(link.Target, out existingEntity))
            this.DetachEntityTracking(existingEntity);
        }
      }
      this._roots.Remove(entity);
    }

    private IEnumerable<SaveChangesResult> GetChangeRequestsFromSubtree(
      SaveChangesResultCollection results,
      Entity entity,
      IEnumerable<Entity> localPath,
      IList<LinkDescriptor> localCircularLinks,
      IEnumerable<Entity> path,
      IList<LinkDescriptor> circularLinks)
    {
      foreach (var data in entity.RelatedEntities.SelectMany((Func<KeyValuePair<Relationship, EntityCollection>, IEnumerable<Entity>>) (relationship => (IEnumerable<Entity>) relationship.Value.Entities), (relationship, target) => new
      {
        relationship = relationship,
        target = target
      }).GroupBy(_param1 => _param1.target, _param1 => new
      {
        Relationship = _param1.relationship,
        Target = _param1.target
      }).Select(grp => new
      {
        Target = grp.Key,
        Relationships = grp.Select(g => g.Relationship).ToList<KeyValuePair<Relationship, EntityCollection>>()
      }).ToList())
      {
        Entity target = data.Target;
        List<LinkDescriptor> source = new List<LinkDescriptor>();
        foreach (KeyValuePair<Relationship, EntityCollection> relationship in data.Relationships)
        {
          LinkDescriptor existingLink;
          if (this._bindings.TryGetValue(new LinkDescriptor(entity, relationship.Key, target), out existingLink))
          {
            if (existingLink.State == EntityStates.Added)
              source.Add(existingLink);
            else
              this.DetachLinkTrackingAndRemoveEntity(existingLink);
          }
        }
        bool flag1 = localPath.Contains<Entity>(target);
        bool flag2 = path.Contains<Entity>(target);
        if (!flag1 && !flag2)
        {
          IEnumerable<Entity> localPath1 = localPath.Concat<Entity>((IEnumerable<Entity>) new Entity[1]
          {
            target
          });
          IEnumerable<Entity> path1 = path.Concat<Entity>((IEnumerable<Entity>) new Entity[1]
          {
            target
          });
          IEnumerable<SaveChangesResult> saveChangesResults;
          if (!source.Any<LinkDescriptor>())
          {
            EntityState? entityState1 = target.EntityState;
            EntityState entityState2 = EntityState.Unchanged;
            saveChangesResults = entityState1.GetValueOrDefault() == entityState2 & entityState1.HasValue ? this.GetChangeRequestsFromUnchangedTree(results, target, path1, circularLinks) : this.GetChangeRequestsFromChangedTree(results, target, path1, circularLinks);
          }
          else
            saveChangesResults = this.GetChangeRequestsFromSubtree(results, target, localPath1, localCircularLinks, path1, circularLinks);
          foreach (SaveChangesResult saveChangesResult in saveChangesResults)
            yield return saveChangesResult;
        }
        else if (source.Any<LinkDescriptor>())
        {
          foreach (LinkDescriptor existingLink in source)
          {
            if (flag1)
              localCircularLinks.Add(existingLink);
            else
              circularLinks.Add(existingLink);
            this.DetachLinkTrackingAndRemoveEntity(existingLink);
            OrganizationServiceContext.SetNewId(existingLink.Source);
            OrganizationServiceContext.SetNewId(existingLink.Target);
          }
        }
      }
    }

    private static OrganizationRequest GetRequest(
      Entity entity,
      ConcurrencyBehavior concurrencyBehavior)
    {
      EntityState? entityState1 = entity.EntityState;
      EntityState entityState2 = EntityState.Created;
      if (entityState1.GetValueOrDefault() == entityState2 & entityState1.HasValue)
        return (OrganizationRequest) new CreateRequest()
        {
          Target = entity
        };
      EntityState? entityState3 = entity.EntityState;
      EntityState entityState4 = EntityState.Changed;
      if (!(entityState3.GetValueOrDefault() == entityState4 & entityState3.HasValue))
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The '{0}' entity must be in the created or changed state.", (object) entity.LogicalName));
      return (OrganizationRequest) new UpdateRequest()
      {
        Target = entity,
        ConcurrencyBehavior = concurrencyBehavior
      };
    }

    private SaveChangesResult GetSaveChangesResult(
      SaveChangesResultCollection results,
      Entity entity)
    {
      OrganizationRequest request = OrganizationServiceContext.GetRequest(entity, this._concurrencyBehavior);
      if (request is CreateRequest createRequest)
        OrganizationServiceContext.TraverseEntityGraph(createRequest.Target, new Action<Entity>(OrganizationServiceContext.SetNewId), (Action<Entity, Relationship, Entity>) ((source, relationship, target) => { }), (IEnumerable<Entity>) new Entity[1]
        {
          createRequest.Target
        }).ToList<Entity>();
      SaveChangesResult saveChangesResult = this.SaveChange(request, (IList<SaveChangesResult>) results);
      if (!(saveChangesResult.Response is CreateResponse response) || !(entity.Id == Guid.Empty))
        return saveChangesResult;
      entity.Id = response.id;
      return saveChangesResult;
    }

    private void DetachOnSave(Entity entity)
    {
      foreach (Entity target in this.DetachEntityGraph(entity))
      {
        bool flag = true;
        foreach (LinkDescriptor existingLink in this.GetTargetingLinks(target).ToList<LinkDescriptor>())
        {
          if (existingLink.State == EntityStates.Added)
          {
            existingLink.Target.RelatedEntities.ClearInternal();
            if (!this.IsAttached(existingLink.Target))
            {
              this.AttachEntityGraph(existingLink.Target, EntityStates.Unchanged);
              existingLink.Target.SetEntityStateInternal(new EntityState?(EntityState.Unchanged));
              flag = false;
            }
          }
          else
            this.DetachLinkTrackingAndRemoveEntity(existingLink);
        }
        if (flag)
          target.SetEntityStateInternal(new EntityState?());
      }
    }

    private void DetachAllOnSave()
    {
      foreach (EntityDescriptor existingEntity in this._descriptors.Values.ToList<EntityDescriptor>())
        this.DetachEntityTracking(existingEntity);
      foreach (LinkDescriptor existingLink in this._bindings.Values.ToList<LinkDescriptor>())
        this.DetachLinkTracking(existingLink);
      this._roots.Clear();
    }

    private static EntityReferenceCollection ToEntityReferenceCollection(
      IEnumerable<LinkDescriptor> links)
    {
      EntityReferenceCollection referenceCollection = new EntityReferenceCollection();
      referenceCollection.AddRange(links.Select<LinkDescriptor, EntityReference>((Func<LinkDescriptor, EntityReference>) (b => b.Target.ToEntityReference())));
      return referenceCollection;
    }

    private static IEnumerable<AssociateRequest> ToAssociateRequests(
      IEnumerable<LinkDescriptor> links)
    {
            //return links.GroupBy(link => new
            //{
            //  Source = link.Source,
            //  Relationship = link.Relationship
            //}).Select<IGrouping<\u003C\u003Ef__AnonymousType4<Entity, Relationship>, LinkDescriptor>, AssociateRequest>(grp => new AssociateRequest()
            //{
            //  Target = grp.Key.Source.ToEntityReference(),
            //  Relationship = grp.Key.Relationship,
            //  RelatedEntities = OrganizationServiceContext.ToEntityReferenceCollection((IEnumerable<LinkDescriptor>) grp)
            //});
            // тут
            throw new NotImplementedException();
        }

    private IEnumerable<SaveChangesResult> ToAssociateResults(
      IEnumerable<LinkDescriptor> links,
      IList<SaveChangesResult> results)
    {
      return OrganizationServiceContext.ToAssociateRequests(links).Select<AssociateRequest, SaveChangesResult>((Func<AssociateRequest, SaveChangesResult>) (associate => this.SaveChange((OrganizationRequest) associate, results)));
    }

    private static void SetNewId(Entity entity)
    {
      EntityState? entityState1 = entity.EntityState;
      EntityState entityState2 = EntityState.Created;
      if (!(entityState1.GetValueOrDefault() == entityState2 & entityState1.HasValue) || !(entity.Id == Guid.Empty))
        return;
      Guid sequentialGuid = OrganizationServiceContext.CreateSequentialGuid();
      entity.Id = sequentialGuid;
    }

    [SecuritySafeCritical]
    private static Guid CreateSequentialGuid()
    {
      if (false)
        return Guid.NewGuid();
      try
      {
        new PermissionSet(PermissionState.Unrestricted).Assert();
        if (OrganizationServiceContext.SequentialGuidOverride != null)
          return OrganizationServiceContext.SequentialGuidOverride();
      }
      finally
      {
        CodeAccessPermission.RevertAssert();
      }
      Guid empty = Guid.Empty;
      long sequential;
      try
      {
        new PermissionSet(PermissionState.Unrestricted).Assert();
        sequential = NativeMethods.UuidCreateSequential(ref empty);
      }
      finally
      {
        CodeAccessPermission.RevertAssert();
      }
      if (sequential != 0L)
        return Guid.NewGuid();
      byte[] byteArray = empty.ToByteArray();
      byte num1 = byteArray[2];
      byteArray[2] = byteArray[1];
      byteArray[1] = num1;
      byte num2 = byteArray[3];
      byteArray[3] = byteArray[0];
      byteArray[0] = num2;
      byte num3 = byteArray[4];
      byteArray[4] = byteArray[5];
      byteArray[5] = num3;
      byte num4 = byteArray[6];
      byteArray[6] = byteArray[7];
      byteArray[7] = num4;
      return new Guid(byteArray);
    }

    internal Entity MergeEntity(Entity entity)
    {
      if (this.MergeOption == MergeOption.NoTracking || entity == null || entity.Id == Guid.Empty)
        return entity;
      EntityDescriptor entityDescriptor = new EntityDescriptor(EntityStates.Unchanged, entity.ToEntityReference(), entity);
      EntityDescriptor existingEntity;
      this._identityToDescriptor.TryGetValue(entityDescriptor.Identity, out existingEntity);
      if (existingEntity != null)
      {
        if (this.MergeOption == MergeOption.AppendOnly || this.MergeOption == MergeOption.PreserveChanges && existingEntity.State != EntityStates.Unchanged)
          return existingEntity.Entity;
        this.DetachEntityTracking(existingEntity);
      }
      this._descriptors[entityDescriptor.Entity] = entityDescriptor;
      this._identityToDescriptor[entityDescriptor.Identity] = entityDescriptor;
      entityDescriptor.Entity.SetEntityStateInternal(new EntityState?(EntityState.Unchanged));
      if (this._trackEntityChanges)
        entityDescriptor.Entity.IsReadOnly = true;
      this.OnBeginEntityTracking(entityDescriptor.Entity);
      return entityDescriptor.Entity;
    }

    private void MergeRelationship(
      Entity source,
      Relationship relationship,
      Entity target,
      bool isAttached)
    {
      if (source == null)
        throw new ArgumentNullException(nameof (source));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      if (isAttached)
      {
        LinkDescriptor key = new LinkDescriptor(source, relationship, target);
        if (this.MergeOption == MergeOption.NoTracking)
          return;
        LinkDescriptor linkDescriptor;
        this._bindings.TryGetValue(key, out linkDescriptor);
        if (linkDescriptor != null && (this.MergeOption == MergeOption.AppendOnly || this.MergeOption == MergeOption.PreserveChanges && linkDescriptor.State != EntityStates.Unchanged))
        {
          OrganizationServiceContext.AddRelationshipIfNotContains(source, relationship, linkDescriptor.Target);
          return;
        }
        this._bindings[key] = key;
        this.OnBeginLinkTracking(key.Source, key.Relationship, key.Target);
      }
      if (!source.RelatedEntities.Contains(relationship))
      {
        source.RelatedEntities.SetItemInternal(relationship, new EntityCollection((IList<Entity>) new Entity[1]
        {
          target
        })
        {
          EntityName = target.LogicalName
        });
      }
      else
      {
        EntityReference targetReference = target.ToEntityReference();
        DataCollection<Entity> entities = source.RelatedEntities[relationship].Entities;
        Entity entity = entities.SingleOrDefault<Entity>((Func<Entity, bool>) (e => object.Equals((object) e.ToEntityReference(), (object) targetReference)));
        if (entity != null)
          entities.Remove(entity);
        entities.Add(target);
      }
    }

    private static void AddRelationshipIfNotContains(
      Entity source,
      Relationship relationship,
      Entity target)
    {
      if (!source.RelatedEntities.Contains(relationship))
      {
        source.RelatedEntities.SetItemInternal(relationship, new EntityCollection((IList<Entity>) new Entity[1]
        {
          target
        })
        {
          EntityName = target.LogicalName
        });
      }
      else
      {
        if (source.RelatedEntities[relationship].Entities.Contains(target))
          return;
        source.RelatedEntities[relationship].Entities.Add(target);
      }
    }

    private static bool RemoveRelationshipIfContains(LinkDescriptor existingLink) => OrganizationServiceContext.RemoveRelationshipIfContains(existingLink.Source, existingLink.Relationship, existingLink.Target);

    private static bool RemoveRelationshipIfContains(
      Entity source,
      Relationship relationship,
      Entity target)
    {
      if (!source.RelatedEntities.Contains(relationship))
        return false;
      EntityCollection relatedEntity = source.RelatedEntities[relationship];
      bool flag = relatedEntity.Entities.Remove(target);
      if (relatedEntity.Entities.Count == 0)
        source.RelatedEntities.RemoveInternal(relationship);
      return flag;
    }

    private static void CheckEntitySubclass(Type entityType)
    {
      if (!entityType.IsSubclassOf(typeof (Entity)))
        throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The specified type '{0}' must be a subclass of '{1}'.", (object) entityType, (object) typeof (Entity)));
      if (string.IsNullOrWhiteSpace(KnownProxyTypesProvider.GetInstance(true).GetNameForType(entityType)))
        throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The specified type '{0}' is not a known entity type.", (object) entityType));
    }

    private EntityCollection GetRelatedEntities(
      Entity entity,
      Relationship relationship)
    {
      string relatedEntityName = this.GetRelatedEntityName(entity, relationship);
      RelationshipQueryCollection relationshipQueryCollection1 = new RelationshipQueryCollection();
      relationshipQueryCollection1.Add(relationship, (QueryBase) new QueryExpression(relatedEntityName)
      {
        ColumnSet = new ColumnSet(true)
      });
      RelationshipQueryCollection relationshipQueryCollection2 = relationshipQueryCollection1;
      EntityReference entityReference = new EntityReference(entity.LogicalName, entity.Id);
      RelatedEntityCollection relatedEntities = (this.Execute((OrganizationRequest) new RetrieveRequest()
      {
        Target = entityReference,
        ColumnSet = new ColumnSet(),
        RelatedEntitiesQuery = relationshipQueryCollection2
      }) as RetrieveResponse).Entity.RelatedEntities;
      return !relatedEntities.Contains(relationship) ? (EntityCollection) null : relatedEntities[relationship];
    }

    private string GetRelatedEntityName(Entity entity, Relationship relationship)
    {
      if (relationship.PrimaryEntityRole.HasValue)
        return entity.LogicalName;
      RetrieveRelationshipResponse relationshipResponse = this.Execute((OrganizationRequest) new RetrieveRelationshipRequest()
      {
        Name = relationship.SchemaName
      }) as RetrieveRelationshipResponse;
      if (relationshipResponse.RelationshipMetadata is OneToManyRelationshipMetadata relationshipMetadata1)
        return !(relationshipMetadata1.ReferencingEntity == entity.LogicalName) ? relationshipMetadata1.ReferencingEntity : relationshipMetadata1.ReferencedEntity;
      if (!(relationshipResponse.RelationshipMetadata is ManyToManyRelationshipMetadata relationshipMetadata2))
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Unable to load the '{0}' relationship.", (object) relationship.SchemaName));
      return !(relationshipMetadata2.Entity1LogicalName == entity.LogicalName) ? relationshipMetadata2.Entity1LogicalName : relationshipMetadata2.Entity2LogicalName;
    }

    private static IEnumerable<Entity> TraverseEntityGraph(
      Entity entity,
      Action<Entity> onEntity,
      Action<Entity, Relationship, Entity> onLink)
    {
      return OrganizationServiceContext.TraverseEntityGraph(entity, onEntity, onLink, (IEnumerable<Entity>) Array.Empty<Entity>());
    }

    private static IEnumerable<Entity> TraverseEntityGraph(
      Entity entity,
      Action<Entity> onEntity,
      Action<Entity, Relationship, Entity> onLink,
      IEnumerable<Entity> path)
    {
      onEntity(entity);
      yield return entity;
      foreach (Tuple<Entity, Relationship, Entity> traverseRelatedEntity in OrganizationServiceContext.TraverseRelatedEntities(entity))
      {
        Entity entity1 = traverseRelatedEntity.Item1;
        Relationship relationship = traverseRelatedEntity.Item2;
        Entity entity2 = traverseRelatedEntity.Item3;
        onLink(entity1, relationship, entity2);
        if (!path.Contains<Entity>(entity2))
        {
          IEnumerable<Entity> path1 = path.Concat<Entity>((IEnumerable<Entity>) new Entity[1]
          {
            entity2
          });
          foreach (Entity entity3 in OrganizationServiceContext.TraverseEntityGraph(entity2, onEntity, onLink, path1))
            yield return entity3;
        }
      }
    }

    private static IEnumerable<Tuple<Entity, Relationship, Entity>> TraverseRelatedEntities(
      Entity entity)
    {
            //      return entity.RelatedEntities.ToList<KeyValuePair<Relationship, EntityCollection>>().Select(relatedEntity => new
            //{
            //  relatedEntity = relatedEntity,
            //  relationship = relatedEntity.Key
            //}).Select(_param1 => new
            //{
            //  \u003C\u003Eh__TransparentIdentifier0 = _param1,
            //  entities = _param1.relatedEntity.Value.Entities.ToList<Entity>()
            //}).SelectMany(_param1 => (IEnumerable<Entity>) _param1.entities, (_param1, target) => new Tuple<Entity, Relationship, Entity>(entity, _param1.\u003C\u003Eh__TransparentIdentifier0.relationship, target));
            // тут
            throw new NotImplementedException(); 
        }

    private IEnumerable<Entity> TraverseEntityGraph(
      Entity graph,
      Action<EntityDescriptor> onEntity,
      Action<LinkDescriptor> onLink)
    {
      return OrganizationServiceContext.TraverseEntityGraph(graph, (Action<Entity>) (entity =>
      {
        EntityDescriptor entityDescriptor;
        if (!this._descriptors.TryGetValue(entity, out entityDescriptor))
          return;
        onEntity(entityDescriptor);
      }), (Action<Entity, Relationship, Entity>) ((source, relationship, target) =>
      {
        LinkDescriptor linkDescriptor;
        if (!this._bindings.TryGetValue(new LinkDescriptor(source, relationship, target), out linkDescriptor))
          return;
        onLink(linkDescriptor);
      }));
    }

    private IEnumerable<LinkDescriptor> GetTargetingLinks(Entity target) => this._bindings.Values.Where<LinkDescriptor>((Func<LinkDescriptor, bool>) (b => b.Target == target));

    private EntityDescriptor EnsureTracked(Entity entity, string parameterName)
    {
      if (entity == null)
        throw new ArgumentNullException(parameterName);
      EntityDescriptor entityDescriptor;
      if (!this._descriptors.TryGetValue(entity, out entityDescriptor))
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The context is not currently tracking the '{0}' entity.", (object) entity.LogicalName));
      return entityDescriptor;
    }

    private bool EnsureRelatable(
      Entity source,
      Relationship relationship,
      Entity target,
      EntityStates state)
    {
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      EntityDescriptor entityDescriptor1 = this.EnsureTracked(source, nameof (source));
      if (source == target)
        throw new InvalidOperationException("The entity cannot link to itself.");
      if (source.Id != Guid.Empty && target.Id != Guid.Empty && source.Id == target.Id && string.Equals(source.LogicalName, target.LogicalName, StringComparison.Ordinal))
        throw new InvalidOperationException("The entity cannot link to itself.");
      EntityDescriptor entityDescriptor2 = (EntityDescriptor) null;
      if (target != null || state != EntityStates.Modified && state != EntityStates.Unchanged)
        entityDescriptor2 = this.EnsureTracked(target, nameof (target));
      if ((state == EntityStates.Added || state == EntityStates.Unchanged) && (entityDescriptor1.State == EntityStates.Deleted || entityDescriptor2 != null && entityDescriptor2.State == EntityStates.Deleted))
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "One or both of the ends of the '{0}' relationship is in the deleted state.", (object) relationship.SchemaName));
      if (state != EntityStates.Deleted && state != EntityStates.Unchanged || entityDescriptor1.State != EntityStates.Added && (entityDescriptor2 == null || entityDescriptor2.State != EntityStates.Added))
        return false;
      if (state != EntityStates.Deleted)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "One or both of the ends of the '{0}' relationship is in the added state.", (object) relationship.SchemaName));
      return true;
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposing)
        return;
      this.ClearChanges();
    }

    protected virtual void OnExecuting(OrganizationRequest request)
    {
    }

    protected virtual void OnExecute(OrganizationRequest request, OrganizationResponse response)
    {
    }

    protected virtual void OnExecute(OrganizationRequest request, Exception exception)
    {
    }

    protected virtual void OnSavingChanges(SaveChangesOptions options)
    {
    }

    protected virtual void OnSaveChanges(SaveChangesResultCollection results)
    {
    }

    protected virtual void OnBeginEntityTracking(Entity entity)
    {
    }

    protected virtual void OnEndEntityTracking(Entity entity)
    {
    }

    protected virtual void OnBeginLinkTracking(
      Entity source,
      Relationship relationship,
      Entity target)
    {
    }

    protected virtual void OnEndLinkTracking(
      Entity entity,
      Relationship relationship,
      Entity target)
    {
    }

    private static class Strings
    {
      public const string PropertyDoesNotExist = "The property '{0}' does not exist on the entity '{1}'.";
      public const string NoSettableProperty = "The closed type '{0}' does not have a corresponding '{1}' settable property.";
      public const string RequiresCreatedOrChangedState = "The '{0}' entity must be in the created or changed state.";
      public const string RequiresUnchangedState = "The '{0}' entity must be in the default (null) or unchanged state.";
      public const string RequiresCreatedState = "The '{0}' entity must be in the default (null) or created state.";
      public const string AlreadyTrackingEntity = "The context is already tracking the '{0}' entity.";
      public const string AlreadyTrackingRelationship = "The context is already tracking the '{0}' relationship.";
      public const string EmptyId = "The '{0}' entity has an empty ID.";
      public const string AlreadyTrackingIdentity = "The context is already tracking a different '{0}' entity with the same identity.";
      public const string EntityAlreadyAttached = "The '{0}' entity is already attached to a context.";
      public const string NotSubclass = "The specified type '{0}' must be a subclass of '{1}'.";
      public const string NotKnownEntityType = "The specified type '{0}' is not a known entity type.";
      public const string NotTrackingEntity = "The context is not currently tracking the '{0}' entity.";
      public const string RelationshipEndIsDeleted = "One or both of the ends of the '{0}' relationship is in the deleted state.";
      public const string RelationshipEndIsAdded = "One or both of the ends of the '{0}' relationship is in the added state.";
      public const string CannotLoadAddedEntity = "The context can not load the related collection or reference for entities in the added state.";
      public const string CannotLoadAttachedEntity = "The context can not load the related collection or reference for tracked entities while the 'MergeOption' is set to 'NoTracking'. Change the 'MergeOption' value or detach the '{0}' entity.";
      public const string CannotLoadDetachedEntity = "The context can not load the related collection or reference for untracked entities while the 'MergeOption' is not set to 'NoTracking'. Change the 'MergeOption' to 'NoTracking' or attach the '{0}' entity.";
      public const string SourceEqualsTarget = "The entity cannot link to itself.";
    }

    internal delegate Guid SequentialGuidOverrideDelegate();
  }
}
