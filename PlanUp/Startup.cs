using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlanUp.Startup))]
namespace PlanUp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
