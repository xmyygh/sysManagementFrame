using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MCL.Management.DAL;
using MCL.Management.Models;

namespace MCL.Management.BLL
{
    public class sysunituserBLL
    {
        sysunituserDAL sysunituserdal = new sysunituserDAL(); 

        /// <summary>
        /// 是否存在数据
        /// <summary>
        public int IsExist(sysunituserModels _Wheresysunituser)
        {
            return sysunituserdal.IsExist(_Wheresysunituser);
        }

        /// <summary>
        /// 查看全部
        /// <summary>
        public List<sysunituserModels> selectAll()
        {
            return sysunituserdal.selectAll();
        }

        /// <summary>
        /// 根据条件查询
        /// <summary>
        public List<sysunituserModels> SelectByWhere(sysunituserModels _Wheresysunituser , Dictionary<string, string> _Sort, object _WhereType = null)
        {
            return sysunituserdal.SelectByWhere(_Wheresysunituser, _Sort, _WhereType);

        }

        /// <summary>
        /// 主键查询
        /// <summary>
        public sysunituserModels SelectByKey(sysunituserModels _Wheresysunituser)
        {
            return sysunituserdal.SelectByKey(_Wheresysunituser);
        }

        /// <summary>
        /// 分页查询
        /// <summary>
        public multiplePageModel<sysunituserModels> SelectMultiple(sysunituserModels _Wheresysunituser, Dictionary<string, string> _Sort, int _Limit, int _Offset)
        {
            return sysunituserdal.SelectMultiple(_Wheresysunituser, _Sort, _Limit, _Offset);
        }

        /// <summary>
        /// 查询第一行第一列
        /// <summary>
        public object SelectScalar(string _ColumnName,sysunituserModels _Wheresysunituser, object _WhereType = null)
        {
            return sysunituserdal.SelectScalar(_ColumnName, _Wheresysunituser, _WhereType);
        }

        /// <summary>
        /// 新增
        /// <summary>
        public int Insert(sysunituserModels _Insertsysunituser)
        {
            return sysunituserdal.Insert(_Insertsysunituser);
        }

        /// <summary>
        /// 主键修改
        /// <summary>
        public int UpdateByKey(sysunituserModels _Updatesysunituser)
        {
            return sysunituserdal.UpdateByKey(_Updatesysunituser);
        }

        /// <summary>
        /// 主键删除
        /// <summary>
        public int DeleteByKey(sysunituserModels _Wheresysunituser)
        {
            return sysunituserdal.DeleteByKey(_Wheresysunituser);
        }

        /// <summary>
        /// 条件删除
        /// <summary>
        public int DeleteByWhere(sysunituserModels _Wheresysunituser, object _WhereType = null)
        {
            return sysunituserdal.DeleteByWhere(_Wheresysunituser, _WhereType);
        }
    }
}
