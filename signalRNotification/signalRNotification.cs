using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using signalRNotification.Notification;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

[assembly: OwinStartup(typeof(signalRNotification.Startup))]
namespace signalRNotification
{
    /// <summary>
    /// Window service for ERP notification
    /// </summary>
    public partial class signalRNotification : ServiceBase
    {
        private Timer timer;
        private IStartup iStartup;
        private INotification iNotification;

        /// <summary>
        /// Constructor for sending notification
        /// </summary>
        public signalRNotification()
        {
            InitializeComponent();
            iStartup = new Startup();
            iNotification = new DbUpdate();
        }

        /// <summary>
        /// Use this method ones service will start.
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            bootStrapService();
        }


        /// <summary>
        /// Bootstram services methods
        /// </summary>
        private void bootStrapService()
        {
            if (!EventLog.SourceExists("signalRNotification"))
            {
                EventLog.CreateEventSource(
                    "signalRNotification", "Application");
            }
            eventLog1.Source = "signalRNotification";
            eventLog1.Log = "Application";

            eventLog1.WriteEntry("In OnStart");
            string url = "http://localhost:8080";
            WebApp.Start(url);


            this.timer = new Timer(30000D);
            this.timer.AutoReset = true;
            this.timer.Elapsed += new ElapsedEventHandler(this.timer_Elapsed);
            this.timer.Start();
        }

        protected override void OnStop()
        {
            this.timer.Stop();
            this.timer = null;
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            iNotification.Send();
           
        }
        
    }
}
