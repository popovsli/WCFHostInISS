using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading;
using System.Web;

namespace StockService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession,
         ConcurrencyMode = ConcurrencyMode.Multiple)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class StockServices : IStockService
    {
        object lockthis = new object();
        private int n_Calls = 0;
        StockServices()
        {
            Console.WriteLine("{0} : Created new isntance of StockService on thread", System.DateTime.Now);
        }

        [OperationBehavior(Impersonation = ImpersonationOption.Required)]
        //[MyOperationBehavior(pattern = "[^a-zA-Z]", message = "Only alpha characters allowed")]
        public StockPrice GetPrice(string ticker)
        {
            StockPrice price = new StockPrice();
            Console.WriteLine("{0} : GetPrice called on thread {1}", System.DateTime.Now, Thread.CurrentThread.ManagedThreadId);
            price.price = 94.85;
            lock (lockthis)
            {
                price.calls = ++n_Calls;
            }
            price.RequestedBy = WindowsIdentity.GetCurrent().Name;
            Thread.Sleep(100);
            return price;
        }
    }
}
