
using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using VBlog.Data.Model;
using VBlog.Data.ViewModel;

namespace VBlog.Service.Blog
{
   public class BlogPostService : ApplicationService, IBlogPostService
    {
        private IRepository<ForumPost> _forumPost;

        public BlogPostService(IRepository<ForumPost> forumPost)
        {
            _forumPost = forumPost ?? throw new ArgumentNullException(nameof(forumPost));
        }

        public async Task Create(ForumPostViewModel model)
        {
            var newPost = new ForumPost()
            {
                CreationTime = model.CreationTime,
                Description = model.Description,
                Title = model.Title,
                Image = model.Image,

            };

            await _forumPost.InsertAsync(newPost);
        }

        public async Task Update(ForumPostViewModel model)
        {
            var updatePost = new ForumPost()
            {
                 CreationTime = model.CreationTime,
                 Description = model.Description,
                  Image = model.Image,
                   Title = model.Title,
                   UserId = model.UserId
            };

            await _forumPost.UpdateAsync(updatePost);
        }

        public async Task Delete(ForumPostViewModel model)
        {
            var deletePost = new ForumPost()
            {
                 CreationTime = model.CreationTime,
                 Description  = model.Description,
                  Image = model.Description,
                  Title = model.Title,
                   UserId = model.Title,
            };

            await _forumPost.DeleteAsync(deletePost);
        }
    }
}
