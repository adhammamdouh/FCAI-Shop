using System.Web.Mvc;

namespace FCAI_Shop.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return RedirectToAction("Index","Help");
        }
    }
}
