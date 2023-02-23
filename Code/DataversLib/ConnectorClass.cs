using Microsoft.PowerPlatform.Dataverse.Client;
using System;
using System.Net;

namespace DataversLib
{
    public class ConnectorClass
    {
        //protected string ConnectionStringName { get; private set; }
        ////protected CrmConnectionParameters ConnectionParameters { get; private set; }

        //public ConnectorClass(string connectionStringName)
        //{
        //    ConnectionStringName = connectionStringName;
        //}

        ////public ContextProvider365(CrmConnectionParameters connectionParameters)
        ////{
        ////    ConnectionParameters = connectionParameters;
        ////}

        //public void CreateContext(Guid? impersonateByUserId = null)
        //{
           
        //    ServiceClient service;
            
        //        service = CreateServiceClient();
            

        //    //if (impersonateByUserId.HasValue)
        //    //{
        //    //    service.CallerId = impersonateByUserId.Value;
        //    //}

        //    var organizationService = new CrmOrganizationService(service.OrganizationServiceProxy);
        //    return Context = new CrmContext365(OrganizationService);
        //}

        //private ServiceClient CreateServiceClient()
        //{
        //    var cred = new NetworkCredential();
        //    string connStr = "";// ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
        //    cred.UserName = GetParameterValue(connStr, "Username");
        //    cred.Password = GetParameterValue(connStr, "Password");
        //    cred.Domain = GetParameterValue(connStr, "Domain");
        //    var requireNewInstance =
        //        Convert.ToBoolean(GetParameterValue(connStr, "RequireNewInstance", "true"));
        //    var uri = new Uri(GetParameterValue(connStr, "Url"));

        //    return
        //        new ServiceClient(cred, uri.Host, uri.Port.ToString(),
        //        uri.LocalPath.Replace("/", string.Empty), requireNewInstance);
        //}

        ////private CrmServiceClient CreateServiceClientWithParameters()
        ////{
        ////    return
        ////        new CrmServiceClient(ConnectionParameters.Credential, ConnectionParameters.Url.Host,
        ////        ConnectionParameters.Url.Port.ToString(), ConnectionParameters.Url.LocalPath.Replace("/", string.Empty),
        ////        ConnectionParameters.RequireNewInstance);
        ////}
    }
}
