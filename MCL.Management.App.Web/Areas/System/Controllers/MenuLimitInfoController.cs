using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using MCL.Management.BLL;
using MCL.Management.Models;
using MCL.Management.Utility;

namespace MCL.Management.App.Web.Areas.System.Controllers
{
    public class MenuLimitInfoController : MvcControllerBase
    {
        // GET: System/MenuLimitInfo
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取登录列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetAllData()
        {
            sysmenuBLL bll = new sysmenuBLL();
            List<sysmenuModels> menulist = new List<sysmenuModels>();
            try
            {
                sysmenuModels model = new sysmenuModels();
                //yxl 暂时此种处理
              //  model = "0";
                menulist = bll.SelectByWhere(model, null, null);
                if (menulist == null)
                {
                    menulist = new List<sysmenuModels>();
                }
                //foreach (sysmenuModels unit in menulist)
                //{

                //    unit.Unit_DeletemarkText = unit.Unit_Deletemark == 1 ? "启用" : "禁用";
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ToJsonResult(menulist);
        }


        public ActionResult GetTreeData()
        {

            List<TreeDataModel> treeDataList = new List<TreeDataModel>();
            sysmenuBLL bll = new sysmenuBLL();
            sysmenuModels model = new sysmenuModels();
            model.Menu_Deletemark = 1;
            List<sysmenuModels> menulist = bll.SelectByWhere(model, null, null);
            if (menulist == null)
            {
                menulist = new List<sysmenuModels>();
                return Success("查询菜单信息,数据为空！", treeDataList);
            }
            List<sysmenuModels> parentList = menulist.Where(t => t.Menu_Parentcode == "0").ToList();
            if (parentList == null || parentList.Count == 0)
            {
                return Success("查询菜单信息,数据为空！", treeDataList);
            }


            foreach (sysmenuModels item in parentList)
            {
                TreeDataModel tree = new TreeDataModel();
                tree.id = item.Menu_Id;
                tree.text = item.Menu_Name;
                tree.parentId = item.Menu_Parentcode;
                if (tree.nodes == null)
                {
                    tree.nodes = new List<TreeDataModel>();
                }

                GetTree(tree, item, menulist);
                treeDataList.Add(tree);
            }
            return Success("查询菜单信息成功！", treeDataList);
        }
        private void GetTree(TreeDataModel treeData, sysmenuModels parent, List<sysmenuModels> unitAllList)
        {
            List<sysmenuModels> childList = unitAllList.Where(t => t.Menu_Parentcode == parent.Menu_Code).ToList();
            if (childList != null && childList.Count > 0)
            {
                foreach (sysmenuModels item in childList)
                {
                    TreeDataModel tree = new TreeDataModel();
                    tree.id = item.Menu_Id;
                    tree.text = item.Menu_Name;
                    tree.parentId = item.Menu_Parentcode;
                    GetTree(tree, item, unitAllList);
                    if (treeData.nodes == null)
                    {
                        treeData.nodes = new List<TreeDataModel>();
                    }
                    treeData.nodes.Add(tree);
                }
            }
        }

        /// <summary>
        /// 保存权限数据
        /// </summary>
        /// <param name="list"></param>
        /// <param name="type"></param>
        /// <param name="userRoleId"></param>
        /// <returns></returns>
        public ActionResult SaveData(string postData,int type,string userRoleId  )
        {
            List<sysmenulimitModels> list = postData.ToList<sysmenulimitModels>();
            if (list.Count>0)
            {
                sysmenulimitBLL bll = new sysmenulimitBLL();
                //需要事务处理
                List<string> strList = new List<string>();
                //sysmenulimitModels model = new sysmenulimitModels();
                //model.Ment_Type = type;
                //model.Unit_Role_User_Id = userRoleId;
                //bll.DeleteByWhere(model, null);
                strList.Add("DELETE FROM SYSMENULIMIT WHERE MENT_TYPE=" + type + " AND UNIT_ROLE_USER_ID=" + userRoleId);
                foreach (var item in list)
                {
                    StringBuilder sbsql = new StringBuilder();
                    sbsql.Append(" INSERT INTO SYSMENULIMIT (");
                    sbsql.Append(" MENU_ID,MENT_TYPE,UNIT_ROLE_USER_ID");
                    sbsql.Append(" ) VALUES (");
                    sbsql.Append("" + item.Menu_Id + "," + type + "," + userRoleId + " )");
                    strList.Add(sbsql.ToString());
                }
                DbHelp.Execute(strList);
            }
           
            return Success("保存数据成功！");
        }

        /// <summary>
        /// 查询选中用户的菜单 并选中
        /// </summary>
        /// <param name="list">传入的角色或用户的集合</param>
        /// <returns></returns>
        public ActionResult GetTreeDataById(string postData)
        {
            
            List<sysmenulimitModels> list = postData.ToList<sysmenulimitModels>();
            string strWhere = "";
            string strSql = "SELECT DISTINCT MENU_ID FROM SYSMENULIMIT  WHERE 1=1 ";
            for (int i = 0; i < list.Count; i++)
            {
                if (i==0)
                {
                    strWhere += " AND (MENT_TYPE=" + list[i].Ment_Type + " AND UNIT_ROLE_USER_ID=" + list[i].Unit_Role_User_Id + ")";
                    
                }
                else
                {
                    strWhere += " OR (MENT_TYPE=" + list[i].Ment_Type + " AND UNIT_ROLE_USER_ID=" + list[i].Unit_Role_User_Id + ")";
                    
                }
            }
           
            strSql += strWhere;
            List<sysmenulimitModels> listSel = DbHelp.Query<sysmenulimitModels>(strSql).ToList();

            //List<TreeDataModel> treeDataList = new List<TreeDataModel>();

            //sysmenuBLL bll = new sysmenuBLL();
            //sysmenuModels model = new sysmenuModels();
            //model.Menu_Deletemark = 1;
            //List<sysmenuModels> menulist = bll.SelectByWhere(model, null, null);
            //if (menulist == null)
            //{
            //    menulist = new List<sysmenuModels>();
            //    return Success("查询菜单信息,数据为空！", treeDataList);
            //}
            //List<sysmenuModels> parentList = menulist.Where(t => t.Menu_Parentcode == "0").ToList();
            //if (parentList == null || parentList.Count == 0)
            //{
            //    return Success("查询菜单信息,数据为空！", treeDataList);
            //}


            //foreach (sysmenuModels item in parentList)
            //{
            //    TreeDataModel tree = new TreeDataModel();
            //    tree.id = item.Menu_Id;
            //    tree.text = item.Menu_Name;
            //    tree.parentId = item.Menu_Parentcode;

            //    if (tree.nodes == null)
            //    {
            //        tree.nodes = new List<TreeDataModel>();
            //    }

            //    GetTree(tree, item, menulist);
            //    treeDataList.Add(tree);
            //}
            //foreach (var item in listSel)
            //{
            //    var temp = treeDataList.Where(p => p.id == item.Menu_Id);
            //    foreach (var tt in temp)
            //    {
            //        tt.isCheck = true;
            //    }
            //}


            return Success("查询菜单信息成功！", listSel);

        }


    }
}