using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MCL.Management.Models;
using DataAccess;

namespace MCL.Management.DAL
{
    public class sysunitDAL
    {
        /// <summary>
        /// 是否存在数据
        /// <summary>
        public int IsExist(sysunitModels _Wheresysunit)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT COUNT(1)");
            sbsql.Append(" FROM SYSUNIT");
            sbsql.Append(" WHERE 1=1");
            if (_Wheresysunit != null)
            {
                sbsql.Append(GetWhere(_Wheresysunit));
            }
            object _ScalarData = DbHelp.ExecuteScalar<object>(@sbsql.ToString(), _Wheresysunit);
            return Convert.ToInt32(_ScalarData);
        }

        /// <summary>
        /// 查看全部
        /// <summary>
        public List<sysunitModels> selectAll()
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" UNIT_ID,UNTI_TYPE,UNIT_CODE,UNIT_NAME,UNIT_PARENTID,UNIT_DELETEMARK,");
            sbsql.Append(" UNIT_DESCRIPTION,UNIT_CREATEDATE");
            sbsql.Append(" FROM SYSUNIT");
            IEnumerable<sysunitModels> _AllData = DbHelp.Query<sysunitModels>(@sbsql.ToString(), null , null, false, null, System.Data.CommandType.Text);
            return _AllData.ToList();
        }

        /// <summary>
        /// 根据条件查询
        /// <summary>
        public List<sysunitModels> SelectByWhere(sysunitModels _Wheresysunit, Dictionary<string,string> _Sort, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" UNIT_ID,UNTI_TYPE,UNIT_CODE,UNIT_NAME,UNIT_PARENTID,UNIT_DELETEMARK,");
            sbsql.Append(" UNIT_DESCRIPTION,UNIT_CREATEDATE");
            sbsql.Append(" FROM SYSUNIT");
            sbsql.Append(" WHERE 1=1");
            if(_WhereType==null)
            {
                string sqlWhere = GetWhere(_Wheresysunit);
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
            IEnumerable<sysunitModels> _WhereData = DbHelp.Query<sysunitModels>(@sbsql.ToString(), _Wheresysunit , null, false, null, System.Data.CommandType.Text);
            return _WhereData.ToList();
        }

        /// <summary>
        /// 主键查询
        /// <summary>
        public sysunitModels SelectByKey(sysunitModels _Wheresysunit)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" UNIT_ID,UNTI_TYPE,UNIT_CODE,UNIT_NAME,UNIT_PARENTID,UNIT_DELETEMARK,");
            sbsql.Append(" UNIT_DESCRIPTION,UNIT_CREATEDATE");
            sbsql.Append(" FROM SYSUNIT");
            sbsql.Append(" WHERE");
            sbsql.Append(" UNIT_ID=@Unit_Id");
            sysunitModels _OneData = DbHelp.QueryOne<sysunitModels>(@sbsql.ToString(), _Wheresysunit , null, false, null, System.Data.CommandType.Text);
            return _OneData;
        }
       
        /// <summary>
        /// 查询分页
        /// <summary>
        public multiplePageModel<sysunitModels> SelectMultiple(sysunitModels _Wheresysunit, Dictionary<string, string> _Sort, int _Limit, int _Offset)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT COUNT(1)");
            sbsql.Append(" FROM SYSUNIT");
            sbsql.Append(" WHERE 1=1");
            string sqlWhere = GetWhere(_Wheresysunit);
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sbsql.Append(sqlWhere);
            }
            sbsql.Append(";");
            sbsql.Append(" SELECT ");
            sbsql.Append(" UNIT_ID,UNTI_TYPE,UNIT_CODE,UNIT_NAME,UNIT_PARENTID,UNIT_DELETEMARK,");
            sbsql.Append(" UNIT_DESCRIPTION,UNIT_CREATEDATE");
            sbsql.Append(" FROM SYSUNIT");
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
            IEnumerable<sysunitModels> _QueryData = DbHelp.QueryMultiple<sysunitModels>(@sbsql.ToString(), out totalCount, _Wheresysunit);
            multiplePageModel<sysunitModels> multipleData = new multiplePageModel<sysunitModels>();
            multipleData.TotalNum = totalCount;
            multipleData.Items = _QueryData.ToList();
            return multipleData;
        }

        /// <summary>
        /// 查询第一行第一列
        /// <summary>
        public object SelectScalar(string _ColumnName,sysunitModels _Wheresysunit, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT "+_ColumnName);
            sbsql.Append(" FROM SYSUNIT");
            sbsql.Append(" WHERE 1=1 ");
            if(_WhereType==null)
            {
                if (_Wheresysunit != null)
                {
                    sbsql.Append(GetWhere(_Wheresysunit));
                }
            }
            object _ScalarData = DbHelp.ExecuteScalar<object>(@sbsql.ToString(), _Wheresysunit);
            return _ScalarData;
        }

        /// <summary>
        /// 新增
        /// <summary>
        public int Insert(sysunitModels _Insertsysunit)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" INSERT INTO SYSUNIT (");
            sbsql.Append(" UNIT_ID,UNTI_TYPE,UNIT_CODE,UNIT_NAME,UNIT_PARENTID,UNIT_DELETEMARK,");
            sbsql.Append(" UNIT_DESCRIPTION,UNIT_CREATEDATE");
            sbsql.Append(" ) VALUES (");
            sbsql.Append(" @Unit_Id,@Unti_Type,@Unit_Code,@Unit_Name,@Unit_Parentid,@Unit_Deletemark,");
            sbsql.Append(" @Unit_Description,@Unit_Createdate )");
            int _InsRow = DbHelp.Execute(@sbsql.ToString(), _Insertsysunit , null, null, System.Data.CommandType.Text);
            return _InsRow;
        }

        /// <summary>
        /// 主键修改
        /// <summary>
        public int UpdateByKey(sysunitModels _Updatesysunit)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" UPDATE SYSUNIT SET");
            sbsql.Append(" UNTI_TYPE =@Unti_Type,");
            sbsql.Append(" UNIT_CODE =@Unit_Code,");
            sbsql.Append(" UNIT_NAME =@Unit_Name,");
            sbsql.Append(" UNIT_PARENTID =@Unit_Parentid,");
            sbsql.Append(" UNIT_DELETEMARK =@Unit_Deletemark,");
            sbsql.Append(" UNIT_DESCRIPTION =@Unit_Description,");
            sbsql.Append(" UNIT_CREATEDATE =@Unit_Createdate");
            sbsql.Append(" WHERE");
            sbsql.Append(" UNIT_ID=@Unit_Id");
            int _UpdateRow = DbHelp.Execute(@sbsql.ToString(), _Updatesysunit , null, null, System.Data.CommandType.Text);
            return _UpdateRow;
        }

        /// <summary>
        /// 主键删除
        /// <summary>
        public int DeleteByKey(sysunitModels _Wheresysunit)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" DELETE FROM SYSUNIT");
            sbsql.Append(" WHERE");
            sbsql.Append(" UNIT_ID=@Unit_Id");
            int _DelRow = DbHelp.Execute(@sbsql.ToString(), _Wheresysunit , null, null, System.Data.CommandType.Text);
            return _DelRow;
        }

        /// <summary>
        /// 条件删除
        /// <summary>
        public int DeleteByWhere(sysunitModels _Wheresysunit, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" DELETE FROM SYSUNIT");
            sbsql.Append(" WHERE 1=1 ");
            if(_WhereType==null)
            {
                if (_Wheresysunit != null)
                {
                    sbsql.Append(GetWhere(_Wheresysunit));
                }
            }
            int _DelRow = DbHelp.Execute(@sbsql.ToString(), _Wheresysunit , null, null, System.Data.CommandType.Text);
            return _DelRow;
        }

        /// <summary>
        /// where条件
        /// <summary>
        private string GetWhere(sysunitModels _Wheresysunit)
        {
            StringBuilder sbwhere = new StringBuilder();
            if(_Wheresysunit != null)
            {
                if (!string.IsNullOrEmpty(_Wheresysunit.Unit_Id))
                {
                    sbwhere.Append(" AND  UNIT_ID=@Unit_Id");
                }
                if (!string.IsNullOrEmpty(_Wheresysunit.Unti_Type))
                {
                    sbwhere.Append(" AND  UNTI_TYPE LIKE CONCAT('%',@Unti_Type,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysunit.Unit_Code))
                {
                    sbwhere.Append(" AND  UNIT_CODE LIKE CONCAT('%',@Unit_Code,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysunit.Unit_Name))
                {
                    sbwhere.Append(" AND  UNIT_NAME LIKE CONCAT('%',@Unit_Name,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysunit.Unit_Parentid))
                {
                    sbwhere.Append(" AND  UNIT_PARENTID=@Unit_Parentid");
                }
                if (_Wheresysunit.Unit_Deletemark != null)
                {
                    sbwhere.Append(" AND  UNIT_DELETEMARK=@Unit_Deletemark");
                }
                if (!string.IsNullOrEmpty(_Wheresysunit.Unit_Description))
                {
                    sbwhere.Append(" AND  UNIT_DESCRIPTION LIKE CONCAT('%',@Unit_Description,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysunit.Unit_Createdate))
                {
                    sbwhere.Append(" AND  UNIT_CREATEDATE LIKE CONCAT('%',@Unit_Createdate,'%')");
                }
            }
            return sbwhere.ToString();
        }
    }
}
