using Abp.Authorization;
using Abp.BackgroundJobs;
using Abp.Notifications;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBlog.Service.Emailing.Dto;
using VBlog.Service.Users;
using VBlog.Service.Users.Dto;

namespace VBlog.Service.Emailing
{

    /// <summary>
    /// The private email app service.
    /// </summary>
    [AbpAuthorize]
    public class PrivateEmailAppService : VBlogAppServiceBase, IPrivateEmailAppService
    {
        /// <summary>
        /// The _background job manager.
        /// </summary>
        private readonly IBackgroundJobManager _backgroundJobManager;

        /// <summary>
        /// The _notification publisher.
        /// </summary>
        private readonly INotificationPublisher _notificationPublisher;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrivateEmailAppService"/> class.
        /// </summary>
        /// <param name="backgroundJobManager">
        /// The background job manager.
        /// </param>
        /// <param name="notificationPublisher">
        /// The notification publisher.
        /// </param>
        public PrivateEmailAppService(IBackgroundJobManager backgroundJobManager, INotificationPublisher notificationPublisher)
        {
            _backgroundJobManager = backgroundJobManager;
            _notificationPublisher = notificationPublisher;
        }

        /// <summary>
        /// The send.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="UserFriendlyException">
        /// </exception>
        public async Task Send(SendPrivateEmailInput input)
        {
            var targetUser = await UserManager.FindByNameAsync(input.UserName);
            if (targetUser == null)
            {
                throw new UserFriendlyException("There is no such a user: " + input.UserName);
            }

            var currentUser = await GetCurrentUserAsync();

            await _backgroundJobManager.EnqueueAsync<SendPrivateEmailJob, SendPrivateEmailJobArgs>(
                new SendPrivateEmailJobArgs
                {
                    Subject = input.Subject,
                    Body = input.Body,
                    SenderUserId = currentUser.Id,
                    TargetTenantId = AbpSession.TenantId,
                    TargetUserId = targetUser.Id
                });

            if (input.SendNotification)
            {
                var notificationData = new MessageNotificationData(
                    string.Format("{0} sent you an email with subject: {1}",
                        currentUser.UserName,
                        input.Subject
                    )
                );

                await this._notificationPublisher.PublishAsync(NotificationNames.YouHaveAnEmail, notificationData).ConfigureAwait(false);
            }
        }
    }

    /// <summary>
    /// The notification names.
    /// </summary>
    public static class NotificationNames
    {
        /// <summary>
        /// The you have an email.
        /// </summary>
        public const string YouHaveAnEmail = "App.YouHaveAnEmail";
    }
}
