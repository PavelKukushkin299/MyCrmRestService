using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Linq;

namespace ConsoleNet22Xrm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var crmManager = new CrmManager();
            var context = crmManager.GetCrmContext();

            var userGuid = new Guid("{1E932C9A-A92F-E511-80E8-0050568732BC}");
            var user = (from u in context.CreateQuery("systemuser")
                        where u.GetAttributeValue<Guid>("systemuserid") == userGuid
                        select u).FirstOrDefault();

            Console.WriteLine(user.Id);

            Console.ReadLine();
        }
    }

    public class CrmManager
    {
        internal OrganizationServiceContext GetCrmContext()
        {
            var orgServiceManagement = GetOrgServiceManagement();
            var credentials = GetCredentials();

            var proxy =
                new OrganizationServiceProxy(orgServiceManagement, credentials.ClientCredentials);
            //var organizationService = new CrmOrganizationService(proxy);
            var context = new OrganizationServiceContext(proxy);
            return context;
        }

        private IServiceManagement<IOrganizationService> GetOrgServiceManagement()
        {
            var serviceUri =
                new Uri("http://172.23.57.20/NSC/XRMServices/2011/Organization.svc");
            return
                ServiceConfigurationFactory.CreateManagement<IOrganizationService>(serviceUri);
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
