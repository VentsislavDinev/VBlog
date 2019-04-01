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
    public class BlogCategoryOrder : ApplicationService, IBlogCategoryOrder
    {
        public IRepository<ForumPostCategory> _forumPostCategory;

        public BlogCategoryOrder(IRepository<ForumPostCategory> forumPostCategory)
        {
            _forumPostCategory = forumPostCategory ?? throw new ArgumentNullException(nameof(forumPostCategory));
        }

        public async Task<List<ForumPostCategoryViweModel>> GetAll()
        {
            return await _forumPostCategory.GetAll()
                .Select(x => new ForumPostCategoryViweModel
                {
                     Name = x.Name,
                })
                .ToListAsync();
        }
    }
}
