using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Scentasy.Startup))]
namespace Scentasy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
