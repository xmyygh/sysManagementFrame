

var roleIndex, userIndex, $selTable, rowindex, selRow, tableId, treeNodeData;
$(function () {
    //构造表格
    InitTable();
    //构造树形菜单
    InitMenuTree();
});

function InitTable() {
    $("#tableRole").tableClient({
        url: "/System/RoleInfo/GetAllRole",
        toolbar: '#tableToolbar', //菜单
        height: $(window).height() - 68,

        uniqueId: "Role_Id",    //主键
        columns: [              //字段名称和Model类中的一样
            {
                checkbox: true,
                align: 'center',
                valign: 'middle'
            },
                {
                    title: '角色名称',
                    halign: 'center',
                    field: 'Role_Name',
                    align: 'center',
                    valign: 'middle',
                    sortable: true
                },
                {
                    title: '角色描述',
                    field: 'Role_Description',
                    align: 'center',
                    valign: 'middle'
                }
        ],
        rowindex: function (index, row) {  //根据单击事件获取到选择的行号和这行的数据（json格式）
            roleIndex = index;
        }
    });


    $("#tableUser").tableClient({
        url: "/System/UserInfo/GetAllUser",
        toolbar: '', //菜单
        height: $(window).height() - 68,
        uniqueId: "User_Id", //主键
        singleSelect: false,
        columns: [
//字段名称和Model类中的一样
            {
                checkbox: true,
                align: 'center',
                valign: 'middle'
            },

            {
                title: '主键',
                halign: 'center',
                field: 'User_Id',
                align: 'center',
                valign: 'middle',
                visible: false,
                switchable: false,
                cardVisible: false,
                sortable: true
            },
            {
                title: '编号',
                halign: 'center',
                field: 'User_Code',
                align: 'center',
                valign: 'middle',
                sortable: true
            },
            {
                title: '员工姓名',
                field: 'User_Name',
                align: 'center',
                valign: 'middle'
            }, {
                title: '所属部门',
                field: 'UNIT_NAME',
                align: 'center',
                valign: 'middle'
            },
            {
                title: '性别',
                field: 'User_Sex',
                align: 'center',
                valign: 'middle',
                sortable: true
            },

            {
                title: '所属部门ID',
                field: 'Unit_Id',
                align: 'center',
                valign: 'middle',
                cardVisible: false,
                switchable: false,
                visible: false
            }
        ],
        rowindex: function (index, row) { //根据单击事件获取到选择的行号和这行的数据（json格式）
            userIndex = index;
        }
    });

}



function InitMenuTree() {

    $.ajaxQuery({
        url: "/System/MenuLimitInfo/GetTreeData",
        success: function (data) {
            $("#itemTree").treeview({
                data: data.resultdata,
                color: "#428bca",
                showTags: true,

                levels: 1,
                showCheckbox: true,
                onNodeSelected: function (event, node) {
                    treeNodeData = node;

                },
                onNodeChecked: function (event, node) {

                },
                onNodeUnchecked: function (event, node) {

                }
            });
        }
    });

}

function btnSave() {
    var roleRowdata = $('#tableRole').bootstrapTable('getSelections');
    var userRowdata = $('#tableUser').bootstrapTable('getSelections');

    if ((roleRowdata == null || roleRowdata.length == 0) && (userRowdata == null || userRowdata.length == 0)) {
        $.modalMsg('请选择一个角色或一个用户！', '', 2000);
        return null;
    }
    var parr = [];
    var dd = {};
    if (roleRowdata.length > 0) {

        $.each(roleRowdata, function (i, data) {
            dd = {};
            dd.Ment_Type = 2;
            dd.Unit_Role_User_Id = data.Role_Id;
            parr.push(dd);
        });

    }
    if (userRowdata.length > 0) {
        $.each(userRowdata, function (i, data) {
            dd = {};
            dd.Ment_Type = 3;
            dd.Unit_Role_User_Id = data.User_Id;
            parr.push(dd);
        });
    }



    $.ajaxQuery({
        url: "/System/MenuLimitInfo/GetTreeDataById",
        param: { postData: $.toJSON(parr) },
        success: function (data) {
            if (data.resultdata) {


                $.each(data.resultdata, function (i, row) {
                    //var findCheckableNodess = function () {
                    //    return $checkableTree.treeview('search', ['系统管理', { ignoreCase: false, exactMatch: false }]);
                    //};
                    var node = $("#itemTree").treeview('findNodes', [row.Menu_Id, 'g', 'id']);
                    //node = $("#itemTree").treeview('getNode', '10003');
                    $("#itemTree").treeview('checkNode', [node, { silent: true, ignoreChildren: true }]);

                });


            }

        }
    });



    $('#myModal').modal('show');


    //var postData = [];

    //$.each(userRowdata, function (i, row) {
    //    var param = {};
    //    param.Role_Id = roleRowdata[0].Role_Id;
    //    param.User_Id = row.User_Id;
    //    postData.push(param);
    //});
    //var dd = $.toJSON(postData);
    ////提交表单
    //$.submitForm({
    //    url: "/System/RoleUserInfo/SubmitFormAdd",
    //    param: { postData: dd },
    //    title: "保存数据",
    //    success: function (data) {


    //        $.modalAlert(data.state, "", data.message, 2000);


    //    }
    //});

}

function submitForm() {
    var roleRowdata = $('#tableRole').bootstrapTable('getSelections');
    var userRowdata = $('#tableUser').bootstrapTable('getSelections');

    if ((roleRowdata == null || roleRowdata.length == 0) && (userRowdata == null || userRowdata.length == 0)) {
        $.modalMsg('请选择一个角色或一个用户！', '', 2000);
        return null;
    }
    var parr = [];
    var dd = {};
    if (roleRowdata.length > 0) {

        $.each(roleRowdata, function (i, data) {
            dd = {};
            dd.Ment_Type = 2;
            dd.Unit_Role_User_Id = data.Role_Id;
            parr.push(dd);
        });

    }
    if (userRowdata.length > 0) {
        $.each(userRowdata, function (i, data) {
            dd = {};
            dd.Ment_Type = 3;
            dd.Unit_Role_User_Id = data.User_Id;
            parr.push(dd);
        });
    }
    var selNodes = $("#itemTree").treeview('getChecked');
    var arr = [];
    var param = {};
    if (selNodes.length>0) {
        $.each(selNodes, function (i, data) {
            param = {};
            param.Menu_Id = data.id;
            arr.push(param);
        });
    }

    if (parr.length>0) {
        $.each(parr, function(i,data) {
            
            $.submitForm({
                url: "/System/MenuLimitInfo/SaveData",
                param: { postData: $.toJSON(arr), type: data.Ment_Type, userRoleId: data.Unit_Role_User_Id },
                title: "保存数据",
                success: function (data) {

                    $.modalAlert(data.state, "", data.message, 2000);

                }
            });
        });
    }
}