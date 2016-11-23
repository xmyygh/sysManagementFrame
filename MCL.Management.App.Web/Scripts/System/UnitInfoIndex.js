//行号 和操作类型如：增删改查
var rowindex, btoptions, selRow, $selTable, type, tableId;

$(function () {

    //帐号状态下拉框绑定 注：下拉框绑定通用的查询都写在ItemDataController中
    $("#Unit_Deletemark").bindSelect({
        url: "/ItemData/GetByKeyItemData",
        param: { "keyName": "ENABLED" },
        id: "Sysdic_Code",
        text: "Sysdic_Name"
    });

    initTable();

});


function initTable() {
    var oInit = new Object();
    //初始化表格 以下信息必须有 具体信息可到bootstrapTable.js中查看
    var columns = [
        {
            checkbox: true,
            align: 'center',
            valign: 'middle'
        },

        {
            title: '主键',
            halign: 'center',
            field: 'Unit_Id',
            align: 'center',
            valign: 'middle',
            visible: false,
            switchable: false,
            sortable: true
        },
        {
            title: '单位分类',
            halign: 'center',
            field: 'Unti_Type',
            align: 'center',
            valign: 'middle',
            visible: false,
            switchable: false,
            sortable: true
        },
        {
            title: '单位编码',
            field: 'Unit_Code',
            align: 'center',
            valign: 'middle',
        },
        {
            title: '单位名称',
            field: 'Unit_Name',
            align: 'center',
            valign: 'middle',
            sortable: true
        },
        {
            title: '父编码',
            field: 'Unit_Parentid',
            align: 'center',
            valign: 'middle',
            visible: false,
            switchable: false,
            sortable: true
        },
        {
            title: '部门状态',
            field: 'Unit_DeletemarkText',
            align: 'center',
            valign: 'middle'
        },
        {
            title: '备注',
            field: 'Unit_Description',
            align: 'center',
            valign: 'middle'
        }
    ];
    $("#table").treeTableClient({
        url: "/System/UnitInfo/GetAllData",
        toolbar: '#tableToolbar', //菜单
        height: $(window).height() - 68,
        uniqueId: "Unit_Id", //主键
        columns: columns,
        rowindex: function (index, row) { //根据单击事件获取到选择的行号和这行的数据（json格式）
            rowindex = index;
            selRow = row;
        },
        onCheck: function (row, $element) {
            $selTable = $("#table");
        },
        //注册加载子表的事件。注意下这里的三个参数！
        onExpandRow: function (index, row, $detail) {
            tableId = row.Unit_Id;
            var postData = { "Unit_Parentid": row.Unit_Id }
            var count = 0;

            $.ajaxQuery({
                async:false,
                url: "/System/UnitInfo/GetDataCount",
                param: postData ,
                success: function (data) {
                    count = data.resultdata;
                    if (count > 0) {
                        oInit.InitSubTable(index, row, $detail);
                    } else {
                        $.modalMsg('没有数据！', '', 2000);
                        return false;
                    }
                }
            });
          
        }
    });
    $selTable = $("#table");
    oInit.InitSubTable = function (index, row, $detail) {
        var postData = { "Unit_Parentid": row.Unit_Id }
        var cur_table = $detail.html('<table id=' + tableId + '></table>').find('table');
        //arrsubmenutable.push(cur_table);
        $(cur_table).treeTableClient({
            url: "/System/UnitInfo/GetByCodeData",
            method: 'get',
            showColumns: false,
            showRefresh: false,
            sortable: false,
            showToggle: false,
            queryParams: postData,
            ajaxOptions: postData,
            columns: columns,
            onLoadSuccess: function (data) {
                $(cur_table).bootstrapTable('load', data.resultdata);
            },
            onCheck: function (row, $element) {
                $selTable = $(cur_table);
            },
            rowindex: function (index, row) { //根据单击事件获取到选择的行号和这行的数据（json格式）
                rowindex = index;
                selRow = row;
            },
            //注册加载子表的事件。注意下这里的三个参数！
            onExpandRow: function (index, row, $detail) {
                tableId = row.Unit_Id;
                oInit.InitSubTable(index, row, $detail);
            }
        });

    }


}
//删除
function bt_del() {
    var rowdata = getTableCheckData();
    if (rowdata == null) {
        return;
    }
    $.deleteForm({
        url: "/System/UnitInfo/SubmitFormDel",
        param: rowdata,
        success: function () {
            $('#table').bootstrapTable('removeByUniqueId', rowdata.Unit_Id);
        }
    });
}

//提交表单
function submitForm() {
    if (!$('#commentForm').formValid()) {
        return false;
    }
    var postData = $("#commentForm").formSerialize();
    postData.Unit_DeletemarkText = $('#Unit_Deletemark').find("option:selected").text();
    var url;
    var title = "";
    //定义操作的表格
    var $table = $selTable;
    if (btoptions === 'add') {
        title = "新增部门";
        //新增下级
        if (type == 1 && tableId) {
            $table = $('#' + tableId);
        }
        url = "/System/UnitInfo/SubmitFormAdd";
    }
    else if (btoptions === 'edit') {
        title = "修改部门";
        postData.Unit_Id = selRow.Unit_Id;
        url = "/System/UnitInfo/SubmitFormUpdate";
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
                    postData.Unit_Id = data.resultdata;
                    if (type == 1) {
                        if (tableId) {
                            $table.bootstrapTable('prepend', postData);
                        }
                    } else {
                        $table.bootstrapTable('prepend', postData);
                    }
                }
            }
            else if (btoptions === 'edit') {
                if (data.state == "success") {
                    $table.bootstrapTable('updateRow', { index: rowindex, row: postData });
                }
            }
        }
    })
};
//查看
function bt_detail() {
    btoptions = 'detail';
    $(".modal-title").text("部门信息");
    modal_open();
}

//添加
function bt_add(type) {
    btoptions = 'add';
    $(".modal-title").text("新增部门信息");
    this.type = type;
    modal_open();
}

//修改
function bt_edit() {
    btoptions = 'edit';
    $(".modal-title").text("修改部门信息");
    modal_open();
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
        var rowdata = $selTable.bootstrapTable('getSelections');
        var fId = "0";
        if (type == 1) {
            if (rowdata == null || rowdata.length == 0) {
                $.modalMsg('请选择需要添加下级的数据！', '', 2000);
                return null;
            }
        }
        if (rowdata == null || rowdata.length == 0) {
            fId = "0";
        } else {
            fId = type == 0 ? rowdata[0].Unit_Parentid : rowdata[0].Unit_Id;
        }

        $('#Unit_Parentid').val(fId);
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
        url: "/System/UnitInfo/GetByKeyData",
        param: { postData: postData },
        success: function (data) {
            $('#table').bootstrapTable('load', data.resultdata);
        }
    });
}

//获取表格选择的数据
function getTableCheckData() {
    var rowdata = $selTable.bootstrapTable('getSelections');
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