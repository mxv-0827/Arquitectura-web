using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Jugueteria.Startup))]
namespace Jugueteria
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
