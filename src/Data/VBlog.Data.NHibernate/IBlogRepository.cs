using Abp.Domain.Repositories;
using System.Collections.Generic;
using VBlog.Data.Model;

namespace VBlog.Data.NHibernate
{
    public interface IBlogRepository : IRepository<ForumPost, int>
    {
        List<ForumPost> GetAllBlog();
    }
}