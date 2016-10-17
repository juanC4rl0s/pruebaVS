using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SoftGreenDoc.Startup))]
namespace SoftGreenDoc
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
