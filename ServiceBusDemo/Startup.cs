using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ServiceBusDemo.Startup))]
namespace ServiceBusDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
