using System.Collections.Generic;
using System.Web.Mvc;

namespace VBlog.Data.ViewModel.Page
{
    public class BlogPostViewModel
    {
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}