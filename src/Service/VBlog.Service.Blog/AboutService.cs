using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBlog.Data.Model;
using VBlog.Data.ViewModel;

namespace VBlog.Service.Blog
{
    public class AboutService : ApplicationService, IAboutService
    {
        private IRepository<About> _forumPostAnswer;

        public AboutService(IRepository<About> forumPostAnswer)
        {
            _forumPostAnswer = forumPostAnswer ?? throw new ArgumentNullException(nameof(forumPostAnswer));
        }

        public async Task Create(AboutViewModel model)
        {
            var newPost = new About()
            { 
                Description = model.Description,
                Title = model.Title,
                CreatedOn = model.CreatedOn
            };

            await _forumPostAnswer.InsertAsync(newPost);
        }

        public async Task Update(AboutViewModel model)
        {
            var updatePost = new About()
            {
                Description = model.Description,
                Title = model.Title,
                CreatedOn = model.CreatedOn
            };

            await _forumPostAnswer.UpdateAsync(updatePost);
        }

        public async Task Delete(AboutViewModel model)
        {
            var deletePost = new About()
            {
                Description = model.Description,
                Title = model.Title,
                CreatedOn = model.CreatedOn
            };

            await _forumPostAnswer.DeleteAsync(deletePost);
        }
    }
}
