using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VBlog.Data.ViewModel.Page;
using VBlog.Service.Blog;

namespace VBlog.Web.Controllers
{
    public class BlogsController : BaseController
    {
        private readonly IBlogPostOrderService _blogPostOrder;
        private readonly IAboutOrderService _about;
        private IThinkOrderService _thinkOrder;
        private IBlogCategoryOrder _blogCategoryService;

        public BlogsController(IBlogPostOrderService blogPostOrder, IAboutOrderService about, IThinkOrderService thinkOrder, IBlogCategoryOrder blogCategoryService)
        {
            _blogPostOrder = blogPostOrder ?? throw new ArgumentNullException(nameof(blogPostOrder));
            _about = about ?? throw new ArgumentNullException(nameof(about));
            _thinkOrder = thinkOrder ?? throw new ArgumentNullException(nameof(thinkOrder));
            _blogCategoryService = blogCategoryService ?? throw new ArgumentNullException(nameof(blogCategoryService));
        }

        // GET: Blog
        public async Task<ActionResult> Index(int id)
        {
            HomePageViewModel page = new HomePageViewModel
            {
                BlogCategoy = await _blogCategoryService.GetAll(),
                GetBlogPost = await _blogPostOrder.GetAllByCategory(id)
            };
            return View(page);
        }



        public async Task<ActionResult> TopSiteBar()
        {
            HomePageViewModel page = new HomePageViewModel
            {
                GetForMe = await  _thinkOrder.GetLast()
            };
            return PartialView(page);
        }


        public async Task<ActionResult> GetSingle(int id)
        {
            HomePageViewModel page = new HomePageViewModel
            {
                BlogCategoy = await _blogCategoryService.GetAll(),
                GetSingleBlogPost = await _blogPostOrder.GetSinglePost(id)
            };
            return View(page);
        }



        public async Task<ActionResult> RightSiteBar()
        {
            HomePageViewModel page = new HomePageViewModel
            {
                GetLastBlogPost = await  _blogPostOrder.GetLastBlogPost()
            };
            return PartialView(page);
        }

    }
}