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
    }
}