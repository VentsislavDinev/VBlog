using Abp.Web;
using System;
using VBlog.Web.Administration.App_Start;

namespace VBlog.Web.Administration
{
    public class MvcApplication : AbpWebApplication<VBlogWebModule>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            //AbpBootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(
            //    f => f.UseAbpLog4Net().WithConfig("log4net.config")
            //);

            base.Application_Start(sender, e);
        }
    }
}
