using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MCL.Management.DAL;
using MCL.Management.Models;

namespace MCL.Management.BLL
{
    public class sysroleBLL
    {
        sysroleDAL sysroledal = new sysroleDAL(); 

        /// <summary>
        /// 是否存在数据
        /// <summary>
        public int IsExist(sysroleModels _Wheresysrole)
        {
            return sysroledal.IsExist(_Wheresysrole);
        }

        /// <summary>
        /// 查看全部
        /// <summary>
        public List<sysroleModels> selectAll()
        {
            return sysroledal.selectAll();
        }

        /// <summary>
        /// 根据条件查询
        /// <summary>
        public List<sysroleModels> SelectByWhere(sysroleModels _Wheresysrole , Dictionary<string, string> _Sort, object _WhereType = null)
        {
            return sysroledal.SelectByWhere(_Wheresysrole, _Sort, _WhereType);

        }

        /// <summary>
        /// 主键查询
        /// <summary>
        public sysroleModels SelectByKey(sysroleModels _Wheresysrole)
        {
            return sysroledal.SelectByKey(_Wheresysrole);
        }

        /// <summary>
        /// 用户id查询角色
        /// </summary>
        /// <param name="_UserID">用户id</param>
        /// <returns></returns>
        public sysroleModels SelectByUserID(string _UserID)
        {
            return sysroledal.SelectByUserID(_UserID);
        }

        /// <summary>
        /// 分页查询
        /// <summary>
        public multiplePageModel<sysroleModels> SelectMultiple(sysroleModels _Wheresysrole, Dictionary<string, string> _Sort, int _Limit, int _Offset)
        {
            return sysroledal.SelectMultiple(_Wheresysrole, _Sort, _Limit, _Offset);
        }

        /// <summary>
        /// 查询第一行第一列
        /// <summary>
        public object SelectScalar(string _ColumnName,sysroleModels _Wheresysrole, object _WhereType = null)
        {
            return sysroledal.SelectScalar(_ColumnName, _Wheresysrole, _WhereType);
        }

        /// <summary>
        /// 新增
        /// <summary>
        public string Insert(sysroleModels _Insertsysrole)
        {
            string id = SQID.GetID();
            _Insertsysrole.Role_Id = id;
            _Insertsysrole.Role_Code = id;
            int row= sysroledal.Insert(_Insertsysrole);
            if (row>0)
            {
                return id;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 主键修改
        /// <summary>
        public int UpdateByKey(sysroleModels _Updatesysrole)
        {
            return sysroledal.UpdateByKey(_Updatesysrole);
        }

        /// <summary>
        /// 主键删除
        /// <summary>
        public int DeleteByKey(sysroleModels _Wheresysrole)
        {
            return sysroledal.DeleteByKey(_Wheresysrole);
        }

        /// <summary>
        /// 条件删除
        /// <summary>
        public int DeleteByWhere(sysroleModels _Wheresysrole, object _WhereType = null)
        {
            return sysroledal.DeleteByWhere(_Wheresysrole, _WhereType);
        }
    }
}
