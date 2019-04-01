using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBlog.Data.ViewModel.Page
{
    public class HomePageViewModel
    {
        public ThinkViewModel GetForMe { get; set; }
      

        public IEnumerable<ForumPostViewModel> GetBlogPost { get; set; }
        public IEnumerable<ForumPostViewModel> GetLastBlogPost { get; set; }
        public ForumPostViewModel GetSingleBlogPost { get; set; }
       // public IEnumerable<BlogCategoryViewModel> BlogCategoy { get; set; }
        public AboutViewModel About { get; set; }
        public List<ForumPostCategoryViweModel> BlogCategoy { get; set; }
    }
}
