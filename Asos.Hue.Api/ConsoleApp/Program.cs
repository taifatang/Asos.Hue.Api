using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asos.Hue.Api;
using Asos.Hue.Api.Interfaces;
using Asos.Hue.Api.Options;

namespace ConsoleApp
{
    class Program
    {
        static  void Main(string[] args)
        {
            RunAsync().Wait();
         
            Console.ReadLine();
        }

        private static async Task RunAsync()
        {
            var options = new HueHubOptions()
            {
                Uri = "http://172.16.9.39/",
                UserKey = "wQts2P-p7Lbf416lmTEJSQZjNMT9TwNOzvHpQeMY"
            };
            IHue hue = new HueHub(options);

            //hue.Flash(2);

            var bulbs = await hue.GetAllBulbs();
            Console.WriteLine(bulbs.ToString());
        }
    }
}
