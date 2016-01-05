using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace DeviceCloud.Models
{
    public class ApiResult
    {
        public HttpStatusCode Status { get; set; }
        public object Data { get; set; }
        public string ErrorMessage { get; set; }      
    }
}