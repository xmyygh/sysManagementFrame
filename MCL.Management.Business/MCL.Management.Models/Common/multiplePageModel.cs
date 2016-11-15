using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCL.Management.Models
{
    /// <summary>
    /// 服务端分页Model类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class multiplePageModel<T>
    {
        private int _TotalNum;
        private IList<T> _Items;     
   
        public multiplePageModel()
        {
            this._Items = new List<T>();
        }
        /// <summary>
        /// 总条数
        /// </summary>
        public int TotalNum
        {
            get { return _TotalNum; }
            set { _TotalNum = value; }
        }
        
        /// <summary>
        /// 数据项
        /// </summary>
        public IList<T> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }

        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPageCount { get; set; }
    }
}
