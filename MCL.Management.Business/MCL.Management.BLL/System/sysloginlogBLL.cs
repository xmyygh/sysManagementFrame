using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MCL.Management.DAL;
using MCL.Management.Models;
using MCL.Management.Utility;

namespace MCL.Management.BLL
{
    public class sysloginlogBLL
    {
        sysloginlogDAL sysloginlogdal = new sysloginlogDAL(); 

        /// <summary>
        /// 是否存在数据
        /// <summary>
        public int IsExist(sysloginlogModels _Wheresysloginlog)
        {
            return sysloginlogdal.IsExist(_Wheresysloginlog);
        }

        /// <summary>
        /// 查看全部
        /// <summary>
        public List<sysloginlogModels> selectAll()
        {
            return sysloginlogdal.selectAll();
        }

        /// <summary>
        /// 根据条件查询
        /// <summary>
        public List<sysloginlogModels> SelectByWhere(sysloginlogModels _Wheresysloginlog , Dictionary<string, string> _Sort, object _WhereType = null)
        {
            return sysloginlogdal.SelectByWhere(_Wheresysloginlog, _Sort, _WhereType);

        }

        /// <summary>
        /// 主键查询
        /// <summary>
        public sysloginlogModels SelectByKey(sysloginlogModels _Wheresysloginlog)
        {
            return sysloginlogdal.SelectByKey(_Wheresysloginlog);
        }

        /// <summary>
        /// 分页查询
        /// <summary>
        public multiplePageModel<sysloginlogModels> SelectMultiple(sysloginlogModels _Wheresysloginlog, Dictionary<string, string> _Sort, int _Limit, int _Offset)
        {
            return sysloginlogdal.SelectMultiple(_Wheresysloginlog, _Sort, _Limit, _Offset);
        }

        /// <summary>
        /// 查询第一行第一列
        /// <summary>
        public object SelectScalar(string _ColumnName,sysloginlogModels _Wheresysloginlog, object _WhereType = null)
        {
            return sysloginlogdal.SelectScalar(_ColumnName, _Wheresysloginlog, _WhereType);
        }

        /// <summary>
        /// 新增
        /// <summary>
        public int Insert(sysloginlogModels _Insertsysloginlog)
        {
            //查看配置文件system.config
            if (!AppSettingsHelper.GetBoolValue("IsDBLoginLog"))
            {
                return 0;
            }

            string id = SQID.GetID();
            _Insertsysloginlog.Loginlog_Id = id;
            return sysloginlogdal.Insert(_Insertsysloginlog);
        }

        /// <summary>
        /// 主键修改
        /// <summary>
        public int UpdateByKey(sysloginlogModels _Updatesysloginlog)
        {
            return sysloginlogdal.UpdateByKey(_Updatesysloginlog);
        }

        /// <summary>
        /// 主键删除
        /// <summary>
        public int DeleteByKey(sysloginlogModels _Wheresysloginlog)
        {
            return sysloginlogdal.DeleteByKey(_Wheresysloginlog);
        }

        /// <summary>
        /// 条件删除
        /// <summary>
        public int DeleteByWhere(sysloginlogModels _Wheresysloginlog, object _WhereType = null)
        {
            return sysloginlogdal.DeleteByWhere(_Wheresysloginlog, _WhereType);
        }
    }
}
