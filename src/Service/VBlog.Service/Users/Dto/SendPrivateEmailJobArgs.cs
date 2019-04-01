using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBlog.Service.Users.Dto
{
    /// <summary>
    /// The send private email job args.
    /// </summary>
    [Serializable]
    public class SendPrivateEmailJobArgs
    {
        /// <summary>
        /// Gets or sets the sender user id.
        /// </summary>
        public long SenderUserId { get; set; }

        /// <summary>
        /// Gets or sets the target tenant id.
        /// </summary>
        public int? TargetTenantId { get; set; }

        /// <summary>
        /// Gets or sets the target user id.
        /// </summary>
        public long TargetUserId { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        public string Body { get; set; }
    }
}
