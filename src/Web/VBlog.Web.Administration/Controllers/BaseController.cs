using Abp.IdentityFramework;
using Abp.UI;
using Abp.Web.Mvc.Controllers;
using Microsoft.AspNet.Identity;

namespace VBlog.Web.Administration.Controllers
{
    public class BaseController : AbpController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ControllerBase"/> class.
        /// </summary>
        protected BaseController()
        {
            //LocalizationSourceName = EducationConsts.LocalizationSourceName;
        }

        /// <summary>
        /// The check model state.
        /// </summary>
        /// <exception cref="UserFriendlyException">
        /// </exception>
        protected virtual void CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                throw new UserFriendlyException(L("FormIsNotValidMessage"));
            }
        }

        /// <summary>
        /// The check errors.
        /// </summary>
        /// <param name="identityResult">
        /// The identity result.
        /// </param>
        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}