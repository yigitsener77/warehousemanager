using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UI.Web.V1.Startup))]
namespace UI.Web.V1
{
    public partial class Startup: BusinessLogic.Middlewares.Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
