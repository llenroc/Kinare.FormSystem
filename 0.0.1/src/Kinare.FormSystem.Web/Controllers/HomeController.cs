using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace Kinare.FormSystem.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : FormSystemControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}