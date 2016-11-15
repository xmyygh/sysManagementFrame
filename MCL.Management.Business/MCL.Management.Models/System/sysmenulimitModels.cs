using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MCL.Management.Models
{
    public class sysmenulimitModels
    {
        /// <summary>
        /// 菜单ID
        /// <summary>
        public string Menu_Id
        {
            get ;
            set ;
        }

        /// <summary>
        /// 菜单类型1单位2角色3用户
        /// <summary>
        public int Ment_Type
        {
            get ;
            set ;
        }

        /// <summary>
        /// 单位、角色、用户ID
        /// <summary>
        public string Unit_Role_User_Id
        {
            get ;
            set ;
        }

    }
}
