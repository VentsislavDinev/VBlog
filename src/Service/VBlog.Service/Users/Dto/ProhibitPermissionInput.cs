using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBlog.Service.Users.Dto
{

    public class ProhibitPermissionInput
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        [Range(1, long.MaxValue)]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the permission name.
        /// </summary>
        [Required]
        public string PermissionName { get; set; }
    }
}
