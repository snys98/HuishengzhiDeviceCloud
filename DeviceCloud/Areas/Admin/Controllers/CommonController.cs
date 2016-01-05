using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeviceCloud.Areas.Admin.Controllers
{
    public class CommonController : Controller
    {
        //
        // GET: /Admin/Common/
        public ActionResult Menus()
        {
            return View();
        }
	}
}