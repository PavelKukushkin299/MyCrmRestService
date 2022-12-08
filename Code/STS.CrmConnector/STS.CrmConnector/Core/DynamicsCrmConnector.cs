using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.CrmConnector.Core
{
    public class DynamicsCrmConnector : IConnector
    {
        public void Execute()
        {
            Console.WriteLine("Начало");
            Console.WriteLine("Конец");
        }
    }
}
