using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EasyUILearn.Startup))]
namespace EasyUILearn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
