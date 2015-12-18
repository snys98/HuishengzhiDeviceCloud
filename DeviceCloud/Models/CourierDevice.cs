using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceCloud.Models
{
    /// <summary>
    /// 承运人设备
    /// </summary>
    public class CourierDevice : Courier
    {
        /// <summary>
        /// 设备ID
        /// </summary>
        public string DeviceId { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceName { get; set; }
    }
}