﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer.SystemSetting
{
    public class ClsCompanyUnit
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public CompanyUnitViewModel Model { get; set; }

        public ClsCompanyUnit()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new CompanyUnitViewModel();
        }

        public string SaveCompanyUnit()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("declare @CompanyUnitId int=(select ISNULL((Select Top 1 max(cast(CompanyUnitId as int))  from ERP.CompanyUnit),0)+1) \n");
                strSql.Append("Insert into ERP.CompanyUnit(CompanyUnitId, CmpUnitName, CmpUnitShortName, Address, City, State, Country, PhoneNo, Fax, Email, ContactPerson, ContactPersonAdd, ContactPersonPhoneNo, ContactPersonMobileNo,BranchId, EnterBy, EnterDate, Gadget) \n");
                strSql.Append("Select @CompanyUnitId,'" + Model.CmpUnitName.Trim() + "','" + Model.CmpUnitShortName.Trim() + "', " + ((Model.Address.Trim() == "") ? "null" : "N'" + Model.Address.Trim().Replace("'", "''") + "'") + ", " + ((Model.City.Trim() == "") ? "null" : "N'" + Model.City.Trim().Replace("'", "''") + "'") + ", " + ((Model.State.Trim() == "") ? "null" : "N'" + Model.State.Trim().Replace("'", "''") + "'") + ", " + ((Model.Country.Trim() == "") ? "null" : "N'" + Model.Country.Trim().Replace("'", "''") + "'") + ", " + ((Model.PhoneNo.Trim() == "") ? "null" : "N'" + Model.PhoneNo.Trim().Replace("'", "''") + "'") + ", " + ((Model.Fax.Trim() == "") ? "null" : "N'" + Model.Fax.Trim().Replace("'", "''") + "'") + ", " + ((Model.Email.Trim() == "") ? "null" : "N'" + Model.Email.Trim().Replace("'", "''") + "'") + ", " + ((Model.ContactPerson.Trim() == "") ? "null" : "N'" + Model.ContactPerson.Trim().Replace("'", "''") + "'") + ", " + ((Model.ContactPersonAdd.Trim() == "") ? "null" : "N'" + Model.ContactPersonAdd.Trim().Replace("'", "''") + "'") + ", " + ((Model.ContactPersonPhone.Trim() == "") ? "null" : "N'" + Model.ContactPersonPhone.Trim().Replace("'", "''") + "'") + ", " + ((Model.ContactPersonPhone.Trim() == "") ? "null" : "N'" + Model.ContactPersonPhone.Trim().Replace("'", "''") + "'") + "," + ((Model.BranchId == 0) ? "0" : "'" + Model.BranchId + "'") + ",'" + Model.EnterBy.Trim() + "',GETDATE(), '"+Model.Gadget+"' \n");
                strSql.Append("SET @VNo =@CompanyUnitId");

            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP.CompanyUnit SET [BranchName] = '" + Model.CmpUnitName.Trim() + "',[BranchShortName] = '" + Model.CmpUnitShortName.Trim() + "',[Address] =  " + ((Model.Address.Trim() == "") ? "null" : "N'" + Model.Address.Trim().Replace("'", "''") + "'") + ",[City] =  " + ((Model.City.Trim() == "") ? "null" : "N'" + Model.City.Trim().Replace("'", "''") + "'") + ",[State] =  " + ((Model.State.Trim() == "") ? "null" : "N'" + Model.State.Trim().Replace("'", "''") + "'") + ",[Country] =  " + ((Model.Country.Trim() == "") ? "null" : "N'" + Model.Country.Trim().Replace("'", "''") + "'") + ",[PhoneNo] =  " + ((Model.PhoneNo.Trim() == "") ? "null" : "N'" + Model.PhoneNo.Trim().Replace("'", "''") + "'") + ",[Fax] =  " + ((Model.Fax.Trim() == "") ? "null" : "N'" + Model.Fax.Trim().Replace("'", "''") + "'") + ",[Email] =  " + ((Model.Email.Trim() == "") ? "null" : "N'" + Model.Email.Trim().Replace("'", "''") + "'") + ",[ContactPerson] =  " + ((Model.ContactPerson.Trim() == "") ? "null" : "N'" + Model.ContactPerson.Trim().Replace("'", "''") + "'") + ",[ContactPersonAdd] =  " + ((Model.ContactPersonAdd.Trim() == "") ? "null" : "N'" + Model.ContactPersonAdd.Trim().Replace("'", "''") + "'") + ",[ContactPersonPhoneNo] =  " + ((Model.ContactPersonPhone.Trim() == "") ? "null" : "N'" + Model.ContactPersonPhone.Trim().Replace("'", "''") + "'") + ",[ContactPersonMobileNo] = " + ((Model.ContactPersonMobileNo.Trim() == "") ? "null" : "N'" + Model.ContactPersonMobileNo.Trim().Replace("'", "''") + "'") + ",[BranchId] = " + ((Model.BranchId == 0) ? "null" : "'" + Model.BranchId + "'") + " WHERE CompanyUnitId = '" + Model.CompanyUnitId + "'");
                strSql.Append("SET @VNo ='" + Model.CompanyUnitId + "'");
            }
            else if (Model.Tag == "DELETE")
            {
                strSql.Append("DELETE FROM ERP.CompanyUnit WHERE CompanyUnitId = '" + Model.CompanyUnitId + "' \n");
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
        public DataTable GetDataCompanyUnit(int CmpUnitId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CU.*,B.BranchName from ERP.CompanyUnit AS CU INNER JOIN ERP.Branch AS B ON CU.BranchId =B.BranchId ");
            if (CmpUnitId != 0)
                strSql.Append("where CompanyUnitId='" + CmpUnitId + "' ");
            strSql.Append(" ORDER BY CmpUnitName");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }

        public int GetDataCompanyUnit(string CmpUnitName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CU.CompanyUnitId,B.BranchName from ERP.CompanyUnit AS CU INNER JOIN ERP.Branch AS B ON CU.BranchId =B.BranchId where CmpUnitName='" + CmpUnitName + "' ");
            return Convert.ToInt32(DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0].Rows[0]["CompanyUnitId"]);
        }
        public DataTable GetDataCompanyUnitList()
        {
            return DAL.ExecuteDataset(CommandType.Text, "select CompanyUnitId, CmpUnitName, CmpUnitShortName from ERP.CompanyUnit order by CmpUnitName ").Tables[0];
        }
        public DataTable CompanyUnitListForLedger(string LedgerId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select 'True' AS Tag, CompanyUnitId, CmpUnitName,BranchName,erp.Branch.BranchId from erp.CompanyUnit left join erp.Branch on erp.Branch.BranchID= erp.CompanyUnit.BranchId  where CompanyUnitId in (select CompanyUnitId from erp.[LedgerBranchUnitMapping] where LedgerId = '" + LedgerId + "') \n");
            strSql.Append("union all \n");
            strSql.Append("select 'False' AS Tag, CompanyUnitId, CmpUnitName,BranchName,erp.Branch.BranchId from erp.CompanyUnit left join erp.Branch on erp.Branch.BranchID= erp.CompanyUnit.BranchId where CompanyUnitId not in (select CompanyUnitId from erp.[LedgerBranchUnitMapping] where LedgerId = '" + LedgerId + "') order by Tag desc, CmpUnitName asc \n");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }

        public DataTable CompanyUnitListByUserCode(string LoginUserCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select CompanyUnitId,CmpUnitName as Description, CmpUnitShortName as ShortName from ERP.CompanyUnit\n");
            //strSql.Append("INNER JOIN MyMaster.dbo.CompanyRights \n");
            //strSql.Append("on MyMaster.dbo.CompanyMaster.IniTial = MyMaster.dbo.CompanyRights.CompanyInitial \n");
            //strSql.Append("where MyMaster.dbo.CompanyRights.UserCode = 'ADMIN' ORDER BY CompanyName \n");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
    }

    public class CompanyUnitViewModel
    {
        public string Tag { get; set; }
        public int CompanyUnitId { get; set; }
        public string CmpUnitName { get; set; }
        public string CmpUnitShortName { get; set; }
        public string BranchName { get; set; }
        public string BranchShortName { get; set; }
        public DateTime? RegDate { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PhoneNo { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPersonAdd { get; set; }
        public string ContactPersonPhone { get; set; }
        public string ContactPersonMobileNo { get; set; }
        public int BranchId { get; set; }
        public string EnterBy { get; set; }
        public DateTime? EnterDate { get; set; }
		public string Gadget { get; set; }
		
	}
}
