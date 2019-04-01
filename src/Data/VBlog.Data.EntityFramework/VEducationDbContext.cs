using Abp.Zero.EntityFramework;
using System.Data.Common;
using System.Data.Entity;
using VBlog.Data.Model;
using VBlog.Infrastructure.Core.Authorization.Roles;
using VBlog.Infrastructure.Core.MultiTenancy;
using VBlog.Infrastructure.Core.Users;

namespace VBlog.Data.EntityFramework
{
    /// <summary>
    /// The education db context.
    /// </summary>

    public class VBlogDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        public IDbSet<ForumPost> ForumPosts { get; set; }
        public IDbSet<Think> Thinks { get; set; }
        public IDbSet<About> Abouts { get; set; }
        public IDbSet<ForumPostAnswer> ForumPostsAnswers { get; set; }
        public IDbSet<ForumPostCategory> ForumPostCategoryes { get; set; }
        public IDbSet<ForumPostSubCategory> ForumPostSubCategoryes { get; set; }
        public IDbSet<ForumPostVote> ForumPostVotes { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public VBlogDbContext()
            : base("DefaultConnection")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EducationDbContext"/> class.
        ///  This constructor is used by ABP to pass connection string defined in InterceptionDemoDataModule.PreInitialize.
        /// Notice that, actually you will not directly create an instance of InterceptionDemoDbContext since ABP automatically handles it.
        /// </summary>
        /// <param name="nameOrConnectionString">
        /// The name or connection string.
        /// </param>
        public VBlogDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        //This constructor is used in tests
        public VBlogDbContext(DbConnection connection)
            : base(connection, true)
        {
        }
    }
}
