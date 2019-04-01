using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBlog.Infrastructure.Core.Editions;
using VBlog.Infrastructure.Core.Users;

namespace VBlog.Infrastructure.Core.MultiTenancy
{
    /// <summary>
    /// The tenant manager.
    /// </summary>
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TenantManager"/> class.
        /// </summary>
        /// <param name="tenantRepository">
        /// The tenant repository.
        /// </param>
        /// <param name="tenantFeatureRepository">
        /// The tenant feature repository.
        /// </param>
        /// <param name="editionManager">
        /// The edition manager.
        /// </param>
        /// <param name="featureValueStore">
        /// The feature value store.
        /// </param>
        public TenantManager(
            IRepository<Tenant> tenantRepository,
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository,
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) : base(
            tenantRepository,
            tenantFeatureRepository,
            editionManager,
            featureValueStore)
        {
        }
    }
}
