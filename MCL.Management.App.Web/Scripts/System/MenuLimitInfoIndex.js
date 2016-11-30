

var roleIndex, userIndex, $selTable, rowindex, selRow, tableId;
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
   
} 

function btnSave() {
    var roleRowdata = $('#tableRole').bootstrapTable('getSelections');
    if (roleRowdata == null || roleRowdata.length == 0) {
        $.modalMsg('请选择一个角色！', '', 2000);
        return null;
    }
    var userRowdata = $('#tableUser').bootstrapTable('getSelections');
    if (userRowdata == null || userRowdata.length == 0) {
        $.modalMsg('请选择至少一个用户！', '', 2000);
        return null;
    }


    var postData = [];

    $.each(userRowdata, function (i, row) {
        var param = {};
        param.Role_Id = roleRowdata[0].Role_Id;
        param.User_Id = row.User_Id;
        postData.push(param);
    });
    var dd = $.toJSON(postData);
    //提交表单
    $.submitForm({
        url: "/System/RoleUserInfo/SubmitFormAdd",
        param: { postData: dd },
        title: "保存数据",
        success: function (data) {


            $.modalAlert(data.state, "", data.message, 2000);


        }
    });

}