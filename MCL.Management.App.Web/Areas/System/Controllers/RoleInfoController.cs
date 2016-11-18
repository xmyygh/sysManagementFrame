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

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetAllRole()
        {
            sysroleBLL bll = new sysroleBLL();
            List<sysroleModels> rolelist = new List<sysroleModels>();
            try
            {
                rolelist = bll.selectAll();
                if (rolelist == null)
                {
                    rolelist = new List<sysroleModels>();
                }                
            }
            catch (Exception ex)
            {
                Logger.Error("查询角色信息错误：" + ex.ToString() + "\r\n");
                throw;
            }

            return ToJsonResult(rolelist);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="postData"></param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetByKeyLogin(string postData)
        {
            sysroleBLL bll = new sysroleBLL();
            List<sysroleModels> rolelist = new List<sysroleModels>();
            try
            {
                if (string.IsNullOrEmpty(postData))
                {
                    rolelist = bll.selectAll();
                }
                else
                {
                    sysroleModels role = new sysroleModels();
                    role.Role_Name = postData;
                    rolelist = bll.SelectByWhere(role, null);
                }
                if (rolelist == null)
                {
                    rolelist = new List<sysroleModels>();
                }
                
            }
            catch (Exception ex)
            {
                Logger.Error("角色信息搜索错误：" + ex.ToString() + "\r\n");
                throw;
            }

            return Success("角色信息搜索成功", rolelist);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="postData"></param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitFormAdd(sysroleModels postData)
        {
            sysroleBLL bll = new sysroleBLL();
            try
            {                
                postData.Role_Createdate = DateTime.Now.ToString("yyyyMMdd");
                string id =bll.Insert(postData);
                if (string.IsNullOrEmpty(id))
                {
                    return Fail("新增失败！");
                }

                postData.Role_Id = id;
                postData.Role_Code = id;

                return Success("新增成功！", postData);
            }
            catch (Exception ex)
            {
                Logger.Error("新增角色信息错误：" + ex.ToString() + "\r\n");
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
        public ActionResult SubmitFormUpdate(sysroleModels postData)
        {
            sysroleBLL bll = new sysroleBLL();
            try
            {
                bll.UpdateByKey(postData);
                return Success("修改成功!");
            }
            catch (Exception ex)
            {
                Logger.Error("修改角色信息错误：" + ex.ToString() + "\r\n");
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
        public ActionResult SubmitFormDel(sysroleModels postData)
        {
            sysroleBLL bll = new sysroleBLL();
            try
            {
                string roleId = postData.Role_Id;
                if (bll.IsExist(roleId)>0)
                {
                    return Warning("角色信息已使用不可删除！");
                }
                bll.DeleteByKey(postData);
                return Success("删除成功!");
            }
            catch (Exception ex)
            {
                Logger.Error("删除角色信息错误：" + ex.ToString() + "\r\n");
                throw;
            }
        }
	}
}