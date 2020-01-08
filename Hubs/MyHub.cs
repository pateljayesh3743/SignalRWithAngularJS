using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRWithAngularJS.Hubs
{
    public class MyHub : Hub
    {
        [HubMethodName("broadcastData")]
        public static void BroadcastData(studentfirstclass model)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            context.Clients.All.updateGrid(model);
        }
    }
}