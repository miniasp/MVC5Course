using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class EFController : Controller
    {
        FabricsEntities db = new FabricsEntities();

        // GET: EF
        public ActionResult Index()
        {
            var data = db.Product.Where(p => p.ProductName.Contains("White"));
            return View(data);
        }

        public ActionResult Edit(int id)
        {
            //var data = db.
            return View();
        }

        public ActionResult Create()
        {

            var product = new Product()
            {
                ProductName = "White",
                Active = true,
                Price = 199,
                Stock = 5
            };

            db.Product.Add(product);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var product = db.Product.Find(id);

            product.isDeleted = true;
            //db.OrderLine.RemoveRange(product.OrderLine);
            //db.Product.Remove(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            var data = db.Product.Find(id);
            data.ProductName += "!";

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var enityErros in ex.EntityValidationErrors)
                {
                    var errorMessage = string.Empty;
                    foreach (var vErroos in enityErros.ValidationErrors)
                    {
                        errorMessage += string.Format("{0} is errors {1}{2}",
                            vErroos.PropertyName,
                            vErroos.ErrorMessage,
                            Environment.NewLine);
                    }
                    throw new DbEntityValidationException(errorMessage);
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var data = db.Product.Find(id);

            return View(data);
        }

        public ActionResult AddPrice()
        {
            //var data = db.Product.Where(p => p.ProductName.Contains("White"));
            //foreach (var item in data)
            //{
            //    if(item.Price.HasValue)
            //    item.Price = item.Price.Value * 1.2m;
            //}

            //db.SaveChanges();
            var sqlParmenter = "%" + "White" + "%";
            db.Database.ExecuteSqlCommand("UPDATE dbo.Product SET Price = Price * 1.2 WHERE ProductName LIKE @p0", sqlParmenter);
            return RedirectToAction("Index");
        }

        public ActionResult ClientContribution()
        {
            var data = db.vw_ClientContribution;
            return View(data);
        }

        public ActionResult ClientContribution2(string search = "%Mary%")
        {

            var data = db.Database.SqlQuery<vw_ClientContribution>(@"
	            SELECT
		             c.ClientId,
		             c.FirstName,
		             c.LastName,
		             (SELECT SUM(o.OrderTotal) 
		              FROM [dbo].[Order] o 
		              WHERE o.ClientId = c.ClientId) as OrderTotal
	            FROM 
		            [dbo].[Client] as c
                WHERE c.FirstName LIKE @p0
            ", search);

            return View(data);
        }

        public ActionResult usp_GetClientContribution_Result(string keyword)
        {
            return View(db.usp_GetClientContribution(keyword));
        }
    }
}