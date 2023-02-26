using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Discovery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyCrmConnector
{
    public class CrmClient
    {
        public IServiceManagement<TService> CreateManagement<TService>(
            Uri serviceUri,
            bool enableProxyTypes,
            Assembly assembly)
        {
            if (serviceUri != (Uri)null)
            {
                //if (typeof(TService) == typeof(IDiscoveryService))
                //    return new DiscoveryServiceConfiguration(serviceUri) as IServiceManagement<TService>;
                if (typeof(TService) == typeof(IOrganizationService))
                {
                    return new MyCrmConnector.Client.OrganizationServiceConfiguration(serviceUri, enableProxyTypes, assembly) as IServiceManagement<TService>;
                }
            }
            return (IServiceManagement<TService>)null;
        }
    }
}
