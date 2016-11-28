using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCL.Management.App.Cache;
using MCL.Management.BLL;
using MCL.Management.Models;
using MCL.Management.Utility;

namespace MCL.Management.App.Web.Areas.System.Controllers
{
    public class RoleUserInfoController : MvcControllerBase
    {
        // GET: System/RoleUserInfo
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitFormAdd(string postData)
        {
            sysroleuserBLL bll = new sysroleuserBLL();
            List<sysroleuserModels> list = postData.ToList<sysroleuserModels>();
            try
            {
                if (list.Count > 0)
                {


                    //先删除全部数据
                    bll.DeleteByWhere(null);
                    if (list.Count > 0)
                    {
                        foreach (var item in list)
                        {
                            bll.Insert(item);
                        }
                    }
                    return Success("保存数据成功。", postData);
                }
                else
                {
                    return Error("请选择保存的数据。");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetAllData()
        {
            sysroleuserBLL bll = new sysroleuserBLL();
            List<sysroleuserModels> rolelist = new List<sysroleuserModels>();
            try
            {
                rolelist = bll.selectAll();
                if (rolelist == null)
                {
                    rolelist = new List<sysroleuserModels>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ToJsonResult(rolelist);
        }




    }
}