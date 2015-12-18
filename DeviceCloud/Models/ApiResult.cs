using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceCloud.Models
{
    [Serializable]
    public class ApiResult<T>
    {
        public bool HasError { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        public ApiResult(T data)
        {
            Data = data;
        }

        public ApiResult(bool hasError, string message)
        {
            HasError = hasError;
            Message = message;
        }
    }
}