// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.SdkExceptionBase
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [Serializable]
  public abstract class SdkExceptionBase : Exception
  {
    private const int UnexpectedErrorFaultCode = -2147220970;

    protected SdkExceptionBase(string message)
      : this(message, (Exception) null)
    {
    }

    protected SdkExceptionBase(Exception innerException)
      : this((string) null, innerException)
    {
    }

    protected SdkExceptionBase(string message, Exception innerException)
      : base(message, innerException)
    {
      this.HResult = -2147220970;
    }

    protected SdkExceptionBase(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}
