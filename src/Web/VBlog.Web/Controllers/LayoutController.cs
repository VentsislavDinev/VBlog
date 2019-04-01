using Abp.Application.Navigation;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.Runtime.Session;
using Abp.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VBlog.Data.ViewModel.Layout;
using VBlog.Service.Sessions;

namespace VBlog.Web.Controllers
{
    public class LayoutController : BaseController
    {
        /// <summary>
        /// The _user navigation manager.
        /// </summary>
        private readonly IUserNavigationManager _userNavigationManager;

        /// <summary>
        /// The _session app service.
        /// </summary>
        private readonly ISessionAppService _sessionAppService;

        /// <summary>
        /// The _multi tenancy config.
        /// </summary>
        private readonly IMultiTenancyConfig _multiTenancyConfig;

        /// <summary>
        /// The _language manager.
        /// </summary>
        private readonly ILanguageManager _languageManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutController"/> class.
        /// </summary>
        /// <param name="userNavigationManager">
        /// The user navigation manager.
        /// </param>
        /// <param name="sessionAppService">
        /// The session app service.
        /// </param>
        /// <param name="multiTenancyConfig">
        /// The multi tenancy config.
        /// </param>
        /// <param name="languageManager">
        /// The language manager.
        /// </param>
        public LayoutController(
            IUserNavigationManager userNavigationManager,
            ISessionAppService sessionAppService,
            IMultiTenancyConfig multiTenancyConfig,
            ILanguageManager languageManager)
        {
            _userNavigationManager = userNavigationManager;
            _sessionAppService = sessionAppService;
            _multiTenancyConfig = multiTenancyConfig;
            _languageManager = languageManager;
        }

        /// <summary>
        /// The top menu.
        /// </summary>
        /// <param name="activeMenu">
        /// The active menu.
        /// </param>
        /// <returns>
        /// The <see cref="PartialViewResult"/>.
        /// </returns>
        [ChildActionOnly]
        public PartialViewResult TopMenu(string activeMenu = "")
        {
            var model = new TopMenuViewModel
            {
                MainMenu = AsyncHelper.RunSync(() => _userNavigationManager.GetMenuAsync("MainMenu", AbpSession.ToUserIdentifier())),
                ActiveMenuItemName = activeMenu
            };

            return PartialView("_TopMenu", model);
        }


        [ChildActionOnly]
        public PartialViewResult SocialMenu()
        {
            var model = new SocialMenuViewModel
            {
                SocialMenu = AsyncHelper.RunSync(() => _userNavigationManager.GetMenusAsync(AbpSession.ToUserIdentifier())),
            };

            return PartialView("_SocialMenu", model);
        }
        /// <summary>
        /// The language selection.
        /// </summary>
        /// <returns>
        /// The <see cref="PartialViewResult"/>.
        /// </returns>
        [ChildActionOnly]
        public PartialViewResult LanguageSelection()
        {
            var model = new LanguageSelectionViewModel
            {
                CurrentLanguage = _languageManager.CurrentLanguage,
                Languages = _languageManager.GetLanguages()
            };

            return PartialView("_LanguageSelection", model);
        }

        /// <summary>
        /// The user menu or login link.
        /// </summary>
        /// <returns>
        /// The <see cref="PartialViewResult"/>.
        /// </returns>
        [ChildActionOnly]
        public PartialViewResult UserMenuOrLoginLink()
        {
            UserMenuOrLoginLinkViewModel model;

            if (AbpSession.UserId.HasValue)
            {
                model = new UserMenuOrLoginLinkViewModel
                {
                    LoginInformations = AsyncHelper.RunSync(() => _sessionAppService.GetCurrentLoginInformations()),
                    IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled,
                };
            }
            else
            {
                model = new UserMenuOrLoginLinkViewModel
                {
                    IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled
                };
            }

            return PartialView("_UserMenuOrLoginLink", model);
        }
    }
}