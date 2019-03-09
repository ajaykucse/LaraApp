using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer.Interface.MasterSetup;

namespace DataAccessLayer.MasterSetup
{   
    public class ClsCostCenter : ICostCenter
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public CostCenterViewModel Model { get; set; }
        public ClsCostCenter()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new CostCenterViewModel();
        }

        public string SaveCostCenter()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("declare @CostCenterId int=(select ISNULL((Select Top 1 max(cast(CostCenterId as int))  from ERP.CostCenter),0)+1) \n");
                strSql.Append("Insert into ERP.CostCenter(CostCenterId, CostCenterDesc, CostCenterShortName, Address, Country, PhoneNo,MobileNo, ContactPerson, ContactPersonAdd, ContPersonPhoneNo, LedgerId, Status, EnterBy, EnterDate,Gadget) \n");
                strSql.Append("select @CostCenterId,N'" + Model.CostCenterDesc.Trim().Replace("'", "''") + "',N'" + Model.CostCenterShortName.Trim().Replace("'", "''") + "','" + Model.Address + "','" + Model.Country.Trim() + "', \n");
                strSql.Append("'" + Model.PhoneNo.Trim() + "','" + Model.MobileNo.Trim() + "','" + Model.ContactPerson.Trim() + "','" + Model.ContactPersonAdd.Trim() + "','" + Model.ContPersonPhoneNo.Trim() + "'," + ((Model.LedgerId == 0) ? "null" : "'" + Model.LedgerId + "'") + ",'" + Model.Status.ToString().ToLower() + "','" + Model.EnterBy.Trim() + "',GETDATE(),Gadget='"+Model.Gadget+"' \n");
                strSql.Append("SET @VNo =@CostCenterId");
            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP.CostCenter SET CostCenterDesc=N'" + Model.CostCenterDesc.Trim().Replace("'", "''") + "',CostCenterShortName = N'" + Model.CostCenterShortName.Trim().Replace("'", "''") + "',Address = '" + Model.Address + "',Country = '" + Model.Country.Trim() + "',PhoneNo = '" + Model.PhoneNo.Trim() + "',MobileNo = '" + Model.MobileNo.Trim() + "',ContactPerson ='" + Model.ContactPerson.Trim() + "',ContactPersonAdd ='" + Model.ContactPersonAdd.Trim() + "',ContPersonPhoneNo ='" + Model.ContPersonPhoneNo.Trim() + "',LedgerId=" + ((Model.LedgerId == 0) ? "null" : "'" + Model.LedgerId + "'") + ",[Status]='" + Model.Status.ToString().ToLower() + "',Gadget='"+Model.Gadget+"'  WHERE CostCenterId = '" + Model.CostCenterId + "' \n");
                strSql.Append("SET @VNo ='" + Model.CostCenterId + "'");
            }
            else if (Model.Tag == "DELETE")
            {
                strSql.Append("DELETE FROM ERP.CostCenter WHERE CostCenterId = '" + Model.CostCenterId + "' \n");
                strSql.Append("SET @VNo ='1'");
            }
            strSql.Append("\n COMMIT TRANSACTION \n");
            strSql.Append("END TRY \n");
            strSql.Append("BEGIN CATCH \n");
            strSql.Append("ROLLBACK TRANSACTION \n");
            strSql.Append("Set @VNo = '' \n");
            strSql.Append("END CATCH \n");

            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@VNo", SqlDbType.VarChar, 25);
            p[0].Direction = ParameterDirection.Output;
            DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString(), p);
            return p[0].Value.ToString();
        }

        public DataTable GetDataCostCenter(int CostCenterId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ERP.CostCenter.*,GlDesc from ERP.CostCenter left join ERP.GeneralLedger on ERP.GeneralLedger.LedgerId=ERP.CostCenter.LedgerId ");
            if (CostCenterId != 0)
                strSql.Append("  WHERE CostCenterId='" + CostCenterId + "'");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];

        }
    }
    public class CostCenterViewModel
    {
        public string Tag { get; set; }
        public int CostCenterId { get; set; }
        public string CostCenterDesc { get; set; }
        public string CostCenterShortName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPersonAdd { get; set; }
        public string ContPersonPhoneNo { get; set; }
        public Int64 LedgerId { get; set; }
        public bool Status { get; set; }
        public string EnterBy { get; set; }
        public DateTime EnterDate { get; set; }
        public string Gadget { get; set; }
    }
}
