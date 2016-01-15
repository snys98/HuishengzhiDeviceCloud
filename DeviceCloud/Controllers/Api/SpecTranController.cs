using DeviceCloud.Models;
using DeviceCloud.Provider;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DeviceCloud.Controllers.Api
{
    /// <summary>
    /// 样本转运
    /// </summary>
    public class SpecTranController : ApiController
    {

        /// <summary>
        /// 转出申请
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Post([FromBody]SpecTran value)
        {
            if (value == null)
            {
                throw new Exception("提交数据格式错误");
            }
            return new SpectranProvider().Save(value);
        }

        /// <summary>
        /// 确认转出
        /// </summary>
        /// <param name="data"></param>
        public int Put([FromBody]JsonData data)
        {
            Trans model = JsonConvert.DeserializeObject<Trans>(data.Json);
            new SpectranProvider().SpecTranOut(model);
            return 0;
        }

        /// <summary>
        /// 接收样本
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Receive(string personId, string personName, string barCode)
        {
            new SpectranProvider().ReceiveSpec(personId, personName, barCode);
            return 0;
        }
    }
}