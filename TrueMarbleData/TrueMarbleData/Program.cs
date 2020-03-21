using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TrueMarbleData
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host;
            NetTcpBinding tcpBinding = new NetTcpBinding();

            tcpBinding.MaxReceivedMessageSize = System.Int32.MaxValue;
            tcpBinding.ReaderQuotas.MaxArrayLength = System.Int32.MaxValue;

            host = new ServiceHost(typeof(TMDataControllerImpl));
            host.AddServiceEndpoint(typeof(ITMDataController), tcpBinding, "net.tcp://localhost:50001/TMData");

            host.Open();

            Console.WriteLine("press enter to exit");
            Console.ReadLine();

            host.Close();

        }
    }
}
