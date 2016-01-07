using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteConsole.Server
{
    class ShellCommandController : Hub
    {
        protected static readonly ConcurrentDictionary<string, ProcessInfo> _processes = new ConcurrentDictionary<string, ProcessInfo>();

        public override Task OnConnected()
        {
            this.Context.ConnectionId
            return base.OnConnected();
        }
    }
}
