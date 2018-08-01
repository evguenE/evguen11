using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using ApiWebApplication1.Hubs;

namespace ApiWebApplication1.Hubs
{
    public class NotificationHub : Hub
    {

        //public async Task NotifyUpdates()
        //{
        //    var hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
        //    if (hubContext != null)
        //    {
        //        var stats = await this.GenerateStatistics();
        //        hubContext.Clients.All.updateStatistics(stats);
        //    }
        //}
        public void AddMessage(string name, string message)
        {
            Console.WriteLine("Hub AddMessage {0} {1}\n", name, message);
            Clients.All.aMessage(name, message);
        }

    }
}