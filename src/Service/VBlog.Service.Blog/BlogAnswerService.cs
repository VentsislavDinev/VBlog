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
    public class BlogAnswerService : ApplicationService,  IBlogAnswerService
    {
        private IRepository<ForumPostAnswer> _forumPostAnswer;

        public BlogAnswerService(IRepository<ForumPostAnswer> forumPostAnswer)
        {
            _forumPostAnswer = forumPostAnswer ?? throw new ArgumentNullException(nameof(forumPostAnswer));
        }

        public async Task Create(ForumPostAnswerViewModel model)
        {
            var newPost = new ForumPostAnswer
            {
                CreationTime = model.CreationTime,
                ForumPostsId = model.ForumPostsId,
                Name = model.Name
            };

           await  _forumPostAnswer.InsertAsync(newPost);
        }

        public async Task Update(ForumPostAnswerViewModel model)
        {
            var updatePost = new ForumPostAnswer
            {
                Name = model.Name,
                CreationTime = model.CreationTime,
                ForumPostsId = model.ForumPostsId,
            };

            await _forumPostAnswer.UpdateAsync(updatePost);
        }

        public async Task Delete(ForumPostAnswerViewModel model)
        {
            var updatePost = new ForumPostAnswer
            {
                Name = model.Name,
                CreationTime = model.CreationTime,
                ForumPostsId = model.ForumPostsId,
            };

            await _forumPostAnswer.DeleteAsync(updatePost);
        }
    }
}
