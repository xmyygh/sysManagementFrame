using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MCL.Management.Models
{
    public class sysunitModels
    {
        /// <summary>
        /// 
        /// <summary>
        public string Unit_Id
        {
            get ;
            set ;
        }

        /// <summary>
        /// 单位分类
        /// <summary>
        public string Unti_Type
        {
            get ;
            set ;
        }

        /// <summary>
        /// 单位编码
        /// <summary>
        public string Unit_Code
        {
            get ;
            set ;
        }

        /// <summary>
        /// 单位名称
        /// <summary>
        public string Unit_Name
        {
            get ;
            set ;
        }

        /// <summary>
        /// 父编码
        /// <summary>
        public string Unit_Parentid
        {
            get ;
            set ;
        }

        /// <summary>
        /// 删除标识
        /// <summary>
        public int? Unit_Deletemark
        {
            get ;
            set ;
        }

        /// <summary>
        /// 描述
        /// <summary>
        public string Unit_Description
        {
            get ;
            set ;
        }

        /// <summary>
        /// 创建时间
        /// <summary>
        public string Unit_Createdate
        {
            get ;
            set ;
        }

    }
}
