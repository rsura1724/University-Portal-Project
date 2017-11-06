using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniversityApplicationPortal.Startup))]
namespace UniversityApplicationPortal
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
           // GlobalConfiguration.Configure(WebApiConfig.Register);

            ConfigureAuth(app);
        }
    }
}
