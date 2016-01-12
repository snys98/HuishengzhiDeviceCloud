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
            CorpSecret=ConfigurationManager.AppSettings["CorpSecret"];
        }
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