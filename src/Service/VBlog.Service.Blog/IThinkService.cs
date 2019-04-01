using Abp.Application.Services;
using System.Threading.Tasks;
using VBlog.Data.ViewModel;

namespace VBlog.Service.Blog
{
    public interface IThinkService : IApplicationService
    {
        Task Create(ThinkViewModel model);
        Task Delete(ThinkViewModel model);
        Task Update(ThinkViewModel model);
    }
}