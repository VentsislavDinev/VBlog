using Abp.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using VBlog.Data.ViewModel;

namespace VBlog.Service.Blog
{
    public interface IBlogPostOrderCategory : IApplicationService
    {
        Task<List<ForumPostCategoryViweModel>> GetAll();
    }
}