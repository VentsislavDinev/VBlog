using Abp.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBlog.Infrastructure.Core.Authorization.Roles;
using VBlog.Service.Roles.Dto;

namespace VBlog.Service.Roles
{
    /// <summary>
    /// The role app service.
    /// </summary>
    public class RoleAppService : VBlogAppServiceBase, IRoleAppService
    {
        /// <summary>
        /// The _role manager.
        /// </summary>
        private readonly RoleManager _roleManager;

        /// <summary>
        /// The _permission manager.
        /// </summary>
        private readonly IPermissionManager _permissionManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleAppService"/> class.
        /// </summary>
        /// <param name="roleManager">
        /// The role manager.
        /// </param>
        /// <param name="permissionManager">
        /// The permission manager.
        /// </param>
        public RoleAppService(RoleManager roleManager, IPermissionManager permissionManager)
        {
            _roleManager = roleManager;
            _permissionManager = permissionManager;
        }

        /// <summary>
        /// The update role permissions.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task UpdateRolePermissions(UpdateRolePermissionsInput input)
        {
            var role = await _roleManager.GetRoleByIdAsync(input.RoleId);
            var grantedPermissions = _permissionManager
                .GetAllPermissions()
                .Where(p => input.GrantedPermissionNames.Contains(p.Name))
                .ToList();

            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);
        }
    }
}
