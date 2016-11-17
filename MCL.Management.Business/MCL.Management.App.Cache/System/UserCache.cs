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
    public class UserCache
    {
        /// <summary>
        /// 缓存key
        /// </summary>
        public string cacheKey = "userCache";

        private sysuserBLL bll = new sysuserBLL();

        /// <summary>
        /// 所有员工列表
        /// </summary>
        /// <returns></returns>
        public List<sysuserModels> GetAllList()
        {
            List<sysuserModels> cacheUserList = null;
            IEnumerable<sysuserModels> data = CacheFactory.Cache().GetCache<IEnumerable<sysuserModels>>(cacheKey);

            if (data == null)
            {
                cacheUserList = bll.selectAll();
                CacheFactory.Cache().WriteCache(cacheUserList, cacheKey, DateTime.Now.AddHours(12));
            }
            else
            {
                cacheUserList = data.ToList();
            }
            return cacheUserList;
        }

        /// <summary>
        /// 根据主键 返回员工信息
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public sysuserModels GetByKey(string userid)
        {
            List<sysuserModels> cacheUserList = GetAllList();
            return cacheUserList.FirstOrDefault(t => t.User_Id == userid);
        }

        /// <summary>
        /// 新增
        /// <summary>
        public string Insert(sysuserModels _Insertsysuser)
        {
            DelCache();
            return bll.Insert(_Insertsysuser);
        }

        /// <summary>
        /// 主键修改
        /// <summary>
        public int UpdateByKey(sysuserModels _Updatesysuser)
        {
            DelCache();
            return bll.UpdateByKey(_Updatesysuser);
        }

        /// <summary>
        /// 主键删除
        /// <summary>
        public int DeleteByKey(sysuserModels _Wheresysuser)
        {
            DelCache();
            return bll.DeleteByKey(_Wheresysuser);
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
