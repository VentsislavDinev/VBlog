using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VBlog.Data.Model;
using VBlog.Data.ViewModel;

namespace VBlog.Service.Blog
{
    public class ThinkOrderService : ApplicationService, IThinkOrderService
    {
        private IRepository<Think> _forumPostAnswer;

        public ThinkOrderService(IRepository<Think> forumPostAnswer)
        {
            _forumPostAnswer = forumPostAnswer ?? throw new ArgumentNullException(nameof(forumPostAnswer));
        }

        public async Task<ThinkViewModel> GetLast()
        {
            return await this._forumPostAnswer.GetAll()
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new ThinkViewModel
                {
                    Description = x.Description,
                    Title = x.Title,
                })
                .FirstOrDefaultAsync();
        }
    }
}
