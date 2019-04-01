using Abp.AutoMapper;
using Abp.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VBlog.Infrastructure.Core;

namespace VBlog.Service.Blog
{
    [DependsOn(typeof(VBlogCoreModule), typeof(AbpAutoMapperModule))]
    public class BlogServiceModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
