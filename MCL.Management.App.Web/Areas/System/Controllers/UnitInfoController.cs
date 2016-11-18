using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCL.Management.App.Cache;
using MCL.Management.BLL;
using MCL.Management.Models;

namespace MCL.Management.App.Web.Areas.System.Controllers
{
    public class UnitInfoController : MvcControllerBase
    {
        // GET: System/UnitInfo
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="postData"></param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitFormAdd(sysunitModels postData)
        {
            try
            {
                sysunitBLL bll = new sysunitBLL();
                int count = bll.IsExist(postData);
                if (count >= 1)
                {
                    return Warning("科室编号已存在！");
                }
                postData.Unit_Createdate = DateTime.Now.ToShortDateString();
                postData.Unit_Id = SQID.GetID();
                bll.Insert(postData);
                return Success("新增成功。", postData.Unit_Id);
            }
            catch (Exception ex)
            {
                Logger.Error("新增科室错误：" + ex.ToString() + "\r\n");
                throw;
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="postData"></param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitFormUpdate(sysunitModels postData)
        {
            sysunitBLL unit = new sysunitBLL();
            try
            {
                unit.UpdateByKey(postData);
                return Success("修改成功。");
            }
            catch (Exception ex)
            {
                Logger.Error("修改科室错误：" + ex.ToString() + "\r\n");
                throw;
            }
        }

        /// <summary>
        /// 删除 没有完成需要判断已使用的用户不可删除
        /// </summary>
        /// <param name="postData"></param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitFormDel(sysunitModels postData)
        {
            sysunitBLL unit = new sysunitBLL();
            try
            {
                unit.DeleteByKey(postData);
                return Success("删除成功。");
            }
            catch (Exception ex)
            {
                Logger.Error("删除科室信息错误：" + ex.ToString() + "\r\n");
                throw;
            }
        }

        /// <summary>
        /// 获取登录列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetAllData()
        {
            sysunitBLL bll = new sysunitBLL();
            List<sysunitModels> unitlist = new List<sysunitModels>();
            try
            {
                sysunitModels model=new sysunitModels();
                //yxl 暂时此种处理
                model.Unit_Parentid = "0";
                unitlist = bll.SelectByWhere(model, null, null);
                if (unitlist == null)
                {
                    unitlist = new List<sysunitModels>();
                }
                foreach (sysunitModels unit in unitlist)
                {

                    unit.Unit_DeletemarkText = unit.Unit_Deletemark == 1 ? "启用" : "禁用";
                }
            }
            catch (Exception ex)
            {
                Logger.Error("查询科室信息错误：" + ex.ToString() + "\r\n");
                throw;
            }

            return ToJsonResult(unitlist);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="postData"></param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetByKeyData(sysunitModels postData)
        {
            sysunitBLL bll = new sysunitBLL();
            List<sysunitModels> unitlist = new List<sysunitModels>();
            try
            {
                unitlist = bll.SelectByWhere(postData, null, null);

                if (unitlist == null)
                {
                    unitlist = new List<sysunitModels>();
                }
                foreach (sysunitModels unit in unitlist)
                {
                    unit.Unit_DeletemarkText = unit.Unit_Deletemark == 1 ? "启用" : "禁用";
                }
            }
            catch (Exception ex)
            {
                Logger.Error("数据搜索错误：" + ex.ToString() + "\r\n");
                throw;
            }

            return Success("数据搜索成功", unitlist);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="postData"></param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetByCodeData(sysunitModels postData)
        {
            sysunitBLL bll = new sysunitBLL();
            List<sysunitModels> unitlist = new List<sysunitModels>();
            try
            {
                unitlist = bll.SelectByWhere(postData, null, null);

                if (unitlist == null)
                {
                    unitlist = new List<sysunitModels>();
                }
                foreach (sysunitModels unit in unitlist)
                {
                    unit.Unit_DeletemarkText = unit.Unit_Deletemark == 1 ? "启用" : "禁用";
                }
            }
            catch (Exception ex)
            {
                Logger.Error("数据搜索错误：" + ex.ToString() + "\r\n");
                throw;
            }

            return Success("数据搜索成功", unitlist);
        }


    }
}