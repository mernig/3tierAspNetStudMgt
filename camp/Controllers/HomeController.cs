using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace camp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page1";

            return View();
        }
        //public ActionResult Subscribe()
        //{
        //    ViewBag.Title = "Subscribe";

        //    return View();
        //}
        //public ActionResult About()
        //{
        //    ViewBag.Title = "About us";

        //    return View();
        //}
        //public ActionResult Student()
        //{
        //    ViewBag.Title = "Student";

        //    return View();
        //}
    }
}
