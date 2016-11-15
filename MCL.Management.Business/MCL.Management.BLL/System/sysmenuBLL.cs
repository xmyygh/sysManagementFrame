using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MCL.Management.DAL;
using MCL.Management.Models;

namespace MCL.Management.BLL
{
    public class sysmenuBLL
    {
        sysmenuDAL sysmenudal = new sysmenuDAL(); 

        /// <summary>
        /// 是否存在数据
        /// <summary>
        public int IsExist(sysmenuModels _Wheresysmenu)
        {
            return sysmenudal.IsExist(_Wheresysmenu);
        }

        /// <summary>
        /// 查看全部
        /// <summary>
        public List<sysmenuModels> selectAll()
        {
            return sysmenudal.selectAll();
        }

        /// <summary>
        /// 根据条件查询
        /// <summary>
        public List<sysmenuModels> SelectByWhere(sysmenuModels _Wheresysmenu , Dictionary<string, string> _Sort, object _WhereType = null)
        {
            return sysmenudal.SelectByWhere(_Wheresysmenu, _Sort, _WhereType);

        }

        /// <summary>
        /// 主键查询
        /// <summary>
        public sysmenuModels SelectByKey(sysmenuModels _Wheresysmenu)
        {
            return sysmenudal.SelectByKey(_Wheresysmenu);
        }

        /// <summary>
        /// 分页查询
        /// <summary>
        public multiplePageModel<sysmenuModels> SelectMultiple(sysmenuModels _Wheresysmenu, Dictionary<string, string> _Sort, int _Limit, int _Offset)
        {
            return sysmenudal.SelectMultiple(_Wheresysmenu, _Sort, _Limit, _Offset);
        }

        /// <summary>
        /// 查询第一行第一列
        /// <summary>
        public object SelectScalar(string _ColumnName,sysmenuModels _Wheresysmenu, object _WhereType = null)
        {
            return sysmenudal.SelectScalar(_ColumnName, _Wheresysmenu, _WhereType);
        }

        /// <summary>
        /// 新增
        /// <summary>
        public int Insert(sysmenuModels _Insertsysmenu)
        {
            return sysmenudal.Insert(_Insertsysmenu);
        }

        /// <summary>
        /// 主键修改
        /// <summary>
        public int UpdateByKey(sysmenuModels _Updatesysmenu)
        {
            return sysmenudal.UpdateByKey(_Updatesysmenu);
        }

        /// <summary>
        /// 主键删除
        /// <summary>
        public int DeleteByKey(sysmenuModels _Wheresysmenu)
        {
            return sysmenudal.DeleteByKey(_Wheresysmenu);
        }

        /// <summary>
        /// 条件删除
        /// <summary>
        public int DeleteByWhere(sysmenuModels _Wheresysmenu, object _WhereType = null)
        {
            return sysmenudal.DeleteByWhere(_Wheresysmenu, _WhereType);
        }
    }
}
