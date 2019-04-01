using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VBlog.Data.Model;
using VBlog.Data.ViewModel;

namespace VBlog.Service.Blog
{
    public class BlogPostOrderService : ApplicationService, IBlogPostOrderService
    {
        private IRepository<ForumPost> _forumPost;

        public BlogPostOrderService(IRepository<ForumPost> forumPost)
        {
            _forumPost = forumPost ?? throw new ArgumentNullException(nameof(forumPost));
        }

        public async Task<ForumPostViewModel> GetSinglePost(int id)
        {
            return await _forumPost.GetAll().Where(x => x.Id == id).Select(x => new ForumPostViewModel()
            {
                Description = x.Description,
                CreationTime = x.CreationTime,
                Title = x.Title,
                Image = x.Image,
                UserId = x.UserId,
            }).SingleOrDefaultAsync();
        }

        public async Task<List<ForumPostViewModel>> GetAllByCategory(int id)
        {
            return await _forumPost.GetAll().Where(x => x.ForumPostCategoryId == id).Select(x => new ForumPostViewModel()
            {
                Description = x.Description,
                CreationTime = x.CreationTime,
                Title = x.Title,
                Image = x.Image,
                UserId = x.UserId,
            }).ToListAsync();
        }


        public async Task<List<ForumPostViewModel>> GetLastBlogPost()
        {
            return await _forumPost.GetAll()
                .OrderByDescending(x=>x.CreationTime)
                .Take(5).Select(x => new ForumPostViewModel()
            {
                Description = x.Description,
                CreationTime = x.CreationTime,
                Title = x.Title,
                Image = x.Image,
                UserId = x.UserId,
            }).ToListAsync();
        }


        public async Task<List<ForumPostViewModel>> GetAllByCategoryId(string name)
        {
            return await _forumPost.GetAll()
                .Where(x => x.ForumPostCategory.Name == name)
                .OrderBy(x => x.CreationTime)
                .Select(x => new ForumPostViewModel
                {
                    CategoryId = x.ForumPostCategoryId,
                    CreationTime = x.CreationTime,
                    Title = x.Title,
                    Image = x.Image,
                    UserId = x.UserId,
                })
           .ToListAsync();
        }

        public async Task<List<ForumPostViewModel>> GetAll()
        {
            return await _forumPost.GetAll().OrderBy(x => x.CreationTime).Select(x => new ForumPostViewModel
            {
                CategoryId = x.ForumPostCategoryId,
                CreationTime = x.CreationTime,
                Title = x.Title,
                Image = x.Image,
                UserId = x.UserId,
            })
            .ToListAsync();
        }
    }
}
