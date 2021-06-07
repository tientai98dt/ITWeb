using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITWeb.Startup))]
namespace ITWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
