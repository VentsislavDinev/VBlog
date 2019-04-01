using Abp.MultiTenancy;
using Abp.Zero.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBlog.Infrastructure.Core.Authorization.Roles
{
    /// <summary>
    /// The app role config.
    /// </summary>
    public static class AppRoleConfig
    {
        /// <summary>
        /// The configure.
        /// </summary>
        /// <param name="roleManagementConfig">
        /// The role management config.
        /// </param>
        public static void Configure(IRoleManagementConfig roleManagementConfig)
        {
            //Static host roles

            roleManagementConfig.StaticRoles.Add(
                new StaticRoleDefinition(
                    StaticRoleNames.Host.Admin,
                    MultiTenancySides.Host)
            );

            //Static tenant roles

            roleManagementConfig.StaticRoles.Add(
                new StaticRoleDefinition(
                    StaticRoleNames.Tenants.Admin,
                    MultiTenancySides.Tenant)
            );
        }
    }
}
