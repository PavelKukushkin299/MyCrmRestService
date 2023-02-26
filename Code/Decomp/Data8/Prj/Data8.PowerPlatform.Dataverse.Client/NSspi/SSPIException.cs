// Decompiled with JetBrains decompiler
// Type: NSspi.SSPIException
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System;
using System.Runtime.Serialization;

namespace NSspi
{
  [Serializable]
  public class SSPIException : Exception
  {
    private SecurityStatus errorCode;
    private string message;

    public SSPIException(string message, SecurityStatus errorCode)
    {
      this.message = message;
      this.errorCode = errorCode;
    }

    protected SSPIException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
      this.message = info.GetString(nameof (message));
      this.errorCode = (SecurityStatus) info.GetUInt32(nameof (errorCode));
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      base.GetObjectData(info, context);
      info.AddValue("message", (object) this.message);
      info.AddValue("errorCode", (object) this.errorCode);
    }

    public SecurityStatus ErrorCode => this.errorCode;

    public override string Message => string.Format("{0}. Error Code = '0x{1:X}' - \"{2}\".", (object) this.message, (object) this.errorCode, (object) EnumMgr.ToText((Enum) this.errorCode));
  }
}
