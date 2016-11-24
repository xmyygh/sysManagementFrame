
$.fn.tableClient = function (options) {
    var $this = $(this);
    var defaults = {
        url: "",
        dataType: "json",
        method: 'get',					  //请求方式（*）
        toolbar: '',		              //工具按钮用哪个容器
        striped: false,					  //是否显示行间隔色
        cache: false,					  //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）

        undefinedText: '',                //当数据为 undefined 时显示的字符

        pagination: true,				  //是否显示分页（*）
        paginationFirstText: "<<",
        paginationPreText: "<",
        paginationNextText: ">",
        paginationLastText: ">>",

        sortable: true,					    //是否启用排序
        //sortOrder: "asc",				    //排序方式
        //sortStable: true,                 //设置为 true 将获得稳定的排序，我们会添加_position属性到 row 数据中。

        sidePagination: "client",		    //分页方式：client客户端分页，server服务端分页（*）
        pageNumber: 1,					    //初始化加载第一页，默认第一页
        pageSize: 10,					    //每页的记录行数（*）
        pageList: [10, 25, 50, 100],	    //可供选择的每页的行数（*）

        search: false,					    //是否显示表格搜索，此搜索是客户端搜索，不会进服务端，所以，个人感觉意义不大
        strictSearch: false,                //设置为 true时，按回车触发搜索方法，否则自动触发搜索方法

        singleSelect: true,                //复选框只能选择一条记录
        clickToSelect: true,               //点击行即可选中单选/复选框

        showColumns: true,				    //是否显示所有的列
        showRefresh: true,				    //是否显示刷新按钮
        minimumCountColumns: 2,			    //最少允许的列数

        height: "",	                        //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
        uniqueId: "",				        //每一行的唯一标识，一般为主键列
        showToggle: true,					//是否显示详细视图和列表视图的切换按钮
        cardView: false,					    //是否显示详细视图
        detailView: false,				    //是否显示父子表
        iconSize: "outline",
        icons: { refresh: "glyphicon-repeat", toggle: "glyphicon-list-alt", columns: "glyphicon-list" },
        columns: [],
        formatLoadingMessage: function () {
            return "请稍等，数据正在加载中...";
        },
        formatNoMatches: function () {  //没有匹配的结果
            return '无符合条件的记录';
        },
        onLoadSuccess: function (data) {
            $this.bootstrapTable();  //ajax后启动表格
        },
        onLoadError: function (data) {
            $this.bootstrapTable('removeAll');
        },
        onClickRow: function (row, $element) {
            index = $element.attr("data-index");
            if (typeof options.rowindex === 'function') {
                options.rowindex(index, row);
            }                
        },
        onDblClickRow: function (row, $element) { //双击表格事件选中check

        }
    }
    var options = $.extend(defaults, options);
    $this.bootstrapTable(options);
}


$.fn.treeTableClient = function (option) {
    var $this = $(this);
    var defaults = {
        url: "",
        detailView: true,//父子表
        dataType: "json",
        method: 'get',					  //请求方式（*）
        toolbar: '',		              //工具按钮用哪个容器
        striped: false,					  //是否显示行间隔色
        cache: false,					  //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
        undefinedText: '',                //当数据为 undefined 时显示的字符
        pagination: false,				  //是否显示分页（*）
        paginationFirstText: "<<",
        paginationPreText: "<",
        paginationNextText: ">",
        paginationLastText: ">>",
        sortable: true,					    //是否启用排序
        sidePagination: "client",		    //分页方式：client客户端分页，server服务端分页（*）
        pageNumber: 1,					    //初始化加载第一页，默认第一页
        pageSize: 10,					    //每页的记录行数（*）
        pageList: [10, 25, 50, 100],	    //可供选择的每页的行数（*）
        search: false,					    //是否显示表格搜索，此搜索是客户端搜索，不会进服务端，所以，个人感觉意义不大
        strictSearch: false,                //设置为 true时，按回车触发搜索方法，否则自动触发搜索方法
        singleSelect: true,                //复选框只能选择一条记录
        clickToSelect: true,               //点击行即可选中单选/复选框
        showColumns: true,				    //是否显示所有的列
        showRefresh: true,				    //是否显示刷新按钮
        minimumCountColumns: 2,			    //最少允许的列数

        height: "",	                        //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
        uniqueId: "",				        //每一行的唯一标识，一般为主键列
        showToggle: true,					//是否显示详细视图和列表视图的切换按钮
        cardView: false,					    //是否显示详细视图
        iconSize: "outline",
       // icons: { refresh: "glyphicon-repeat", toggle: "glyphicon-list-alt", columns: "glyphicon-list" },
        columns: [],
        formatLoadingMessage: function () {
            return "请稍等，数据正在加载中...";
        },
        formatNoMatches: function () {  //没有匹配的结果
            return '无符合条件的记录';
        },
        onLoadSuccess: function (data) {
            $this.bootstrapTable();  //ajax后启动表格
        },
        onLoadError: function (data) {
            $this.bootstrapTable('removeAll');
        },
        onClickRow: function (row, $element) {
            index = $element.attr("data-index");
            if (typeof options.rowindex === 'function') {
                options.rowindex(index, row);
            }
        },
        onDblClickRow: function (row, $element) { //双击表格事件选中check
        }
    }
    var options = $.extend(defaults, option);
    $this.bootstrapTable(options);
}