using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceCloud.Models
{
    public class Courier
    {        
        public int CourierId { get; set; }
        public string BarCode { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        /// <summary>
        /// 默认运输工具
        /// </summary>
        public string DefaultTool { get; set; }
        /// <summary>
        /// 状态：1：正常；0：删除
        /// </summary>
        public int Status { get; set; }
    }
}