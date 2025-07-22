using Microsoft.Owin;

using Ok.Framework.Db;

using Owin;

[assembly: OwinStartupAttribute(typeof(Ok.Framework.Web.Startup))]
namespace Ok.Framework.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAutofac(app);
        }
    }
}