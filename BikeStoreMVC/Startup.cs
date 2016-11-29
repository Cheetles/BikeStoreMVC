using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BikeStoreMVC.Startup))]
namespace BikeStoreMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
