using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCL.Management.Models;
using MCL.Management.BLL;
using MCL.Management.Cache;

namespace MCL.Management.App.Cache
{
    public class MenuLimitCache
    {
        /// <summary>
        /// 缓存key
        /// </summary>
        public string cacheKey = "menuLimitCache";

        private sysmenulimitBLL bll = new sysmenulimitBLL();

        /// <summary>
        /// 所有员工列表
        /// </summary>
        /// <returns></returns>
        public List<sysmenulimitModels> GetAllList()
        {
            List<sysmenulimitModels> cacheMenuLimitList = null;
            IEnumerable<sysmenulimitModels> data = CacheFactory.Cache().GetCache<IEnumerable<sysmenulimitModels>>(cacheKey);

            if (data == null)
            {
                cacheMenuLimitList = bll.selectAll();
                CacheFactory.Cache().WriteCache(cacheMenuLimitList, cacheKey, DateTime.Now.AddHours(12));
            }
            else
            {
                cacheMenuLimitList = data.ToList();
            }
            return cacheMenuLimitList;
        }

        /// <summary>
        /// 根据主键
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<sysmenulimitModels> GetByKey(int type, string id)
        {
            List<sysmenulimitModels> cacheUserList = GetAllList();
            return cacheUserList.Where(t => t.Ment_Type == type&&t.Unit_Role_User_Id==id).ToList();
        }
    }
}
