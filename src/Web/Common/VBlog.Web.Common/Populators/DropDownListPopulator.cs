//namespace Education.Web.Common.Populators
//{
//    using Caching;

//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Web.Mvc;

//    using Education.Data;

//    /// <summary>
//    /// The drop down list populator.
//    /// </summary>
//    public class DropDownListPopulator : IDropDownListPopulator
//    {
//        /// <summary>
//        /// The _blog.
//        /// </summary>
//        private EducationDbContext _blog = new EducationDbContext();

//        /// <summary>
//        /// The _cache.
//        /// </summary>
//        private ICacheService _cache;

//        /// <summary>
//        /// Initializes a new instance of the <see cref="DropDownListPopulator"/> class.
//        /// </summary>
//        /// <param name="cache">
//        /// The cache.
//        /// </param>
//        public DropDownListPopulator(ICacheService cache)
//        {
//            this._cache = cache;
//        }

//        /// <summary>
//        /// The get blog categories.
//        /// </summary>
//        /// <returns>
//        /// The <see cref="IEnumerable"/>.
//        /// </returns>
//        public IEnumerable<SelectListItem> GetBlogCategories()
//        {
//            var categories = this._cache.Get<IEnumerable<SelectListItem>>("categories",
//                () =>
//                {
//                    return this._blog.BlogPostCategories
//                       .Select(c => new SelectListItem
//                       {
//                           Value = c.Id.ToString(),
//                           Text = c.Name
//                       })
//                       .ToList();
//                });

//            return categories;
//        }
//    }
//}