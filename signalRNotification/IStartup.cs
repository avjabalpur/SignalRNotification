using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signalRNotification
{
   public interface IStartup
    {
        void Configuration(IAppBuilder app);
    }
}
