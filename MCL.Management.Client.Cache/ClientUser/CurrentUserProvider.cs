using MCL.Management.Cache;
using MCL.Management.Utility;
using System;
using System.Collections.Generic;

namespace MCL.Management.Client.Cache
{
    public class CurrentUserProvider:CurrentUserIProvider
    {
        #region 静态实例

        /// <summary>
        /// 当前提供者
        /// </summary>
        public static CurrentUserIProvider Provider
        {
            get { return new CurrentUserProvider(); }
        }
        /// <summary>
        /// 给app调用
        /// </summary>
        public static string AppUserId
        {
            set;
            get;
        }
        #endregion

        /// <summary>
        /// Session、Cookie秘钥
        /// </summary>
        /// 
        private string LoginUserKey = "macl_20161025_v1";

        /// <summary>
        /// 登陆提供者模式:Session、Cookie 
        /// </summary>
        private string LoginProvider = AppSettingsHelper.GetString("LoginProvider");
        
        /// <summary>
        /// 写入登录信息
        /// </summary>
        /// <param name="user">当前登陆用户信息</param>
        public void AddCurrent(CurrentUser user)
        {
            try
            {
                if (LoginProvider == "Cookie")
                {
                    WebHelper.WriteCookie(LoginUserKey, Encrypt.Encode(user.ToJson()));
                }
                else
                {
                    WebHelper.WriteSession(LoginUserKey, Encrypt.Encode(user.ToJson()));
                }
                CacheFactory.Cache().WriteCache(user.Token, user.UserId, user.LoginTime.AddHours(12));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 当前操作用户
        /// </summary>
        /// <returns></returns>
        public CurrentUser GetCurrentUser()
        {
            try
            {
                CurrentUser user = new CurrentUser();
                if (LoginProvider == "Cookie")
                {
                    user = Encrypt.Decode(WebHelper.GetCookie(LoginUserKey).ToString()).ToObject<CurrentUser>();
                }
                else if (LoginProvider == "AppClient")
                {
                    user = CacheFactory.Cache().GetCache<CurrentUser>(AppUserId);
                }
                else
                {
                    user = Encrypt.Decode(WebHelper.GetSession(LoginUserKey).ToString()).ToObject<CurrentUser>();
                }
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 删除登录信息
        /// </summary>
        public void EmptyCurrentUser()
        {
            if (LoginProvider == "Cookie")
            {
                WebHelper.RemoveCookie(LoginUserKey.Trim());
            }
            else
            {
                WebHelper.RemoveSession(LoginUserKey.Trim());
            }
        }

        /// <summary>
        /// 是否过期
        /// </summary>
        /// <returns></returns>
        public bool IsOverdue()
        {
            try
            {
                object str = "";
                if (LoginProvider == "Cookie")
                {
                    str = WebHelper.GetCookie(LoginUserKey);
                }
                else
                {
                    str = WebHelper.GetSession(LoginUserKey);
                }
                if (str != null && str.ToString() != "")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return true;
            }
        }

        /// <summary>
        /// 是否已登录
        /// </summary>
        /// <returns></returns>
        public int IsOnLine()
        {
            CurrentUser user = new CurrentUser();
            if (LoginProvider == "Cookie")
            {
                user = Encrypt.Decode(WebHelper.GetCookie(LoginUserKey).ToString()).ToObject<CurrentUser>();
            }
            else
            {
                user = Encrypt.Decode(WebHelper.GetSession(LoginUserKey).ToString()).ToObject<CurrentUser>();
            }

            object token = CacheFactory.Cache().GetCache<string>(user.UserId);
            if (token == null)
            {
                return -1;//过期
            }
            if (user.Token == token.ToString())
            {
                return 1;//正常
            }
            else
            {
                return 0;//已登录
            }
        }

        /// <summary>
        /// 允许重复登录(单点登录与多点登陆)
        /// </summary>
        /// <returns></returns>
        public bool CheckIsOnLine()
        {
            return AppSettingsHelper.GetBoolValue("CheckOnLine");
        }
    }
}
