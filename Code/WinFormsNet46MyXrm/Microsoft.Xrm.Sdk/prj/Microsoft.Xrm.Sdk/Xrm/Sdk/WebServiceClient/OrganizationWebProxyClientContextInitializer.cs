// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.WebServiceClient.OrganizationWebProxyClientContextInitializer
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.Xrm.Sdk.WebServiceClient
{
  internal sealed class OrganizationWebProxyClientContextInitializer : 
    WebProxyClientContextInitializer<IOrganizationService>
  {
    public OrganizationWebProxyClientContextInitializer(OrganizationWebProxyClient proxy)
      : base((WebProxyClient<IOrganizationService>) proxy)
    {
      this.Initialize();
    }

    private OrganizationWebProxyClient OrganizationWebProxyClient => this.ServiceProxy as OrganizationWebProxyClient;

    private void Initialize()
    {
      if (this.ServiceProxy == null)
        return;
      this.AddTokenToHeaders();
      if (this.ServiceProxy == null)
        return;
      if (this.OrganizationWebProxyClient.OfflinePlayback)
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("IsOfflinePlayback", "http://schemas.microsoft.com/xrm/2011/Contracts", (object) true));
      if (this.OrganizationWebProxyClient.CallerId != Guid.Empty)
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("CallerId", "http://schemas.microsoft.com/xrm/2011/Contracts", (object) this.OrganizationWebProxyClient.CallerId));
      if (this.OrganizationWebProxyClient.CallerRegardingObjectId != Guid.Empty)
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("CallerRegardingObjectId", "http://schemas.microsoft.com/xrm/2011/Contracts", (object) this.OrganizationWebProxyClient.CallerRegardingObjectId));
      if (this.OrganizationWebProxyClient.LanguageCodeOverride != 0)
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("LanguageCodeOverride", "http://schemas.microsoft.com/xrm/2011/Contracts", (object) this.OrganizationWebProxyClient.LanguageCodeOverride));
      if (this.OrganizationWebProxyClient.SyncOperationType != null)
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("OutlookSyncOperationType", "http://schemas.microsoft.com/xrm/2011/Contracts", (object) this.OrganizationWebProxyClient.SyncOperationType));
      OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("UserType", "http://schemas.microsoft.com/xrm/2011/Contracts", (object) this.OrganizationWebProxyClient.userType));
      this.AddCommonHeaders();
    }
  }
}
