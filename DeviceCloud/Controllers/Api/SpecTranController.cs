﻿using DeviceCloud.Models;
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
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public int Post([FromBody]SpecTran value)
        {
            if (value == null)
            {
                throw new Exception("提交数据格式错误");
            }

            var r = Db.ExeProc<SpecTran>("Sp_PostSpecTran", value);
            return r;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}