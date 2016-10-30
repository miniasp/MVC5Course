using System;
using System.Web.Mvc;

namespace MVC5Course.ActionFilter
{
    public class LocalDebugOnlyAttribute : ActionFilterAttribute
    {
        private int val;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsLocal)
            {
                filterContext.Result = new RedirectResult("/");
            }
            val = 3;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var a = val;
            //base.OnActionExecuted(filterContext);
        }
    }
}