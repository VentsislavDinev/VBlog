using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace VBlog.Web.Views
{
    /// <summary>
    /// The url checker.
    /// </summary>
    public static class UrlChecker
    {
        /// <summary>
        /// The url with protocol regex.
        /// </summary>
        private static readonly Regex UrlWithProtocolRegex = new Regex("^.{1,10}://.*$");

        /// <summary>
        /// The is rooted.
        /// </summary>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsRooted(string url)
        {
            if (url.StartsWith("/"))
            {
                return true;
            }

            if (UrlWithProtocolRegex.IsMatch(url))
            {
                return true;
            }

            return false;
        }
    }
}