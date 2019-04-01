using Abp.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBlog.Infrastructure.Core.Users;
using VBlog.Service.Users.Dto;

namespace VBlog.Service.Users
{

    /* THIS IS JUST A SAMPLE. */
    /// <summary>
    /// The user app service.
    /// </summary>
    public class UserAppService : VBlogAppServiceBase
    {
        /// <summary>
        /// The _user manager.
        /// </summary>
        private readonly UserManager _userManager;

        /// <summary>
        /// The _permission manager.
        /// </summary>
        private readonly IPermissionManager _permissionManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAppService"/> class.
        /// </summary>
        /// <param name="userManager">
        /// The user manager.
        /// </param>
        /// <param name="permissionManager">
        /// The permission manager.
        /// </param>
        public UserAppService(UserManager userManager, IPermissionManager permissionManager)
        {
            _userManager = userManager;
            _permissionManager = permissionManager;
        }

        public async Task ProhibitPermission(ProhibitPermissionInput input)
        {
            var user = await this._userManager.GetUserByIdAsync(input.UserId).ConfigureAwait(false);
            var permission = _permissionManager.GetPermission(input.PermissionName);

            await this._userManager.ProhibitPermissionAsync(user, permission).ConfigureAwait(true);
        }

        //Example for primitive method parameters.
        public async Task RemoveFromRole(long userId, string roleName)
        {
            CheckErrors(await _userManager.RemoveFromRoleAsync(userId, roleName));
        }
    }
}
