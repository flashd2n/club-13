using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Flash.Club13.Web.Startup))]
namespace Flash.Club13.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
