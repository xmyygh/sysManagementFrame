using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MCL.Management.Models
{
    public class sysroleModels
    {
        /// <summary>
        /// 角色ID
        /// <summary>
        public string Role_Id
        {
            get ;
            set ;
        }

        /// <summary>
        /// 角色编码
        /// <summary>
        public string Role_Code
        {
            get ;
            set ;
        }

        /// <summary>
        /// 角色名称
        /// <summary>
        public string Role_Name
        {
            get ;
            set ;
        }

        /// <summary>
        /// 角色描述
        /// <summary>
        public string Role_Description
        {
            get ;
            set ;
        }

        /// <summary>
        /// 创建时间
        /// <summary>
        public string Role_Createdate
        {
            get ;
            set ;
        }

    }
}
