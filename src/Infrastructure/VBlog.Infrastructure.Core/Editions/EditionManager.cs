using Abp.Application.Editions;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBlog.Infrastructure.Core.Features;

namespace VBlog.Infrastructure.Core.Editions
{

    /// <summary>
    /// The edition manager.
    /// </summary>
    public class EditionManager : AbpEditionManager
    {
        /// <summary>
        /// The default edition name.
        /// </summary>
        public const string DefaultEditionName = "Standard";

        /// <summary>
        /// Initializes a new instance of the <see cref="EditionManager"/> class.
        /// </summary>
        /// <param name="editionRepository">
        /// The edition repository.
        /// </param>
        /// <param name="featureValueStore">
        /// The feature value store.
        /// </param>
        public EditionManager(
            IRepository<Edition> editionRepository,
            FeatureValueStore featureValueStore)
            : base(
                editionRepository,
                featureValueStore)
        {
        }
    }
}
