using Abp.Application.Services;
using System.Threading.Tasks;
using VBlog.Data.ViewModel;

namespace VBlog.Service.Blog
{
    public interface IBlogCategoryService : IApplicationService
    {
        Task Create(ForumPostCategoryViweModel model);
        Task Delete(ForumPostCategoryViweModel model);
        Task Update(ForumPostCategoryViweModel model);
    }
}