using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MCL.Management.Models
{
    public class sysuserModels
    {
        /// <summary>
        /// 
        /// <summary>
        public string User_Id
        {
            get ;
            set ;
        }

        /// <summary>
        /// ���,����
        /// <summary>
        public string User_Code
        {
            get ;
            set ;
        }

        /// <summary>
        /// �û���
        /// <summary>
        public string User_Name
        {
            get ;
            set ;
        }

        /// <summary>
        /// �û�ͼƬURL
        /// <summary>
        public string User_Imageurl
        {
            get ;
            set ;
        }

        /// <summary>
        /// �Ա� M�� WŮ
        /// <summary>
        public string User_Sex
        {
            get ;
            set ;
        }
        /// <summary>
        /// �Ա� M�� WŮ
        /// <summary>
        public string User_SexText
        {
            get;
            set;
        }
        /// <summary>
        /// ����
        /// <summary>
        public string Usr_Birthday
        {
            get ;
            set ;
        }

        /// <summary>
        /// ����
        /// <summary>
        public int? User_Age
        {
            get ;
            set ;
        }

        /// <summary>
        /// ���֤����
        /// <summary>
        public string User_Idcard
        {
            get ;
            set ;
        }

        /// <summary>
        /// ���к���
        /// <summary>
        public string User_Bankcode
        {
            get ;
            set ;
        }

        /// <summary>
        /// 
        /// <summary>
        public string User_Email
        {
            get ;
            set ;
        }

        /// <summary>
        /// �ֻ���
        /// <summary>
        public string User_Mobile
        {
            get ;
            set ;
        }

        /// <summary>
        /// QQ����
        /// <summary>
        public string User_Oicq
        {
            get ;
            set ;
        }

        /// <summary>
        /// ��ҵѧУ
        /// <summary>
        public string User_School
        {
            get ;
            set ;
        }

        /// <summary>
        /// ��Ч��ʶ 0���� 1����
        /// <summary>
        public int? User_Enabled
        {
            get ;
            set ;
        }
        public string User_EnabledText
        {
            get ;
            set ;
        }
        /// <summary>
        /// ����
        /// <summary>
        public string User_Description
        {
            get ;
            set ;
        }

        /// <summary>
        /// �û���������
        /// <summary>
        public string Unit_Id
        {
            get;
            set;
        }

        /// <summary>
        /// ����ʱ��
        /// <summary>
        public string User_Createdate
        {
            get ;
            set ;
        }

    }
}
