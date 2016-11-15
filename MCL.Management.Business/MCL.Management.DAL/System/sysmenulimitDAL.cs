using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MCL.Management.Models;
using DataAccess;

namespace MCL.Management.DAL
{
    public class sysmenulimitDAL
    {
        /// <summary>
        /// 是否存在数据
        /// <summary>
        public int IsExist(sysmenulimitModels _Wheresysmenulimit)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT COUNT(1)");
            sbsql.Append(" FROM SYSMENULIMIT");
            sbsql.Append(" WHERE 1=1");
            if (_Wheresysmenulimit != null)
            {
                sbsql.Append(GetWhere(_Wheresysmenulimit));
            }
            object _ScalarData = DbHelp.ExecuteScalar<object>(@sbsql.ToString(), _Wheresysmenulimit);
            return Convert.ToInt32(_ScalarData);
        }

        /// <summary>
        /// 查看全部
        /// <summary>
        public List<sysmenulimitModels> selectAll()
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" MENU_ID,MENT_TYPE,UNIT_ROLE_USER_ID");
            sbsql.Append(" FROM SYSMENULIMIT");
            IEnumerable<sysmenulimitModels> _AllData = DbHelp.Query<sysmenulimitModels>(@sbsql.ToString(), null , null, false, null, System.Data.CommandType.Text);
            return _AllData.ToList();
        }

        /// <summary>
        /// 根据条件查询
        /// <summary>
        public List<sysmenulimitModels> SelectByWhere(sysmenulimitModels _Wheresysmenulimit, Dictionary<string,string> _Sort, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" MENU_ID,MENT_TYPE,UNIT_ROLE_USER_ID");
            sbsql.Append(" FROM SYSMENULIMIT");
            sbsql.Append(" WHERE 1=1");
            if(_WhereType==null)
            {
                string sqlWhere = GetWhere(_Wheresysmenulimit);
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
            IEnumerable<sysmenulimitModels> _WhereData = DbHelp.Query<sysmenulimitModels>(@sbsql.ToString(), _Wheresysmenulimit , null, false, null, System.Data.CommandType.Text);
            return _WhereData.ToList();
        }

        /// <summary>
        /// 主键查询
        /// <summary>
        public sysmenulimitModels SelectByKey(sysmenulimitModels _Wheresysmenulimit)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" MENU_ID,MENT_TYPE,UNIT_ROLE_USER_ID");
            sbsql.Append(" FROM SYSMENULIMIT");
            sbsql.Append(" WHERE");
            sbsql.Append(" MENU_ID=@Menu_Id");
            sbsql.Append(" AND MENT_TYPE=@Ment_Type");
            sbsql.Append(" AND UNIT_ROLE_USER_ID=@Unit_Role_User_Id");
            sysmenulimitModels _OneData = DbHelp.QueryOne<sysmenulimitModels>(@sbsql.ToString(), _Wheresysmenulimit , null, false, null, System.Data.CommandType.Text);
            return _OneData;
        }

        /// <summary>
        /// 查询分页
        /// <summary>
        public multiplePageModel<sysmenulimitModels> SelectMultiple(sysmenulimitModels _Wheresysmenulimit, Dictionary<string, string> _Sort, int _Limit, int _Offset)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT COUNT(1)");
            sbsql.Append(" FROM SYSMENULIMIT");
            sbsql.Append(" WHERE 1=1");
            string sqlWhere = GetWhere(_Wheresysmenulimit);
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sbsql.Append(sqlWhere);
            }
            sbsql.Append(";");
            sbsql.Append(" SELECT ");
            sbsql.Append(" MENU_ID,MENT_TYPE,UNIT_ROLE_USER_ID");
            sbsql.Append(" FROM SYSMENULIMIT");
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
            IEnumerable<sysmenulimitModels> _QueryData = DbHelp.QueryMultiple<sysmenulimitModels>(@sbsql.ToString(), out totalCount, _Wheresysmenulimit);
            multiplePageModel<sysmenulimitModels> multipleData = new multiplePageModel<sysmenulimitModels>();
            multipleData.TotalNum = totalCount;
            multipleData.Items = _QueryData.ToList();
            return multipleData;
        }

        /// <summary>
        /// 查询第一行第一列
        /// <summary>
        public object SelectScalar(string _ColumnName,sysmenulimitModels _Wheresysmenulimit, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT "+_ColumnName);
            sbsql.Append(" FROM SYSMENULIMIT");
            sbsql.Append(" WHERE 1=1 ");
            if(_WhereType==null)
            {
                if (_Wheresysmenulimit != null)
                {
                    sbsql.Append(GetWhere(_Wheresysmenulimit));
                }
            }
            object _ScalarData = DbHelp.ExecuteScalar<object>(@sbsql.ToString(), _Wheresysmenulimit);
            return _ScalarData;
        }

        /// <summary>
        /// 新增
        /// <summary>
        public int Insert(sysmenulimitModels _Insertsysmenulimit)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" INSERT INTO SYSMENULIMIT (");
            sbsql.Append(" MENU_ID,MENT_TYPE,UNIT_ROLE_USER_ID");
            sbsql.Append(" ) VALUES (");
            sbsql.Append(" @Menu_Id,@Ment_Type,@Unit_Role_User_Id )");
            int _InsRow = DbHelp.Execute(@sbsql.ToString(), _Insertsysmenulimit , null, null, System.Data.CommandType.Text);
            return _InsRow;
        }

        /// <summary>
        /// 主键修改
        /// <summary>
        public int UpdateByKey(sysmenulimitModels _Updatesysmenulimit)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" UPDATE SYSMENULIMIT SET");
            sbsql.Append(" WHERE");
            sbsql.Append(" MENU_ID=@Menu_Id");
            sbsql.Append(" AND MENT_TYPE=@Ment_Type");
            sbsql.Append(" AND UNIT_ROLE_USER_ID=@Unit_Role_User_Id");
            int _UpdateRow = DbHelp.Execute(@sbsql.ToString(), _Updatesysmenulimit , null, null, System.Data.CommandType.Text);
            return _UpdateRow;
        }

        /// <summary>
        /// 主键删除
        /// <summary>
        public int DeleteByKey(sysmenulimitModels _Wheresysmenulimit)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" DELETE FROM SYSMENULIMIT");
            sbsql.Append(" WHERE");
            sbsql.Append(" MENU_ID=@Menu_Id");
            sbsql.Append(" AND MENT_TYPE=@Ment_Type");
            sbsql.Append(" AND UNIT_ROLE_USER_ID=@Unit_Role_User_Id");
            int _DelRow = DbHelp.Execute(@sbsql.ToString(), _Wheresysmenulimit , null, null, System.Data.CommandType.Text);
            return _DelRow;
        }

        /// <summary>
        /// 条件删除
        /// <summary>
        public int DeleteByWhere(sysmenulimitModels _Wheresysmenulimit, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" DELETE FROM SYSMENULIMIT");
            sbsql.Append(" WHERE 1=1 ");
            if(_WhereType==null)
            {
                if (_Wheresysmenulimit != null)
                {
                    sbsql.Append(GetWhere(_Wheresysmenulimit));
                }
            }
            int _DelRow = DbHelp.Execute(@sbsql.ToString(), _Wheresysmenulimit , null, null, System.Data.CommandType.Text);
            return _DelRow;
        }

        /// <summary>
        /// where条件
        /// <summary>
        private string GetWhere(sysmenulimitModels _Wheresysmenulimit)
        {
            StringBuilder sbwhere = new StringBuilder();
            if(_Wheresysmenulimit != null)
            {
                if (!string.IsNullOrEmpty(_Wheresysmenulimit.Menu_Id))
                {
                    sbwhere.Append(" AND  MENU_ID=@Menu_Id");
                }
                if (_Wheresysmenulimit.Ment_Type != null)
                {
                    sbwhere.Append(" AND  MENT_TYPE=@Ment_Type");
                }
                if (!string.IsNullOrEmpty(_Wheresysmenulimit.Unit_Role_User_Id))
                {
                    sbwhere.Append(" AND  UNIT_ROLE_USER_ID=@Unit_Role_User_Id");
                }
            }
            return sbwhere.ToString();
        }
    }
}
