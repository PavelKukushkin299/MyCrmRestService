using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsNet46Xrm
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            Console.OutputEncoding = Encoding.UTF8;
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            
            //Console.WriteLine("Начало.");

            //var crmManager = new CrmToolingManager(); 
            //var context = crmManager.GetCrmContext();

            //var userGuid = new Guid("{1E932C9A-A92F-E511-80E8-0050568732BC}");
            //var user = (from u in context.CreateQuery("systemuser")
            //            where u.GetAttributeValue<Guid>("systemuserid") == userGuid
            //            select u).FirstOrDefault();
            //Console.WriteLine(user.Id);

            //Console.WriteLine("Конец.");
        }

        private void btnGo2_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("Начало2.");

            //var crmManager = new CrmToolingManager(); 
            //var context = crmManager.GetCrmContext();

            //var userGuid = new Guid("{1E932C9A-A92F-E511-80E8-0050568732BB}");
            //var user = (from u in context.CreateQuery("systemuser")
            //            where u.GetAttributeValue<Guid>("systemuserid") == userGuid
            //            select u).FirstOrDefault();
            //Console.WriteLine(user?.Id);

            //Console.WriteLine("Конец2.");
        }

        private void btnGo3_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Начало3.");

            var crmManager = new CrmSdkManager();
            var context = crmManager.GetCrmContext();

            var userGuid = new Guid("{1E932C9A-A92F-E511-80E8-0050568732BC}");
            var user = (from u in context.CreateQuery("systemuser")
                        where u.GetAttributeValue<Guid>("systemuserid") == userGuid
                        select u).FirstOrDefault();
            Console.WriteLine(user?.Id);

            Console.WriteLine("Конец3.");
        }

        private void btnGo4_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Начало4.");

            var crmManager = new CrmSdkManager();
            var orgService = crmManager.GetOrganizationService();

            var query = new QueryExpression("systemuser");
            query.ColumnSet = new ColumnSet("systemuserid");
            query.Criteria.AddCondition("systemuserid", ConditionOperator.Equal, new Guid("{1E932C9A-A92F-E511-80E8-0050568732BC}"));

            var res = orgService.RetrieveMultiple(query).Entities.FirstOrDefault();

            Console.WriteLine(res?.Id);

            Console.WriteLine("Конец4.");
        }
    }

    //public class CrmToolingManager
    //{
    //    internal OrganizationServiceContext GetCrmContext()
    //    {
    //        var credentials = GetCredentials();
    //        var orgService = new CrmServiceClient(credentials.ClientCredentials.Windows.ClientCredential, "172.23.57.20", "80", "NSC", false);
    //        var context = new OrganizationServiceContext(orgService);
    //        return context;
    //    }

    //    private AuthenticationCredentials GetCredentials()
    //    {
    //        var userName = "crm-sysuser";
    //        var password = "[2cekthsfhukm]";
    //        var domain = "bss";
    //        var authCredentials = new AuthenticationCredentials();
    //        authCredentials.ClientCredentials.Windows.ClientCredential =
    //            new System.Net.NetworkCredential(userName, password, domain);
    //        return authCredentials;
    //    }
    //}

    public class CrmSdkManager
    {
        private static IServiceManagement<IOrganizationService> _orgServiceManagement;
        private static AuthenticationCredentials _credentials;

        internal IOrganizationService GetOrganizationService()
        {
            var orgServiceManagement = GetOrgServiceManagement();
            var credentials = GetCredentials();

            var proxy =
                new OrganizationServiceProxy(orgServiceManagement, credentials.ClientCredentials);
           
            return proxy;
        }

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
