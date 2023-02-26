// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.QuickFindResult
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "QuickFindResult", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class QuickFindResult : IExtensibleDataObject
  {
    private int errorCode;
    private EntityCollection data;
    private DataCollection<string> queryColumnSet;
    private ExtensionDataObject _extensionDataObject;

    public QuickFindResult()
    {
    }

    public QuickFindResult(int error, EntityCollection entities)
    {
      this.errorCode = error;
      this.data = entities;
      this.queryColumnSet = (DataCollection<string>) null;
    }

    public QuickFindResult(
      int error,
      EntityCollection entities,
      DataCollection<string> queryColumns)
    {
      this.errorCode = error;
      this.data = entities;
      this.queryColumnSet = queryColumns;
    }

    [DataMember]
    public int ErrorCode
    {
      get => this.errorCode;
      set => this.errorCode = value;
    }

    [DataMember]
    public EntityCollection Data
    {
      get => this.data;
      set => this.data = value;
    }

    [DataMember]
    public DataCollection<string> QueryColumnSet
    {
      get => this.queryColumnSet;
      set => this.queryColumnSet = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
