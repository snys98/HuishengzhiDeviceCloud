$(document).ready(function () {
    //显示当前菜单
    Menus.Open("spectran_waitdeal");
    $("#chkall").click(function () {
        var checked = $(this).attr("checked");
        $("input[id*='chk_']").each(function () {
            if (checked == undefined) {
                $(this).removeAttr("checked");
            }
            else {
                $(this).attr("checked", checked);
            }
        });

    });

    $("#btndispatch").click(function () {
        $("input[id*='chk_']").each(function () {
            if ($(this).attr("checked") == true || $(this).attr("checked") =="checked") {
                alert($(this).attr("orgname"));
            }
        })
    });
});