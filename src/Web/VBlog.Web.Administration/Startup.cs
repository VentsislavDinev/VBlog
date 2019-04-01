using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VBlog.Web.Administration.Startup))]
namespace VBlog.Web.Administration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
