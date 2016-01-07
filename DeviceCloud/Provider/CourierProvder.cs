using DeviceCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceCloud.Provider
{
    /// <summary>
    /// 承运人
    /// </summary>
    public class CourierProvder
    {
        public IEnumerable<CourierDevice> Query(string barcode,string orgname)
        {
            Dapper.DynamicParameters p = new Dapper.DynamicParameters();
            p.Add("@BarCode", barcode);
            p.Add("@OrgName", orgname);
            return Db.QueryProc<CourierDevice>("Sp_QueryCourierForBarCode", p);
        }

        public IEnumerable<CourierDevice> GetAll()
        {
            return Db.QueryProc<CourierDevice>("Sp_QueryAllCourier");
            
        }
    }
}