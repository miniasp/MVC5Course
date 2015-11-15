using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.ActionFillters;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{


    public class BaseController : Controller
    {
        protected FabricsEntities db = new FabricsEntities();

        public ActionResult Debug()
        {
            return View();
        }

        //專門處理controller沒辦法回應的頁面
        protected override void HandleUnknownAction(string actionName)
        {
            //若是local的情況，回首頁，若不是出現404頁面
            if (Request.IsLocal)
            {
                this.Redirect("/?unknow-action=" + actionName).ExecuteResult(this.ControllerContext);
            }
            else
            {
                base.HandleUnknownAction(actionName);
            }
        }
    }
}