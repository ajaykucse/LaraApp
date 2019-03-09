using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer.Common;
using System.Windows.Forms;
using System.IO;

namespace DataAccessLayer.SystemSetting
{
    public class ClsCompany
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public CompanyViewModel Model { get; set; }
        public ClsCompany()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new CompanyViewModel();
        }

        public string SaveCompany()
        {
            //------if not exit create MyMaster Database (Our Master Database)-----------
            //--------------Create Company Database--------      

            if (Model.Tag == "NEW")
            {
                StringBuilder sqlMymaster = new StringBuilder();
                sqlMymaster.Append("USE MASTER; if NOT EXISTS(select * from sys.databases where name = 'MYMASTER')\n");
                sqlMymaster.Append("begin \n");
                sqlMymaster.Append("CREATE DATABASE MYMASTER ON PRIMARY (NAME =MYMASTER, FILENAME = '" + Model.DatabasePath + "MYMASTER.mdf',\n");
                sqlMymaster.Append("SIZE = 5MB, MAXSIZE = 100MB, FILEGROWTH = 100%) LOG ON (NAME = " + "MYMASTER_Log, FILENAME = '" + Model.DatabasePath + "MYMASTERLog.ldf', \n");
                sqlMymaster.Append("SIZE = 5MB, MAXSIZE = 100MB, FILEGROWTH = 100%) \n");
                sqlMymaster.Append("RESTORE DATABASE MYMASTER FROM DISK = '" + Path.GetDirectoryName(Application.ExecutablePath) + "\\MYMASTER.BAK" + "' WITH REPLACE , \n");
                sqlMymaster.Append("MOVE 'MYMASTER' TO '" + Model.DatabasePath + "\\MYMASTER.mdf" + "', \n");
                sqlMymaster.Append("MOVE 'MYMASTER_Log' TO '" + Model.DatabasePath + "\\MYMASTERLog.ldf" + "' \n");
                sqlMymaster.Append("end \n");
                sqlMymaster.Append("CREATE DATABASE " + Model.DatabaseName.Trim() + " ON PRIMARY (NAME = " + Model.DatabaseName + ", FILENAME = '" + Model.DatabasePath + Model.DatabaseName + ".mdf',\n");
                sqlMymaster.Append("SIZE = 5MB, MAXSIZE = 100MB, FILEGROWTH = 100%) LOG ON (NAME = " + Model.DatabaseName + "_Log, FILENAME = '" + Model.DatabasePath + Model.DatabaseName + "Log.ldf', \n");
                sqlMymaster.Append("SIZE = 5MB, MAXSIZE = 100MB, FILEGROWTH = 100%) \n");

                // sqlMymaster.Append("USE[master] \n");
                //sqlMymaster.Append("GO \n");

                //sqlMymaster.Append("RESTORE DATABASE MANISH FROM DISK = '" + Model.DatabasePath + Model.DatabaseName + ".mdf'\n");
                //sqlMymaster.Append("WITH FILE = 1, \n"); 
                //sqlMymaster.Append("MOVE 'DEFAULTDATA' TO '" + Model.DatabasePath + "\\" + Model.DatabaseName.Trim() + ".mdf" + "', \n");
                //sqlMymaster.Append("MOVE 'DEFAULTDATA_log' TO '" + Model.DatabasePath + "\\" + Model.DatabaseName.Trim() + "Log.ldf, \n");
                //sqlMymaster.Append("RECOVERY, REPLACE, STATS = 15; \n");
                int result = DAL.ExecuteNonQuery(CommandType.Text, sqlMymaster.ToString());
            }

            //------------------------CREATE DATABASE END------------------------------------

            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("BEGIN TRANSACTION \n");
            //strSql.Append("BEGIN TRY \n");
            //if (Model.Tag == "NEW")
            //{
            //    strSql.Append("Insert INTO MYMaster.dbo.CompanyMaster (IniTial, CompanyName, StartDate, Enddate, DatabaseName, DatabasePath, BackupPath) VALUES ('" + Model.Initial + "','" + Model.CompanyName + "','" + Model.StartDate + "','" + Model.EndDate + "','" + Model.DatabaseName + "','" + Model.DatabasePath + "','" + Model.DataBackupPath + "')");
            //    strSql.Append("Insert into ERP.CompanyInfo(Initial, CompanyName, StartDate, EndDate, FiscalYear, RegDate, Address, City,District, State,Country, PhoneNo,AltPhoneNo, Fax, PanNo, Email, Website, VersionNo, EnterBy, CreateDate) \n");
            //    strSql.Append("Select '" + Model.Initial.Trim() + "',N'" + Model.CompanyName.Trim().Replace("'", "''") + "','" + Model.StartDate.ToString("MM/dd/yyyy") + "','" + Model.EndDate.ToString("MM/dd/yyyy") + "','" + Model.FiscalYear + "',NULL," + ((Model.Address.Trim() == "") ? "null" : "N'" + Model.Address.Trim().Replace("'", "''") + "'") + "," + ((Model.City.Trim() == "") ? "null" : "N'" + Model.City.Trim().Replace("'", "''") + "'") + "," + ((Model.District.Trim() == "") ? "null" : "N'" + Model.District.Trim().Replace("'", "''") + "'") + "," + ((Model.State.Trim() == "") ? "null" : "N'" + Model.State.Trim().Replace("'", "''") + "'") + "," + ((Model.Country.Trim() == "") ? "null" : "N'" + Model.Country.Trim().Replace("'", "''") + "'") + "," + ((Model.PhoneNo.Trim() == "") ? "null" : "N'" + Model.PhoneNo.Trim().Replace("'", "''") + "'") + "," + ((Model.AltPhoneNo.Trim() == "") ? "null" : "N'" + Model.AltPhoneNo.Trim().Replace("'", "''") + "'") + "," + ((Model.Fax.Trim() == "") ? "null" : "N'" + Model.Fax.Trim().Replace("'", "''") + "'") + "," + ((Model.PanNo.Trim() == "") ? "null" : "N'" + Model.PanNo.Trim().Replace("'", "''") + "'") + "," + ((Model.Email.Trim() == "") ? "null" : "N'" + Model.Email.Trim().Replace("'", "''") + "'") + "," + ((Model.Website.Trim() == "") ? "null" : "N'" + Model.Website.Trim().Replace("'", "''") + "'") + "," + ((Model.VersionNo == 0) ? "0" : "'" + Model.VersionNo + "'") + ",'" + Model.EnterBy + "',GETDATE() \n");
            //    strSql.Append("SET @VNo ='" + Model.Initial.Trim() + "'");

            //}
            //else if (Model.Tag == "EDIT")
            //{
            //    strSql.Append("UPDATE  MYMaster.dbo.CompanyMaster SET CompanyName='" + Model.CompanyName + "',StartDate='" + Model.StartDate.ToString("MM/dd/yyyy") + "',EndDate='" + Model.EndDate.ToString("MM/dd/yyyy") + "',DatabaseName='" + Model.DatabaseName + "',BackupPath='" + Model.DataBackupPath + "' WHERE INITIAL= '" + Model.Initial + "'");//DatabasePath='" + Model.DatabasePath + "',
            //    strSql.Append("UPDATE ERP.CompanyInfo SET [CompanyName] =N'" + Model.CompanyName.Trim().Replace("'", "''") + "',StartDate='" + Model.StartDate.ToString("MM/dd/yyyy") + "',EndDate='" + Model.EndDate.ToString("MM/dd/yyyy") + "',FiscalYear='" + Model.FiscalYear + "',Address=" + ((Model.Address.Trim() == "") ? "null" : "N'" + Model.Address.Trim().Replace("'", "''") + "'") + ",City=" + ((Model.City.Trim() == "") ? "null" : "N'" + Model.City.Trim().Replace("'", "''") + "'") + ",District=" + ((Model.District.Trim() == "") ? "null" : "N'" + Model.District.Trim().Replace("'", "''") + "'") + ",State=" + ((Model.State.Trim() == "") ? "null" : "N'" + Model.State.Trim().Replace("'", "''") + "'") + ",Country=" + ((Model.Country.Trim() == "") ? "null" : "N'" + Model.Country.Trim().Replace("'", "''") + "'") + ",PhoneNo=" + ((Model.PhoneNo.Trim() == "") ? "null" : "N'" + Model.PhoneNo.Trim().Replace("'", "''") + "'") + ",AltPhoneNo=" + ((Model.AltPhoneNo.Trim() == "") ? "null" : "N'" + Model.AltPhoneNo.Trim().Replace("'", "''") + "'") + ",Fax=" + ((Model.Fax.Trim() == "") ? "null" : "N'" + Model.Fax.Trim().Replace("'", "''") + "'") + ",PanNo=" + ((Model.PanNo.Trim() == "") ? "null" : "N'" + Model.PanNo.Trim().Replace("'", "''") + "'") + ",Email=" + ((Model.Email.Trim() == "") ? "null" : "N'" + Model.Email.Trim().Replace("'", "''") + "'") + ",Website=" + ((Model.Website.Trim() == "") ? "null" : "N'" + Model.Website.Trim().Replace("'", "''") + "'") + ",VersionNo=" + ((Model.VersionNo == 0) ? "0" : "'" + Model.VersionNo + "'") + ",EnterBy='" + Model.EnterBy.Trim() + "' WHERE Initial = '" + Model.Initial + "'");
            //    strSql.Append("SET @VNo ='" + Model.Initial + "'");
            //}
            //else if (Model.Tag == "DELETE")
            //{
            //    strSql.Append("DELETE FROM MYMASTER.DBO.CompanyMaster WHERE Initial = '" + Model.Initial + "' \n");
            //    strSql.Append("DELETE FROM ERP.CompanyInfo WHERE Initial = '" + Model.Initial + "' \n");
            //    strSql.Append("SET @VNo ='1'");
            //}

            //strSql.Append("\n COMMIT TRANSACTION \n");
            //strSql.Append("END TRY \n");
            //strSql.Append("BEGIN CATCH \n");
            //strSql.Append("ROLLBACK TRANSACTION \n");
            //strSql.Append("Set @VNo = '' \n");
            //strSql.Append("END CATCH \n");

            //SqlParameter[] p = new SqlParameter[1];
            //p[0] = new SqlParameter("@VNo", SqlDbType.VarChar, 25);
            //p[0].Direction = ParameterDirection.Output;
            //DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString(), p);
            //return p[0].Value.ToString();
            return "aa";
        }

        public void RestoreDatabase()
        {
            StringBuilder sqlMymaster = new StringBuilder();
            //sqlMymaster.Append("RESTORE DATABASE  " + Model.DatabaseName.Trim() + " FROM DISK = '" + Path.GetDirectoryName(Application.ExecutablePath) + "\\" + "DEFAULTDATA.BAK" + "' WITH  FILE = 1, \n");
            //sqlMymaster.Append("MOVE '" + Model.DatabaseName.Trim() + "' TO '" + Model.DatabasePath + "\\" + Model.DatabaseName.Trim() + ".mdf" + "', \n");
            //sqlMymaster.Append("MOVE '" + Model.DatabaseName.Trim() + "_Log" + "' TO '" + Model.DatabasePath + "\\" + Model.DatabaseName.Trim() + "Log.ldf" + "' , NOUNLOAD,  REPLACE,  STATS = 5  \n");
            sqlMymaster.Append("--ALTER DATABASE [" + Model.DatabaseName.Trim() + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; \n");

            sqlMymaster.Append("--RESTORE FILELISTONLY FROM disk = N'" + Path.GetDirectoryName(Application.ExecutablePath) + "\\DEFAULTDATA.BAK' \n");

            sqlMymaster.Append("RESTORE DATABASE [" + Model.DatabaseName.Trim() + "] FROM DISK = N'" + Path.GetDirectoryName(Application.ExecutablePath) + "\\DEFAULTDATA.BAK' \n");
            sqlMymaster.Append("WITH FILE = 1, MOVE N'"+ Model.DatabaseName.Trim() + "' TO N'" + Model.DatabasePath + "\\" + Model.DatabaseName.Trim() + ".mdf" + "', \n");
            sqlMymaster.Append("MOVE N'"+ Model.DatabaseName.Trim() +"_log"+ "' TO N'" + Model.DatabasePath + "\\" + Model.DatabaseName.Trim() + "Log.ldf" + "', \n");
            sqlMymaster.Append("NOUNLOAD,  REPLACE,  STATS = 5 \n");

            sqlMymaster.Append("--ALTER DATABASE [" + Model.DatabaseName.Trim() + "] SET MULTI_USER; \n");
            DAL.ExecuteNonQuery(CommandType.Text, sqlMymaster.ToString());
        }

        public DataTable GetDataCompany(string Initial)
        {
            return DAL.ExecuteDataset(CommandType.Text, "select * from ERP.CompanyInfo  where Initial='" + Initial + "'").Tables[0];
        }

        public DataTable CompanyListByUserCode(string LoginUserCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select CompanyMaster.IniTial, CompanyName as [Company Name],StartDate as [Start Date],Enddate as [End Date],DatabaseName as [Db Name] \n");
            strSql.Append("from MyMaster.dbo.CompanyMaster \n");
            strSql.Append("INNER JOIN MyMaster.dbo.CompanyRights \n");
            strSql.Append("on MyMaster.dbo.CompanyMaster.IniTial = MyMaster.dbo.CompanyRights.IniTial \n");
            strSql.Append("where MyMaster.dbo.CompanyRights.UserCode = '"+ LoginUserCode + "' ORDER BY CompanyName \n");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }

        public DataTable CompanyInfo()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from ERP.CompanyInfo \n");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
        public void UpdateSoftwareFocus(string SoftwareFocus)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update ERP.CompanyInfo set SoftwareFocus='"+ SoftwareFocus + "'\n");
			if (SoftwareFocus == "Restaurant")
			{
				strSql.Append("BEGIN\n");
				strSql.Append("IF NOT EXISTS (select TermId from [ERP].[SalesBillingTerm])\n");
				strSql.Append("BEGIN\n");
				strSql.Append("INSERT [ERP].[SalesBillingTerm] ([TermId], [TermPosition], [TermType], [TermDesc], [Category], [LedgerId], [Basis], [STSign], [Billwise], [TermRate], [Profitability], [SupressZero], [Formula], [Status], [EnterBy], [EnterDate], [Gadget]) VALUES (1, 1, N'B ', N'P.Discount', N'General', 28, N'V ', N'-', N'N', CAST(0.000000 AS Decimal(18, 6)), 1, 1, N'', 1, N'ACME', CAST(N'2019-02-22 11:00:47.920' AS DateTime), N'Desktop')\n");
				strSql.Append("INSERT [ERP].[SalesBillingTerm] ([TermId], [TermPosition], [TermType], [TermDesc], [Category], [LedgerId], [Basis], [STSign], [Billwise], [TermRate], [Profitability], [SupressZero], [Formula], [Status], [EnterBy], [EnterDate], [Gadget]) VALUES (2, 4, N'B ', N'B.Discount', N'General', 28, N'V ', N'+', N'Y', CAST(0.000000 AS Decimal(18, 6)), 1, 1, N'', 1, N'ACME', CAST(N'2019-02-22 11:01:13.510' AS DateTime), N'Desktop')\n");
				strSql.Append("INSERT [ERP].[SalesBillingTerm] ([TermId], [TermPosition], [TermType], [TermDesc], [Category], [LedgerId], [Basis], [STSign], [Billwise], [TermRate], [Profitability], [SupressZero], [Formula], [Status], [EnterBy], [EnterDate], [Gadget]) VALUES (3, 7, N'B ', N'VAT', N'General', 33, N'V ', N'+', N'Y', CAST(13.000000 AS Decimal(18, 6)), 1, 1, N'', 1, N'ACME', CAST(N'2019-02-22 11:01:36.930' AS DateTime), N'Desktop')\n");
				strSql.Append("INSERT [ERP].[SalesBillingTerm] ([TermId], [TermPosition], [TermType], [TermDesc], [Category], [LedgerId], [Basis], [STSign], [Billwise], [TermRate], [Profitability], [SupressZero], [Formula], [Status], [EnterBy], [EnterDate], [Gadget]) VALUES (4, 3, N'B ', N'Service Charge', N'General', 28, N'V ', N'+', N'N', CAST(10.000000 AS Decimal(18, 6)), 1, 1, N'', 1, N'ACME', CAST(N'2019-02-22 14:16:10.813' AS DateTime), N'Desktop')\n");
				strSql.Append("END\n");
				strSql.Append("END\n\n");
				strSql.Append("BEGIN\n");
				strSql.Append("IF NOT EXISTS (select ProductGrpId from [ERP].[ProductGroup1])\n");
				strSql.Append("BEGIN\n");
				strSql.Append("INSERT [ERP].[ProductGroup1] ([ProductGrpId], [ProductGrpDesc], [ProductGrpShortName], [Margin], [PrinterName], [Status], [EnterBy], [EnterDate], [Gadget]) VALUES (1, N'USED', N'US00001', CAST(0.000000 AS Decimal(18, 6)), NULL, 1, N'ACME', CAST(N'2019-03-01 15:17:59.227' AS DateTime), N'Desktop')\n");
				strSql.Append("INSERT [ERP].[ProductGroup1] ([ProductGrpId], [ProductGrpDesc], [ProductGrpShortName], [Margin], [PrinterName], [Status], [EnterBy], [EnterDate], [Gadget]) VALUES (2, N'UNUSED', N'UN00001', CAST(0.000000 AS Decimal(18, 6)), NULL, 1, N'ACME', CAST(N'2019-03-01 15:18:06.090' AS DateTime), N'Desktop')\n");
				strSql.Append("END\n");
				strSql.Append("END\n");
			}
			DAL.ExecuteNonQuery (CommandType.Text, strSql.ToString());
        }
    }
    public class CompanyViewModel
    {
        public string Tag { get; set; }
        public int CompanyId { get; set; }
        public string Initial { get; set; }       
        public string CompanyName { get; set; }
        public string FiscalYear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? RegDate { get; set; }
        public byte[] CompanyLogo { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PhoneNo { get; set; }
        public string AltPhoneNo { get; set; }
        public string Fax { get; set; }
        public string PanNo { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public int? VersionNo { get; set; }
        public bool Status { get; set; }
        public bool DefaultData { get; set; }
        public string EnterBy { get; set; }
        public DateTime? EnterDate { get; set; }
        public string DatabaseName { get; set; }
        public string DatabasePath { get; set; }
        public string DataBackupPath { get; set; }
    }
}
