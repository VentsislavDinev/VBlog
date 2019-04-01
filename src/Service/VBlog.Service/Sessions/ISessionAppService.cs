using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBlog.Service.Sessions.Dto;

namespace VBlog.Service.Sessions
{

    /// <summary>
    /// The SessionAppService interface.
    /// </summary>
    public interface ISessionAppService : IApplicationService
    {
        /// <summary>
        /// The get current login informations.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
