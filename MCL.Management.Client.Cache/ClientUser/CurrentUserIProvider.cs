using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCL.Management.Client.Cache
{
    public interface CurrentUserIProvider
    {
        /// <summary>
        /// 写入登录信息
        /// </summary>
        /// <param name="user">成员信息</param>
        void AddCurrent(CurrentUser user);

        /// <summary>
        /// 获取当前用户
        /// </summary>
        /// <returns></returns>
        CurrentUser GetCurrentUser();

        /// <summary>
        /// 删除当前用户
        /// </summary>
        void EmptyCurrentUser();

        /// <summary>
        /// 是否过期
        /// </summary>
        /// <returns></returns>
        bool IsOverdue();

        /// <summary>
        /// 是否已登录
        /// </summary>
        /// <returns></returns>
        int IsOnLine();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool CheckIsOnLine();
    }
}
