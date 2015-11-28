using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(NoStore = false, Duration = 0)]
        public ActionResult gettime()
        {
            return Content(DateTime.Now.ToString());
        }
    }
}