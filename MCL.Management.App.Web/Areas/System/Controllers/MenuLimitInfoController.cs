using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCL.Management.BLL;
using MCL.Management.Models;

namespace MCL.Management.App.Web.Areas.System.Controllers
{
    public class MenuLimitInfoController : MvcControllerBase
    {
        // GET: System/MenuLimitInfo
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取登录列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetAllData()
        {
            sysmenuBLL bll = new sysmenuBLL();
            List<sysmenuModels> menulist = new List<sysmenuModels>();
            try
            {
                sysmenuModels model = new sysmenuModels();
                //yxl 暂时此种处理
              //  model = "0";
                menulist = bll.SelectByWhere(model, null, null);
                if (menulist == null)
                {
                    menulist = new List<sysmenuModels>();
                }
                //foreach (sysmenuModels unit in menulist)
                //{

                //    unit.Unit_DeletemarkText = unit.Unit_Deletemark == 1 ? "启用" : "禁用";
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ToJsonResult(menulist);
        }
    }
}