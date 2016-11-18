//表格行号 和操作类型如：增删改查
var rowindex, btoptions, selRow;

$(function () {
    $('#Usr_Birthday').datetimepicker({
        format: 'yyyy-mm-dd',
        language: 'zh-CN',
        autoclose: 'true',
        minView: 2
    });
    $(".gridPanel").height($(window).height() - 60);
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
        height: $(window).height() - 65,
        uniqueId: "User_Id", //主键
        columns: [
//字段名称和Model类中的一样
            {
                checkbox: true,
                align: 'center',
                valign: 'middle'
            },
            {
                title: '操作',
                field: 'operation',
                align: 'center',
                valign: 'middle',
                formatter: function (value, row, index) {
                    var s = '<a class = "rowEdit" title="修改" href="javascript:void(0)"><i class="glyphicon glyphicon-edit"></i></a>';
                    var d = '<a class = "rowDelete" title="删除" href="javascript:void(0)"><i class="glyphicon glyphicon-trash"></i></a>';
                    return s + ' ' + d;
                },
                events: 'operateEvents'
            },
            {
                title: '主键',
                halign: 'center',
                field: 'User_Id',
                align: 'center',
                valign: 'middle',

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
                title: '用户姓名',
                field: 'User_Name',
                align: 'center',
                valign: 'middle',
            },
            {
                title: '性别',
                field: 'User_SexText',
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
                title: '用户状态',
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
    $("#table").bootstrapTable('hideColumn', 'User_Id');
    $("#table").bootstrapTable('hideColumn', 'User_Createdate');
    //表格中的操作事件
    window.operateEvents = {
        'click .rowEdit': function (event, value, row, index) {
            updateRowData(row, index);
        },
        'click .rowDelete': function (event, value, row, index) {
            delRowData(row);
        }
    };
});
//提交表单
function submitForm() {
    if (!$('#commentForm').formValid()) {
        return false;
    }
    var postData = $("#commentForm").formSerialize();
    postData.User_EnabledText = $('#User_Enabled').find("option:selected").text();
    postData.User_SexText = $('#User_Sex').find("option:selected").text();
    var url;
    var title = "";
    if (btoptions === 'add') {
        title = "新增用户";

        url = "/System/UserInfo/SubmitFormAdd";
    }
    else if (btoptions === 'edit') {
        title = "修改用户";
        postData.User_Id = selRow.User_Id;
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
                    postData.User_Id = data.resultdata;

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

//表格删除
function delRowData(rowData) {
    $.deleteForm({
        url: "/System/UserInfo/SubmitFormDel",
        param: rowData,
        success: function () {
            $('#table').bootstrapTable('removeByUniqueId', rowData.User_Id);
        }
    });
}
//表格中的修改
function updateRowData(row, index) {
    btoptions = 'edit';
    rowindex = index;

    modal_open(row);
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