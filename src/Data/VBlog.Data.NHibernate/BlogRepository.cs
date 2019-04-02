using Abp.NHibernate;
using Abp.NHibernate.Repositories;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBlog.Data.Model;

namespace VBlog.Data.NHibernate
{
   public  class BlogRepository : NhRepositoryBase<ForumPost, int>, IBlogRepository
    {
        public BlogRepository(ISessionProvider sessionProvider)
            : base(sessionProvider)
        {
        }

        public List<ForumPost> GetAllBlog()
        {
            var query = GetAll();


            return query
                .OrderByDescending(task => task.CreationTime)
                .ToList();
        }
    }
    }
