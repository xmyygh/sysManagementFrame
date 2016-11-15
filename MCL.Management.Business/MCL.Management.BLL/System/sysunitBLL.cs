using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MCL.Management.DAL;
using MCL.Management.Models;

namespace MCL.Management.BLL
{
    public class sysunitBLL
    {
        sysunitDAL sysunitdal = new sysunitDAL(); 

        /// <summary>
        /// 是否存在数据
        /// <summary>
        public int IsExist(sysunitModels _Wheresysunit)
        {
            return sysunitdal.IsExist(_Wheresysunit);
        }

        /// <summary>
        /// 查看全部
        /// <summary>
        public List<sysunitModels> selectAll()
        {
            return sysunitdal.selectAll();
        }

        /// <summary>
        /// 根据条件查询
        /// <summary>
        public List<sysunitModels> SelectByWhere(sysunitModels _Wheresysunit , Dictionary<string, string> _Sort, object _WhereType = null)
        {
            return sysunitdal.SelectByWhere(_Wheresysunit, _Sort, _WhereType);

        }

        /// <summary>
        /// 主键查询
        /// <summary>
        public sysunitModels SelectByKey(sysunitModels _Wheresysunit)
        {
            return sysunitdal.SelectByKey(_Wheresysunit);
        }

        /// <summary>
        /// 根据用户ID查询单位
        /// </summary>
        /// <param name="_UserID">用户ID</param>
        /// <returns></returns>
        public sysunitModels SelectByUserID(string _UserID)
        {
            return sysunitdal.SelectByUserID(_UserID);
        }
        /// <summary>
        /// 分页查询
        /// <summary>
        public multiplePageModel<sysunitModels> SelectMultiple(sysunitModels _Wheresysunit, Dictionary<string, string> _Sort, int _Limit, int _Offset)
        {
            return sysunitdal.SelectMultiple(_Wheresysunit, _Sort, _Limit, _Offset);
        }

        /// <summary>
        /// 查询第一行第一列
        /// <summary>
        public object SelectScalar(string _ColumnName,sysunitModels _Wheresysunit, object _WhereType = null)
        {
            return sysunitdal.SelectScalar(_ColumnName, _Wheresysunit, _WhereType);
        }

        /// <summary>
        /// 新增
        /// <summary>
        public int Insert(sysunitModels _Insertsysunit)
        {
            return sysunitdal.Insert(_Insertsysunit);
        }

        /// <summary>
        /// 主键修改
        /// <summary>
        public int UpdateByKey(sysunitModels _Updatesysunit)
        {
            return sysunitdal.UpdateByKey(_Updatesysunit);
        }

        /// <summary>
        /// 主键删除
        /// <summary>
        public int DeleteByKey(sysunitModels _Wheresysunit)
        {
            return sysunitdal.DeleteByKey(_Wheresysunit);
        }

        /// <summary>
        /// 条件删除
        /// <summary>
        public int DeleteByWhere(sysunitModels _Wheresysunit, object _WhereType = null)
        {
            return sysunitdal.DeleteByWhere(_Wheresysunit, _WhereType);
        }
    }
}
