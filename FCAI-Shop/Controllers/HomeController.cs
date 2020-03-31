using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FCAI_Shop.DbContext;
using FCAI_Shop.Models;

namespace FCAI_Shop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return RedirectToAction("Index","Help");
        }
    }
}
