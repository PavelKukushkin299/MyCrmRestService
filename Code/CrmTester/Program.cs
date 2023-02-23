using STS.CrmConnector;
using STS.CrmConnector.Core;
using System;

namespace CrmTester
{
    class Program
    {
        static void Main(string[] args)
        {
            IConnector connector = new DynamicsCrmConnector();
            connector.Execute();
        }
    }
}
