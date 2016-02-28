using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MatthewRocheEadCA3.Startup))]
namespace MatthewRocheEadCA3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
