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
        var orgname = "";
        var barcodes = new Array();
        $("input[id*='chk_']").each(function () {
            if ($(this).attr("checked") == true || $(this).attr("checked") =="checked") {
                var t = $(this).attr("orgname");
                if(orgname!="" && orgname!=t){
                    alert("一次派工不能选择多家医院！");
                    return;
                }
                orgname = t;
                barcodes.push($(this).attr("val"));
            }
        })
        if(barcodes.length<1){
            alert("请选择转运申请记录！");
            return;
        }
        var carriage = $("#carriage").val();
        if (carriage == "") {
            alert("请选择承运人");
            return;
        }
        $.post(hosturl+"Admin/SpecTran/Dispatch", { DeviceCourierID: carriage, OutHospName: orgname, barcodes: barcodes }, function (result) {
            if (result.Status == 1) {
                alert("派工成功！");
                gopage(0);
            }
            else {
                alert(result.ErrorMessage);
            }
        });

    });
});

function gopage(index) {
    $("#PageIndex").val(index);
    $("#form1").submit();
}