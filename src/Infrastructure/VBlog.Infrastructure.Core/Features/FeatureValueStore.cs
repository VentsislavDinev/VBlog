using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.MultiTenancy;
using Abp.Runtime.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBlog.Infrastructure.Core.MultiTenancy;
using VBlog.Infrastructure.Core.Users;

namespace VBlog.Infrastructure.Core.Features
{
    /// <summary>
    /// The feature value store.
    /// </summary>
    public class FeatureValueStore : AbpFeatureValueStore<Tenant, User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureValueStore"/> class.
        /// </summary>
        /// <param name="cacheManager">
        /// The cache manager.
        /// </param>
        /// <param name="tenantFeatureSettingRepository">
        /// The tenant feature setting repository.
        /// </param>
        /// <param name="tenantRepository">
        /// The tenant repository.
        /// </param>
        /// <param name="editionFeatureSettingRepository">
        /// The edition feature setting repository.
        /// </param>
        /// <param name="featureManager">
        /// The feature manager.
        /// </param>
        /// <param name="unitOfWorkManager">
        /// The unit of work manager.
        /// </param>
        public FeatureValueStore(
            ICacheManager cacheManager,
            IRepository<TenantFeatureSetting, long> tenantFeatureSettingRepository,
            IRepository<Tenant> tenantRepository,
            IRepository<EditionFeatureSetting, long> editionFeatureSettingRepository,
            IFeatureManager featureManager,
            IUnitOfWorkManager unitOfWorkManager)
            : base(
                cacheManager,
                tenantFeatureSettingRepository,
                tenantRepository,
                editionFeatureSettingRepository,
                featureManager,
                unitOfWorkManager)
        {
        }
    }
}
