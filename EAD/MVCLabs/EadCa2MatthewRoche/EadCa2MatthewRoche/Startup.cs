using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EadCa2MatthewRoche.Startup))]
namespace EadCa2MatthewRoche
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
