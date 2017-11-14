using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signalRNotification.Notification
{
    /// <summary>
    /// Db update class for sending db related notification to the users
    /// </summary>
    public class DbUpdate : INotification
    {
        private const string topic = "DbUpdate";
        public void Send()
        {
            //TODO Have to read db and send notifications if db updated
            var context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            context.Clients.All.broadcastNotification(topic, "Database has updated please refresh your page"); //TODO proper message has to change
        }
    }
}
