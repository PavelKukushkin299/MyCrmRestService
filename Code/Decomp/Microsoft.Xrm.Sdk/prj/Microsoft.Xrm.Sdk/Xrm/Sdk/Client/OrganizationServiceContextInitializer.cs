// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.OrganizationServiceContextInitializer
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.Xrm.Sdk.Client
{
  internal sealed class OrganizationServiceContextInitializer : 
    ServiceContextInitializer<IOrganizationService>
  {
    public OrganizationServiceContextInitializer(OrganizationServiceProxy proxy)
      : base((ServiceProxy<IOrganizationService>) proxy)
    {
      this.Initialize();
    }

    private OrganizationServiceProxy OrganizationServiceProxy => this.ServiceProxy as OrganizationServiceProxy;

    private void Initialize()
    {
      if (this.OrganizationServiceProxy == null)
        return;
      if (this.OrganizationServiceProxy.OfflinePlayback)
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("IsOfflinePlayback", "http://schemas.microsoft.com/xrm/2011/Contracts", (object) true));
      if (this.OrganizationServiceProxy.CallerId != Guid.Empty)
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("CallerId", "http://schemas.microsoft.com/xrm/2011/Contracts", (object) this.OrganizationServiceProxy.CallerId));
      if (this.OrganizationServiceProxy.CallerRegardingObjectId != Guid.Empty)
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("CallerRegardingObjectId", "http://schemas.microsoft.com/xrm/2011/Contracts", (object) this.OrganizationServiceProxy.CallerRegardingObjectId));
      if (this.OrganizationServiceProxy.LanguageCodeOverride != 0)
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("LanguageCodeOverride", "http://schemas.microsoft.com/xrm/2011/Contracts", (object) this.OrganizationServiceProxy.LanguageCodeOverride));
      if (this.OrganizationServiceProxy.SyncOperationType != null)
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("OutlookSyncOperationType", "http://schemas.microsoft.com/xrm/2011/Contracts", (object) this.OrganizationServiceProxy.SyncOperationType));
      if (!string.IsNullOrEmpty(this.OrganizationServiceProxy.ClientAppName))
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("ClientAppName", "http://schemas.microsoft.com/xrm/2011/Contracts", (object) this.OrganizationServiceProxy.ClientAppName));
      if (!string.IsNullOrEmpty(this.OrganizationServiceProxy.ClientAppVersion))
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("ClientAppVersion", "http://schemas.microsoft.com/xrm/2011/Contracts", (object) this.OrganizationServiceProxy.ClientAppVersion));
      if (!string.IsNullOrEmpty(this.OrganizationServiceProxy.SdkClientVersion))
      {
        OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("SdkClientVersion", "http://schemas.microsoft.com/xrm/2011/Contracts", (object) this.OrganizationServiceProxy.SdkClientVersion));
      }
      else
      {
        string assemblyFileVersion = OrganizationServiceProxy.GetXrmSdkAssemblyFileVersion();
        if (!string.IsNullOrEmpty(assemblyFileVersion))
          OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("SdkClientVersion", "http://schemas.microsoft.com/xrm/2011/Contracts", (object) assemblyFileVersion));
      }
      OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("UserType", "http://schemas.microsoft.com/xrm/2011/Contracts", (object) this.OrganizationServiceProxy.UserType));
    }
  }
}
