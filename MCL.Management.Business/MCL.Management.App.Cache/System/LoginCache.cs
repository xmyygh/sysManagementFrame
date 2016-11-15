using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCL.Management.Cache;
using MCL.Management.Models;
using MCL.Management.BLL;

namespace MCL.Management.App.Cache
{
    public class LoginCache
    {
        /// <summary>
        /// 缓存key
        /// </summary>
        public string cacheKey = "loginCache";

        private sysloginBLL bll = new sysloginBLL();

        /// <summary>
        /// 所有登陆用户列表
        /// </summary>
        /// <returns></returns>
        public List<sysloginModels> GetAllList()
        {
            List<sysloginModels> cacheLoginList = null;
            IEnumerable<sysloginModels> data = CacheFactory.Cache().GetCache<IEnumerable<sysloginModels>>(cacheKey);
            
            if (data == null)
            {
                cacheLoginList = bll.selectAll();
                CacheFactory.Cache().WriteCache(cacheLoginList, cacheKey,DateTime.Now.AddHours(12));
            }
            else
            {
                cacheLoginList = data.ToList();
            }
            return cacheLoginList;
        }

        /// <summary>
        /// 根据主键 返回登陆用户信息
        /// </summary>
        /// <param name="Account"></param>
        /// <returns></returns>
        public sysloginModels GetByKey(string Account)
        {
            List<sysloginModels> cacheLoginList = GetAllList();
            return cacheLoginList.FirstOrDefault(t => t.Account == Account);
        }

        /// <summary>
        /// 新增
        /// <summary>
        public int Insert(sysloginModels _Insertsyslogin)
        {
            DelCache();
            return bll.Insert(_Insertsyslogin);
        }

        /// <summary>
        /// 主键修改
        /// <summary>
        public int UpdateByKey(sysloginModels _Updatesyslogin)
        {
            DelCache();
            return bll.UpdateByKey(_Updatesyslogin);
        }

        /// <summary>
        /// 主键删除
        /// <summary>
        public int DeleteByKey(sysloginModels _Wheresyslogin)
        {
            DelCache();
            return bll.DeleteByKey(_Wheresyslogin);
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
