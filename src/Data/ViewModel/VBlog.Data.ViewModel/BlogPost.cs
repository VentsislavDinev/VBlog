namespace VBlog.Data.ViewModel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using System.Web.Mvc;

    public class ForumPostViewModel
    {
        public int  Id { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        [DataType("tinymce_full")]
        [UIHint("tinymce_full")]
        public string Description { get; set; }
        public string UserId { get; set; }
        public DateTime CreationTime { get; set; }
        public string Image { get; set; }

        public HttpPostedFileBase Upload { get; set; }
        public int CategoryId { get; set; }
    }
}
