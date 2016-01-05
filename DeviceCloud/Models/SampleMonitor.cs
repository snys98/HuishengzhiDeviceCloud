using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Dapper;
using DeviceLibrary;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DeviceCloud.Models
{
    public class SampleMonitor
    {
        public string DeviceId { get; private set; }
        public Courier Courier { get; private set; }

        public List<TranLog> TransLogs { get; private set; }

        //public SampleMonitor(string sampleId, string deviceId)
        //{
        //    SampleId = sampleId;
        //    DeviceId = deviceId;
        //    using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("SampleMonitorConnectionString")))
        //    {
        //        TransLogs = con.Query<TranLog>(string.Format("SELECT * FROM dbo.TranLog WHERE TranId = '{0}' AND DeviceAddress = '{1}'", sampleId, deviceId)).ToList();
        //    }
        //    TransLogs.ConvertToBaiduCord();
        //}

        public SampleMonitor(DateTime startTime, DateTime endTime, string deviceId)
        {
            
            DeviceId = deviceId;
            using (SqlConnection con = Db.Create())
            {
                Dapper.DynamicParameters parameters = new Dapper.DynamicParameters();
                parameters.Add("@StartTime", startTime);
                parameters.Add("@EndTime", endTime);
                parameters.Add("@DeviceId", deviceId);
                TransLogs = Db.QueryProc<TranLog>("Sp_QueryTransLogs", parameters).ToList();
                parameters = new Dapper.DynamicParameters();
                parameters.Add("@DeviceId", deviceId);
                Courier = Db.QueryProc<Courier>("Sp_QueryCourierByDeviceId", parameters).First();
            }
            TransLogs.ConvertToBaiduCord();
        }
    }

    public static class SampleMonitorExtentions
    {
        /// <summary>
        /// 将转运记录(集合)的坐标系转换到百度坐标,Todo:坐标转换后位置不准&网络访问性能优化和服务器cpu性能优化哪个重要
        /// </summary>
        /// <param name="tranLogs"></param>
        public static void ConvertToBaiduCord(this List<TranLog> tranLogs)
        {
            string jsonData = tranLogs.Aggregate("http://api.map.baidu.com/geoconv/v1/?coords=", (current, tranLog) => current + String.Concat(tranLog.Longitude, ",", tranLog.Latitude, ";"));
            jsonData = jsonData.TrimEnd(';');
            jsonData += "&from=1&to=5&ak=" + ConfigurationManager.AppSettings.Get("BaiduApiKey");
            WebClient webClient = new WebClient();
            var jsonObject = JsonConvert.DeserializeObject<JObject>(webClient.DownloadString(jsonData));
            var status = jsonObject.GetValue("status").ToObject<int>();
            if (status == 0)
            {
                var convertedList = jsonObject.GetValue("result").ToObject<JArray>();
                for (int i = 0; i < convertedList.Count; i++)
                {
                    tranLogs[i].Longitude = convertedList[i].Value<decimal>("x");
                    tranLogs[i].Latitude = convertedList[i].Value<decimal>("y");
                }
            }
        }
    }
    public class TranLog
    {
        public System.Guid Id { get; set; }
        public string TranId { get; set; }
        public int DataLength { get; set; }
        public int ProtocolVersion { get; set; }
        public int UploadInterval { get; set; }
        public int ChannelCount { get; set; }
        public bool IsLargeBattery { get; set; }
        public decimal Voltage { get; set; }
        public int SignalStrength { get; set; }
        public System.DateTime UploadTime { get; set; }
        public string DeviceAddress { get; set; }
        public string CRC16 { get; set; }
        public bool IsNorth { get; set; }
        public bool IsEast { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public decimal Temperature { get; set; }
        public decimal Humidity { get; set; }
        public System.DateTime Created { get; set; }
    }
}