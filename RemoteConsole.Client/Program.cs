using Microsoft.AspNet.SignalR.Client;
using RemoteConsole.Core.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteConsole.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                var conHub = new HubConnection("http://localhost:8080/");
                conHub.CreateHubProxy("Shell").On<ShellCommandParams>("cmd", (data) =>
                {
                });

                using (var con = new Connection("http://localhost:8080/api/cmd"))
                {
                    con.Received += (data) =>
                    {
                        Console.WriteLine($"ola, recebi! {data}");
                    };
                    con.StateChanged += (state) =>
                    {
                        if (state.NewState != state.OldState)
                        {
                            Console.WriteLine($"De {state.OldState} para {state.NewState}");
                        }
                    };
                    await con.Start();

                    await con.Send("Hello Mello");
                }
            }).Wait();

        }
    }
}
