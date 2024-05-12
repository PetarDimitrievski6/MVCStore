using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCStore.Startup))]
namespace MVCStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
