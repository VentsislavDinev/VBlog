using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.IdentityFramework;
using Abp.Localization;
using Abp.Organizations;
using Abp.Runtime.Caching;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBlog.Infrastructure.Core.Authorization.Roles;

namespace VBlog.Infrastructure.Core.Users
{
    public class UserStore : AbpUserStore<Role, User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserStore"/> class.
        /// </summary>
        /// <param name="userRepository">
        /// The user repository.
        /// </param>
        /// <param name="userLoginRepository">
        /// The user login repository.
        /// </param>
        /// <param name="userRoleRepository">
        /// The user role repository.
        /// </param>
        /// <param name="roleRepository">
        /// The role repository.
        /// </param>
        /// <param name="userPermissionSettingRepository">
        /// The user permission setting repository.
        /// </param>
        /// <param name="unitOfWorkManager">
        /// The unit of work manager.
        /// </param>
        /// <param name="userClaimRepository">
        /// The user claim repository.
        /// </param>
        public UserStore(
            IRepository<User, long> userRepository,
            IRepository<UserLogin, long> userLoginRepository,
            IRepository<UserRole, long> userRoleRepository,
            IRepository<Role> roleRepository,
            IRepository<UserPermissionSetting, long> userPermissionSettingRepository,
            IUnitOfWorkManager unitOfWorkManager,
            IRepository<UserClaim, long> userClaimRepository) : base(
            userRepository,
            userLoginRepository,
            userRoleRepository,
            roleRepository,
            userPermissionSettingRepository,
            unitOfWorkManager,
            userClaimRepository)
        {
        }
    }
}
