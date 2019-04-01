using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBlog.Infrastructure.Core.Users;

namespace VBlog.Infrastructure.Core.Authorization.Roles
{
    /// <summary>
    /// The role store.
    /// </summary>
    public class RoleStore : AbpRoleStore<Role, User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleStore"/> class.
        /// </summary>
        /// <param name="roleRepository">
        /// The role repository.
        /// </param>
        /// <param name="userRoleRepository">
        /// The user role repository.
        /// </param>
        /// <param name="rolePermissionSettingRepository">
        /// The role permission setting repository.
        /// </param>
        public RoleStore(
            IRepository<Role> roleRepository,
            IRepository<UserRole, long> userRoleRepository,
            IRepository<RolePermissionSetting, long> rolePermissionSettingRepository)
            : base(
                roleRepository,
                userRoleRepository,
                rolePermissionSettingRepository)
        {
        }
    }
}
