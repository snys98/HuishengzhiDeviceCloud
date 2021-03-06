﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using DeviceCloud.Models;
using Newtonsoft.Json;

namespace DeviceCloud.Controllers
{
    public class SampleMonitorController : Controller
    {
        // GET: SampleMonitor
        public ActionResult Index(string tranId)
        {
            //var sampleMonitor = new SampleMonitor(sampleId,deviceId);
            ViewBag.NavId = "nav-item-monitor";
            ViewBag.TranId = tranId;
            return View();
        }

        public ActionResult Monitor(string tranId)
        {
            ViewBag.TranId = tranId;
            return View();
        }
        /// <summary>
        /// 获取SampleMonitor的Json字符串形式,这个是前台必须要的数据,根据设备id和起止时间
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        [System.Web.Mvc.HttpPost]
        public string GetSampleMonitorByTimeAndDeviceId([FromBody]string startTime, [FromBody]string endTime, [FromBody]string deviceId)
        {
            var sampleMonitor = new SampleMonitor(
                                    DateTime.ParseExact(startTime, "yyyy-MM-dd HH:mm:ss", null, DateTimeStyles.None),
                                    DateTime.ParseExact(endTime==null?DateTime.Now.ToString():endTime, "yyyy-MM-dd HH:mm:ss", null, DateTimeStyles.None),
                                    deviceId);
            string result = JsonConvert.SerializeObject(sampleMonitor);
            return result;
        }

        /// <summary>
        /// 获取SampleMonitor的Json字符串形式,这个是前台必须要的数据,根据转运记录的ID
        /// </summary>
        /// <param name="tranId"></param>
        /// <returns></returns>
        [System.Web.Mvc.HttpPost]
        public string GetSampleMonitorByTranId([FromBody]string tranId)
        {
            var sampleMonitor = new SampleMonitor(tranId);
            string result = JsonConvert.SerializeObject(sampleMonitor);
            return result;
        }
    }
}