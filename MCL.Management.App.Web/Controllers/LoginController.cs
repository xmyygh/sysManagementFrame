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

namespace MCL.Management.App.Web.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 默认页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Default()
        {
            return View();
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="autologin">记住密码</param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult CheckLogin(string username, string password)
        {
            LoginCache loginCache = new LoginCache();
            sysloginModels syslogin = loginCache.GetByKey(username);

            #region 登陆验证
            //登录名是否正确
            if (syslogin != null && !string.IsNullOrEmpty(syslogin.Account))
            {
                //密码是否正确
                if (Encrypt.Encode(password) != syslogin.Password)
                {
                    return Content(new AjaxResult { state = ResultType.fail, message = "登录密码错误。" }.ToJson());
                }

                //是否禁用
                if (syslogin.Enabled!=null&&syslogin.Enabled == 0)
                {
                    return Content(new AjaxResult { state = ResultType.fail, message = "登录帐号已禁用，请联系管理员。" }.ToJson());
                }

                UserCache userCache = new UserCache();
                sysuserModels sysuser =  userCache.GetByKey(syslogin.User_Id);

                sysunitBLL unitbll = new sysunitBLL();
                sysunitModels unit = new sysunitModels();
                unit.Unit_Id = sysuser.Unit_Id;
                sysunitModels sysunit = unitbll.SelectByKey(unit);

                sysroleBLL rolebll = new sysroleBLL();
                sysroleModels sysrole = rolebll.SelectByUserID(syslogin.User_Id);

                CurrentUser currrntUser = new CurrentUser();
                currrntUser.UserId = sysuser.User_Id;
                currrntUser.UserCode = sysuser.User_Code;
                currrntUser.UserName = sysuser.User_Name;
                if (string.IsNullOrEmpty(sysuser.User_Imageurl))
                {
                    if (sysuser.User_Sex=="男")
                    {
                        currrntUser.UserImageUrl = "~/Content/UserImg/man.jpg";
                    }
                    else
                    {
                        currrntUser.UserImageUrl = "~/Content/UserImg/woman.jpg";
                    }
                }
                else
                {
                    currrntUser.UserImageUrl = sysuser.User_Imageurl;
                }
                
                currrntUser.Account = syslogin.Account;
                currrntUser.Password = syslogin.Password;
                currrntUser.LoginTime = DateTime.Now;
                currrntUser.LoginIPAddress = WebHelper.Ip;
                currrntUser.UnitID = sysunit == null ? string.Empty : sysunit.Unit_Id;
                currrntUser.UnitName = sysunit == null ? string.Empty : sysunit.Unit_Name;
                currrntUser.RoleID = sysrole == null ? string.Empty : sysrole.Role_Id;
                currrntUser.RoleName = sysrole == null ? string.Empty : sysrole.Role_Name;             
                currrntUser.Token = Encrypt.Encode(Guid.NewGuid().ToString());
                currrntUser.IsSystem = true;

                CurrentUserProvider.Provider.AddCurrent(currrntUser);

            }
            else
            {
                return Content(new AjaxResult { state = ResultType.fail, message = "登录帐号不存在。" }.ToJson());
            }
            #endregion
            //登录日志保存
            sysloginlogBLL logbll = new sysloginlogBLL();
            sysloginlogModels loginlog = new sysloginlogModels();
            loginlog.Account = CurrentUserProvider.Provider.GetCurrentUser().Account ;
            loginlog.User_Id = CurrentUserProvider.Provider.GetCurrentUser().UserId;
            loginlog.User_Name = CurrentUserProvider.Provider.GetCurrentUser().UserName;
            loginlog.Localip = WebHelper.Ip;
            loginlog.Logintime = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
            loginlog.Description = "登录成功";
            logbll.Insert(loginlog);

            //登录日志
            var log = LogFactory.GetLogger(this.GetType().ToString());
            LogMessage logMessage = new LogMessage();
            logMessage.OperationTime = DateTime.Now;
            logMessage.Url = "Login/Index";
            logMessage.Class = "";
            logMessage.Ip = WebHelper.Ip;
            logMessage.Host = WebHelper.Host;
            logMessage.Browser = WebHelper.Browser;
            logMessage.UserName = CurrentUserProvider.Provider.GetCurrentUser().UserName;
            logMessage.Content = "登录成功";

            string strMessage = new LogFormat().InfoFormat(logMessage);
            log.Info(strMessage);

            return Content(new AjaxResult { state = ResultType.success.ToString(), message = "登录成功。" }.ToJson());
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult OutLogin()
        {
            //退出登录日志保存
            sysloginlogBLL logbll = new sysloginlogBLL();
            sysloginlogModels loginlog = new sysloginlogModels();
            loginlog.Account = CurrentUserProvider.Provider.GetCurrentUser().Account;
            loginlog.User_Id = CurrentUserProvider.Provider.GetCurrentUser().UserId;
            loginlog.User_Name = CurrentUserProvider.Provider.GetCurrentUser().UserName;
            loginlog.Localip = WebHelper.Ip;
            loginlog.Outsystime = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
            loginlog.Description = "退出登录";
            logbll.Insert(loginlog);

            //退出登录日志
            var log = LogFactory.GetLogger(this.GetType().ToString());
            LogMessage logMessage = new LogMessage();
            logMessage.OperationTime = DateTime.Now;
            logMessage.Url = "OutLogin";
            logMessage.Class = "";
            logMessage.Ip = WebHelper.Ip;
            logMessage.Host = WebHelper.Host;
            logMessage.Browser = WebHelper.Browser;
            logMessage.UserName = CurrentUserProvider.Provider.GetCurrentUser().UserName;
            logMessage.Content = "退出登录";

            string strMessage = new LogFormat().InfoFormat(logMessage);
            log.Info(strMessage);

            CurrentUserProvider.Provider.EmptyCurrentUser();

            return RedirectToAction("Index", "Login");
        }
	}
}