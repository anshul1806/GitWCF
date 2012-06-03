using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvalServiceLibrary;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.ServiceModel.Description;

namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
         IntializeConsoleHost();
        
        }

        private static void IntializeConsoleHost()
        {
            ServiceHost host= new ServiceHost(typeof(EvalService));
            CreateServiceMetaDataBehaviour(ref host);

            PrintServiceDetails( host);
            Console.ReadLine();

            ////host.AddServiceEndpoint(typeof(IEval), new BasicHttpBinding(), "http://localhost:8080/evals/basic");
            ////host.AddServiceEndpoint(typeof(IEval), new WSHttpBinding(), "http://localhost:8081/evals/ws");
            ////host.AddServiceEndpoint(typeof(IEval), new NetTcpBinding(), "net.tcp://localhost:8082/evals");
            try
            {
                Console.WriteLine("Attempting to host the service end points");
                host.Open();
                PrintServiceDetails(host);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured while opening Service end point" + ex.Message);
                host.Abort();

            }

        }

        private static void CreateServiceMetaDataBehaviour(ref ServiceHost host)
        {
            //ServiceMetadataBehavior smb = new ServiceMetadataBehavior(); 
            //smb.HttpGetEnabled =  true;
            //smb.HttpGetUrl = new Uri("http://localhost:8088/evals/meta");
            //host.Description.Behaviors.Add(smb);

        }

     

        private static void PrintServiceDetails(ServiceHost host)
        {
            Console.WriteLine("Service is up and listening at following end points");
            Console.WriteLine("host.Description.Name"+host.Description.ServiceType);
            foreach (var endPoint in host.Description.Endpoints)
            {
                Console.WriteLine("\nEnpoint:"+ endPoint.Address);
            }
           
        }
    }
}
