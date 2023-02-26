// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.BaseServiceFault
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "BaseServiceFault", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  [KnownType(typeof (DiscoveryServiceFault))]
  [KnownType(typeof (OrganizationServiceFault))]
  [KnownType(typeof (ExecuteTransactionFault))]
  [Serializable]
  public abstract class BaseServiceFault : IExtensibleDataObject
  {
    private DateTime _timestamp;
    private string _message;
    private int _errorCode;
    private string _helpLink;
    private ErrorDetailCollection _details;
    private BaseServiceFault _innerServiceFault;
    private Guid _activityId;
    [NonSerialized]
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public string Message
    {
      get => this._message;
      set => this._message = value;
    }

    [DataMember]
    public int ErrorCode
    {
      get => this._errorCode;
      set => this._errorCode = value;
    }

    [DataMember]
    public string HelpLink
    {
      get => this._helpLink;
      set => this._helpLink = value;
    }

    [DataMember]
    public DateTime Timestamp
    {
      get => this._timestamp;
      set => this._timestamp = value;
    }

    [DataMember]
    public Guid ActivityId
    {
      get => this._activityId;
      set => this._activityId = value;
    }

    [DataMember]
    public ErrorDetailCollection ErrorDetails
    {
      get
      {
        if (this._details == null)
          this._details = new ErrorDetailCollection();
        return this._details;
      }
      set => this._details = value;
    }

    internal virtual BaseServiceFault InnerServiceFault
    {
      get => this._innerServiceFault;
      set => this._innerServiceFault = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
