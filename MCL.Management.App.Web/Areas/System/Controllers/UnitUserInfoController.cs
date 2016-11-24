using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCL.Management.Models;
using MCL.Management.BLL;
using MCL.Management.App.Cache;
using MCL.Management.Utility;
using MCL.Management.Client.Cache;

namespace MCL.Management.App.Web.Areas.System.Controllers
{
    public class UnitUserInfoController : MvcControllerBase
    {
        //
        // GET: /System/UnitUserInfo/
        [HttpGet]
        [HandlerAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取科室下拉框数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetUnitTree()
        {
            List<TreeDataModel> treeDataList = new List<TreeDataModel>();
            sysunitBLL bll = new sysunitBLL();
            sysunitModels model = new sysunitModels();
            model.Unit_Deletemark = 1;

            List<sysunitModels> unitlist = bll.SelectByWhere(model, null, null);
            if (unitlist == null)
            {
                unitlist = new List<sysunitModels>();
                return Success("查询部门信息成功,数据为空！", treeDataList);
            }

            List<sysunitModels> parentList = unitlist.Where(t => t.Unit_Parentid == "0").ToList();
            if (parentList == null || parentList.Count == 0)
            {
                return Success("查询部门信息成功,数据为空！", treeDataList);
            }

            foreach (sysunitModels item in parentList)
            {
                TreeDataModel tree = new TreeDataModel();
                tree.id = item.Unit_Id;
                tree.text = item.Unit_Name;
                tree.parentId = item.Unit_Parentid;
                if (tree.nodes == null)
                {
                    tree.nodes = new List<TreeDataModel>();
                }

                GetTree(tree, item, unitlist);
                treeDataList.Add(tree);
            }
            return Success("查询部门信息成功！", treeDataList);           
        }

        private void GetTree(TreeDataModel treeData, sysunitModels parent, List<sysunitModels> unitAllList)
        {
            List<sysunitModels> childList = unitAllList.Where(t => t.Unit_Parentid == parent.Unit_Id).ToList();
            if (childList != null && childList.Count > 0)
            {
                foreach (sysunitModels item in childList)
                {
                    TreeDataModel tree = new TreeDataModel();
                    tree.id = item.Unit_Id;
                    tree.text = item.Unit_Name;
                    tree.parentId = item.Unit_Parentid;

                    GetTree(tree, item, unitAllList);
                    if (treeData.nodes == null)
                    {
                        treeData.nodes = new List<TreeDataModel>();
                    }                   
                    treeData.nodes.Add(tree);
                }
            }
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetByKeyUser(string id, string username)
        {
            UserCache user = new UserCache();

            List<sysuserModels> userList = null; 
            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(username))
            {
                userList = user.GetAllList().Where(t => t.Unit_Id == id && t.User_Name.Contains(username)).ToList();
            }
            else if (!string.IsNullOrEmpty(id))
            {
                userList = user.GetAllList().Where(t => t.Unit_Id == id).ToList();
            }
            else if (!string.IsNullOrEmpty(username))
            {
                userList = user.GetAllList().Where(t => t.User_Name.Contains(username)).ToList();
            }

            if (userList!=null)
            {
                foreach (sysuserModels item in userList)
                {
                    item.User_EnabledText = item.User_Enabled == 1 ? "启用" : "禁用";
                }
            }
            return Success("查询部门下员工信息成功", userList);
        }
    }
}