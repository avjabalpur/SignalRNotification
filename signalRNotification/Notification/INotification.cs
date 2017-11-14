using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signalRNotification.Notification
{
    /// <summary>
    /// Interface for sending the notification.
    /// </summary>
   public interface INotification
    {
        /// <summary>
        /// Method for sending notification.
        /// </summary>
        void Send();
    }
}
