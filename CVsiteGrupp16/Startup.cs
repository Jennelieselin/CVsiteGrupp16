using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CVsiteGrupp16.Startup))]
namespace CVsiteGrupp16
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
