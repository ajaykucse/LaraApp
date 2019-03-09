using DataAccessLayer.Interface.DataTransaction;
using DataAccessLayer.Interface.DataTransaction.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataTransaction.Sales
{
    public class ClsSalesOrder : ISalesOrder
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public SalesOrderMasterViewModel Model { get; set; }
        public List<SalesOrderDetailsViewModel> ModelDetails { get; set; }
        public BillingAddressViewModel ModelBillAddress { get; set; }
        public OtherDetailsViewModel ModelOtherDetails { get; set; }
        public List<TermViewModel> ModelTerms { get; set; }

        public ClsSalesOrder()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new SalesOrderMasterViewModel();
            ModelDetails = new List<SalesOrderDetailsViewModel>();
            ModelBillAddress = new BillingAddressViewModel();
            ModelOtherDetails = new OtherDetailsViewModel();
            ModelTerms = new List<TermViewModel>();
        }
        public string IsExistsVNumber(string VoucherNo)
        {
            DataTable dt = DAL.ExecuteDataset(CommandType.Text, "select VoucherNo from erp.SalesOrderMaster WHERE VoucherNo='" + VoucherNo.Trim() + "'").Tables[0];
			return dt.Rows.Count == 0 ? "" : dt.Rows[0]["VoucherNo"].ToString();
		}

		public string IsOrderUsedInChallan(string VoucherNo)
		{
			DataTable dt = DAL.ExecuteDataset(CommandType.Text, "select top 1 OrderNo from erp.SalesChallanDetails where OrderNo = '" + VoucherNo.Trim() + "'").Tables[0];
			return dt.Rows.Count == 0 ? "" : dt.Rows[0]["OrderNo"].ToString();
		}

		public string IsOrderUsedInSalesBill(string VoucherNo)
		{
			DataTable dt = DAL.ExecuteDataset(CommandType.Text, "select top 1 OrderNo from erp.SalesInvoiceDetails where OrderNo = '" + VoucherNo.Trim() + "'").Tables[0];
			return dt.Rows.Count == 0 ? "" : dt.Rows[0]["OrderNo"].ToString();
		}

		public DataSet GetDataOrderVoucher(string VoucherNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select SIM.*,GLDesc,GlCategory,SubledgerDesc,SalesmanDesc,D1.DepartmentDesc as DepartmentDesc1,D2.DepartmentDesc as DepartmentDesc2,D3.DepartmentDesc as DepartmentDesc3,D4.DepartmentDesc as DepartmentDesc4,  \n");
            strSql.Append("CurrencyDesc,BranchName,CU.CmpUnitName \n");
            strSql.Append("from erp.SalesOrderMaster SIM \n");
            strSql.Append("left Join erp.GeneralLedger GL on SIM.ledgerId = GL.LedgerID  \n");
            strSql.Append("left Join erp.Subledger SGL on SIM.SubledgerId = SGL.SubledgerId  \n");
            strSql.Append("left Join erp.Salesman SM on SIM.SalesmanId = SM.SalesmanId \n");
            strSql.Append("left Join erp.Department D1 on SIM.DepartmentId1 = D1.DepartmentID  \n");
            strSql.Append("left Join erp.Department D2  on SIM.DepartmentId2 = D2.DepartmentID  \n");
            strSql.Append("left Join erp.Department D3 on SIM.DepartmentId3 = D3.DepartmentID  \n");
            strSql.Append("left Join erp.Department D4 on SIM.DepartmentId4 = D4.DepartmentID  \n");
            strSql.Append("left Join erp.Currency CY on SIM.CurrencyId = CY.CurrencyId  \n");
            strSql.Append("left Join erp.Branch BR on SIM.BranchId = BR.BranchId  \n");
            strSql.Append("left Join erp.CompanyUnit CU on SIM.CompanyUnitId = CU.CompanyUnitId \n");
            if (!string.IsNullOrEmpty(VoucherNo))
                strSql.Append("where voucherNo='" + VoucherNo + "' \n");
            strSql.Append("Select [SID].*,ProductShortName, ProductDesc,ProductPrintingName,PD.AltConv,PAU.ProductUnitShortName as ProductAltUnitDesc,PU.ProductUnitShortName as ProductUnitDesc,GodownDesc,PD.IsTaxable from erp.SalesOrderDetails [SID] \n");
            strSql.Append("left join erp.Product PD on [SID].ProductId = PD.ProductId  \n");
            strSql.Append("left join erp.ProductUnit PU on[SID].ProductUnit = PU.ProductUnitId  \n");
            strSql.Append("left join erp.ProductUnit PAU on[SID].ProductAltUnit = PAU.ProductUnitId  \n");
            strSql.Append("left join erp.Godown GD on[SID].GodownId = GD.GodownId  \n");
            if (!string.IsNullOrEmpty(VoucherNo))
                strSql.Append("where voucherNo='" + VoucherNo + "' \n");
            strSql.Append("Select * from erp.SalesOrderTerm \n");
            if (!string.IsNullOrEmpty(VoucherNo))
                strSql.Append("where voucherNo='" + VoucherNo + "' \n");
            strSql.Append("select* from[ERP].[UDFDataEntry] where VoucherNo = '" + VoucherNo + "' and EntryModule = 'SO'\n");
            strSql.Append("Select * from ERP.SalesOrderOtherDetails where VoucherNo = '" + VoucherNo + "' \n");
            strSql.Append("Select * from ERP.SalesOrderBillingAddress where VoucherNo = '" + VoucherNo + "' \n");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

		public DataSet GetDataOrderForSales(string VoucherNo,string BillNo, string module)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("Select SIM.*,GLDesc,GlCategory,SubledgerDesc,SalesmanDesc, \n");
			strSql.Append("D1.DepartmentDesc as DepartmentDesc1, \n");
			strSql.Append("D2.DepartmentDesc as DepartmentDesc2, \n");
			strSql.Append("D3.DepartmentDesc as DepartmentDesc3, \n");
			strSql.Append("D4.DepartmentDesc as DepartmentDesc4, \n");
			strSql.Append("CurrencyDesc,BranchName,CU.CmpUnitName \n");
			strSql.Append("from erp.SalesOrderMaster SIM \n");
			strSql.Append("left Join erp.GeneralLedger GL on SIM.ledgerId = GL.LedgerID \n");
			strSql.Append("left Join erp.Subledger SGL on SIM.SubledgerId = SGL.SubledgerId \n");
			strSql.Append("left Join erp.Salesman SM on SIM.SalesmanId = SM.SalesmanId \n");
			strSql.Append("left Join erp.Department D1 on SIM.DepartmentId1 = D1.DepartmentID \n");
			strSql.Append("left Join erp.Department D2  on SIM.DepartmentId2 = D2.DepartmentID \n");
			strSql.Append("left Join erp.Department D3 on SIM.DepartmentId3 = D3.DepartmentID \n");
			strSql.Append("left Join erp.Department D4 on SIM.DepartmentId4 = D4.DepartmentID \n");
			strSql.Append("left Join erp.Currency CY on SIM.CurrencyId = CY.CurrencyId \n");
			strSql.Append("left Join erp.Branch BR on SIM.BranchId = BR.BranchId \n");
			strSql.Append("left Join erp.CompanyUnit CU on SIM.CompanyUnitId = CU.CompanyUnitId \n");
			strSql.Append("Where SIM.VoucherNo IN (SELECT Value FROM fn_Splitstring('"+ VoucherNo + "', ',')) \n\n");

			strSql.Append("BEGIN \n");
			if(module=="SC")
				strSql.Append("IF NOT EXISTS(select VoucherNo from erp.SalesChallanDetails where VoucherNo= '"+ BillNo + "' AND OrderNo = '" + VoucherNo + "') \n");
			else if(module=="SB")
				strSql.Append("IF NOT EXISTS(select VoucherNo from erp.SalesInvoiceDetails where VoucherNo= '" + BillNo + "' AND OrderNo = '" + VoucherNo + "') \n");

			strSql.Append("BEGIN \n");
			strSql.Append("Select SOD.VoucherNo,SOD.Sno,SOD.ProductId,ProductAltUnit,ProductUnit,G.GodownId, \n");
			strSql.Append("SOD.AltQty,SUM(SOD.Qty-isnull(CQty,0)-isnull(BQty,0)) as Qty,SOD.SalesRate,SOD.BasicAmount,SOD.TermAmount,SOD.NetAmount,SOD.LocalNetAmount ,SOD.AdditionalDesc,SOD.ConversionRatio,SOD.FreeQty,SOD.FreeQtyUnit, \n");
			strSql.Append("SOD.QuotationNo,SOD.QuotationSNo,ProductShortName, ProductDesc,ProductPrintingName,P.AltConv,PAU.ProductUnitShortName as ProductAltUnitDesc,PU.ProductUnitShortName as ProductUnitDesc,GodownDesc,P.IsTaxable \n");
			strSql.Append("FROM ERP.SalesOrderDetails as SOD \n");
			strSql.Append("Left Outer join( \n");
			strSql.Append("select OrderNo,OrderSNo, sum(Qty) as CQty from ERP.SalesChallanDetails where OrderNo is not Null  group by OrderNo,OrderSNo \n");
			strSql.Append(") as Challan on Challan.OrderNo=SOD.VoucherNo and Challan.OrderSNo=SOD.SNo \n");
			strSql.Append("Left Outer join \n");
			strSql.Append("( \n");
			strSql.Append("select OrderNo,OrderSNo, sum(Qty) as BQty from ERP.SalesInvoiceDetails where OrderNo is not Null group by OrderNo,OrderSNo \n");
			strSql.Append(") as Bill on Bill.OrderNo=SOD.VoucherNo and Bill.OrderSNo=SOD.SNo \n");
			strSql.Append("Left Outer join ERP.Product AS P on P.ProductId=SOD.ProductId \n");
			strSql.Append("Left Outer join ERP.Godown AS G on G.GodownId=SOD.GodownId \n");
			strSql.Append("left join erp.ProductUnit PU on[SOD].ProductUnit = PU.ProductUnitId \n");
			strSql.Append("left join erp.ProductUnit PAU on[SOD].ProductAltUnit = PAU.ProductUnitId \n");
			strSql.Append("where SOD.VoucherNo IN (SELECT Value FROM fn_Splitstring('" + VoucherNo + "', ',')) \n");
			strSql.Append("group by SOD.ProductId,ProductAltUnit,ProductUnit,SOD.VoucherNo,SOD.Sno,ProductDesc,G.GodownId,GodownDesc, \n");
			strSql.Append("SOD.AltQty,ProductAltUnitId,SOD.FreeQty, \n");
			strSql.Append("SOD.BasicAmount,SOD.NetAmount, SOD.LocalNetAmount ,SOD.SalesRate, \n");
			strSql.Append("SOD.AdditionalDesc,SOD.TermAmount,SOD.NetAmount,P.IsSerialWise,P.IsBatchwise,SOD.ConversionRatio, SOD.FreeQtyUnit, \n");
			strSql.Append("SOD.QuotationNo, \n");
			strSql.Append("SOD.QuotationSNo,ProductShortName,ProductPrintingName,P.AltConv,PU.ProductUnitShortName,PAU.ProductUnitShortName,P.IsTaxable \n");
			strSql.Append("Having Sum(SOD.Qty - IsNull(CQty, 0) - IsNull(BQty, 0)) > 0 \n");
			strSql.Append("Order by SOD.VoucherNo,SOD.Sno \n\n");

			strSql.Append("Select * from erp.SalesOrderTerm where voucherNo='" + VoucherNo + "' \n");
			strSql.Append("select* from[ERP].[UDFDataEntry] where VoucherNo = '" + VoucherNo + "' and EntryModule = 'SO' \n");
			strSql.Append("Select * from ERP.SalesOrderOtherDetails  where VoucherNo = '" + VoucherNo + "' \n");
			strSql.Append("Select * from ERP.SalesOrderBillingAddress  where VoucherNo = '" + VoucherNo + "' \n");

			strSql.Append("END\n");
			strSql.Append("ELSE\n");
			strSql.Append("BEGIN\n");
			strSql.Append("select VoucherNo,Sno,SOD.ProductId,ProductAltUnit,ProductUnit,SOD.GodownId,\n");
			strSql.Append("AltQty, Qty, SOD.SalesRate, BasicAmount, TermAmount, NetAmount, LocalNetAmount, AdditionalDesc, ConversionRatio, FreeQty, FreeQtyUnit,\n");
			strSql.Append("ProductShortName, ProductDesc, ProductPrintingName, P.AltConv, PAU.ProductUnitShortName as ProductAltUnitDesc, PU.ProductUnitShortName as ProductUnitDesc, GodownDesc, P.IsTaxable\n");
			if (module == "SC")
				strSql.Append(" from erp.SalesChallanDetails SOD\n");
			else if (module=="SB")
				strSql.Append(" from erp.SalesInvoiceDetails SOD\n");

			strSql.Append(" LEFT JOIN erp.Product P ON P.ProductId = SOD.ProductId\n");
			strSql.Append("Left Outer join ERP.Godown AS G on G.GodownId = SOD.GodownId\n");
			strSql.Append("left join erp.ProductUnit PU on SOD.ProductUnit = PU.ProductUnitId\n");
			strSql.Append("left join erp.ProductUnit PAU on SOD.ProductAltUnit = PAU.ProductUnitId where VoucherNo = '"+ BillNo +"'\n");

			if (module == "SC")
			{
				strSql.Append("Select * from erp.SalesChallanTerm where voucherNo='" + BillNo + "' \n");
				strSql.Append("select* from[ERP].[UDFDataEntry] where VoucherNo = '" + BillNo + "' and EntryModule = 'SC' \n");
				strSql.Append("Select * from ERP.SalesChallanOtherDetails  where VoucherNo = '" + BillNo + "' \n");
				strSql.Append("Select * from ERP.SalesChallanBillingAddress  where VoucherNo = '" + BillNo + "' \n");
			}
			else if (module == "SB")
			{
				strSql.Append("Select * from erp.SalesInvoiceTerm where voucherNo='" + BillNo + "' \n");
				strSql.Append("select* from[ERP].[UDFDataEntry] where VoucherNo = '" + BillNo + "' and EntryModule = 'SB' \n");
				strSql.Append("Select * from ERP.SalesInvoiceOtherDetails  where VoucherNo = '" + BillNo + "' \n");
				strSql.Append("Select * from ERP.SalesInvoiceBillingAddress  where VoucherNo = '" + BillNo + "' \n");
			}
			strSql.Append("END\n");
			strSql.Append("END\n");

		
			return DAL.ExecuteDataset(CommandType.Text, strSql.ToString());
		}

		public string SaveSalesOrder()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            strSql.Append("Set @VoucherNo ='" + Model.VoucherNo.Trim() + "' \n");

            if (Model.Tag == "NEW")
            {
                strSql.Append("INSERT INTO [ERP].[SalesOrderMaster]([VoucherNo],[VDate],[VTime],[VMiti],[ReferenceNo],[ReferenceDate],[ReferenceMiti],[LedgerId],[SubLedgerId],[SalesmanId],[DepartmentId1],[DepartmentId2],[DepartmentId3],[DepartmentId4],[CurrencyId],[CurrencyRate],[BranchId],[CompanyUnitId],[BasicAmount],[TermAmount],[NetAmount],[LocalNetAmount],[PartyName],[PartyVatNo],[PartyAddress],[PartyMobileNo],[ChequeNo],[ChequeDate],[ChequeMiti],[Remarks],[QuotationNo],[EnterBy],[EnterDate],[IsReconcile],[ReconcileBy],[ReconcileDate],[IsPosted],[PostedBy],[PostedDate],[IsAuthorized],[AuthorizedBy],[AuthorizedDate],[AuthorizeRemarks],[Gadget],[TableId],[ResIsCurrentOrder],[ResNoOfPacks],[CounterId],EntryFromProject,IsOrderCancel) \n");
                strSql.Append("Select @VoucherNo,'" + Model.VDate.ToString("yyyy-MM-dd") + "','" + Model.VDate.ToString("yyyy-MM-dd") + ' ' + DateTime.Now.ToShortTimeString() + "','" + Model.VMiti.ToString() + "', " + ((Model.ReferenceNo == "") ? "null" : "'" + Model.ReferenceNo + "'") + ", " + ((Model.ReferenceDate.ToString() == "") ? "null" : "'" + Model.ReferenceDate.ToString() + "'") + ", " + ((Model.ReferenceMiti.ToString() == "") ? "null" : "'" + Model.ReferenceMiti.ToString() + "'") + ", " + ((Model.LedgerId == 0) ? "null" : "'" + Model.LedgerId + "'") + "," + ((Model.SubLedgerId == 0) ? "null" : "'" + Model.SubLedgerId + "'") + "," + ((Model.SalesmanId == 0) ? "null" : "'" + Model.SalesmanId + "'") + "," + ((Model.DepartmentId1 == 0) ? "null" : "'" + Model.DepartmentId1 + "'") + ", " + ((Model.DepartmentId2 == 0) ? "null" : "'" + Model.DepartmentId2 + "'") + " ," + ((Model.DepartmentId3 == 0) ? "null" : "'" + Model.DepartmentId3 + "'") + ", " + ((Model.DepartmentId4 == 0) ? "null" : "'" + Model.DepartmentId4 + "'") + ", " + ((Model.CurrencyId == 0) ? "null" : "'" + Model.CurrencyId + "'") + ",'" + (Model.CurrencyRate == 0 ? 1 : Model.CurrencyRate) + "', " + ((Model.BranchId == 0) ? "null" : "'" + Model.BranchId + "'") + "," + ((Model.CompanyUnitId == 0) ? "null" : "'" + Model.CompanyUnitId + "'") + ", \n");
                strSql.Append("'" + Model.BasicAmount + "','" + Model.TermAmount + "', '" + Model.NetAmount + "' ,'"+Model.LocalNetAmount + "', \n");
                strSql.Append("" + (string.IsNullOrEmpty(Model.PartyName) ? "null" : "'" + Model.PartyName + "'") + ",  " + ((Model.PartyVatNo == "") ? "null" : "'" + Model.PartyVatNo + "'") + ",  " + ((Model.PartyAddress == "") ? "null" : "'" + Model.PartyAddress + "'") + ",  " + ((Model.PartyMobileNo == "") ? "null" : "'" + Model.PartyMobileNo + "'") + ",'" + Model.ChequeNo + "', " + ((Model.ChequeDate.ToString() == "") ? "null" : "'" + Model.ChequeDate.ToString() + "'") + ",  " + ((Model.ChequeMiti == "") ? "null" : "'" + Model.ChequeMiti + "'") + ",  \n");
                strSql.Append("" + ((Model.Remarks == "") ? "null" : "'" + Model.Remarks + "'") + ", " + ((Model.QuotationNo == "") ? "null" : "'" + Model.QuotationNo + "'") + ", " + ((Model.EnterBy == "") ? "null" : "'" + Model.EnterBy + "'") + ", GETDATE(), \n");
                strSql.Append(" '" + Model.IsReconcile + "'," + ((Model.ReconcileBy == "") ? "null" : "'" + Model.ReconcileBy + "'") + ",  " + ((Model.ReconcileDate.ToString() == "") ? "null" : "'" + Model.ReconcileDate.ToString() + "'") + ", '" + Model.IsPosted + "',  " + ((Model.PostedBy == "") ? "null" : "'" + Model.PostedBy + "'") + ",  " + ((Model.PostedDate.ToString() == "") ? "null" : "'" + Model.PostedDate.ToString() + "'") + ",'" + Model.IsAuthorized + "',  " + ((Model.AuthorizedBy == "") ? "null" : "'" + Model.AuthorizedBy + "'") + "," + ((Model.AuthorizedDate.ToString() == "") ? "null" : "'" + Model.AuthorizedDate.ToString() + "'") + ",  " + ((Model.AuthorizeRemarks == "") ? "null" : "'" + Model.AuthorizeRemarks + "'") + ", '" + Model.Gadget + "'," + ((Model.TableId == 0) ? "null" : "'" + Model.TableId + "'") + "," + ((Model.ResIsCurrentOrder == 0) ? "null" : "'" + Model.ResIsCurrentOrder + "'") + ",  " + ((Model.ResNoOfPacks == 0) ? "null" : "'" + Model.ResNoOfPacks + "'") + "," + ((Model.CounterId == 0) ? "Null" : "'" + Model.CounterId + "'") + " ,'" + Model.EntryFromProject + "','" + Model.IsOrderCancel + "'\n");
                strSql.Append("Update ERP.DocumentNumbering set DocCurrentNo = DocCurrentNo + 1 where DocId =" + Model.DocId + " \n");

                if (Model.EntryFromProject == "Restaurant")
                    strSql.Append("Update Erp.TableMaster set TableStatus='O' where TableID ='" + Model.TableId + "' \n");

                if (Model.EntryFromProject != "Restaurant")
                {
                    strSql.Append("INSERT INTO [ERP].[SalesOrderOtherDetails]([VoucherNo],[Transport],[VehicleNo],[Package],[CnNo],[CnDate],[CnFreight],[CnType]\n");
                    strSql.Append(",[Advance],[BalFreight],[DriverName],[DriverLicNo],[DriverMobileNo],[ContractNo],[ContractDate],[ExpInvNo],[ExpInvDate],[PoNo],[PoDate],[DocBank],[LcNo],[CustomName],[Cofd])\n");
                    strSql.Append("Select @VoucherNo," + (string.IsNullOrEmpty(ModelOtherDetails.Transport) ? "null" : "'" + ModelOtherDetails.Transport + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.VehicleNo) ? "null" : "'" + ModelOtherDetails.VehicleNo + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.Package) ? "null" : "'" + ModelOtherDetails.Package + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.CnNo) ? "null" : "'" + ModelOtherDetails.CnNo + "'") + "," + ((Convert.ToDateTime(ModelOtherDetails.CnDate).ToString() == "") ? "null" : "'" + Convert.ToDateTime(ModelOtherDetails.CnDate).ToString("yyyy-MM-dd") + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.CnFreight) ? "null" : "'" + ModelOtherDetails.CnFreight + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.CnType) ? "null" : "'" + ModelOtherDetails.CnType + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.Advance) ? "null" : "'" + ModelOtherDetails.Advance + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.BalFreight) ? "null" : "'" + ModelOtherDetails.BalFreight + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.DriverName) ? "null" : "'" + ModelOtherDetails.DriverName + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.DriverLicNo) ? "null" : "'" + ModelOtherDetails.DriverLicNo + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.DriverMobileNo) ? "null" : "'" + ModelOtherDetails.DriverMobileNo + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.ContractNo) ? "null" : "'" + ModelOtherDetails.ContractNo + "'") + "," + ((Convert.ToDateTime(ModelOtherDetails.ContractDate).ToString("yyyy-MM-dd") == null) ? "null" : "'" + Convert.ToDateTime(ModelOtherDetails.ContractDate).ToString("yyyy-MM-dd") + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.ExpInvNo) ? "null" : "'" + ModelOtherDetails.ExpInvNo + "'") + "," + ((Convert.ToDateTime(ModelOtherDetails.ExpInvDate).ToString("yyyy-MM-dd") == null) ? "null" : "'" + Convert.ToDateTime(ModelOtherDetails.ExpInvDate).ToString("yyyy-MM-dd") + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.PoNo) ? "null" : "'" + ModelOtherDetails.PoNo + "'") + "," + ((Convert.ToDateTime(ModelOtherDetails.PoDate).ToString("yyyy-MM-dd") == null) ? "null" : "'" + Convert.ToDateTime(ModelOtherDetails.PoDate).ToString("yyyy-MM-dd") + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.DocBank) ? "null" : "'" + ModelOtherDetails.DocBank + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.LcNo) ? "null" : "'" + ModelOtherDetails.LcNo + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.CustomName) ? "null" : "'" + ModelOtherDetails.CustomName + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.Cofd) ? "null" : "'" + ModelOtherDetails.Cofd + "'") + " \n");

                    strSql.Append("INSERT INTO[ERP].[SalesOrderBillingAddress] ([VoucherNo],[LedgerId],[BillingAddress],[BillingCity],[BillingState],[BillingCountry],[BillingEmail],[ShippingAddress],[ShippingCity],[ShippingState],[ShippingCountry],[ShippingEmail],[DeliveryDate],[Remarks])\n");
                    strSql.Append("Select @VoucherNo," + ((ModelBillAddress.LedgerId == 0) ? "null" : "'" + ModelBillAddress.LedgerId + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingAddress) ? "null" : "'" + ModelBillAddress.BillingAddress + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingCity) ? "null" : "'" + ModelBillAddress.BillingCity + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingState) ? "null" : "'" + ModelBillAddress.BillingState + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingCountry) ? "null" : "'" + ModelBillAddress.BillingCountry + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingEmail) ? "null" : "'" + ModelBillAddress.BillingEmail + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingAddress) ? "null" : "'" + ModelBillAddress.ShippingAddress + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingCity) ? "null" : "'" + ModelBillAddress.ShippingCity + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingState) ? "null" : "'" + ModelBillAddress.ShippingState + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingCountry) ? "null" : "'" + ModelBillAddress.ShippingCountry + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingEmail) ? "null" : "'" + ModelBillAddress.ShippingEmail + "'") + "," + ((ModelBillAddress.DeliveryDate.ToString() == "") ? "null" : "'" + ModelBillAddress.DeliveryDate.ToString() + "'") + ", " + (string.IsNullOrEmpty(ModelBillAddress.Remarks) ? "null" : "'" + ModelBillAddress.Remarks + "'") + " \n");
                }

            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP.SalesOrderMaster SET VDate='" + Model.VDate.ToString("yyyy-MM-dd") + "',VTime='" + Model.VDate.ToString("yyyy-MM-dd") + ' ' + DateTime.Now.ToShortTimeString() + "',VMiti='" + Model.VMiti.ToString() + "',ReferenceNo= " + ((Model.ReferenceNo == "") ? "null" : "'" + Model.ReferenceNo + "'") + ", ReferenceDate=" + ((Model.ReferenceDate.ToString() == "") ? "null" : "'" + Model.ReferenceDate.ToString() + "'") + ", ReferenceMiti= '" + Model.ReferenceMiti.ToString() + "',LedgerId= " + ((Model.LedgerId == 0) ? "null" : "'" + Model.LedgerId + "'") + ", \n");
                strSql.Append("SubLedgerId=" + ((Model.SubLedgerId == 0) ? "null" : "'" + Model.SubLedgerId + "'") + ",SalesmanId= " + ((Model.SalesmanId == 0) ? "null" : "'" + Model.SalesmanId + "'") + ", DepartmentId3=" + ((Model.DepartmentId3 == 0) ? "null" : "'" + Model.DepartmentId3 + "'") + ", DepartmentId4=" + ((Model.DepartmentId4 == 0) ? "null" : "'" + Model.DepartmentId4 + "'") + ", CurrencyId=" + ((Model.CurrencyId == 0) ? "null" : "'" + Model.CurrencyId + "'") + ",CurrencyRate='" + Model.CurrencyRate + "', BranchId= " + ((Model.BranchId == 0) ? "null" : "'" + Model.BranchId + "'") + ",CompanyUnitId=" + ((Model.CompanyUnitId == 0) ? "null" : "'" + Model.CompanyUnitId + "'") + ", \n");
                strSql.Append("BasicAmount='" + Model.BasicAmount + "',TermAmount='" + Model.TermAmount + "',NetAmount= '" + Model.NetAmount + "',LocalNetAmount='"+Model.LocalNetAmount + "', \n");
                strSql.Append("PartyName=" + ((Model.PartyName == "") ? "null" : "'" + Model.PartyName + "'") + ", PartyVatNo= " + ((Model.PartyVatNo == "") ? "null" : "'" + Model.PartyVatNo + "'") + ", PartyAddress= " + ((Model.PartyAddress == "") ? "null" : "'" + Model.PartyAddress + "'") + ", PartyMobileNo= " + ((Model.PartyMobileNo == "") ? "null" : "'" + Model.PartyMobileNo + "'") + ",ChequeNo='" + Model.ChequeNo + "',ChequeDate= " + ((Model.ChequeDate.ToString() == "") ? "null" : "'" + Model.ChequeDate.ToString() + "'") + ", ChequeMiti= " + ((Model.ChequeMiti == "") ? "null" : "'" + Model.ChequeMiti + "'") + ",  \n");
                strSql.Append("Remarks=" + ((Model.Remarks == "") ? "null" : "'" + Model.Remarks + "'") + ", QuotationNo=" + ((Model.QuotationNo == "") ? "null" : "'" + Model.QuotationNo + "'") + ",  EnterBy=" + ((Model.EnterBy == "") ? "null" : "'" + Model.EnterBy + "'") + ",EnterDate= GETDATE(), ReconcileBy= " + ((Model.ReconcileBy == "") ? "null" : "'" + Model.ReconcileBy + "'") + ",  ReconcileDate=" + ((Model.ReconcileDate.ToString() == "") ? "null" : "'" + Model.ReconcileDate.ToString() + "'") + ", IsPosted='" + Model.IsPosted + "', PostedBy= " + ((Model.PostedBy == "") ? "null" : "'" + Model.PostedBy + "'") + ",  PostedDate=" + ((Model.PostedDate.ToString() == "") ? "null" : "'" + Model.PostedDate.ToString() + "'") + ",IsAuthorized='" + Model.IsAuthorized + "', AuthorizedBy= " + ((Model.AuthorizedBy == "") ? "null" : "'" + Model.AuthorizedBy + "'") + ", \n");
                strSql.Append("AuthorizedDate= " + ((Model.AuthorizedDate.ToString() == "") ? "null" : "'" + Model.AuthorizedDate.ToString() + "'") + ", AuthorizeRemarks= " + ((Model.AuthorizeRemarks == "") ? "null" : "'" + Model.AuthorizeRemarks.Trim() + "'") + ", Gadget='" + Model.Gadget.Trim() + "' \n");
                strSql.Append("Where VoucherNo ='" + Model.VoucherNo + "' \n");
                if (Model.EntryFromProject != "Restaurant")
                {
                    strSql.Append("UPDATE [ERP].[SalesOrderOtherDetails] SET Transport = " + (string.IsNullOrEmpty(ModelOtherDetails.Transport) ? "null" : "'" + ModelOtherDetails.Transport + "'") + ",VehicleNo = " + (string.IsNullOrEmpty(ModelOtherDetails.VehicleNo) ? "null" : "'" + ModelOtherDetails.VehicleNo + "'") + ",Package = " + (string.IsNullOrEmpty(ModelOtherDetails.Package) ? "null" : "'" + ModelOtherDetails.Package + "'") + ",CnNo = " + (string.IsNullOrEmpty(ModelOtherDetails.CnNo) ? "null" : "'" + ModelOtherDetails.CnNo + "'") + ",CnDate = " + ((string.IsNullOrEmpty(ModelOtherDetails.CnDate.ToString())) ? "null" : "'" + ModelOtherDetails.CnDate.Value.ToString("yyyy-MM-dd") + "'") + ",CnFreight = " + (string.IsNullOrEmpty(ModelOtherDetails.CnFreight) ? "null" : "'" + ModelOtherDetails.CnFreight + "'") + ",CnType = " + (string.IsNullOrEmpty(ModelOtherDetails.CnType) ? "null" : "'" + ModelOtherDetails.CnType + "'") + ",Advance = " + (string.IsNullOrEmpty(ModelOtherDetails.Advance) ? "null" : "'" + ModelOtherDetails.Advance + "'") + ",BalFreight = " + (string.IsNullOrEmpty(ModelOtherDetails.BalFreight) ? "null" : "'" + ModelOtherDetails.BalFreight + "'") + ",DriverName = " + (string.IsNullOrEmpty(ModelOtherDetails.DriverName) ? "null" : "'" + ModelOtherDetails.DriverName + "'") + ",DriverLicNo = " + (string.IsNullOrEmpty(ModelOtherDetails.DriverLicNo) ? "null" : "'" + ModelOtherDetails.DriverLicNo + "'") + ",DriverMobileNo = " + (string.IsNullOrEmpty(ModelOtherDetails.DriverMobileNo) ? "null" : "'" + ModelOtherDetails.DriverMobileNo + "'") + ",ContractNo = " + (string.IsNullOrEmpty(ModelOtherDetails.ContractNo) ? "null" : "'" + ModelOtherDetails.ContractNo + "'") + ",ContractDate = " + ((string.IsNullOrEmpty(ModelOtherDetails.ContractDate.ToString())) ? "null" : "'" + ModelOtherDetails.ContractDate.Value.ToString("yyyy-MM-dd") + "'") + ",ExpInvNo = " + (string.IsNullOrEmpty(ModelOtherDetails.ExpInvNo) ? "null" : "'" + ModelOtherDetails.ExpInvNo + "'") + ",ExpInvDate = " + ((string.IsNullOrEmpty(ModelOtherDetails.ExpInvDate.ToString())) ? "null" : "'" + ModelOtherDetails.ExpInvDate.Value.ToString("yyyy-MM-dd") + "'") + ",PoNo = " + (string.IsNullOrEmpty(ModelOtherDetails.PoNo) ? "null" : "'" + ModelOtherDetails.PoNo + "'") + ",PoDate = " + ((string.IsNullOrEmpty(ModelOtherDetails.PoDate.ToString())) ? "null" : "'" + ModelOtherDetails.PoDate.Value.ToString("yyyy-MM-dd") + "'") + ",DocBank = " + (string.IsNullOrEmpty(ModelOtherDetails.DocBank) ? "null" : "'" + ModelOtherDetails.DocBank + "'") + ",LcNo = " + (string.IsNullOrEmpty(ModelOtherDetails.LcNo) ? "null" : "'" + ModelOtherDetails.LcNo + "'") + ",CustomName = " + (string.IsNullOrEmpty(ModelOtherDetails.CustomName) ? "null" : "'" + ModelOtherDetails.CustomName + "'") + ",Cofd = " + (string.IsNullOrEmpty(ModelOtherDetails.Cofd) ? "null" : "'" + ModelOtherDetails.Cofd + "'") + " Where VoucherNo = '" + Model.VoucherNo + "'\n");
                    strSql.Append("UPDATE[ERP].[SalesOrderBillingAddress] SET LedgerId =" + ((ModelBillAddress.LedgerId == 0) ? "null" : "'" + ModelBillAddress.LedgerId + "'") + ", [BillingAddress] =" + (string.IsNullOrEmpty(ModelBillAddress.BillingAddress) ? "null" : "'" + ModelBillAddress.BillingAddress + "'") + ",[BillingCity] = " + (string.IsNullOrEmpty(ModelBillAddress.BillingCity) ? "null" : "'" + ModelBillAddress.BillingCity + "'") + ",[BillingState] = " + (string.IsNullOrEmpty(ModelBillAddress.BillingState) ? "null" : "'" + ModelBillAddress.BillingState + "'") + ",[BillingCountry] = " + (string.IsNullOrEmpty(ModelBillAddress.BillingCountry) ? "null" : "'" + ModelBillAddress.BillingCountry + "'") + ",[BillingEmail] = " + (string.IsNullOrEmpty(ModelBillAddress.BillingEmail) ? "null" : "'" + ModelBillAddress.BillingEmail + "'") + ",ShippingAddress=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingAddress) ? "null" : "'" + ModelBillAddress.ShippingAddress + "'") + ",ShippingCity=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingCity) ? "null" : "'" + ModelBillAddress.ShippingCity + "'") + ",ShippingState=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingState) ? "null" : "'" + ModelBillAddress.ShippingState + "'") + ",ShippingCountry=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingCountry) ? "null" : "'" + ModelBillAddress.ShippingCountry + "'") + ",ShippingEmail=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingEmail) ? "null" : "'" + ModelBillAddress.ShippingEmail + "'") + ",DeliveryDate=" + ((ModelBillAddress.DeliveryDate.ToString() == "") ? "null" : "'" + ModelBillAddress.DeliveryDate.ToString() + "'") + ", Remarks=" + (string.IsNullOrEmpty(ModelBillAddress.Remarks) ? "null" : "'" + ModelBillAddress.Remarks + "'") + " Where VoucherNo = '" + Model.VoucherNo + "'\n");
                
                    strSql.Append("DELETE FROM [ERP].[SalesOrderDetails] WHERE VoucherNo =@VoucherNo \n");
                    strSql.Append("DELETE FROM [ERP].[SalesOrderTerm] WHERE  VoucherNo =@VoucherNo \n");
                }
            }
            else if (Model.Tag == "DELETE")
            {
                strSql.Append("DELETE FROM [ERP].[SalesOrderTerm] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
                strSql.Append("DELETE FROM [ERP].[SalesOrderDetails] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
                strSql.Append("DELETE FROM [ERP].[SalesOrderBillingAddress] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
                strSql.Append("DELETE FROM [ERP].[SalesOrderOtherDetails] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
                strSql.Append("DELETE FROM [ERP].[SalesOrderMaster] WHERE VoucherNo = '" + Model.VoucherNo + "' \n");
                strSql.Append("SET @VoucherNo ='1'");
                ModelTerms.Clear();
                ModelDetails.Clear();
            }

            if (Model.Tag != "TERMEDIT")
            {               
                foreach (SalesOrderDetailsViewModel det in ModelDetails)
                {
                    strSql.Append("INSERT INTO [ERP].[SalesOrderDetails]([VoucherNo],[Sno],[ProductId],[ProductAltUnit],[ProductUnit],[GodownId],[AltQty],[Qty],\n");
                    strSql.Append("[SalesRate],[BasicAmount],[TermAmount],[NetAmount],[LocalNetAmount],[AdditionalDesc],[ConversionRatio],[FreeQty],[FreeQtyUnit],[QuotationNo],[QuotationSNo],\n");
                    strSql.Append("[ResOrderBy],[ResOrderTime],[ResOrderNotes],[ResIsPrinted],[ResIsFirePrinter],[ResKOTNo],[TermDetails]) \n");
                    strSql.Append("Select @VoucherNo, '" + det.Sno + "', '" + det.ProductId + "'," + ((det.ProductAltUnit == 0) ? "null" : "'" + det.ProductAltUnit + "'") + ", " + ((det.ProductUnit == 0) ? "null" : "'" + det.ProductUnit + "'") + ", " + ((det.GodownId == 0) ? "null" : "'" + det.GodownId + "'") + ",'" + det.AltQty + "', '" + det.Qty + "',\n");
                    strSql.Append(" '" + det.SalesRate + "', '" + det.BasicAmount + "', '" + det.TermAmount + "', '" + det.NetAmount + "', '" + det.LocalNetAmount + "', '" + det.AdditionalDesc + "', '" + det.ConversionRatio + "' ,'" + det.FreeQty + "',  " + ((det.FreeQtyUnit == 0) ? "null" : "'" + det.FreeQtyUnit + "'") + ",  " + ((det.QuotationNo == "") ? "null" : "'" + det.QuotationNo + "'") + ",  " + ((det.QuotationSNo == 0) ? "null" : "'" + det.QuotationSNo + "'") + ",\n");
                    strSql.Append(" " + ((det.ResOrderBy == "") ? "Null" : "'" + det.ResOrderBy + "'") + "," + ((det.ResOrderTime == null) ? "Null" : "'" + Convert.ToDateTime(det.ResOrderTime).ToString("yyyy-MM-dd hh:mm:ss tt") + "'") + "," + ((det.ResOrderNotes == "") ? "Null" : "'" + det.ResOrderNotes + "'") + "," + ((det.ResIsPrinted == 0) ? "0" : "'" + det.ResIsPrinted + "'") + "," + ((det.ResIsFirePrinter == 0) ? "0" : "'" + det.ResIsFirePrinter + "'") + "," + ((det.ResKOTNo == "") ? "Null" : "'" + det.ResKOTNo + "'") + " ," + ((det.TermDetails == "") ? "Null" : "'" + det.TermDetails + "'") + " \n");
                }
            }

            if (Model.EntryFromProject == "Restaurant" && Model.Tag != "NEW")
                strSql.Append(" Delete from  [ERP].[SalesOrderTerm] where VoucherNo=@VoucherNo and TermType in ('B','BT') \n");
            foreach (TermViewModel det in ModelTerms)
            {
                strSql.Append("INSERT INTO [ERP].[SalesOrderTerm]([VoucherNo],[Sno],[ProductId],[TermId],[TermType],[STSign],[TermRate],[TermAmt],[LocalTermAmt]) \n");
                strSql.Append("Select @VoucherNo, '" + det.Sno + "', " + ((det.ProductId == 0) ? "Null" : "'" + det.ProductId + "'") + ", '" + det.TermId + "', '" + det.TermType + "', '" + det.STSign + "', '" + det.TermRate + "', '" + det.TermAmt + "', '" + det.LocalTermAmt + "' \n");
            }
            if (Model.EntryFromProject == "Normal")
            {
                if (Model.UdfDetails.Rows.Count > 0)
                {
                    strSql.Append("DELETE FROM ERP.UDFDataEntry WHERE VoucherNo=@VoucherNo AND EntryModule='SO' AND SNO<>0 \n");
                    int _s = 0;
                    foreach (DataRow ro in Model.UdfDetails.Rows)
                    {
                        int j = 1;
                        for (int i = 0; i < (Model.UdfDetails.Columns.Count - 1) / 2; i++)
                        {
                            strSql.Append("INSERT INTO ERP.UDFDataEntry(VoucherNo,EntryModule,SNO,UDFCode,UDFData,ProductId) \n");
                            strSql.Append("Select @VoucherNo,'SO','" + ro[0].ToString() + "', ");
                            strSql.Append("'" + ro[j].ToString() + "' ");
                            j++;
                            strSql.Append("," + (string.IsNullOrEmpty(ro[j].ToString()) ? "null" : "'" + ro[j].ToString() + "'") + "");
                            j++;
                            strSql.Append(",'" + ModelDetails[_s].ProductId.ToString() + "' \n");
                        }
                        _s++;
                    }
                    Model.UdfDetails.Rows.Clear();
                }

                if (Model.UdfMaster.Rows.Count > 0)
                {
                    strSql.Append("DELETE FROM ERP.UDFDataEntry WHERE VoucherNo=@VoucherNo AND EntryModule='SO' AND SNO=0 \n");
                    foreach (DataRow ro in Model.UdfMaster.Rows)
                    {
                        int j = 1;
                        for (int i = 0; i < (Model.UdfMaster.Columns.Count - 1) / 2; i++)
                        {
                            strSql.Append("INSERT INTO ERP.UDFDataEntry(VoucherNo,EntryModule,SNO,UDFCode,UDFData,ProductId) \n");
                            strSql.Append("Select @VoucherNo,'SO','0','" + ro[j].ToString() + "',");
                            j++;
                            strSql.Append("" + (string.IsNullOrEmpty(ro[j].ToString()) ? "null" : "'" + ro[j].ToString() + "'") + ",NULL \n");
                            j++;
                        }
                    }
                    Model.UdfMaster.Rows.Clear();
                }
            }

            //BT Posting

            strSql.Append("insert into erp.SalesOrderTerm(VoucherNo, TermId, Sno, ProductId, TermType, STSign, TermRate, TermAmt, LocalTermAmt) \n");
            strSql.Append("(Select @VoucherNo as VoucherNo, TermId as TermId, Sno, SBD1.ProductId, 'BT' as TermType, STSign, TermRate \n");
            strSql.Append(", isnull(abs(sum((Amt * SBD1.Bamt1) / Bamt)), 0) as TermAmt1, 0 as LocalTermAmt from erp.SalesOrderMaster as sm, \n");
            strSql.Append("(Select Sno, SD.ProductId, SD.VoucherNo, sum(Case When SD.NetAmount <> 0 then SD.NetAmount else SD.BasicAmount end) as Bamt1 from erp.SalesOrderDetails as SD, erp.SalesOrderMaster as SM  where SD.VoucherNo = SM.VoucherNo \n");
            strSql.Append("group by SD.ProductId, SD.VoucherNo, Sno) as SBD1, (select SD.VoucherNo, CASE WHEN  sum(Case when SD.NetAmount <> 0 then SD.NetAmount * CurrencyRate else SD.BasicAmount * CurrencyRate end) = 0 THEN 1 ELSE sum(Case when SD.NetAmount<>0 then SD.NetAmount* CurrencyRate else SD.BasicAmount* CurrencyRate end ) END as Bamt from erp.SalesOrderDetails as SD,erp.SalesOrderMaster as SM  where SD.VoucherNo = SM.VoucherNo group by SD.VoucherNo) as Sbd, \n");
            strSql.Append("(Select SD.VoucherNo,SD.TermId,SD.TermRate,sum((case when STM.STSign = '+' then(SD.TermAmt * CurrencyRate) else -(SD.TermAmt * CurrencyRate) end)) as Amt,Stm.STSign from erp.SalesOrderTerm as SD, erp.SalesOrderMaster as Sm,erp.SalesBillingTerm as Stm \n");
            strSql.Append("where SD.VoucherNo = SM.VoucherNo and SD.TermId = STM.TermId and ProductId is Null and Basis <> 'Q' and Exists(Select* from erp.SalesOrderDetails as SBD where SD.VoucherNo = SBD.VoucherNo group by ProductId) and SD.VoucherNo = @VoucherNo \n");
            strSql.Append("group by SD.VoucherNo,SD.TermId,SD.TermRate,STM.STSign) as Trm where sm.VoucherNo = SBD1.VoucherNo and sm.VoucherNo = Trm.VoucherNo And Sbd.VoucherNo = Trm.VoucherNo  group by SBD1.ProductId,TermId,TermRate,Sno,Trm.STSign \n");
            strSql.Append("Union All \n");
            strSql.Append("Select @VoucherNo as VoucherNo,TermId as TermId,Sno,Sbd.ProductId,'BT' as TermType,Trm.STSign ,TermRate,isnull(abs(sum(Case when TotQty <> 0 then(Amt / TotQty) * Bamt end)), 0) as TermAmt1,0 as LocalTermAmt \n");
            strSql.Append("from erp.SalesOrderMaster as Sm,(Select VoucherNo, Sum(Qty) as TotQty from erp.SalesOrderDetails group by VoucherNo) as SD, \n");
            strSql.Append("(select Sno, ProductId, VoucherNo, sum(Qty) as Bamt from erp.SalesOrderDetails group by VoucherNo,ProductId,Sno) as Sbd, \n");
            strSql.Append("(Select SD.VoucherNo,SD.TermId,SD.TermRate,sum((case when STM.STSign = '+' then(SD.TermAmt * CurrencyRate) else -(SD.TermAmt * CurrencyRate) end)) as Amt,Stm.STSign \n");
            strSql.Append("from erp.SalesOrderTerm as SD,erp.SalesOrderMaster as Sm,erp.SalesBillingTerm as Stm where SD.VoucherNo = SM.VoucherNo and SD.TermId = STM.TermId and ProductId is Null and Basis = 'Q' \n");
            strSql.Append("and Exists(Select* from erp.SalesOrderDetails as SBD where SD.VoucherNo = SBD.VoucherNo group by ProductId) and SD.VoucherNo = @VoucherNo group by SD.VoucherNo,SD.TermId,SD.TermRate,STm.STSign) as Trm \n");
            strSql.Append("Where SM.VoucherNo = Trm.VoucherNo And Sbd.VoucherNo = Trm.VoucherNo and sm.VoucherNo = SD.VoucherNo \n");
            strSql.Append("group by Sbd.ProductId,TermId,TermRate,Sno,Trm.STSign) \n");

            strSql.Append("Update erp.SalesOrderTerm set LocalTermAmt = TermAmt * CurrencyRate from erp.SalesOrderMaster where erp.SalesOrderTerm.VoucherNo = erp.SalesOrderMaster.VoucherNo and erp.SalesOrderMaster.VoucherNo = @VoucherNo \n");

            if (Model.EntryFromProject == "Restaurant")
            {
                strSql.Append(" Update erp.SalesOrderMaster set TermAmount = (Select sum(isnull( case when STSign = '+' then TermAmt else -TermAmt end, 0)) from erp.salesorderterm where TermType = 'B' and voucherno = @VoucherNo)where erp.SalesOrderMaster.VoucherNo = @VoucherNo \n");
                strSql.Append(" Update erp.SalesOrderMaster set BasicAmount = (Select Sum(NetAmount) from Erp.SalesOrderDetails where voucherno = @VoucherNo) where voucherno = @VoucherNo \n");
                strSql.Append(" Update erp.SalesOrderMaster Set NetAmount = (BasicAmount + TermAmount) where VoucherNo = @VoucherNo \n");
                strSql.Append(" Update erp.SalesOrderMaster Set SalesmanId = " + ((Model.SalesmanId == 0) ? "null" : "'" + Model.SalesmanId + "'") + "  where VoucherNo = @VoucherNo \n");
            }

            ModelDetails.Clear();
            ModelTerms.Clear();
            strSql.Append("\n COMMIT TRANSACTION \n");
            strSql.Append("END TRY \n");
            strSql.Append("BEGIN CATCH \n");
            strSql.Append("ROLLBACK TRANSACTION \n");
            strSql.Append("Set @VoucherNo = '' \n");
            strSql.Append("END CATCH \n");

            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@VoucherNo", SqlDbType.VarChar, 25) { Direction = ParameterDirection.Output };
            DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString(), p);
            return p[0].Value.ToString();
        }

        public string GetOrderVoucherNo(int tableId)
        {
            DataTable dt = DAL.ExecuteDataset(CommandType.Text, "select VoucherNo from erp.SalesOrderMaster WHERE tableId='" + tableId + "' and ResIsCurrentOrder='Y' ").Tables[0];
            if (dt.Rows.Count == 0)
                return "";
            else
                return dt.Rows[0]["VoucherNo"].ToString();
        }

        public void DeleteOrderDetails(string voucherNo, string canceltype = "", string Sno = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");

            if (!string.IsNullOrEmpty(canceltype))
            {
                strSql.Append("Declare @OrderDetails int \n");
                strSql.Append("Declare @SNo int \n");
                strSql.Append("IF not EXISTS(SELECT OrderNo FROM ERP.SalesOrderCancelMaster WHERE OrderNo = '" + voucherNo + "') \n");
                strSql.Append("BEGIN  \n");
                strSql.Append("declare @VoucherNo int= (select ISNULL((Select Top 1 max(cast(VoucherNo as int))  from ERP.SalesOrderCancelMaster),0)+1) \n");
                strSql.Append("   Insert into [ERP].[SalesOrderCancelMaster](VoucherNo, VDate, VTime, VMiti,OrderNo, LedgerId, SubLedgerId, SalesmanId, DepartmentId1, DepartmentId2, DepartmentId3, DepartmentId4, CurrencyId, CurrencyRate, BranchId, CompanyUnitId, BasicAmount, TermAmount, NetAmount, PartyName, PartyVatNo, PartyAddress, PartyMobileNo, ChequeNo, ChequeDate, ChequeMiti, Remarks, QuotationNo, EnterBy, EnterDate, IsReconcile, ReconcileBy, ReconcileDate, IsPosted, PostedBy, PostedDate, IsAuthorized, AuthorizedBy, AuthorizedDate, AuthorizeRemarks, Gadget, TableId, ResNoOfPacks, CounterId, EntryFromProject)  \n");
                strSql.Append("   Select @VoucherNo , GetDate(), GetDate(), VMiti,VoucherNo, LedgerId, SubLedgerId, SalesmanId, DepartmentId1, DepartmentId2, DepartmentId3, DepartmentId4, CurrencyId, CurrencyRate, BranchId, CompanyUnitId, BasicAmount, TermAmount, NetAmount, PartyName, PartyVatNo, PartyAddress, PartyMobileNo, ChequeNo, ChequeDate, ChequeMiti, Remarks, QuotationNo, EnterBy, EnterDate, IsReconcile, ReconcileBy, ReconcileDate, IsPosted, PostedBy, PostedDate, IsAuthorized, AuthorizedBy, AuthorizedDate, AuthorizeRemarks, Gadget, TableId, ResNoOfPacks, CounterId, EntryFromProject from ERP.SalesOrderMaster where  VoucherNo ='" + voucherNo + "'  \n");
                strSql.Append("		DECLARE db_cursor CURSOR FOR \n");
                strSql.Append("		SELECT sno  FROM ERP.SalesOrderDetails  where voucherNo  = '" + voucherNo + "' \n");
                if (canceltype == "PartialCancel")
                    strSql.Append(" and Sno = '" + Sno + "' \n");
                strSql.Append("		OPEN db_cursor \n");
                strSql.Append("		FETCH NEXT FROM db_cursor INTO @OrderDetails   \n");
                strSql.Append("		WHILE @@FETCH_STATUS = 0  \n");
                strSql.Append("		BEGIN  \n");
                strSql.Append("		 Set @SNo=(Select distinct  (select ISNULL((Select Top 1 max(sno)  from ERP.SalesOrderCanceldetails where VoucherNo =(SELECT VoucherNo FROM ERP.SalesOrderCancelMaster WHERE OrderNo = '" + voucherNo + "')),0)+1) from ERP.[SalesOrderCancelMaster] where VoucherNo =(SELECT VoucherNo FROM ERP.SalesOrderCancelMaster WHERE OrderNo = '" + voucherNo + "'))\n");
                strSql.Append("			  insert into [ERP].[SalesOrderCancelDetails] (VoucherNo, Sno,ProductId, ProductAltUnit, ProductUnit, GodownId, AltQty, Qty, SalesRate, BasicAmount, TermAmount, NetAmount, LocalNetAmount, AdditionalDesc, ConversionRatio, FreeQty, FreeQtyUnit, QuotationNo, QuotationSNo, ResOrderBy, ResOrderTime, ResOrderNotes, ResIsPrinted, ResIsFirePrinter, ResKOTNo, TermDetails, OrderCancelOrItem)  \n");
                strSql.Append("			  Select top 1 @VoucherNo , @SNo,ProductId, ProductAltUnit, ProductUnit, GodownId, AltQty, Qty, SalesRate, BasicAmount, TermAmount, NetAmount, LocalNetAmount, AdditionalDesc, ConversionRatio, FreeQty, FreeQtyUnit, QuotationNo, QuotationSNo, ResOrderBy, ResOrderTime, ResOrderNotes, ResIsPrinted, ResIsFirePrinter, ResKOTNo, TermDetails, '" + canceltype + "' from[ERP].[SalesOrderDetails] where VoucherNo = '" + voucherNo + "' \n");
                if (canceltype == "PartialCancel")
                    strSql.Append(" and Sno = '" + Sno + "' \n");
                strSql.Append("	Delete from erp.SalesOrderDetails where  VoucherNo='" + voucherNo + "' and  sno  in (Select Top 1  sno from erp.SalesOrderDetails \n");
                if (canceltype == "PartialCancel")
                    strSql.Append(" Where Sno = '" + Sno + "' \n");
                strSql.Append(" order by sno) \n");
                strSql.Append("			  FETCH NEXT FROM db_cursor INTO @OrderDetails \n");
                strSql.Append("		END  \n");
                strSql.Append("		CLOSE db_cursor  \n");
                strSql.Append("		DEALLOCATE db_cursor \n");
                strSql.Append("		END \n");
                strSql.Append("ELSE \n");
                strSql.Append("BEGIN \n");
                strSql.Append("		DECLARE db_cursor CURSOR FOR \n");
                strSql.Append("		SELECT sno FROM ERP.SalesOrderDetails  where voucherNo = '" + voucherNo + "' \n");
                if (canceltype == "PartialCancel")
                    strSql.Append(" and Sno = '" + Sno + "' \n");
                strSql.Append("		OPEN db_cursor  \n");
                strSql.Append("		FETCH NEXT FROM db_cursor INTO @OrderDetails  \n");
                strSql.Append("		WHILE @@FETCH_STATUS = 0  \n");
                strSql.Append("		BEGIN  \n");
                strSql.Append("		    Set @VoucherNo=(Select VoucherNo from ERP.SalesOrderCancelMaster where OrderNo = '" + voucherNo + "')  \n");
                strSql.Append("		    Set @SNo=(Select distinct  (select ISNULL((Select Top 1 max(sno)  from ERP.SalesOrderCanceldetails where VoucherNo =(SELECT VoucherNo FROM ERP.SalesOrderCancelMaster WHERE OrderNo = '" + voucherNo + "')),0)+1) from ERP.[SalesOrderCancelMaster] where VoucherNo =(SELECT VoucherNo FROM ERP.SalesOrderCancelMaster WHERE OrderNo = '" + voucherNo + "')) \n");
                strSql.Append("			  insert into [ERP].[SalesOrderCancelDetails] (VoucherNo, Sno,ProductId, ProductAltUnit, ProductUnit, GodownId, AltQty, Qty, SalesRate, BasicAmount, TermAmount, NetAmount, LocalNetAmount, AdditionalDesc, ConversionRatio, FreeQty, FreeQtyUnit, QuotationNo, QuotationSNo, ResOrderBy, ResOrderTime, ResOrderNotes, ResIsPrinted, ResIsFirePrinter, ResKOTNo, TermDetails, OrderCancelOrItem)  \n");
                strSql.Append("			  Select  top 1 @VoucherNo , @SNo, ProductId, ProductAltUnit, ProductUnit, GodownId, AltQty, Qty, SalesRate, BasicAmount, TermAmount, NetAmount, LocalNetAmount, AdditionalDesc, ConversionRatio, FreeQty, FreeQtyUnit, QuotationNo, QuotationSNo, ResOrderBy, ResOrderTime, ResOrderNotes, ResIsPrinted, ResIsFirePrinter, ResKOTNo, TermDetails, '" + canceltype + "' from[ERP].[SalesOrderDetails] where VoucherNo = '" + voucherNo + "' \n");
                if (canceltype == "PartialCancel")
                    strSql.Append(" and Sno = '" + Sno + "' \n");

                strSql.Append("	Delete from erp.SalesOrderDetails where  VoucherNo='" + voucherNo + "' and sno  in (Select Top 1  sno from erp.SalesOrderDetails \n");
                  if (canceltype == "PartialCancel")
                    strSql.Append(" Where Sno = '" + Sno + "' \n");
                strSql.Append(" order by sno) \n");
                strSql.Append("			  FETCH NEXT FROM db_cursor INTO @OrderDetails \n");
                strSql.Append("		END \n");
                strSql.Append("		CLOSE db_cursor  \n");
                strSql.Append("		DEALLOCATE db_cursor  \n");
                strSql.Append("END \n");

            }
            if ((string.IsNullOrEmpty(Sno) && string.IsNullOrEmpty(canceltype)) || (!string.IsNullOrEmpty(Sno) && canceltype == "PartialCancel"))
            {
                strSql.Append("Delete from [ERP].[SalesOrderDetails] where VoucherNo='" + voucherNo + "' \n");
                strSql.Append("Delete from [ERP].[SalesOrderTerm] where VoucherNo='" + voucherNo + "' \n");
            }
            else if (canceltype != "PartialCancel")
            {
                strSql.Append("Delete from [ERP].[SalesOrderDetails] where VoucherNo='" + voucherNo + "' \n");
                strSql.Append("Delete from [ERP].[SalesOrderTerm] where VoucherNo='" + voucherNo + "' \n");
                //strSql.Append("Delete from [ERP].[SalesOrderMaster] where VoucherNo='" + voucherNo + "' \n");
            }
            strSql.Append("\n COMMIT TRANSACTION \n");
            strSql.Append("END TRY \n");
            strSql.Append("BEGIN CATCH \n");
            strSql.Append("ROLLBACK TRANSACTION \n");
            //strSql.Append("Set @VoucherNo = '' \n");
            strSql.Append("END CATCH \n");
            DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        public void UpdateOrderOnBillTermChange(string voucherNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete from [ERP].[SalesOrderTerm] where VoucherNo='" + voucherNo + "' and TermType in ('B','BT')  \n");
            DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        public void CancelOrder(string voucherNo, int tableId, string remarks = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update  [ERP].[SalesOrderMaster] set IsOrderCancel=1 , ResIsCurrentOrder='N' , Remarks='" + remarks + "' where VoucherNo='" + voucherNo + "' \n");
            strSql.Append(" Update Erp.TableMaster Set TableStatus='A' where TableId='" + tableId + "' \n");
            DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        public void UpdateTransferTable(string voucherNo, int tableId, int transferTableId, string remarks = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update  [ERP].[SalesOrderMaster] set TableId=" + transferTableId + " , Remarks='" + remarks + "' where VoucherNo='" + voucherNo + "' \n");
            strSql.Append(" Update Erp.TableMaster Set TableStatus='A' where TableId='" + tableId + "' \n");
            strSql.Append(" Update Erp.TableMaster Set TableStatus='O' where TableId='" + transferTableId + "' \n");
            DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }
    }

    public class SalesOrderMasterViewModel
    {
        public string Tag { get; set; }
        public int DocId { get; set; }
        public string VoucherNo { get; set; }
        public DateTime VDate { get; set; }
        public DateTime VTime { get; set; }
        public string VMiti { get; set; }
        public string ReferenceNo { get; set; }
        public Nullable<DateTime> ReferenceDate { get; set; }
        public string ReferenceMiti { get; set; }
        public int LedgerId { get; set; }
        public int SubLedgerId { get; set; }
        public int SalesmanId { get; set; }
        public int DepartmentId1 { get; set; }
        public int DepartmentId2 { get; set; }
        public int DepartmentId3 { get; set; }
        public int DepartmentId4 { get; set; }
        public int CurrencyId { get; set; }
        public decimal CurrencyRate { get; set; }
        public int BranchId { get; set; }
        public int CompanyUnitId { get; set; }
        public decimal BasicAmount { get; set; }
        public decimal TermAmount { get; set; }
        public decimal NetAmount { get; set; }
        public Decimal LocalNetAmount { get; set; }
        public decimal TenderAmount { get; set; }
        public decimal ReturnAmount { get; set; }
        public string PartyName { get; set; }
        public string PartyVatNo { get; set; }
        public string PartyAddress { get; set; }
        public string PartyMobileNo { get; set; }
		public string PartyEmail { get; set; }
		
		public string ChequeNo { get; set; }
        public Nullable<DateTime> ChequeDate { get; set; }
        public string ChequeMiti { get; set; }
        public string PaymentType { get; set; }
        public string Remarks { get; set; }
        public string QuotationNo { get; set; }
        public string OrderNo { get; set; }
        public string ChallanNo { get; set; }
        public DataTable UdfDetails { get; set; }
        public DataTable UdfMaster { get; set; }
        public string EnterBy { get; set; }
        public DateTime EnterDate { get; set; }
        public int PrintCopy { get; set; }
        public int IsReconcile { get; set; }
        public string ReconcileBy { get; set; }
        public Nullable<DateTime> ReconcileDate { get; set; }
        public int IsPosted { get; set; }
        public string PostedBy { get; set; }
        public Nullable<DateTime> PostedDate { get; set; }
        public int IsAuthorized { get; set; }
        public string AuthorizedBy { get; set; }
        public Nullable<DateTime> AuthorizedDate { get; set; }
        public string AuthorizeRemarks { get; set; }
        public string Gadget { get; set; }
        public string EntryFromProject { get; set; }
        //------ RESTAURANT --------
        public int TableId { get; set; }
        public char ResIsCurrentOrder { get; set; }
        public int ResNoOfPacks { get; set; }
        public int CounterId { get; set; }
        public int IsOrderCancel { get; set; }
    }

    public class SalesOrderDetailsViewModel
    {
        public string VoucherNo { get; set; }
        public int Sno { get; set; }
        public int ProductId { get; set; }
        public int ProductAltUnit { get; set; }
        public int ProductUnit { get; set; }
        public int GodownId { get; set; }
        public decimal AltQty { get; set; }
        public decimal Qty { get; set; }
        public decimal SalesRate { get; set; }
        public decimal BasicAmount { get; set; }
        public decimal TermAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal LocalNetAmount { get; set; }

        public string AdditionalDesc { get; set; }
        public decimal ConversionRatio { get; set; }
        public decimal FreeQty { get; set; }
        public int FreeQtyUnit { get; set; }
        public string QuotationNo { get; set; }
        public int QuotationSNo { get; set; }
        //------ RESTAURANT --------
        public string ResOrderBy { get; set; }
        public Nullable<DateTime> ResOrderTime { get; set; }
        public string ResOrderNotes { get; set; }
        public char ResIsPrinted { get; set; }
        public char ResIsFirePrinter { get; set; }
        public string ResKOTNo { get; set; }
        public string TermDetails { get; set; }
    }
}
