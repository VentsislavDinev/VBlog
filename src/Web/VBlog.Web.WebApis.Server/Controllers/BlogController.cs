using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using VBlog.Data.ViewModel;
using VBlog.Service.Blog;

namespace VBlog.Web.WebApis.Server.Controllers
{
    public class BlogController : ApiController
    {
        private IBlogPostOrderService _blogPostOrder;

        public BlogController(IBlogPostOrderService blogPostOrder)
        {
            _blogPostOrder = blogPostOrder ?? throw new ArgumentNullException(nameof(blogPostOrder));
        }

        // GET: Blog/GetPostByCategory
        public async Task<List<ForumPostViewModel>> GetPostByCategory(int id)
        {
            return await _blogPostOrder.GetAllByCategory(id);
        }

        // GET api/blog/GetAll
        public async Task<List<ForumPostViewModel>> GetAll()
        {
            return await _blogPostOrder.GetAll();
        }

        // GET api/blog/5
        public async Task<ForumPostViewModel> GetById(int id) { return await _blogPostOrder.GetSinglePost(id); }

        // GET api/blog/GetLastPost
        public async Task<List<ForumPostViewModel>> GetLastPost() { return await _blogPostOrder.GetLastBlogPost(); }

    }
}