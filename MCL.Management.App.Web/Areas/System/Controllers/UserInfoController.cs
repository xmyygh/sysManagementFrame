using MCL.Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCL.Management.App.Cache;
using MCL.Management.BLL;
using MCL.Management.Utility;

namespace MCL.Management.App.Web.Areas.System.Controllers
{
    public class UserInfoController : MvcControllerBase
    {
        // GET: System/UserInfo
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
        public ActionResult SubmitFormAdd(sysuserModels postData)
        {
            UserCache login = new UserCache();
            try
            {
                sysuserBLL bll = new sysuserBLL();
                sysuserModels userMod = new sysuserModels();
                userMod.User_Idcard = postData.User_Idcard;
                int count = bll.IsExist(userMod);
                if (count >= 1)
                {
                    return Warning("用户名已存在！");
                }
                login.Insert(postData);
                return Success("新增成功。");
            }
            catch (Exception ex)
            {
                Logger.Error("新增用户错误：" + ex.ToString() + "\r\n");
                throw;
            }
        }

        /// <summary>
        /// 获取登录列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetAllUser()
        {
            sysuserBLL bll = new sysuserBLL();
            List<sysuserModels> userlist = new List<sysuserModels>();
            try
            {
                userlist = bll.selectAll();
                if (userlist == null)
                {
                    userlist = new List<sysuserModels>();
                }
                foreach (sysuserModels user in userlist)
                {

                    user.User_EnabledText = user.User_Enabled == 1 ? "使用" : (user.User_Enabled == 0 ? "删除" : "锁定");
                }
            }
            catch (Exception ex)
            {
                Logger.Error("查询登录用户信息错误：" + ex.ToString() + "\r\n");
                throw;
            }

            return ToJsonResult(userlist);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="postData"></param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetByKeyLogin(sysuserModels postData)
        {
            sysuserBLL bll = new sysuserBLL();
            List<sysuserModels> userlist = new List<sysuserModels>();
            try
            {
                userlist = bll.SelectByWhere(postData, null, null);

                if (userlist == null)
                {
                    userlist = new List<sysuserModels>();
                }
                foreach (sysuserModels user in userlist)
                {
                    user.User_EnabledText = user.User_Enabled == 1 ? "使用" : (user.User_Enabled == 0 ? "删除" : "锁定");
                }
            }
            catch (Exception ex)
            {
                Logger.Error("用户搜索错误：" + ex.ToString() + "\r\n");
                throw;
            }

            return Success("用户搜索成功", userlist);
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="postData"></param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitFormUpdate(sysuserModels postData)
        {
            UserCache user = new UserCache();
            try
            {
                user.UpdateByKey(postData);
                return Success("修改成功。");
            }
            catch (Exception ex)
            {
                Logger.Error("修改用户错误：" + ex.ToString() + "\r\n");
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
        public ActionResult SubmitFormDel(sysuserModels postData)
        {
            UserCache user = new UserCache();
            try
            {
                user.DeleteByKey(postData);
                return Success("删除成功。");
            }
            catch (Exception ex)
            {
                Logger.Error("删除用户信息错误：" + ex.ToString() + "\r\n");
                throw;
            }
        }
    }
}