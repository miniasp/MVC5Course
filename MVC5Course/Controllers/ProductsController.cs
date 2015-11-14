using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using Omu.ValueInjecter;

namespace MVC5Course.Controllers
{
    public class ProductsController : BaseController
    {
       
        ProductRepository repo = RepositoryHelper.GetProductRepository();
        // GET: Products
        public ActionResult Index(string search)
        {
            var data = repo.Get取得前面10筆範例資料();

            if (!String.IsNullOrEmpty(search))
            {
                data = repo.Get取得依搜尋條件名字的資料(search);
            }

            return View(data);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repo.GetByID(id);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotAcceptable);
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {

                // db.Entry(product).State = EntityState.Modified;
                ((FabricsEntities)repo.UnitOfWork.Context).Entry(product).State = EntityState.Modified;



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
            //var orderLines = db.OrderLine.Where(p => p.ProductId == product.ProductId);
            //var orderLines1 = product.OrderLine.ToList();
            //foreach(var item in orderLines1){
            //    db.OrderLine.Remove(item);
            //}
            // db.OrderLine.RemoveRange(product.OrderLine);
            // db.Product.Remove(product);

            //db.OrderLine.RemoveRange(product.OrderLine);


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


        public ActionResult NewProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewProduct(NewProductVM newProduct)
        {
            //這裡會驗證NewProductVM
            if (ModelState.IsValid)
            {

                var prod = Mapper.Map<Product>(newProduct);

                prod.Stock = 1;
                prod.Active = true;

                repo.Add(prod);

                try
                {
                    repo.UnitOfWork.Commit();//這裡會驗證Product
                }
                catch (DbEntityValidationException ex)
                {
                    //throw ex;
                    var allErrors = new List<string>();

                    foreach (DbEntityValidationResult re in ex.EntityValidationErrors)
                    {
                        foreach (DbValidationError err in re.ValidationErrors)
                        {
                            allErrors.Add(err.ErrorMessage);
                        }
                    }

                    ViewBag.Errors = allErrors;
                }


                return RedirectToAction("Index");
            }

            //驗證NewProductVM
            //驗證Product
            //假設兩者驗證不一，一定要加try catch
            //不然很難找原因為何
            //model 會套用驗證屬性，entity framework 也會看model中的驗證屬性
            //這裡使用value Injecter 使資料直接注射進入
            return View(newProduct);
        }

        /// <summary>
        /// 實做列表中批次改變價錢行為
        /// </summary>
        /// <returns></returns>
        public ActionResult BatchUpdate()
        {
            var data = repo.Get取得前面10筆範例資料();

            foreach (var g in data)
            {
                ((Product)g).Price = 7;
            }

            try
            {
                repo.UnitOfWork.Commit();
            }
            catch (DbEntityValidationException ex)
            {
                //throw ex;
                var allErrors = new List<string>();

                foreach (DbEntityValidationResult re in ex.EntityValidationErrors)
                {
                    foreach (DbValidationError err in re.ValidationErrors)
                    {
                        allErrors.Add(err.ErrorMessage);
                    }
                }

                ViewBag.Errors = allErrors;
            }
            return RedirectToAction("Index");
        }

     

    }
}
