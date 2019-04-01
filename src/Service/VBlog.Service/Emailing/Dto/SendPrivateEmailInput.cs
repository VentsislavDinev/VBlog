using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBlog.Infrastructure.Core.Users;

namespace VBlog.Service.Emailing.Dto
{

    /// <summary>
    /// The send private email input.
    /// </summary>
    public class SendPrivateEmailInput : EntityDto
    {
        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        [Required]
        [MaxLength(User.MaxUserNameLength)]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        [Required]
        [MaxLength(128)]
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        [Required]
        [MaxLength(4000)]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether send notification.
        /// </summary>
        public bool SendNotification { get; set; }
    }
}
