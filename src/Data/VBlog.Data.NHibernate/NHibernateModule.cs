using Abp.Configuration.Startup;
using Abp.Modules;
using FluentNHibernate.Cfg.Db;
using System.Configuration;
using System.Reflection;

namespace VBlog.Data.NHibernate
{
    public class NHibernateModule : AbpModule
    {
        public override void PreInitialize()
        {
            var connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            Configuration.Modules.AbpNHibernate().FluentConfiguration
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connStr))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()));
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
