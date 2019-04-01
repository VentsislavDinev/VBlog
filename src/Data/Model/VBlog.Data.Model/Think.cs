using Abp.Domain.Entities;
using System;

namespace VBlog.Data.Model
{
    public class Think : Entity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
