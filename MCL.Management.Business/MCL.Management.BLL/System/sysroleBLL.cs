using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MCL.Management.DAL;
using MCL.Management.Models;

namespace MCL.Management.BLL
{
    public class sysroleBLL
    {
        sysroleDAL sysroledal = new sysroleDAL(); 

        /// <summary>
        /// �Ƿ��������
        /// <summary>
        public int IsExist(sysroleModels _Wheresysrole)
        {
            return sysroledal.IsExist(_Wheresysrole);
        }

        /// <summary>
        /// �鿴ȫ��
        /// <summary>
        public List<sysroleModels> selectAll()
        {
            return sysroledal.selectAll();
        }

        /// <summary>
        /// ����������ѯ
        /// <summary>
        public List<sysroleModels> SelectByWhere(sysroleModels _Wheresysrole , Dictionary<string, string> _Sort, object _WhereType = null)
        {
            return sysroledal.SelectByWhere(_Wheresysrole, _Sort, _WhereType);

        }

        /// <summary>
        /// ������ѯ
        /// <summary>
        public sysroleModels SelectByKey(sysroleModels _Wheresysrole)
        {
            return sysroledal.SelectByKey(_Wheresysrole);
        }

        /// <summary>
        /// �û�id��ѯ��ɫ
        /// </summary>
        /// <param name="_UserID">�û�id</param>
        /// <returns></returns>
        public sysroleModels SelectByUserID(string _UserID)
        {
            return sysroledal.SelectByUserID(_UserID);
        }

        /// <summary>
        /// ��ҳ��ѯ
        /// <summary>
        public multiplePageModel<sysroleModels> SelectMultiple(sysroleModels _Wheresysrole, Dictionary<string, string> _Sort, int _Limit, int _Offset)
        {
            return sysroledal.SelectMultiple(_Wheresysrole, _Sort, _Limit, _Offset);
        }

        /// <summary>
        /// ��ѯ��һ�е�һ��
        /// <summary>
        public object SelectScalar(string _ColumnName,sysroleModels _Wheresysrole, object _WhereType = null)
        {
            return sysroledal.SelectScalar(_ColumnName, _Wheresysrole, _WhereType);
        }

        /// <summary>
        /// ����
        /// <summary>
        public string Insert(sysroleModels _Insertsysrole)
        {
            string id = SQID.GetID();
            _Insertsysrole.Role_Id = id;
            _Insertsysrole.Role_Code = id;
            int row= sysroledal.Insert(_Insertsysrole);
            if (row>0)
            {
                return id;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// �����޸�
        /// <summary>
        public int UpdateByKey(sysroleModels _Updatesysrole)
        {
            return sysroledal.UpdateByKey(_Updatesysrole);
        }

        /// <summary>
        /// ����ɾ��
        /// <summary>
        public int DeleteByKey(sysroleModels _Wheresysrole)
        {
            return sysroledal.DeleteByKey(_Wheresysrole);
        }

        /// <summary>
        /// ����ɾ��
        /// <summary>
        public int DeleteByWhere(sysroleModels _Wheresysrole, object _WhereType = null)
        {
            return sysroledal.DeleteByWhere(_Wheresysrole, _WhereType);
        }
    }
}
