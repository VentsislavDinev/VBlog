using Abp.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBlog.Infrastructure.Core.Users;

namespace VBlog.Infrastructure.Core.MultiTenancy
{
    /// <summary>
    /// The tenant.
    /// </summary>
    public class Tenant : AbpTenant<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tenant"/> class.
        /// </summary>
        public Tenant()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tenant"/> class.
        /// </summary>
        /// <param name="tenancyName">
        /// The tenancy name.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
