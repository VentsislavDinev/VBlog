using Abp.Extensions;
using System.Text.RegularExpressions;

namespace VBlog.Infrastructure.Core.Validation
{

    /// <summary>
    /// The validation helper.
    /// </summary>
    public static class ValidationHelper
    {
        /// <summary>
        /// The email regex.
        /// </summary>
        public const string EmailRegex = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        /// <summary>
        /// The is email.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsEmail(string value)
        {
            if (value.IsNullOrEmpty())
            {
                return false;
            }

            var regex = new Regex(EmailRegex);
            return regex.IsMatch(value);
        }
    }
}
