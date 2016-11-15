using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCL.Management.App.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult CustomHttpError()
        {
            ViewBag.Message = "有错误";
            //HandleErrorInfo
            //ExceptionContext 

            return View();
        }
        public ActionResult NotFound()
        {
            return View();
        }
	}
}