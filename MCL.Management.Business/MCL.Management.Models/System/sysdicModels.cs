using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MCL.Management.Models
{
    public class sysdicModels
    {
        /// <summary>
        /// 主键ID
        /// <summary>
        public string Sysdic_Id
        {
            get ;
            set ;
        }

        /// <summary>
        /// 字典分类
        /// <summary>
        public string Sysdic_Type
        {
            get ;
            set ;
        }

        /// <summary>
        /// 字典编码
        /// <summary>
        public string Sysdic_Code
        {
            get ;
            set ;
        }

        /// <summary>
        /// 字典名称
        /// <summary>
        public string Sysdic_Name
        {
            get ;
            set ;
        }

        /// <summary>
        /// 
        /// <summary>
        public int? Sysdic_Order
        {
            get ;
            set ;
        }

        /// <summary>
        /// 0不可用 1可用
        /// <summary>
        public string Sysdic_Enabled
        {
            get ;
            set ;
        }

        /// <summary>
        /// 字典描述
        /// <summary>
        public string Sysdic_Description
        {
            get ;
            set ;
        }

    }
}
