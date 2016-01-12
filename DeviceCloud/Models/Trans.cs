using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceCloud.Models
{
    /// <summary>
    /// 转运派工记录
    /// </summary>
    public class Trans
    {
        private Guid _tranid;
        private int _devicecourierid;
        private string _outhospname;
        private string _outpersonname;
        private string _receivehospname;
        private string _receivepersonname;
        private DateTime _outtime;
        private DateTime _receivetime;
        private int _outhospid;
        private int _outpersonid;
        private int _receivehospid;
        private int _receivepersonid;
        /// <summary>
        /// 
        /// </summary>
        public Guid TranID
        {
            set { _tranid = value; }
            get { return _tranid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int DeviceCourierID
        {
            set { _devicecourierid = value; }
            get { return _devicecourierid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OutHospName
        {
            set { _outhospname = value; }
            get { return _outhospname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OutPersonName
        {
            set { _outpersonname = value; }
            get { return _outpersonname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReceiveHospName
        {
            set { _receivehospname = value; }
            get { return _receivehospname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReceivePersonName
        {
            set { _receivepersonname = value; }
            get { return _receivepersonname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime OutTime
        {
            set { _outtime = value; }
            get { return _outtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ReceiveTime
        {
            set { _receivetime = value; }
            get { return _receivetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OutHospID
        {
            set { _outhospid = value; }
            get { return _outhospid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OutPersonID
        {
            set { _outpersonid = value; }
            get { return _outpersonid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ReceiveHospID
        {
            set { _receivehospid = value; }
            get { return _receivehospid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ReceivePersonID
        {
            set { _receivepersonid = value; }
            get { return _receivepersonid; }
        }
        /// <summary>
        /// 样本条码
        /// </summary>
        public List<TranBarCode> BarCodes { get; set; }
    }
}