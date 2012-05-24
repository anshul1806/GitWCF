using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleClient.HelloWorldClientReference;



namespace ConsoleClient
{
    class Program
    {
        /// <summary>
        /// Following method initiates the client to talk to service on the 
        /// end points address specified in the app.config. We picked one of the end points.
        /// Any end point can be chosen
        /// </summary>
        /// <param name="args"></param>

         static void Main(string[] args)
        {
            HelloServiceClient client = new HelloServiceClient("WSHttpBinding_IHelloService");
            HelloData userName = new HelloData();
            userName.Fname = "Anshul";
            userName.Lname = "Pandey";
            Console.WriteLine("Client Send the message "+ userName.Fname + " "+ userName.Lname);
            Console.WriteLine("Client received Following Message from Service" + client.HelloWorld(userName));
            Console.ReadLine();
            Console.Read();

        }
    }
}
