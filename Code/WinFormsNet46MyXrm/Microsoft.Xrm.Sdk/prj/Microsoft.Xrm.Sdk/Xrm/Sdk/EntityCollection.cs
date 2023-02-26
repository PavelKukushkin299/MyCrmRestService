// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.EntityCollection
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "EntityCollection", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class EntityCollection : IExtensibleDataObject
  {
    private string _entityName;
    private DataCollection<Entity> _entities;
    private bool _moreRecords;
    private string _pagingCookie;
    private string _minActiveRowVersion;
    private int _totalRecordCount;
    private bool _totalRecordCountLimitExceeded;
    private bool _isReadOnly;
    private ExtensionDataObject _extensionDataObject;

    public EntityCollection()
    {
    }

    public EntityCollection(IList<Entity> list) => this._entities = new DataCollection<Entity>(list);

    [DataMember]
    public DataCollection<Entity> Entities
    {
      get
      {
        if (this._entities == null)
          this._entities = new DataCollection<Entity>();
        return this._entities;
      }
      private set => this._entities = value;
    }

    [DataMember]
    public bool MoreRecords
    {
      get => this._moreRecords;
      set
      {
        this.CheckIsReadOnly();
        this._moreRecords = value;
      }
    }

    [DataMember]
    public string PagingCookie
    {
      get => this._pagingCookie;
      set
      {
        this.CheckIsReadOnly();
        this._pagingCookie = value;
      }
    }

    [DataMember]
    public string MinActiveRowVersion
    {
      get => this._minActiveRowVersion;
      set
      {
        this.CheckIsReadOnly();
        this._minActiveRowVersion = value;
      }
    }

    [DataMember]
    public int TotalRecordCount
    {
      get => this._totalRecordCount;
      set
      {
        this.CheckIsReadOnly();
        this._totalRecordCount = value;
      }
    }

    [DataMember]
    public bool TotalRecordCountLimitExceeded
    {
      get => this._totalRecordCountLimitExceeded;
      set
      {
        this.CheckIsReadOnly();
        this._totalRecordCountLimitExceeded = value;
      }
    }

    public Entity this[int index]
    {
      get => this.Entities[index];
      set
      {
        this.CheckIsReadOnly();
        this.Entities[index] = value;
      }
    }

    [DataMember]
    public string EntityName
    {
      get => this._entityName;
      set
      {
        this.CheckIsReadOnly();
        this._entityName = value;
      }
    }

    internal bool IsReadOnly
    {
      get => this._isReadOnly;
      set => this._isReadOnly = value;
    }

    private void CheckIsReadOnly()
    {
      if (this.IsReadOnly)
        throw new InvalidOperationException("The collection is read-only.");
    }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
