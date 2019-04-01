using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBlog.Service.Roles.Dto
{

    /// <summary>
    /// The update role permissions input.
    /// </summary>
    public class UpdateRolePermissionsInput
    {
        /// <summary>
        /// Gets or sets the role id.
        /// </summary>
        [Range(1, int.MaxValue)]
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the granted permission names.
        /// </summary>
        [Required]
        public List<string> GrantedPermissionNames { get; set; }
    }
}
