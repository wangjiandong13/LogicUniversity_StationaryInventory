using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class NoticationController : Hub
    {
        public void send(String name, string message)
        {
            Clients.All.chat(name, message);
            Clients.Caller.chat(name, message);
        }
        public void SendOnlyName(String name)
        {
            Clients.All.receive(name);
        }
    }
}
