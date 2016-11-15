using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MCL.Management.Models
{
    public class sysexceptionModels
    {
        /// <summary>
        /// 异常ID
        /// <summary>
        public string Ex_Id
        {
            get ;
            set ;
        }

        /// <summary>
        /// 异常主题
        /// <summary>
        public string Ex_Title
        {
            get ;
            set ;
        }

        /// <summary>
        /// 异常事件ID
        /// <summary>
        public string Ex_Eventid
        {
            get ;
            set ;
        }

        /// <summary>
        /// 异常发生类名称
        /// <summary>
        public string Ex_Classname
        {
            get ;
            set ;
        }

        /// <summary>
        /// 异常发生方法名称
        /// <summary>
        public string Ex_Method
        {
            get ;
            set ;
        }

        /// <summary>
        /// 异常创建时间
        /// <summary>
        public string Ex_Creattime
        {
            get ;
            set ;
        }

        /// <summary>
        /// 异常操作用户ID
        /// <summary>
        public string Ex_User_Id
        {
            get ;
            set ;
        }

        /// <summary>
        /// 异常
        /// <summary>
        public string Ex_Message
        {
            get ;
            set ;
        }

        /// <summary>
        /// 异常描述
        /// <summary>
        public string Ex_Des
        {
            get ;
            set ;
        }

    }
}
