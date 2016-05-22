using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IjpieSite.Startup))]
namespace IjpieSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
