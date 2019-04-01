using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBlog.Infrastructure.Core.MultiTenancy;

namespace VBlog.Service.MultiTenancy.Dto
{
    /// <summary>
    /// The tenant list dto.
    /// </summary>
    [AutoMapFrom(typeof(Tenant))]
    public class TenantListDto : EntityDto
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
