using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(snip_n_stick.Startup))]
namespace snip_n_stick
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
