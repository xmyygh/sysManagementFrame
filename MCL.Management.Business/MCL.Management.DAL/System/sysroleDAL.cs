using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MCL.Management.Models;
using DataAccess;

namespace MCL.Management.DAL
{
    public class sysroleDAL
    {
        /// <summary>
        /// 是否存在数据
        /// <summary>
        public int IsExist(sysroleModels _Wheresysrole)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT COUNT(1)");
            sbsql.Append(" FROM SYSROLE");
            sbsql.Append(" WHERE 1=1");
            if (_Wheresysrole != null)
            {
                sbsql.Append(GetWhere(_Wheresysrole));
            }
            object _ScalarData = DbHelp.ExecuteScalar<object>(@sbsql.ToString(), _Wheresysrole);
            return Convert.ToInt32(_ScalarData);
        }

//        public int IsExist(string _RoleId)
//        { 

//            SELECT COUNT(1) C FROM SYSROLEUSER 
//UNION ALL
//SELECT COUNT(1) C FROM SYSMENULIMIT WHERE MENT_TYPE=2
//        }

        /// <summary>
        /// 查看全部
        /// <summary>
        public List<sysroleModels> selectAll()
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" ROLE_ID,ROLE_CODE,ROLE_NAME,ROLE_DESCRIPTION,ROLE_CREATEDATE");
            sbsql.Append(" FROM SYSROLE");
            IEnumerable<sysroleModels> _AllData = DbHelp.Query<sysroleModels>(@sbsql.ToString(), null , null, false, null, System.Data.CommandType.Text);
            return _AllData.ToList();
        }

        /// <summary>
        /// 根据条件查询
        /// <summary>
        public List<sysroleModels> SelectByWhere(sysroleModels _Wheresysrole, Dictionary<string,string> _Sort, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" ROLE_ID,ROLE_CODE,ROLE_NAME,ROLE_DESCRIPTION,ROLE_CREATEDATE");
            sbsql.Append(" FROM SYSROLE");
            sbsql.Append(" WHERE 1=1");
            if(_WhereType==null)
            {
                string sqlWhere = GetWhere(_Wheresysrole);
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
            IEnumerable<sysroleModels> _WhereData = DbHelp.Query<sysroleModels>(@sbsql.ToString(), _Wheresysrole , null, false, null, System.Data.CommandType.Text);
            return _WhereData.ToList();
        }

        /// <summary>
        /// 主键查询
        /// <summary>
        public sysroleModels SelectByKey(sysroleModels _Wheresysrole)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" ROLE_ID,ROLE_CODE,ROLE_NAME,ROLE_DESCRIPTION,ROLE_CREATEDATE");
            sbsql.Append(" FROM SYSROLE");
            sbsql.Append(" WHERE");
            sbsql.Append(" ROLE_ID=@Role_Id");
            sysroleModels _OneData = DbHelp.QueryOne<sysroleModels>(@sbsql.ToString(), _Wheresysrole , null, false, null, System.Data.CommandType.Text);
            return _OneData;
        }

        /// <summary>
        /// 用户id查询角色
        /// <summary>
        public sysroleModels SelectByUserID(string _UserID)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" ROLE_ID,ROLE_CODE,ROLE_NAME,ROLE_DESCRIPTION,ROLE_CREATEDATE");
            sbsql.Append(" FROM SYSROLE");
            sbsql.Append(" WHERE");
            sbsql.Append(" ROLE_ID IN (SELECT ROLE_ID FROM SYSROLEUSER WHERE USER_ID=@UserID)");
            sysroleModels _OneData = DbHelp.QueryOne<sysroleModels>(@sbsql.ToString(), new { UserID = _UserID }, null, false, null, System.Data.CommandType.Text);
            return _OneData;
        }
        /// <summary>
        /// 查询分页
        /// <summary>
        public multiplePageModel<sysroleModels> SelectMultiple(sysroleModels _Wheresysrole, Dictionary<string, string> _Sort, int _Limit, int _Offset)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT COUNT(1)");
            sbsql.Append(" FROM SYSROLE");
            sbsql.Append(" WHERE 1=1");
            string sqlWhere = GetWhere(_Wheresysrole);
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sbsql.Append(sqlWhere);
            }
            sbsql.Append(";");
            sbsql.Append(" SELECT ");
            sbsql.Append(" ROLE_ID,ROLE_CODE,ROLE_NAME,ROLE_DESCRIPTION,ROLE_CREATEDATE");
            sbsql.Append(" FROM SYSROLE");
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
            IEnumerable<sysroleModels> _QueryData = DbHelp.QueryMultiple<sysroleModels>(@sbsql.ToString(), out totalCount, _Wheresysrole);
            multiplePageModel<sysroleModels> multipleData = new multiplePageModel<sysroleModels>();
            multipleData.TotalNum = totalCount;
            multipleData.Items = _QueryData.ToList();
            return multipleData;
        }

        /// <summary>
        /// 查询第一行第一列
        /// <summary>
        public object SelectScalar(string _ColumnName,sysroleModels _Wheresysrole, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT "+_ColumnName);
            sbsql.Append(" FROM SYSROLE");
            sbsql.Append(" WHERE 1=1 ");
            if(_WhereType==null)
            {
                if (_Wheresysrole != null)
                {
                    sbsql.Append(GetWhere(_Wheresysrole));
                }
            }
            object _ScalarData = DbHelp.ExecuteScalar<object>(@sbsql.ToString(), _Wheresysrole);
            return _ScalarData;
        }

        /// <summary>
        /// 新增
        /// <summary>
        public int Insert(sysroleModels _Insertsysrole)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" INSERT INTO SYSROLE (");
            sbsql.Append(" ROLE_ID,ROLE_CODE,ROLE_NAME,ROLE_DESCRIPTION,ROLE_CREATEDATE");
            sbsql.Append(" ) VALUES (");
            sbsql.Append(" @Role_Id,@Role_Code,@Role_Name,@Role_Description,@Role_Createdate )");
            int _InsRow = DbHelp.Execute(@sbsql.ToString(), _Insertsysrole , null, null, System.Data.CommandType.Text);
            return _InsRow;
        }

        /// <summary>
        /// 主键修改
        /// <summary>
        public int UpdateByKey(sysroleModels _Updatesysrole)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" UPDATE SYSROLE SET");
            sbsql.Append(" ROLE_CODE =@Role_Code,");
            sbsql.Append(" ROLE_NAME =@Role_Name,");
            sbsql.Append(" ROLE_DESCRIPTION =@Role_Description,");
            sbsql.Append(" ROLE_CREATEDATE =@Role_Createdate");
            sbsql.Append(" WHERE");
            sbsql.Append(" ROLE_ID=@Role_Id");
            int _UpdateRow = DbHelp.Execute(@sbsql.ToString(), _Updatesysrole , null, null, System.Data.CommandType.Text);
            return _UpdateRow;
        }

        /// <summary>
        /// 主键删除
        /// <summary>
        public int DeleteByKey(sysroleModels _Wheresysrole)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" DELETE FROM SYSROLE");
            sbsql.Append(" WHERE");
            sbsql.Append(" ROLE_ID=@Role_Id");
            int _DelRow = DbHelp.Execute(@sbsql.ToString(), _Wheresysrole , null, null, System.Data.CommandType.Text);
            return _DelRow;
        }

        /// <summary>
        /// 条件删除
        /// <summary>
        public int DeleteByWhere(sysroleModels _Wheresysrole, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" DELETE FROM SYSROLE");
            sbsql.Append(" WHERE 1=1 ");
            if(_WhereType==null)
            {
                if (_Wheresysrole != null)
                {
                    sbsql.Append(GetWhere(_Wheresysrole));
                }
            }
            int _DelRow = DbHelp.Execute(@sbsql.ToString(), _Wheresysrole , null, null, System.Data.CommandType.Text);
            return _DelRow;
        }

        /// <summary>
        /// where条件
        /// <summary>
        private string GetWhere(sysroleModels _Wheresysrole)
        {
            StringBuilder sbwhere = new StringBuilder();
            if(_Wheresysrole != null)
            {
                if (!string.IsNullOrEmpty(_Wheresysrole.Role_Id))
                {
                    sbwhere.Append(" AND  ROLE_ID=@Role_Id");
                }
                if (!string.IsNullOrEmpty(_Wheresysrole.Role_Code))
                {
                    sbwhere.Append(" AND  ROLE_CODE LIKE CONCAT('%',@Role_Code,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysrole.Role_Name))
                {
                    sbwhere.Append(" AND  ROLE_NAME LIKE CONCAT('%',@Role_Name,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysrole.Role_Description))
                {
                    sbwhere.Append(" AND  ROLE_DESCRIPTION LIKE CONCAT('%',@Role_Description,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysrole.Role_Createdate))
                {
                    sbwhere.Append(" AND  ROLE_CREATEDATE LIKE CONCAT('%',@Role_Createdate,'%')");
                }
            }
            return sbwhere.ToString();
        }
    }
}
