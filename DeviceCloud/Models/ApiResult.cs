using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceCloud.Models
{
    public class ApiResult<T>
    {
        public bool HasError { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public ApiResult()
        {
        }
        public ApiResult(T data)
        {
            Data = data;
            Message = "";
        }

        public ApiResult(bool hasError, string message)
        {
            HasError = hasError;
            Message = message;
        }
    }
}