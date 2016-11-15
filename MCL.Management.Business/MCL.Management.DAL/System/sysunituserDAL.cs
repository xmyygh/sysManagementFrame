using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MCL.Management.Models;
using DataAccess;

namespace MCL.Management.DAL
{
    public class sysunituserDAL
    {
        /// <summary>
        /// 是否存在数据
        /// <summary>
        public int IsExist(sysunituserModels _Wheresysunituser)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT COUNT(1)");
            sbsql.Append(" FROM SYSUNITUSER");
            sbsql.Append(" WHERE 1=1");
            if (_Wheresysunituser != null)
            {
                sbsql.Append(GetWhere(_Wheresysunituser));
            }
            object _ScalarData = DbHelp.ExecuteScalar<object>(@sbsql.ToString(), _Wheresysunituser);
            return Convert.ToInt32(_ScalarData);
        }

        /// <summary>
        /// 查看全部
        /// <summary>
        public List<sysunituserModels> selectAll()
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" UNIT_ID,USER_ID");
            sbsql.Append(" FROM SYSUNITUSER");
            IEnumerable<sysunituserModels> _AllData = DbHelp.Query<sysunituserModels>(@sbsql.ToString(), null , null, false, null, System.Data.CommandType.Text);
            return _AllData.ToList();
        }

        /// <summary>
        /// 根据条件查询
        /// <summary>
        public List<sysunituserModels> SelectByWhere(sysunituserModels _Wheresysunituser, Dictionary<string,string> _Sort, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" UNIT_ID,USER_ID");
            sbsql.Append(" FROM SYSUNITUSER");
            sbsql.Append(" WHERE 1=1");
            if(_WhereType==null)
            {
                string sqlWhere = GetWhere(_Wheresysunituser);
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
            IEnumerable<sysunituserModels> _WhereData = DbHelp.Query<sysunituserModels>(@sbsql.ToString(), _Wheresysunituser , null, false, null, System.Data.CommandType.Text);
            return _WhereData.ToList();
        }

        /// <summary>
        /// 主键查询
        /// <summary>
        public sysunituserModels SelectByKey(sysunituserModels _Wheresysunituser)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" UNIT_ID,USER_ID");
            sbsql.Append(" FROM SYSUNITUSER");
            sbsql.Append(" WHERE");
            sbsql.Append(" UNIT_ID=@Unit_Id");
            sbsql.Append(" AND USER_ID=@User_Id");
            sysunituserModels _OneData = DbHelp.QueryOne<sysunituserModels>(@sbsql.ToString(), _Wheresysunituser , null, false, null, System.Data.CommandType.Text);
            return _OneData;
        }

        /// <summary>
        /// 查询分页
        /// <summary>
        public multiplePageModel<sysunituserModels> SelectMultiple(sysunituserModels _Wheresysunituser, Dictionary<string, string> _Sort, int _Limit, int _Offset)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT COUNT(1)");
            sbsql.Append(" FROM SYSUNITUSER");
            sbsql.Append(" WHERE 1=1");
            string sqlWhere = GetWhere(_Wheresysunituser);
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sbsql.Append(sqlWhere);
            }
            sbsql.Append(";");
            sbsql.Append(" SELECT ");
            sbsql.Append(" UNIT_ID,USER_ID");
            sbsql.Append(" FROM SYSUNITUSER");
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
            IEnumerable<sysunituserModels> _QueryData = DbHelp.QueryMultiple<sysunituserModels>(@sbsql.ToString(), out totalCount, _Wheresysunituser);
            multiplePageModel<sysunituserModels> multipleData = new multiplePageModel<sysunituserModels>();
            multipleData.TotalNum = totalCount;
            multipleData.Items = _QueryData.ToList();
            return multipleData;
        }

        /// <summary>
        /// 查询第一行第一列
        /// <summary>
        public object SelectScalar(string _ColumnName,sysunituserModels _Wheresysunituser, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT "+_ColumnName);
            sbsql.Append(" FROM SYSUNITUSER");
            sbsql.Append(" WHERE 1=1 ");
            if(_WhereType==null)
            {
                if (_Wheresysunituser != null)
                {
                    sbsql.Append(GetWhere(_Wheresysunituser));
                }
            }
            object _ScalarData = DbHelp.ExecuteScalar<object>(@sbsql.ToString(), _Wheresysunituser);
            return _ScalarData;
        }

        /// <summary>
        /// 新增
        /// <summary>
        public int Insert(sysunituserModels _Insertsysunituser)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" INSERT INTO SYSUNITUSER (");
            sbsql.Append(" UNIT_ID,USER_ID");
            sbsql.Append(" ) VALUES (");
            sbsql.Append(" @Unit_Id,@User_Id )");
            int _InsRow = DbHelp.Execute(@sbsql.ToString(), _Insertsysunituser , null, null, System.Data.CommandType.Text);
            return _InsRow;
        }

        /// <summary>
        /// 主键修改
        /// <summary>
        public int UpdateByKey(sysunituserModels _Updatesysunituser)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" UPDATE SYSUNITUSER SET");
            sbsql.Append(" WHERE");
            sbsql.Append(" UNIT_ID=@Unit_Id");
            sbsql.Append(" AND USER_ID=@User_Id");
            int _UpdateRow = DbHelp.Execute(@sbsql.ToString(), _Updatesysunituser , null, null, System.Data.CommandType.Text);
            return _UpdateRow;
        }

        /// <summary>
        /// 主键删除
        /// <summary>
        public int DeleteByKey(sysunituserModels _Wheresysunituser)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" DELETE FROM SYSUNITUSER");
            sbsql.Append(" WHERE");
            sbsql.Append(" UNIT_ID=@Unit_Id");
            sbsql.Append(" AND USER_ID=@User_Id");
            int _DelRow = DbHelp.Execute(@sbsql.ToString(), _Wheresysunituser , null, null, System.Data.CommandType.Text);
            return _DelRow;
        }

        /// <summary>
        /// 条件删除
        /// <summary>
        public int DeleteByWhere(sysunituserModels _Wheresysunituser, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" DELETE FROM SYSUNITUSER");
            sbsql.Append(" WHERE 1=1 ");
            if(_WhereType==null)
            {
                if (_Wheresysunituser != null)
                {
                    sbsql.Append(GetWhere(_Wheresysunituser));
                }
            }
            int _DelRow = DbHelp.Execute(@sbsql.ToString(), _Wheresysunituser , null, null, System.Data.CommandType.Text);
            return _DelRow;
        }

        /// <summary>
        /// where条件
        /// <summary>
        private string GetWhere(sysunituserModels _Wheresysunituser)
        {
            StringBuilder sbwhere = new StringBuilder();
            if(_Wheresysunituser != null)
            {
                if (!string.IsNullOrEmpty(_Wheresysunituser.Unit_Id))
                {
                    sbwhere.Append(" AND  UNIT_ID=@Unit_Id");
                }
                if (!string.IsNullOrEmpty(_Wheresysunituser.User_Id))
                {
                    sbwhere.Append(" AND  USER_ID=@User_Id");
                }
            }
            return sbwhere.ToString();
        }
    }
}
