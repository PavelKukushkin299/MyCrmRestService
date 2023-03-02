using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ConsoleNet5XrmWithRest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            //var client = new WebClient();
            //client.UseDefaultCredentials = true;
            ////var url = "http://172.23.57.20/NSC/api/data/v9.0/";
            //var url = "http://172.23.57.20/NSC/";

            //HttpClient httpClient = null;
            //httpClient = new HttpClient();
            ////Default Request Headers needed to be added in the HttpClient Object
            //httpClient.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
            //httpClient.DefaultRequestHeaders.Add("OData-Version", "4.0");
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            ////Set the Authorization header with the Access Token received specifying the Credentials
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

            //httpClient.BaseAddress = new Uri(redirectUrl);
            //var response = httpClient.GetAsync("accounts?$select=name&$top=5").Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    var accounts = response.Content.ReadAsStringAsync().Result;
            //}

            #region работает 1

            HttpClient client = new HttpClient(new HttpClientHandler() { Credentials = new NetworkCredential("avzharov", "Passw0rd!DEV", "bss") });
            //client.BaseAddress = new Uri(Helpers.GetSystemUrl(COHEN.APIConnector.Application.Dynamics));
            client.BaseAddress = new Uri("http://172.23.57.20");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
            client.DefaultRequestHeaders.Add("OData-Version", "4.0");
            HttpResponseMessage responseMessage;
            //string url = "ccseq_clients";
            //var url = "/NSC/XRMServices/2011/OrganizationData.svc/gm_abonentSet(guid'00000000-0000-0001-0000-000000000080')";
            //string url = "/NSC/XRMServices/2011/OrganizationData.svc/gm_abonentSet?top=1";
            //var url = "/NSC/api/data/v9.0/gm_abonentSet(guid'00000000-0000-0001-0000-000000000080')";
            //var url = "/NSC/api/data/v9.0/gm_abonent?$filter=gm_abonent_id eq B33E8EE7-4AB5-42FF-9665-E32CB8883BA2";
            var url = "/NSC/api/data/v9.0/gm_abonents(B33E8EE7-4AB5-42FF-9665-E32CB8883BA2)";
            responseMessage = client.GetAsync(url).Result;

            Console.ReadLine();

            responseMessage = client.GetAsync(url).Result;

            #endregion работает 1

            #region работает 2

            //using (WebClient client = new WebClient())
            //{
            //    client.UseDefaultCredentials = true;
            //    client.Credentials = new NetworkCredential("avzharov", "Passw0rd!DEV", "bss");
            //    client.BaseAddress = "http://172.23.57.20";
            //    client.Headers.Add(HttpRequestHeader.Accept, "application/json");
            //    client.Headers.Add("OData-MaxVersion", "4.0");
            //    client.Headers.Add("OData-Version", "4.0");
            //    string url = "/NSC/XRMServices/2011/OrganizationData.svc/gm_abonentSet(guid'00000000-0000-0001-0000-000000000080')";
            //    //string url = "/NSC/api/data/v9.0/gm_abonentSet(guid'00000000-0000-0001-0000-000000000080')";
            //    byte[] responseBytes = client.DownloadData(url);
            //    string response = Encoding.UTF8.GetString(responseBytes);

            //    Console.ReadLine();

            //    responseBytes = client.DownloadData(url);
            //    response = Encoding.UTF8.GetString(responseBytes);
            //    // parse the json response 
            //}

            //Console.ReadLine();

            #endregion работает 2
        }
    }
}
