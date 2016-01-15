using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weixin.Models
{
    public class Message
    {
        public Message()
        {
            sendtype = 0;
        }
        /// <summary>
        /// 消息接收用户
        /// </summary>
        public string wxcode { get; set; }
        public string mobile { get; set; }
        /// <summary>
        /// 消息正文
        /// </summary>
        public string body { get; set; }
        /// <summary>
        /// 发送类型:0微信;1短信;2都发
        /// </summary>
        public int sendtype { get; set; }
    }
}