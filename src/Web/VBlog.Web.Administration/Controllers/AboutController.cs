using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using VBlog.Data.ViewModel;
using VBlog.Service.Blog;

namespace VBlog.Web.Administration.Controllers
{
    public class AboutController : BaseController
    {

        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService) 
        {
            _aboutService = aboutService ?? throw new ArgumentNullException(nameof(aboutService));
        }


        // GET: Administration/About
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(AboutViewModel model)
        {
            model.CreatedOn =DateTime.Now;
            await _aboutService.Create(model);
            return View();
        }


        public ActionResult Update()
        {
            return View();
        }


        [HttpPut]
        public async Task<ActionResult> Update(AboutViewModel model)
        {
            model.CreatedOn = DateTime.Now;
            await _aboutService.Update(model);
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(AboutViewModel model)
        {
            model.CreatedOn = DateTime.Now;
            await _aboutService.Delete(model);
            return View();
        }
    }
}