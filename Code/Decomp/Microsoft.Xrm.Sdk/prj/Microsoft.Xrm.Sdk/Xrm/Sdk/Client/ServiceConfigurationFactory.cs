// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.ServiceConfigurationFactory
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Discovery;
using System;
using System.Reflection;

namespace Microsoft.Xrm.Sdk.Client
{
  public static class ServiceConfigurationFactory
  {
    public static IServiceConfiguration<TService> CreateConfiguration<TService>(
      Uri serviceUri)
    {
      return ServiceConfigurationFactory.CreateConfiguration<TService>(serviceUri, false, (Assembly) null);
    }

    public static IServiceConfiguration<TService> CreateConfiguration<TService>(
      Uri serviceUri,
      bool enableProxyTypes,
      Assembly assembly)
    {
      if (serviceUri != (Uri) null)
      {
        if (typeof (TService) == typeof (IDiscoveryService))
          return new DiscoveryServiceConfiguration(serviceUri) as IServiceConfiguration<TService>;
        if (typeof (TService) == typeof (IOrganizationService))
          return new OrganizationServiceConfiguration(serviceUri, enableProxyTypes, assembly) as IServiceConfiguration<TService>;
      }
      return (IServiceConfiguration<TService>) null;
    }

    public static IServiceManagement<TService> CreateManagement<TService>(
      Uri serviceUri)
    {
      return ServiceConfigurationFactory.CreateManagement<TService>(serviceUri, false, (Assembly) null);
    }

    public static IServiceManagement<TService> CreateManagement<TService>(
      Uri serviceUri,
      bool enableProxyTypes,
      Assembly assembly)
    {
      if (serviceUri != (Uri) null)
      {
        if (typeof (TService) == typeof (IDiscoveryService))
          return new DiscoveryServiceConfiguration(serviceUri) as IServiceManagement<TService>;
        if (typeof (TService) == typeof (IOrganizationService))
          return new OrganizationServiceConfiguration(serviceUri, enableProxyTypes, assembly) as IServiceManagement<TService>;
      }
      return (IServiceManagement<TService>) null;
    }
  }
}
