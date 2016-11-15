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
    public class MenuCache
    {
        /// <summary>
        /// 缓存key
        /// </summary>
        public string cacheKey = "menuCache";

        private sysmenuBLL bll = new sysmenuBLL();

        /// <summary>
        /// 所有员工列表
        /// </summary>
        /// <returns></returns>
        public List<sysmenuModels> GetAllList()
        {
            List<sysmenuModels> cacheMenuList = null;
            IEnumerable<sysmenuModels> data = CacheFactory.Cache().GetCache<IEnumerable<sysmenuModels>>(cacheKey);

            if (data == null)
            {
                cacheMenuList = bll.selectAll();
                CacheFactory.Cache().WriteCache(cacheMenuList, cacheKey, DateTime.Now.AddHours(12));
            }
            else
            {
                cacheMenuList = data.ToList();
            }
            return cacheMenuList;
        }

        /// <summary>
        /// 新增
        /// <summary>
        public int Insert(sysmenuModels _Insertsysmenu)
        {
            DelCache();
            return bll.Insert(_Insertsysmenu);
        }

        /// <summary>
        /// 主键修改
        /// <summary>
        public int UpdateByKey(sysmenuModels _Updatesysmenu)
        {
            DelCache();
            return bll.UpdateByKey(_Updatesysmenu);
        }

        /// <summary>
        /// 主键删除
        /// <summary>
        public int DeleteByKey(sysmenuModels _Wheresysmenu)
        {
            DelCache();
            return bll.DeleteByKey(_Wheresysmenu);
        }

        /// <summary>
        /// 删除登录用户缓存
        /// </summary>
        private void DelCache()
        {
            CacheFactory.Cache().RemoveCache(cacheKey);
        }
    }
}
