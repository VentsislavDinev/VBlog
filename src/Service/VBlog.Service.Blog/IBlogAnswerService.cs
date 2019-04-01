using Abp.Application.Services;
using System.Threading.Tasks;
using VBlog.Data.ViewModel;

namespace VBlog.Service.Blog
{
    public interface IBlogAnswerService : IApplicationService
    {
        Task Create(ForumPostAnswerViewModel model);
        Task Delete(ForumPostAnswerViewModel model);
        Task Update(ForumPostAnswerViewModel model);
    }
}