using Abp.Authorization.Users;
using Abp.Extensions;
using Microsoft.AspNet.Identity;
using System;

namespace VBlog.Infrastructure.Core.Users
{

    /// <summary>
    /// The user.
    /// </summary>
    public class User : AbpUser<User>
    {
        /// <summary>
        /// The default password.
        /// </summary>
        public const string DefaultPassword = "123qwe";

        /// <summary>
        /// The create random password.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        /// <summary>
        /// The create tenant admin user.
        /// </summary>
        /// <param name="tenantId">
        /// The tenant id.
        /// </param>
        /// <param name="emailAddress">
        /// The email address.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// The <see cref="User"/>.
        /// </returns>
        public static User CreateTenantAdminUser(int tenantId, string emailAddress, string password)
        {
            return new User
            {
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Password = new PasswordHasher().HashPassword(password)
            };
        }
    }
}
