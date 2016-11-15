using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MCL.Management.DAL;
using MCL.Management.Models;

namespace MCL.Management.BLL
{
    public class sysdicBLL
    {
        sysdicDAL sysdicdal = new sysdicDAL(); 

        /// <summary>
        /// 是否存在数据
        /// <summary>
        public int IsExist(sysdicModels _Wheresysdic)
        {
            return sysdicdal.IsExist(_Wheresysdic);
        }

        /// <summary>
        /// 查看全部
        /// <summary>
        public List<sysdicModels> selectAll()
        {
            return sysdicdal.selectAll();
        }

        /// <summary>
        /// 根据条件查询
        /// <summary>
        public List<sysdicModels> SelectByWhere(sysdicModels _Wheresysdic , Dictionary<string, string> _Sort, object _WhereType = null)
        {
            return sysdicdal.SelectByWhere(_Wheresysdic, _Sort, _WhereType);

        }

        /// <summary>
        /// 主键查询
        /// <summary>
        public sysdicModels SelectByKey(sysdicModels _Wheresysdic)
        {
            return sysdicdal.SelectByKey(_Wheresysdic);
        }

        /// <summary>
        /// 分页查询
        /// <summary>
        public multiplePageModel<sysdicModels> SelectMultiple(sysdicModels _Wheresysdic, Dictionary<string, string> _Sort, int _Limit, int _Offset)
        {
            return sysdicdal.SelectMultiple(_Wheresysdic, _Sort, _Limit, _Offset);
        }

        /// <summary>
        /// 查询第一行第一列
        /// <summary>
        public object SelectScalar(string _ColumnName,sysdicModels _Wheresysdic, object _WhereType = null)
        {
            return sysdicdal.SelectScalar(_ColumnName, _Wheresysdic, _WhereType);
        }

        /// <summary>
        /// 新增
        /// <summary>
        public int Insert(sysdicModels _Insertsysdic)
        {
            return sysdicdal.Insert(_Insertsysdic);
        }

        /// <summary>
        /// 主键修改
        /// <summary>
        public int UpdateByKey(sysdicModels _Updatesysdic)
        {
            return sysdicdal.UpdateByKey(_Updatesysdic);
        }

        /// <summary>
        /// 主键删除
        /// <summary>
        public int DeleteByKey(sysdicModels _Wheresysdic)
        {
            return sysdicdal.DeleteByKey(_Wheresysdic);
        }

        /// <summary>
        /// 条件删除
        /// <summary>
        public int DeleteByWhere(sysdicModels _Wheresysdic, object _WhereType = null)
        {
            return sysdicdal.DeleteByWhere(_Wheresysdic, _WhereType);
        }
    }
}
