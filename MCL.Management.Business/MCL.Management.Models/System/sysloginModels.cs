using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MCL.Management.Models
{
    public class sysloginModels
    {
        /// <summary>
        /// 登录名
        /// <summary>
        public string Account
        {
            get ;
            set ;
        }

        /// <summary>
        /// 登录密码
        /// <summary>
        public string Password
        {
            get ;
            set ;
        }

        /// <summary>
        /// 关联SYSUSER表 USER_ID
        /// <summary>
        public string User_Id
        {
            get ;
            set ;
        }
        /// <summary>
        /// 关联SYSUSER表 USER_ID
        /// <summary>
        public string User_Name
        {
            get;
            set;
        }
        /// <summary>
        /// 是否有效 0禁止 1启动
        /// <summary>
        public int? Enabled
        {
            get ;
            set ;
        }

        public string EnabledText
        {
            get;
            set;
        }
        /// <summary>
        /// 是否在线 0不在线 1在线
        /// <summary>
        public int? Line
        {
            get ;
            set ;
        }

    }
}
