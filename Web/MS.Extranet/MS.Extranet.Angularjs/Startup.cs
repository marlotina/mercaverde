using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MS.Extranet.Angularjs.Startup))]
namespace MS.Extranet.Angularjs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
