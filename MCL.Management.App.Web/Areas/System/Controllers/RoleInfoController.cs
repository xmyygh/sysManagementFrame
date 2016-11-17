using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCL.Management.App;
using MCL.Management.Utility;
using MCL.Management.Models;
using MCL.Management.BLL;
using MCL.Management.App.Cache;
using MCL.Management.Client.Cache;
using MCL.Management.Utility.Log;

namespace MCL.Management.App.Web.Areas.System.Controllers
{
    public class RoleInfoController : MvcControllerBase
    {
        //
        // GET: /System/RoleInfo/
        public ActionResult Index()
        {
            return View();
        }
	}
}