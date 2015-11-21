using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBController : BaseController
    {
        public ActionResult Index()
        {
            var data = new NewProductVM()
            {
                Price = 100,
                ProductName = "T-Shirt"
            };


            ViewData["MyName"] = "Will";

            ViewData["MyTitle"] = "ASP.NET MVC 1";
            ViewBag.MyTitle     = "ASP.NET MVC 2";

            ViewBag.Products = db.Product.Take(5).ToList();

            TempData["Msg"] = "test";

            ViewData.Model = data;

            return View();
        }

        public ActionResult SimpleBinding(int p1 = 1, string p2 = "", double p3 = 0)
        {
            return Content(p1 + " " + p2 + " " + p3);
        }

        public ActionResult FormBinding()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FormBinding(Product data)
        {
            return Json(data);
        }

        public ActionResult MultiBinding()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MultiBinding(Product data1, Product data2)
        {
            ViewBag.data1 = data1;
            ViewBag.data2 = data2;

            return View();
        }

    }
}