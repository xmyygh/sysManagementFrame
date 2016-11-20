using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCL.Management.Models;
using MCL.Management.BLL;
using MCL.Management.App.Cache;
using MCL.Management.Utility;

namespace MCL.Management.App.Web.Controllers
{
    public class ItemDataController : Controller
    {
        //
        // GET: /ItemData/
        /// <summary>
        /// 获取正在使用的用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetAllEnabledUser()
        {
            UserCache bll = new UserCache();
            List<sysuserModels> userlist = bll.GetAllList().Where(t => t.User_Enabled == 1).ToList();
            if (userlist == null)
            {
                userlist = new List<sysuserModels>();
            }

            return Content(userlist.ToJson());
        }

        /// <summary>
        /// 根据字典类型返回字典信息
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetByKeyItemData(string keyName)
        {
            DicCachecs bll = new DicCachecs();
            List<sysdicModels> ItemDatalist = bll.GetByKey(keyName).Where(t => t.Sysdic_Enabled == "1").OrderBy(o => o.Sysdic_Order).ToList();
            if (ItemDatalist == null)
            {
                ItemDatalist = new List<sysdicModels>();
            }

            return Content(ItemDatalist.ToJson());
        }

        /// <summary>
        /// 获取科室下拉框数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetUnit()
        {
            sysunitBLL bll = new sysunitBLL();
            sysunitModels model = new sysunitModels();
            model.Unit_Deletemark = 1;
            List<sysunitModels> ItemDatalist = bll.SelectByWhere(model, null, null);
            if (ItemDatalist == null)
            {
                ItemDatalist = new List<sysunitModels>();
            }
            return Content(ItemDatalist.ToJson());
        }
    }
}