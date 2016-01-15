using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Weixin.Common
{
    public class SmsHelper
    {
        public async static Task<int> Send(string mobile, string content)
        {
            Dictionary<string, string> p = new Dictionary<string, string>();
            p.Add("account", ConfigHelper.SmsAccount);
            p.Add("pswd", ConfigHelper.SmsPassword);
            p.Add("mobile", mobile);
            p.Add("msg", content);
            p.Add("needstatus", "true");
            var message = string.Empty;
            var handler = new HttpClientHandler()
            {
                MaxRequestContentBufferSize = int.MaxValue,
            };
            //创建HttpClient（注意传入HttpClientHandler）
            using (var http = new HttpClient(handler) { MaxResponseContentBufferSize = int.MaxValue })
            {
                //使用FormUrlEncodedContent做HttpContent
                var data = new FormUrlEncodedContent(p);
                //await异步等待回应
                var response = await http.PostAsync(ConfigHelper.SmsUrl, data);
                try
                {
                    //确保HTTP成功状态值
                    response.EnsureSuccessStatusCode();
                }
                catch
                {
                    return 500;
                }
                var r = await response.Content.ReadAsStringAsync();
                LogHelper.Info("短信接口返回：" + r);
                if (!string.IsNullOrEmpty(r))
                {
                    string[] sp = r.Split(new char[] { '\n' });
                    string[] inf = sp[0].Split(new char[] { ',' });
                    if (inf.Length > 1)
                    {
                        return int.Parse(inf[1]);
                    }
                }
                return 500;
            }
        }
    }
}