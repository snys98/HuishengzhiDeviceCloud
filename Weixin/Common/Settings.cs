using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tencent;

namespace Weixin.Common
{
    public class Settings
    {
        static Settings()
        {
            WxDecrypt = new WXBizMsgCrypt(ConfigHelper.Token, ConfigHelper.EncodingAESKey, ConfigHelper.CorpID);
            SendUrl = "https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={0}";
        }

        /// <summary>
        /// 微信解密方法
        /// </summary>
        public static WXBizMsgCrypt WxDecrypt { get; set; }

        public static string SendUrl { get; private set; }
    }
}