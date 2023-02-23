using GMCS.CrmCore.Xrm.Context;
using GMCS.CrmCore.Xrm.Repository;
using GMCS.CrmCore.Xrm.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.CrmConnector.Core
{
    public class DynamicsCrmConnector : IConnector
    {
        public string Execute()
        {
            Console.WriteLine("Начало");

            var connectionParameters = new CrmConnectionParameters();
            string connStr = "Url=http://172.23.57.20/NSC; Domain=BSS; Username=crm-sysuser; Password=[2cekthsfhukm];";
            connectionParameters.Credential.UserName = GetParameterValue(connStr, "Username");
            connectionParameters.Credential.Password = GetParameterValue(connStr, "Password");
            connectionParameters.Credential.Domain = GetParameterValue(connStr, "Domain");
            connectionParameters.RequireNewInstance =
                Convert.ToBoolean(GetParameterValue(connStr, "RequireNewInstance", "true"));
            connectionParameters.Url = new Uri(GetParameterValue(connStr, "Url"));

            //var context = new ContextProvider365(connectionParameters);
            //var context = new ContextProviderProxy365(connectionParameters);
            //var context = new ContextProviderProxy365("CRM");
            var context = new ContextProvider365("CRM");
            var unitOfWorkFactory = new UnitOfWorkFactory(context);
            var commonRepository = new CommonRepository(context);

            Console.WriteLine("Середина");

            using (var uow = unitOfWorkFactory.Create())
            {
                var user =
                    //commonRepository.FindById<User>(new Guid("{1E932C9A-A92F-E511-80E8-0050568732BC}"));
                    commonRepository.FindById("systemuser", new Guid("{1E932C9A-A92F-E511-80E8-0050568732BC}"), true);
                Console.WriteLine(user.Id);
                return user.Id.ToString();
            }





            Console.WriteLine("Конец");

        }

        protected string GetParameterValue(string connectionString, string parameterName, string defaultValue = "")
        {
            const char ParametersSeparator = ';';
            const char ParametersSetter = '=';
            var paramBox =
                connectionString.Trim().Split(ParametersSeparator).Select(x => x.Split(ParametersSetter)).FirstOrDefault(x => x[0].Trim() == parameterName);
            return
                paramBox != null ? paramBox[1] : defaultValue;
        }
    }
}
