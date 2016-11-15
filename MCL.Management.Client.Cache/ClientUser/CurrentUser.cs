using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCL.Management.Client.Cache
{
    public class CurrentUser
    {
        /// <summary>
        /// 用户主键
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserCode { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string UserImageUrl { get; set; }

        /// <summary>
        /// 登陆帐号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 登陆密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }

        /// <summary>
        /// 登录IP地址
        /// </summary>
        public string LoginIPAddress { get; set; }

        /// <summary>
        /// 单位ID
        /// </summary>
        public string UnitID { get; set; }

        /// <summary>
        /// 单位名称
        /// </summary>
        public string UnitName { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public string RoleID { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 登录Token令牌
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 是否系统帐号；拥有所以权限
        /// </summary>
        public bool IsSystem { get; set; }
    }
}
