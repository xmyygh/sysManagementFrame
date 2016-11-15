using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MCL.Management.DAL;
using MCL.Management.Models;

namespace MCL.Management.BLL
{
    public class sysroleuserBLL
    {
        sysroleuserDAL sysroleuserdal = new sysroleuserDAL(); 

        /// <summary>
        /// 是否存在数据
        /// <summary>
        public int IsExist(sysroleuserModels _Wheresysroleuser)
        {
            return sysroleuserdal.IsExist(_Wheresysroleuser);
        }

        /// <summary>
        /// 查看全部
        /// <summary>
        public List<sysroleuserModels> selectAll()
        {
            return sysroleuserdal.selectAll();
        }

        /// <summary>
        /// 根据条件查询
        /// <summary>
        public List<sysroleuserModels> SelectByWhere(sysroleuserModels _Wheresysroleuser , Dictionary<string, string> _Sort, object _WhereType = null)
        {
            return sysroleuserdal.SelectByWhere(_Wheresysroleuser, _Sort, _WhereType);

        }

        /// <summary>
        /// 主键查询
        /// <summary>
        public sysroleuserModels SelectByKey(sysroleuserModels _Wheresysroleuser)
        {
            return sysroleuserdal.SelectByKey(_Wheresysroleuser);
        }

        /// <summary>
        /// 分页查询
        /// <summary>
        public multiplePageModel<sysroleuserModels> SelectMultiple(sysroleuserModels _Wheresysroleuser, Dictionary<string, string> _Sort, int _Limit, int _Offset)
        {
            return sysroleuserdal.SelectMultiple(_Wheresysroleuser, _Sort, _Limit, _Offset);
        }

        /// <summary>
        /// 查询第一行第一列
        /// <summary>
        public object SelectScalar(string _ColumnName,sysroleuserModels _Wheresysroleuser, object _WhereType = null)
        {
            return sysroleuserdal.SelectScalar(_ColumnName, _Wheresysroleuser, _WhereType);
        }

        /// <summary>
        /// 新增
        /// <summary>
        public int Insert(sysroleuserModels _Insertsysroleuser)
        {
            return sysroleuserdal.Insert(_Insertsysroleuser);
        }

        /// <summary>
        /// 主键修改
        /// <summary>
        public int UpdateByKey(sysroleuserModels _Updatesysroleuser)
        {
            return sysroleuserdal.UpdateByKey(_Updatesysroleuser);
        }

        /// <summary>
        /// 主键删除
        /// <summary>
        public int DeleteByKey(sysroleuserModels _Wheresysroleuser)
        {
            return sysroleuserdal.DeleteByKey(_Wheresysroleuser);
        }

        /// <summary>
        /// 条件删除
        /// <summary>
        public int DeleteByWhere(sysroleuserModels _Wheresysroleuser, object _WhereType = null)
        {
            return sysroleuserdal.DeleteByWhere(_Wheresysroleuser, _WhereType);
        }
    }
}
