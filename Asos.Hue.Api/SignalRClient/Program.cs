using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asos.Hue.Api;
using Asos.Hue.Api.Interfaces;
using Asos.Hue.Api.Options;
using Microsoft.AspNet.SignalR.Client;

namespace SignalRClient
{
    public static class Config
    {
        public static string HueApiUrl = "http://172.16.8.97/";
        public static string HueUserKey = "wQts2P-p7Lbf416lmTEJSQZjNMT9TwNOzvHpQeMY";

        public static string Proxy = "HomeHub";
        public static string SignalRClient = "RegisterHome";


    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Hue Api Client started ***");

            StartAsync().Wait();

            Console.ReadLine();
            Console.WriteLine("*** Exiting Hue Api Client started ***");
        }

        private static async Task StartAsync()
        {
            var uri = "http://hackergameshubazureapi.azurewebsites.net/";
            var client = new HubClient(uri);
            client.CreateProxy(Config.Proxy);
            await client.RegisterHandler<string, string>("BellPressed", BellPressedHandler);
            await client.Start(Config.SignalRClient);
        }

        private static async void BellPressedHandler(string msg, string id)
        {
            Console.WriteLine($"Message Received: {msg} : {id}");

            IHue hue = new HueHub(new HueHubOptions()
            {
                Uri = Config.HueApiUrl,
                UserKey = Config.HueUserKey
            });

            var bulb = new Bulb { Id = 2 };

            await hue.Flash(bulb, 10);
        }
    }
}

