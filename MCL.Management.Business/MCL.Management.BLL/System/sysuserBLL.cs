using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MCL.Management.DAL;
using MCL.Management.Models;

namespace MCL.Management.BLL
{
    public class sysuserBLL
    {
        sysuserDAL sysuserdal = new sysuserDAL(); 

        /// <summary>
        /// 是否存在数据
        /// <summary>
        public int IsExist(sysuserModels _Wheresysuser)
        {
            return sysuserdal.IsExist(_Wheresysuser);
        }

        /// <summary>
        /// 查看全部
        /// <summary>
        public List<sysuserModels> selectAll()
        {
            return sysuserdal.selectAll();
        }

        /// <summary>
        /// 根据条件查询
        /// <summary>
        public List<sysuserModels> SelectByWhere(sysuserModels _Wheresysuser , Dictionary<string, string> _Sort, object _WhereType = null)
        {
            return sysuserdal.SelectByWhere(_Wheresysuser, _Sort, _WhereType);

        }

        /// <summary>
        /// 主键查询
        /// <summary>
        public sysuserModels SelectByKey(sysuserModels _Wheresysuser)
        {
            return sysuserdal.SelectByKey(_Wheresysuser);
        }

        /// <summary>
        /// 分页查询
        /// <summary>
        public multiplePageModel<sysuserModels> SelectMultiple(sysuserModels _Wheresysuser, Dictionary<string, string> _Sort, int _Limit, int _Offset)
        {
            return sysuserdal.SelectMultiple(_Wheresysuser, _Sort, _Limit, _Offset);
        }

        /// <summary>
        /// 查询第一行第一列
        /// <summary>
        public object SelectScalar(string _ColumnName,sysuserModels _Wheresysuser, object _WhereType = null)
        {
            return sysuserdal.SelectScalar(_ColumnName, _Wheresysuser, _WhereType);
        }

        /// <summary>
        /// 新增
        /// <summary>
        public int Insert(sysuserModels _Insertsysuser)
        {
            return sysuserdal.Insert(_Insertsysuser);
        }

        /// <summary>
        /// 主键修改
        /// <summary>
        public int UpdateByKey(sysuserModels _Updatesysuser)
        {
            return sysuserdal.UpdateByKey(_Updatesysuser);
        }

        /// <summary>
        /// 主键删除
        /// <summary>
        public int DeleteByKey(sysuserModels _Wheresysuser)
        {
            return sysuserdal.DeleteByKey(_Wheresysuser);
        }

        /// <summary>
        /// 条件删除
        /// <summary>
        public int DeleteByWhere(sysuserModels _Wheresysuser, object _WhereType = null)
        {
            return sysuserdal.DeleteByWhere(_Wheresysuser, _WhereType);
        }
    }
}
