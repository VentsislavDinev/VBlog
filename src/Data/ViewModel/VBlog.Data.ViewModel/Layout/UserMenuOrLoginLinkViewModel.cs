using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBlog.Service.Sessions.Dto;

namespace VBlog.Data.ViewModel.Layout
{

    /// <summary>
    /// The user menu or login link view model.
    /// </summary>
    public class UserMenuOrLoginLinkViewModel
    {
        /// <summary>
        /// Gets or sets the login informations.
        /// </summary>
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is multi tenancy enabled.
        /// </summary>
        public bool IsMultiTenancyEnabled { get; set; }

        /// <summary>
        /// The get shown login name.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetShownLoginName()
        {
            var userName = "<span id=\"HeaderCurrentUserName\">" + LoginInformations.User.UserName + "</span>";

            if (!IsMultiTenancyEnabled)
            {
                return userName;
            }

            return LoginInformations.Tenant == null
                       ? ".\\" + userName
                       : LoginInformations.Tenant.TenancyName + "\\" + userName;
        }
    }
}
