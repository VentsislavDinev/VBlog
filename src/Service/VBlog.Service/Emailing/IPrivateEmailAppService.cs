using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBlog.Service.Emailing.Dto;

namespace VBlog.Service.Emailing
{

    /// <summary>
    /// The PrivateEmailAppService interface.
    /// </summary>
    public interface IPrivateEmailAppService : IApplicationService
    {
        /// <summary>
        /// The send.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task Send(SendPrivateEmailInput input);
    }
}
