using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using Dapper;
using DeviceLibrary;

namespace DeviceCloud.Models
{
    public class SampleMonitor
    {
        public string SampleId { get; private set; }
        public string DeviceId { get; private set; }

        public List<TranLog> Datas { get; private set; }

        public SampleMonitor(string sampleId,string deviceId)
        {
            SampleId = sampleId;
            DeviceId = deviceId;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("SampleMonitorConnectionString")))
            {
                Datas = con.Query<TranLog>(string.Format("SELECT * FROM dbo.TranLog WHERE TranId = '{0}' AND DeviceAddress = '{1}'", sampleId, deviceId)).ToList();
            }
            
        }
    }

    public static class SampleMonitorExtentions
    {
        public static string ToMarkerInfo(this TranLog tranLog)
        {
            string html = "<div>";
            html += string.Format("<p>温度: {0} ℃<p>", tranLog.Temperature);
            html += string.Format("<p>湿度: {0} %<p>", tranLog.Humidity);
            html += "</div>";
            return html;
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