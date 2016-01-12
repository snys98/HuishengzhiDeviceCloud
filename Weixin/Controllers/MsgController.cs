using Senparc.Weixin.QY.CommonAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Weixin.Common;
using Weixin.Models;

namespace Weixin.Controllers
{
    public class MsgController : ApiController
    {
        public int Post([FromBody]WxMessage message)
        {
            var accessToken = AccessTokenContainer.TryGetToken(ConfigHelper.CorpID, ConfigHelper.CorpSecret);
            var data = new
            {
                touser = message.touser,
                msgtype = "text",
                agentid = ConfigHelper.AppID,
                text = new
                {
                    content = message.body
                },
                safe = message.safe
            };

            var result = CommonJsonSend.Send(accessToken, Settings.SendUrl, data);
            return (int)result.errcode;

        }
    }
}