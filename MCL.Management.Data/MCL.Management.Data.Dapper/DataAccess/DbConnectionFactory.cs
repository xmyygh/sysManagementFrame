using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccess
{
    public sealed class DbConnectionFactory
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>MySqlDB
        //public static readonly string connectionString = "server=localhost;user id=root;password=x5;database=manager";
        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["MySqlDB"].ToString();
        
        private static DbConnectionFactory _instance;
        private DbConnectionFactory()
        { }

        public static DbConnectionFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DbConnectionFactory();
                }
                return _instance;
            }
        }
        /// <summary>
        /// 创建数据库连接
        /// </summary>
        /// <returns></returns>
        public IDbConnection GetOpenConnection()
        {
            IDbConnection con = null;
            con = new MySql.Data.MySqlClient.MySqlConnection(connectionString);

            if (con == null)
            {
                throw new Exception("数据库连接配置不正确。");
            }

            return con;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IDbConnection GetClosedConnection()
        {
            IDbConnection con = null;
            con = new MySql.Data.MySqlClient.MySqlConnection(connectionString);

            if (con == null)
            {
                throw new Exception("数据库连接配置不正确。");
            }

            return con;

        }
    }
}
