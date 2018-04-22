using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientWCFHostedInISS.ServiceReference;
using System.Threading.Tasks;

namespace ClientWCFHostedInISS
{
    class Program
    {
        static void Main(string[] args)
        {
            StockServiceClient proxy = new StockServiceClient("WSHttpBinding_IStockService");

            while (true)
            {
                Console.WriteLine("{0}: Calling GetPrice", System.DateTime.Now);
                StockPrice res = proxy.GetPrice("test");
                Console.WriteLine("Result in : {0}, Price:{1},calls : {2},\n requested by {3}", System.DateTime.Now, res.price, res.calls,res.RequestedBy);
                Console.ReadLine();
            }
        }
    }
}
