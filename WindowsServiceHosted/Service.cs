using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using StockService;
using System.ServiceModel.Description;

namespace WindowsServiceHosted
{

    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;

        public ProjectInstaller()
        {
            process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;
            service = new ServiceInstaller();
            service.ServiceName = "EssentialWCF";
            Installers.Add(process);
            Installers.Add(service);
        }

    }

    public partial class Service : ServiceBase
    {

        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ServiceHost serviceHost = new ServiceHost(typeof(StockServices));

            serviceHost.Open();

            ServiceEndpoint endPoint = serviceHost.Description.Endpoints[0];

            EventLog.WriteEntry(endPoint.Contract.Name +
                "Started" + "listening on " + endPoint.Address +
                " (" + endPoint.Binding.Name + ")",
                System.Diagnostics.EventLogEntryType.Information);
        }

        protected override void OnStop()
        {
            EventLog.WriteEntry("EssentialWCF Stopping", System.Diagnostics.EventLogEntryType.Information);
        }
    }
}
