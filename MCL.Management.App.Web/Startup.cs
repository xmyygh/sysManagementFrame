using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MCL.Management.App.Web.Startup))]
namespace MCL.Management.App.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
