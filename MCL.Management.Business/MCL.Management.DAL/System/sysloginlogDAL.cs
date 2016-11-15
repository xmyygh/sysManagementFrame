using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MCL.Management.Models;
using DataAccess;

namespace MCL.Management.DAL
{
    public class sysloginlogDAL
    {
        /// <summary>
        /// 是否存在数据
        /// <summary>
        public int IsExist(sysloginlogModels _Wheresysloginlog)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT COUNT(1)");
            sbsql.Append(" FROM SYSLOGINLOG");
            sbsql.Append(" WHERE 1=1");
            if (_Wheresysloginlog != null)
            {
                sbsql.Append(GetWhere(_Wheresysloginlog));
            }
            object _ScalarData = DbHelp.ExecuteScalar<object>(@sbsql.ToString(), _Wheresysloginlog);
            return Convert.ToInt32(_ScalarData);
        }

        /// <summary>
        /// 查看全部
        /// <summary>
        public List<sysloginlogModels> selectAll()
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" LOGINLOG_ID,ACCOUNT,USER_ID,USER_NAME,LOCALIP,LOGINTIME,");
            sbsql.Append(" OUTSYSTIME,DESCRIPTION");
            sbsql.Append(" FROM SYSLOGINLOG");
            IEnumerable<sysloginlogModels> _AllData = DbHelp.Query<sysloginlogModels>(@sbsql.ToString(), null , null, false, null, System.Data.CommandType.Text);
            return _AllData.ToList();
        }

        /// <summary>
        /// 根据条件查询
        /// <summary>
        public List<sysloginlogModels> SelectByWhere(sysloginlogModels _Wheresysloginlog, Dictionary<string,string> _Sort, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" LOGINLOG_ID,ACCOUNT,USER_ID,USER_NAME,LOCALIP,LOGINTIME,");
            sbsql.Append(" OUTSYSTIME,DESCRIPTION");
            sbsql.Append(" FROM SYSLOGINLOG");
            sbsql.Append(" WHERE 1=1");
            if(_WhereType==null)
            {
                string sqlWhere = GetWhere(_Wheresysloginlog);
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
            IEnumerable<sysloginlogModels> _WhereData = DbHelp.Query<sysloginlogModels>(@sbsql.ToString(), _Wheresysloginlog , null, false, null, System.Data.CommandType.Text);
            return _WhereData.ToList();
        }

        /// <summary>
        /// 主键查询
        /// <summary>
        public sysloginlogModels SelectByKey(sysloginlogModels _Wheresysloginlog)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" LOGINLOG_ID,ACCOUNT,USER_ID,USER_NAME,LOCALIP,LOGINTIME,");
            sbsql.Append(" OUTSYSTIME,DESCRIPTION");
            sbsql.Append(" FROM SYSLOGINLOG");
            sbsql.Append(" WHERE");
            sbsql.Append(" LOGINLOG_ID=@Loginlog_Id");
            sysloginlogModels _OneData = DbHelp.QueryOne<sysloginlogModels>(@sbsql.ToString(), _Wheresysloginlog , null, false, null, System.Data.CommandType.Text);
            return _OneData;
        }

        /// <summary>
        /// 查询分页
        /// <summary>
        public multiplePageModel<sysloginlogModels> SelectMultiple(sysloginlogModels _Wheresysloginlog, Dictionary<string, string> _Sort, int _Limit, int _Offset)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT COUNT(1)");
            sbsql.Append(" FROM SYSLOGINLOG");
            sbsql.Append(" WHERE 1=1");
            string sqlWhere = GetWhere(_Wheresysloginlog);
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sbsql.Append(sqlWhere);
            }
            sbsql.Append(";");
            sbsql.Append(" SELECT ");
            sbsql.Append(" LOGINLOG_ID,ACCOUNT,USER_ID,USER_NAME,LOCALIP,LOGINTIME,");
            sbsql.Append(" OUTSYSTIME,DESCRIPTION");
            sbsql.Append(" FROM SYSLOGINLOG");
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
            IEnumerable<sysloginlogModels> _QueryData = DbHelp.QueryMultiple<sysloginlogModels>(@sbsql.ToString(), out totalCount, _Wheresysloginlog);
            multiplePageModel<sysloginlogModels> multipleData = new multiplePageModel<sysloginlogModels>();
            multipleData.TotalNum = totalCount;
            multipleData.Items = _QueryData.ToList();
            return multipleData;
        }

        /// <summary>
        /// 查询第一行第一列
        /// <summary>
        public object SelectScalar(string _ColumnName,sysloginlogModels _Wheresysloginlog, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT "+_ColumnName);
            sbsql.Append(" FROM SYSLOGINLOG");
            sbsql.Append(" WHERE 1=1 ");
            if(_WhereType==null)
            {
                if (_Wheresysloginlog != null)
                {
                    sbsql.Append(GetWhere(_Wheresysloginlog));
                }
            }
            object _ScalarData = DbHelp.ExecuteScalar<object>(@sbsql.ToString(), _Wheresysloginlog);
            return _ScalarData;
        }

        /// <summary>
        /// 新增
        /// <summary>
        public int Insert(sysloginlogModels _Insertsysloginlog)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" INSERT INTO SYSLOGINLOG (");
            sbsql.Append(" LOGINLOG_ID,ACCOUNT,USER_ID,USER_NAME,LOCALIP,LOGINTIME,");
            sbsql.Append(" OUTSYSTIME,DESCRIPTION");
            sbsql.Append(" ) VALUES (");
            sbsql.Append(" @Loginlog_Id,@Account,@User_Id,@User_Name,@Localip,@Logintime,");
            sbsql.Append(" @Outsystime,@Description )");
            int _InsRow = DbHelp.Execute(@sbsql.ToString(), _Insertsysloginlog , null, null, System.Data.CommandType.Text);
            return _InsRow;
        }

        /// <summary>
        /// 主键修改
        /// <summary>
        public int UpdateByKey(sysloginlogModels _Updatesysloginlog)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" UPDATE SYSLOGINLOG SET");
            sbsql.Append(" ACCOUNT =@Account,");
            sbsql.Append(" USER_ID =@User_Id,");
            sbsql.Append(" USER_NAME =@User_Name,");
            sbsql.Append(" LOCALIP =@Localip,");
            sbsql.Append(" LOGINTIME =@Logintime,");
            sbsql.Append(" OUTSYSTIME =@Outsystime,");
            sbsql.Append(" DESCRIPTION =@Description");
            sbsql.Append(" WHERE");
            sbsql.Append(" LOGINLOG_ID=@Loginlog_Id");
            int _UpdateRow = DbHelp.Execute(@sbsql.ToString(), _Updatesysloginlog , null, null, System.Data.CommandType.Text);
            return _UpdateRow;
        }

        /// <summary>
        /// 主键删除
        /// <summary>
        public int DeleteByKey(sysloginlogModels _Wheresysloginlog)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" DELETE FROM SYSLOGINLOG");
            sbsql.Append(" WHERE");
            sbsql.Append(" LOGINLOG_ID=@Loginlog_Id");
            int _DelRow = DbHelp.Execute(@sbsql.ToString(), _Wheresysloginlog , null, null, System.Data.CommandType.Text);
            return _DelRow;
        }

        /// <summary>
        /// 条件删除
        /// <summary>
        public int DeleteByWhere(sysloginlogModels _Wheresysloginlog, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" DELETE FROM SYSLOGINLOG");
            sbsql.Append(" WHERE 1=1 ");
            if(_WhereType==null)
            {
                if (_Wheresysloginlog != null)
                {
                    sbsql.Append(GetWhere(_Wheresysloginlog));
                }
            }
            int _DelRow = DbHelp.Execute(@sbsql.ToString(), _Wheresysloginlog , null, null, System.Data.CommandType.Text);
            return _DelRow;
        }

        /// <summary>
        /// where条件
        /// <summary>
        private string GetWhere(sysloginlogModels _Wheresysloginlog)
        {
            StringBuilder sbwhere = new StringBuilder();
            if(_Wheresysloginlog != null)
            {
                if (!string.IsNullOrEmpty(_Wheresysloginlog.Loginlog_Id))
                {
                    sbwhere.Append(" AND  LOGINLOG_ID=@Loginlog_Id");
                }
                if (!string.IsNullOrEmpty(_Wheresysloginlog.Account))
                {
                    sbwhere.Append(" AND  ACCOUNT CONCAT('%',@Account,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysloginlog.User_Id))
                {
                    sbwhere.Append(" AND  USER_ID CONCAT('%',@User_Id,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysloginlog.User_Name))
                {
                    sbwhere.Append(" AND  USER_NAME CONCAT('%',@User_Name,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysloginlog.Localip))
                {
                    sbwhere.Append(" AND  LOCALIP CONCAT('%',@Localip,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysloginlog.Logintime))
                {
                    sbwhere.Append(" AND  LOGINTIME CONCAT('%',@Logintime,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysloginlog.Outsystime))
                {
                    sbwhere.Append(" AND  OUTSYSTIME CONCAT('%',@Outsystime,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysloginlog.Description))
                {
                    sbwhere.Append(" AND  DESCRIPTION CONCAT('%',@Description,'%')");
                }
            }
            return sbwhere.ToString();
        }
    }
}
