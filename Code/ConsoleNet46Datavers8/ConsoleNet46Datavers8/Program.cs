using Data8.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
//using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleNet46Datavers8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Начало.");

            var app = new Program();
            //var connectionString = app.Configuration.GetConnectionString("default");
            //var connectionString = app.Configuration["default"];
            //var serviceClient =
            //    new ServiceClient(connectionString);

            //var serviceClient =
            //    new ServiceClient(


            //var orgService = new OnPremiseClient("http://172.23.57.20/NSC/XRMServices/2011/Organization.svc", "bss\\crm-sysuser", "[2cekthsfhukm]");

            //var orgService = new ServiceClient(

            var context = GetCrmContext();

            var userGuid = new Guid("{1E932C9A-A92F-E511-80E8-0050568732BC}");
            var user = (from u in context.CreateQuery("systemuser")
                        where u.GetAttributeValue<Guid>("systemuserid") == userGuid
                        select u).FirstOrDefault();

            Console.WriteLine(user.Id);


            Console.WriteLine("Конец.");
            Console.ReadLine();
        }

        static internal OrganizationServiceContext GetCrmContext()
        {
            //var orgServiceManagement = GetOrgServiceManagement();
            //var credentials = GetCredentials();

            //var proxy =
            //    new OrganizationServiceProxy(orgServiceManagement, credentials.ClientCredentials);


            //var organizationService = new CrmOrganizationService(proxy);
            //var orgService = new OnPremiseClient("http://172.23.57.20/NSC/XRMServices/2011/Organization.svc", "bss\\crm-sysuser", "[2cekthsfhukm]");
            var orgService = new OnPremiseClient("http://172.23.57.22/NSC/XRMServices/2011/Organization.svc", "bss\\avzharov", "Passw0rd!DEV");
            orgService.EnableProxyTypes();

            //var query = new QueryExpression("systemuser");
            //query.ColumnSet = new ColumnSet("systemuserid");
            //query.Criteria.AddCondition("systemuserid", ConditionOperator.Equal, new Guid("{1E932C9A-A92F-E511-80E8-0050568732BC}"));

            //var res = orgService.RetrieveMultiple(query).Entities.ToList();

            var context = new OrganizationServiceContext(orgService);

            //var context = new CrmServiceContext(orgService);
            return context;
        }
    }
}
