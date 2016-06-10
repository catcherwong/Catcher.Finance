using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Catcher.Finance.DataServiceViaNancyFx.Startup))]

namespace Catcher.Finance.DataServiceViaNancyFx
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();            
        }
    }
}
