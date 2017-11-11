using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Proyecto1_LA.Startup))]
namespace Proyecto1_LA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
