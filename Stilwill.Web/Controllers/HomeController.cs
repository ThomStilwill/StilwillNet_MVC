using Stilwill.Web.Code;
using System.Web.Mvc;

namespace Stilwill.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
     
        [AllowAnonymous]
        public ActionResult MenuBar(string submit)
        {
            var model = MenuOrchestrator.GetMenu();
            return PartialView("_MenuBar",model);
        }

        public ActionResult Work()
        {
            return View();
        }

        public ActionResult Play()
        {
            return View();
        }

    }
}