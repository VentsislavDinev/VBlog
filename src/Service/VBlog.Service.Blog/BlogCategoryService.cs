using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Threading.Tasks;
using VBlog.Data.Model;
using VBlog.Data.ViewModel;

namespace VBlog.Service.Blog
{
    public class BlogCategoryService : ApplicationService, IBlogCategoryService
    {
        private IRepository<ForumPostCategory> _forumPostCategory;

        public BlogCategoryService(IRepository<ForumPostCategory> forumPostCategory)
        {
            _forumPostCategory = forumPostCategory ?? throw new ArgumentNullException(nameof(forumPostCategory));
        }

        public async Task Create(ForumPostCategoryViweModel model)
        {
            var newCategory = new ForumPostCategory
            {
                Name = model.Name
            };

            await _forumPostCategory.InsertAsync(newCategory);
        }

        public async Task Update(ForumPostCategoryViweModel model)
        {
            var updateCategory = new ForumPostCategory
            {
                Name = model.Name,
            };

            await _forumPostCategory.UpdateAsync(updateCategory);
        }

        public async Task Delete(ForumPostCategoryViweModel model)
        {
            var updateCategory = new ForumPostCategory
            {
                Name = model.Name,
            };

            await _forumPostCategory.DeleteAsync(updateCategory);
        }
    }
}
