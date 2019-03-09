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
    public class ClsSubledger : ISubledger
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public SubledgerViewModel Model { get; set; }
        public ClsSubledger()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new SubledgerViewModel();
        }
        public string SaveSubledger()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("declare @SubledgerId int=(select ISNULL((Select Top 1 max(cast(SubledgerId as int))  from ERP.Subledger),0)+1) \n");
                strSql.Append("insert into [ERP].[SubLedger] (SubledgerId, SubledgerDesc, SubledgerShortName, SubledgerType, SubledgerPicture, SubledgerPictureUrl, LedgerId, Address, Country, NationalId, PhoneNo, MobileNo, EmailId, PanNo, Fax, InterestRate, Status, EnterBy, EnterDate, BankAccountNo,Gadget)\n");
                strSql.Append("Select @SubledgerId,N'" + Model.SubledgerDesc.Trim().Replace("'", "''") + "',N'" + Model.SubledgerShortName.Trim().Replace("'", "''") + "', 'Account', null, null, " + ((Model.LedgerId == 0) ? "null" : "'" + Model.LedgerId + "'") + "," + ((Model.Address.Trim() == "") ? "null" : "N'" + Model.Address.Trim().Replace("'", "''") + "'") + "," + ((Model.Country.Trim()  == "") ? "null" : "N'" + Model.Country.Trim().Replace("'", "''") + "'") + "," + ((Model.NationalId == "") ? "null" : "'" + Model.NationalId.Trim().Replace("'", "''") + "'") + "," + ((Model.PhoneNo  == "") ? "null" : "N'" + Model.PhoneNo.Trim().Replace("'", "''") + "'") + "," + ((Model.MobileNo == "") ? "null" : "N'" + Model.MobileNo.Trim().Replace("'", "''") + "'") + "," + ((Model.EmailId  == "") ? "null" : "N'" + Model.EmailId.Trim().Replace("'", "''") + "'") + "," + ((Model.PanNo  == "") ? "null" : "N'" + Model.PanNo.Trim().Replace("'", "''") + "'") + "," + ((Model.Fax == "") ? "null" : "N'" + Model.Fax.Trim().Replace("'", "''") + "'") + " , " + Model.InterestRate + ", '" + Model.Status.ToString().ToLower() + "', '" + Model.EnterBy + "', GETDATE()," + ((Model.BankAccountNo == "") ? "null" : "N'" + Model.BankAccountNo.Trim().Replace("'", "''") + "'") + " ,'"+Model.Gadget + "'\n");

                strSql.Append("SET @VNo =@SubledgerId");
            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP.Subledger SET SubledgerDesc=N'" + Model.SubledgerDesc.Trim().Replace("'", "''") + "',SubledgerShortName = N'" + Model.SubledgerShortName.Trim().Replace("'", "''") + "',[Status]='" + Model.Status.ToString().ToLower() + "', LedgerId=" + ((Model.LedgerId == 0) ? "null" : "'" + Model.LedgerId + "'") + ",Address= " + ((Model.Address == "") ? "null" : "N'" + Model.Address.Trim().Replace("'", "''") + "'") + ", Country= " + ((Model.Country == "") ? "null" : "N'" + Model.Country.Trim().Replace("'", "''") + "'") + ",NationalId= " + ((Model.NationalId == "") ? "null" : "N'" + Model.NationalId.Trim().Replace("'", "''") + "'") + ", PhoneNo= " + ((Model.PhoneNo == "") ? "null" : "N'" + Model.PhoneNo.Trim().Replace("'", "''") + "'") + ", MobileNo= " + ((Model.MobileNo == "") ? "null" : "N'" + Model.MobileNo.Trim().Replace("'", "''") + "'") + ", EmailId=" + ((Model.EmailId == "") ? "null" : "N'" + Model.EmailId.Trim().Replace("'", "''") + "'") + ", PanNo= " + ((Model.PanNo == "") ? "null" : "N'" + Model.PanNo.Trim().Replace("'", "''") + "'") + ",Fax= " + ((Model.Fax == "") ? "null" : "N'" + Model.Fax.Trim().Replace("'", "''") + "'") + " , InterestRate=" + Model.InterestRate + " ,BankAccountNo= " + ((Model.BankAccountNo == "") ? "null" : "N'" + Model.BankAccountNo.Trim().Replace("'", "''") + "'") + " ,Gadget='"+ Model.Gadget + "' WHERE SubledgerId = '" + Model.SubledgerId + "' \n");
                strSql.Append("SET @VNo ='" + Model.SubledgerId + "'");
            }
            else if (Model.Tag == "DELETE")
            {
                strSql.Append("DELETE FROM ERP.Subledger WHERE SubledgerId = '" + Model.SubledgerId + "' \n");
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
        public DataTable GetDataSubledger(int SubledgerId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ERP.Subledger.*,GlDesc from ERP.Subledger left join ERP.GeneralLedger on ERP.GeneralLedger.LedgerId=ERP.Subledger.LedgerId ");
            if (SubledgerId != 0)
                strSql.Append("  WHERE SubledgerId='" + SubledgerId + "'");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
           
        }
        public void GetSingleSubledger(string SubledgerDesc)
        {
            DataTable dt = DAL.ExecuteDataset(CommandType.Text, "select SubledgerId,SubledgerDesc,SubledgerShortName from ERP.Subledger WHERE SubledgerDesc='" + SubledgerDesc.Replace("'","''") + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                DataRow ro = dt.Rows[0];
                if (ro["SubledgerId"] != DBNull.Value) Model.SubledgerId =Convert.ToInt32(ro["SubledgerId"].ToString());
                if (ro["SubledgerDesc"] != DBNull.Value) Model.SubledgerDesc = ro["SubledgerDesc"].ToString();
                if (ro["SubledgerShortName"] != DBNull.Value) Model.SubledgerShortName = ro["SubledgerShortName"].ToString();
            }
        }
    }

    public class SubledgerViewModel
    {
        public string Tag { get; set; }
        public int SubledgerId { get; set; }
        public string SubledgerDesc { get; set; }
        public string SubledgerShortName { get; set; }
        public string SubledgerType { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string NationalId { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string PanNo { get; set; }
        public string Fax { get; set; }
        public decimal InterestRate { get; set; }
        public Int64 LedgerId { get; set; }
        public string LedgerDesc { get; set; }
        public string SubledgerImage { get; set; }
        public bool Status { get; set; }
        public string EnterBy { get; set; }
        public string BankAccountNo { get; set; }
        public string Gadget { get; set; }
    }
}
