using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MCL.Management.Models
{
    public class sysloginlogModels
    {
        /// <summary>
        /// 
        /// <summary>
        public string Loginlog_Id
        {
            get ;
            set ;
        }

        /// <summary>
        /// 登录名
        /// <summary>
        public string Account
        {
            get ;
            set ;
        }

        /// <summary>
        /// 用户ID
        /// <summary>
        public string User_Id
        {
            get ;
            set ;
        }

        /// <summary>
        /// 用户名
        /// <summary>
        public string User_Name
        {
            get ;
            set ;
        }

        /// <summary>
        /// 登录IP
        /// <summary>
        public string Localip
        {
            get ;
            set ;
        }

        /// <summary>
        /// 登录时间
        /// <summary>
        public string Logintime
        {
            get ;
            set ;
        }

        /// <summary>
        /// 退出时间
        /// <summary>
        public string Outsystime
        {
            get ;
            set ;
        }

        /// <summary>
        /// 描述
        /// <summary>
        public string Description
        {
            get ;
            set ;
        }

    }
}
