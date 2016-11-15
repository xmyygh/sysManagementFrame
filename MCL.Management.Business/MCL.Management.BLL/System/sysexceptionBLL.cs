using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MCL.Management.DAL;
using MCL.Management.Models;

namespace MCL.Management.BLL
{
    public class sysexceptionBLL
    {
        sysexceptionDAL sysexceptiondal = new sysexceptionDAL(); 

        /// <summary>
        /// 是否存在数据
        /// <summary>
        public int IsExist(sysexceptionModels _Wheresysexception)
        {
            return sysexceptiondal.IsExist(_Wheresysexception);
        }

        /// <summary>
        /// 查看全部
        /// <summary>
        public List<sysexceptionModels> selectAll()
        {
            return sysexceptiondal.selectAll();
        }

        /// <summary>
        /// 根据条件查询
        /// <summary>
        public List<sysexceptionModels> SelectByWhere(sysexceptionModels _Wheresysexception , Dictionary<string, string> _Sort, object _WhereType = null)
        {
            return sysexceptiondal.SelectByWhere(_Wheresysexception, _Sort, _WhereType);

        }

        /// <summary>
        /// 主键查询
        /// <summary>
        public sysexceptionModels SelectByKey(sysexceptionModels _Wheresysexception)
        {
            return sysexceptiondal.SelectByKey(_Wheresysexception);
        }

        /// <summary>
        /// 分页查询
        /// <summary>
        public multiplePageModel<sysexceptionModels> SelectMultiple(sysexceptionModels _Wheresysexception, Dictionary<string, string> _Sort, int _Limit, int _Offset)
        {
            return sysexceptiondal.SelectMultiple(_Wheresysexception, _Sort, _Limit, _Offset);
        }

        /// <summary>
        /// 查询第一行第一列
        /// <summary>
        public object SelectScalar(string _ColumnName,sysexceptionModels _Wheresysexception, object _WhereType = null)
        {
            return sysexceptiondal.SelectScalar(_ColumnName, _Wheresysexception, _WhereType);
        }

        /// <summary>
        /// 新增
        /// <summary>
        public int Insert(sysexceptionModels _Insertsysexception)
        {
            return sysexceptiondal.Insert(_Insertsysexception);
        }

        /// <summary>
        /// 主键修改
        /// <summary>
        public int UpdateByKey(sysexceptionModels _Updatesysexception)
        {
            return sysexceptiondal.UpdateByKey(_Updatesysexception);
        }

        /// <summary>
        /// 主键删除
        /// <summary>
        public int DeleteByKey(sysexceptionModels _Wheresysexception)
        {
            return sysexceptiondal.DeleteByKey(_Wheresysexception);
        }

        /// <summary>
        /// 条件删除
        /// <summary>
        public int DeleteByWhere(sysexceptionModels _Wheresysexception, object _WhereType = null)
        {
            return sysexceptiondal.DeleteByWhere(_Wheresysexception, _WhereType);
        }
    }
}
