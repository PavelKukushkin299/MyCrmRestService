// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.ChannelFaultedEventArgs
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;

namespace Microsoft.Xrm.Sdk.Client
{
  public sealed class ChannelFaultedEventArgs : CancelEventArgs
  {
    public ChannelFaultedEventArgs(Exception exception)
      : this(string.Empty, exception)
    {
    }

    public ChannelFaultedEventArgs(string message, Exception exception)
    {
      this.Exception = exception;
      this.Message = message;
    }

    public Exception Exception { get; private set; }

    public string Message { get; private set; }
  }
}
