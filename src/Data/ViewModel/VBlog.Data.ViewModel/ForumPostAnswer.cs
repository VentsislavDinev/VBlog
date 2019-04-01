namespace VBlog.Data.ViewModel
{
    using System;

    public class ForumPostAnswerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
        public string UserId { get; set; }
        public int ForumPostsId { get; set; }
    }
}