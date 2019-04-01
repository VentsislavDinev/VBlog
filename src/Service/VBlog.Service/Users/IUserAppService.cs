using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBlog.Service.Users.Dto;

namespace VBlog.Service.Users
{

    /// <summary>
    /// The UserAppService interface.
    /// </summary>
    public interface IUserAppService : IApplicationService
    {
        /// <summary>
        /// The prohibit permission.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task ProhibitPermission(ProhibitPermissionInput input);

        /// <summary>
        /// The remove from role.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="roleName">
        /// The role name.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task RemoveFromRole(long userId, string roleName);
    }
}
