using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBlog.Infrastructure.Core.Authorization
{
    /// <summary>
    /// The interception demo authorization provider.
    /// </summary>
    public class VBlogAuthorizationProvider : AuthorizationProvider
    {
        /// <summary>
        /// The set permissions.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //Common permissions
            var pages = context.GetPermissionOrNull(PermissionNames.Pages);
            if (pages == null)
            {
                pages = context.CreatePermission(PermissionNames.Pages, L("Pages"));
            }

            //Host permissions
            var tenants = pages.CreateChildPermission("Tenant2", L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, VBlogConsts.LocalizationSourceName);
        }
    }
}
