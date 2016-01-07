using DeviceCloud.Models.Admin;
using DeviceCloud.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeviceCloud.Areas.Admin.Controllers
{
    /// <summary>
    /// 样本转运
    /// </summary>
    [AdminAuthorize]
    public class SpecTranController : Controller
    {
        //
        // GET: /Admin/SpecTran/
        public ActionResult Index(int PageIndex = 0, string OrgName = "")
        {
            int PageSize = Config.DefaultPageSize;
            int RecordCount = 0;
            var data = new SpectranProvider().QueryPage(PageSize, PageIndex, OrgName, out RecordCount);
            ViewBag.PageCount = Math.Ceiling(RecordCount / Convert.ToDecimal(PageSize));
            ViewBag.PageIndex = PageIndex;
            ViewBag.OrgName = OrgName;
            ViewBag.RecordCount = RecordCount;
            ViewBag.Carriage = new Provider.CourierProvder().GetAll();
            return View(data);
        }

        public JsonResult Dispatch(int DeviceCourierID, string OutHospName, Array barcodes)
        {
            if (barcodes == null || barcodes.Length < 1)
                return Json(new { Status = 0, ErrorMessage = "转运申请记录为空" });
            try
            {
                new SpectranProvider().SaveDispctch(DeviceCourierID, OutHospName, barcodes);
                return Json(new { Status = 1, ErrorMessage = "" });
            }
            catch (Exception ex)
            {
                return Json(new { Status = 0, ErrorMessage = ex.Message });
            }
        }
    }
}