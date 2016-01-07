using DeviceCloud.Models;
using DeviceCloud.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;

namespace DeviceCloud.Controllers.Api
{
    /// <summary>
    /// 承运人API
    /// </summary>
    public class CarriageController : ApiController
    {


        // GET api/<controller>/5
        /// <summary>
        /// 根据条码获取承运人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CourierDevice Get(string BarCode, string OrgName)
        {
            var r = new CourierProvder().Query(BarCode, OrgName);
            if (r.Count() == 0)
                throw new Exception("不存在该承运人信息或没有该承运人的派工单！");
            else
                return r.First();
        }
    }
}