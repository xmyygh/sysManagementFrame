using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MCL.Management.Models;
using DataAccess;

namespace MCL.Management.DAL
{
    public class sysroleuserDAL
    {
        /// <summary>
        /// 是否存在数据
        /// <summary>
        public int IsExist(sysroleuserModels _Wheresysroleuser)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT COUNT(1)");
            sbsql.Append(" FROM SYSROLEUSER");
            sbsql.Append(" WHERE 1=1");
            if (_Wheresysroleuser != null)
            {
                sbsql.Append(GetWhere(_Wheresysroleuser));
            }
            object _ScalarData = DbHelp.ExecuteScalar<object>(@sbsql.ToString(), _Wheresysroleuser);
            return Convert.ToInt32(_ScalarData);
        }

        /// <summary>
        /// 查看全部
        /// <summary>
        public List<sysroleuserModels> selectAll()
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" ROLE_ID,USER_ID");
            sbsql.Append(" FROM SYSROLEUSER");
            IEnumerable<sysroleuserModels> _AllData = DbHelp.Query<sysroleuserModels>(@sbsql.ToString(), null , null, false, null, System.Data.CommandType.Text);
            return _AllData.ToList();
        }

        /// <summary>
        /// 根据条件查询
        /// <summary>
        public List<sysroleuserModels> SelectByWhere(sysroleuserModels _Wheresysroleuser, Dictionary<string,string> _Sort, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" ROLE_ID,USER_ID");
            sbsql.Append(" FROM SYSROLEUSER");
            sbsql.Append(" WHERE 1=1");
            if(_WhereType==null)
            {
                string sqlWhere = GetWhere(_Wheresysroleuser);
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
            IEnumerable<sysroleuserModels> _WhereData = DbHelp.Query<sysroleuserModels>(@sbsql.ToString(), _Wheresysroleuser , null, false, null, System.Data.CommandType.Text);
            return _WhereData.ToList();
        }

        /// <summary>
        /// 主键查询
        /// <summary>
        public sysroleuserModels SelectByKey(sysroleuserModels _Wheresysroleuser)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" ROLE_ID,USER_ID");
            sbsql.Append(" FROM SYSROLEUSER");
            sbsql.Append(" WHERE");
            sbsql.Append(" ROLE_ID=@Role_Id");
            sbsql.Append(" AND USER_ID=@User_Id");
            sysroleuserModels _OneData = DbHelp.QueryOne<sysroleuserModels>(@sbsql.ToString(), _Wheresysroleuser , null, false, null, System.Data.CommandType.Text);
            return _OneData;
        }

        /// <summary>
        /// 查询分页
        /// <summary>
        public multiplePageModel<sysroleuserModels> SelectMultiple(sysroleuserModels _Wheresysroleuser, Dictionary<string, string> _Sort, int _Limit, int _Offset)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT COUNT(1)");
            sbsql.Append(" FROM SYSROLEUSER");
            sbsql.Append(" WHERE 1=1");
            string sqlWhere = GetWhere(_Wheresysroleuser);
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sbsql.Append(sqlWhere);
            }
            sbsql.Append(";");
            sbsql.Append(" SELECT ");
            sbsql.Append(" ROLE_ID,USER_ID");
            sbsql.Append(" FROM SYSROLEUSER");
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
            IEnumerable<sysroleuserModels> _QueryData = DbHelp.QueryMultiple<sysroleuserModels>(@sbsql.ToString(), out totalCount, _Wheresysroleuser);
            multiplePageModel<sysroleuserModels> multipleData = new multiplePageModel<sysroleuserModels>();
            multipleData.TotalNum = totalCount;
            multipleData.Items = _QueryData.ToList();
            return multipleData;
        }

        /// <summary>
        /// 查询第一行第一列
        /// <summary>
        public object SelectScalar(string _ColumnName,sysroleuserModels _Wheresysroleuser, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT "+_ColumnName);
            sbsql.Append(" FROM SYSROLEUSER");
            sbsql.Append(" WHERE 1=1 ");
            if(_WhereType==null)
            {
                if (_Wheresysroleuser != null)
                {
                    sbsql.Append(GetWhere(_Wheresysroleuser));
                }
            }
            object _ScalarData = DbHelp.ExecuteScalar<object>(@sbsql.ToString(), _Wheresysroleuser);
            return _ScalarData;
        }

        /// <summary>
        /// 新增
        /// <summary>
        public int Insert(sysroleuserModels _Insertsysroleuser)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" INSERT INTO SYSROLEUSER (");
            sbsql.Append(" ROLE_ID,USER_ID");
            sbsql.Append(" ) VALUES (");
            sbsql.Append(" @Role_Id,@User_Id )");
            int _InsRow = DbHelp.Execute(@sbsql.ToString(), _Insertsysroleuser , null, null, System.Data.CommandType.Text);
            return _InsRow;
        }

        /// <summary>
        /// 主键修改
        /// <summary>
        public int UpdateByKey(sysroleuserModels _Updatesysroleuser)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" UPDATE SYSROLEUSER SET");
            sbsql.Append(" WHERE");
            sbsql.Append(" ROLE_ID=@Role_Id");
            sbsql.Append(" AND USER_ID=@User_Id");
            int _UpdateRow = DbHelp.Execute(@sbsql.ToString(), _Updatesysroleuser , null, null, System.Data.CommandType.Text);
            return _UpdateRow;
        }

        /// <summary>
        /// 主键删除
        /// <summary>
        public int DeleteByKey(sysroleuserModels _Wheresysroleuser)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" DELETE FROM SYSROLEUSER");
            sbsql.Append(" WHERE");
            sbsql.Append(" ROLE_ID=@Role_Id");
            sbsql.Append(" AND USER_ID=@User_Id");
            int _DelRow = DbHelp.Execute(@sbsql.ToString(), _Wheresysroleuser , null, null, System.Data.CommandType.Text);
            return _DelRow;
        }

        /// <summary>
        /// 条件删除
        /// <summary>
        public int DeleteByWhere(sysroleuserModels _Wheresysroleuser, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" DELETE FROM SYSROLEUSER");
            sbsql.Append(" WHERE 1=1 ");
            if(_WhereType==null)
            {
                if (_Wheresysroleuser != null)
                {
                    sbsql.Append(GetWhere(_Wheresysroleuser));
                }
            }
            int _DelRow = DbHelp.Execute(@sbsql.ToString(), _Wheresysroleuser , null, null, System.Data.CommandType.Text);
            return _DelRow;
        }

        /// <summary>
        /// where条件
        /// <summary>
        private string GetWhere(sysroleuserModels _Wheresysroleuser)
        {
            StringBuilder sbwhere = new StringBuilder();
            if(_Wheresysroleuser != null)
            {
                if (!string.IsNullOrEmpty(_Wheresysroleuser.Role_Id))
                {
                    sbwhere.Append(" AND  ROLE_ID=@Role_Id");
                }
                if (!string.IsNullOrEmpty(_Wheresysroleuser.User_Id))
                {
                    sbwhere.Append(" AND  USER_ID=@User_Id");
                }
            }
            return sbwhere.ToString();
        }
    }
}
