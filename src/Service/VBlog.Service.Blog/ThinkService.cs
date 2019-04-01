using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Threading.Tasks;
using VBlog.Data.Model;
using VBlog.Data.ViewModel;

namespace VBlog.Service.Blog
{
    public class ThinkService : ApplicationService, IThinkService
    {
        private IRepository<Think> _forumPostAnswer;

        public ThinkService(IRepository<Think> forumPostAnswer)
        {
            _forumPostAnswer = forumPostAnswer ?? throw new ArgumentNullException(nameof(forumPostAnswer));
        }

        public async Task Create(ThinkViewModel model)
        {
            var newPost = new Think()
            {
                Description = model.Description,
                Title = model.Title,
                CreatedOn = model.CreatedOn
            };

            await _forumPostAnswer.InsertAsync(newPost);
        }

        public async Task Update(ThinkViewModel model)
        {
            var updatePost = new Think()
            {
                Description = model.Description,
                Title = model.Title,
                CreatedOn = model.CreatedOn
            };

            await _forumPostAnswer.UpdateAsync(updatePost);
        }

        public async Task Delete(ThinkViewModel model)
        {
            var deletePost = new Think()
            {
                Description = model.Description,
                Title = model.Title,
                CreatedOn = model.CreatedOn
            };

            await _forumPostAnswer.DeleteAsync(deletePost);
        }
    }
}
