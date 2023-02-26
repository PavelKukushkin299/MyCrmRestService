// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Entity
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "Entity", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public class Entity : IExtensibleDataObject
  {
    private string _logicalName;
    private Guid _id;
    private AttributeCollection _attributes;
    private Microsoft.Xrm.Sdk.EntityState? _entityState;
    private FormattedValueCollection _formattedValues;
    private RelatedEntityCollection _relatedEntities;
    internal bool _isReadOnly;
    private string _rowVersion;
    private KeyAttributeCollection _keyAttributes;
    private ExtensionDataObject _extensionDataObject;

    public Entity()
      : this((string) null)
    {
      this.HasLazyFileAttribute = false;
    }

    public Entity(string entityName)
    {
      this._logicalName = entityName;
      this.HasLazyFileAttribute = false;
    }

    public Entity(string entityName, Guid id)
    {
      this._logicalName = entityName;
      this._id = id;
      this.HasLazyFileAttribute = false;
    }

    public Entity(string entityName, string keyName, object keyValue)
    {
      this._logicalName = entityName;
      this.KeyAttributes.Add(keyName, keyValue);
      this.HasLazyFileAttribute = false;
    }

    public Entity(string entityName, KeyAttributeCollection keyAttributes)
    {
      this._logicalName = entityName;
      this._keyAttributes = keyAttributes;
      this.HasLazyFileAttribute = false;
    }

    [DataMember]
    public string LogicalName
    {
      get => this._logicalName;
      set
      {
        this.CheckIsReadOnly(nameof (LogicalName));
        this._logicalName = value;
      }
    }

    [DataMember]
    public virtual Guid Id
    {
      get => this._id;
      set
      {
        if (this._id != Guid.Empty)
          this.CheckIsReadOnly(nameof (Id));
        this._id = value;
      }
    }

    [DataMember]
    public AttributeCollection Attributes
    {
      get
      {
        if (this._attributes == null)
          this._attributes = new AttributeCollection();
        return this._attributes;
      }
      set => this._attributes = value;
    }

    [DataMember]
    public Microsoft.Xrm.Sdk.EntityState? EntityState
    {
      get => this._entityState;
      set
      {
        this.CheckIsReadOnly(nameof (EntityState));
        this._entityState = value;
      }
    }

    [DataMember]
    public FormattedValueCollection FormattedValues
    {
      get
      {
        if (this._formattedValues == null)
          this._formattedValues = new FormattedValueCollection();
        return this._formattedValues;
      }
      internal set => this._formattedValues = value;
    }

    [DataMember]
    public RelatedEntityCollection RelatedEntities
    {
      get
      {
        if (this._relatedEntities == null)
        {
          this._relatedEntities = new RelatedEntityCollection();
          this._relatedEntities.IsReadOnly = this.IsReadOnly;
        }
        return this._relatedEntities;
      }
      internal set
      {
        this.CheckIsReadOnly(nameof (RelatedEntities));
        this._relatedEntities = value;
      }
    }

    [DataMember]
    public string RowVersion
    {
      get => this._rowVersion;
      set => this._rowVersion = value;
    }

    [DataMember]
    public KeyAttributeCollection KeyAttributes
    {
      get
      {
        if (this._keyAttributes == null)
          this._keyAttributes = new KeyAttributeCollection();
        return this._keyAttributes;
      }
      set => this._keyAttributes = value;
    }

    public bool HasLazyFileAttribute { get; set; }

    public string LazyFileAttributeKey { get; set; }

    public Lazy<object> LazyFileAttributeValue { get; set; }

    public string LazyFileSizeAttributeKey { get; set; }

    public int LazyFileSizeAttributeValue { get; set; }

    public object this[string attributeName]
    {
      get => this.Attributes[attributeName];
      set => this.Attributes[attributeName] = value;
    }

    public bool Contains(string attributeName) => this.Attributes.Contains(attributeName);

    public T ToEntity<T>() where T : Entity
    {
      if (typeof (T) == typeof (Entity))
      {
        Entity target = new Entity();
        this.ShallowCopyTo(target);
        return target as T;
      }
      if (string.IsNullOrWhiteSpace(this._logicalName))
        throw new NotSupportedException("LogicalName must be set before calling ToEntity()");
      string str = (string) null;
      object[] customAttributes = typeof (T).GetCustomAttributes(typeof (EntityLogicalNameAttribute), true);
      if (customAttributes != null)
      {
        object[] objArray = customAttributes;
        int index = 0;
        if (index < objArray.Length)
          str = ((EntityLogicalNameAttribute) objArray[index]).LogicalName;
      }
      if (string.IsNullOrWhiteSpace(str))
        throw new NotSupportedException("Cannot convert to type that is does not have EntityLogicalNameAttribute");
      if (this._logicalName != str)
        throw new NotSupportedException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Cannot convert entity {0} to {1}", (object) this._logicalName, (object) str));
      T instance = (T) Activator.CreateInstance(typeof (T));
      this.ShallowCopyTo((Entity) instance);
      return instance;
    }

    public EntityReference ToEntityReference() => new EntityReference(this.LogicalName, this.Id)
    {
      RowVersion = this.RowVersion
    };

    internal void ShallowCopyTo(Entity target)
    {
      if (target == null || target == this)
        return;
      target.Id = this.Id;
      target.SetLogicalNameInternal(this.LogicalName);
      target.SetEntityStateInternal(this.EntityState);
      target.SetRelatedEntitiesInternal(this.RelatedEntities);
      target.Attributes = this.Attributes;
      target.FormattedValues = this.FormattedValues;
      target.ExtensionData = this.ExtensionData;
      target.RowVersion = this.RowVersion;
      target.KeyAttributes = this.KeyAttributes;
    }

    public virtual T GetAttributeValue<T>(string attributeLogicalName)
    {
      object attributeValue = this.GetAttributeValue(attributeLogicalName);
      return attributeValue == null ? default (T) : (T) attributeValue;
    }

    private object GetAttributeValue(string attributeLogicalName)
    {
      if (string.IsNullOrWhiteSpace(attributeLogicalName))
        throw new ArgumentNullException(nameof (attributeLogicalName));
      return !this.Contains(attributeLogicalName) ? (object) null : this[attributeLogicalName];
    }

    public bool TryGetAttributeValue<T>(string attributeKey, out T result)
    {
      try
      {
        object attributeValue = this.GetAttributeValue(attributeKey);
        if (attributeValue == null)
        {
          result = default (T);
          return false;
        }
        if (attributeValue is T obj)
        {
          result = obj;
          return true;
        }
        TypeConverter converter = TypeDescriptor.GetConverter(typeof (T));
        result = (T) converter.ConvertFrom(attributeValue);
        return true;
      }
      catch
      {
      }
      result = default (T);
      return false;
    }

    protected virtual void SetAttributeValue(string attributeLogicalName, object value)
    {
      if (string.IsNullOrWhiteSpace(attributeLogicalName))
        throw new ArgumentNullException(nameof (attributeLogicalName));
      this[attributeLogicalName] = value;
    }

    protected virtual string GetFormattedAttributeValue(string attributeLogicalName)
    {
      if (string.IsNullOrWhiteSpace(attributeLogicalName))
        throw new ArgumentNullException(nameof (attributeLogicalName));
      return !this.FormattedValues.Contains(attributeLogicalName) ? (string) null : this.FormattedValues[attributeLogicalName];
    }

    protected virtual TEntity GetRelatedEntity<TEntity>(
      string relationshipSchemaName,
      EntityRole? primaryEntityRole)
      where TEntity : Entity
    {
      Relationship key = !string.IsNullOrWhiteSpace(relationshipSchemaName) ? new Relationship(relationshipSchemaName)
      {
        PrimaryEntityRole = primaryEntityRole
      } : throw new ArgumentNullException(nameof (relationshipSchemaName));
      return !this.RelatedEntities.Contains(key) ? default (TEntity) : (TEntity) this.RelatedEntities[key].Entities.FirstOrDefault<Entity>();
    }

    protected virtual void SetRelatedEntity<TEntity>(
      string relationshipSchemaName,
      EntityRole? primaryEntityRole,
      TEntity entity)
      where TEntity : Entity
    {
      if (string.IsNullOrWhiteSpace(relationshipSchemaName))
        throw new ArgumentNullException(nameof (relationshipSchemaName));
      if ((object) entity != null && string.IsNullOrWhiteSpace(entity.LogicalName))
        throw new ArgumentException("The entity is missing a value for the 'LogicalName' property.", nameof (entity));
      Relationship key = new Relationship(relationshipSchemaName)
      {
        PrimaryEntityRole = primaryEntityRole
      };
      EntityCollection entityCollection1;
      if ((object) entity == null)
      {
        entityCollection1 = (EntityCollection) null;
      }
      else
      {
        entityCollection1 = new EntityCollection((IList<Entity>) new TEntity[1]
        {
          entity
        });
        entityCollection1.EntityName = entity.LogicalName;
      }
      EntityCollection entityCollection2 = entityCollection1;
      if (entityCollection2 != null)
        this.RelatedEntities[key] = entityCollection2;
      else
        this.RelatedEntities.Remove(key);
    }

    protected virtual IEnumerable<TEntity> GetRelatedEntities<TEntity>(
      string relationshipSchemaName,
      EntityRole? primaryEntityRole)
      where TEntity : Entity
    {
      Relationship key = !string.IsNullOrWhiteSpace(relationshipSchemaName) ? new Relationship(relationshipSchemaName)
      {
        PrimaryEntityRole = primaryEntityRole
      } : throw new ArgumentNullException(nameof (relationshipSchemaName));
      return !this.RelatedEntities.Contains(key) ? (IEnumerable<TEntity>) null : this.RelatedEntities[key].Entities.Cast<TEntity>();
    }

    protected virtual void SetRelatedEntities<TEntity>(
      string relationshipSchemaName,
      EntityRole? primaryEntityRole,
      IEnumerable<TEntity> entities)
      where TEntity : Entity
    {
      if (string.IsNullOrWhiteSpace(relationshipSchemaName))
        throw new ArgumentNullException(nameof (relationshipSchemaName));
      if (entities != null && entities.Any<TEntity>((Func<TEntity, bool>) (entity => string.IsNullOrWhiteSpace(entity.LogicalName))))
        throw new ArgumentException("An entity is missing a value for the 'LogicalName' property.", nameof (entities));
      Relationship key = new Relationship(relationshipSchemaName)
      {
        PrimaryEntityRole = primaryEntityRole
      };
      EntityCollection entityCollection1;
      if (entities == null)
      {
        entityCollection1 = (EntityCollection) null;
      }
      else
      {
        entityCollection1 = new EntityCollection((IList<Entity>) new List<Entity>((IEnumerable<Entity>) entities));
        entityCollection1.EntityName = entities.First<TEntity>().LogicalName;
      }
      EntityCollection entityCollection2 = entityCollection1;
      if (entityCollection2 != null)
        this.RelatedEntities[key] = entityCollection2;
      else
        this.RelatedEntities.Remove(key);
    }

    internal bool IsReadOnly
    {
      get => this._isReadOnly;
      set
      {
        this._isReadOnly = value;
        this.RelatedEntities.IsReadOnly = value;
      }
    }

    internal void SetLogicalNameInternal(string logicalName) => this._logicalName = logicalName;

    internal void SetEntityStateInternal(Microsoft.Xrm.Sdk.EntityState? entityState) => this._entityState = entityState;

    internal void SetRelatedEntitiesInternal(RelatedEntityCollection relatedEntities) => this._relatedEntities = relatedEntities;

    private void CheckIsReadOnly(string propertyName)
    {
      if (this.IsReadOnly)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The entity is read-only and the '{0}' property cannot be modified. Use the context to update the entity instead.", (object) propertyName));
    }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
