using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBlog.Infrastructure.Core.Authorization.Roles;
using VBlog.Infrastructure.Core.Editions;
using VBlog.Infrastructure.Core.MultiTenancy;
using VBlog.Infrastructure.Core.Users;
using VBlog.Service.MultiTenancy.Dto;

namespace VBlog.Service.MultiTenancy
{
    /// <summary>
    /// The tenant app service.
    /// </summary>
    public class TenantAppService : VBlogAppServiceBase, ITenantAppService
    {
        /// <summary>
        /// The _tenant manager.
        /// </summary>
        private readonly TenantManager _tenantManager;

        /// <summary>
        /// The _role manager.
        /// </summary>
        private readonly RoleManager _roleManager;

        /// <summary>
        /// The _edition manager.
        /// </summary>
        private readonly EditionManager _editionManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="TenantAppService"/> class.
        /// </summary>
        /// <param name="tenantManager">
        /// The tenant manager.
        /// </param>
        /// <param name="roleManager">
        /// The role manager.
        /// </param>
        /// <param name="editionManager">
        /// The edition manager.
        /// </param>
        public TenantAppService(TenantManager tenantManager, RoleManager roleManager, EditionManager editionManager)
        {
            _tenantManager = tenantManager;
            _roleManager = roleManager;
            _editionManager = editionManager;
        }

        /// <summary>
        /// The get tenants.
        /// </summary>
        /// <returns>
        /// The <see cref="ListResultDto"/>.
        /// </returns>
        public ListResultDto<TenantListDto> GetTenants()
        {
            return new ListResultDto<TenantListDto>(
                _tenantManager.Tenants
                    .OrderBy(t => t.TenancyName)
                    .ToList()
                    .MapTo<List<TenantListDto>>()
                );
        }

        /// <summary>
        /// The create tenant.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task CreateTenant(CreateTenantInput input)
        {
            //Create tenant
            var tenant = new Tenant(input.TenancyName, input.Name);
            var defaultEdition = await _editionManager.FindByNameAsync(EditionManager.DefaultEditionName);
            if (defaultEdition != null)
            {
                tenant.EditionId = defaultEdition.Id;
            }

            await TenantManager.CreateAsync(tenant);
            await CurrentUnitOfWork.SaveChangesAsync(); //To get new tenant's id.

            //We are working entities of new tenant, so changing tenant filter
            using (CurrentUnitOfWork.SetFilterParameter(AbpDataFilters.MayHaveTenant, AbpDataFilters.Parameters.TenantId, tenant.Id))
            {
                //Create static roles for new tenant
                CheckErrors(await _roleManager.CreateStaticRoles(tenant.Id));

                await CurrentUnitOfWork.SaveChangesAsync(); //To get static role ids

                //grant all permissions to admin role
                var adminRole = _roleManager.Roles.Single(r => r.Name == StaticRoleNames.Tenants.Admin);
                await _roleManager.GrantAllPermissionsAsync(adminRole);

                //Create admin user for the tenant
                var adminUser = User.CreateTenantAdminUser(tenant.Id, input.AdminEmailAddress, User.DefaultPassword);
                CheckErrors(await UserManager.CreateAsync(adminUser));
                await CurrentUnitOfWork.SaveChangesAsync(); //To get admin user's id

                //Assign admin user to role!
                CheckErrors(await UserManager.AddToRoleAsync(adminUser.Id, adminRole.Name));
                await CurrentUnitOfWork.SaveChangesAsync();
            }
        }

    }
}
