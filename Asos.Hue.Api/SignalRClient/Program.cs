using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace SignalRClient
{
    class Program
    {
        static void Main(string[] args)
        {
    
            StartAsync().Wait();

            Console.ReadLine();
        }

       private static async Task StartAsync()
        {
            var uri = "http://hackergameshubazureapi.azurewebsites.net/";
            var client = new HubClient(uri);
            client.CreateProxy("HomeHub");
            client.

        }
    }
}
