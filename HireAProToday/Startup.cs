using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HireAProToday.Startup))]
namespace HireAProToday
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
