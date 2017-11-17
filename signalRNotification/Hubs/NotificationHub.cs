using System;
using System.Linq;
using Microsoft.AspNet.SignalR;
using signalRNotification.Notification;
using System.Timers;

namespace signalRNotification.Hubs
{
    /// <summary>
    /// Notification hub class for sending notification
    /// </summary>
    public class NotificationHub : Hub
    {
        /// <summary>
        /// Send Notification to all the users ones notification send manually.
        /// </summary>
        public void SendNotification()
        {
            Clients.All.broadcastNotification("Amit", "Came Here");
        }

    }
}
