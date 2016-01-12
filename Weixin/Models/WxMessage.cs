using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weixin.Models
{
    public class WxMessage
    {
        public WxMessage()
        {
            safe = 0;
        }
        /// <summary>
        /// 消息接收用户
        /// </summary>
        public string touser { get; set; }
        /// <summary>
        /// 消息正文
        /// </summary>
        public string body { get; set; }
        public int safe { get; set; }
    }
}