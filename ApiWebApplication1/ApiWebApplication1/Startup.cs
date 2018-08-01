using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Microsoft.AspNet.SignalR;
using Owin;

[assembly: OwinStartup(typeof(ApiWebApplication1.Startup))]

namespace ApiWebApplication1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Turn on the cross domain access
            var config = new HubConfiguration { 
                //EnableCrossDomain = true,
                EnableJSONP = true};
            app.MapHubs(config);
            
            //ConfigureAuth(app);
            //app.MapSignalR();
        }
    }
}
