using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PoolTourn.Startup))]
namespace PoolTourn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
