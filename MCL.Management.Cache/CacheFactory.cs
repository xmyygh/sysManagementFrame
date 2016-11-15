using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCL.Management.Cache
{
    /// <summary>
    /// 缓存工厂类
    /// 马春良
    /// 20161025
    /// </summary>
    public class CacheFactory
    {
        public static ICache Cache()
        {
            return new Cache();
        }
    }
}
