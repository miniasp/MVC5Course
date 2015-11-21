using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using System.Data.Entity.Validation;
using Omu.ValueInjecter;
using System.Web.UI;

namespace MVC5Course.Controllers
{
    public class ProductsController : BaseController
    {
        ProductRepository repo = RepositoryHelper.GetProductRepository();

        public ActionResult BatchUpdate()
        {
            //db.Database.ExecuteSqlCommand("UPDATE dbo.Product SET Price=5 WHERE ProductId < @p0", 10);

            var data = repo.Get取得前面10筆範例資料();

            foreach (var item in data)
            {
                item.Price = 5;
            }

            try
            {
                repo.UnitOfWork.Commit();
            }
            catch (DbEntityValidationException ex)
            {
                //var allErrors = new List<string>();

                //foreach (DbEntityValidationResult re in ex.EntityValidationErrors)
                //{
                //    foreach (DbValidationError err in re.ValidationErrors)
                //    {
                //        allErrors.Add(err.ErrorMessage);
                //    }
                //}

                //ViewBag.Errors = allErrors;
                throw ex;
            }

            return RedirectToAction("Index");
        }

        //[OutputCache(Location=OutputCacheLocation.Server, Duration=60)]
        // GET: Products
        public ActionResult Index(string search, string ProductName, bool? active = true)
        {
            ViewBag.IsActive = active;


            var pList = from p in repo.All(true)
                        group p by p.ProductName into g
                        select g.Key;

            ViewBag.ProductName = new SelectList(pList);

            //var pList = repo.All();
            //ViewBag.ProductName = new SelectList(pList, "ProductId", "ProductName");


            // var data = db.Product.Where(p => p.ProductId < 10).AsQueryable();
            // var data = repo.All().Where(p => p.ProductId < 10);
            //var data = repo.All(true); 
            var data = repo.Get取得前面10筆範例資料(active);

            if (!String.IsNullOrEmpty(search))
            {
                data = data.Where(p => p.ProductName.Contains(search));
            }

            //if (!String.IsNullOrEmpty(ProductName))
            //{
            //    data = data.Where(p => p.ProductName == ProductName);
            //}

            //var data1 = from p in db.Product
            //            where p.ProductName.Contains("100")
            //            orderby p.ProductName
            //            select p;

            //var data2 = from p in db.Product
            //            where p.ProductName.Contains("100")
            //            orderby p.ProductName
            //            select new NewProductVM
            //            {
            //                ProductName = p.ProductName,
            //                Price = p.Price
            //            };

            return View(data);
        }

        [HandleError(
            ExceptionType = typeof(DbEntityValidationException),
            View = "Error_DbEntityValidationException")
        ]
        [HttpPost]
        public ActionResult Index(int[] ProductId, FormCollection form)
        {
            IList<NewProductVM> data = new List<NewProductVM>();

            TryUpdateModel<IList<NewProductVM>>(data, "data");

            foreach (var item in data)
            {
                var dbItem = repo.GetByID(item.ProductId);

                dbItem.InjectFrom(item);
            }

            if (ProductId != null)
            {
                foreach (var id in ProductId)
                {
                    repo.Delete(repo.GetByID(id));
                }
            }

            repo.UnitOfWork.Commit();

            return RedirectToAction("Index");

            //ModelState.AddModelError("data[0].Price", "ERROR");
            //ModelState.Clear();

            return View(repo.Get取得前面10筆範例資料());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Product.Find(id);
            //Product product = db.Product.Where(p => p.ProductId == id && p.Active == true).FirstOrDefault();
            //Product product = db.Product.FirstOrDefault(p => p.ProductId == id && p.Active == true);


            var product = repo.GetByID(id);

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [ChildActionOnly]
        public ActionResult OrderLines(int id)
        {

            return View(repo.GetByID(id).OrderLine);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                repo.Add(product);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new ArgumentException("Not id input");

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repo.GetByID(id);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotAcceptable);
                //return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[ValidateInput(false)]
        public ActionResult Edit(int? id, FormCollection form)
        // [Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product
        {
            var product = repo.GetByID(id);
            var includeProperties = "ProductId,ProductName,Price,Stock".Split(',');
            if (TryUpdateModel<Product>(product, includeProperties))
            {
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repo.GetByID(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = repo.GetByID(id);

            repo.Delete(product);

            repo.UnitOfWork.Commit();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }

        public string TestInsert()
        {
            var db = new FabricsEntities();

            var product = new Product()
            {
                ProductName = "Entity",
                Price = 99,
                Stock = 10,
                Active = true
            };

            db.Product.Add(product);

            repo.UnitOfWork.Commit();

            return "OK: " + product.ProductId;
        }

        public ActionResult NewProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewProduct(NewProductVM product)
        {
            if (ModelState.IsValid)
            {
                var prod = Mapper.Map<Product>(product);

                //var prod = new Product();
                //prod.ProductName = product.ProductName;
                //prod.Price = product.Price;

                repo.Add(prod);

                try
                {
                    repo.UnitOfWork.Commit();
                }
                catch (DbEntityValidationException ex)
                {
                    var allErrors = new List<string>();

                    foreach (DbEntityValidationResult re in ex.EntityValidationErrors)
                    {
                        foreach (DbValidationError err in re.ValidationErrors)
                        {
                            allErrors.Add(err.ErrorMessage);
                        }
                    }

                    return Content(String.Join("<br>", allErrors.ToArray()));
                    //throw ex;
                }

                return RedirectToAction("Index");
            }

            return View(product);
        }

    }
}
