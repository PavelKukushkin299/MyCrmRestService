// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.RemoteExecutionContext
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  [KnownType("GetKnownParameterTypes")]
  public sealed class RemoteExecutionContext : 
    IPluginExecutionContext,
    IExecutionContext,
    IExtensibleDataObject
  {
    private int _stage;
    private int _mode;
    private int _depth;
    private int _isolationMode;
    private string _messageName;
    private string _primaryEntityName;
    private string _secondaryEntityName;
    private string _organizationName;
    private bool _isOffline;
    private bool _isOfflinePlayback;
    private bool _isInTransaction;
    private ParameterCollection _inputParameters;
    private ParameterCollection _outputParameters;
    private ParameterCollection _sharedVariables;
    private Guid _userId;
    private Guid _initiatingUserId;
    private Guid _userAzureActiveDirectoryObjectId;
    private Guid _initiatingUserAzureActiveDirectoryObjectId;
    private Guid _businessUnitId;
    private Guid _organizationId;
    private Guid _correlationId;
    private Guid _primaryEntityId;
    private Guid _asyncOperationId;
    private Guid? _requestId;
    private EntityReference _owningExtension;
    private EntityImageCollection _preImages;
    private EntityImageCollection _postImages;
    private DateTime _operationCreatedOnTime;
    private RemoteExecutionContext _parentContext;
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public int Stage
    {
      get => this._stage;
      set => this._stage = value;
    }

    [DataMember]
    public int Mode
    {
      get => this._mode;
      set => this._mode = value;
    }

    [DataMember]
    public string MessageName
    {
      get => this._messageName;
      set => this._messageName = value;
    }

    [DataMember]
    public string PrimaryEntityName
    {
      get => this._primaryEntityName;
      set => this._primaryEntityName = value;
    }

    [DataMember]
    public string SecondaryEntityName
    {
      get => this._secondaryEntityName;
      set => this._secondaryEntityName = value;
    }

    [DataMember]
    public Guid? RequestId
    {
      get => this._requestId;
      set => this._requestId = value;
    }

    [DataMember]
    public ParameterCollection InputParameters
    {
      get
      {
        if (this._inputParameters == null)
          this._inputParameters = new ParameterCollection();
        return this._inputParameters;
      }
    }

    [DataMember]
    public ParameterCollection OutputParameters
    {
      get
      {
        if (this._outputParameters == null)
          this._outputParameters = new ParameterCollection();
        return this._outputParameters;
      }
    }

    [DataMember]
    public ParameterCollection SharedVariables
    {
      get
      {
        if (this._sharedVariables == null)
          this._sharedVariables = new ParameterCollection();
        return this._sharedVariables;
      }
    }

    [DataMember]
    public Guid UserId
    {
      get => this._userId;
      set => this._userId = value;
    }

    [DataMember]
    public Guid InitiatingUserId
    {
      get => this._initiatingUserId;
      set => this._initiatingUserId = value;
    }

    [DataMember]
    public Guid BusinessUnitId
    {
      get => this._businessUnitId;
      set => this._businessUnitId = value;
    }

    [DataMember]
    public Guid OrganizationId
    {
      get => this._organizationId;
      set => this._organizationId = value;
    }

    [DataMember]
    public string OrganizationName
    {
      get => this._organizationName;
      set => this._organizationName = value;
    }

    [DataMember]
    public EntityImageCollection PreEntityImages
    {
      get
      {
        if (this._preImages == null)
          this._preImages = new EntityImageCollection();
        return this._preImages;
      }
    }

    [DataMember]
    public EntityImageCollection PostEntityImages
    {
      get
      {
        if (this._postImages == null)
          this._postImages = new EntityImageCollection();
        return this._postImages;
      }
    }

    [DataMember]
    public Guid CorrelationId
    {
      get => this._correlationId;
      set => this._correlationId = value;
    }

    [DataMember]
    public int Depth
    {
      get => this._depth;
      set => this._depth = value;
    }

    [DataMember]
    public bool IsExecutingOffline
    {
      get => this._isOffline;
      set => this._isOffline = value;
    }

    [DataMember]
    public bool IsOfflinePlayback
    {
      get => this._isOfflinePlayback;
      set => this._isOfflinePlayback = value;
    }

    [DataMember]
    public int IsolationMode
    {
      get => this._isolationMode;
      set => this._isolationMode = value;
    }

    [DataMember]
    public bool IsInTransaction
    {
      get => this._isInTransaction;
      set => this._isInTransaction = value;
    }

    [DataMember]
    public Guid OperationId
    {
      get => this._asyncOperationId;
      set => this._asyncOperationId = value;
    }

    [DataMember]
    public EntityReference OwningExtension
    {
      get => this._owningExtension;
      set => this._owningExtension = value;
    }

    [DataMember]
    public Guid PrimaryEntityId
    {
      get => this._primaryEntityId;
      set => this._primaryEntityId = value;
    }

    [DataMember]
    public DateTime OperationCreatedOn
    {
      get => this._operationCreatedOnTime;
      set => this._operationCreatedOnTime = value;
    }

    [DataMember]
    public RemoteExecutionContext ParentContext
    {
      get => this._parentContext;
      set => this._parentContext = value;
    }

    IPluginExecutionContext IPluginExecutionContext.ParentContext => (IPluginExecutionContext) this.ParentContext;

    [DataMember(IsRequired = false)]
    public Guid UserAzureActiveDirectoryObjectId
    {
      get => this._userAzureActiveDirectoryObjectId;
      set => this._userAzureActiveDirectoryObjectId = value;
    }

    [DataMember(IsRequired = false)]
    public Guid InitiatingUserAzureActiveDirectoryObjectId
    {
      get => this._initiatingUserAzureActiveDirectoryObjectId;
      set => this._initiatingUserAzureActiveDirectoryObjectId = value;
    }

    private static IEnumerable<Type> GetKnownParameterTypes() => KnownTypesProvider.RetrieveKnownValueTypes();

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
