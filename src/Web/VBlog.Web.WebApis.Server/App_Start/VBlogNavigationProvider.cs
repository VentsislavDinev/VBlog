using Abp.Application.Navigation;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VBlog.Web.WebApis.Server.App_Start
{

    public class VBlogNavigationProvider : NavigationProvider
    {
        /// <summary>
        /// The set navigation.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Home",
                        new LocalizableString("Home", "Education"),
                        url: "/",
                        icon: "fa fa-home"))
                        //.AddItem(
                        //    new MenuItemDefinition(
                        //        "Tenants",
                        //        L("Tenants"),
                        //        url: "#tenants",
                        //        icon: "fa fa-globe",
                        //        requiredPermissionName: "Tenant"))
                        .AddItem(
                    new MenuItemDefinition(
                        "About",
                        new LocalizableString("About", "Education"),
                        url: "/Home/about",
                        icon: "fa fa-info"))
                        .AddItem(
                            new MenuItemDefinition(
                                       "Contact",
                                       new LocalizableString("Contact", "Education"),
                                       url: "/Home/Contact",
                                       icon: "fa fa-info"))
               .AddItem(
                            new MenuItemDefinition(
                                       "Events",
                                       new LocalizableString("Events", "Education"),
                                       url: "/Events/Index",
                                       icon: "fa fa-info"))
                                       .AddItem(
                            new MenuItemDefinition(
                                       "Courses",
                                       new LocalizableString("Courses", "Education"),
                                       url: "/Courses/Index",
                                       icon: "fa fa-info"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, "Education");
        }
    }
}