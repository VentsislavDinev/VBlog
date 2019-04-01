using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using VBlog.Data.ViewModel;
using VBlog.Service.Blog;

namespace VBlog.Web.Administration.Controllers
{
    public class ForMeController : BaseController
    {
        private readonly IThinkService _manageForMeService;

        public ForMeController(IThinkService manageForMeService)
        {
            _manageForMeService = manageForMeService ?? throw new ArgumentNullException(nameof(manageForMeService));
        }

        // GET: Administration/ForMe
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ThinkViewModel model)
        {
            await _manageForMeService.Create(model);
            return View();
        }

        public ActionResult Update()
        {
            return View();
        }


        [HttpPut]
        public async Task<ActionResult> Update(ThinkViewModel model)
        {
            await _manageForMeService.Update(model);
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(ThinkViewModel model)
        {
            await _manageForMeService.Delete(model);
            return View();
        }
    }
}