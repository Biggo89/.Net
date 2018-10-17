using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GuestResponse.Startup))]
namespace GuestResponse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
