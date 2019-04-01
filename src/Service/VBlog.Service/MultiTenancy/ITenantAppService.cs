using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using VBlog.Service.MultiTenancy.Dto;

namespace VBlog.Service.MultiTenancy
{

    /// <summary>
    /// The TenantAppService interface.
    /// </summary>
    public interface ITenantAppService : IApplicationService
    {
        /// <summary>
        /// The get tenants.
        /// </summary>
        /// <returns>
        /// The <see cref="ListResultDto"/>.
        /// </returns>
        ListResultDto<TenantListDto> GetTenants();

        /// <summary>
        /// The create tenant.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task CreateTenant(CreateTenantInput input);
    }
}
