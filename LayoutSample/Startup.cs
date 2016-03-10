using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LayoutSample.Startup))]
namespace LayoutSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
