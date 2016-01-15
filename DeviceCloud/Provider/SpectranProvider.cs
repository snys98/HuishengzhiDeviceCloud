using DeviceCloud.Models;
using DeviceCloud.Models.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DeviceCloud.Provider
{
    public class SpectranProvider
    {
        public int Save(SpecTran value)
        {
            return Db.ExeProc<SpecTran>("Sp_PostSpecTran", value);
        }

        public IEnumerable<SpecWaitDealModel> QueryPage(int PageSize, int PageIndex, string OrgName, out int RecordCount)
        {
            Dapper.DynamicParameters p = new Dapper.DynamicParameters();
            p.Add("@PageSize", PageSize);
            p.Add("@PageIndex", PageIndex);
            p.Add("@OrgName", OrgName);
            p.Add("@RecordCount", 0, DbType.Int32, ParameterDirection.Output);
            var data = Db.QueryProc<SpecWaitDealModel>("Sp_QueryWaitDealSpecTranList", p);
            RecordCount = p.Get<int>("@RecordCount");
            return data;
        }

        public void SaveDispctch(int DeviceCourierID, string OutHospName, Array barcodes)
        {
            var tranID = Guid.NewGuid();
            Dapper.DynamicParameters p = new Dapper.DynamicParameters();
            p.Add("@TranID", tranID);
            p.Add("@DeviceCourierID", DeviceCourierID);
            p.Add("@OutHospName", OutHospName);
            Db.ExeProc("Sp_SaveDispatch", p);
            foreach (var item in barcodes)
            {
                Dapper.DynamicParameters dp = new Dapper.DynamicParameters();
                dp.Add("@BarCode", item);
                dp.Add("@Status", 1);
                Db.ExeProc("Sp_ModifyTranStatus", dp);
            }

        }

        public void SpecTranOut(Trans tran)
        {
            Dapper.DynamicParameters p = new Dapper.DynamicParameters();
            p.Add("@TranID", tran.TranID);
            p.Add("@DeviceCourierID", tran.DeviceCourierID);
            p.Add("@OutPersonName", tran.OutPersonName);
            p.Add("@OutHospID", tran.OutHospID);
            p.Add("@OutPersonID", tran.OutPersonID);
            p.Add("@ReceiveHospName", tran.ReceiveHospName);
            p.Add("@ReceiveHospID", tran.ReceiveHospID);
            Db.ExeProc("Sp_SaveSpecTranOut", p);
            foreach (var item in tran.BarCodes)
            {
                Dapper.DynamicParameters dp = new Dapper.DynamicParameters();
                dp.Add("@TranID", tran.TranID);
                dp.Add("@BarCode", item.BarCode);
                dp.Add("@SpecimentTypeTemperatureMax", item.SpecimentTypeTemperatureMax);
                dp.Add("@SpecimentTypeTemperatureMin", item.SpecimentTypeTemperatureMin);
                dp.Add("@SpecimentTypeHumidityMax", item.SpecimentTypeHumidityMax);
                dp.Add("@SpecimentTypeHumidityMin", item.SpecimentTypeHumidityMin);
                Db.ExeProc("Sp_SaveDispatchDetail", dp);
            }
        }

        public void ReceiveSpec(string personId,string personName,string barcode)
        {
            Dapper.DynamicParameters p = new Dapper.DynamicParameters();
            p.Add("@PersonName",personName);
            p.Add("@PersonID", personId);
            p.Add("@BarCode",barcode);
            Db.ExeProc("Sp_SaveDispatchDetail", p);
        }
    }
}