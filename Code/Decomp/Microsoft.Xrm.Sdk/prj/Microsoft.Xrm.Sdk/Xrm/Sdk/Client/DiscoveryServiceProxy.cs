// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.DiscoveryServiceProxy
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Discovery;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;

namespace Microsoft.Xrm.Sdk.Client
{
  public class DiscoveryServiceProxy : ServiceProxy<IDiscoveryService>, IDiscoveryService
  {
    internal DiscoveryServiceProxy()
    {
    }

    public DiscoveryServiceProxy(
      Uri uri,
      Uri homeRealmUri,
      ClientCredentials clientCredentials,
      ClientCredentials deviceCredentials)
      : base(uri, homeRealmUri, clientCredentials, deviceCredentials)
    {
    }

    public DiscoveryServiceProxy(
      IServiceConfiguration<IDiscoveryService> serviceConfiguration,
      SecurityTokenResponse securityTokenResponse)
      : base(serviceConfiguration, securityTokenResponse)
    {
    }

    public DiscoveryServiceProxy(
      IServiceConfiguration<IDiscoveryService> serviceConfiguration,
      ClientCredentials clientCredentials)
      : base(serviceConfiguration, clientCredentials)
    {
    }

    public DiscoveryServiceProxy(
      IServiceManagement<IDiscoveryService> serviceManagement,
      SecurityTokenResponse securityTokenResponse)
      : this(serviceManagement as IServiceConfiguration<IDiscoveryService>, securityTokenResponse)
    {
    }

    public DiscoveryServiceProxy(
      IServiceManagement<IDiscoveryService> serviceManagement,
      ClientCredentials clientCredentials)
      : this(serviceManagement as IServiceConfiguration<IDiscoveryService>, clientCredentials)
    {
    }

    public DiscoveryResponse Execute(DiscoveryRequest request)
    {
      bool? retry = new bool?();
      do
      {
        bool forceClose = false;
        try
        {
          using (new DiscoveryServiceContextInitializer(this))
            return this.ServiceChannel.Channel.Execute(request);
        }
        catch (MessageSecurityException ex)
        {
          forceClose = true;
          retry = this.ShouldRetry(ex, retry);
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (EndpointNotFoundException ex)
        {
          forceClose = true;
          retry = new bool?(this.HandleFailover(retry));
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (TimeoutException ex)
        {
          forceClose = true;
          retry = new bool?(this.HandleFailover(retry));
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch (FaultException<DiscoveryServiceFault> ex)
        {
          forceClose = true;
          retry = this.HandleFailover((BaseServiceFault) ex.Detail, retry);
          if (!retry.GetValueOrDefault())
            throw;
        }
        catch
        {
          forceClose = true;
          throw;
        }
        finally
        {
          this.CloseChannel(forceClose);
        }
      }
      while (retry.HasValue && retry.Value);
      return (DiscoveryResponse) null;
    }
  }
}
