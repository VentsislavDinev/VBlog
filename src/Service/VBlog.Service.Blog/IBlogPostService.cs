using Abp.Application.Services;
using System.Threading.Tasks;
using VBlog.Data.ViewModel;

namespace VBlog.Service.Blog
{
    public interface IBlogPostService : IApplicationService
    {
        Task Create(ForumPostViewModel model);
        Task Delete(ForumPostViewModel model);
        Task Update(ForumPostViewModel model);
    }
}