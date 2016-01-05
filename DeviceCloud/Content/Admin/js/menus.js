Menus = function () { }
Menus.Open=function(id){
    $("#" + id).parent().parent().addClass("am-in");
    $("#" + id).addClass("am-active");
}
