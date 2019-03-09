﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Common
{
    public class ClsUpdateCompany
    {
        ActiveDataAccess.ActiveDataAccess DAL;

        public ClsUpdateCompany()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
        }

        public string GetCompanyVersionNo()
        {
            DataTable dt = DAL.ExecuteDataset(CommandType.Text, "select VersionNo from ERP.CompanyInfo").Tables[0];
            return dt.Rows[0]["VersionNo"].ToString();
        }

        public void UpdateCompanyVersionNo(string VersionNo)
        {
            DAL.ExecuteNonQuery(CommandType.Text, "UPDATE ERP.CompanyInfo SET VersionNo='" + VersionNo + "'");
        }

        public void CreateView()
        {
            StringBuilder strSql = new StringBuilder();
            try
            {
                DAL.ExecuteNonQuery(CommandType.Text, "drop view ViewCompanyInfo");
            }
            catch { }

            try
            {
                DAL.ExecuteNonQuery(CommandType.Text, "Create View ViewCompanyInfo as select Initial,CompanyName,StartDate,EndDate,CompanyLogo,[Address],City,District,[State],Country,PhoneNo,AltPhoneNo,Fax,PanNo,Email,Website From ERP.CompanyInfo");
            }
            catch { }

            #region---------------Sales Invoice View-----------------
            try
            {
                DAL.ExecuteNonQuery(CommandType.Text, "drop view ViewSalesInvoiceMaster");
            }
            catch { }

            try
            {
                strSql.Append("Create View ViewSalesInvoiceMaster as \n");
                strSql.Append("Select \n");
                strSql.Append("SIM.VoucherNo as [Voucher No], \n");
                strSql.Append("SIM.VDate as [Voucher Date], \n");
                strSql.Append("GL.GlDesc as [Customer], \n");
                strSql.Append("GL.GlShortName as [Customer Code], \n");
                strSql.Append("SL.SubledgerDesc as [SubLedger], \n");
                strSql.Append("SL.SubledgerShortName as [Subledger Code], \n");
                strSql.Append("SIM.VMiti as [Voucher Miti], \n");
                strSql.Append("SIM.VTime as [Voucher Time], \n");
                strSql.Append("SIM.ReferenceNo as [Reference No], \n");
                strSql.Append("SIM.ReferenceDate as [Reference Date], \n");
                strSql.Append("SIM.ReferenceMiti as [Reference Miti], \n");
                strSql.Append("SIM.DueDay, \n");
                strSql.Append("SIM.DueDate, \n");
                strSql.Append("SIM.DueMiti, \n");
                strSql.Append("SIM.PartyName, \n");
                strSql.Append("SIM.ChequeNo, \n");
                strSql.Append("SIM.ChequeDate, \n");
                strSql.Append("SIM.ChequeMiti, \n");
                strSql.Append("SIM.PartyVatNo, \n");
                strSql.Append("SIM.PartyAddress, \n");
                strSql.Append("SIM.CurrencyId as [Currency Code], \n");
                strSql.Append("SIM.CurrencyRate as [Currency Rate], \n");
                strSql.Append("SIM.DepartmentId1, \n");
                strSql.Append("SIM.DepartmentId2, \n");
                strSql.Append("SIM.DepartmentId3, \n");
                strSql.Append("SIM.DepartmentId4, \n");
                strSql.Append("SIM.Remarks, \n");
                strSql.Append("SIM.EnterBy, \n");
                strSql.Append("SIM.PaymentType, \n");
                strSql.Append("SIM.OrderNo as [Order No], \n");
                strSql.Append("--MOrderDate as [Order Date], MOrderMiti as [Order Miti], \n");
                strSql.Append("SIM.ChallanNo as [Challan No], \n");
                strSql.Append("--MChallanDate as [Challan Date], MChallanMiti as [Challan Miti], \n");
                strSql.Append("isnull(SalesIrd.PrintCopy, 0) as PrintCopy, \n");
                strSql.Append("SalesIrd.PrintedDate, \n");
                strSql.Append("SalesIrd.PrintedBy, \n");
                strSql.Append("SIM.BasicAmount, \n");
                strSql.Append("SIM.TermAmount, \n");
                strSql.Append("SIM.NetAmount, \n");
                strSql.Append("SIM.TenderAmount, \n");
                strSql.Append("SIM.ReturnAmount, \n");
                strSql.Append("SL.[Address] as [Subledger Address], \n");
                strSql.Append("GL.PanNo, \n");
                strSql.Append("GL.Country, \n");
                strSql.Append("GL.[Address] as [Ledger Address], \n");
                strSql.Append("GL.Address1 as [Ledger Address1], \n");
                strSql.Append("GL.MobileNo, \n");
                strSql.Append("GL.Email, \n");
                strSql.Append("Salesman.SalesmanDesc as [Bill Salesman Name], \n");
                strSql.Append("Salesman.SalesmanShortName as [Bill Salesman Code], \n");
                strSql.Append("Salesman1.SalesmanDesc as [Salesman Name], \n");
                strSql.Append("Salesman1.SalesmanShortName as [Salesman Code], \n");
                strSql.Append("Area.AreaDesc as [Area Name], \n");
                strSql.Append("Area.AreaShortName as [Area Code], \n");
                strSql.Append("Branch.BranchName as [Branch Name], \n");
                strSql.Append("CompanyUnit.CmpUnitName as [Company Unit], \n");
                strSql.Append("SIM.TableId, \n");
                strSql.Append("TableMaster.TableDesc \n");
                strSql.Append("From ERP.SalesInvoiceMaster as SIM \n");
                strSql.Append("Left outer join ERP.SalesIrd on SIM.VoucherNo=SalesIrd.VoucherNo \n");
                strSql.Append("Left outer join ERP.GeneralLedger as GL on SIM.LedgerId = GL.LedgerId \n");
                strSql.Append("Left Outer join ERP.SubLedger as SL on SIM.SubledgerId = SL.SubledgerId \n");
                strSql.Append("Left outer join ERP.Area as Area on Area.AreaId=GL.AreaId \n");
                strSql.Append("Left outer join ERP.Salesman as Salesman1 on Salesman1.SalesmanId=GL.SalesmanId \n");
                strSql.Append("Left outer join ERP.Salesman on SIM.SalesmanId = Salesman.SalesmanId \n");
                strSql.Append("Left Outer Join ERP.Branch on SIM.BranchId = Branch.BranchId \n");
                strSql.Append("Left Outer Join ERP.CompanyUnit on SIM.CompanyUnitId = CompanyUnit.CompanyUnitId \n");
                strSql.Append("Left Outer Join ERP.TableMaster on SIM.TableId = TableMaster.TableId \n");
                strSql.Append("where SIM.IsBillCancel='0' \n");
                DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            }
            catch { }

            try
            {
                DAL.ExecuteNonQuery(CommandType.Text, "drop view ViewSalesInvoiceDetails");
            }
            catch { }

            try
            {
                strSql.Clear();
                strSql.Append("CREATE VIEW ViewSalesInvoiceDetails as \n");
                strSql.Append("Select VoucherNo as [Voucher No],SNo,ProductShortName as [Product Code],ProductDesc as [Product Name],Product.ProductAlias as [Product Alias], \n");
                strSql.Append("ProductPrintingName,GodownShortName as [Godown Code],GodownDesc as [Godown Desc],SalesInvoiceDetails.AltQty, \n");
                strSql.Append("SalesInvoiceDetails.Qty,SalesInvoiceDetails.SalesRate,BasicAmount,TermAmount,NetAmount,LocalNetAmount,TaxableAmount,TaxFreeAmount,VatAmount, \n");
                strSql.Append("AdditionalDesc,OrderSNo,OrderNo,ChallanSNo,ChallanNo,ProductAltUnit.ProductUnitDesc as [Alt Unit], \n");
                strSql.Append("ProductUnit.ProductUnitDesc as [Unit],ProductGrpShortName as [Group Code],ProductGrpDesc as [Group Name], \n");
                strSql.Append("ProductSubGrpDesc as [Sub Group],ProductSubGrpShortName as [Sub Group Code] \n");
                strSql.Append("From ERP.SalesInvoiceDetails \n");
                strSql.Append("Left Outer join ERP.Product on SalesInvoiceDetails.ProductId = Product.ProductId \n");
                strSql.Append("Left Outer join ERP.ProductGroup on Product.ProductGrpId = ProductGroup.ProductGrpId \n");
                strSql.Append("Left Outer join ERP.ProductSubGroup on Product.ProductSubGrpId = ProductSubGroup.ProductSubGrpId \n");
                strSql.Append("Left Outer join ERP.Godown on SalesInvoiceDetails.GodownId = Godown.GodownId \n");
                strSql.Append("Left Outer join ERP.ProductUnit as ProductAltUnit on SalesInvoiceDetails.ProductAltUnit = ProductAltUnit.ProductUnitId \n");
                strSql.Append("Left Outer join ERP.ProductUnit as ProductUnit on SalesInvoiceDetails.ProductUnit = ProductUnit.ProductUnitId \n");
                DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            }
            catch { }

            try
            {
                DAL.ExecuteNonQuery(CommandType.Text, "drop view ViewFinanceTransaction");
            }
            catch { }

            try
            {
                strSql.Clear();
                strSql.Append("Create View ViewFinanceTransaction as \n");
                strSql.Append("select Source,VoucherNo as [Voucher No],VDate as [Date],VMiti as [Miti],VTime as [Time],GlShortName as [Ledger Code], \n");
                strSql.Append("GlDesc as [Ledger Desc] ,SalesmanShortName as [Salesman Code],SalesmanDesc as [Agent Desc],SubledgerShortName as [SubLedger Code], \n");
                strSql.Append("SubledgerDesc as [Subledger Desc] ,sum(DrAmt) as [Debit],sum(CrAmt) as [Credit],sum(LocalDrAmt) as [Local Debit], \n");
                strSql.Append("sum(LocalCrAmt) as [Local Credit], Naration,Remarks,ChequeNo as [Cheque No],ChequeDate as [Cheque Date], \n");
                strSql.Append("ChequeMiti as [Cheque Miti] \n");
                strSql.Append("From [ERP].GeneralLedger,[ERP].[FinanceTransaction] \n");
                strSql.Append("left outer join [ERP].Salesman on Salesman.SalesmanId=[ERP].[FinanceTransaction].SalesmanId \n");
                strSql.Append("Left Outer join [ERP].SubLedger on SubLedger.SubledgerId=[ERP].[FinanceTransaction].SubledgerId \n");
                strSql.Append("Where GeneralLedger.LedgerId = [ERP].[FinanceTransaction].LedgerId \n");
                strSql.Append("group by Source,VoucherNo,VDate,VMiti,VTime,GlShortName,GlDesc,SalesmanShortName, \n");
                strSql.Append("SalesmanDesc,SubledgerShortName,SubledgerDesc,Naration,Remarks,ChequeNo,ChequeDate,ChequeMiti \n");
                DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            }
            catch { }

            try
            {
                DAL.ExecuteNonQuery(CommandType.Text, "drop view ViewSalesInvoiceTermProductWise");
            }
            catch { }

            try
            {
                DataTable dt1 = DAL.ExecuteDataset(CommandType.Text, "SELECT SUBSTRING((SELECT ', [' + TermDesc + ']' FROM erp.SalesBillingTerm  where Billwise in ('N') and Category = 'General' order by CONVERT(int, TermId) FOR XML PATH('')), 3, 200000) as Terms").Tables[0];
                DataTable dt2 = DAL.ExecuteDataset(CommandType.Text, "SELECT SUBSTRING((SELECT ', CONVERT(DECIMAL(18, 2), ISNULL([' + TermDesc + '],0)) AS [' + TermDesc + ']' FROM erp.SalesBillingTerm  where Billwise in ('N') and Category = 'General' order by CONVERT(int, TermId) FOR XML PATH('')), 3, 200000) as Terms").Tables[0];
                if (dt1.Rows.Count > 0)
                {
                    strSql.Clear();
                    strSql.Append("Create View ViewSalesInvoiceTermProductWise as \n");
                    strSql.Append("select VoucherNo as [Voucher No],SNo,ProductId," + dt2.Rows[0]["Terms"].ToString() + " from (select VoucherNo,TermDesc as [Term Description],SNo,SalesInvoiceTerm.ProductId, \n");
                    strSql.Append("case when SalesInvoiceTerm.STSign='+' then LocalTermAmt else -LocalTermAmt end as LocalTermAmt \n");
                    strSql.Append("from ERP.SalesBillingTerm,ERP.SalesInvoiceTerm \n");
                    strSql.Append("where SalesBillingTerm.TermId=SalesInvoiceTerm.TermId and SalesInvoiceTerm.TermType='P' ) as d \n");
                    strSql.Append("Pivot(max(LocalTermAmt) for [Term Description] in (" + dt1.Rows[0]["Terms"].ToString() + ")) piv \n");
                    DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString());
                }
                else
                {
                    DAL.ExecuteNonQuery(CommandType.Text, "Create View  ViewSalesInvoiceTermProductWise as select VoucherNo as [Voucher No],Sno,ProductId from ERP.SalesInvoiceTerm");
                }
            }
            catch { }

            try
            {
                DAL.ExecuteNonQuery(CommandType.Text, "drop view ViewSalesInvoiceTermBillWise");
            }
            catch { }

            try
            {
                DataTable dt1 = DAL.ExecuteDataset(CommandType.Text, "SELECT SUBSTRING((SELECT ', [' + TermDesc + ']' FROM erp.SalesBillingTerm  where Billwise in ('Y') and Category = 'General' order by CONVERT(int, TermId) FOR XML PATH('')), 3, 200000) as Terms").Tables[0];
                DataTable dt2 = DAL.ExecuteDataset(CommandType.Text, "SELECT SUBSTRING((SELECT ', CONVERT(DECIMAL(18, 2), ISNULL([' + TermDesc + '],0)) AS [' + TermDesc + ']' FROM erp.SalesBillingTerm  where Billwise in ('Y') and Category = 'General' order by CONVERT(int, TermId) FOR XML PATH('')), 3, 200000) as Terms").Tables[0];
                if (dt1.Rows.Count > 0)
                {
                    strSql.Clear();
                    strSql.Append("Create View ViewSalesInvoiceTermBillWise as \n");
                    strSql.Append("select VoucherNo as [Voucher No]," + dt2.Rows[0]["Terms"].ToString() + " from (select VoucherNo,TermDesc as [Term Description], \n");
                    strSql.Append("case when SalesInvoiceTerm.STSign='+' then LocalTermAmt else -LocalTermAmt end as LocalTermAmt \n");
                    strSql.Append("from ERP.SalesBillingTerm,ERP.SalesInvoiceTerm \n");
                    strSql.Append("where SalesBillingTerm.TermId=SalesInvoiceTerm.TermId and SalesInvoiceTerm.TermType='B' ) as d \n");
                    strSql.Append("Pivot(max(LocalTermAmt) for [Term Description] in (" + dt1.Rows[0]["Terms"].ToString() + ")) piv \n");
                    DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString());
                }
                else
                {
                    DAL.ExecuteNonQuery(CommandType.Text, "Create View  ViewSalesInvoiceTermBillWise as select VoucherNo as [Voucher No] from ERP.SalesInvoiceTerm");
                }
            }
            catch { }

            try
            {
                DAL.ExecuteNonQuery(CommandType.Text, "drop view ViewLedgerBalance");
            }
            catch { }

            try
            {
                strSql.Clear();
                strSql.Append("create view ViewLedgerBalance as \n");
                strSql.Append("SELECT GlDesc,GlShortName,SUM(DrAmt-CrAmt) AS Balance,SUM(LocalDrAmt-LocalCrAmt) AS LocalBalance \n");
                strSql.Append("FROM [ERP].[FinanceTransaction],[ERP].GeneralLedger \n");
                strSql.Append("WHERE FinanceTransaction.LedgerId=GeneralLedger.LedgerId and source <> 'PDC' GROUP BY GlShortName,GlDesc \n");
                DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            }
            catch { }

            try
            {
                DAL.ExecuteNonQuery(CommandType.Text, "drop view ViewSalesInvoiceOtherDetails");
            }
            catch { }

            try
            {
                DAL.ExecuteNonQuery(CommandType.Text, "Create View ViewSalesInvoiceOtherDetails as select VoucherNo as [Voucher No], Transport, VehicleNo, Package, CnNo, CnDate, CnFreight, CnType, Advance, BalFreight, DriverName, DriverLicNo, DriverMobileNo, ContractNo, ContractDate, ExpInvNo, ExpInvDate, PoNo, PoDate, DocBank, LcNo, CustomName, Cofd From [ERP].[SalesInvoiceOtherDetails]");
            }
            catch { }
            #endregion

            #region---------------Sales Order View-------------------
            try
            {
                DAL.ExecuteNonQuery(CommandType.Text, "drop view ViewSalesOrderMaster");
            }
            catch { }

            try
            {
                strSql.Clear();
                strSql.Append("Create View ViewSalesOrderMaster as \n");
                strSql.Append("Select \n");
                strSql.Append("SIM.VoucherNo as [Voucher No], \n");
                strSql.Append("SIM.VDate as [Voucher Date], \n");
                strSql.Append("GL.GlDesc as [Customer], \n");
                strSql.Append("GL.GlShortName as [Customer Code], \n");
                strSql.Append("SL.SubledgerDesc as [SubLedger], \n");
                strSql.Append("SL.SubledgerShortName as [Subledger Code], \n");
                strSql.Append("SIM.VMiti as [Voucher Miti], \n");
                strSql.Append("SIM.VTime as [Voucher Time], \n");
                strSql.Append("SIM.ReferenceNo as [Reference No], \n");
                strSql.Append("SIM.ReferenceDate as [Reference Date], \n");
                strSql.Append("SIM.ReferenceMiti as [Reference Miti], \n");
                strSql.Append("SIM.PartyName, \n");
                strSql.Append("SIM.ChequeNo, \n");
                strSql.Append("SIM.ChequeDate, \n");
                strSql.Append("SIM.ChequeMiti, \n");
                strSql.Append("SIM.PartyVatNo, \n");
                strSql.Append("SIM.PartyAddress, \n");
                strSql.Append("SIM.CurrencyId as [Currency Code], \n");
                strSql.Append("SIM.CurrencyRate as [Currency Rate], \n");
                strSql.Append("SIM.DepartmentId1, \n");
                strSql.Append("SIM.DepartmentId2, \n");
                strSql.Append("SIM.DepartmentId3, \n");
                strSql.Append("SIM.DepartmentId4, \n");
                strSql.Append("SIM.Remarks, \n");
                strSql.Append("SIM.EnterBy, \n");
                strSql.Append("SIM.QuotationNo, \n");
                strSql.Append("SIM.BasicAmount, \n");
                strSql.Append("SIM.TermAmount, \n");
                strSql.Append("SIM.NetAmount, \n");
                strSql.Append("SL.[Address] as [Subledger Address], \n");
                strSql.Append("GL.PanNo, \n");
                strSql.Append("GL.Country, \n");
                strSql.Append("GL.[Address] as [Ledger Address], \n");
                strSql.Append("GL.Address1 as [Ledger Address1], \n");
                strSql.Append("GL.MobileNo, \n");
                strSql.Append("GL.Email, \n");
                strSql.Append("Salesman.SalesmanDesc as [Bill Salesman Name], \n");
                strSql.Append("Salesman.SalesmanShortName as [Bill Salesman Code], \n");
                strSql.Append("Salesman1.SalesmanDesc as [Salesman Name], \n");
                strSql.Append("Salesman1.SalesmanShortName as [Salesman Code], \n");
                strSql.Append("Area.AreaDesc as [Area Name], \n");
                strSql.Append("Area.AreaShortName as [Area Code], \n");
                strSql.Append("Branch.BranchName as [Branch Name], \n");
                strSql.Append("CompanyUnit.CmpUnitName as [Company Unit], \n");
                strSql.Append("SIM.TableId,SIM.CounterId,CounterDesc as [Counter Name] ,\n");
                strSql.Append("TableMaster.TableDesc \n");
                strSql.Append("From ERP.SalesOrderMaster as SIM \n");
                strSql.Append("Left outer join ERP.GeneralLedger as GL on SIM.LedgerId = GL.LedgerId \n");
                strSql.Append("Left Outer join ERP.SubLedger as SL on SIM.SubledgerId = SL.SubledgerId \n");
                strSql.Append("Left outer join ERP.Area as Area on Area.AreaId=GL.AreaId \n");
                strSql.Append("Left outer join ERP.Salesman as Salesman1 on Salesman1.SalesmanId=GL.SalesmanId \n");
                strSql.Append("Left outer join ERP.Salesman on SIM.SalesmanId = Salesman.SalesmanId \n");
                strSql.Append("Left Outer Join ERP.Branch on SIM.BranchId = Branch.BranchId \n");
                strSql.Append("Left Outer Join ERP.CompanyUnit on SIM.CompanyUnitId = CompanyUnit.CompanyUnitId \n");
                strSql.Append("Left Outer Join ERP.TableMaster on SIM.TableId = TableMaster.TableId \n");
                strSql.Append("Left Outer Join ERP.Counter on SIM.CounterId = Counter.TableId \n");
                strSql.Append("where SIM.IsOrderCancel='0' \n");
                DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            }
            catch { }

            try
            {
                DAL.ExecuteNonQuery(CommandType.Text, "drop view ViewSalesOrderDetails");
            }
            catch { }

            try
            {
                strSql.Clear();
                strSql.Append("CREATE VIEW ViewSalesOrderDetails as \n");
                strSql.Append("Select VoucherNo as [Voucher No],SNo,ProductShortName as [Product Code],ProductDesc as [Product Name],Product.ProductAlias as [Product Alias], \n");
                strSql.Append("ProductPrintingName,GodownShortName as [Godown Code],GodownDesc as [Godown Desc],SalesOrderDetails.AltQty, \n");
                strSql.Append("SalesOrderDetails.Qty,SalesOrderDetails.SalesRate,BasicAmount,TermAmount,NetAmount,LocalNetAmount, \n");
                strSql.Append("AdditionalDesc,ProductAltUnit.ProductUnitDesc as [Alt Unit], \n");
                strSql.Append("ProductUnit.ProductUnitDesc as [Unit],ProductGrpShortName as [Group Code],ProductGrpDesc as [Group Name], \n");
                strSql.Append("ProductSubGrpDesc as [Sub Group],ProductSubGrpShortName as [Sub Group Code],QuotationNo ,QuotationSNo,ResKOTNo,ResIsPrinted,ResOrderNotes,ResOrderTime,ResOrderBy  \n");
                strSql.Append("From ERP.SalesOrderDetails \n");
                strSql.Append("Left Outer join ERP.Product on SalesOrderDetails.ProductId = Product.ProductId \n");
                strSql.Append("Left Outer join ERP.ProductGroup on Product.ProductGrpId = ProductGroup.ProductGrpId \n");
                strSql.Append("Left Outer join ERP.ProductSubGroup on Product.ProductSubGrpId = ProductSubGroup.ProductSubGrpId \n");
                strSql.Append("Left Outer join ERP.Godown on SalesOrderDetails.GodownId = Godown.GodownId \n");
                strSql.Append("Left Outer join ERP.ProductUnit as ProductAltUnit on SalesOrderDetails.ProductAltUnit = ProductAltUnit.ProductUnitId \n");
                strSql.Append("Left Outer join ERP.ProductUnit as ProductUnit on SalesOrderDetails.ProductUnit = ProductUnit.ProductUnitId \n");
                DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            }
            catch { }

            try
            {
                DAL.ExecuteNonQuery(CommandType.Text, "drop view ViewSalesOrderTermProductWise");
            }
            catch { }

            try
            {
                DataTable dt1 = DAL.ExecuteDataset(CommandType.Text, "SELECT SUBSTRING((SELECT ', [' + TermDesc + ']' FROM erp.SalesBillingTerm  where Billwise in ('N') and Category = 'General' order by CONVERT(int, TermId) FOR XML PATH('')), 3, 200000) as Terms").Tables[0];
                DataTable dt2 = DAL.ExecuteDataset(CommandType.Text, "SELECT SUBSTRING((SELECT ', CONVERT(DECIMAL(18, 2), ISNULL([' + TermDesc + '],0)) AS [' + TermDesc + ']' FROM erp.SalesBillingTerm  where Billwise in ('N') and Category = 'General' order by CONVERT(int, TermId) FOR XML PATH('')), 3, 200000) as Terms").Tables[0];
                if (dt1.Rows.Count > 0)
                {
                    strSql.Clear();
                    strSql.Append("Create View ViewSalesOrderTermProductWise as \n");
                    strSql.Append("select VoucherNo as [Voucher No],SNo,ProductId," + dt2.Rows[0]["Terms"].ToString() + " from (select VoucherNo,TermDesc as [Term Description],SNo,SalesOrderTerm.ProductId, \n");
                    strSql.Append("case when SalesOrderTerm.STSign='+' then LocalTermAmt else -LocalTermAmt end as LocalTermAmt \n");
                    strSql.Append("from ERP.SalesBillingTerm,ERP.SalesOrderTerm \n");
                    strSql.Append("where SalesBillingTerm.TermId=SalesOrderTerm.TermId and SalesOrderTerm.TermType='P' ) as d \n");
                    strSql.Append("Pivot(max(LocalTermAmt) for [Term Description] in (" + dt1.Rows[0]["Terms"].ToString() + ")) piv \n");
                    DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString());
                }
                else
                {
                    DAL.ExecuteNonQuery(CommandType.Text, "Create View  ViewSalesOrderTermProductWise as select VoucherNo as [Voucher No],Sno,ProductId from ERP.SalesOrderTerm");
                }
            }
            catch { }

            try
            {
                DAL.ExecuteNonQuery(CommandType.Text, "drop view ViewSalesOrderTermBillWise");
            }
            catch { }

            try
            {
                DataTable dt1 = DAL.ExecuteDataset(CommandType.Text, "SELECT SUBSTRING((SELECT ', [' + TermDesc + ']' FROM erp.SalesBillingTerm  where Billwise in ('Y') and Category = 'General' order by CONVERT(int, TermId) FOR XML PATH('')), 3, 200000) as Terms").Tables[0];
                DataTable dt2 = DAL.ExecuteDataset(CommandType.Text, "SELECT SUBSTRING((SELECT ', CONVERT(DECIMAL(18, 2), ISNULL([' + TermDesc + '],0)) AS [' + TermDesc + ']' FROM erp.SalesBillingTerm  where Billwise in ('Y') and Category = 'General' order by CONVERT(int, TermId) FOR XML PATH('')), 3, 200000) as Terms").Tables[0];
                if (dt1.Rows.Count > 0)
                {
                    strSql.Clear();
                    strSql.Append("Create View ViewSalesOrderTermBillWise as \n");
                    strSql.Append("select VoucherNo as [Voucher No]," + dt2.Rows[0]["Terms"].ToString() + " from (select VoucherNo,TermDesc as [Term Description], \n");
                    strSql.Append("case when SalesOrderTerm.STSign='+' then LocalTermAmt else -LocalTermAmt end as LocalTermAmt \n");
                    strSql.Append("from ERP.SalesBillingTerm,ERP.SalesOrderTerm \n");
                    strSql.Append("where SalesBillingTerm.TermId=SalesOrderTerm.TermId and SalesOrderTerm.TermType='B' ) as d \n");
                    strSql.Append("Pivot(max(LocalTermAmt) for [Term Description] in (" + dt1.Rows[0]["Terms"].ToString() + ")) piv \n");
                    DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString());
                }
                else
                {
                    DAL.ExecuteNonQuery(CommandType.Text, "Create View  ViewSalesOrderTermProductWise as select VoucherNo as [Voucher No] from ERP.SalesOrderTerm");
                }
            }
            catch { }


            try
            {
                DAL.ExecuteNonQuery(CommandType.Text, "drop view ViewSalesOrderOtherDetails");
            }
            catch { }

            try
            {
                DAL.ExecuteNonQuery(CommandType.Text, "Create View ViewSalesOrderOtherDetails as select VoucherNo as [Voucher No], Transport, VehicleNo, Package, CnNo, CnDate, CnFreight, CnType, Advance, BalFreight, DriverName, DriverLicNo, DriverMobileNo, ContractNo, ContractDate, ExpInvNo, ExpInvDate, PoNo, PoDate, DocBank, LcNo, CustomName, Cofd From [ERP].[SalesOrderOtherDetails]");
            }
            catch { }
			#endregion

			#region---------------Purchase Invoice View--------------
			try
			{
				DAL.ExecuteNonQuery(CommandType.Text, "drop view ViewPurchaseInvoiceMaster");
			}
			catch { }

			try
			{
				strSql.Clear();
				strSql.Append("Create View ViewPurchaseInvoiceMaster as \n");
				strSql.Append("Select \n");
				strSql.Append("PIM.VoucherNo as [Voucher No], \n");
				strSql.Append("PIM.VDate as [Voucher Date], \n");
				strSql.Append("GL.GlDesc as [Customer], \n");
				strSql.Append("GL.GlShortName as [Customer Code], \n");
				strSql.Append("SL.SubledgerDesc as [SubLedger], \n");
				strSql.Append("SL.SubledgerShortName as [Subledger Code], \n");
				strSql.Append("PIM.VMiti as [Voucher Miti], \n");
				strSql.Append("PIM.VTime as [Voucher Time], \n");
				strSql.Append("PIM.ReferenceNo as [Reference No], \n");
				strSql.Append("PIM.ReferenceDate as [Reference Date], \n");
				strSql.Append("PIM.ReferenceMiti as [Reference Miti], \n");
				strSql.Append("PIM.DueDay, \n");
				strSql.Append("PIM.DueDate, \n");
				strSql.Append("PIM.DueMiti, \n");
				strSql.Append("PIM.PartyName, \n");
				strSql.Append("PIM.ChequeNo, \n");
				strSql.Append("PIM.ChequeDate, \n");
				strSql.Append("PIM.ChequeMiti, \n");
				strSql.Append("PIM.PartyVatNo, \n");
				strSql.Append("PIM.PartyAddress, \n");
				strSql.Append("PIM.CurrencyId as [Currency Code], \n");
				strSql.Append("PIM.CurrencyRate as [Currency Rate], \n");
				strSql.Append("PIM.DepartmentId1, \n");
				strSql.Append("PIM.DepartmentId2, \n");
				strSql.Append("PIM.DepartmentId3, \n");
				strSql.Append("PIM.DepartmentId4, \n");
				strSql.Append("PIM.Remarks, \n");
				strSql.Append("PIM.EnterBy, \n");
				strSql.Append("PIM.PaymentType, \n");
				strSql.Append("PIM.OrderNo as [Order No], \n");
				strSql.Append("--MOrderDate as [Order Date], MOrderMiti as [Order Miti], \n");
				strSql.Append("PIM.ChallanNo as [Challan No], \n");
				strSql.Append("--MChallanDate as [Challan Date], MChallanMiti as [Challan Miti], \n");
				strSql.Append("isnull(SalesIrd.PrintCopy, 0) as PrintCopy, \n");
				strSql.Append("SalesIrd.PrintedDate, \n");
				strSql.Append("SalesIrd.PrintedBy, \n");
				strSql.Append("PIM.BasicAmount, \n");
				strSql.Append("PIM.TermAmount, \n");
				strSql.Append("PIM.NetAmount, \n");
				strSql.Append("SL.[Address] as [Subledger Address], \n");
				strSql.Append("GL.PanNo, \n");
				strSql.Append("GL.Country, \n");
				strSql.Append("GL.[Address] as [Ledger Address], \n");
				strSql.Append("GL.Address1 as [Ledger Address1], \n");
				strSql.Append("GL.MobileNo, \n");
				strSql.Append("GL.Email, \n");
				strSql.Append("Salesman.SalesmanDesc as [Bill Salesman Name], \n");
				strSql.Append("Salesman.SalesmanShortName as [Bill Salesman Code], \n");
				strSql.Append("Salesman1.SalesmanDesc as [Salesman Name], \n");
				strSql.Append("Salesman1.SalesmanShortName as [Salesman Code], \n");
				strSql.Append("Area.AreaDesc as [Area Name], \n");
				strSql.Append("Area.AreaShortName as [Area Code], \n");
				strSql.Append("Branch.BranchName as [Branch Name], \n");
				strSql.Append("CompanyUnit.CmpUnitName as [Company Unit]\n");
				strSql.Append("From ERP.PurchaseInvoiceMaster as PIM \n");
				strSql.Append("Left outer join ERP.SalesIrd on PIM.VoucherNo=SalesIrd.VoucherNo \n");
				strSql.Append("Left outer join ERP.GeneralLedger as GL on PIM.LedgerId = GL.LedgerId \n");
				strSql.Append("Left Outer join ERP.SubLedger as SL on PIM.SubledgerId = SL.SubledgerId \n");
				strSql.Append("Left outer join ERP.Area as Area on Area.AreaId=GL.AreaId \n");
				strSql.Append("Left outer join ERP.Salesman as Salesman1 on Salesman1.SalesmanId=GL.SalesmanId \n");
				strSql.Append("Left outer join ERP.Salesman on PIM.SalesmanId = Salesman.SalesmanId \n");
				strSql.Append("Left Outer Join ERP.Branch on PIM.BranchId = Branch.BranchId \n");
				strSql.Append("Left Outer Join ERP.CompanyUnit on PIM.CompanyUnitId = CompanyUnit.CompanyUnitId \n");
				DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString());
			}
			catch { }

			try
			{
				DAL.ExecuteNonQuery(CommandType.Text, "DROP VIEW ViewPurchaseInvoiceDetails");
			}
			catch { }

			try
			{
				strSql.Clear();
				strSql.Append("CREATE VIEW ViewPurchaseInvoiceDetails as\n");
				strSql.Append("Select VoucherNo as [Voucher No],SNo,ProductShortName as [Product Code],ProductDesc as [Product Name],Product.ProductAlias as [Product Alias],\n");
				strSql.Append("ProductPrintingName,GodownShortName as [Godown Code],GodownDesc as [Godown Desc],PurchaseInvoiceDetails.AltQty,\n");
				strSql.Append("PurchaseInvoiceDetails.Qty,PurchaseInvoiceDetails.PurchaseRate,BasicAmount,TermAmount,NetAmount,LocalNetAmount,TaxableAmount,TaxFreeAmount,VatAmount,\n");
				strSql.Append("AdditionalDesc,OrderSNo,OrderNo,ChallanSNo,ChallanNo,ProductAltUnit.ProductUnitDesc as [Alt Unit],\n");
				strSql.Append("ProductUnit.ProductUnitDesc as [Unit],ProductGrpShortName as [Group Code],ProductGrpDesc as [Group Name],\n");
				strSql.Append("ProductSubGrpDesc as [Sub Group],ProductSubGrpShortName as [Sub Group Code]\n");
				strSql.Append("From ERP.PurchaseInvoiceDetails\n");
				strSql.Append("Left Outer join ERP.Product on PurchaseInvoiceDetails.ProductId = Product.ProductId\n");
				strSql.Append("Left Outer join ERP.ProductGroup on Product.ProductGrpId = ProductGroup.ProductGrpId\n");
				strSql.Append("Left Outer join ERP.ProductSubGroup on Product.ProductSubGrpId = ProductSubGroup.ProductSubGrpId\n");
				strSql.Append("Left Outer join ERP.Godown on PurchaseInvoiceDetails.GodownId = Godown.GodownId\n");
				strSql.Append("Left Outer join ERP.ProductUnit as ProductAltUnit on PurchaseInvoiceDetails.ProductAltUnit = ProductAltUnit.ProductUnitId\n");
				strSql.Append("Left Outer join ERP.ProductUnit as ProductUnit on PurchaseInvoiceDetails.ProductUnit = ProductUnit.ProductUnitId\n");
				DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString());
			}
			catch { }

			try
			{
				DAL.ExecuteNonQuery(CommandType.Text, "drop view ViewPurchaseInvoiceTermProductWise");
			}
			catch { }

			try
			{
				DataTable dt1 = DAL.ExecuteDataset(CommandType.Text, "SELECT SUBSTRING((SELECT ', [' + TermDesc + ']' FROM erp.PurchaseBillingTerm  where Billwise in ('N') and Category = 'General' order by CONVERT(int, TermId) FOR XML PATH('')), 3, 200000) as Terms").Tables[0];
				DataTable dt2 = DAL.ExecuteDataset(CommandType.Text, "SELECT SUBSTRING((SELECT ', CONVERT(DECIMAL(18, 2), ISNULL([' + TermDesc + '],0)) AS [' + TermDesc + ']' FROM erp.PurchaseBillingTerm  where Billwise in ('N') and Category = 'General' order by CONVERT(int, TermId) FOR XML PATH('')), 3, 200000) as Terms").Tables[0];
				if (dt1.Rows.Count > 0)
				{
					strSql.Clear();
					strSql.Append("Create View ViewPurchaseInvoiceTermProductWise as \n");
					strSql.Append("select VoucherNo as [Voucher No],SNo,ProductId," + dt2.Rows[0]["Terms"].ToString() + " from (select VoucherNo,TermDesc as [Term Description],SNo,PurchaseInvoiceTerm.ProductId, \n");
					strSql.Append("case when PurchaseInvoiceTerm.PTSign='+' then LocalTermAmt else -LocalTermAmt end as LocalTermAmt \n");
					strSql.Append("from ERP.PurchaseBillingTerm,ERP.PurchaseInvoiceTerm \n");
					strSql.Append("where PurchaseBillingTerm.TermId=PurchaseInvoiceTerm.TermId and PurchaseInvoiceTerm.TermType='P' ) as d \n");
					strSql.Append("Pivot(max(LocalTermAmt) for [Term Description] in (" + dt1.Rows[0]["Terms"].ToString() + ")) piv \n");
					DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString());
				}
				else
				{
					DAL.ExecuteNonQuery(CommandType.Text, "Create View ViewPurchaseInvoiceTermProductWise as select VoucherNo as [Voucher No],Sno,ProductId from ERP.PurchaseInvoiceTerm");
				}
			}
			catch { }

			try
			{
				DAL.ExecuteNonQuery(CommandType.Text, "drop view ViewPurchaseInvoiceTermBillWise");
			}
			catch { }

			try
			{
				DataTable dt1 = DAL.ExecuteDataset(CommandType.Text, "SELECT SUBSTRING((SELECT ', [' + TermDesc + ']' FROM erp.SalesBillingTerm  where Billwise in ('Y') and Category = 'General' order by CONVERT(int, TermId) FOR XML PATH('')), 3, 200000) as Terms").Tables[0];
				DataTable dt2 = DAL.ExecuteDataset(CommandType.Text, "SELECT SUBSTRING((SELECT ', CONVERT(DECIMAL(18, 2), ISNULL([' + TermDesc + '],0)) AS [' + TermDesc + ']' FROM erp.SalesBillingTerm  where Billwise in ('Y') and Category = 'General' order by CONVERT(int, TermId) FOR XML PATH('')), 3, 200000) as Terms").Tables[0];
				if (dt1.Rows.Count > 0)
				{
					strSql.Clear();
					strSql.Append("Create View ViewPurchaseInvoiceTermBillWise as \n");
					strSql.Append("select VoucherNo as [Voucher No]," + dt2.Rows[0]["Terms"].ToString() + " from (select VoucherNo,TermDesc as [Term Description], \n");
					strSql.Append("case when PurchaseInvoiceTerm.PTSign='+' then LocalTermAmt else -LocalTermAmt end as LocalTermAmt \n");
					strSql.Append("from ERP.PurchaseBillingTerm,ERP.PurchaseInvoiceTerm \n");
					strSql.Append("where PurchaseBillingTerm.TermId=PurchaseInvoiceTerm.TermId and PurchaseInvoiceTerm.TermType='B' ) as d \n");
					strSql.Append("Pivot(max(LocalTermAmt) for [Term Description] in (" + dt1.Rows[0]["Terms"].ToString() + ")) piv \n");
					DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString());
				}
				else
				{
					DAL.ExecuteNonQuery(CommandType.Text, "Create View  ViewPurchaseInvoiceTermBillWise as select VoucherNo as [Voucher No] from ERP.PurchaseInvoiceTerm");
				}
			}
			catch { }

			try
			{
				DAL.ExecuteNonQuery(CommandType.Text, "drop view ViewPurchaseInvoiceOtherDetails");
			}
			catch { }

			try
			{
				DAL.ExecuteNonQuery(CommandType.Text, "Create View ViewPurchaseInvoiceOtherDetails as select VoucherNo as [Voucher No], Transport, VehicleNo, Package, CnNo, CnDate, CnFreight, CnType, Advance, BalFreight, DriverName, DriverLicNo, DriverMobileNo, ContractNo, ContractDate, ExpInvNo, ExpInvDate, PoNo, PoDate, DocBank, LcNo, CustomName, Cofd From [ERP].[PurchaseInvoiceOtherDetails]");
			}
			catch { }
			#endregion
		}

		public void UpdateResetPickList(string Module)
        {
            StringBuilder Sb = new StringBuilder();
            Sb.Append("delete from ERP.PickListTemplate where Module = 'Master' and PageName = '" + Module + "' \n");
            Sb.Append(DefaultPickList(Module, "NO").ToString());
            DAL.ExecuteNonQuery(CommandType.Text, Sb.ToString());
        }

        public void InsertDefaultData()
        {
            StringBuilder strSql = new StringBuilder();
            try
            {
                strSql.Append("BEGIN \n");
                strSql.Append("IF NOT EXISTS (select DateType from [ERP].[SystemSetting]) \n");
                strSql.Append("BEGIN \n");
                strSql.Append("INSERT INTO [ERP].[SystemSetting](DateType,Gadget) VALUES('D','DEFAULT') \n");
                strSql.Append("END \n");
                strSql.Append("END \n");
                DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            }
            catch { }

            try
            {
                strSql.Append("BEGIN \n");
                strSql.Append("IF NOT EXISTS (select PickListId from [ERP].[PickListTemplate]) \n");
                strSql.Append("BEGIN \n");
                strSql.Append(DefaultPickList("", "YES").ToString());
                strSql.Append("END \n");
                strSql.Append("END \n");
                DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            }
            catch { }
        }

        public StringBuilder DefaultPickList(string Module, string isInsertPickList)
        {
            StringBuilder Sb = new StringBuilder();
            if (Module == "Account Group" || isInsertPickList == "YES")
            {
                Sb.Append("INSERT [ERP].[PickListTemplate] ([FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'AccountGrpId', N'AccountGrpId', 1, 0, 0, 0, 0, N'Master', N'Account Group')  \n");
                Sb.Append("INSERT [ERP].[PickListTemplate] ([FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'AccountGrpDesc', N'Group Desc', 0, 1, 1, 1, NULL, N'Master', N'Account Group')  \n");
                Sb.Append("INSERT [ERP].[PickListTemplate] ([FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'AccountGrpShortName', N'Short Name', 0, 1, 2, 1, 120, N'Master', N'Account Group')  \n");
                Sb.Append("INSERT [ERP].[PickListTemplate] ([FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'GrpType', N'AC Type', 0, 0, 3, 1, 120, N'Master', N'Account Group')  \n");
                Sb.Append("INSERT [ERP].[PickListTemplate] ([FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'PrimaryGrp', N'Primary Group', 0, 0, 4, 1, 120, N'Master', N'Account Group')  \n");
            }
            if (Module == "Account Sub Group" || isInsertPickList == "YES")
            {
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'AccountSubGrpId', N'AccountSubGrpId', 1, 0, 0, 0, 0, N'Master', N'Account Sub Group') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'AccountSubGrpDesc', N'Sub Group Desc', 0, 1, 1, 1, NULL, N'Master', N'Account Sub Group') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'AccountSubGrpShortName', N'Short Name', 0, 1, 2, 1, 120, N'Master', N'Account Sub Group') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'AccountGrpDesc', N'Account Group', 0, 0, 3, 1, 120, N'Master', N'Account Sub Group') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'AccountGrpId', N'AccountGrpId', 0, 0, 4, 0, 0, N'Master', N'Account Sub Group') \n");
            }
            if (Module == "Sales Term" || isInsertPickList == "YES")
            {
                Sb.Append(" INSERT[ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'TermId', N'TermId', 1, 0, 0, 0, 0, N'Master', N'Sales Term') \n");
                Sb.Append("INSERT[ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'TermPosition', N'Term Position', 0, 0, 1, 1, 95, N'Master', N'Sales Term') \n");
                Sb.Append("INSERT[ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'TermDesc', N'Term Desc', 0, 1, 2, 1, NULL, N'Master', N'Sales Term') \n");
                Sb.Append("INSERT[ERP].[PickListTemplate] ( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'Category', N'Category', 0, 1, 3, 1, 75, N'Master', N'Sales Term') \n");
                Sb.Append("INSERT[ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'LedgerDesc', N'Ledger Desc', 0, 1, 4, 1, 120, N'Master', N'Sales Term') \n");
                Sb.Append("INSERT[ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'BillWise', N'Bill Wise', 0, 1, 5, 1, 90, N'Master', N'Sales Term') \n");
            }
            if (Module == "Purchase Term" || isInsertPickList == "YES")
            {
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'TermId', N'TermId', 1, 0, 0, 0, 0, N'Master', N'Purchase Term') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'TermPosition', N'Term Position', 0, 0, 1, 1, 95, N'Master', N'Purchase Term') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'TermDesc', N'Term Desc', 0, 1, 2, 1, NULL, N'Master', N'Purchase Term') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'Category', N'Category', 0, 1, 3, 1, 75, N'Master', N'Purchase Term') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'LedgerDesc', N'Ledger Desc', 0, 1, 4, 1, 120, N'Master', N'Purchase Term') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'BillWise', N'Bill Wise', 0, 1, 5, 1, 90, N'Master', N'Purchase Term') \n");
            }
            if (Module == "General Ledger" || isInsertPickList == "YES")
            {
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'LedgerId', N'LedgerId', 1, 0, 0, 0, 0, N'Master', N'General Ledger') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'GlDesc', N'Ledger Desc', 0, 1, 1, 1, NULL, N'Master', N'General Ledger') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'GlShortName', N'Ledger ShortName', 0, 1, 2, 1, 120, N'Master', N'General Ledger') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate] ( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'GlCategory', N'Ledger Category', 0, 1, 3, 1, 120, N'Master', N'General Ledger') \n");
            }
            if (Module == "Product" || isInsertPickList == "YES")
            {
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'ProductId', N'ProductId', 1, 0, 0, 0, 0, N'Master', N'Product') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'ProductDesc', N'Product Description', 0, 1, 2, 1, 150, N'Master', N'Product') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate] ( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'ProductShortName', N'Product ShortName', 0, 1, 3, 1, 130, N'Master', N'Product') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'ProductCategory', N'ProductCategory', 0, 1, 4, 1, 110, N'Master', N'product') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'ProductType', N'Product Type', 0, 0, 5, 0, 0, N'Master', N'Product') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'SalesRate', N'Sales Rate', 0, 0, 6, 1, 100, N'Master', N'Product') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'BuyRate', N'Buy Rate', 0, 0, 7, 1, 100, N'Master', N'Product') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'IsBatchwise', N'IsBatchwise', 0, 0, 8, 1, 0, N'Master', N'Product') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate] ( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'Isserialwise', N'Isserialwise', 0, 0, 8, 1, 0, N'Master', N'Product') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'ProductGrpDesc', N'Group', 0, 0, 10, 1, 100, N'Master', N'Product') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'ProductSubGrpDesc', N'Sub Group', 0, 0, 11, 1, 100, N'Master', N'Product') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'ProductUnitId', N'ProductUnitId', 0, 0, 12, 1, 0, N'Master', N'Product') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'ProductUnit', N'Unit', 0, 0, 13, 1, 100, N'Master', N'Product') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate] ( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'ProductAltUnitId', N'ProductAltUnitId', 0, 0, 14, 1, 0, N'Master', N'Product') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'ProductAltUnit', N'Alt Unit', 0, 0, 15, 1, 100, N'Master', N'Product') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'StockQty', N'StockQty', 0, 0, 16, 1, 0, N'Master', N'Product') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate] ( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'AltStockQty', N'AltStockQty', 0, 0, 17, 1, 0, N'Master', N'Product') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate] ( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'QtyConv', N'QtyConv', 0, 0, 18, 1, 0, N'Master', N'Product') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'AltConv', N'AltConv', 0, 0, 19, 1, 0, N'Master', N'Product') \n");
            }
            if (Module == "ProductRestaurant" || isInsertPickList == "YES")
            {
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'ProductId', N'ProductId', 1, 0, 0, 0, 0, N'Master', N'ProductRestaurant') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'ProductDesc', N'Product Description', 0, 1, 2, 1, 150, N'Master', N'ProductRestaurant') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'ProductShortName', N'Product ShortName', 0, 1, 3, 1, 130, N'Master', N'ProductRestaurant') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'ProductUnitId', N'ProductUnitId', 0, 0, 12, 1, 0, N'Master', N'ProductRestaurant') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'ProductUnit', N'Unit', 0, 0, 13, 1, 100, N'Master', N'ProductRestaurant') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate] ( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'ProductGrpDesc', N'Group', 0, 0, 10, 1, 100, N'Master', N'ProductRestaurant') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'ProductSubGrpDesc', N'Sub Group', 0, 0, 11, 1, 100, N'Master', N'ProductRestaurant') \n");
                Sb.Append("INSERT [ERP].[PickListTemplate]( [FieldName], [DisplayName], [PrimaryColumn], [IsSearchable], [Odr], [ShowHide], [ColumnWidth], [Module], [PageName]) VALUES(N'PreparationCenter', N'Preparation Center', 0, 0, 14, 1, 100, N'Master', N'ProductRestaurant') \n");
            }
            return Sb;
        }
    }
}