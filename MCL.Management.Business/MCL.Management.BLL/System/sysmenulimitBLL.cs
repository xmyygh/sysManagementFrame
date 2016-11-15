using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MCL.Management.DAL;
using MCL.Management.Models;

namespace MCL.Management.BLL
{
    public class sysmenulimitBLL
    {
        sysmenulimitDAL sysmenulimitdal = new sysmenulimitDAL(); 

        /// <summary>
        /// 是否存在数据
        /// <summary>
        public int IsExist(sysmenulimitModels _Wheresysmenulimit)
        {
            return sysmenulimitdal.IsExist(_Wheresysmenulimit);
        }

        /// <summary>
        /// 查看全部
        /// <summary>
        public List<sysmenulimitModels> selectAll()
        {
            return sysmenulimitdal.selectAll();
        }

        /// <summary>
        /// 根据条件查询
        /// <summary>
        public List<sysmenulimitModels> SelectByWhere(sysmenulimitModels _Wheresysmenulimit , Dictionary<string, string> _Sort, object _WhereType = null)
        {
            return sysmenulimitdal.SelectByWhere(_Wheresysmenulimit, _Sort, _WhereType);

        }

        /// <summary>
        /// 主键查询
        /// <summary>
        public sysmenulimitModels SelectByKey(sysmenulimitModels _Wheresysmenulimit)
        {
            return sysmenulimitdal.SelectByKey(_Wheresysmenulimit);
        }

        /// <summary>
        /// 分页查询
        /// <summary>
        public multiplePageModel<sysmenulimitModels> SelectMultiple(sysmenulimitModels _Wheresysmenulimit, Dictionary<string, string> _Sort, int _Limit, int _Offset)
        {
            return sysmenulimitdal.SelectMultiple(_Wheresysmenulimit, _Sort, _Limit, _Offset);
        }

        /// <summary>
        /// 查询第一行第一列
        /// <summary>
        public object SelectScalar(string _ColumnName,sysmenulimitModels _Wheresysmenulimit, object _WhereType = null)
        {
            return sysmenulimitdal.SelectScalar(_ColumnName, _Wheresysmenulimit, _WhereType);
        }

        /// <summary>
        /// 新增
        /// <summary>
        public int Insert(sysmenulimitModels _Insertsysmenulimit)
        {
            return sysmenulimitdal.Insert(_Insertsysmenulimit);
        }

        /// <summary>
        /// 主键修改
        /// <summary>
        public int UpdateByKey(sysmenulimitModels _Updatesysmenulimit)
        {
            return sysmenulimitdal.UpdateByKey(_Updatesysmenulimit);
        }

        /// <summary>
        /// 主键删除
        /// <summary>
        public int DeleteByKey(sysmenulimitModels _Wheresysmenulimit)
        {
            return sysmenulimitdal.DeleteByKey(_Wheresysmenulimit);
        }

        /// <summary>
        /// 条件删除
        /// <summary>
        public int DeleteByWhere(sysmenulimitModels _Wheresysmenulimit, object _WhereType = null)
        {
            return sysmenulimitdal.DeleteByWhere(_Wheresysmenulimit, _WhereType);
        }
    }
}
