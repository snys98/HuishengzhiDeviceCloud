using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceCloud.Models
{
    /// <summary>
    /// 样本转运记录
    /// </summary>
    public class SpecTran
    {
        private string _barcode;
        private long _preid;
        private string _sex;
        private decimal _age;
        private string _nationality;
        private string _name;
        private string _residence;
        private decimal _price;
        private string _curdisease;
        private string _preorgname;
        private string _predepname;
        private string _predoctorname;
        private string _curbedno;
        private DateTime? _pretime;
        private string _prestattext;
        private string _itemnames;
        private string _specimentypename;
        private string _comment;
        private int _preorgid;
        private int _predepid;
        private int _predoctorid;
        private int _patientid;
        private int _checkrecid;
        private int _itemid;
        private int _specimentypeid;
        private DateTime? _posttime;
        private DateTime? _outtime;
        private DateTime? _receivetime;
        private int _transtatus;
        /// <summary>
        /// 条码
        /// </summary>
        public string BarCode
        {
            set { _barcode = value; }
            get { return _barcode; }
        }
        /// <summary>
        /// 开单ID
        /// </summary>
        public long PreID
        {
            set { _preid = value; }
            get { return _preid; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 年龄
        /// </summary>
        public decimal Age
        {
            set { _age = value; }
            get { return _age; }
        }
        /// <summary>
        /// 民族
        /// </summary>
        public string Nationality
        {
            set { _nationality = value; }
            get { return _nationality; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 居住地
        /// </summary>
        public string Residence
        {
            set { _residence = value; }
            get { return _residence; }
        }
        /// <summary>
        /// 费用
        /// </summary>
        public decimal Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 医生诊断
        /// </summary>
        public string CurDisease
        {
            set { _curdisease = value; }
            get { return _curdisease; }
        }
        /// <summary>
        /// 开单医院
        /// </summary>
        public string PreOrgName
        {
            set { _preorgname = value; }
            get { return _preorgname; }
        }
        /// <summary>
        /// 开单部门
        /// </summary>
        public string PreDepName
        {
            set { _predepname = value; }
            get { return _predepname; }
        }
        /// <summary>
        /// 主治医生
        /// </summary>
        public string PreDoctorName
        {
            set { _predoctorname = value; }
            get { return _predoctorname; }
        }
        /// <summary>
        /// 床号
        /// </summary>
        public string curBedNo
        {
            set { _curbedno = value; }
            get { return _curbedno; }
        }
        /// <summary>
        /// 开单时间
        /// </summary>
        public DateTime? PreTime
        {
            set { _pretime = value; }
            get { return _pretime; }
        }
        /// <summary>
        /// 开单状态
        /// </summary>
        public string PreStatText
        {
            set { _prestattext = value; }
            get { return _prestattext; }
        }
        /// <summary>
        /// 检验项目
        /// </summary>
        public string ItemNames
        {
            set { _itemnames = value; }
            get { return _itemnames; }
        }
        /// <summary>
        /// 样本类型
        /// </summary>
        public string SpecimenTypeName
        {
            set { _specimentypename = value; }
            get { return _specimentypename; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Comment
        {
            set { _comment = value; }
            get { return _comment; }
        }
        /// <summary>
        /// 开单医院ID
        /// </summary>
        public int PreOrgID
        {
            set { _preorgid = value; }
            get { return _preorgid; }
        }
        /// <summary>
        /// 开单部门ID
        /// </summary>
        public int PreDepID
        {
            set { _predepid = value; }
            get { return _predepid; }
        }
        /// <summary>
        /// 主治医生ID
        /// </summary>
        public int PreDoctorID
        {
            set { _predoctorid = value; }
            get { return _predoctorid; }
        }
        /// <summary>
        /// 病人ID
        /// </summary>
        public int PatientID
        {
            set { _patientid = value; }
            get { return _patientid; }
        }
        /// <summary>
        /// 开单记录ID
        /// </summary>
        public int CheckRecID
        {
            set { _checkrecid = value; }
            get { return _checkrecid; }
        }
        /// <summary>
        /// 项目ID
        /// </summary>
        public int ItemID
        {
            set { _itemid = value; }
            get { return _itemid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SpecimenTypeID
        {
            set { _specimentypeid = value; }
            get { return _specimentypeid; }
        }
        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime? PostTime
        {
            set { _posttime = value; }
            get { return _posttime; }
        }
        /// <summary>
        /// 转出时间
        /// </summary>
        public DateTime? OutTime
        {
            set { _outtime = value; }
            get { return _outtime; }
        }
        /// <summary>
        /// 接收时间
        /// </summary>
        public DateTime? ReceiveTime
        {
            set { _receivetime = value; }
            get { return _receivetime; }
        }
        /// <summary>
        /// 转运状态：0：待处理；1：已派工；2：已转出；3：已完成
        /// </summary>
        public int TranStatus
        {
            set { _transtatus = value; }
            get { return _transtatus; }
        }
    }
}