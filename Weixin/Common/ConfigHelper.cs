using Senparc.Weixin.QY.CommonAPIs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Weixin.Common
{
    public class ConfigHelper
    {
        static ConfigHelper()
        {
            ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            CorpID = ConfigurationManager.AppSettings["CorpID"];
            Token = ConfigurationManager.AppSettings["Token"];
            EncodingAESKey = ConfigurationManager.AppSettings["EncodingAESKey"];
            AppID = Convert.ToInt32(ConfigurationManager.AppSettings["AppID"]);
            CorpSecret = ConfigurationManager.AppSettings["CorpSecret"];
            SmsAccount = ConfigurationManager.AppSettings["SmsAccount"];
            SmsPassword = ConfigurationManager.AppSettings["SmsPassword"];
            SmsUrl = ConfigurationManager.AppSettings["SmsUrl"];
        }

        /// <summary>
        /// SMS接口账号
        /// </summary>
        public static string SmsAccount { private set; get; }
        /// <summary>
        /// SMS密码
        /// </summary>
        public static string SmsPassword { private set; get; }
        /// <summary>
        /// SMS接口地址
        /// </summary>
        public static string SmsUrl { private set; get; }
        public static string CorpSecret
        {
            private set;
            get;
        }

        public static int AppID
        {
            private set;
            get;
        }
        public static string ConnectionString
        {
            private set;
            get;
        }

        public static string CorpID
        {
            private set;
            get;
        }

        public static string Token
        {
            private set;
            get;
        }

        public static string EncodingAESKey
        {
            private set;
            get;
        }
    }
}