using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceCloud.Models.Admin
{
    /// <summary>
    /// 待处理样本转运申请
    /// </summary>
    public class SpecWaitDealModel
    {
        public string PreOrgName { get; set; }
        public string PreDepName { get; set; }
        public string SpecimenTypeName { get; set; }
        public string ItemNames { get; set; }
        public string BarCode { get; set; }
        public DateTime PostTime { get; set; }
    }
}