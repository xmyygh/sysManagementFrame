using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCL.Management.Utility;
using MCL.Management.App.Cache;
using MCL.Management.Models;
using MCL.Management.Client.Cache;
using System.Text;

namespace MCL.Management.App.Web.Controllers
{
    [HandlerLogin(LoginMode.Enforce)]
    public class ClientsDataController : Controller
    {
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetClientsDataJson()
        {
            var data = new
            {
                dataItems = this.GetDataItemList(),
                organize = this.GetOrganizeList(),
                role = this.GetRoleList(),
                user = "",
                authorizeMenu = this.GetMenuList(),
                authorizeButton = this.GetMenuButtonList(),
            };
            return Content(data.ToJson());
        }

        /// <summary>
        /// 获取字典数据
        /// </summary>
        /// <returns></returns>
        private object GetDataItemList()
        {
            
            Dictionary<string, object> dictionaryItem = new Dictionary<string, object>();            
            return dictionaryItem;
        }

        /// <summary>
        /// 获取单位数据
        /// </summary>
        /// <returns></returns>
        private object GetOrganizeList()
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();           
            return dictionary;
        }

        /// <summary>
        /// 获取角色数据
        /// </summary>
        /// <returns></returns>
        private object GetRoleList()
        {           
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            return dictionary;
        }

        /// <summary>
        /// 获取菜单权限数据
        /// </summary>
        /// <returns></returns>
        private object GetMenuList()
        {
            string userid = CurrentUserProvider.Provider.GetCurrentUser().UserId;
            string roleid = CurrentUserProvider.Provider.GetCurrentUser().RoleID;
            MenuLimitCache menuLimitCache = new MenuLimitCache();
            List<sysmenulimitModels> menurole = menuLimitCache.GetByKey(2, roleid);
            List<sysmenulimitModels> menuuser = menuLimitCache.GetByKey(3, userid);

            if (menurole==null)
            {
                menurole = new List<sysmenulimitModels>();
            }
            if (menuuser==null)
            {
                menuuser = new List<sysmenulimitModels>();
            }

            List<sysmenulimitModels> menuall = menurole.Union(menuuser).ToList();

            MenuCache menuCache = new MenuCache();
            List<sysmenuModels> menuList = menuCache.GetAllList();
            List<sysmenuModels> menuLimitList = new List<sysmenuModels>();

            if (menuList == null)
            {
                return null;
            }
            if (menuall==null||menuall.Count<=0)
            {
                return null;
            }

            foreach (sysmenulimitModels item in menuall)
            {
                if (menuLimitList.Count(t=>t.Menu_Id==item.Menu_Id)>0)
                {
                    continue;
                }
                sysmenuModels menu = menuList.FirstOrDefault(t => t.Menu_Id == item.Menu_Id);
                if (menu!=null)
                {
                    menuLimitList.Add(menu);
                }
            }
            return ToMenuJson(menuLimitList,"0");
        }
        private string ToMenuJson(List<sysmenuModels> data, string parentId)
        {
            StringBuilder sbJson = new StringBuilder();
            sbJson.Append("[");
            List<sysmenuModels> entitys = data.FindAll(t => t.Menu_Parentcode == parentId);
            if (entitys.Count > 0)
            {
                foreach (var item in entitys)
                {
                    string strJson = item.ToJson();
                    strJson = strJson.Insert(strJson.Length - 1, ",\"ChildNodes\":" + ToMenuJson(data, item.Menu_Code) + "");
                    sbJson.Append(strJson + ",");
                }
                sbJson = sbJson.Remove(sbJson.Length - 1, 1);
            }
            sbJson.Append("]");
            return sbJson.ToString();
        }

        /// <summary>
        /// 获取按钮权限数据
        /// </summary>
        /// <returns></returns>
        private object GetMenuButtonList()
        {            
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            return dictionary;
        }
	}
}