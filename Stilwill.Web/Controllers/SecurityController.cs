using System.Web.Mvc;

namespace Stilwill.Web.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}