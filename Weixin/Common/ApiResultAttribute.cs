using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;
using Weixin.Models;

namespace Weixin.Common
{
    public class ApiResultAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            // 若发生例外则不在这边处理
            if (actionExecutedContext.Exception != null)
                return;

            base.OnActionExecuted(actionExecutedContext);

            ApiResult result = new ApiResult();

            // 取得由 API 返回的状态代码
            result.Status = actionExecutedContext.ActionContext.Response.StatusCode;
            result.Data = actionExecutedContext.ActionContext.Response.Content.ReadAsStringAsync().Result;
            // 取得由 API 返回的资料
            result.Data = actionExecutedContext.ActionContext.Response.Content.ReadAsAsync<object>().Result;
            // 重新封装回传格式
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(result.Status, result);
        }

    }
}