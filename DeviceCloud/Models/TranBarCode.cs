using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceCloud.Models
{
    public class TranBarCode
    {
        public string BarCode { get; set; }
        public float SpecimentTypeTemperatureMax { get; set; }
        public float SpecimentTypeTemperatureMin { get; set; }
        public float SpecimentTypeHumidityMax { get; set; }
        public float SpecimentTypeHumidityMin { get; set; }
    }
}