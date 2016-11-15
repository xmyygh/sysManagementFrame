using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MCL.Management.DAL;
using MCL.Management.Models;

namespace MCL.Management.BLL
{
    public class sysloginBLL
    {
        sysloginDAL syslogindal = new sysloginDAL();

        /// <summary>
        /// 是否存在数据
        /// <summary>
        public int IsExist(sysloginModels _Wheresyslogin)
        {
            return syslogindal.IsExist(_Wheresyslogin);
        }

        /// <summary>
        /// 查看全部
        /// <summary>
        public List<sysloginModels> selectAll()
        {
            return syslogindal.selectAll();
        }

        /// <summary>
        /// 根据登录账号和用户姓名查看登陆信息
        /// <summary>
        public List<sysloginModels> selectByName(string _ByName)
        {
            return syslogindal.selectByName(_ByName);
        }
        /// <summary>
        /// 根据条件查询
        /// <summary>
        public List<sysloginModels> SelectByWhere(sysloginModels _Wheresyslogin , Dictionary<string, string> _Sort, object _WhereType = null)
        {
            return syslogindal.SelectByWhere(_Wheresyslogin, _Sort, _WhereType);

        }

        /// <summary>
        /// 主键查询
        /// <summary>
        public sysloginModels SelectByKey(sysloginModels _Wheresyslogin)
        {
            return syslogindal.SelectByKey(_Wheresyslogin);
        }

        /// <summary>
        /// 分页查询
        /// <summary>
        public multiplePageModel<sysloginModels> SelectMultiple(sysloginModels _Wheresyslogin, Dictionary<string, string> _Sort, int _Limit, int _Offset)
        {
            return syslogindal.SelectMultiple(_Wheresyslogin, _Sort, _Limit, _Offset);
        }

        /// <summary>
        /// 查询第一行第一列
        /// <summary>
        public object SelectScalar(string _ColumnName,sysloginModels _Wheresyslogin, object _WhereType = null)
        {
            return syslogindal.SelectScalar(_ColumnName, _Wheresyslogin, _WhereType);
        }

        /// <summary>
        /// 新增
        /// <summary>
        public int Insert(sysloginModels _Insertsyslogin)
        {
            return syslogindal.Insert(_Insertsyslogin);
        }

        /// <summary>
        /// 主键修改
        /// <summary>
        public int UpdateByKey(sysloginModels _Updatesyslogin)
        {
            return syslogindal.UpdateByKey(_Updatesyslogin);
        }

        /// <summary>
        /// 主键删除
        /// <summary>
        public int DeleteByKey(sysloginModels _Wheresyslogin)
        {
            return syslogindal.DeleteByKey(_Wheresyslogin);
        }

        /// <summary>
        /// 条件删除
        /// <summary>
        public int DeleteByWhere(sysloginModels _Wheresyslogin, object _WhereType = null)
        {
            return syslogindal.DeleteByWhere(_Wheresyslogin, _WhereType);
        }
    }
}
