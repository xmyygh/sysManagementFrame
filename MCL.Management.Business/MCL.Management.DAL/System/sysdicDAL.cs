using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MCL.Management.Models;
using DataAccess;

namespace MCL.Management.DAL
{
    public class sysdicDAL
    {
        /// <summary>
        /// 是否存在数据
        /// <summary>
        public int IsExist(sysdicModels _Wheresysdic)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT COUNT(1)");
            sbsql.Append(" FROM SYSDIC");
            sbsql.Append(" WHERE 1=1");
            if (_Wheresysdic != null)
            {
                sbsql.Append(GetWhere(_Wheresysdic));
            }
            object _ScalarData = DbHelp.ExecuteScalar<object>(@sbsql.ToString(), _Wheresysdic);
            return Convert.ToInt32(_ScalarData);
        }

        /// <summary>
        /// 查看全部
        /// <summary>
        public List<sysdicModels> selectAll()
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" SYSDIC_ID,SYSDIC_TYPE,SYSDIC_CODE,SYSDIC_NAME,SYSDIC_ORDER,SYSDIC_ENABLED,");
            sbsql.Append(" SYSDIC_DESCRIPTION");
            sbsql.Append(" FROM SYSDIC");
            IEnumerable<sysdicModels> _AllData = DbHelp.Query<sysdicModels>(@sbsql.ToString(), null , null, false, null, System.Data.CommandType.Text);
            return _AllData.ToList();
        }

        /// <summary>
        /// 根据条件查询
        /// <summary>
        public List<sysdicModels> SelectByWhere(sysdicModels _Wheresysdic, Dictionary<string,string> _Sort, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" SYSDIC_ID,SYSDIC_TYPE,SYSDIC_CODE,SYSDIC_NAME,SYSDIC_ORDER,SYSDIC_ENABLED,");
            sbsql.Append(" SYSDIC_DESCRIPTION");
            sbsql.Append(" FROM SYSDIC");
            sbsql.Append(" WHERE 1=1");
            if(_WhereType==null)
            {
                string sqlWhere = GetWhere(_Wheresysdic);
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
            IEnumerable<sysdicModels> _WhereData = DbHelp.Query<sysdicModels>(@sbsql.ToString(), _Wheresysdic , null, false, null, System.Data.CommandType.Text);
            return _WhereData.ToList();
        }

        /// <summary>
        /// 主键查询
        /// <summary>
        public sysdicModels SelectByKey(sysdicModels _Wheresysdic)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" SYSDIC_ID,SYSDIC_TYPE,SYSDIC_CODE,SYSDIC_NAME,SYSDIC_ORDER,SYSDIC_ENABLED,");
            sbsql.Append(" SYSDIC_DESCRIPTION");
            sbsql.Append(" FROM SYSDIC");
            sbsql.Append(" WHERE");
            sbsql.Append(" SYSDIC_ID=@Sysdic_Id");
            sysdicModels _OneData = DbHelp.QueryOne<sysdicModels>(@sbsql.ToString(), _Wheresysdic , null, false, null, System.Data.CommandType.Text);
            return _OneData;
        }

        /// <summary>
        /// 查询分页
        /// <summary>
        public multiplePageModel<sysdicModels> SelectMultiple(sysdicModels _Wheresysdic, Dictionary<string, string> _Sort, int _Limit, int _Offset)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT COUNT(1)");
            sbsql.Append(" FROM SYSDIC");
            sbsql.Append(" WHERE 1=1");
            string sqlWhere = GetWhere(_Wheresysdic);
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sbsql.Append(sqlWhere);
            }
            sbsql.Append(";");
            sbsql.Append(" SELECT ");
            sbsql.Append(" SYSDIC_ID,SYSDIC_TYPE,SYSDIC_CODE,SYSDIC_NAME,SYSDIC_ORDER,SYSDIC_ENABLED,");
            sbsql.Append(" SYSDIC_DESCRIPTION");
            sbsql.Append(" FROM SYSDIC");
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
            IEnumerable<sysdicModels> _QueryData = DbHelp.QueryMultiple<sysdicModels>(@sbsql.ToString(), out totalCount, _Wheresysdic);
            multiplePageModel<sysdicModels> multipleData = new multiplePageModel<sysdicModels>();
            multipleData.TotalNum = totalCount;
            multipleData.Items = _QueryData.ToList();
            return multipleData;
        }

        /// <summary>
        /// 查询第一行第一列
        /// <summary>
        public object SelectScalar(string _ColumnName,sysdicModels _Wheresysdic, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT "+_ColumnName);
            sbsql.Append(" FROM SYSDIC");
            sbsql.Append(" WHERE 1=1 ");
            if(_WhereType==null)
            {
                if (_Wheresysdic != null)
                {
                    sbsql.Append(GetWhere(_Wheresysdic));
                }
            }
            object _ScalarData = DbHelp.ExecuteScalar<object>(@sbsql.ToString(), _Wheresysdic);
            return _ScalarData;
        }

        /// <summary>
        /// 新增
        /// <summary>
        public int Insert(sysdicModels _Insertsysdic)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" INSERT INTO SYSDIC (");
            sbsql.Append(" SYSDIC_ID,SYSDIC_TYPE,SYSDIC_CODE,SYSDIC_NAME,SYSDIC_ORDER,SYSDIC_ENABLED,");
            sbsql.Append(" SYSDIC_DESCRIPTION");
            sbsql.Append(" ) VALUES (");
            sbsql.Append(" @Sysdic_Id,@Sysdic_Type,@Sysdic_Code,@Sysdic_Name,@Sysdic_Order,@Sysdic_Enabled,");
            sbsql.Append(" @Sysdic_Description )");
            int _InsRow = DbHelp.Execute(@sbsql.ToString(), _Insertsysdic , null, null, System.Data.CommandType.Text);
            return _InsRow;
        }

        /// <summary>
        /// 主键修改
        /// <summary>
        public int UpdateByKey(sysdicModels _Updatesysdic)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" UPDATE SYSDIC SET");
            sbsql.Append(" SYSDIC_TYPE =@Sysdic_Type,");
            sbsql.Append(" SYSDIC_CODE =@Sysdic_Code,");
            sbsql.Append(" SYSDIC_NAME =@Sysdic_Name,");
            sbsql.Append(" SYSDIC_ORDER =@Sysdic_Order,");
            sbsql.Append(" SYSDIC_ENABLED =@Sysdic_Enabled,");
            sbsql.Append(" SYSDIC_DESCRIPTION =@Sysdic_Description");
            sbsql.Append(" WHERE");
            sbsql.Append(" SYSDIC_ID=@Sysdic_Id");
            int _UpdateRow = DbHelp.Execute(@sbsql.ToString(), _Updatesysdic , null, null, System.Data.CommandType.Text);
            return _UpdateRow;
        }

        /// <summary>
        /// 主键删除
        /// <summary>
        public int DeleteByKey(sysdicModels _Wheresysdic)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" DELETE FROM SYSDIC");
            sbsql.Append(" WHERE");
            sbsql.Append(" SYSDIC_ID=@Sysdic_Id");
            int _DelRow = DbHelp.Execute(@sbsql.ToString(), _Wheresysdic , null, null, System.Data.CommandType.Text);
            return _DelRow;
        }

        /// <summary>
        /// 条件删除
        /// <summary>
        public int DeleteByWhere(sysdicModels _Wheresysdic, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" DELETE FROM SYSDIC");
            sbsql.Append(" WHERE 1=1 ");
            if(_WhereType==null)
            {
                if (_Wheresysdic != null)
                {
                    sbsql.Append(GetWhere(_Wheresysdic));
                }
            }
            int _DelRow = DbHelp.Execute(@sbsql.ToString(), _Wheresysdic , null, null, System.Data.CommandType.Text);
            return _DelRow;
        }

        /// <summary>
        /// where条件
        /// <summary>
        private string GetWhere(sysdicModels _Wheresysdic)
        {
            StringBuilder sbwhere = new StringBuilder();
            if(_Wheresysdic != null)
            {
                if (!string.IsNullOrEmpty(_Wheresysdic.Sysdic_Id))
                {
                    sbwhere.Append(" AND  SYSDIC_ID=@Sysdic_Id");
                }
                if (!string.IsNullOrEmpty(_Wheresysdic.Sysdic_Type))
                {
                    sbwhere.Append(" AND  SYSDIC_TYPE CONCAT('%',@Sysdic_Type,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysdic.Sysdic_Code))
                {
                    sbwhere.Append(" AND  SYSDIC_CODE CONCAT('%',@Sysdic_Code,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysdic.Sysdic_Name))
                {
                    sbwhere.Append(" AND  SYSDIC_NAME CONCAT('%',@Sysdic_Name,'%')");
                }
                if (_Wheresysdic.Sysdic_Order != null)
                {
                    sbwhere.Append(" AND  SYSDIC_ORDER=@Sysdic_Order");
                }
                if (!string.IsNullOrEmpty(_Wheresysdic.Sysdic_Enabled))
                {
                    sbwhere.Append(" AND  SYSDIC_ENABLED CONCAT('%',@Sysdic_Enabled,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysdic.Sysdic_Description))
                {
                    sbwhere.Append(" AND  SYSDIC_DESCRIPTION CONCAT('%',@Sysdic_Description,'%')");
                }
            }
            return sbwhere.ToString();
        }
    }
}
