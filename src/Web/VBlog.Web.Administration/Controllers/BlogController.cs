using System;
using System.IO;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;
using VBlog.Data.ViewModel;
using VBlog.Data.ViewModel.Page;
using VBlog.Service.Blog;
using VEducation.Web.Common.Populator;

namespace VBlog.Web.Administration.Controllers
{
    public class BlogController : BaseController
    {
        private readonly IBlogPostService _manageBlogPostService;
        private const string imagePath = "/Files/uploads";
        private string saveMediumImageLocation;

        private IDropDownListPopulator _populator;
        public BlogController(IBlogPostService manageBlogPostService,IDropDownListPopulator populator)
        {
            _manageBlogPostService = manageBlogPostService ?? throw new ArgumentNullException(nameof(manageBlogPostService));
            _populator = populator ?? throw new ArgumentNullException(nameof(populator));
        }


        // GET: Administration/Blog
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var addTicketViewModel = new BlogPostViewModel
            {
                Categories = this._populator.GetBlogCategories()
            };

            return View(addTicketViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ForumPostViewModel model)
        {

            WebImage file = new WebImage(model.Upload.InputStream);
            string fileExtention = file.ImageFormat;
            string curretnDirectory = Path.GetFullPath(Server.MapPath(imagePath));
            //creating filename to avoid file name conflicts.
            string fileName = Guid.NewGuid().ToString();

            saveMediumImageLocation = curretnDirectory;

            string fileNameWithExtension = fileName + "." + fileExtention;
            //saving file in savedImage folder.
            string saveFile = saveMediumImageLocation + "/" + fileNameWithExtension;
            file.Save(saveFile, fileExtention);
            model.Image = fileNameWithExtension;
            //model.UserId = this.UserProfile.Id;
            model.CreationTime = DateTime.Now;
            await _manageBlogPostService.Create(model);
            return Redirect("/");
        }


        public ActionResult Update()
        {
            return View();
        }


        [HttpPut]
        public async Task<ActionResult> Update(ForumPostViewModel model)
        {
            await _manageBlogPostService.Update(model);
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(ForumPostViewModel model)
        {
            await _manageBlogPostService.Delete(model);
            return View();
        }
    }

}