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
    public class LoginInfoController : MvcControllerBase
    {
        //继承自MvcControllerBase
        //操作窗口必须要把try catch写上
        //HttpGet HttpPost  http请求类型
        //HandlerAjaxOnly  只能进修ajax操作
        //ValidateAntiForgeryToken 防止CSRF攻击
        //yxl a
        #region 视图
        //
        // GET: /System/LoginInfo/
        /// <summary>
        /// 登录注册页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 修改密码页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize]
        public ActionResult UpdatePwd()
        {
            string passwd = CurrentUserProvider.Provider.GetCurrentUser().Password;
            ViewBag.pwd = Encrypt.Decode(passwd);
            return View();
        }
        #endregion

        /// <summary>
        /// 获取登录列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetAllLogin()
        {
            sysloginBLL bll = new sysloginBLL();
            List<sysloginModels> loginlist = new List<sysloginModels>();
            try
            {
                loginlist = bll.selectAll();
                if (loginlist == null)
                {
                    loginlist = new List<sysloginModels>();
                }
                foreach (sysloginModels login in loginlist)
                {
                    login.Password = Encrypt.Decode(login.Password);
                    login.EnabledText = login.Enabled == 1 ? "启用" : "禁用";
                }
            }
            catch (Exception ex)
            {
                Logger.Error("查询登录账号错误：" + ex.ToString() + "\r\n");
                throw;
            }

            return ToJsonResult(loginlist);
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
            sysloginBLL bll = new sysloginBLL();
            List<sysloginModels> loginlist = new List<sysloginModels>();
            try
            {
                if (string.IsNullOrEmpty(postData))
                {
                    loginlist = bll.selectAll();
                }
                else
                {
                    loginlist = bll.selectByName(postData);
                }
                if (loginlist == null)
                {
                    loginlist = new List<sysloginModels>();
                }
                foreach (sysloginModels login in loginlist)
                {
                    login.Password = Encrypt.Decode(login.Password);
                    login.EnabledText = login.Enabled == 1 ? "启用" : "禁用";
                }
            }
            catch (Exception ex)
            {
                Logger.Error("登录账号搜索错误：" + ex.ToString() + "\r\n");
                throw;
            }

            return Success("登录账号搜索成功", loginlist);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="postData"></param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitFormAdd(sysloginModels postData)
        {
            LoginCache login = new LoginCache();
            try
            {
                sysloginBLL bll = new sysloginBLL();
                sysloginModels loginMod = new sysloginModels();
                loginMod.Account = postData.Account;
                int count = bll.IsExist(loginMod);
                if (count >= 1)
                {
                    return Warning("登录账户已存在！");
                }
                if (!string.IsNullOrEmpty(postData.Password))
                {
                    postData.Password = Encrypt.Encode(postData.Password);
                }
                login.Insert(postData);
                return Success("新增成功。");
            }
            catch (Exception ex)
            {
                Logger.Error("新增登录账号错误：" + ex.ToString() + "\r\n");
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
        public ActionResult SubmitFormUpdate(sysloginModels postData)
        {
            LoginCache login = new LoginCache();
            try
            {
                if (!string.IsNullOrEmpty(postData.Password))
                {
                    postData.Password = Encrypt.Encode(postData.Password);
                }

                login.UpdateByKey(postData);
                return Success("修改成功。");
            }
            catch (Exception ex)
            {
                Logger.Error("修改登录账号错误：" + ex.ToString() + "\r\n");
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
        public ActionResult SubmitFormDel(sysloginModels postData)
        {
            LoginCache login = new LoginCache();
            try
            {
                login.DeleteByKey(postData);
                return Success("删除成功。");
            }
            catch (Exception ex)
            {
                Logger.Error("删除登录账号错误：" + ex.ToString() + "\r\n");
                throw;
            }
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitFormUpdatePwd(string Password)
        {
            LoginCache login = new LoginCache();
            try
            {
                sysloginModels postData = new sysloginModels();

                postData.Account = CurrentUserProvider.Provider.GetCurrentUser().Account;
                postData.Password = Encrypt.Encode(Password);
                postData.User_Id = CurrentUserProvider.Provider.GetCurrentUser().UserId;
                postData.Enabled = 1;

                login.UpdateByKey(postData);
                return Success("修改登录密码成功。");
            }
            catch (Exception ex)
            {
                Logger.Error("修改登录密码错误：" + ex.ToString() + "\r\n");
                throw;
            }
        }
    }
}