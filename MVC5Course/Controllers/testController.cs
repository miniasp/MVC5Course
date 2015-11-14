using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class testController : BaseController
    {
        // GET: test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult testPartial()
        {
            return PartialView();
        }

        public ActionResult ContentIndex()
        {
            return Content("<h1>hello world</h1>", "text/plain");
        }

        public string ContentString()
        {
            return "<h1>hello world</h1>";
        }

        public ActionResult FileTest()
        {
            string filePath = Server.MapPath(@"~/Content/344774.jpg");
            string contentType = "image/jepg";
            return File(filePath, contentType);
        }

        public ActionResult FileTestRename()
        {
            string filePath = Server.MapPath(@"~/Content/344774.jpg");
            string contentType = "image/jepg";
            return File(filePath, contentType,"我自定的檔名.jpg");
        }

    }
}