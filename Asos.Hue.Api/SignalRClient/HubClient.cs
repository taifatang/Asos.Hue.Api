using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace SignalRClient
{
    public class HubClient
    {
        private readonly HubConnection _hub;
        private readonly IHubProxy _proxy;
        public HubClient(string uri)
        {
            _hub = new HubConnection(uri);
            _proxy = _hub.CreateHubProxy("HomeHub");
        }

        public IHubProxy CreateProxy(string name)
        {
            return _hub.CreateHubProxy(name);
        }

        public async Task Start()
        {
            await _hub.Start();
        }
        public void Stop()
        {
            _hub.Stop();
        }
        public async Task Register(string name)
        {
            await _proxy.Invoke(name);
        }
        
        public async Task RegisterHandler<T1,T2>(string eventName, Action<T1, T2> handler)
        {
            _proxy.On<T1, T2>(eventName, handler);
        }
    }
}
