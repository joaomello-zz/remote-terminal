using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteConsole.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:8080";
            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }
        }
    }
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR<PersistentCommandController>("/api/cmd");
        }
    }

    public class PersistentCommandController : PersistentConnection
    {
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            Console.WriteLine($"Cliente {connectionId} connectado");
            this.Connection.Send(connectionId, "Ola, seja bem vindo");
            return base.OnConnected(request, connectionId);
        }

        protected override Task OnDisconnected(IRequest request, string connectionId, bool stopCalled)
        {
            Console.WriteLine($"Cliente {connectionId} desconnectou");
            return base.OnDisconnected(request, connectionId, stopCalled);
        }

        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            Console.WriteLine($"Cliente {connectionId} mandou {data}");
            return base.OnReceived(request, connectionId, data);
        }
    }
}
