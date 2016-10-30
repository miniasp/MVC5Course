using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : Controller
    {
        private FabricsEntities db = new FabricsEntities();

        // GET: AR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FileTest()
        {
            var filePath = Server.MapPath("~/Content/unnamed.png");

            return File(filePath, "image/png", "test1.png");
        }

        public ActionResult FileTest1()
        {
            var filePath = Server.MapPath("~/Content/unnamed.png");

            return File(filePath, "image/png");
        }

        public ActionResult JsonTest()
        {
            db.Configuration.LazyLoadingEnabled = false;
            var data = db.Product.Take(10).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}