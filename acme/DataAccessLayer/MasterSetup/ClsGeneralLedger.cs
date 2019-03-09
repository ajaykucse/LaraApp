using DataAccessLayer.Common;
using DataAccessLayer.Interface.MasterSetup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer.MasterSetup
{
    public class ClsGeneralLedger : IGeneralLedger
    {
        private ActiveDataAccess.ActiveDataAccess DAL;
        public LedgerViewModel Model { get; set; }
        public List<LedgerBranchCompanyUnitModel> ModelLedgerBranchCompanyUnit { get; set; }
        public List<LedgerMappingList> ModelLedgerMappingList { get; set; }
        public ClsGeneralLedger()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new LedgerViewModel();
            ModelLedgerBranchCompanyUnit = new List<LedgerBranchCompanyUnitModel>();
            ModelLedgerMappingList = new List<LedgerMappingList>();
        }
        public string SaveGeneralLedger()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("declare @ledgerId int=(select ISNULL((Select Top 1 max(cast(ledgerId as int))  from ERP.Generalledger),0)+1) \n");
                strSql.Append("Insert into [ERP].[Generalledger] (LedgerId, GlDesc, GlShortName,GlPrintingName, GlAlias, ACCode, GlCategory, AccountGrpId,  AccountSubGrpId, AreaId, SalesmanId, CurrencyId, DepartmentId1,DepartmentId2,DepartmentId3,DepartmentId4, IsSubledger, IsCard, IsTDSAplicable, IsDocAdjustment, \n");
                strSql.Append("CreditDays, CreditDaysWarning, CreditLimit, CreditLimitWarning, CreditType, ChequeReciveDays, InterestRate, SchemeId, Address, Address1, City, District, State, Country, PhoneNo, AltPhoneNo, MobileNo, DOB, Age, Gender, FaxNo, Email, Website, PanNo,NationalId,DrvingLicenseNo,\n");
                strSql.Append("GlPictureUrl,ContactPersonName, CPAddress, CPPhoneNo, CPAltPhoneNo, Status, IsSystemLedger, EnterBy, EnterDate,Gadget,CustomerType)\n");//GlPicture,Signature,
                strSql.Append("Select @ledgerId,N'" + Model.GlDesc.Trim().Replace("'", "''") + "',N'" + Model.GlShortName.Trim().Replace("'", "''") + "'," + ((Model.GlPrintingName == "") ? "null" : "N'" + Model.GlPrintingName.Trim().Replace("'", "''") + "'") + "," + ((Model.GlAlias == "") ? "null" : "N'" + Model.GlAlias.Trim().Replace("'", "''") + "'") + "," + ((Model.ACCode == "") ? "null" : "N'" + Model.ACCode.Trim().Replace("'", "''") + "'") + ",N'" + Model.GlCategory.Trim().Replace("'", "''") + "', \n");
                strSql.Append("'" + Model.AccountGrpId + "' , " + ((Model.AccountSubGrpId == 0) ? "null" : "'" + Model.AccountSubGrpId + "'") + ", " + ((Model.AreaId == 0) ? "null" : "'" + Model.AreaId + "'") + ", " + ((Model.SalesmanId == 0) ? "null" : "'" + Model.SalesmanId + "'") + "," + ((Model.CurrencyId == 0) ? "null" : "'" + Model.CurrencyId + "'") + "," + ((Model.DepartmentId1 == 0) ? "null" : "'" + Model.DepartmentId1 + "'") + "," + ((Model.DepartmentId2 == 0) ? "null" : "'" + Model.DepartmentId2 + "'") + "," + ((Model.DepartmentId3 == 0) ? "null" : "'" + Model.DepartmentId3 + "'") + "," + ((Model.DepartmentId4 == 0) ? "null" : "'" + Model.DepartmentId4 + "'") + ",  \n");
                strSql.Append("'" + Model.IsSubledger.ToString().ToLower() + "', '" + Model.IsCard.ToString().ToLower() + "','" + Model.IsTDSAplicable.ToString().ToLower() + "', '" + Model.IsDocAdjustment.ToString().ToLower() + "','" + ClsGlobal.Val(Model.CreditDays.ToString()) + "','" + Model.CreditDaysWarning.ToString() + "','" + ClsGlobal.Val(Model.CreditLimit.ToString()) + "', '" + Model.CreditLimitWarning.ToString() + "',null, " + ((Model.ChequeReciveDays == 0) ? "null" : "'" + Model.ChequeReciveDays + "'") + ", " + ((Model.InterestRate == 0) ? "null" : "'" + Model.InterestRate + "'") + ", " + ((Model.SchemeId == 0) ? "null" : "'" + Model.SchemeId + "'") + ",\n");
                strSql.Append("" + ((Model.Address.Trim() == "") ? "null" : "N'" + Model.Address.Trim().Replace("'", "''") + "'") + "," + ((Model.Address1.Trim() == "") ? "null" : "N'" + Model.Address1.Trim().Replace("'", "''") + "'") + "," + ((Model.City.Trim() == "") ? "null" : "N'" + Model.City.Trim().Replace("'", "''") + "'") + "," + ((Model.District.Trim() == "") ? "null" : "N'" + Model.District.Trim().Replace("'", "''") + "'") + "," + ((Model.State.Trim() == "") ? "null" : "N'" + Model.State.Trim().Replace("'", "''") + "'") + "," + ((Model.Country.Trim() == "") ? "null" : "N'" + Model.Country.Trim().Replace("'", "''") + "'") + ", \n");
                strSql.Append("" + ((Model.PhoneNo == "") ? "null" : "N'" + Model.PhoneNo.Trim().Replace("'", "''") + "'") + "," + ((Model.AltPhoneNo == "") ? "null" : "N'" + Model.AltPhoneNo.Trim().Replace("'", "''") + "'") + "," + ((Model.MobileNo == "") ? "null" : "N'" + Model.MobileNo.Trim().Replace("'", "''") + "'") + ",null,null,null,\n");
                strSql.Append("" + ((Model.FaxNo == "") ? "null" : "N'" + Model.FaxNo.Trim().Replace("'", "''") + "'") + " , " + ((Model.EmailId == "") ? "null" : "N'" + Model.EmailId.Trim().Replace("'", "''") + "'") + ",null," + ((Model.PanNo == "") ? "null" : "N'" + Model.PanNo.Trim().Replace("'", "''") + "'") + ",null,null,\n");
                strSql.Append(" null ," + ((Model.ContactPersonName == "") ? "null" : "N'" + Model.ContactPersonName.Trim().Replace("'", "''") + "'") + " , " + ((Model.CPAddress == "") ? "null" : "N'" + Model.CPAddress.Trim().Replace("'", "''") + "'") + "," + ((Model.CPPhoneNo == "") ? "null" : "'" + Model.CPPhoneNo.Trim().Replace("'", "''") + "'") + ",null, \n");
                strSql.Append("'" + Model.Status.ToString().ToLower() + "',0, '" + Model.EnterBy + "', GETDATE(),Gadget='" + Model.Gadget + "','" + Model.CustomerType + "' \n");

                if (ClsGlobal.BranchOrCompanyUnitWise == "Branch")
                {
                    foreach (LedgerBranchCompanyUnitModel det in ModelLedgerBranchCompanyUnit)
                    {
                        strSql.Append("INSERT INTO [ERP].[LedgerBranchUnitMapping] (LedgerId, BranchId, CompanyUnitId) \n");
                        strSql.Append("Select @ledgerId,'" + det.BranchId + "',null \n");
                    }
                    ModelLedgerBranchCompanyUnit.Clear();
                }
                else if (ClsGlobal.BranchOrCompanyUnitWise == "CompanyUnit")
                {
                    foreach (LedgerBranchCompanyUnitModel det in ModelLedgerBranchCompanyUnit)
                    {
                        strSql.Append("INSERT INTO [ERP].[LedgerBranchUnitMapping] (LedgerId, BranchId, CompanyUnitId) \n");
                        strSql.Append("Select @ledgerId,'" + det.BranchId + "','" + det.CompanyUnitId + "' \n");
                    }
                    ModelLedgerBranchCompanyUnit.Clear();
                }

                strSql.Append("SET @VNo =@ledgerId");
            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP.Generalledger SET GlDesc=N'" + Model.GlDesc.Trim().Replace("'", "''") + "',GlShortName = N'" + Model.GlShortName.Trim().Replace("'", "''") + "',GlPrintingName =  " + ((Model.GlPrintingName == "") ? "null" : "N'" + Model.GlPrintingName.Trim().Replace("'", "''") + "'") + ", GlAlias = " + ((Model.GlAlias == "") ? "null" : "N'" + Model.GlAlias.Trim().Replace("'", "''") + "'") + ",ACCode= " + ((Model.ACCode == "") ? "null" : "N'" + Model.ACCode.Trim().Replace("'", "''") + "'") + ",GlCategory = N'" + Model.GlCategory.Trim().Replace("'", "''") + "',\n");
                strSql.Append("AccountGrpId = '" + Model.AccountGrpId + "' ,AccountSubGrpId = " + ((Model.AccountSubGrpId == 0) ? "null" : "'" + Model.AccountSubGrpId + "'") + ",AreaId = " + ((Model.AreaId == 0) ? "null" : "'" + Model.AreaId + "'") + ",SalesmanId = " + ((Model.SalesmanId == 0) ? "null" : "'" + Model.SalesmanId + "'") + ",CurrencyId = " + ((Model.CurrencyId == 0) ? "null" : "'" + Model.CurrencyId + "'") + ",DepartmentId1 = " + ((Model.DepartmentId1 == 0) ? "null" : "'" + Model.DepartmentId1 + "'") + ",DepartmentId2 = " + ((Model.DepartmentId2 == 0) ? "null" : "'" + Model.DepartmentId2 + "'") + ",DepartmentId3 = " + ((Model.DepartmentId3 == 0) ? "null" : "'" + Model.DepartmentId3 + "'") + ", DepartmentId4 = " + ((Model.DepartmentId4 == 0) ? "null" : "'" + Model.DepartmentId4 + "'") + ",   \n");
                strSql.Append("IsSubledger = '" + Model.IsSubledger.ToString().ToLower() + "',IsCard = '" + Model.IsCard.ToString().ToLower() + "',IsTDSAplicable ='" + Model.IsTDSAplicable.ToString().ToLower() + "',IsDocAdjustment = '" + Model.IsDocAdjustment.ToString().ToLower() + "',CreditDays=" + ClsGlobal.Val(Model.CreditDays.ToString()) + ",CreditDaysWarning = '" + Model.CreditDaysWarning.ToString() + "',CreditLimit = '" + ClsGlobal.Val(Model.CreditLimit.ToString()) + "',CreditLimitWarning = '" + Model.CreditLimitWarning.ToString() + "',ChequeReciveDays = '" + ClsGlobal.Val(Model.ChequeReciveDays.ToString()) + "',InterestRate = '" + ClsGlobal.Val(Model.InterestRate.ToString()) + "',SchemeId = " + ((Model.SchemeId == 0) ? "null" : "'" + Model.SchemeId + "'") + ",\n");
                strSql.Append("Address = " + ((Model.Address.Trim() == "") ? "null" : "N'" + Model.Address.Trim().Replace("'", "''") + "'") + ",Address1 =" + ((Model.Address1.Trim() == "") ? "null" : "N'" + Model.Address1.Trim().Replace("'", "''") + "'") + ",City = " + ((Model.City.Trim() == "") ? "null" : "N'" + Model.City.Trim().Replace("'", "''") + "'") + ",District = " + ((Model.District.Trim() == "") ? "null" : "N'" + Model.District.Trim().Replace("'", "''") + "'") + ",State = " + ((Model.State.Trim() == "") ? "null" : "N'" + Model.State.Trim().Replace("'", "''") + "'") + ",Country = " + ((Model.Country.Trim() == "") ? "null" : "N'" + Model.Country.Trim().Replace("'", "''") + "'") + ", \n");
                strSql.Append("PhoneNo = " + ((Model.PhoneNo == "") ? "null" : "N'" + Model.PhoneNo.Trim().Replace("'", "''") + "'") + ",AltPhoneNo =" + ((Model.AltPhoneNo == "") ? "null" : "N'" + Model.AltPhoneNo.Trim().Replace("'", "''") + "'") + ",MobileNo = " + ((Model.MobileNo == "") ? "null" : "N'" + Model.MobileNo.Trim().Replace("'", "''") + "'") + ",\n");
                strSql.Append("FaxNo = " + ((Model.FaxNo == "") ? "null" : "N'" + Model.FaxNo.Trim().Replace("'", "''") + "'") + " ,Email = " + ((Model.EmailId == "") ? "null" : "N'" + Model.EmailId.Trim().Replace("'", "''") + "'") + ",PanNo = " + ((Model.PanNo == "") ? "null" : "N'" + Model.PanNo.Trim().Replace("'", "''") + "'") + ",\n");
                strSql.Append("ContactPersonName = " + ((Model.ContactPersonName == "") ? "null" : "N'" + Model.ContactPersonName.Trim().Replace("'", "''") + "'") + " ,CPAddress = " + ((Model.CPAddress == "") ? "null" : "N'" + Model.CPAddress.Trim().Replace("'", "''") + "'") + ",CPPhoneNo = " + ((Model.CPPhoneNo == "") ? "null" : "'" + Model.CPPhoneNo.Trim().Replace("'", "''") + "'") + ", \n");
                strSql.Append("Status = '" + Model.Status.ToString().ToLower() + "',EnterBy = '" + Model.EnterBy + "',EnterDate = GETDATE(),Gadget='" + Model.Gadget + "',CustomerType='" + Model.CustomerType + "' \n");
                strSql.Append("WHERE LedgerId = '" + Model.LedgerId + "' \n");
                strSql.Append("SET @VNo ='" + Model.LedgerId + "'");

                if (ClsGlobal.BranchOrCompanyUnitWise == "Branch")
                {
                    strSql.Append("Delete from [ERP].[LedgerBranchUnitMapping] where LedgerId ='" + Model.LedgerId + "' \n");
                    foreach (LedgerBranchCompanyUnitModel det in ModelLedgerBranchCompanyUnit)
                    {
                        strSql.Append("INSERT INTO [ERP].[LedgerBranchUnitMapping] (LedgerId, BranchId, CompanyUnitId) \n");
                        strSql.Append("Select '" + Model.LedgerId + "','" + det.BranchId + "',null \n");
                    }
                    ModelLedgerBranchCompanyUnit.Clear();
                }
                else if (ClsGlobal.BranchOrCompanyUnitWise == "CompanyUnit")
                {
                    strSql.Append("Delete from [ERP].[LedgerBranchUnitMapping] where LedgerId ='" + Model.LedgerId + "' \n");
                    foreach (LedgerBranchCompanyUnitModel det in ModelLedgerBranchCompanyUnit)
                    {
                        strSql.Append("INSERT INTO [ERP].[LedgerBranchUnitMapping] (LedgerId, BranchId, CompanyUnitId) \n");
                        strSql.Append("Select '" + Model.LedgerId + "','" + det.BranchId + "','" + det.CompanyUnitId + "' \n");
                    }
                    ModelLedgerBranchCompanyUnit.Clear();
                }
            }
            else if (Model.Tag == "DELETE")
            {
                strSql.Append("Delete from [ERP].[LedgerBranchUnitMapping] where LedgerId ='" + Model.LedgerId + "' \n");
                strSql.Append("DELETE FROM ERP.Generalledger WHERE ledgerId = '" + Model.LedgerId + "' \n");
                strSql.Append("DELETE FROM MyMaster.dbo.UserMaster WHERE LedgerId = '" + Model.LedgerId + "' \n");
                strSql.Append("SET @VNo ='1'");
            }
            strSql.Append("\n COMMIT TRANSACTION \n");
            strSql.Append("END TRY \n");
            strSql.Append("BEGIN CATCH \n");
            strSql.Append("ROLLBACK TRANSACTION \n");
            strSql.Append("Set @VNo = '' \n");
            strSql.Append("END CATCH \n");

            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@VNo", SqlDbType.VarChar, 25)
            {
                Direction = ParameterDirection.Output
            };
            DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString(), p);
            return p[0].Value.ToString();
        }
        public string SaveUserMaster()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");

            strSql.Append("Insert into MyMaster.dbo.UserMaster (UserCode, UserName, UserPassword,  CreateBy, CreateDate, MobileNo, EmailId,LedgerId,UserType) \n");
            strSql.Append("select N'" + Model.UserName.Trim().Replace("'", "''") + "',N'" + Model.UserName.Trim().Replace("'", "''") + "','" + Model.Password + "','" + Model.EnterBy + "',GETDATE(),'" + Model.UMobileNo.Trim() + "','" + Model.UEmailId.Trim() + "' ,'" + Model.ULedgerId + "','"+Model.CustomerType+"'\n");
            
            strSql.Append("\n COMMIT TRANSACTION \n");
            strSql.Append("END TRY \n");
            strSql.Append("BEGIN CATCH \n");
            strSql.Append("ROLLBACK TRANSACTION \n");
            strSql.Append("END CATCH \n");
            return DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString()).ToString();
        }
        public DataTable GetDataGeneralLedger(int LedgerId)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("Select Gl.*,AG.AccountGrpDesc,AG.AccountGrpShortName,ASG.AccountSubGrpDesc,ASG.AccountSubGrpShortName,AR.AreaDesc,AR.AreaShortName,AGN.SalesmanDesc,AGN.SalesmanShortName,\n");
            strSql.Append("Cur.CurrencyDesc,Cur.CurrencyShortName,DP1.DepartmentDesc as DepartmentDesc1,DP1.DepartmentShortName as DepartmentShortName1,\n");
            strSql.Append("DP2.DepartmentDesc as DepartmentDesc2,DP2.DepartmentShortName as DepartmentShortName2,DP3.DepartmentDesc as DepartmentDesc3,DP3.DepartmentShortName as DepartmentShortName3,\n");
            strSql.Append("DP4.DepartmentDesc as DepartmentDesc4,DP4.DepartmentShortName as DepartmentShortName4,'' SchemeDesc  \n");
            strSql.Append("from ERP.GeneralLedger as Gl Inner join ERP.AccountGroup as AG on Gl.AccountGrpId = AG.AccountGrpId Left Outer join ERP.AccountSubGroup as ASG on Gl.AccountSubGrpId = ASG.AccountSubGrpId  \n");
            strSql.Append("Left Outer join ERP.Area as AR on Gl.AreaId = AR.AreaId Left Outer join ERP.Salesman as AGN on Gl.SalesmanId = AGN.SalesmanId  \n");
            strSql.Append("Left Outer join ERP.Currency as Cur on Gl.CurrencyId = Cur.CurrencyId \n");
            strSql.Append("Left Outer join ERP.Department as DP1 on Gl.DepartmentId1 = DP1.DepartmentId Left Outer join ERP.Department as DP2 on Gl.DepartmentId2 = DP2.DepartmentId \n");
            strSql.Append("Left Outer join ERP.Department as DP3 on Gl.DepartmentId3 = DP3.DepartmentId Left Outer join ERP.Department as DP4 on Gl.DepartmentId4 = DP4.DepartmentId   \n");

            if (LedgerId != 0)
            {
                strSql.Append("WHERE GL.LedgerId='" + LedgerId + "' \n");
            }

            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
        public string CheckGlContainsSubledger(string LedgerDesc)
        {

            DataTable dt = DAL.ExecuteDataset(CommandType.Text, "select SubLedgerId from erp.SubLedger where LedgerId  = (select LedgerId from ERP.GeneralLedger where GlDesc = '" + LedgerDesc.Trim().Replace("'", "''") + "')").Tables[0];
            return dt.Rows.Count > 0 ? "Y" : "N";
        }
        public void GetSingleLedger(string GlDesc, DateTime Date, int BranchId)
        {
            StringBuilder strSql = new StringBuilder();
            if (BranchId != 0)
            {
                strSql.Append(" Declare @LedgerId varchar(15) set @LedgerId = (Select LedgerId from Erp.GeneralLedger where GlDesc='" + GlDesc.Replace("'", "''") + "') select GlDesc,GL.LedgerId,GlShortName,isnull(CurrBal,0) as CurrBal,PanNo, isnull(CreditDay,0) as CreditDays ,isnull(CreditLimit,0) as CreditLimit from ERP.GeneralLedger as Gl Left Outer join (select (Sum(LocalDrAmt)- sum(LocalCrAmt)) as CurrBal,LedgerId from ERP.FinanceTransaction where LedgerId= @LedgerId and VDate<='" + Date.ToString("MM/dd/yyyy") + "'  and BranchId ='" + BranchId + "'  Group by LedgerId) as Tab on tab.LedgerId=Gl.LedgerId  where GlDesc='" + GlDesc.Replace("'", "''") + "' \n");
            }
            else
            {
                strSql.Append("Declare @LedgerId varchar(15) set @LedgerId = (Select LedgerId from Erp.GeneralLedger where GlDesc='" + GlDesc.Replace("'", "''") + "')  select GlDesc,Gl.LedgerId,GlShortname,isnull(CurrBal,0) as CurrentBal,panno, isnull(CreditDays,0) as CreditDays ,isnull(CreditLimit,0) as CreditLimit  from ERP.GeneralLedger as Gl Left Outer join (select (Sum(LocalDrAmt)- sum(LocalCrAmt)) as CurrBal,LedgerId from ERP.FinanceTransaction where LedgerId= @LedgerId and  VDate<='" + Date.ToString("MM/dd/yyyy") + "'  and BranchId is null  Group by LedgerId) as Tab on tab.LedgerId=Gl.LedgerId  where GlDesc='" + GlDesc.Replace("'", "''") + "' ");
            }

            DataTable dt = DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow ro in dt.Rows)
                {
                    Model.LedgerId = Convert.ToInt32(ro["LedgerId"].ToString());
                    Model.GlDesc = ro["GlDesc"].ToString();
                    Model.GlShortName = ro["GlShortname"].ToString();
                    Model.CurrentBal = Convert.ToDecimal(ro["CurrentBal"].ToString());
                    Model.PanNo = ro["PanNo"].ToString();
                    Model.CreditDays = Convert.ToDecimal(ro["CreditDays"].ToString());
                    Model.CreditLimit = Convert.ToDecimal(ro["CreditLimit"].ToString());
                }
            }
        }
        public string VatEntryLedger()
        {
            DataTable dt = DAL.ExecuteDataset(CommandType.Text, "SELECT GlDesc FROM ERP.GeneralLedger WHERE LedgerId = (select LedgerId from ERP.SalesBillingTerm WHERE TermId=(select VatLedgerId from ERP.SystemSetting))").Tables[0];
            return dt.Rows.Count > 0 ? dt.Rows[0]["GlDesc"].ToString() : "";
        }
        public DataTable GetCurrrentBalance(int LedgerId, DateTime date, int BranchId, int CompanyUnitId)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select GL.LedgerId,GlDesc,GlShortName,CONVERT(DECIMAL(18,2),isnull(CurrentBalance,0)) as CurrentBalance,PanNo,GL.SalesmanId,Salesman.SalesmanDesc,ISNULL(IsSubledger,0) AS IsSubledger, \n");
            strSql.Append("isnull(GL.CreditDays,0) as CreditDays ,CONVERT(DECIMAL(18,2),isnull(GL.CreditLimit,0)) as CreditLimit \n");
            strSql.Append("from ERP.GeneralLedger AS GL \n");
            strSql.Append("Left Outer join(Select LedgerId,ISNULL(sum(LocalDrAmt-LocalCrAmt),0)as CurrentBalance from ERP.FinanceTransaction where VDate<='" + date.ToString("yyyy-MM-dd") + "' \n");
            if (BranchId != 0)
            {
                strSql.Append("and BranchId='" + BranchId + "' \n");
            }
            strSql.Append("Group by LedgerId) as Tbl on Tbl.LedgerId=GL.LedgerId \n");
            strSql.Append("left outer join ERP.Salesman ON GL.SalesmanId=Salesman.SalesmanId \n");
            strSql.Append("where GL.LedgerId='" + LedgerId + "' \n");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
        //------------ START LEDGER MAPPING --------
        public void SaveLedgerMapping(string Module)
        {
            StringBuilder strSql = new StringBuilder();
            int i = 0;
            foreach (LedgerMappingList det in ModelLedgerMappingList)
            {
                if (Module == "AccountGroup")
                {
                    strSql.Append("UPDATE ERP.Generalledger  set AccountGrpId='" + det.AccountGrpId + "' where LedgerId='" + det.LedgerId + "' \n");
                }
                else if (Module == "AccountSubGroup")
                {
                    strSql.Append("UPDATE ERP.Generalledger  set AccountGrpId='" + det.AccountGrpId + "',AccountSubGrpId = '" + det.AccountSubGrpId + "' where LedgerId='" + det.LedgerId + "' \n");
                }
                else if (Module == "Salesman")
                {
                    strSql.Append("UPDATE ERP.Generalledger  set SalesmanId = " + ((det.SalesmanId == 0) ? "null" : "'" + det.SalesmanId + "'") + " where LedgerId='" + det.LedgerId + "' \n");
                }
                else if (Module == "Area")
                {
                    strSql.Append("UPDATE ERP.Generalledger  set AreaId = " + ((det.AreaId == 0) ? "null" : "'" + det.AreaId + "'") + " where LedgerId='" + det.LedgerId + "' \n");
                }
                else if (Module == "Branch")
                {
                    if (i == 0)
                    {
                        strSql.Append("Delete from [ERP].[LedgerBranchUnitMapping] where BranchId ='" + det.BranchId + "' \n");
                    }

                    strSql.Append("INSERT INTO [ERP].[LedgerBranchUnitMapping] (LedgerId, BranchId, CompanyUnitId) \n");
                    strSql.Append("Select '" + det.LedgerId + "','" + det.BranchId + "',null \n");
                }
                else if (Module == "CompanyUnit")
                {
                    if (i == 0)
                    {
                        strSql.Append("Delete from [ERP].[LedgerBranchUnitMapping] where CompanyUnitId ='" + det.CompanyUnitId + "' \n");
                    }

                    strSql.Append("INSERT INTO [ERP].[LedgerBranchUnitMapping] (LedgerId, BranchId, CompanyUnitId) \n");
                    strSql.Append("Select '" + det.LedgerId + "','" + det.BranchId + "','" + det.CompanyUnitId + "' \n");
                }
                i++;
            }
            ModelLedgerMappingList.Clear();
            DAL.ExecuteNonQuery(System.Data.CommandType.Text, strSql.ToString());

        }
        public DataTable AccountGroupListForLedgerMapping(string AccountGrpId)
        {
            return DAL.ExecuteDataset(CommandType.Text, "SELECT * FROM(select 0 AS S,'True' as Tag,GL.GlShortName,GL.GlDesc,AG.AccountGrpDesc,GL.LedgerId,GL.AccountGrpId from ERP.GeneralLedger as GL  left Join ERP.AccountGroup  as AG on GL.AccountGrpId=AG.AccountGrpId where Gl.AccountGrpId IN(" + AccountGrpId + ") Union All select 1 AS S,'False'as Tag,GL.GlShortName,GL.GlDesc,AG.AccountGrpDesc,GL.LedgerId,GL.AccountGrpId from ERP.GeneralLedger as GL left Join ERP.AccountGroup  as AG on GL.AccountGrpId=AG.AccountGrpId where Gl.AccountGrpId NOT IN(" + AccountGrpId + ")) AS T ORDER BY T.S, T.GlDesc").Tables[0];
        }
        public DataTable AccountSubGroupListForLedgerMapping(string AccountSubGrpId)
        {
            return DAL.ExecuteDataset(CommandType.Text, "select * from(select 0 AS S, 'True' as Tag, LedgerId,GlShortName, GlDesc, AccountGrpDesc, AccountSubGrpDesc from erp.GeneralLedger as GL inner join erp.AccountGroup AS AG on GL.AccountGrpId = AG.AccountGrpId LEFT OUTER JOIN ERP.AccountSubGroup AS ASG ON GL.AccountSubGrpId = ASG.AccountSubGrpId where GL.LedgerId IN(SELECT LedgerId FROM ERP.GeneralLedger WHERE AccountSubGrpId =" + AccountSubGrpId + ") union all select 1 AS S, 'False' as Tag, LedgerId,GlShortName, GlDesc, AccountGrpDesc, AccountSubGrpDesc from erp.GeneralLedger as GL inner join erp.AccountGroup AS AG on GL.AccountGrpId = AG.AccountGrpId LEFT OUTER JOIN ERP.AccountSubGroup AS ASG ON GL.AccountSubGrpId = ASG.AccountSubGrpId where GL.LedgerId NOT IN(SELECT LedgerId FROM ERP.GeneralLedger WHERE AccountSubGrpId =" + AccountSubGrpId + ")) as T order by T.S, GlDesc").Tables[0];
        }
        public DataTable SalesManpListForLedgerMapping(string SalesmanId)
        {
            return DAL.ExecuteDataset(CommandType.Text, "SELECT * FROM (select 0 AS S,'True'as Tag,GL.GlShortName,GL.GlDesc,A.SalesmanDesc,GL.LedgerId,GL.SalesmanId from erp.GeneralLedger as GL left Join erp.Salesman  as A on GL.AreaId=A.SalesmanId   where Gl.SalesmanId in (" + SalesmanId + ") Union All  select 0 AS S,'False'as Tag,GL.GlShortName,GL.GlDesc,A.SalesmanDesc,GL.LedgerId,GL.SalesmanId from ERP.GeneralLedger as GL  left Join ERP.Salesman  as A on GL.AreaId=A.SalesmanId   where  GL.GlCategory<>'Other' and Gl.SalesmanId IS NULL OR GL.SalesmanId Not in (" + SalesmanId + ") ) AS T ORDER BY T.S, T.GlDesc").Tables[0];
        }
        public DataTable AreaListForLedgerMapping(string AreaId)
        {
            return DAL.ExecuteDataset(CommandType.Text, "SELECT * FROM (select 0 AS S,'True'as Tag,GL.GlShortName,GL.GlDesc,A.AreaDesc,GL.LedgerId,GL.AreaId from erp.GeneralLedger as GL left Join erp.Area  as A on GL.AreaId=A.AreaId   where Gl.AreaId in (" + AreaId + ") Union All  select 0 AS S,'False'as Tag,GL.GlShortName,GL.GlDesc,A.AreaDesc,GL.LedgerId,GL.AreaId from ERP.GeneralLedger as GL  left Join ERP.Area  as A on GL.AreaId=A.AreaId   where  GL.GlCategory<>'Other' and Gl.AreaId IS NULL OR GL.AreaId Not in (" + AreaId + ")) AS T ORDER BY T.S, T.GlDesc").Tables[0];
        }
        public DataTable BranchListForLedgerMapping(string BranchId)
        {
            return DAL.ExecuteDataset(CommandType.Text, "SELECT * FROM ( select 0 AS S,'True'as Tag,GL.GlShortName,GL.GlDesc,B.BranchName,GL.LedgerId,B.BranchId from erp.GeneralLedger as GL left Join erp.LedgerBranchUnitMapping  as LB on GL.LedgerId=LB.LedgerId left join ERP.Branch as B on LB.BranchId=B.BranchId where B.BranchId in (" + BranchId + ") Union All  select 0 AS S,'False'as Tag,GL.GlShortName,GL.GlDesc,B.BranchName,GL.LedgerId,B.BranchId from ERP.GeneralLedger as GL  left Join erp.LedgerBranchUnitMapping  as LB on GL.LedgerId=LB.LedgerId left join ERP.Branch as B on LB.BranchId=B.BranchId where   B.BranchId IS NULL OR B.BranchId Not in (" + BranchId + ")) AS T ORDER BY T.S, T.GlDesc").Tables[0];
        }
        public DataTable CompanyUnitListForLedgerMapping(string CompanyUnitId)
        {
            return DAL.ExecuteDataset(CommandType.Text, "SELECT * FROM (select 0 AS S,'True'as Tag, LedgerId,GlShortName,GlDesc,'' as CmpUnitName from  ERP.GeneralLedger  where LedgerId  in ( select LedgerId from Erp.LedgerBranchUnitMapping where CompanyUnitId=" + CompanyUnitId + ") union all select 1 AS S,'False'as Tag, LedgerId,GlShortName,GlDesc,'' as CmpUnitName from  ERP.GeneralLedger  where LedgerId not in ( select LedgerId from Erp.LedgerBranchUnitMapping where CompanyUnitId=" + CompanyUnitId + ")) as T ORDER BY T.S, T.GlDesc ").Tables[0];
        }
        //------------ END LEDGER MAPPING --------
    }

    public class LedgerViewModel
    {
        public string Tag { get; set; }
        public int LedgerId { get; set; }
        public string GlDesc { get; set; }
        public string GlShortName { get; set; }
        public string GlPrintingName { get; set; }
        public string ACCode { get; set; }
        public string GlAlias { get; set; }
        public string GlCategory { get; set; }
        public int AccountGrpId { get; set; }
        public int AccountSubGrpId { get; set; }
        public int AreaId { get; set; }
        public int SalesmanId { get; set; }
        public int CurrencyId { get; set; }
        public int DepartmentId1 { get; set; }
        public int DepartmentId2 { get; set; }
        public int DepartmentId3 { get; set; }
        public int DepartmentId4 { get; set; } 
        public decimal CreditDays { get; set; }
        public string CreditDaysWarning { get; set; }
        public decimal CreditLimit { get; set; }
        public string CreditLimitWarning { get; set; }
        public string CreditType { get; set; }
        public int ChequeReciveDays { get; set; }
        public decimal InterestRate { get; set; }
        public int SchemeId { get; set; }
        public bool IsSubledger { get; set; }
        public bool IsCard { get; set; }
        public bool IsTDSAplicable { get; set; }
        public bool IsDocAdjustment { get; set; }
        public string Address { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PhoneNo { get; set; }
        public string AltPhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string DOB { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string FaxNo { get; set; }
        public string EmailId { get; set; }
        public string Website { get; set; }
        public string PanNo { get; set; }
        public string NationalId { get; set; }
        public string DrvingLicenseNo { get; set; }
        public string GlPictureUrl { get; set; }
        public string ContactPersonName { get; set; }
        public string CPAddress { get; set; }
        public string CPPhoneNo { get; set; }
        public string CPAltPhoneNo { get; set; }
        public string EnterBy { get; set; }
        public DateTime EnterDate { get; set; }
        public bool Status { get; set; }
        public decimal CurrentBal { get; set; }
        public string Gadget { get; set; }
        public string CustomerType { get; set; }
        public string UserName { get; set; }
        public string UMobileNo { get; set; }
        public string UEmailId { get; set; }
        public string Password { get; set; }
        public int ULedgerId { get; set; }
    }

    public class LedgerBranchCompanyUnitModel
    {
        public string Tag { get; set; }
        public int LedgerId { get; set; }
        public int BranchId { get; set; }
        public int CompanyUnitId { get; set; }
        public string Gadget { get; set; }
    }

    public class LedgerMappingList
    {
        public string Tag { get; set; }
        public int LedgerId { get; set; }
        public int AccountGrpId { get; set; }
        public int AccountSubGrpId { get; set; }
        public int SalesmanId { get; set; }
        public int AreaId { get; set; }
        public int BranchId { get; set; }
        public int CompanyUnitId { get; set; }
    }

}
