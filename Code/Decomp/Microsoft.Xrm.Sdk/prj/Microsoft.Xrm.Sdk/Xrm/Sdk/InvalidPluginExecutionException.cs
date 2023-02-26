// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.InvalidPluginExecutionException
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;
using System.Security;

namespace Microsoft.Xrm.Sdk
{
  [Serializable]
  public sealed class InvalidPluginExecutionException : Exception, ISerializable
  {
    private OperationStatus _status;

    public InvalidPluginExecutionException() => this._status = OperationStatus.Failed;

    public InvalidPluginExecutionException(OperationStatus status)
      : this(status, string.Empty)
    {
    }

    public InvalidPluginExecutionException(string message)
      : base(message)
    {
      this._status = OperationStatus.Failed;
    }

    public InvalidPluginExecutionException(OperationStatus status, string message)
      : this(status, 0, message)
    {
    }

    public InvalidPluginExecutionException(string message, Exception exception)
      : base(message, exception)
    {
      this._status = OperationStatus.Failed;
    }

    public InvalidPluginExecutionException(OperationStatus status, int errorCode, string message)
      : this(message)
    {
      this._status = status;
      if (errorCode == 0)
        return;
      this.HResult = errorCode;
    }

    private InvalidPluginExecutionException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
      this._status = (OperationStatus) info.GetValue(nameof (Status), typeof (OperationStatus));
    }

    public OperationStatus Status => this._status;

    public int ErrorCode => this.HResult;

    [SecurityCritical]
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      if (info == null)
        throw new ArgumentNullException(nameof (info));
      info.AddValue("Status", (object) this._status, typeof (OperationStatus));
      base.GetObjectData(info, context);
    }
  }
}
