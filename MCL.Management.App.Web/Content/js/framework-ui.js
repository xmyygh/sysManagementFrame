$.loading = function (bool, text) {
    var $loadingpage = top.$("#loadingPage");
    var $loadingtext = $loadingpage.find('.loading-content');
    if (bool) {
        $loadingpage.show();
    } else {
        if ($loadingtext.attr('istableloading') == undefined) {
            $loadingpage.hide();
        }
    }
    if (!!text) {
        $loadingtext.html(text);
    } else {
        $loadingtext.html("数据加载中，请稍后…");
    }
    $loadingtext.css("left", (top.$('body').width() - $loadingtext.width()) / 2 - 50);
    $loadingtext.css("top", (top.$('body').height() - $loadingtext.height()) / 2);
}
$.request = function (name) {
    var search = location.search.slice(1);
    var arr = search.split("&");
    for (var i = 0; i < arr.length; i++) {
        var ar = arr[i].split("=");
        if (ar[0] == name) {
            if (unescape(ar[1]) == 'undefined') {
                return "";
            } else {
                return unescape(ar[1]);
            }
        }
    }
    return "";
}
$.currentWindow = function () {
    var iframeId = top.$(".J_iframe:visible").attr("id");
    return top.frames[iframeId];
}
$.browser = function () {
    var userAgent = navigator.userAgent;
    var isOpera = userAgent.indexOf("Opera") > -1;
    if (isOpera) {
        return "Opera"
    };
    if (userAgent.indexOf("Firefox") > -1) {
        return "FF";
    }
    if (userAgent.indexOf("Chrome") > -1) {
        if (window.navigator.webkitPersistentStorage.toString().indexOf('DeprecatedStorageQuota') > -1) {
            return "Chrome";
        } else {
            return "360";
        }
    }
    if (userAgent.indexOf("Safari") > -1) {
        return "Safari";
    }
    if (userAgent.indexOf("compatible") > -1 && userAgent.indexOf("MSIE") > -1 && !isOpera) {
        return "IE";
    };
}
$.download = function (url, data, method) {
    if (url && data) {
        data = typeof data == 'string' ? data : jQuery.param(data);
        var inputs = '';
        $.each(data.split('&'), function () {
            var pair = this.split('=');
            inputs += '<input type="hidden" name="' + pair[0] + '" value="' + pair[1] + '" />';
        });
        $('<form action="' + url + '" method="' + (method || 'post') + '">' + inputs + '</form>').appendTo('body').submit().remove();
    };
};
$.modalConfirm = function (content, message, callBack) {
    if (content.length == 0) {
        content = "您确定要进行操作吗？";
    }
    //if (message == 0) {
    //    message = "确定操作后数据不可恢复！";
    //}

    swal({
        title: content,
        text: message,
        type: "warning",
        showCancelButton: true,
        cancelButtonText: "取消",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "确定",
        closeOnConfirm: false
    }, function () {
        callBack(true);
    });
}
//type类型 content标题 message消息 timer自动关闭时间
$.modalAlert = function (type, content, message, timer) {

    if (type == 'fail') {
        type = 'error'
    }
    if (content.length == 0) {
        switch (type) {
            case "info":
                content = "系统提示!";
                break;
            case "success":
                content = "保存成功!";
                break;
            case "warning":
                content = "系统警告!";
                break;
            case "error":
                content = "保存失败!";
                break;
            default:
                content = "";
                break;
        }
    }
    if (content == null || content.length == 0) {
        return;
    }

    if (message == null || message.length == 0) {
        message = '';
    }
    if (timer == null || timer.length == 0) {
        timer = null;
    }
    swal({ title: content, text: message, type: type, timer: timer, confirmButtonText: "确定" });
}

//content标题 message消息 timer自动关闭时间
$.modalMsg = function (content, message, timer) {

    if (content.length == 0) {
        content = "系统提示!";
    }

    if (message == null || message.length == 0) {
        message = '';
    }

    if (timer == null || timer.length == 0) {
        timer = null;
    }
    swal({ title: content, text: message, timer: timer, showConfirmButton: true });
}

