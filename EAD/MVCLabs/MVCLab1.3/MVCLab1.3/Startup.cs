using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCLab1._3.Startup))]
namespace MVCLab1._3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
