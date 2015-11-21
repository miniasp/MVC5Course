using MVC5Course.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            ViewBag.IsEnabled = true;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [在多個控制器中共用的ViewBag屬性]
        public ActionResult Test()
        {
            System.Diagnostics.Debug.WriteLine("Test Action");

            throw new Exception("BAD");

            return View();
        }

        public ActionResult ViewTest(bool enable = true)
        {
            ViewBag.IsEnabled = enable;

            int[] data = new int[] { 1, 2, 3, 4, 5 };

            return View(data);
        }

        public ActionResult ViewHelper()
        {
            return View();
        }
    }
}