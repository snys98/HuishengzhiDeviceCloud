using Senparc.Weixin.MP;
using Senparc.Weixin.MP.Entities.Request;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Weixin.Common;

namespace Weixin.Controllers
{
    public class WxController : Controller
    {
        [ActionName("callback")]
        public ActionResult callback(PostModel post, string echostr)
        {
            LogHelper.Debug("接收到微信回调");
            LogHelper.Debug(post.Msg_Signature);
            LogHelper.Debug(post.Timestamp);
            LogHelper.Debug(post.Nonce);
            LogHelper.Debug(echostr);
            string decryptEchoString = "";
            int i = Settings.WxDecrypt.VerifyURL(post.Msg_Signature, post.Timestamp, post.Nonce, echostr, ref decryptEchoString);
            if (i == 0 && !string.IsNullOrEmpty(decryptEchoString))
            {
                return Content(decryptEchoString);
            }
            return Content("error");
        }
    }
}
