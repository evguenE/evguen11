using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WebApplicationTest3.Hub111
{
    public class MyHub1 : Hub
    {
        //public void Hello()
        //{
        //    Clients.All.hello();
        //}
        public void AddMessage(string name, string message)
        {
            Console.WriteLine("Hub AddMessage {0} {1}\n", name, message);
            Clients.All.addMessage(name, message);
        }
    }
}