$.submitForm = function (options) {
    var defaults = {
        url: "",
        param: [],
        title: "",
        message: "",
        loading: "正在提交数据...",
        success: null,
        successbox: false,  //成功是否弹出提示框
        modal: null,
        timer: 2000,
        close: true
    };
    var options = $.extend(defaults, options);
    $.loading(true, options.loading);
    window.setTimeout(function () {
        if ($('[name=__RequestVerificationToken]').length > 0) {
            options.param["__RequestVerificationToken"] = $('[name=__RequestVerificationToken]').val();
        }
        $.ajax({
            url: options.url,
            data: options.param,
            type: "post",
            dataType: "json",
            success: function (data) {
                if (data.state == "success") {
                    options.success(data);
                    if (options.close == true && options.modal != null) {
                        $(options.modal).modal('hide');
                    }
                    if (options.successbox == true) {
                        var content = "";
                        if (options.title != null && options.title.length > 0) {
                            content = options.title + "成功！";
                        }
                        $.modalAlert(data.state, content, options.message, options.timer);
                    }
                } else {
                    var content = "";
                    if (options.title != null && options.title.length > 0) {
                        content = options.title + "失败！";
                    }
                    $.modalAlert(data.state, content, data.message);
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                $.loading(false);
                $.modalAlert("error", "", errorThrown);
            },
            beforeSend: function () {
                $.loading(true, options.loading);
            },
            complete: function () {
                $.loading(false);
            }
        });
    }, 500);
}

$.submitFormConfirm = function (options) {
    var defaults = {
        confirmtitle: "",
        confirmmessage: "",
        url: "",
        param: [],
        title: "",
        message: "",
        loading: "正在提交数据...",
        success: null,
        successbox: false,  //成功是否弹出提示框
        modal: null,
        timer: 2000,
        close: true
    };
    var options = $.extend(defaults, options);
    $.loading(true, options.loading);
    $.modalConfirm(options.confirmtitle, options.confirmmessage, function (r) {
        if (r) {
            window.setTimeout(function () {
                if ($('[name=__RequestVerificationToken]').length > 0) {
                    options.param["__RequestVerificationToken"] = $('[name=__RequestVerificationToken]').val();
                }
                $.ajax({
                    url: options.url,
                    data: options.param,
                    type: "post",
                    dataType: "json",
                    success: function (data) {
                        if (data.state == "success") {
                            options.success(data);
                            if (options.close == true && options.modal != null) {
                                $(options.modal).modal('hide');
                            }
                            if (options.successbox == true) {
                                var content = "";
                                if (options.title != null && options.title.length > 0) {
                                    content = options.title + "成功！";
                                }
                                $.modalAlert(data.state, content, options.message, options.timer);
                            }
                        } else {
                            var content = "";
                            if (options.title != null && options.title.length > 0) {
                                content = options.title + "失败！";
                            }
                            $.modalAlert(data.state, content, data.message);
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        $.loading(false);
                        $.modalAlert("error", "", errorThrown);
                    },
                    beforeSend: function () {
                        $.loading(true, options.loading);
                    },
                    complete: function () {
                        $.loading(false);
                    }
                });
            }, 500);
        }
    });
}

$.deleteForm = function (options) {
    var defaults = {
        title: "您确定要删除该项数据吗?",
        message: "注：确定删除该项数据后，数据不可恢复！",
        url: "",
        param: [],
        loading: "正在删除数据...",
        success: null,
        timer: 2000,
        close: true
    };
    var options = $.extend(defaults, options);
    $.modalConfirm(options.title, options.message, function (r) {
        if (r) {
            $.loading(true, options.loading);
            window.setTimeout(function () {
                if ($('[name=__RequestVerificationToken]').length > 0) {
                    options.param["__RequestVerificationToken"] = $('[name=__RequestVerificationToken]').val();
                }
                $.ajax({
                    url: options.url,
                    data: options.param,
                    type: "post",
                    dataType: "json",
                    success: function (data) {
                        if (data.state == "success") {
                            options.success(data);
                            $.modalAlert(data.state, "删除成功！", "", options.timer);
                        } else {
                            $.modalAlert(data.state, "删除失败！", data.message);
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        $.loading(false);
                        $.modalAlert("error", "删除失败！", errorThrown);
                    },
                    beforeSend: function () {
                        $.loading(true, options.loading);
                    },
                    complete: function () {
                        $.loading(false);
                    }
                });
            }, 500);
        }
    });
}

$.ajaxQuery = function (options) {
    var defaults = {
        url: "",
        param: [],
        loading: "正在查询数据...",
        success: null
    };
    var options = $.extend(defaults, options);
    $.loading(true, options.loading);
    window.setTimeout(function () {
        $.ajax({
            url: options.url,
            data: options.param,
            type: "get",
            dataType: "json",
            success: function (data) {
                if (data.state == "success") {
                    options.success(data);
                } else {
                    $.modalAlert(data.state, "", data.message);
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                $.loading(false);
                $.modalAlert("error", "", errorThrown);
            },
            beforeSend: function () {
                $.loading(true, options.loading);
            },
            complete: function () {
                $.loading(false);
            }
        });
    }, 500);
}

$.jsonWhere = function (data, action) {
    if (action == null) return;
    var reval = new Array();
    $(data).each(function (i, v) {
        if (action(v)) {
            reval.push(v);
        }
    })
    return reval;
}

//控件添加验证信息 mcl 20161117
$.fn.formValid = function () {
    return $(this).valid({
        errorPlacement: function (error, element) {
            element.parents('.formValue').addClass('has-error');
            element.parents('.has-error').find('i.error').remove();
            element.parents('.has-error').append('<i class="form-control-feedback fa fa-times-circle error" data-placement="left" data-toggle="tooltip" title="' + error[0].innerText + '"></i>');
            $("[data-toggle='tooltip']").tooltip();
            if (element.parents('.input-group').hasClass('input-group')) {
                element.parents('.has-error').find('i.error').css('right', '33px');
            }
        },
        success: function (element) {
            element.parents('.has-error').find('i.error').remove();
            element.parent().removeClass('has-error');
        }
    });
}

//控件清除验证信息 mcl 20161117
$.fn.ValidMsg = function (msg) {
    var $this = $(this);
    $this.parents('.formValue').addClass('has-error');
    $this.parents('.has-error').find('i.error').remove();
    $this.parents('.has-error').append('<i class="form-control-feedback fa fa-times-circle error" data-placement="left" data-toggle="tooltip" title="' + msg + '"></i>');
    $("[data-toggle='tooltip']").tooltip();
    if ($this.parents('.input-group').hasClass('input-group')) {
        $this.parents('.has-error').find('i.error').css('right', '33px');
    }
}
$.fn.clearValidMsg = function () {
    var $this = $(this);
    if ($this.parents('.has-error').find('i.error').length > 0) {
        $this.parents('.has-error').find('i.error').remove();
        $this.parent().removeClass('has-error');
    }
}

$.fn.clearFormValid = function () {
    var element = $(this);
    element.find('.has-error').each(function (r) {
        var $this = $(this);
        $this.find('i.error').remove();
        $this.find('.error').removeClass('.error');
        $this.removeClass('has-error');
    });
};

$.IsExist = function (Id, url, msg) {
    var $this = $("#" + Id);
    if (!$this.val()) {
        return false;
    }
    window.setTimeout(function () {
        $.ajax({
            url: url,
            data: { "getData": $this.val() },
            type: "get",
            dataType: "json",
            async: false,
            cache: false,
            global: false,
            success: function (data) {
                if (data.state == "success") {

                    if ($this.parents('.has-error').find('i.isExist').length>0) {
                        $this.parents('.has-error').find('i.isExist').remove();
                        $this.parent().removeClass('has-error');
                    }
                    return false;
                } else {
                    $this.parents('.formValue').addClass('has-error');
                    $this.parents('.has-error').find('i.isExist').remove();
                    $this.parents('.has-error').append('<i class="form-control-feedback fa fa-times-circle error isExist" data-placement="left" data-toggle="tooltip" title="' + msg + '"></i>');
                    $("[data-toggle='tooltip']").tooltip();
                    if ($this.parents('.input-group').hasClass('input-group')) {
                        $this.parents('.has-error').find('i.error').css('right', '33px');
                    }
                    return true;
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                $.modalAlert("error", "字段是否存在查询错误！", errorThrown);
            },
        });
    }, 500);
}

$.fn.clearForm = function () {
    var element = $(this);
    element.find('input,select,select2,checkbox,radio,textarea,password').each(function (r) {
        var $this = $(this);
        var type = $this.attr('type');
        var tag = $this.tagName;
        var id = $this.attr('id');
        switch (type) {
            case "checkbox":
                $this.removeAttr("checked");
                break;
            case "radio":
                $this.checked = false;
                break;
            case "select":
                $this.val("").trigger("change");
                break;
            case "select2":
                if ($("#" + id + " option").length > 0) {
                    var value = $("#" + id + " option:first").val();
                    $this.val(value).trigger("change");
                }                
                break;
            default:
                $this.val("");
                break;
        }
    });
};

$.fn.formSerialize = function (formdate) {
    var element = $(this);
    if (!!formdate) {
        for (var key in formdate) {
            var $id = element.find('#' + key);
            if ($id.length > 0) {
                var value = formdate[key];
                var type = $id.attr('type');
                if ($id.hasClass("select2-hidden-accessible")) {
                    type = "select";
                }
                switch (type) {
                    case "checkbox":
                        if (value == "true") {
                            $id.attr("checked", 'checked');
                        } else {
                            $id.removeAttr("checked");
                        }
                        break;
                    case "select":
                        $id.val(value).trigger("change");
                        break;
                    default:
                        $id.val(value);
                        break;
                }
            }
        };
        return false;
    }
    var postdata = {};
    element.find('input,select,select2,textarea,checkbox,hidden').each(function (r) {
        var $this = $(this);
        var id = $this.attr('id');
        var type = $this.attr('type');
        switch (type) {
            case "checkbox":
                postdata[id] = $this.is(":checked");
                break;
            case "select2":
                var value = $this.val();
                if (value == null && $("#"+id+" option").length>0) {
                    value = $("#" + id + " option:first").val()
                }
                postdata[id] = value;
                break;
            default:
                var value = $this.val();
                postdata[id] = value;
                break;
        }
    });

    if ($('[name=__RequestVerificationToken]').length > 0) {
        postdata["__RequestVerificationToken"] = $('[name=__RequestVerificationToken]').val();
    }
    return postdata;
};
$.fn.bindSelect = function (options) {
    var defaults = {
        id: "id",
        text: "text",
        search: false,
        url: "",
        param: [],
        change: null
    };
    var options = $.extend(defaults, options);
    var $element = $(this);
    if (options.url != "") {
        $.ajax({
            url: options.url,
            data: options.param,
            dataType: "json",
            async: false,
            success: function (data) {
                $.each(data, function (i) {
                    $element.append($("<option></option>").val(data[i][options.id]).html(data[i][options.text]));
                });
                $element.select2({
                    minimumResultsForSearch: options.search == true ? 0 : -1
                });
                $element.on("change", function (e) {
                    if (options.change != null) {
                        options.change(data[$(this).find("option:selected").index()]);
                    }
                    $("#select2-" + $element.attr('id') + "-container").html($(this).find("option:selected").text().replace(/　　/g, ''));
                });
            }
        });
    } else {
        $element.select2({
            minimumResultsForSearch: -1
        });
    }
}
$.fn.authorizeButton = function () {
    var moduleId = top.$(".J_iframe:visible").attr("id").substr(6);
    var dataJson = top.clients.authorizeButton[moduleId];
    var $element = $(this);
    $element.find('a[authorize=yes]').attr('authorize', 'no');
    if (dataJson != undefined) {
        $.each(dataJson, function (i) {
            $element.find("#" + dataJson[i].F_EnCode).attr('authorize', 'yes');
        });
    }
    $element.find("[authorize=no]").parents('li').prev('.split').remove();
    $element.find("[authorize=no]").parents('li').remove();
    $element.find('[authorize=no]').remove();
}