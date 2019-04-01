using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBlog.Service.Sessions.Dto
{

    /// <summary>
    /// The get current login informations output.
    /// </summary>
    public class GetCurrentLoginInformationsOutput
    {
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        public UserLoginInfoDto User { get; set; }

        /// <summary>
        /// Gets or sets the tenant.
        /// </summary>
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
