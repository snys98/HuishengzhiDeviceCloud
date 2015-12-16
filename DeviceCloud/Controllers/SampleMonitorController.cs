using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeviceCloud.Models;

namespace DeviceCloud.Controllers
{
    public class SampleMonitorController : Controller
    {
        // GET: SampleMonitor
        public ActionResult Index(string sampleId, string deviceId)
        {
            var sampleMonitor = new SampleMonitor(sampleId,deviceId);
            ViewBag.Monitor = sampleMonitor;
            return View();
        }
    }
}