//表格行号 和操作类型如：增删改查
var rowindex, btoptions, selRow;

$(function () {
    $('#Usr_Birthday').datetimepicker({
        format: 'yyyy-mm-dd',
        language: 'zh-CN',
        autoclose: 'true',
        minView: 2
    });

    $('#User_Sex').select2({
        minimumResultsForSearch: Infinity
    });
    //绑定部门下拉框
    $("#Unit_Id").bindSelect({
        url: "/ItemData/GetUnit",
        param: {},
        id: "Unit_Id",
        text: "Unit_Name"
    });

    //帐号状态下拉框绑定 注：下拉框绑定通用的查询都写在ItemDataController中
    $("#User_Enabled").bindSelect({
        url: "/ItemData/GetByKeyItemData",
        param: { "keyName": "ENABLED" },
        id: "Sysdic_Code",
        text: "Sysdic_Name"
    });

    //初始化表格 以下信息必须有 具体信息可到bootstrapTable.js中查看
    $("#table").tableClient({
        url: "/System/UserInfo/GetAllUser",
        toolbar: '#tableToolbar', //菜单
        height: $(window).height() - 68,
        uniqueId: "User_Id", //主键
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
                title: '所属部门ID',
                field: 'Unit_Id',
                align: 'center',
                valign: 'middle',
                cardVisible: false,
                switchable:false,
                visible: false
            },
            {
                title: '性别',
                field: 'User_Sex',
                align: 'center',
                valign: 'middle',
                sortable: true
            },
            {
                title: '年龄',
                field: 'User_Age',
                align: 'center',
                valign: 'middle',
                sortable: true
            },
            {
                title: '邮箱',
                field: 'User_Email',
                align: 'center',
                valign: 'middle'
            },
            {
                title: '手机号',
                field: 'User_Mobile',
                align: 'center',
                valign: 'middle'
            },
            {
                title: '员工状态',
                field: 'User_EnabledText',
                align: 'center',
                valign: 'middle',
                sortable: true
            },
            {
                title: '创建时间',
                field: 'User_Createdate',
                align: 'center',
                valign: 'middle',
                sortable: true
            }
        ],
        rowindex: function (index, row) { //根据单击事件获取到选择的行号和这行的数据（json格式）
            rowindex = index;
            selRow = row;
        }
    });
    //$("#table").bootstrapTable('hideColumn', 'User_Id');
    //$("#table").bootstrapTable('hideColumn', 'Unit_Id');

});
//提交表单
function submitForm() {
    if (!$('#commentForm').formValid()) {
        return false;
    }
    var postData = $("#commentForm").formSerialize();
    postData.User_EnabledText = $('#User_Enabled').find("option:selected").text();
    postData.UNIT_NAME = $('#Unit_Id').find("option:selected").text();

    var url;
    var title = "";
    if (btoptions === 'add') {
        title = "新增员工";

        url = "/System/UserInfo/SubmitFormAdd";
    }
    else if (btoptions === 'edit') {
        title = "修改员工";
        postData.User_Id = selRow.User_Id;
        postData.User_Createdate = selRow.User_Createdate;
        url = "/System/UserInfo/SubmitFormUpdate";
    }



    //提交表单
    $.submitForm({
        url: url,
        param: postData,
        title: title,
        modal: $('#myModal'),
        success: function (data) {
            if (btoptions === 'add') {
                if (data.state == "success") {
                    postData.User_Id = data.resultdata.User_Id;
                    postData.User_Createdate = data.resultdata.User_Createdate;
                    $('#table').bootstrapTable('prepend', postData);
                }
            }
            else if (btoptions === 'edit') {
                if (data.state == "success") {
                    $('#table').bootstrapTable('updateRow', { index: rowindex, row: postData });
                }
            }
        }
    })
};
//查看
function bt_detail() {
    btoptions = 'detail';
    modal_open();
}

//添加
function bt_add() {
    btoptions = 'add';
    modal_open();
}

//修改
function bt_edit() {
    btoptions = 'edit';
    modal_open();
}
//删除
function bt_del() {
    var rowdata = getTableCheckData();
    if (rowdata == null) {
        return;
    }
    $.deleteForm({
        url: "/System/UserInfo/SubmitFormDel",
        param: rowdata,
        success: function () {
            $('#table').bootstrapTable('removeByUniqueId', rowdata.User_Id);
        }
    });
}

function bt_loginSet() {
    var rowdata = getTableCheckData();
    if (rowdata == null) {
        return;
    }
    $.submitFormConfirm({
        confirmtitle: "您确定将此员工设置为登录用户！",
        url: "/System/UserInfo/LoginUserSet",
        param: rowdata,
        title: "设置登录账户",
        successbox: true,
        success: function (data) {
            if (data.state == "success") {

            }
        }
    })

}

//禁用
function bt_disable() {
    var rowdata = getTableCheckData();
    if (rowdata == null) {
        return;
    }
    rowdata.User_Enabled = "0";
    rowdata.User_EnabledText = "禁用";
    options("您确定将员工禁用！", "员工禁用", rowdata);
}

//启用
function bt_enable() {
    var rowdata = getTableCheckData();
    if (rowdata == null) {
        return;
    }
    rowdata.User_Enabled = "1";
    rowdata.User_EnabledText = "启用";
    options("您确定将员工启用！", "员工启用", rowdata);
}
//提交表单弹出是否提交提示框
function options(confirmmsg, msg, rowdata) {
    $.submitFormConfirm({
        confirmtitle: confirmmsg,
        url: "/System/UserInfo/SubmitFormUpdate",
        param: rowdata,
        title: msg,
        successbox: true,
        success: function (data) {
            if (data.state == "success") {
                $('#table').bootstrapTable('updateRow', { index: rowindex, row: rowdata });
            }
        }
    });
}

//弹出窗体
function modal_open(row) {

    //确定按钮显示
    $('#bt_ok').css({ "display": "inline" });

    //删除验证信息
    $('#commentForm').clearFormValid();

    if (btoptions === 'detail') { //查看
        var rowdata = getTableCheckData();
        if (rowdata == null) {
            return;
        }
        $('#commentForm').formSerialize(rowdata); //from表单赋值传json格式数据
        $('#bt_ok').css({ "display": "none" }); //确定按钮隐藏
    } else if (btoptions === 'add') { //新增
        $('#commentForm').clearForm(); //清空from表单内容
    } else if (btoptions === 'edit') { //修改
        if (row == null) { //表格修改操作
            var rowdata = getTableCheckData();
            if (rowdata == null) {
                return;
            }
            $('#commentForm').formSerialize(rowdata);
            if (rowdata.length == 0) { //没有选择数据
                $('#bt_ok').css({ "display": "none" });
            }
        } else {
            $('#commentForm').formSerialize(row);
        }

    }

    $('#myModal').modal('show').css({
        width: 'auto'
    });;
};

//查询
function bt_query() {
    var postData = $("#commentForm").formSerialize();
    $.ajaxQuery({
        url: "/System/UserInfo/GetByKeyLogin",
        param: { postData: postData },
        success: function (data) {
            $('#table').bootstrapTable('load', data.resultdata);
        }
    });
}

//获取表格选择的数据
function getTableCheckData() {
    var rowdata = $('#table').bootstrapTable('getSelections');
    if (rowdata == null || rowdata.length == 0) {
        $.modalMsg('请选择数据！', '', 2000);
        return null;
    } else {
        if (rowdata.length > 1) {
            return rowdata;
        } else {
            return rowdata[0];

        }
    }
}