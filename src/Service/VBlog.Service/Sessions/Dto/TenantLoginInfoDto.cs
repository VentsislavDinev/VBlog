using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBlog.Infrastructure.Core.MultiTenancy;

namespace VBlog.Service.Sessions.Dto
{

    /// <summary>
    /// The tenant login info dto.
    /// </summary>
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        /// <summary>
        /// Gets or sets the tenancy name.
        /// </summary>
        public string TenancyName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
    }
}
