using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class OrdersController : Controller
    {
        private FabricsEntities db = new FabricsEntities();

        // GET: Orders
        public ActionResult Index(int? clinetId)
        {
            IQueryable<Order> order = null;

            if (clinetId != null)
            {
                order = db.Order.Include(o => o.Client).Where(o => o.ClientId == clinetId);
            } else
            {
                order = db.Order.Include(o => o.Client);
            }
            
            return View(order.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
