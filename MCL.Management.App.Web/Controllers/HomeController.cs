using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCL.Management.Client.Cache;
using MCL.Management.Utility;

namespace MCL.Management.App.Web.Controllers
{
    [HandlerLogin(LoginMode.Enforce)]
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Default()
        {
            return View();
        }
	}
}