using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MCL.Management.Models;
using DataAccess;

namespace MCL.Management.DAL
{
    public class sysuserDAL
    {
        /// <summary>
        /// 是否存在数据
        /// <summary>
        public int IsExist(sysuserModels _Wheresysuser)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT COUNT(1)");
            sbsql.Append(" FROM SYSUSER");
            sbsql.Append(" WHERE 1=1");
            if (_Wheresysuser != null)
            {
                sbsql.Append(GetWhere(_Wheresysuser));
            }
            object _ScalarData = DbHelp.ExecuteScalar<object>(@sbsql.ToString(), _Wheresysuser);
            return Convert.ToInt32(_ScalarData);
        }

        /// <summary>
        /// 查看全部
        /// <summary>
        public List<sysuserModels> selectAll()
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" USER_ID,USER_CODE,USER_NAME,USER_IMAGEURL,USER_SEX,USR_BIRTHDAY,");
            sbsql.Append(" USER_AGE,USER_IDCARD,USER_BANKCODE,USER_EMAIL,USER_MOBILE,USER_OICQ,");
            sbsql.Append(" USER_SCHOOL,USER_ENABLED,USER_DESCRIPTION,USER_CREATEDATE");
            sbsql.Append(" FROM SYSUSER");
            IEnumerable<sysuserModels> _AllData = DbHelp.Query<sysuserModels>(@sbsql.ToString(), null , null, false, null, System.Data.CommandType.Text);
            return _AllData.ToList();
        }

        /// <summary>
        /// 根据条件查询
        /// <summary>
        public List<sysuserModels> SelectByWhere(sysuserModels _Wheresysuser, Dictionary<string,string> _Sort, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" USER_ID,USER_CODE,USER_NAME,USER_IMAGEURL,USER_SEX,USR_BIRTHDAY,");
            sbsql.Append(" USER_AGE,USER_IDCARD,USER_BANKCODE,USER_EMAIL,USER_MOBILE,USER_OICQ,");
            sbsql.Append(" USER_SCHOOL,USER_ENABLED,USER_DESCRIPTION,USER_CREATEDATE");
            sbsql.Append(" FROM SYSUSER");
            sbsql.Append(" WHERE 1=1");
            if(_WhereType==null)
            {
                string sqlWhere = GetWhere(_Wheresysuser);
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
            IEnumerable<sysuserModels> _WhereData = DbHelp.Query<sysuserModels>(@sbsql.ToString(), _Wheresysuser , null, false, null, System.Data.CommandType.Text);
            return _WhereData.ToList();
        }

        /// <summary>
        /// 主键查询
        /// <summary>
        public sysuserModels SelectByKey(sysuserModels _Wheresysuser)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT ");
            sbsql.Append(" USER_ID,USER_CODE,USER_NAME,USER_IMAGEURL,USER_SEX,USR_BIRTHDAY,");
            sbsql.Append(" USER_AGE,USER_IDCARD,USER_BANKCODE,USER_EMAIL,USER_MOBILE,USER_OICQ,");
            sbsql.Append(" USER_SCHOOL,USER_ENABLED,USER_DESCRIPTION,USER_CREATEDATE");
            sbsql.Append(" FROM SYSUSER");
            sbsql.Append(" WHERE");
            sbsql.Append(" USER_ID=@User_Id");
            sysuserModels _OneData = DbHelp.QueryOne<sysuserModels>(@sbsql.ToString(), _Wheresysuser , null, false, null, System.Data.CommandType.Text);
            return _OneData;
        }

        /// <summary>
        /// 查询分页
        /// <summary>
        public multiplePageModel<sysuserModels> SelectMultiple(sysuserModels _Wheresysuser, Dictionary<string, string> _Sort, int _Limit, int _Offset)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT COUNT(1)");
            sbsql.Append(" FROM SYSUSER");
            sbsql.Append(" WHERE 1=1");
            string sqlWhere = GetWhere(_Wheresysuser);
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sbsql.Append(sqlWhere);
            }
            sbsql.Append(";");
            sbsql.Append(" SELECT ");
            sbsql.Append(" USER_ID,USER_CODE,USER_NAME,USER_IMAGEURL,USER_SEX,USR_BIRTHDAY,");
            sbsql.Append(" USER_AGE,USER_IDCARD,USER_BANKCODE,USER_EMAIL,USER_MOBILE,USER_OICQ,");
            sbsql.Append(" USER_SCHOOL,USER_ENABLED,USER_DESCRIPTION,USER_CREATEDATE");
            sbsql.Append(" FROM SYSUSER");
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
            IEnumerable<sysuserModels> _QueryData = DbHelp.QueryMultiple<sysuserModels>(@sbsql.ToString(), out totalCount, _Wheresysuser);
            multiplePageModel<sysuserModels> multipleData = new multiplePageModel<sysuserModels>();
            multipleData.TotalNum = totalCount;
            multipleData.Items = _QueryData.ToList();
            return multipleData;
        }

        /// <summary>
        /// 查询第一行第一列
        /// <summary>
        public object SelectScalar(string _ColumnName,sysuserModels _Wheresysuser, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" SELECT "+_ColumnName);
            sbsql.Append(" FROM SYSUSER");
            sbsql.Append(" WHERE 1=1 ");
            if(_WhereType==null)
            {
                if (_Wheresysuser != null)
                {
                    sbsql.Append(GetWhere(_Wheresysuser));
                }
            }
            object _ScalarData = DbHelp.ExecuteScalar<object>(@sbsql.ToString(), _Wheresysuser);
            return _ScalarData;
        }

        /// <summary>
        /// 新增
        /// <summary>
        public int Insert(sysuserModels _Insertsysuser)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" INSERT INTO SYSUSER (");
            sbsql.Append(" USER_ID,USER_CODE,USER_NAME,USER_IMAGEURL,USER_SEX,USR_BIRTHDAY,");
            sbsql.Append(" USER_AGE,USER_IDCARD,USER_BANKCODE,USER_EMAIL,USER_MOBILE,USER_OICQ,");
            sbsql.Append(" USER_SCHOOL,USER_ENABLED,USER_DESCRIPTION,USER_CREATEDATE");
            sbsql.Append(" ) VALUES (");
            sbsql.Append(" @User_Id,@User_Code,@User_Name,@User_Imageurl,@User_Sex,@Usr_Birthday,");
            sbsql.Append(" @User_Age,@User_Idcard,@User_Bankcode,@User_Email,@User_Mobile,");
            sbsql.Append(" @User_Oicq,@User_School,@User_Enabled,@User_Description,@User_Createdate,");
            int _InsRow = DbHelp.Execute(@sbsql.ToString(), _Insertsysuser , null, null, System.Data.CommandType.Text);
            return _InsRow;
        }

        /// <summary>
        /// 主键修改
        /// <summary>
        public int UpdateByKey(sysuserModels _Updatesysuser)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" UPDATE SYSUSER SET");
            sbsql.Append(" USER_CODE =@User_Code,");
            sbsql.Append(" USER_NAME =@User_Name,");
            sbsql.Append(" USER_IMAGEURL =@User_Imageurl,");
            sbsql.Append(" USER_SEX =@User_Sex,");
            sbsql.Append(" USR_BIRTHDAY =@Usr_Birthday,");
            sbsql.Append(" USER_AGE =@User_Age,");
            sbsql.Append(" USER_IDCARD =@User_Idcard,");
            sbsql.Append(" USER_BANKCODE =@User_Bankcode,");
            sbsql.Append(" USER_EMAIL =@User_Email,");
            sbsql.Append(" USER_MOBILE =@User_Mobile,");
            sbsql.Append(" USER_OICQ =@User_Oicq,");
            sbsql.Append(" USER_SCHOOL =@User_School,");
            sbsql.Append(" USER_ENABLED =@User_Enabled,");
            sbsql.Append(" USER_DESCRIPTION =@User_Description,");
            sbsql.Append(" USER_CREATEDATE =@User_Createdate");
            sbsql.Append(" WHERE");
            sbsql.Append(" USER_ID=@User_Id");
            int _UpdateRow = DbHelp.Execute(@sbsql.ToString(), _Updatesysuser , null, null, System.Data.CommandType.Text);
            return _UpdateRow;
        }

        /// <summary>
        /// 主键删除
        /// <summary>
        public int DeleteByKey(sysuserModels _Wheresysuser)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" DELETE FROM SYSUSER");
            sbsql.Append(" WHERE");
            sbsql.Append(" USER_ID=@User_Id");
            int _DelRow = DbHelp.Execute(@sbsql.ToString(), _Wheresysuser , null, null, System.Data.CommandType.Text);
            return _DelRow;
        }

        /// <summary>
        /// 条件删除
        /// <summary>
        public int DeleteByWhere(sysuserModels _Wheresysuser, object _WhereType)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" DELETE FROM SYSUSER");
            sbsql.Append(" WHERE 1=1 ");
            if(_WhereType==null)
            {
                if (_Wheresysuser != null)
                {
                    sbsql.Append(GetWhere(_Wheresysuser));
                }
            }
            int _DelRow = DbHelp.Execute(@sbsql.ToString(), _Wheresysuser , null, null, System.Data.CommandType.Text);
            return _DelRow;
        }

        /// <summary>
        /// where条件
        /// <summary>
        private string GetWhere(sysuserModels _Wheresysuser)
        {
            StringBuilder sbwhere = new StringBuilder();
            if(_Wheresysuser != null)
            {
                if (!string.IsNullOrEmpty(_Wheresysuser.User_Id))
                {
                    sbwhere.Append(" AND  USER_ID=@User_Id");
                }
                if (!string.IsNullOrEmpty(_Wheresysuser.User_Code))
                {
                    sbwhere.Append(" AND  USER_CODE CONCAT('%',@User_Code,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysuser.User_Name))
                {
                    sbwhere.Append(" AND  USER_NAME CONCAT('%',@User_Name,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysuser.User_Imageurl))
                {
                    sbwhere.Append(" AND  USER_IMAGEURL CONCAT('%',@User_Imageurl,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysuser.User_Sex))
                {
                    sbwhere.Append(" AND  USER_SEX CONCAT('%',@User_Sex,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysuser.Usr_Birthday))
                {
                    sbwhere.Append(" AND  USR_BIRTHDAY CONCAT('%',@Usr_Birthday,'%')");
                }
                if (_Wheresysuser.User_Age != null)
                {
                    sbwhere.Append(" AND  USER_AGE=@User_Age");
                }
                if (!string.IsNullOrEmpty(_Wheresysuser.User_Idcard))
                {
                    sbwhere.Append(" AND  USER_IDCARD CONCAT('%',@User_Idcard,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysuser.User_Bankcode))
                {
                    sbwhere.Append(" AND  USER_BANKCODE CONCAT('%',@User_Bankcode,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysuser.User_Email))
                {
                    sbwhere.Append(" AND  USER_EMAIL CONCAT('%',@User_Email,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysuser.User_Mobile))
                {
                    sbwhere.Append(" AND  USER_MOBILE CONCAT('%',@User_Mobile,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysuser.User_Oicq))
                {
                    sbwhere.Append(" AND  USER_OICQ CONCAT('%',@User_Oicq,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysuser.User_School))
                {
                    sbwhere.Append(" AND  USER_SCHOOL CONCAT('%',@User_School,'%')");
                }
                if (_Wheresysuser.User_Enabled != null)
                {
                    sbwhere.Append(" AND  USER_ENABLED=@User_Enabled");
                }
                if (!string.IsNullOrEmpty(_Wheresysuser.User_Description))
                {
                    sbwhere.Append(" AND  USER_DESCRIPTION CONCAT('%',@User_Description,'%')");
                }
                if (!string.IsNullOrEmpty(_Wheresysuser.User_Createdate))
                {
                    sbwhere.Append(" AND  USER_CREATEDATE CONCAT('%',@User_Createdate,'%')");
                }
            }
            return sbwhere.ToString();
        }
    }
}
