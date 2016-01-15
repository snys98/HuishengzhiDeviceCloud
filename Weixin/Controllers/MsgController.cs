using Senparc.Weixin.QY.CommonAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Weixin.Common;
using Weixin.Models;

namespace Weixin.Controllers
{
    public class MsgController : ApiController
    {
        public async Task<int> Post([FromBody]Message message)
        {
            int wxresult = 0;
            int smsresult = 0;
            //发送微信
            if (message.sendtype == 0 || message.sendtype == 2)
            {
                var accessToken = AccessTokenContainer.TryGetToken(ConfigHelper.CorpID, ConfigHelper.CorpSecret);
                var data = new
                {
                    touser = message.wxcode,
                    msgtype = "text",
                    agentid = ConfigHelper.AppID,
                    text = new
                    {
                        content = message.body
                    },
                    safe = 0
                };
                wxresult = (int)CommonJsonSend.Send(accessToken, Settings.SendUrl, data).errcode;
            }
            //发送短信
            if (message.sendtype == 1 || message.sendtype == 2)
            {
                smsresult = await SmsHelper.Send(message.mobile, message.body);
            }
            return (wxresult == 0 && smsresult == 0) ? 0 : -1;
        }
    }
}