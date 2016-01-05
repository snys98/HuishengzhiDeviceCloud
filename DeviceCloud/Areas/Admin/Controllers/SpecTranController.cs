using DeviceCloud.Models.Admin;
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
            int PageSize = 20;
            Dapper.DynamicParameters p = new Dapper.DynamicParameters();
            p.Add("@PageSize", PageSize);
            p.Add("@PageIndex", PageIndex);
            p.Add("@OrgName", OrgName);
            p.Add("@RecordCount", 0, DbType.Int32, ParameterDirection.Output);
            var data = Db.QueryProc<SpecWaitDealModel>("Sp_QueryWaitDealSpecTranList", p);
            ViewBag.RecordCount = p.Get<int>("@RecordCount");
            ViewBag.PageCount = Math.Ceiling((p.Get<int>("@RecordCount")) / Convert.ToDecimal(PageSize));
            ViewBag.PageIndex = PageIndex;
            ViewBag.OrgName = OrgName;
            return View(data);
        }
    }
}