using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MCL.Management.Models;
using DataAccess;

namespace MCL.Management.DAL
{
    public class sysmenuDAL
    {
        /// <summary>
        /// 是否存在数据
        /// <summary>
        public int IsExist(sysmenuModels _Wheresysmenu)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT COUNT(1)");
            sbsql.Append(" FROM SYSMENU");
            sbsql.Append(" WHERE 1=1");
            if (_Wheresysmenu != null)
            {
                sbsql.Append(GetWhere(_Wheresysmenu));
            }
            object _ScalarData = DbHelp.ExecuteScalar<object>(@sbsql.ToString(), _Wheresysmenu);
            return Convert.ToInt32(_ScalarData);
        }

        /// <summary>
        /// 查看全部
        /// <summary>
        public List<sysmenuModels> selectAll()
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" MENU_ID,MENU_CODE,MENU_NAME,MENU_PARENTCODE,MENU_CATEGORYLD,MENU_IMAGEINDEX,");
            sbsql.Append(" MENU_NAVIGATEURL,MENU_TARGET,MENU_SORT,MENU_DELETEMARK,MENU_DESCRIPTION");
            sbsql.Append(" FROM SYSMENU WHERE MENU_DELETEMARK='1'");
            IEnumerable<sysmenuModels> _AllData = DbHelp.Query<sysmenuModels>(@sbsql.ToString(), null , null, false, null, System.Data.CommandType.Text);
            return _AllData.ToList();
        }

        /// <summary>
        /// 根据条件查询
        /// <summary>
        public List<sysmenuModels> SelectByWhere(sysmenuModels _Wheresysmenu, Dictionary<string,string> _Sort, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" MENU_ID,MENU_CODE,MENU_NAME,MENU_PARENTCODE,MENU_CATEGORYLD,MENU_IMAGEINDEX,");
            sbsql.Append(" MENU_NAVIGATEURL,MENU_TARGET,MENU_SORT,MENU_DELETEMARK,MENU_DESCRIPTION");
            sbsql.Append(" FROM SYSMENU");
            sbsql.Append(" WHERE 1=1");
            if(_WhereType==null)
            {
                string sqlWhere = GetWhere(_Wheresysmenu);
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
            IEnumerable<sysmenuModels> _WhereData = DbHelp.Query<sysmenuModels>(@sbsql.ToString(), _Wheresysmenu , null, false, null, System.Data.CommandType.Text);
            return _WhereData.ToList();
        }

        /// <summary>
        /// 主键查询
        /// <summary>
        public sysmenuModels SelectByKey(sysmenuModels _Wheresysmenu)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" MENU_ID,MENU_CODE,MENU_NAME,MENU_PARENTCODE,MENU_CATEGORYLD,MENU_IMAGEINDEX,");
            sbsql.Append(" MENU_NAVIGATEURL,MENU_TARGET,MENU_SORT,MENU_DELETEMARK,MENU_DESCRIPTION");
            sbsql.Append(" FROM SYSMENU");
            sbsql.Append(" WHERE");
            sbsql.Append(" MENU_ID=@Menu_Id");
            sysmenuModels _OneData = DbHelp.QueryOne<sysmenuModels>(@sbsql.ToString(), _Wheresysmenu , null, false, null, System.Data.CommandType.Text);
            return _OneData;
        }

        /// <summary>
        /// 查询分页
        /// <summary>
        public multiplePageModel<sysmenuModels> SelectMultiple(sysmenuModels _Wheresysmenu, Dictionary<string, string> _Sort, int _Limit, int _Offset)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT COUNT(1)");
            sbsql.Append(" FROM SYSMENU");
            sbsql.Append(" WHERE 1=1");
            string sqlWhere = GetWhere(_Wheresysmenu);
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sbsql.Append(sqlWhere);
            }
            sbsql.Append(";");
            sbsql.Append(" SELECT ");
            sbsql.Append(" MENU_ID,MENU_CODE,MENU_NAME,MENU_PARENTCODE,MENU_CATEGORYLD,MENU_IMAGEINDEX,");
            sbsql.Append(" MENU_NAVIGATEURL,MENU_TARGET,MENU_SORT,MENU_DELETEMARK,MENU_DESCRIPTION");
            sbsql.Append(" FROM SYSMENU");
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
            IEnumerable<sysmenuModels> _QueryData = DbHelp.QueryMultiple<sysmenuModels>(@sbsql.ToString(), out totalCount, _Wheresysmenu);
            multiplePageModel<sysmenuModels> multipleData = new multiplePageModel<sysmenuModels>();
            multipleData.TotalNum = totalCount;
            multipleData.Items = _QueryData.ToList();
            return multipleData;
        }

        /// <summary>
        /// 查询第一行第一列
        /// <summary>
        public object SelectScalar(string _ColumnName,sysmenuModels _Wheresysmenu, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT "+_ColumnName);
            sbsql.Append(" FROM SYSMENU");
            sbsql.Append(" WHERE 1=1 ");
            if(_WhereType==null)
            {
                if (_Wheresysmenu != null)
                {
                    sbsql.Append(GetWhere(_Wheresysmenu));
                }
            }
            object _ScalarData = DbHelp.ExecuteScalar<object>(@sbsql.ToString(), _Wheresysmenu);
            return _ScalarData;
        }

        /// <summary>
        /// 新增
        /// <summary>
        public int Insert(sysmenuModels _Insertsysmenu)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" INSERT INTO SYSMENU (");
            sbsql.Append(" MENU_ID,MENU_CODE,MENU_NAME,MENU_PARENTCODE,MENU_CATEGORYLD,MENU_IMAGEINDEX,");
            sbsql.Append(" MENU_NAVIGATEURL,MENU_TARGET,MENU_SORT,MENU_DELETEMARK,MENU_DESCRIPTION");
            sbsql.Append(" ) VALUES (");
            sbsql.Append(" @Menu_Id,@Menu_Code,@Menu_Name,@Menu_Parentcode,@Menu_Categoryld,@Menu_Imageindex,");
            sbsql.Append(" @Menu_Navigateurl,@Menu_Target,@Menu_Sort,@Menu_Deletemark,@Menu_Description,");
            int _InsRow = DbHelp.Execute(@sbsql.ToString(), _Insertsysmenu , null, null, System.Data.CommandType.Text);
            return _InsRow;
        }

        /// <summary>
        /// 主键修改
        /// <summary>
        public int UpdateByKey(sysmenuModels _Updatesysmenu)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" UPDATE SYSMENU SET");
            sbsql.Append(" MENU_CODE =@Menu_Code,");
            sbsql.Append(" MENU_NAME =@Menu_Name,");
            sbsql.Append(" MENU_PARENTCODE =@Menu_Parentcode,");
            sbsql.Append(" MENU_CATEGORYLD =@Menu_Categoryld,");
            sbsql.Append(" MENU_IMAGEINDEX =@Menu_Imageindex,");
            sbsql.Append(" MENU_NAVIGATEURL =@Menu_Navigateurl,");
            sbsql.Append(" MENU_TARGET =@Menu_Target,");
            sbsql.Append(" MENU_SORT =@Menu_Sort,");
            sbsql.Append(" MENU_DELETEMARK =@Menu_Deletemark,");
            sbsql.Append(" MENU_DESCRIPTION =@Menu_Description");
            sbsql.Append(" WHERE");
            sbsql.Append(" MENU_ID=@Menu_Id");
            int _UpdateRow = DbHelp.Execute(@sbsql.ToString(), _Updatesysmenu , null, null, System.Data.CommandType.Text);
            return _UpdateRow;
        }

        /// <summary>
        /// 主键删除
        /// <summary>
        public int DeleteByKey(sysmenuModels _Wheresysmenu)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" DELETE FROM SYSMENU");
            sbsql.Append(" WHERE");
            sbsql.Append(" MENU_ID=@Menu_Id");
            int _DelRow = DbHelp.Execute(@sbsql.ToString(), _Wheresysmenu , null, null, System.Data.CommandType.Text);
            return _DelRow;
        }

        /// <summary>
        /// 条件删除
        /// <summary>
        public int DeleteByWhere(sysmenuModels _Wheresysmenu, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" DELETE FROM SYSMENU");
            sbsql.Append(" WHERE 1=1 ");
            if(_WhereType==null)
            {
                if (_Wheresysmenu != null)
                {
                    sbsql.Append(GetWhere(_Wheresysmenu));
                }
            }
            int _DelRow = DbHelp.Execute(@sbsql.ToString(), _Wheresysmenu , null, null, System.Data.CommandType.Text);
            return _DelRow;
        }

        /// <summary>
        /// where条件
        /// <summary>
        private string GetWhere(sysmenuModels _Wheresysmenu)
        {
            StringBuilder sbwhere = new StringBuilder();
            if(_Wheresysmenu != null)
            {
                if (!string.IsNullOrEmpty(_Wheresysmenu.Menu_Id))
                {
                    sbwhere.Append(" AND  MENU_ID=@Menu_Id");
                }
                if (!string.IsNullOrEmpty(_Wheresysmenu.Menu_Code))
                {
                    sbwhere.Append(" AND  MENU_CODE CONCAT('%',@Menu_Code,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysmenu.Menu_Name))
                {
                    sbwhere.Append(" AND  MENU_NAME CONCAT('%',@Menu_Name,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysmenu.Menu_Parentcode))
                {
                    sbwhere.Append(" AND  MENU_PARENTCODE CONCAT('%',@Menu_Parentcode,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysmenu.Menu_Categoryld))
                {
                    sbwhere.Append(" AND  MENU_CATEGORYLD CONCAT('%',@Menu_Categoryld,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysmenu.Menu_Imageindex))
                {
                    sbwhere.Append(" AND  MENU_IMAGEINDEX CONCAT('%',@Menu_Imageindex,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysmenu.Menu_Navigateurl))
                {
                    sbwhere.Append(" AND  MENU_NAVIGATEURL CONCAT('%',@Menu_Navigateurl,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysmenu.Menu_Target))
                {
                    sbwhere.Append(" AND  MENU_TARGET CONCAT('%',@Menu_Target,'%')");
                }
                if (_Wheresysmenu.Menu_Sort != null)
                {
                    sbwhere.Append(" AND  MENU_SORT=@Menu_Sort");
                }
                if (_Wheresysmenu.Menu_Deletemark != null)
                {
                    sbwhere.Append(" AND  MENU_DELETEMARK=@Menu_Deletemark");
                }
                if (!string.IsNullOrEmpty(_Wheresysmenu.Menu_Description))
                {
                    sbwhere.Append(" AND  MENU_DESCRIPTION CONCAT('%',@Menu_Description,'%')");
                }
            }
            return sbwhere.ToString();
        }
    }
}
