using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleNet46Xrm
{
    class Program
    {
        static void Main(string[] args)
        {
            #region
            //var connectionString = "http://172.23.57.20/NSC/XRMServices/2011/Organization.svc";
            //var connectionString = "Url=https://myorgname.crm.dynamics.com; Username=me@mydomain.com; Password=mypassword; AuthType=Office365";
            //var connectionString = "Url=http://172.23.57.20/NSC/XRMServices/2011/Organization.svc; Username=crm-sysuser@bss; Password=[2cekthsfhukm]; AuthType=Office365";
            //var client = new CrmServiceClient(connectionString);
            #endregion

            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Начало.");

            var crmManager = new CrmToolingManager(); ;// CrmSdkManager();//
            var context = crmManager.GetCrmContext();

            var userGuid = new Guid("{1E932C9A-A92F-E511-80E8-0050568732BC}");
            var user = (from u in context.CreateQuery("systemuser")
                        where u.GetAttributeValue<Guid>("systemuserid") == userGuid
                        select u).FirstOrDefault();
            Console.WriteLine(user.Id);

            Console.WriteLine("Конец.");
            Console.ReadLine();
        }
    }

    public class CrmToolingManager
    {
        internal OrganizationServiceContext GetCrmContext()
        {
            var credentials = GetCredentials();
            var orgService = new CrmServiceClient(credentials.ClientCredentials.Windows.ClientCredential, "172.23.57.20", "80", "NSC", true);
            var context = new OrganizationServiceContext(orgService);
            return context;
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

    public class CrmSdkManager
    {
        internal OrganizationServiceContext GetCrmContext()
        {
            var orgServiceManagement = GetOrgServiceManagement();
            var credentials = GetCredentials();

            var proxy =
                new OrganizationServiceProxy(orgServiceManagement, credentials.ClientCredentials);
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
