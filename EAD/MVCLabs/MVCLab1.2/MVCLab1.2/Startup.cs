using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCLab1._2.Startup))]
namespace MVCLab1._2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
