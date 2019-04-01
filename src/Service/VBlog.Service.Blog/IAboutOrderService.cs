using Abp.Application.Services;
using System.Threading.Tasks;
using VBlog.Data.ViewModel;

namespace VBlog.Service.Blog
{
    public interface IAboutOrderService : IApplicationService
    {
        Task<AboutViewModel> GetLast();
    }
}