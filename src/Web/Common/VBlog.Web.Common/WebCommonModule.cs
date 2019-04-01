using Abp.AutoMapper;
using Abp.Modules;
using System.Reflection;
using VBlog.Infrastructure.Core;

namespace VBlog.Web.Common
{
    [DependsOn(typeof(VBlogCoreModule), typeof(AbpAutoMapperModule))]
    public class WebCommonModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
