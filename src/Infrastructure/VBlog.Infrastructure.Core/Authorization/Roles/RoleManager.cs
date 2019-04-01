using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Domain.Uow;
using Abp.Runtime.Caching;
using Abp.Zero.Configuration;
using VBlog.Infrastructure.Core.Users;

namespace VBlog.Infrastructure.Core.Authorization.Roles
{

    /// <summary>
    /// The role manager.
    /// </summary>
    public class RoleManager : AbpRoleManager<Role, User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleManager"/> class.
        /// </summary>
        /// <param name="store">
        /// The store.
        /// </param>
        /// <param name="permissionManager">
        /// The permission manager.
        /// </param>
        /// <param name="roleManagementConfig">
        /// The role management config.
        /// </param>
        /// <param name="cacheManager">
        /// The cache manager.
        /// </param>
        /// <param name="unitOfWorkManager">
        /// The unit of work manager.
        /// </param>
        public RoleManager(
            RoleStore store,
            IPermissionManager permissionManager,
            IRoleManagementConfig roleManagementConfig,
            ICacheManager cacheManager,
            IUnitOfWorkManager unitOfWorkManager)
            : base(
                store,
                permissionManager,
                roleManagementConfig,
                cacheManager,
                unitOfWorkManager)
        {
        }
    }
}
