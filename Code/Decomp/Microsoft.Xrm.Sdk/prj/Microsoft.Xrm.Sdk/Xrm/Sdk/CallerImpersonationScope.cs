// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.CallerImpersonationScope
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.Xrm.Sdk
{
  public sealed class CallerImpersonationScope : IDisposable
  {
    private bool _disposed;
    private OperationContextScope scope;

    public CallerImpersonationScope(IOrganizationService service, Guid callerId)
    {
      MessageHeader header = MessageHeader.CreateHeader("CallerId", "http://schemas.microsoft.com/xrm/2011/Contracts", (object) callerId);
      this.scope = new OperationContextScope((IContextChannel) service);
      OperationContext.Current.OutgoingMessageHeaders.Add(header);
    }

    public void Dispose()
    {
      if (this._disposed)
        return;
      if (OperationContext.Current != null)
      {
        OperationContext.Current.OutgoingMessageHeaders.RemoveAll("CallerId", "http://schemas.microsoft.com/xrm/2011/Contracts");
        if (this.scope != null)
          this.scope.Dispose();
      }
      this._disposed = true;
    }
  }
}
