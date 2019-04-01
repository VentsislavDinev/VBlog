//using Abp.Domain.Entities;
//using Abp.EntityFramework;
//using Abp.EntityFramework.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace VEducation.Data.EntityFramework.Repositories
//{
//    /// <summary>
//    /// We declare a base repository class for our application.
//    /// It inherits from <see cref="EfRepositoryBase{TDbContext,TEntity,TPrimaryKey}"/>.
//    /// We can add here common methods for all our repositories.
//    /// </summary>
//    public abstract class SimpleTaskSystemRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<EducationDbContext, TEntity, TPrimaryKey>
//        where TEntity : class, IEntity<TPrimaryKey>
//    {
//        protected SimpleTaskSystemRepositoryBase(IDbContextProvider<EducationDbContext> dbContextProvider)
//            : base(dbContextProvider)
//        {
//        }
//    }

//    /// <summary>
//    /// A shortcut of <see cref="SimpleTaskSystemRepositoryBase{TEntity,TPrimaryKey}"/> for Entities with primary key type <see cref="int"/>.
//    /// </summary>
//    public abstract class SimpleTaskSystemRepositoryBase<TEntity> : SimpleTaskSystemRepositoryBase<TEntity, int>
//        where TEntity : class, IEntity<int>
//    {
//        protected SimpleTaskSystemRepositoryBase(IDbContextProvider<EducationDbContext> dbContextProvider)
//            : base(dbContextProvider)
//        {
//        }
//    }
//}
