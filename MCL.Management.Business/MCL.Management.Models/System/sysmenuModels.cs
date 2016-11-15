using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MCL.Management.Models
{
    public class sysmenuModels
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
        /// 菜单编码
        /// <summary>
        public string Menu_Code
        {
            get ;
            set ;
        }

        /// <summary>
        /// 菜单名称
        /// <summary>
        public string Menu_Name
        {
            get ;
            set ;
        }

        /// <summary>
        /// 菜单父编码
        /// <summary>
        public string Menu_Parentcode
        {
            get ;
            set ;
        }

        /// <summary>
        /// 菜单分类
        /// <summary>
        public string Menu_Categoryld
        {
            get ;
            set ;
        }

        /// <summary>
        /// 菜单图片
        /// <summary>
        public string Menu_Imageindex
        {
            get ;
            set ;
        }

        /// <summary>
        /// 菜单url
        /// <summary>
        public string Menu_Navigateurl
        {
            get ;
            set ;
        }

        /// <summary>
        /// 菜单目标
        /// <summary>
        public string Menu_Target
        {
            get ;
            set ;
        }

        /// <summary>
        /// 排序码
        /// <summary>
        public int? Menu_Sort
        {
            get ;
            set ;
        }

        /// <summary>
        /// 删除标识
        /// <summary>
        public int? Menu_Deletemark
        {
            get ;
            set ;
        }

        /// <summary>
        /// 描述
        /// <summary>
        public string Menu_Description
        {
            get ;
            set ;
        }

    }
}
