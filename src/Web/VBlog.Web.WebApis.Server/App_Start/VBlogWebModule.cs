using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Hangfire;
using Abp.Localization;
using Abp.Modules;
using Abp.Web.Mvc;
using Abp.Web.Mvc.Configuration;
using Abp.Web.SignalR;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using VBlog.Data.Dapper;
using VBlog.Data.EntityFramework;
using VBlog.Infrastructure.Core;
using VBlog.Service;
using VBlog.Service.Blog;
using VBlog.Web.Common;
using VEducationWebApi;

namespace VBlog.Web.WebApis.Server.App_Start
{
    [DependsOn(
        typeof(VBlogDataModule),
        typeof(VBlogServiceCoreModule),
        typeof(VBlogCoreModule),
        typeof(DapperModule),
        typeof(BlogServiceModule),
        typeof(WebCommonModule),
        typeof(VBlogWebApiModule),
        typeof(AbpWebMvcModule),
        typeof(AbpWebSignalRModule), //Add AbpWebSignalRModule dependency
        typeof(AbpHangfireModule)
        )]
    public class VBlogWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Enable database based localization
            //Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();
            Configuration.Localization.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flag-england", true));
            Configuration.Localization.Languages.Add(new LanguageInfo("tr", "Türkçe", "famfamfam-flag-tr"));
            Configuration.Localization.Languages.Add(new LanguageInfo("zh-CN", "简体中文", "famfamfam-flag-cn"));
            Configuration.Modules.AbpMvc().IsValidationEnabledForControllers = false;

            //  Configuration.Localization.Sources.Add(
            //new DictionaryBasedLocalizationSource(
            //    "EducationLocalization",
            //    new XmlFileLocalizationDictionaryProvider(
            //        HttpContext.Current.Server.MapPath("~/Localization/Source")
            //        )
            //    )
            //);

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<VBlogNavigationProvider>();

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false; //Can disable job manager to not process jobs.

            //Configuration.BackgroundJobs.UseHangfire(
            //    configuration => //Configure to use hangfire for background jobs.
            //        {
            //            configuration.GlobalConfiguration.UseSqlServerStorage("Default"); //Set database connection
            //        });

            // var lang = IocManager.Resolve<ILanguageManager>().CurrentLanguage;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
               .ForAll<IApplicationService>(typeof(VBlogServiceCoreModule).Assembly, "app")
               .Build();

            ConfigureSwaggerUi();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }



        private void ConfigureSwaggerUi()
        {
            Configuration.Modules.AbpWebApi().HttpConfiguration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "VBlog.Web.WebApis.Server");
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                })
                .EnableSwaggerUi(c =>
                {
                    c.DocExpansion(DocExpansion.List);
                    c.BooleanValues(new[] { "0", "1" });

                    c.InjectJavaScript(Assembly.GetAssembly(typeof(VBlogServiceCoreModule)), "VBlog.Web.WebApis.Server.Scripts.Swagger-Custom.js");
                });
        }
    }
}