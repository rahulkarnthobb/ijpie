using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ijpie.Web.Startup))]
namespace ijpie.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
