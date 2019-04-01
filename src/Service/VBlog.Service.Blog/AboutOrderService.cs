using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBlog.Data.Model;
using VBlog.Data.ViewModel;

namespace VBlog.Service.Blog
{
    public class AboutOrderService : ApplicationService, IAboutOrderService
    {
        private IRepository<About> _forumPostAnswer;

        public AboutOrderService(IRepository<About> forumPostAnswer)
        {
            _forumPostAnswer = forumPostAnswer ?? throw new ArgumentNullException(nameof(forumPostAnswer));
        }

        public async Task<AboutViewModel> GetLast()
        {
            return await this._forumPostAnswer.GetAll()
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new AboutViewModel
                {
                     Description = x.Description,
                     Title = x.Title,
                })
                .FirstOrDefaultAsync();
        }
    }
}
