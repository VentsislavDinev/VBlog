using Abp.Application.Services;
using System.Threading.Tasks;
using VBlog.Data.ViewModel;

namespace VBlog.Service.Blog
{
    public interface IAboutService : IApplicationService
    {
        Task Create(AboutViewModel model);
        Task Delete(AboutViewModel model);
        Task Update(AboutViewModel model);
    }
}