using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartialIndex()
        {
            return PartialView("Index");
        }

        public ActionResult ContentIndex()
        {
            return Content("<h1>Hello world</h1>", "text/plain");
        }

        public string StringIndex()
        {
            return "<h1>Hello world</h1>";
        }

        public ActionResult FileIndex()
        {
            string fileName = Server.MapPath(@"~/Content/test.xlsx");
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            return File(fileName, contentType, "簡易預算表.xlsx" );
        }

        public ActionResult ImageIndex()
        {
            string fileName = Server.MapPath(@"~/Content/344773.jpg");
            string contentType = "image/jpeg";
            return File(fileName, contentType);
        }

        public ActionResult ImageDownload()
        {
            string fileName = Server.MapPath(@"~/Content/344773.jpg");
            string contentType = "image/jpeg";
            return File(fileName, contentType, Path.GetFileName(fileName));
        }

        public ActionResult JsonIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult JsonData()
        {
            db.Configuration.LazyLoadingEnabled = false;

            var data = db.Product.Take(5).ToList();

            return Json(data);
        }

        public ActionResult RedirectToIndex()
        {
            return RedirectToActionPermanent("Index");
        }

    }
}