using Data8.PowerPlatform.Dataverse.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Text;


// https://github.com/microsoft/PowerApps-Samples/tree/master/dataverse/orgsvc/C%23-NETCore/ServiceClient

namespace ConsoleNet5Xrm
{
    class Program
    {
        IConfiguration Configuration { get; }

        Program()
        {


            // Get the path to the appsettings file. If the environment variable is set,
            // use that file path. Otherwise, use the runtime folder's settings file.
            //string path = Environment.GetEnvironmentVariable("DATAVERSE_APPSETTINGS");
            //if (path == null) path = "appsettings.json";

            //// Load the app's configuration settings from the JSON file.
            //Configuration = new ConfigurationBuilder()
            //    .AddJsonFile(path, optional: false, reloadOnChange: true)
            //    .Build();

            var builder = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string>
            {
                {"firstname", "Tom"},
                {"age", "31"},
                {"default","AuthType=OAuth; Url = https://myorg.crm.dynamics.com;Username=someone@myorg.onmicrosoft.com;Password=mypassword;RedirectUri=http://localhost;AppId=51f81489-12ee-4a9e-aaae-a2591f45987d;LoginPrompt=Auto" }
            });
            Configuration = builder.Build();



        }


        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Начало.");

            var app = new Program();
            //var connectionString = app.Configuration.GetConnectionString("default");
            var connectionString = app.Configuration["default"];
            //var serviceClient =
            //    new ServiceClient(connectionString);

            //var serviceClient =
            //    new ServiceClient(


            IOrganizationService orgService = new OnPremiseClient("http://172.23.57.20/NSC/XRMServices/2011/Organization.svc", "bss\\crm-sysuser", "[2cekthsfhukm]");

            //var orgService = new ServiceClient(

            Console.WriteLine("Конец.");
            Console.ReadLine();

        }
    }
}
