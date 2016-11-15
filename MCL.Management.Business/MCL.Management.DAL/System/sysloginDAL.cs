using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MCL.Management.Models;
using DataAccess;

namespace MCL.Management.DAL
{
    public class sysloginDAL
    {
        /// <summary>
        /// 是否存在数据
        /// <summary>
        public int IsExist(sysloginModels _Wheresyslogin)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT COUNT(1)");
            sbsql.Append(" FROM SYSLOGIN");
            sbsql.Append(" WHERE 1=1");
            if (_Wheresyslogin != null)
            {
                sbsql.Append(GetWhere(_Wheresyslogin));
            }
            object _ScalarData = DbHelp.ExecuteScalar<object>(@sbsql.ToString(), _Wheresyslogin);
            return Convert.ToInt32(_ScalarData);
        }

        /// <summary>
        /// 查看全部
        /// <summary>
        public List<sysloginModels> selectAll()
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" A.ACCOUNT,A.PASSWORD,B.USER_ID,B.USER_NAME,A.ENABLED,A.LINE");
            sbsql.Append(" FROM SYSLOGIN A,SYSUSER B");
            sbsql.Append(" WHERE A.USER_ID=B.USER_ID");
            IEnumerable<sysloginModels> _AllData = DbHelp.Query<sysloginModels>(@sbsql.ToString(), null , null, false, null, System.Data.CommandType.Text);
            return _AllData.ToList();
        }

        /// <summary>
        /// 根据登录账号和用户姓名查看登陆信息
        /// <summary>
        public List<sysloginModels> selectByName(string _ByName)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" A.ACCOUNT,A.PASSWORD,B.USER_ID,B.USER_NAME,A.ENABLED,A.LINE");
            sbsql.Append(" FROM SYSLOGIN A,SYSUSER B");
            sbsql.Append(" WHERE A.USER_ID=B.USER_ID");
            sbsql.Append(" AND (A.ACCOUNT LIKE '%" + _ByName + "%'");
            sbsql.Append(" OR B.USER_NAME LIKE '%" + _ByName + "%')");
            IEnumerable<sysloginModels> _AllData = DbHelp.Query<sysloginModels>(@sbsql.ToString(), null, null, false, null, System.Data.CommandType.Text);
            return _AllData.ToList();
        }

        /// <summary>
        /// 根据条件查询
        /// <summary>
        public List<sysloginModels> SelectByWhere(sysloginModels _Wheresyslogin, Dictionary<string,string> _Sort, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" ACCOUNT,PASSWORD,USER_ID,ENABLED,LINE");
            sbsql.Append(" FROM SYSLOGIN");
            sbsql.Append(" WHERE 1=1");
            if(_WhereType==null)
            {
                string sqlWhere = GetWhere(_Wheresyslogin);
                if (!string.IsNullOrEmpty(sqlWhere))
                {
                    sbsql.Append(sqlWhere);
                }
            }
            if (_Sort != null && _Sort.Count > 0)
            {
                sbsql.Append(" ORDER BY ");
                int flagcount = 0;
                foreach (KeyValuePair<string, string> item in _Sort)
                {
                    flagcount++;
                    if (flagcount == _Sort.Count)
                    {
                        sbsql.Append(item.Key.ToUpper() + " " + item.Value);
                    }
                    else
                    {
                        sbsql.Append(item.Key.ToUpper() + " " + item.Value + ", ");
                    }
                }
            }
            IEnumerable<sysloginModels> _WhereData = DbHelp.Query<sysloginModels>(@sbsql.ToString(), _Wheresyslogin , null, false, null, System.Data.CommandType.Text);
            return _WhereData.ToList();
        }

        /// <summary>
        /// 主键查询
        /// <summary>
        public sysloginModels SelectByKey(sysloginModels _Wheresyslogin)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" ACCOUNT,PASSWORD,USER_ID,ENABLED,LINE");
            sbsql.Append(" FROM SYSLOGIN");
            sbsql.Append(" WHERE");
            sbsql.Append(" ACCOUNT=@Account");
            sysloginModels _OneData = DbHelp.QueryOne<sysloginModels>(@sbsql.ToString(), _Wheresyslogin , null, false, null, System.Data.CommandType.Text);
            return _OneData;
        }

        /// <summary>
        /// 查询分页
        /// <summary>
        public multiplePageModel<sysloginModels> SelectMultiple(sysloginModels _Wheresyslogin, Dictionary<string, string> _Sort, int _Limit, int _Offset)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT COUNT(1)");
            sbsql.Append(" FROM SYSLOGIN");
            sbsql.Append(" WHERE 1=1");
            string sqlWhere = GetWhere(_Wheresyslogin);
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sbsql.Append(sqlWhere);
            }
            sbsql.Append(";");
            sbsql.Append(" SELECT ");
            sbsql.Append(" ACCOUNT,PASSWORD,USER_ID,ENABLED,LINE");
            sbsql.Append(" FROM SYSLOGIN");
            sbsql.Append(" WHERE 1=1");
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sbsql.Append(sqlWhere);
            }
            if (_Sort != null && _Sort.Count > 0)
            {
                sbsql.Append(" ORDER BY ");
                int flagcount = 0;
                foreach (KeyValuePair<string, string> item in _Sort)
                {
                    flagcount++;
                    if (flagcount == _Sort.Count)
                    {
                        sbsql.Append(item.Key.ToUpper() + " " + item.Value);
                    }
                    else
                    {
                        sbsql.Append(item.Key.ToUpper() + " " + item.Value + ", ");
                    }
                }
            }
            sbsql.Append(" LIMIT " + _Offset + "," + _Offset + _Limit);
            int totalCount;
            IEnumerable<sysloginModels> _QueryData = DbHelp.QueryMultiple<sysloginModels>(@sbsql.ToString(), out totalCount, _Wheresyslogin);
            multiplePageModel<sysloginModels> multipleData = new multiplePageModel<sysloginModels>();
            multipleData.TotalNum = totalCount;
            multipleData.Items = _QueryData.ToList();
            return multipleData;
        }

        /// <summary>
        /// 查询第一行第一列
        /// <summary>
        public object SelectScalar(string _ColumnName,sysloginModels _Wheresyslogin, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT "+_ColumnName);
            sbsql.Append(" FROM SYSLOGIN");
            sbsql.Append(" WHERE 1=1 ");
            if(_WhereType==null)
            {
                if (_Wheresyslogin != null)
                {
                    sbsql.Append(GetWhere(_Wheresyslogin));
                }
            }
            object _ScalarData = DbHelp.ExecuteScalar<object>(@sbsql.ToString(), _Wheresyslogin);
            return _ScalarData;
        }

        /// <summary>
        /// 新增
        /// <summary>
        public int Insert(sysloginModels _Insertsyslogin)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" INSERT INTO SYSLOGIN (");
            sbsql.Append(" ACCOUNT,PASSWORD,USER_ID,ENABLED,LINE");
            sbsql.Append(" ) VALUES (");
            sbsql.Append(" @Account,@Password,@User_Id,@Enabled,@Line )");
            int _InsRow = DbHelp.Execute(@sbsql.ToString(), _Insertsyslogin , null, null, System.Data.CommandType.Text);
            return _InsRow;
        }

        /// <summary>
        /// 主键修改
        /// <summary>
        public int UpdateByKey(sysloginModels _Updatesyslogin)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" UPDATE SYSLOGIN SET");
            sbsql.Append(" PASSWORD =@Password,");
            sbsql.Append(" USER_ID =@User_Id,");
            sbsql.Append(" ENABLED =@Enabled,");
            sbsql.Append(" LINE =@Line");
            sbsql.Append(" WHERE");
            sbsql.Append(" ACCOUNT=@Account");
            int _UpdateRow = DbHelp.Execute(@sbsql.ToString(), _Updatesyslogin , null, null, System.Data.CommandType.Text);
            return _UpdateRow;
        }

        /// <summary>
        /// 主键删除
        /// <summary>
        public int DeleteByKey(sysloginModels _Wheresyslogin)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" DELETE FROM SYSLOGIN");
            sbsql.Append(" WHERE");
            sbsql.Append(" ACCOUNT=@Account");
            int _DelRow = DbHelp.Execute(@sbsql.ToString(), _Wheresyslogin , null, null, System.Data.CommandType.Text);
            return _DelRow;
        }

        /// <summary>
        /// 条件删除
        /// <summary>
        public int DeleteByWhere(sysloginModels _Wheresyslogin, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" DELETE FROM SYSLOGIN");
            sbsql.Append(" WHERE 1=1 ");
            if(_WhereType==null)
            {
                if (_Wheresyslogin != null)
                {
                    sbsql.Append(GetWhere(_Wheresyslogin));
                }
            }
            int _DelRow = DbHelp.Execute(@sbsql.ToString(), _Wheresyslogin , null, null, System.Data.CommandType.Text);
            return _DelRow;
        }

        /// <summary>
        /// where条件
        /// <summary>
        private string GetWhere(sysloginModels _Wheresyslogin)
        {
            StringBuilder sbwhere = new StringBuilder();
            if(_Wheresyslogin != null)
            {
                if (!string.IsNullOrEmpty(_Wheresyslogin.Account))
                {
                    sbwhere.Append(" AND  ACCOUNT=@Account");
                }
                if (!string.IsNullOrEmpty(_Wheresyslogin.Password))
                {
                    sbwhere.Append(" AND  PASSWORD CONCAT('%',@Password,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresyslogin.User_Id))
                {
                    sbwhere.Append(" AND  USER_ID CONCAT('%',@User_Id,'%')");
                }
                if (_Wheresyslogin.Enabled != null)
                {
                    sbwhere.Append(" AND  ENABLED=@Enabled");
                }
                if (_Wheresyslogin.Line != null)
                {
                    sbwhere.Append(" AND  LINE=@Line");
                }
            }
            return sbwhere.ToString();
        }
    }
}
