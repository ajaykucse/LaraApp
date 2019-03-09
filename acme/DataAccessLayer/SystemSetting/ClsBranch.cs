using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SystemSetting
{
    public class ClsBranch
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public CompanyUnitViewModel Model { get; set; }

        public ClsBranch()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new CompanyUnitViewModel();
        }

        public string SaveBranch()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("declare @BranchId int=(select ISNULL((Select Top 1 max(cast(BranchId as int))  from ERP.Branch),0)+1) \n");
                strSql.Append("Insert into ERP.Branch(BranchId, BranchName, BranchShortName, Address, City, State, Country, PhoneNo, Fax, Email, ContactPerson, ContactPersonAdd, ContactPersonPhone, ContactPersonMobileNo, EnterBy, EnterDate,Gadget) \n");
                strSql.Append("Select @BranchId,'" + Model.BranchName.Trim()+"','"+Model.BranchShortName.Trim()+ "', " + ((Model.Address.Trim() == "") ? "null" : "N'" + Model.Address.Trim().Replace("'", "''") + "'") + ", " + ((Model.City.Trim() == "") ? "null" : "N'" + Model.City.Trim().Replace("'", "''") + "'") + ", " + ((Model.State.Trim() == "") ? "null" : "N'" + Model.State.Trim().Replace("'", "''") + "'") + ", " + ((Model.Country.Trim() == "") ? "null" : "N'" + Model.Country.Trim().Replace("'", "''") + "'") + ", " + ((Model.PhoneNo.Trim() == "") ? "null" : "N'" + Model.PhoneNo.Trim().Replace("'", "''") + "'") + ", " + ((Model.Fax .Trim() == "") ? "null" : "N'" + Model.Fax.Trim().Replace("'", "''") + "'") + ", " + ((Model.Email .Trim() == "") ? "null" : "N'" + Model.Email.Trim().Replace("'", "''") + "'") + ", " + ((Model.ContactPerson.Trim() == "") ? "null" : "N'" + Model.ContactPerson.Trim().Replace("'", "''") + "'") + ", " + ((Model.ContactPersonAdd.Trim() == "") ? "null" : "N'" + Model.ContactPersonAdd.Trim().Replace("'", "''") + "'") + ", " + ((Model.ContactPersonPhone.Trim() == "") ? "null" : "N'" + Model.ContactPersonPhone.Trim().Replace("'", "''") + "'") + ", " + ((Model.ContactPersonPhone.Trim() == "") ? "null" : "N'" + Model.ContactPersonPhone.Trim().Replace("'", "''") + "'") + ",'" + Model.EnterBy.Trim()+ "',GETDATE() ,'"+Model.Gadget+"'\n");
                strSql.Append("SET @VNo =@BranchId");

            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP.Branch SET [BranchName] = '" + Model.BranchName.Trim() + "',[BranchShortName] = '" + Model.BranchShortName.Trim() + "',[Address] =  " + ((Model.Address.Trim() == "") ? "null" : "N'" + Model.Address.Trim().Replace("'", "''") + "'") + ",[City] =  " + ((Model.City.Trim() == "") ? "null" : "N'" + Model.City.Trim().Replace("'", "''") + "'") + ",[State] =  " + ((Model.State.Trim() == "") ? "null" : "N'" + Model.State.Trim().Replace("'", "''") + "'") + ",[Country] =  " + ((Model.Country.Trim() == "") ? "null" : "N'" + Model.Country.Trim().Replace("'", "''") + "'") + ",[PhoneNo] =  " + ((Model.PhoneNo.Trim() == "") ? "null" : "N'" + Model.PhoneNo.Trim().Replace("'", "''") + "'") + ",[Fax] =  " + ((Model.Fax.Trim() == "") ? "null" : "N'" + Model.Fax.Trim().Replace("'", "''") + "'") + ",[Email] =  " + ((Model.Email.Trim() == "") ? "null" : "N'" + Model.Email.Trim().Replace("'", "''") + "'") + ",[ContactPerson] =  " + ((Model.ContactPerson.Trim() == "") ? "null" : "N'" + Model.ContactPerson.Trim().Replace("'", "''") + "'") + ",[ContactPersonAdd] =  " + ((Model.ContactPersonAdd .Trim() == "") ? "null" : "N'" + Model.ContactPersonAdd.Trim().Replace("'", "''") + "'") + ",[ContactPersonPhone] =  " + ((Model.ContactPersonPhone .Trim() == "") ? "null" : "N'" + Model.ContactPersonPhone.Trim().Replace("'", "''") + "'") + ",[ContactPersonMobileNo] = " + ((Model.ContactPersonMobileNo.Trim() == "") ? "null" : "N'" + Model.ContactPersonMobileNo.Trim().Replace("'", "''") + "'") + ",[EnterBy] = '" + Model.EnterBy.Trim() + "',[EnterDate] = '" + Model.EnterDate + "' ,Gadget='"+Model.Gadget+"' WHERE BranchId = '" + Model.BranchId + "'");
                strSql.Append("SET @VNo ='" + Model.BranchId + "'");
            }
            else if (Model.Tag == "DELETE")
            {
                strSql.Append("DELETE FROM ERP.Branch WHERE BranchId = '" + Model.BranchId + "' \n");
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
        public DataTable GetDataBranch(int BranchId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ERP.Branch");
            if (BranchId != 0)
                strSql.Append("  where BranchId='" + BranchId + "'");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
         
        }

        public int GetDataBranchCode(string BranchName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BranchId from ERP.Branch where BranchName='" + BranchName + "'");
            return Convert.ToInt32(DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0].Rows[0]["BranchId"].ToString());
        }
        public DataTable GetDataBranchList()
        {
            return DAL.ExecuteDataset(CommandType.Text, "select * from ERP.Branch ").Tables[0];
        }
        public DataTable BranchListForLedger(string LedgerId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select 'True' AS Tag, BranchId, BranchName from erp.Branch where BranchId in (select BranchId from erp.[LedgerBranchUnitMapping] where LedgerId = '" + LedgerId + "') \n");
            strSql.Append("union all \n");
            strSql.Append("select 'False' AS Tag, BranchId, BranchName from erp.Branch where BranchId not in (select BranchId from erp.[LedgerBranchUnitMapping] where LedgerId = '" + LedgerId + "') order by Tag desc, BranchName asc \n");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
        public DataTable BranchListByUserCode(string LoginUserCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select BranchId,BranchName as Description, BranchShortName as ShortName from ERP.Branch\n");
            //strSql.Append("INNER JOIN MyMaster.dbo.CompanyRights \n");
            //strSql.Append("on MyMaster.dbo.CompanyMaster.IniTial = MyMaster.dbo.CompanyRights.CompanyInitial \n");
            //strSql.Append("where MyMaster.dbo.CompanyRights.UserCode = 'ADMIN' ORDER BY CompanyName \n");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
        public DataTable GetCompanyUnitId_ByBranchID(string ListOfBranchCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ERP.CompanyUnit where BranchId in ("+ ListOfBranchCode + ")\n");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }

        public int GetBranch_ByCompanyUnitId(int CompUnitId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BranchId from ERP.CompanyUnit where CompanyUnitId = '" + CompUnitId+"'\n");
            return Convert.ToInt32(DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0].Rows[0]["BranchId"]);
        }
    }
}
