using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signalRNotification.Notification
{
    /// <summary>
    /// License class for sending License related notification to the users
    /// </summary>
    public class License : INotification
    {
        private const string topic = "License";
        public void Send()
        {
            //TODO Have to read db and send notifications if db updated
            var context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            context.Clients.All.broadcastNotification(topic, "Your License got expire"); //TODO proper message has to change
        }
    }
}
