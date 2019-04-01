namespace VBlog.Data.EntityFramework.Migrations
{
    using Abp.MultiTenancy;
    using global::EntityFramework.DynamicFilters;
    using System.Data.Entity.Migrations;
    using VBlog.Data.EntityFramework.Migrations.SeedData;

    internal sealed class Configuration : DbMigrationsConfiguration<VBlog.Data.EntityFramework.VBlogDbContext>
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(VBlog.Data.EntityFramework.VBlogDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
