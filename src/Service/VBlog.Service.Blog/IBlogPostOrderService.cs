using Abp.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using VBlog.Data.ViewModel;

namespace VBlog.Service.Blog
{
    public interface IBlogPostOrderService : IApplicationService
    {
        Task<List<ForumPostViewModel>> GetAllByCategory(int id);
        Task<List<ForumPostViewModel>> GetAll();
        Task<ForumPostViewModel> GetSinglePost(int id);
        Task<List<ForumPostViewModel>> GetLastBlogPost();
    }
}