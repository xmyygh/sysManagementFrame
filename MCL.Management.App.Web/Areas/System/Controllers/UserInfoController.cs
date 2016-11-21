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
            UserCache userCache = new UserCache();
            try
            {
                sysuserBLL bll = new sysuserBLL();
                sysuserModels userMod = new sysuserModels();
                userMod.User_Code = postData.User_Code;
                int count = bll.IsExist(userMod);
                if (count >= 1)
                {
                    return Warning("员工名已存在！");
                }
                postData.User_Createdate = DateTime.Now.ToString("yyyy-MM-dd");
                string id = userCache.Insert(postData);
                postData.User_Id = id;
                return Success("新增成功。", postData.User_Id);
            }
            catch (Exception ex)
            {
                Logger.Error("新增员工错误：" + ex.ToString() + "\r\n");
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

                    user.User_EnabledText = user.User_Enabled == 1 ? "启用" : "禁用";
                }
            }
            catch (Exception ex)
            {
                Logger.Error("查询登录员工信息错误：" + ex.ToString() + "\r\n");
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
                    user.User_EnabledText = user.User_Enabled == 1 ? "启用" : "禁用";
                }
            }
            catch (Exception ex)
            {
                Logger.Error("员工搜索错误：" + ex.ToString() + "\r\n");
                throw;
            }

            return Success("员工搜索成功", userlist);
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
                Logger.Error("修改员工错误：" + ex.ToString() + "\r\n");
                throw;
            }
        }


        public ActionResult LoginUserSet(sysuserModels postData)
        {
            LoginCache login = new LoginCache();
            sysloginModels loginMod = new sysloginModels();
            var tempStr = AppSettingsHelper.GetString("LoginType");
            var tempSel = "";
            tempSel = tempStr == "Code" ? postData.User_Code : postData.User_Name;
            loginMod.Account = tempSel;
            loginMod.Password = "123456";
            loginMod.User_Id = postData.User_Id;
            loginMod.Enabled = 1;
            loginMod.Line = 0;
            sysloginBLL bll = new sysloginBLL();
            sysloginModels temp = new sysloginModels();
            temp.Account = loginMod.Account;
            int count = bll.IsExist(loginMod);
            if (count >= 1)
            {
                return Warning("登录账户已存在！");
            }
            if (!string.IsNullOrEmpty(loginMod.Password))
            {
                loginMod.Password = Encrypt.Encode(loginMod.Password);
            }
            login.Insert(loginMod);
            return Success("设置成功。");
        }

        /// <summary>
        /// 删除 没有完成需要判断已使用的员工不可删除
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
                Logger.Error("删除员工信息错误：" + ex.ToString() + "\r\n");
                throw;
            }
        }
    }
}