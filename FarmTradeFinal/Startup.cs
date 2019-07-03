using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FarmTradeFinal.Startup))]
namespace FarmTradeFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
