using Abp.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBlog.Infrastructure.Core.Authorization.Roles;
using VBlog.Infrastructure.Core.Users;

namespace VBlog.Infrastructure.Core.Authorization
{
    /// <summary>
    /// The permission checker.
    /// </summary>
    public class PermissionCheckers : PermissionChecker<Role, User>
    {
        public PermissionCheckers(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
