using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Stilwill.Web.Startup))]
namespace Stilwill.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
