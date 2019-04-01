//using Abp.Domain.Repositories;
//using VBlog.Data.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace VBlog.Data.EntityFramework.Repositories
//{
//    /// <summary>
//    /// Defines a repository to perform database operations for <see cref="Task"/> Entities.
//    /// 
//    /// Extends <see cref="IRepository{TEntity, TPrimaryKey}"/> to inherit base repository functionality. 
//    /// </summary>
//    public interface ITaskRepository : IRepository<Courses>
//    {
//        /// <summary>
//        /// Gets all tasks with <see cref="Task.AssignedPerson"/> is retrived (Include for EntityFramework, Fetch for NHibernate)
//        /// filtered by given conditions.
//        /// </summary>
//        /// <param name="assignedPersonId">Optional assigned person filter. If it's null, not filtered.</param>
//        /// <param name="state">Optional state filter. If it's null, not filtered.</param>
//        /// <returns>List of found tasks</returns>
//        List<Courses> GetAllWithPeople(int? assignedPersonId);
//    }
//}
