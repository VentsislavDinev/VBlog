using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using VBlog.Data.ViewModel.Page;
using VBlog.Service.Blog;

namespace VBlog.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IBlogPostOrderService _blogPostOrder;
        private readonly IAboutOrderService _about;
        private IThinkOrderService _thinkOrder;
        private IBlogCategoryOrder _blogCategoryService;

        public HomeController(IBlogPostOrderService blogPostOrder, IAboutOrderService about, IThinkOrderService thinkOrder, IBlogCategoryOrder blogCategoryService)
        {
            _blogPostOrder = blogPostOrder ?? throw new ArgumentNullException(nameof(blogPostOrder));
            _about = about ?? throw new ArgumentNullException(nameof(about));
            _thinkOrder = thinkOrder ?? throw new ArgumentNullException(nameof(thinkOrder));
            _blogCategoryService = blogCategoryService ?? throw new ArgumentNullException(nameof(blogCategoryService));
        }

        public async Task<ActionResult> Index()
        {
            HomePageViewModel newPage = new HomePageViewModel
            {
                GetBlogPost = await _blogPostOrder.GetAll(),
            };

            return PartialView(newPage);
        }

        public async Task<ActionResult> TopSiteBar()
        {
            HomePageViewModel newPage = new HomePageViewModel
            {
                GetForMe = await _thinkOrder.GetLast(),
            };

            return PartialView(newPage);
        }


        public async Task<ActionResult> RightSiteBar()
        {
            HomePageViewModel page = new HomePageViewModel
            {
                GetLastBlogPost = await  _blogPostOrder.GetLastBlogPost()
            };
            return PartialView(page);
        }


        public async Task<ActionResult> About()
        {
            HomePageViewModel page = new HomePageViewModel
            {
               BlogCategoy = await  _blogCategoryService.GetAll(),
                About = await  _about.GetLast(),

            };

            return View(page);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}