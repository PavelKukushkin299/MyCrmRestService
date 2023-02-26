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
                if (typeof(TService) == typeof(IDiscoveryService))
                {
                    return new MyCrmConnector.Client.DiscoveryServiceConfiguration(serviceUri) as IServiceManagement<TService>;
                }
                if (typeof(TService) == typeof(IOrganizationService))
                {
                    return new MyCrmConnector.Client.OrganizationServiceConfiguration(serviceUri, enableProxyTypes, assembly) as IServiceManagement<TService>;
                }
            }
            return (IServiceManagement<TService>)null;
        }

        public IOrganizationService GetOrganizationService()
        {
            var serviceUri =
                new Uri("http://172.23.57.20/NSC/XRMServices/2011/Organization.svc");
            var orgServiceManagement = this.CreateManagement<IOrganizationService>(serviceUri, false, null);
            var credentials = GetCredentials();

            var proxy =
                new MyCrmConnector.Client.OrganizationServiceProxy(orgServiceManagement, credentials.ClientCredentials);

            return proxy;

        }

        private AuthenticationCredentials GetCredentials()
        {
            var userName = "crm-sysuser";
            var password = "[2cekthsfhukm]";
            var domain = "bss";
            var authCredentials = new AuthenticationCredentials();
            authCredentials.ClientCredentials.Windows.ClientCredential =
                new System.Net.NetworkCredential(userName, password, domain);
            return authCredentials;
        }
    }
}
