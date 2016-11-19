using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MCL.Management.Models
{
    public class sysuserModels
    {
        /// <summary>
        /// 
        /// <summary>
        public string User_Id
        {
            get ;
            set ;
        }

        /// <summary>
        /// 编号,工号
        /// <summary>
        public string User_Code
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
        /// 用户图片URL
        /// <summary>
        public string User_Imageurl
        {
            get ;
            set ;
        }

        /// <summary>
        /// 性别 M男 W女
        /// <summary>
        public string User_Sex
        {
            get ;
            set ;
        }
        /// <summary>
        /// 性别 M男 W女
        /// <summary>
        public string User_SexText
        {
            get;
            set;
        }
        /// <summary>
        /// 生日
        /// <summary>
        public string Usr_Birthday
        {
            get ;
            set ;
        }

        /// <summary>
        /// 年龄
        /// <summary>
        public int? User_Age
        {
            get ;
            set ;
        }

        /// <summary>
        /// 身份证号码
        /// <summary>
        public string User_Idcard
        {
            get ;
            set ;
        }

        /// <summary>
        /// 银行号码
        /// <summary>
        public string User_Bankcode
        {
            get ;
            set ;
        }

        /// <summary>
        /// 
        /// <summary>
        public string User_Email
        {
            get ;
            set ;
        }

        /// <summary>
        /// 手机号
        /// <summary>
        public string User_Mobile
        {
            get ;
            set ;
        }

        /// <summary>
        /// QQ号码
        /// <summary>
        public string User_Oicq
        {
            get ;
            set ;
        }

        /// <summary>
        /// 毕业学校
        /// <summary>
        public string User_School
        {
            get ;
            set ;
        }

        /// <summary>
        /// 有效标识 0禁用 1启用
        /// <summary>
        public int? User_Enabled
        {
            get ;
            set ;
        }
        public string User_EnabledText
        {
            get ;
            set ;
        }
        /// <summary>
        /// 描述
        /// <summary>
        public string User_Description
        {
            get ;
            set ;
        }

        /// <summary>
        /// 用户所属部门
        /// <summary>
        public string Unit_Id
        {
            get;
            set;
        }

        /// <summary>
        /// 创建时间
        /// <summary>
        public string User_Createdate
        {
            get ;
            set ;
        }

    }
}
