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
    public class BlogPostOrderCategory : ApplicationService, IBlogPostOrderCategory
    {
        private IRepository<ForumPostCategory> _blogPostCategory;

        public BlogPostOrderCategory(IRepository<ForumPostCategory> blogPostCategory)
        {
            _blogPostCategory = blogPostCategory ?? throw new ArgumentNullException(nameof(blogPostCategory));
        }

        public async Task<List<ForumPostCategoryViweModel>> GetAll()
        {
            return await _blogPostCategory.GetAll().Select(x => new ForumPostCategoryViweModel()
            {
                Name = x.Name,
            })
            .ToListAsync();
        }
    }
}
