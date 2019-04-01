using Abp.Domain.Entities;

namespace VBlog.Data.Model
{
    
    public class ForumPostVote : Entity
    {
        public int Id { get; set; }
        public bool IsVote { get; set; }
        public string User { get; set; }
        public ForumPost ForumPost { get; set; }
    }
}
