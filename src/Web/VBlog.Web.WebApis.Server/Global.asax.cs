using Abp.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using VBlog.Web.WebApis.Server.App_Start;

namespace VBlog.Web.WebApis.Server
{
    public class WebApiApplication : AbpWebApplication<VBlogWebModule>
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
