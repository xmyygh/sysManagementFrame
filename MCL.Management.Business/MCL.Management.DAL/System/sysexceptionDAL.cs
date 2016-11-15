using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MCL.Management.Models;
using DataAccess;

namespace MCL.Management.DAL
{
    public class sysexceptionDAL
    {
        /// <summary>
        /// 是否存在数据
        /// <summary>
        public int IsExist(sysexceptionModels _Wheresysexception)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT COUNT(1)");
            sbsql.Append(" FROM SYSEXCEPTION");
            sbsql.Append(" WHERE 1=1");
            if (_Wheresysexception != null)
            {
                sbsql.Append(GetWhere(_Wheresysexception));
            }
            object _ScalarData = DbHelp.ExecuteScalar<object>(@sbsql.ToString(), _Wheresysexception);
            return Convert.ToInt32(_ScalarData);
        }

        /// <summary>
        /// 查看全部
        /// <summary>
        public List<sysexceptionModels> selectAll()
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" EX_ID,EX_TITLE,EX_EVENTID,EX_CLASSNAME,EX_METHOD,EX_CREATTIME,");
            sbsql.Append(" EX_USER_ID,EX_MESSAGE,EX_DES");
            sbsql.Append(" FROM SYSEXCEPTION");
            IEnumerable<sysexceptionModels> _AllData = DbHelp.Query<sysexceptionModels>(@sbsql.ToString(), null , null, false, null, System.Data.CommandType.Text);
            return _AllData.ToList();
        }

        /// <summary>
        /// 根据条件查询
        /// <summary>
        public List<sysexceptionModels> SelectByWhere(sysexceptionModels _Wheresysexception, Dictionary<string,string> _Sort, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" EX_ID,EX_TITLE,EX_EVENTID,EX_CLASSNAME,EX_METHOD,EX_CREATTIME,");
            sbsql.Append(" EX_USER_ID,EX_MESSAGE,EX_DES");
            sbsql.Append(" FROM SYSEXCEPTION");
            sbsql.Append(" WHERE 1=1");
            if(_WhereType==null)
            {
                string sqlWhere = GetWhere(_Wheresysexception);
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
            IEnumerable<sysexceptionModels> _WhereData = DbHelp.Query<sysexceptionModels>(@sbsql.ToString(), _Wheresysexception , null, false, null, System.Data.CommandType.Text);
            return _WhereData.ToList();
        }

        /// <summary>
        /// 主键查询
        /// <summary>
        public sysexceptionModels SelectByKey(sysexceptionModels _Wheresysexception)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" EX_ID,EX_TITLE,EX_EVENTID,EX_CLASSNAME,EX_METHOD,EX_CREATTIME,");
            sbsql.Append(" EX_USER_ID,EX_MESSAGE,EX_DES");
            sbsql.Append(" FROM SYSEXCEPTION");
            sbsql.Append(" WHERE");
            sbsql.Append(" EX_ID=@Ex_Id");
            sysexceptionModels _OneData = DbHelp.QueryOne<sysexceptionModels>(@sbsql.ToString(), _Wheresysexception , null, false, null, System.Data.CommandType.Text);
            return _OneData;
        }

        /// <summary>
        /// 查询分页
        /// <summary>
        public multiplePageModel<sysexceptionModels> SelectMultiple(sysexceptionModels _Wheresysexception, Dictionary<string, string> _Sort, int _Limit, int _Offset)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT COUNT(1)");
            sbsql.Append(" FROM SYSEXCEPTION");
            sbsql.Append(" WHERE 1=1");
            string sqlWhere = GetWhere(_Wheresysexception);
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sbsql.Append(sqlWhere);
            }
            sbsql.Append(";");
            sbsql.Append(" SELECT ");
            sbsql.Append(" EX_ID,EX_TITLE,EX_EVENTID,EX_CLASSNAME,EX_METHOD,EX_CREATTIME,");
            sbsql.Append(" EX_USER_ID,EX_MESSAGE,EX_DES");
            sbsql.Append(" FROM SYSEXCEPTION");
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
            IEnumerable<sysexceptionModels> _QueryData = DbHelp.QueryMultiple<sysexceptionModels>(@sbsql.ToString(), out totalCount, _Wheresysexception);
            multiplePageModel<sysexceptionModels> multipleData = new multiplePageModel<sysexceptionModels>();
            multipleData.TotalNum = totalCount;
            multipleData.Items = _QueryData.ToList();
            return multipleData;
        }

        /// <summary>
        /// 查询第一行第一列
        /// <summary>
        public object SelectScalar(string _ColumnName,sysexceptionModels _Wheresysexception, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT "+_ColumnName);
            sbsql.Append(" FROM SYSEXCEPTION");
            sbsql.Append(" WHERE 1=1 ");
            if(_WhereType==null)
            {
                if (_Wheresysexception != null)
                {
                    sbsql.Append(GetWhere(_Wheresysexception));
                }
            }
            object _ScalarData = DbHelp.ExecuteScalar<object>(@sbsql.ToString(), _Wheresysexception);
            return _ScalarData;
        }

        /// <summary>
        /// 新增
        /// <summary>
        public int Insert(sysexceptionModels _Insertsysexception)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" INSERT INTO SYSEXCEPTION (");
            sbsql.Append(" EX_ID,EX_TITLE,EX_EVENTID,EX_CLASSNAME,EX_METHOD,EX_CREATTIME,");
            sbsql.Append(" EX_USER_ID,EX_MESSAGE,EX_DES");
            sbsql.Append(" ) VALUES (");
            sbsql.Append(" @Ex_Id,@Ex_Title,@Ex_Eventid,@Ex_Classname,@Ex_Method,@Ex_Creattime,");
            sbsql.Append(" @Ex_User_Id,@Ex_Message,@Ex_Des )");
            int _InsRow = DbHelp.Execute(@sbsql.ToString(), _Insertsysexception , null, null, System.Data.CommandType.Text);
            return _InsRow;
        }

        /// <summary>
        /// 主键修改
        /// <summary>
        public int UpdateByKey(sysexceptionModels _Updatesysexception)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" UPDATE SYSEXCEPTION SET");
            sbsql.Append(" EX_TITLE =@Ex_Title,");
            sbsql.Append(" EX_EVENTID =@Ex_Eventid,");
            sbsql.Append(" EX_CLASSNAME =@Ex_Classname,");
            sbsql.Append(" EX_METHOD =@Ex_Method,");
            sbsql.Append(" EX_CREATTIME =@Ex_Creattime,");
            sbsql.Append(" EX_USER_ID =@Ex_User_Id,");
            sbsql.Append(" EX_MESSAGE =@Ex_Message,");
            sbsql.Append(" EX_DES =@Ex_Des");
            sbsql.Append(" WHERE");
            sbsql.Append(" EX_ID=@Ex_Id");
            int _UpdateRow = DbHelp.Execute(@sbsql.ToString(), _Updatesysexception , null, null, System.Data.CommandType.Text);
            return _UpdateRow;
        }

        /// <summary>
        /// 主键删除
        /// <summary>
        public int DeleteByKey(sysexceptionModels _Wheresysexception)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" DELETE FROM SYSEXCEPTION");
            sbsql.Append(" WHERE");
            sbsql.Append(" EX_ID=@Ex_Id");
            int _DelRow = DbHelp.Execute(@sbsql.ToString(), _Wheresysexception , null, null, System.Data.CommandType.Text);
            return _DelRow;
        }

        /// <summary>
        /// 条件删除
        /// <summary>
        public int DeleteByWhere(sysexceptionModels _Wheresysexception, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" DELETE FROM SYSEXCEPTION");
            sbsql.Append(" WHERE 1=1 ");
            if(_WhereType==null)
            {
                if (_Wheresysexception != null)
                {
                    sbsql.Append(GetWhere(_Wheresysexception));
                }
            }
            int _DelRow = DbHelp.Execute(@sbsql.ToString(), _Wheresysexception , null, null, System.Data.CommandType.Text);
            return _DelRow;
        }

        /// <summary>
        /// where条件
        /// <summary>
        private string GetWhere(sysexceptionModels _Wheresysexception)
        {
            StringBuilder sbwhere = new StringBuilder();
            if(_Wheresysexception != null)
            {
                if (!string.IsNullOrEmpty(_Wheresysexception.Ex_Id))
                {
                    sbwhere.Append(" AND  EX_ID=@Ex_Id");
                }
                if (!string.IsNullOrEmpty(_Wheresysexception.Ex_Title))
                {
                    sbwhere.Append(" AND  EX_TITLE CONCAT('%',@Ex_Title,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysexception.Ex_Eventid))
                {
                    sbwhere.Append(" AND  EX_EVENTID CONCAT('%',@Ex_Eventid,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysexception.Ex_Classname))
                {
                    sbwhere.Append(" AND  EX_CLASSNAME CONCAT('%',@Ex_Classname,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysexception.Ex_Method))
                {
                    sbwhere.Append(" AND  EX_METHOD CONCAT('%',@Ex_Method,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysexception.Ex_Creattime))
                {
                    sbwhere.Append(" AND  EX_CREATTIME CONCAT('%',@Ex_Creattime,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysexception.Ex_User_Id))
                {
                    sbwhere.Append(" AND  EX_USER_ID CONCAT('%',@Ex_User_Id,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysexception.Ex_Message))
                {
                    sbwhere.Append(" AND  EX_MESSAGE CONCAT('%',@Ex_Message,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysexception.Ex_Des))
                {
                    sbwhere.Append(" AND  EX_DES CONCAT('%',@Ex_Des,'%')");
                }
            }
            return sbwhere.ToString();
        }
    }
}
