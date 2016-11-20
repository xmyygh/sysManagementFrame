using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCL.Management.Models;
using MCL.Management.BLL;
using MCL.Management.App.Cache;
using MCL.Management.Utility;
using MCL.Management.Client.Cache;

namespace MCL.Management.App.Web.Areas.System.Controllers
{
    public class UnitUserInfoController : MvcControllerBase
    {
        //
        // GET: /System/UnitUserInfo/
        public ActionResult Index()
        {
            return View();
        }
	}
}