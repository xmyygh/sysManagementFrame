
$(function ($) {
    GetLoadNav();
});

//¼ÓÔØ²Ëµ¥
function GetLoadNav() {
    var data = top.clients.authorizeMenu;
    var _html = "";
    $.each(data, function (i) {
        var row = data[i];
        if (row.Menu_Parentcode == "0") {

            var childNodes = row.ChildNodes;
            if (childNodes.length > 0) {
                _html += '<li>';
                _html += '<a href="#">';
                _html += '<i class="' + row.Menu_Imageindex + '"></i>';
                _html += '<span class="nav-label">' + row.Menu_Name + '</span>';
                _html += '<span class="fa arrow"></span>';                 
                _html += '</a>';                                       
                _html += '<ul class="nav nav-second-level">';
                $.each(childNodes, function (i) {
                    var subrow = childNodes[i];
                    _html += '<li>';
                    _html += '<a class="J_menuItem" href="' + subrow.Menu_Navigateurl + '">' + subrow.Menu_Name + '</a>';
                    _html += '</li>';
                });
                _html += '</ul>';
                _html += '</li>';
            }
            else {                
                _html += '<li>';
                _html += '<a class="J_menuItem" href="' + row.Menu_Navigateurl + '"><i class="' + row.Menu_Imageindex + '"></i> <span class="nav-label">' + row.Menu_Name + '</span></a>';
                _html += '</li>';
            }
        }
    });
    $("#side-menu").append(_html);
}