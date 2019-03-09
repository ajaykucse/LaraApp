using DataAccessLayer.Interface.MasterSetup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MasterSetup
{
    public class ClsMainSalesman : IMainSalesman
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public MainSalesmanViewModel Model { get; set; }
        public ClsMainSalesman()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new MainSalesmanViewModel();
        }

        public string SaveMainSalesman()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("declare @MainSalesmanId int=(select ISNULL((Select Top 1 max(cast(MainSalesmanId as int))  from ERP.MainSalesman),0)+1) \n");
                strSql.Append("Insert into ERP.MainSalesman(MainSalesmanId, MainSalesmanDesc, MainSalesmanShortName,Address, PhoneNo, MobileNo,  CommissionRate, LedgerId, BranchId, CompanyUnitId, Status, EnterBy, EnterDate , Gadget) \n");
                strSql.Append("Select @MainSalesmanId,N'" + Model.MainSalesmanDesc.Trim().Replace("'", "''") + "',N'" + Model.MainSalesmanShortName.Trim().Replace("'", "''") + "',  " + ((Model.Address.Trim() == "") ? "null" : "N'" + Model.Address.Trim().Replace("'", "''") + "'") + "," + ((Model.PhoneNo == "") ? "null" : "N'" + Model.PhoneNo.Trim().Replace("'", "''") + "'") + "," + ((Model.MobileNo == "") ? "null" : "N'" + Model.MobileNo.Trim().Replace("'", "''") + "'") + "," + Model.CommissionRate + "," + ((Model.LedgerId == 0) ? "null" : "'" + Model.LedgerId + "'") + "," + ((Model.BranchId == 0) ? "null" : "'" + Model.BranchId + "'") + "," + ((Model.CompanyUnitId == 0) ? "null" : "'" + Model.CompanyUnitId + "'") + ", '" + Model.Status.ToString().ToLower() + "', '" + Model.EnterBy + "', GETDATE(),'" + Model.Gadget + "' \n");

                strSql.Append("SET @VNo =@MainSalesmanId");
            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP.MainSalesman SET MainSalesmanDesc=N'" + Model.MainSalesmanDesc.Trim().Replace("'", "''") + "',MainSalesmanShortName = N'" + Model.MainSalesmanShortName.Trim().Replace("'", "''") + "', Address=" + ((Model.Address.Trim() == "") ? "null" : "N'" + Model.Address.Trim().Replace("'", "''") + "'") + ",PhoneNo=" + "" + ((Model.PhoneNo == "") ? "null" : "N'" + Model.PhoneNo.Trim().Replace("'", "''") + "'") + ",MobileNo=" + "" + ((Model.MobileNo == "") ? "null" : "N'" + Model.MobileNo.Trim().Replace("'", "''") + "'") + ",LedgerId=" + ((Model.LedgerId == 0) ? "null" : "'" + Model.LedgerId + "'") + ",BranchId=" + ((Model.BranchId == 0) ? "null" : "'" + Model.BranchId + "'") + ",CompanyUnitId=" + ((Model.CompanyUnitId == 0) ? "null" : "'" + Model.CompanyUnitId + "'") + ",CommissionRate= " + Model.CommissionRate + ",Status='" + Model.Status.ToString().ToLower() + "',EnterBy= '" + Model.EnterBy + "',Gadget='" + Model.Gadget + "'  WHERE MainSalesmanId = '" + Model.MainSalesmanId + "' \n");
                strSql.Append("SET @VNo ='" + Model.MainSalesmanId + "'");
            }
            else if (Model.Tag == "DELETE")
            {
                strSql.Append("DELETE FROM ERP.MainSalesman WHERE MainSalesmanId = '" + Model.MainSalesmanId + "' \n");
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
        public DataTable GetDataMainSalesman(int MainSalesmanId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ERP.MainSalesman.*,GlDesc from ERP.MainSalesman left join ERP.GeneralLedger on  ERP.MainSalesman.LedgerId= ERP.GeneralLedger.LedgerId");
            if (MainSalesmanId != 0)
                strSql.Append("  WHERE MainSalesmanId='" + MainSalesmanId + "' ");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];

        }
    }
    public class MainSalesmanViewModel
    {
        public string Tag { get; set; }
        public int MainSalesmanId { get; set; }
        public string MainSalesmanDesc { get; set; }
        public string MainSalesmanShortName { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public decimal CommissionRate { get; set; }
        public int LedgerId { get; set; }
        public int BranchId { get; set; }
        public int CompanyUnitId { get; set; }
        public bool Status { get; set; }
        public string EnterBy { get; set; }
        public DateTime EnterDate { get; set; }
        public string Gadget { get; set; }
    }
}