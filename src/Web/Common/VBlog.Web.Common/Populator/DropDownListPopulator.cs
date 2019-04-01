//using Abp.Application.Services;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web.Mvc;
//using VBlog.Data.EntityFramework;

//namespace VBlog.Web.Common.Populator
//{
//    public class DropDownListPopulator : ApplicationService, IDropDownListPopulator
//    {
//        private VBlogDbContext _blog;
       
//        public VBlogDbContext Blog { get => _blog; set => _blog = value; }

//        public DropDownListPopulator(VBlogDbContext data)
//        {
//            Blog = data ?? throw new System.ArgumentNullException(nameof(data));
//        }

//        public IEnumerable<SelectListItem> GetBlogCategories()
//        {

//            return Blog.BlogPostCategories
//               .Select(c => new SelectListItem
//               {
//                   Value = c.Id.ToString(),
//                   Text = c.Name
//               })
//               .ToList();
//        }

//        public IEnumerable<SelectListItem> GetCoursesCategories()
//        {

//            return Blog.CoursesCategories
//               .Select(c => new SelectListItem
//               {
//                   Value = c.Id.ToString(),
//                   Text = c.Name
//               })
//               .ToList();

//        }
//    }
//}
