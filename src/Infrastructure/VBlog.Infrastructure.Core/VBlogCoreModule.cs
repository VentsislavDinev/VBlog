using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using System.Reflection;
using VBlog.Infrastructure.Core.Authorization;
using VBlog.Infrastructure.Core.Authorization.Roles;
using VBlog.Infrastructure.Core.Timing;
using VBlog.Infrastructure.Core.Users;

namespace VBlog.Infrastructure.Core
{

    [DependsOn(typeof(AbpZeroCoreModule))]
    public class VBlogCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            //Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            Configuration.Localization.Sources.Add(
                           new DictionaryBasedLocalizationSource(
                               VBlogConsts.LocalizationSourceName,
                               new XmlEmbeddedFileLocalizationDictionaryProvider(
                                   Assembly.GetExecutingAssembly(),
                                   "VEducation.Infrastructure.Core.Localization.Source"
                                   )
                               )
                           );            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);



            Configuration.Authorization.Providers.Add<VBlogAuthorizationProvider>();

        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(VBlogCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
