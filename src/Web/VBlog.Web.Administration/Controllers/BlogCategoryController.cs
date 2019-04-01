using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VBlog.Data.ViewModel;
using VBlog.Service.Blog;

namespace VBlog.Web.Administration.Controllers
{
    public class BlogCategoryController : BaseController
    {

        private readonly IBlogCategoryService _manageBlogCategory;

        public BlogCategoryController(IBlogCategoryService manageBlogCategory)
        {
            _manageBlogCategory = manageBlogCategory ?? throw new ArgumentNullException(nameof(manageBlogCategory));
        }

        // GET: Administration/BlogCategory
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<ActionResult> Create(ForumPostCategoryViweModel model)
        {
            await _manageBlogCategory.Create(model);
            return View();
        }

        public ActionResult Update()
        {
            return View();
        }

        [HttpPut]
        public async Task<ActionResult> Update(ForumPostCategoryViweModel model)
        {
            await _manageBlogCategory.Update(model);
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(ForumPostCategoryViweModel model)
        {
            await _manageBlogCategory.Delete(model);
            return View();
        }

    }
}