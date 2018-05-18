using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RunnersLog.Startup))]
namespace RunnersLog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
