namespace VBlog.Data.Model
{
    using Abp.Domain.Entities;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ForumPostCategory : Entity
    {
        private ICollection<ForumPostSubCategory> forumPostSubCategory;

        /// <summary>
        /// The _blog post.
        /// </summary>
        private ICollection<ForumPost> _blogPost;
        public ForumPostCategory()
        {
            this.forumPostSubCategory = new HashSet<ForumPostSubCategory>();
            this._blogPost = new HashSet<ForumPost>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "полето е задължително")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "полето  трябва да е между 3 и 200 символа")]

        public string Name { get; set; }
        public int ForumPostId { get; set; }
        public virtual ICollection<ForumPost> BlogPost
        {
            get
            {
                return this._blogPost;
            }
            set
            {
                this._blogPost = value;
            }
        }
        public int ForumPostSubCategoryId { get; set; }
        public virtual ICollection<ForumPostSubCategory> ForumPostSubCategory
        {
            get
            {
                return this.forumPostSubCategory;
            }
            set
            {
                this.forumPostSubCategory = value;
            }
        }
    }
}