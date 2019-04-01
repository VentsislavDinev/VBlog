using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Zero.Configuration;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBlog.Infrastructure.Core.Authorization.Roles;
using VBlog.Infrastructure.Core.MultiTenancy;
using VBlog.Infrastructure.Core.Users;

namespace VBlog.Infrastructure.Core.Authorization
{

    /// <summary>
    /// The login manager.
    /// </summary>
    public class LoginManager : AbpLogInManager<Tenant, Role, User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginManager"/> class.
        /// </summary>
        /// <param name="userManager">
        /// The user manager.
        /// </param>
        /// <param name="multiTenancyConfig">
        /// The multi tenancy config.
        /// </param>
        /// <param name="tenantRepository">
        /// The tenant repository.
        /// </param>
        /// <param name="unitOfWorkManager">
        /// The unit of work manager.
        /// </param>
        /// <param name="settingManager">
        /// The setting manager.
        /// </param>
        /// <param name="userLoginAttemptRepository">
        /// The user login attempt repository.
        /// </param>
        /// <param name="userManagementConfig">
        /// The user management config.
        /// </param>
        /// <param name="iocResolver">
        /// The ioc resolver.
        /// </param>
        /// <param name="roleManager">
        /// The role manager.
        /// </param>
        public LoginManager(
            UserManager userManager,
            IMultiTenancyConfig multiTenancyConfig,
            IRepository<Tenant> tenantRepository,
            IUnitOfWorkManager unitOfWorkManager,
             ISettingManager settingManager,
            IRepository<UserLoginAttempt, long> userLoginAttemptRepository,
            IUserManagementConfig userManagementConfig,
            IIocResolver iocResolver,
            RoleManager roleManager)
            : base(
                userManager,
                multiTenancyConfig,
                tenantRepository,
                unitOfWorkManager,
                settingManager,
                userLoginAttemptRepository,
                userManagementConfig,
                iocResolver,
                roleManager)
        {
        }
    }
}
