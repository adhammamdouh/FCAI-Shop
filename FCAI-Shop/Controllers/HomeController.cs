using System.Web.Mvc;
#pragma warning disable 1591
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
