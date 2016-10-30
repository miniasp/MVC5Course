using MVC5Course.ActionFilter;
using MVC5Course.Models;
using MVC5Course.Models.VeiwModesl;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBController : Controller
    {
        // GET: MB
        [LocalDebugOnly]
        public ActionResult Index()
        {
            ViewData["Temp1"] = "Temp1";

            var viewModel = new LoginVeiwModel
            {
                FirstName = "test",
                LastName = "test"
            };

            ViewData["Temp2"] = viewModel;

            ViewBag.Temp3 = viewModel;

            return View();
        }

        public ActionResult MyForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MyForm(LoginVeiwModel c)
        {
            if (ModelState.IsValid)
            {
                TempData["MyFormData"] = c;
                return RedirectToAction("MyFormResult");
            }
            return View();
        }

        public ActionResult MyFormResult()
        {
            return View();
        }

        public ActionResult PeoductList()
        {
            var db = new FabricsEntities();
            var data = db.Product.Take(10).ToList();
            return View(data);
        }

        [HandleError(ExceptionType = typeof(DbEntityValidationException), View = "Error_DbEntityValidationException")]
        public ActionResult BacthUpdateProduct(ProductListVeiwModel[] items)
        {
            /*
            * 預設輸出的欄位名稱格式：item.ProductId
            * 要改成以下欄位格式：
            * items[0].ProductId
            * items[1].ProductId
            */
            var db = new FabricsEntities();
            //if (ModelState.IsValid)
            {
                foreach (var item in items)
                {
                    var product = db.Product.Find(item.ProductId);
                    product.ProductName = item.ProductName;
                    product.Active = item.Active;
                    product.Stock = item.Stock;
                    product.Price = item.Price;
                }

                db.SaveChanges();

                return RedirectToAction("PeoductList");
            }
            return View();
        }

        public ActionResult MyError()
        {
            throw new Exception();
            return View();
        }
    }
}