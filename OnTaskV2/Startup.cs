using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnTaskV2.Startup))]
namespace OnTaskV2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
