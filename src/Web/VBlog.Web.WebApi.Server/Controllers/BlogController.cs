using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using VBlog.Data.ViewModel;
using VBlog.Service.Blog;

namespace VBlog.Web.WebApi.Server.Controllers
{
    public class BlogController : ApiController
    {
        private IBlogPostOrderService _blogPostOrder;

        private IBlogPostService _blogPost;

        public BlogController(IBlogPostOrderService blogPostOrder, IBlogPostService blogPost)
        {
            _blogPostOrder = blogPostOrder ?? throw new ArgumentNullException(nameof(blogPostOrder));
            _blogPost = blogPost ?? throw new ArgumentNullException(nameof(blogPost));
        }

        // GET api/values
        public async Task<IEnumerable<ForumPostViewModel>> GetAll()
        {
            return await _blogPostOrder.GetAll(); 
        }

        public async Task<IEnumerable<ForumPostViewModel>> GetByCategory(int id)
        {
            return await _blogPostOrder.GetAllByCategory(id);
        }

        public async Task<ForumPostViewModel> GetById(int id)
        {
            return await _blogPostOrder.GetSinglePost(id);
        }

        public async void Post([FromBody]ForumPostViewModel model)
        {
            await _blogPost.Create(model);
        }

        public async void Put([FromBody]ForumPostViewModel model)
        {
            await _blogPost.Update(model);
        }

        public async void Delete([FromBody]ForumPostViewModel model)
        {
            await _blogPost.Delete(model);
        }
    }
}
