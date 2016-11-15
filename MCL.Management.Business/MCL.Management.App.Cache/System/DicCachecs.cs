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
    public class DicCachecs
    {
        /// <summary>
        /// 缓存key
        /// </summary>
        public string cacheKey = "dicCache";

        private sysdicBLL bll = new sysdicBLL();

        /// <summary>
        /// 所有字典信息
        /// </summary>
        /// <returns></returns>
        public List<sysdicModels> GetAllList()
        {
            List<sysdicModels> cacheLoginList = null;
            IEnumerable<sysdicModels> data = CacheFactory.Cache().GetCache<IEnumerable<sysdicModels>>(cacheKey);

            if (data == null)
            {
                cacheLoginList = bll.selectAll();
                CacheFactory.Cache().WriteCache(cacheLoginList, cacheKey, DateTime.Now.AddHours(12));
            }
            else
            {
                cacheLoginList = data.ToList();
            }
            return cacheLoginList;
        }

        /// <summary>
        /// 根据字典分类 返回字典信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<sysdicModels> GetByKey(string type)
        {
            List<sysdicModels> cacheLoginList = GetAllList().Where(t => t.Sysdic_Type == type).ToList();
            return cacheLoginList;
        }
    }
}
