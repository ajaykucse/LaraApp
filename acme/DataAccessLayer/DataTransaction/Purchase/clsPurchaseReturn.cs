using DataAccessLayer.DataTransaction.Sales;
using DataAccessLayer.Interface.DataTransaction.Purchase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessLayer.DataTransaction.Purchase.ClsPurchaseInvoice;

namespace DataAccessLayer.DataTransaction.Purchase
{
	public class clsPurchaseReturn: IPurchaseReturn
	{
		ActiveDataAccess.ActiveDataAccess DAL;
		public PurchaseInvoiceReturnMasterViewModel Model { get; set; }
		public List<PurchaseInvoiceReturnDetailsViewModel> ModelDetails { get; set; }
		public List<TermViewModel> ModelTerms { get; set; }
		public PartyInfoViewModel ModelPartyInfo { get; set; }
		public BillingAddressViewModel ModelBillAddress { get; set; }
		public OtherDetailsViewModel ModelOtherDetails { get; set; }

		public clsPurchaseReturn() 
		{
			DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
			Model = new PurchaseInvoiceReturnMasterViewModel();
			ModelDetails = new List<PurchaseInvoiceReturnDetailsViewModel>();
			ModelTerms = new List<TermViewModel>();
			ModelPartyInfo = new PartyInfoViewModel();
			ModelBillAddress = new BillingAddressViewModel();
			ModelOtherDetails = new OtherDetailsViewModel();
		}

		public string SavePurchaseReturn()
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("BEGIN TRANSACTION \n");
			strSql.Append("BEGIN TRY \n");
			strSql.Append("Set @VoucherNo ='" + Model.VoucherNo.Trim() + "' \n");
			if (Model.Tag == "NEW")
			{
				strSql.Append("INSERT INTO ERP.PurchaseInvoiceReturnMaster([VoucherNo], [VDate], [VTime], [VMiti], [ReferenceNo], [ReferenceDate], \n");
				strSql.Append(" [ReferenceMiti], [DueDay], [DueDate], [DueMiti], [LedgerId], [SubLedgerId], [SalesmanId], [DepartmentId1], [DepartmentId2], \n");
				strSql.Append(" [DepartmentId3], [DepartmentId4], [CurrencyId], [CurrencyRate], [BranchId], [CompanyUnitId], [BasicAmount], [TermAmount],  \n");
				strSql.Append("[NetAmount],[LocalNetAmount], [TaxableAmount], [TaxFreeAmount], [VatAmount], [PartyName], [PartyVatNo], [PartyAddress], [PartyMobileNo],PartyEmail, \n");
				strSql.Append(" [ChequeNo], [ChequeDate], [ChequeMiti], [PaymentType], [Remarks], [QuotationNo], [OrderNo], [ChallanNo], [InvoiceType], \n");
				strSql.Append(" [EnterBy], [EnterDate], [ReconcileBy], [ReconcileDate], [IsPosted], [PostedBy], [PostedDate], [IsAuthorized], [AuthorizedBy], \n");
				strSql.Append(" [AuthorizedDate], [AuthorizeRemarks], [Gadget])  \n");
				strSql.Append("Select @VoucherNo,'" + Model.VDate.ToString("yyyy-MM-dd") + "','" + Model.VDate.ToString("yyyy-MM-dd") + ' ' + DateTime.Now.ToShortTimeString() + "','" + Model.VMiti.ToString() + "', " + (string.IsNullOrEmpty(Model.ReferenceNo) ? "null" : "'" + Model.ReferenceNo + "'") + ", " + ((string.IsNullOrEmpty(Model.ReferenceDate.ToString())) ? "null" : "'" + Model.ReferenceDate.Value.ToString("yyyy-MM-dd") + "'") + ", " + (string.IsNullOrEmpty(Model.ReferenceMiti.ToString()) ? "null" : "'" + Model.ReferenceMiti.ToString() + "'") + ", '" + Model.DueDay.ToString() + "', " + ((string.IsNullOrEmpty(Model.DueDate.ToString())) ? "null" : "'" + Model.DueDate.Value.ToString("yyyy-MM-dd") + "'") + ",  " + (string.IsNullOrEmpty(Model.DueMiti) ? "null" : "'" + Model.DueMiti + "'") + ", " + ((Model.LedgerId == 0) ? "null" : "'" + Model.LedgerId + "'") + ", \n");
				strSql.Append("" + ((Model.SubLedgerId == 0) ? "null" : "'" + Model.SubLedgerId + "'") + ", " + ((Model.SalesmanId == 0) ? "null" : "'" + Model.SalesmanId + "'") + "," + ((Model.DepartmentId1 == 0) ? "null" : "'" + Model.DepartmentId1 + "'") + ", " + ((Model.DepartmentId2 == 0) ? "null" : "'" + Model.DepartmentId2 + "'") + " ," + ((Model.DepartmentId3 == 0) ? "null" : "'" + Model.DepartmentId3 + "'") + ", " + ((Model.DepartmentId4 == 0) ? "null" : "'" + Model.DepartmentId4 + "'") + ", " + ((Model.CurrencyId == 0) ? "null" : "'" + Model.CurrencyId + "'") + ",'" + (Model.CurrencyRate == 0 ? 1 : Model.CurrencyRate) + "', " + ((Model.BranchId == 0) ? "null" : "'" + Model.BranchId + "'") + "," + ((Model.CompanyUnitId == 0) ? "null" : "'" + Model.CompanyUnitId + "'") + ", \n");
				strSql.Append("'" + Model.BasicAmount + "','" + Model.TermAmount + "', '" + Model.NetAmount + "','" + Model.LocalNetAmount + "','" + Model.TaxableAmount + "','" + Model.TaxFreeAmount + "','" + Model.VatAmount + "',  \n");
				strSql.Append("" + (string.IsNullOrEmpty(Model.PartyName) ? "null" : "'" + Model.PartyName + "'") + ",  " + (string.IsNullOrEmpty(Model.PartyVatNo) ? "null" : "'" + Model.PartyVatNo + "'") + ",  " + (string.IsNullOrEmpty(Model.PartyAddress) ? "null" : "'" + Model.PartyAddress + "'") + ",  " + (string.IsNullOrEmpty(Model.PartyMobileNo) ? "null" : "'" + Model.PartyMobileNo + "'") + "," + (string.IsNullOrEmpty(Model.PartyEmail) ? "null" : "'" + Model.PartyEmail + "'") + "," + (string.IsNullOrEmpty(Model.ChequeNo) ? "null" : "'" + Model.ChequeNo + "'") + ",  " + ((string.IsNullOrEmpty(Model.ChequeDate.ToString())) ? "null" : "'" + Model.ChequeDate.Value.ToString("yyyy-MM-dd") + "'") + ",  " + (string.IsNullOrEmpty(Model.ChequeMiti) ? "null" : "'" + Model.ChequeMiti + "'") + "," + (string.IsNullOrEmpty(Model.PaymentType) ? "null" : "'" + Model.PaymentType + "'") + ",\n");
				strSql.Append("" + (string.IsNullOrEmpty(Model.Remarks) ? "null" : "'" + Model.Remarks + "'") + ", " + (string.IsNullOrEmpty(Model.QuotationNo) ? "null" : "'" + Model.QuotationNo + "'") + ",  " + (string.IsNullOrEmpty(Model.OrderNo) ? "null" : "'" + Model.OrderNo + "'") + ",  " + (string.IsNullOrEmpty(Model.ChallanNo) ? "null" : "'" + Model.ChallanNo + "'") + ",'" + Model.InvoiceType + "','" + Model.EnterBy + "', GETDATE()," + (string.IsNullOrEmpty(Model.ReconcileBy) ? "null" : "'" + Model.ReconcileBy + "'") + ",  " + ((Model.ReconcileDate.ToString() == "") ? "null" : "'" + Model.ReconcileDate.ToString() + "'") + ", '" + Model.IsPosted + "',  " + (string.IsNullOrEmpty(Model.PostedBy) ? "null" : "'" + Model.PostedBy + "'") + ",  " + ((Model.PostedDate.ToString() == "") ? "null" : "'" + Model.PostedDate.ToString() + "'") + ",'" + Model.IsAuthorized + "',  " + (string.IsNullOrEmpty(Model.AuthorizedBy) ? "null" : "'" + Model.AuthorizedBy + "'") + ", \n");
				strSql.Append("" + ((Model.AuthorizedDate.ToString() == "") ? "null" : "'" + Model.AuthorizedDate.ToString() + "'") + ",  " + (string.IsNullOrEmpty(Model.AuthorizeRemarks) ? "null" : "'" + Model.AuthorizeRemarks + "'") + ", '" + Model.Gadget + "' \n");

				strSql.Append("INSERT INTO [ERP].[PurchaseInvoiceReturnOtherDetails]([VoucherNo],[Transport],[VehicleNo],[Package],[CnNo],[CnDate],[CnFreight],[CnType]\n");
				strSql.Append(",[Advance],[BalFreight],[DriverName],[DriverLicNo],[DriverMobileNo],[ContractNo],[ContractDate],[ExpInvNo],[ExpInvDate],[PoNo],[PoDate],[DocBank],[LcNo],[CustomName],[Cofd])\n");
				strSql.Append("Select @VoucherNo," + (string.IsNullOrEmpty(ModelOtherDetails.Transport) ? "null" : "'" + ModelOtherDetails.Transport + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.VehicleNo) ? "null" : "'" + ModelOtherDetails.VehicleNo + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.Package) ? "null" : "'" + ModelOtherDetails.Package + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.CnNo) ? "null" : "'" + ModelOtherDetails.CnNo + "'") + "," + ((Convert.ToDateTime(ModelOtherDetails.CnDate).ToString() == "") ? "null" : "'" + Convert.ToDateTime(ModelOtherDetails.CnDate).ToString("yyyy-MM-dd") + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.CnFreight) ? "null" : "'" + ModelOtherDetails.CnFreight + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.CnType) ? "null" : "'" + ModelOtherDetails.CnType + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.Advance) ? "null" : "'" + ModelOtherDetails.Advance + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.BalFreight) ? "null" : "'" + ModelOtherDetails.BalFreight + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.DriverName) ? "null" : "'" + ModelOtherDetails.DriverName + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.DriverLicNo) ? "null" : "'" + ModelOtherDetails.DriverLicNo + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.DriverMobileNo) ? "null" : "'" + ModelOtherDetails.DriverMobileNo + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.ContractNo) ? "null" : "'" + ModelOtherDetails.ContractNo + "'") + "," + ((Convert.ToDateTime(ModelOtherDetails.ContractDate).ToString("yyyy-MM-dd") == null) ? "null" : "'" + Convert.ToDateTime(ModelOtherDetails.ContractDate).ToString("yyyy-MM-dd") + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.ExpInvNo) ? "null" : "'" + ModelOtherDetails.ExpInvNo + "'") + "," + ((Convert.ToDateTime(ModelOtherDetails.ExpInvDate).ToString("yyyy-MM-dd") == null) ? "null" : "'" + Convert.ToDateTime(ModelOtherDetails.ExpInvDate).ToString("yyyy-MM-dd") + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.PoNo) ? "null" : "'" + ModelOtherDetails.PoNo + "'") + "," + ((Convert.ToDateTime(ModelOtherDetails.PoDate).ToString("yyyy-MM-dd") == null) ? "null" : "'" + Convert.ToDateTime(ModelOtherDetails.PoDate).ToString("yyyy-MM-dd") + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.DocBank) ? "null" : "'" + ModelOtherDetails.DocBank + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.LcNo) ? "null" : "'" + ModelOtherDetails.LcNo + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.CustomName) ? "null" : "'" + ModelOtherDetails.CustomName + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.Cofd) ? "null" : "'" + ModelOtherDetails.Cofd + "'") + " \n");

				strSql.Append("INSERT INTO[ERP].[PurchaseInvoiceReturnBillingAddress] ([VoucherNo],[LedgerId],[BillingAddress],[BillingCity],[BillingState],[BillingCountry],[BillingEmail],[ShippingAddress],[ShippingCity],[ShippingState],[ShippingCountry],[ShippingEmail],[DeliveryDate],[Remarks])\n");
				strSql.Append("Select @VoucherNo," + ((ModelBillAddress.LedgerId == 0) ? "null" : "'" + ModelBillAddress.LedgerId + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingAddress) ? "null" : "'" + ModelBillAddress.BillingAddress + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingCity) ? "null" : "'" + ModelBillAddress.BillingCity + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingState) ? "null" : "'" + ModelBillAddress.BillingState + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingCountry) ? "null" : "'" + ModelBillAddress.BillingCountry + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingEmail) ? "null" : "'" + ModelBillAddress.BillingEmail + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingAddress) ? "null" : "'" + ModelBillAddress.ShippingAddress + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingCity) ? "null" : "'" + ModelBillAddress.ShippingCity + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingState) ? "null" : "'" + ModelBillAddress.ShippingState + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingCountry) ? "null" : "'" + ModelBillAddress.ShippingCountry + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingEmail) ? "null" : "'" + ModelBillAddress.ShippingEmail + "'") + "," + ((ModelBillAddress.DeliveryDate.ToString() == "") ? "null" : "'" + ModelBillAddress.DeliveryDate.ToString() + "'") + ", " + (string.IsNullOrEmpty(ModelBillAddress.Remarks) ? "null" : "'" + ModelBillAddress.Remarks + "'") + " \n");
				strSql.Append("Update ERP.DocumentNumbering set DocCurrentNo = DocCurrentNo + 1 where DocId =" + Model.DocId + "\n");

			}
			else if (Model.Tag == "EDIT")
			{
				strSql.Append("UPDATE ERP.PurchaseInvoiceReturnMaster SET VDate='" + Model.VDate.ToString("yyyy-MM-dd") + "',VTime='" + Model.VDate.ToString("yyyy-MM-dd") + ' ' + DateTime.Now.ToShortTimeString() + "',VMiti='" + Model.VMiti.ToString() + "',ReferenceNo= " + ((Model.ReferenceNo == "") ? "null" : "'" + Model.ReferenceNo + "'") + ", ReferenceDate=" + ((Model.ReferenceDate.ToString() == "") ? "null" : "'" + Model.ReferenceDate.Value.ToString("yyyy-MM-dd") + "'") + ", ReferenceMiti= '" + Model.ReferenceMiti.ToString() + "', DueDate=" + ((Model.DueDate.ToString() == "") ? "null" : "'" + Model.DueDate.Value.ToString("yyyy-MM-dd") + "'") + ", DueDay='" + Model.DueDay.ToString() + "', DueMiti='" + Model.DueMiti.ToString() + "',LedgerId= " + ((Model.LedgerId == 0) ? "null" : "'" + Model.LedgerId + "'") + ", \n");
				strSql.Append("SubLedgerId=" + ((Model.SubLedgerId == 0) ? "null" : "'" + Model.SubLedgerId + "'") + ",SalesmanId= " + ((Model.SalesmanId == 0) ? "null" : "'" + Model.SalesmanId + "'") + ", DepartmentId1=" + ((Model.DepartmentId1 == 0) ? "null" : "'" + Model.DepartmentId1 + "'") + ", DepartmentId2=" + ((Model.DepartmentId2 == 0) ? "null" : "'" + Model.DepartmentId2 + "'") + ", DepartmentId3=" + ((Model.DepartmentId3 == 0) ? "null" : "'" + Model.DepartmentId3 + "'") + ", DepartmentId4=" + ((Model.DepartmentId4 == 0) ? "null" : "'" + Model.DepartmentId4 + "'") + ", CurrencyId=" + ((Model.CurrencyId == 0) ? "null" : "'" + Model.CurrencyId + "'") + ",CurrencyRate='" + Model.CurrencyRate + "', BranchId= " + ((Model.BranchId == 0) ? "null" : "'" + Model.BranchId + "'") + ",CompanyUnitId=" + ((Model.CompanyUnitId == 0) ? "null" : "'" + Model.CompanyUnitId + "'") + ", \n");
				strSql.Append("BasicAmount='" + Model.BasicAmount + "',TermAmount='" + Model.TermAmount + "',NetAmount= '" + Model.NetAmount + "',TaxableAmount= '" + Model.TaxableAmount + "',TaxFreeAmount='" + Model.TaxFreeAmount + "',VatAmount='" + Model.VatAmount + "',   \n");
				strSql.Append("PartyName=" + ((Model.PartyName == "") ? "null" : "'" + Model.PartyName + "'") + ", PartyVatNo= " + ((Model.PartyVatNo == "") ? "null" : "'" + Model.PartyVatNo + "'") + ", PartyAddress= " + ((Model.PartyAddress == "") ? "null" : "'" + Model.PartyAddress + "'") + ", PartyMobileNo= " + ((Model.PartyMobileNo == "") ? "null" : "'" + Model.PartyMobileNo + "'") + ",PartyEmail=" + (string.IsNullOrEmpty(Model.PartyEmail) ? "null" : "'" + Model.PartyEmail + "'") + ",ChequeNo=" + ((Model.ChequeNo == "") ? "null" : "'" + Model.ChequeNo + "'") + ",ChequeDate=  " + ((string.IsNullOrEmpty(Model.ChequeDate.ToString())) ? "null" : "'" + Model.ChequeDate.Value.ToString("yyyy-MM-dd") + "'") + ", ChequeMiti= " + ((Model.ChequeMiti == "") ? "null" : "'" + Model.ChequeMiti + "'") + ",  PaymentType=" + ((Model.PaymentType == "") ? "null" : "'" + Model.PaymentType + "'") + ",\n");
				strSql.Append("Remarks=" + ((Model.Remarks == "") ? "null" : "'" + Model.Remarks + "'") + ", QuotationNo=" + ((Model.QuotationNo == "") ? "null" : "'" + Model.QuotationNo + "'") + ",  OrderNo=" + ((Model.OrderNo == "") ? "null" : "'" + Model.OrderNo + "'") + ", ChallanNo= " + ((Model.ChallanNo == "") ? "null" : "'" + Model.ChallanNo + "'") + ",InvoiceType='" + Model.InvoiceType.Trim().ToString() + "', EnterBy=" + ((Model.EnterBy == "") ? "null" : "'" + Model.EnterBy + "'") + ",EnterDate= GETDATE(), ReconcileBy= " + ((Model.ReconcileBy == "") ? "null" : "'" + Model.ReconcileBy + "'") + ",  ReconcileDate=" + ((Model.ReconcileDate.ToString() == "") ? "null" : "'" + Model.ReconcileDate.ToString() + "'") + ", IsPosted='" + Model.IsPosted + "', PostedBy= " + ((Model.PostedBy == "") ? "null" : "'" + Model.PostedBy + "'") + ",  PostedDate=" + ((Model.PostedDate.ToString() == "") ? "null" : "'" + Model.PostedDate.ToString() + "'") + ",IsAuthorized='" + Model.IsAuthorized + "', AuthorizedBy= " + ((Model.AuthorizedBy == "") ? "null" : "'" + Model.AuthorizedBy + "'") + ", \n");
				strSql.Append("AuthorizedDate= " + ((string.IsNullOrEmpty(Model.AuthorizedDate.ToString())) ? "null" : "'" + Model.AuthorizedDate.Value.ToString("yyyy-MM-dd") + "'") + ", AuthorizeRemarks= " + (string.IsNullOrEmpty(Model.AuthorizeRemarks) ? "null" : "'" + Model.AuthorizeRemarks.Trim() + "'") + ", Gadget='" + Model.Gadget.Trim() + "' \n");

				strSql.Append("UPDATE [ERP].[PurchaseInvoiceReturnOtherDetails] SET Transport = " + (string.IsNullOrEmpty(ModelOtherDetails.Transport) ? "null" : "'" + ModelOtherDetails.Transport + "'") + ",VehicleNo = " + (string.IsNullOrEmpty(ModelOtherDetails.VehicleNo) ? "null" : "'" + ModelOtherDetails.VehicleNo + "'") + ",Package = " + (string.IsNullOrEmpty(ModelOtherDetails.Package) ? "null" : "'" + ModelOtherDetails.Package + "'") + ",CnNo = " + (string.IsNullOrEmpty(ModelOtherDetails.CnNo) ? "null" : "'" + ModelOtherDetails.CnNo + "'") + ",CnDate = " + ((ModelOtherDetails.CnDate.ToString() == "") ? "null" : "'" + Convert.ToDateTime(ModelOtherDetails.CnDate).ToString("yyyy-MM-dd") + "'") + ",CnFreight = " + (string.IsNullOrEmpty(ModelOtherDetails.CnFreight) ? "null" : "'" + ModelOtherDetails.CnFreight + "'") + ",CnType = " + (string.IsNullOrEmpty(ModelOtherDetails.CnType) ? "null" : "'" + ModelOtherDetails.CnType + "'") + ",Advance = " + (string.IsNullOrEmpty(ModelOtherDetails.Advance) ? "null" : "'" + ModelOtherDetails.Advance + "'") + ",BalFreight = " + (string.IsNullOrEmpty(ModelOtherDetails.BalFreight) ? "null" : "'" + ModelOtherDetails.BalFreight + "'") + ",DriverName = " + (string.IsNullOrEmpty(ModelOtherDetails.DriverName) ? "null" : "'" + ModelOtherDetails.DriverName + "'") + ",DriverLicNo = " + (string.IsNullOrEmpty(ModelOtherDetails.DriverLicNo) ? "null" : "'" + ModelOtherDetails.DriverLicNo + "'") + ",DriverMobileNo = " + (string.IsNullOrEmpty(ModelOtherDetails.DriverMobileNo) ? "null" : "'" + ModelOtherDetails.DriverMobileNo + "'") + ",ContractNo = " + (string.IsNullOrEmpty(ModelOtherDetails.ContractNo) ? "null" : "'" + ModelOtherDetails.ContractNo + "'") + ",ContractDate = " + ((ModelOtherDetails.ContractDate.ToString() == "") ? "null" : "'" + Convert.ToDateTime(ModelOtherDetails.ContractDate).ToString("yyyy-MM-dd") + "'") + ",ExpInvNo = " + (string.IsNullOrEmpty(ModelOtherDetails.ExpInvNo) ? "null" : "'" + ModelOtherDetails.ExpInvNo + "'") + ",ExpInvDate = " + ((ModelOtherDetails.ExpInvDate.ToString() == "") ? "null" : "'" + Convert.ToDateTime(ModelOtherDetails.ExpInvDate).ToString("yyyy-MM-dd") + "'") + ",PoNo = " + (string.IsNullOrEmpty(ModelOtherDetails.PoNo) ? "null" : "'" + ModelOtherDetails.PoNo + "'") + ",PoDate = " + ((ModelOtherDetails.PoDate.ToString() == "") ? "null" : "'" + Convert.ToDateTime(ModelOtherDetails.PoDate).ToString("yyyy-MM-dd") + "'") + ",DocBank = " + (string.IsNullOrEmpty(ModelOtherDetails.DocBank) ? "null" : "'" + ModelOtherDetails.DocBank + "'") + ",LcNo = " + (string.IsNullOrEmpty(ModelOtherDetails.LcNo) ? "null" : "'" + ModelOtherDetails.LcNo + "'") + ",CustomName = " + (string.IsNullOrEmpty(ModelOtherDetails.CustomName) ? "null" : "'" + ModelOtherDetails.CustomName + "'") + ",Cofd = " + (string.IsNullOrEmpty(ModelOtherDetails.Cofd) ? "null" : "'" + ModelOtherDetails.Cofd + "'") + " Where VoucherNo = '" + Model.VoucherNo + "' \n");
				strSql.Append("UPDATE[ERP].[PurchaseInvoiceReturnBillingAddress] SET LedgerId =" + ((ModelBillAddress.LedgerId == 0) ? "null" : "'" + ModelBillAddress.LedgerId + "'") + ", [BillingAddress] =" + (string.IsNullOrEmpty(ModelBillAddress.BillingAddress) ? "null" : "'" + ModelBillAddress.BillingAddress + "'") + ",[BillingCity] = " + (string.IsNullOrEmpty(ModelBillAddress.BillingCity) ? "null" : "'" + ModelBillAddress.BillingCity + "'") + ",[BillingState] = " + (string.IsNullOrEmpty(ModelBillAddress.BillingState) ? "null" : "'" + ModelBillAddress.BillingState + "'") + ",[BillingCountry] = " + (string.IsNullOrEmpty(ModelBillAddress.BillingCountry) ? "null" : "'" + ModelBillAddress.BillingCountry + "'") + ",[BillingEmail] = " + (string.IsNullOrEmpty(ModelBillAddress.BillingEmail) ? "null" : "'" + ModelBillAddress.BillingEmail + "'") + ",ShippingAddress=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingAddress) ? "null" : "'" + ModelBillAddress.ShippingAddress + "'") + ",ShippingCity=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingCity) ? "null" : "'" + ModelBillAddress.ShippingCity + "'") + ",ShippingState=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingState) ? "null" : "'" + ModelBillAddress.ShippingState + "'") + ",ShippingCountry=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingCountry) ? "null" : "'" + ModelBillAddress.ShippingCountry + "'") + ",ShippingEmail=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingEmail) ? "null" : "'" + ModelBillAddress.ShippingEmail + "'") + ",DeliveryDate=" + ((ModelBillAddress.DeliveryDate.ToString() == "") ? "null" : "'" + ModelBillAddress.DeliveryDate.ToString() + "'") + ", Remarks=" + (string.IsNullOrEmpty(ModelBillAddress.Remarks) ? "null" : "'" + ModelBillAddress.Remarks + "'") + " Where VoucherNo = '" + Model.VoucherNo + "'\n");

                strSql.Append("DELETE FROM [ERP].[PurchaseInvoiceReturnTerm] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
                strSql.Append("DELETE FROM [ERP].[PurchaseInvoiceReturnDetails] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
            }			
			else if (Model.Tag == "DELETE")
			{
				strSql.Append("Delete from ERP.InventoryTransaction Where Source = 'PR' and VoucherNo = @VoucherNo \n");
				strSql.Append("Delete from ERP.[FinanceTransaction] Where Source = 'PR' and VoucherNo = @VoucherNo \n");
				strSql.Append("DELETE FROM [ERP].[PurchaseInvoiceReturnTerm] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
				strSql.Append("DELETE FROM [ERP].[PurchaseInvoiceReturnDetails] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
				strSql.Append("DELETE FROM [ERP].[PurchaseInvoiceReturnBillingAddress] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
				strSql.Append("DELETE FROM [ERP].[PurchaseInvoiceReturnOtherDetails] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
				strSql.Append("DELETE FROM [ERP].[PurchaseInvoiceReturnMaster] WHERE VoucherNo = '" + Model.VoucherNo + "' \n");
				strSql.Append("SET @VoucherNo ='1'");
				ModelTerms.Clear();
				ModelDetails.Clear();
			}

			foreach (PurchaseInvoiceReturnDetailsViewModel det in ModelDetails)
			{
				strSql.Append("INSERT INTO ERP.PurchaseInvoiceReturnDetails(VoucherNo ,Sno,ProductId ,ProductAltUnit ,ProductUnit ,GodownId ,AltQty ,Qty ,PurchaseRate ,BasicAmount ,TermAmount ,NetAmount ,LocalNetAmount ,TaxableAmount ,TaxFreeAmount ,VatAmount ,IsTaxable ,AdditionalDesc ,ConversionRatio ,FreeQty ,FreeQtyUnit ,OrderNo ,OrderSNo ,ChallanNo ,ChallanSNo,PurchaseInvoiceNo,PurchaseInvoiceSNo) \n");
				strSql.Append("Select @VoucherNo, '" + det.Sno + "', '" + det.ProductId + "'," + ((det.ProductAltUnitId == 0) ? "null" : "'" + det.ProductAltUnitId + "'") + ", " + ((det.ProductUnitId == 0) ? "null" : "'" + det.ProductUnitId + "'") + ", " + ((det.GodownId == 0) ? "null" : "'" + det.GodownId + "'") + ",'" + det.AltQty + "', '" + det.Qty + "', '" + det.PurchaseRate + "','" + det.BasicAmount + "', '" + det.TermAmount + "', '" + det.NetAmount + "', '" + det.LocalNetAmount + "','" + det.TaxableAmount + "','" + det.TaxFreeAmount + "','" + det.VatAmount + "','" + det.IsTaxable + "','" + det.AdditionalDesc + "', '" + det.ConversionRatio + "' ,'" + det.FreeQty + "' ," + ((det.FreeQtyUnit == 0) ? "null" : "'" + det.FreeQtyUnit + "'") + " ,'" + det.OrderNo + "' ,'" + det.OrderSNo + "' ," + "'" + det.ChallanNo + "' ,'" + det.ChallanSNo + "'," + "'" + det.PurchaseInvoiceNo + "' ,'" + det.PurchaseInvoiceSNo + "' \n");

			}
			foreach (TermViewModel det in ModelTerms)
			{
				strSql.Append("INSERT INTO ERP.PurchaseInvoiceReturnTerm(VoucherNo ,Sno ,ProductId ,TermId ,TermType ,PTSign ,TermRate ,TermAmt ,LocalTermAmt ) \n");
				strSql.Append("Select @VoucherNo, '" + det.Sno + "', " + ((det.ProductId == 0) ? "null" : "'" + det.ProductId + "'") + ", '" + det.TermId + "', '" + det.TermType + "', '" + det.PTSign + "', '" + det.TermRate + "', '" + det.TermAmt + "', '" + det.LocalTermAmt + "' \n");
			}
			ModelTerms.Clear();

			if (Model.UdfDetails.Rows.Count > 0)
			{
				strSql.Append("DELETE FROM ERP.UDFDataEntry WHERE VoucherNo=@VoucherNo AND EntryModule='PR' and SNO <> 0 \n");
				int _s = 0;
				foreach (DataRow ro in Model.UdfDetails.Rows)
				{
					int j = 1;
					for (int i = 0; i < (Model.UdfDetails.Columns.Count - 1) / 2; i++)
					{
						strSql.Append("INSERT INTO ERP.UDFDataEntry(VoucherNo,EntryModule,SNO,UDFCode,UDFData,ProductId) \n");
						strSql.Append("Select @VoucherNo,'PR','" + ro[0].ToString() + "', ");
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
				strSql.Append("DELETE FROM ERP.UDFDataEntry WHERE VoucherNo=@VoucherNo AND EntryModule='PR' and SNO = 0 \n");
				foreach (DataRow ro in Model.UdfMaster.Rows)
				{
					int j = 1;
					for (int i = 0; i < (Model.UdfMaster.Columns.Count - 1) / 2; i++)
					{
						strSql.Append("INSERT INTO ERP.UDFDataEntry(VoucherNo,EntryModule,SNO,UDFCode,UDFData,ProductId) \n");
						strSql.Append("Select @VoucherNo,'PR','0','" + ro[j].ToString() + "',");
						j++;
						strSql.Append("" + (string.IsNullOrEmpty(ro[j].ToString()) ? "null" : "'" + ro[j].ToString() + "'") + ",NULL \n");
						j++;
					}
				}
				Model.UdfMaster.Rows.Clear();
			}

			ModelDetails.Clear();

			//BT Posting

			strSql.Append("insert into erp.PurchaseInvoiceReturnTerm(VoucherNo, TermId, Sno, ProductId, TermType, PTSign, TermRate, TermAmt, LocalTermAmt)  \n");
			strSql.Append("(Select @VoucherNo as VoucherNo, TermId as TermId, Sno, Pbd1.ProductId, 'BT' as TermType, PTSign, TermRate  \n");
			strSql.Append(",isnull(abs(sum((Amt * Pbd1.Bamt1) / Bamt)), 0) as TermAmt1, 0 as LocalTermAmt from erp.PurchaseInvoiceReturnMaster as sm,  \n");
			strSql.Append("(Select Sno, SD.ProductId, SD.VoucherNo, sum(Case When SD.NetAmount <> 0 then SD.NetAmount else SD.BasicAmount end) as Bamt1 from erp.PurchaseInvoiceReturnDetails as SD, erp.PurchaseInvoiceReturnMaster as SM  where SD.VoucherNo = SM.VoucherNo  \n");
			strSql.Append("group by SD.ProductId, SD.VoucherNo, Sno) as Pbd1, (select SD.VoucherNo, CASE WHEN  sum(Case when SD.NetAmount <> 0 then SD.NetAmount * CurrencyRate else SD.BasicAmount * CurrencyRate end) = 0 THEN 1 ELSE sum(Case when SD.NetAmount<>0 then SD.NetAmount* CurrencyRate else SD.BasicAmount* CurrencyRate end ) END as Bamt from erp.PurchaseInvoiceReturnDetails as SD,erp.PurchaseInvoiceReturnMaster as SM  where SD.VoucherNo = SM.VoucherNo group by SD.VoucherNo) as Pbd,\n");
			strSql.Append("(Select SD.VoucherNo,SD.TermId,SD.TermRate,sum((case when Ptm.PTSign = '+' then(SD.TermAmt * CurrencyRate) else -(SD.TermAmt * CurrencyRate) end)) as Amt,Ptm.PTSign from erp.PurchaseInvoiceReturnTerm as SD, erp.PurchaseInvoiceReturnMaster as Sm,erp.PurchaseBillingTerm as Ptm  \n");
			strSql.Append("where SD.VoucherNo = SM.VoucherNo and SD.TermId = Ptm.TermId and ProductId is Null and Basis <> 'Q' and Exists(Select* from erp.PurchaseInvoiceReturnDetails as Pbd where SD.VoucherNo = Pbd.VoucherNo group by ProductId) and SD.VoucherNo = @VoucherNo  \n");
			strSql.Append("group by SD.VoucherNo,SD.TermId,SD.TermRate,Ptm.PTSign) as Trm where sm.VoucherNo = Pbd1.VoucherNo and sm.VoucherNo = Trm.VoucherNo And Pbd.VoucherNo = Trm.VoucherNo  group by Pbd1.ProductId,TermId,TermRate,Sno,Trm.PTSign  \n");
			strSql.Append("Union All  \n");
			strSql.Append("Select @VoucherNo as VoucherNo,TermId as TermId,Sno,Pbd.ProductId,'BT' as TermType,Trm.PTSign ,TermRate,isnull(abs(sum(Case when TotQty <> 0 then(Amt / TotQty) * Bamt end)), 0) as TermAmt1,0 as LocalTermAmt  \n");
			strSql.Append("from erp.PurchaseInvoiceReturnMaster as Sm,(Select VoucherNo, Sum(Qty) as TotQty from erp.PurchaseInvoiceReturnDetails group by VoucherNo) as SD,   \n");
			strSql.Append("(select Sno, ProductId, VoucherNo, sum(Qty) as Bamt from erp.PurchaseInvoiceReturnDetails group by VoucherNo,ProductId,Sno) as Pbd,   \n");
			strSql.Append("(Select SD.VoucherNo,SD.TermId,SD.TermRate,sum((case when Ptm.PTSign = '+' then(SD.TermAmt * CurrencyRate) else -(SD.TermAmt * CurrencyRate) end)) as Amt,Ptm.PTSign  \n");
			strSql.Append("from erp.PurchaseInvoiceReturnTerm as SD,erp.PurchaseInvoiceReturnMaster as Sm,erp.PurchaseBillingTerm as Ptm where SD.VoucherNo = SM.VoucherNo and SD.TermId = Ptm.TermId and ProductId is Null and Basis = 'Q'  \n");
			strSql.Append("and Exists(Select* from erp.PurchaseInvoiceReturnDetails as Pbd where SD.VoucherNo = Pbd.VoucherNo group by ProductId) and SD.VoucherNo = @VoucherNo group by SD.VoucherNo,SD.TermId,SD.TermRate,Ptm.PTSign) as Trm  \n");
			strSql.Append("Where SM.VoucherNo = Trm.VoucherNo And Pbd.VoucherNo = Trm.VoucherNo and sm.VoucherNo = SD.VoucherNo  \n");
			strSql.Append("group by Pbd.ProductId,TermId,TermRate,Sno,Trm.PTSign) \n");


			if (Model.Tag == "EDIT")
			{
				strSql.Append("Delete from ERP.InventoryTransaction Where Source = 'PR' and VoucherNo = @VoucherNo \n");
				strSql.Append("Delete from ERP.[FinanceTransaction] Where Source = 'PR' and VoucherNo = @VoucherNo \n");
			}
		
			strSql.Append("Insert Into ERP.InventoryTransaction\n");
			strSql.Append("(VoucherNo, VDate, VMiti, VTime, LedgerId, SalesManId, DepartmentId1, DepartmentId2, DepartmentId3, CurrencyId, CurrencyRate, Sno, ProductId, GodownId, BranchId, CostCenterId, \n");
			strSql.Append("AltQuantity, AltUnitId, Quantity, ProductUnitId, AltStockQuantity, StockQuantity, FreeQuantity, StockFreeQuantity, FreeUnitId, ConversionRatio, Rate, BasicAmount, TermAmount, NetAmount, TransactionType, \n");
			strSql.Append("Source, GodownDetailId, DocumentValue, BillTerm, StockValue, TmpStockValue, ExtraFreeQty, ExtraStockFreeQty, ExtraFreeUnit, RefVoucherNo, ReferenceSource, Issueqty, IsBillCancel) \n");
			strSql.Append("Select SIM.VoucherNo,VDate,VMiti,VTime,LedgerId,SalesmanId,DepartmentId1,DepartmentId2,DepartmentId3, CurrencyId,CurrencyRate,Sno,ProductId,GodownId,BranchId, null as CostCenterId, \n");
			strSql.Append("AltQty,ProductAltUnit, Qty,ProductUnit,AltQty,Qty,0 as FreeQty,0 as StFreeQty,null as FreeUnitId ,1 as Ratio, sim.CurrencyRate, [SID].BasicAmount,[SID].TermAmount as ProductTerm,[SID].NetAmount ,'O'as TransactionType  , \n");
			strSql.Append("'PR' as Source,SID.GodownId,0 as DocumentValue, SIM.TermAmount as BillTerm,0 as StockValue,0 as TmpStockValue, 0 as ExtraFreeQty, 0 as ExtraStockFreeQty,null as  ExtraFreeUnit,'' as RefVoucherNo, '' as ReferenceSource, 0 as  Issueqty, 0 as IsBillCancel \n");
			strSql.Append("from ERP.PurchaseInvoiceReturnMaster SIM Left Outer Join ERP.PurchaseInvoiceReturnDetails [SID] on[SID].VoucherNo= SIM.VoucherNo where ProductId in (Select ProductId from erp.Product where [ProductCategory] <> 'S') \n");
			strSql.Append("and SIM.VoucherNo=@VoucherNo \n");

			strSql.Append(" declare @RateLen int set @RateLen = 2 \n");
			strSql.Append(" Insert into  erp.FinanceTransaction(VoucherNo, VDate, VMiti, VTime, CurrencyId, CurrencyRate, DepartmentId1, DepartmentId2, DepartmentId3, BranchId, SalesmanId, LedgerId, SubLedgerId, \n");
			strSql.Append(" DrAmt, CrAmt, LocalDrAmt, LocalCrAmt, ReconcileDate, SNO, CbCode, TDueDate, RefVNo,  ClearingDate, ClearedBy, EnterBy, Naration, Remarks, Source, chequeNo, ChequeDate,IsBillCancel) \n");
			strSql.Append(" select VoucherNo, VDate, VMiti, VTime, CurrencyId, CurrencyRate, DepartmentId1, DepartmentId2, DepartmentId3, BranchId, SalesmanId, LedgerId, SubLedgerId, \n");
			strSql.Append(" DrAmt, CrAmt, Local_DrAmt, Local_CrAmt, ReconcileDate, SNO, CbCode, TDueDate, RefVNo,  ClearingDate, ClearedBy, EnterBy, Naration, Remarks, Source, chequeNo, ChequeDate,IsBillCancel from( \n");
			strSql.Append(" SELECT VoucherNo, VDate, VMiti, VTime, CurrencyId, CurrencyRate, DepartmentId1, DepartmentId2, DepartmentId3, BranchId, SalesmanId, LedgerId, SubLedgerId, \n");
			strSql.Append(" round(NetAmount, @RateLen) AS DrAmt, 0  AS CrAmt, round((NetAmount * CurrencyRate), @RateLen)  AS Local_DrAmt, 0 AS Local_CrAmt, \n");
			strSql.Append(" ReconcileDate, null as SNO, null as CbCode, 0 as TDueDate, null as RefVNo,  null as ClearingDate, null as ClearedBy, EnterBy, null as Naration, Remarks, 'PR' as Source, chequeNo, ChequeDate,0 as IsBillCancel \n");
			strSql.Append(" From erp.PurchaseInvoiceReturnMaster where(VoucherNo = @VoucherNo) \n");
			strSql.Append(" Union All \n");
			strSql.Append(" SELECT PIM.VoucherNo, VDate, VMiti, VTime, CurrencyId, CurrencyRate, PIM.DepartmentId1, PIM.DepartmentId2, PIM.DepartmentId3, BranchId, SalesmanId, LedgerId, SubLedgerId, \n");
			strSql.Append(" 0 AS DrAmt, round(Sum([SID].BasicAmount), @RateLen)  AS CrAmt,0 AS Local_DrAmt, round(Sum([SID].BasicAmount * PIM.CurrencyRate), @RateLen) AS Local_CrAmt, \n");
			strSql.Append(" ReconcileDate, SNO,null as CbCode, 0 as TDueDate, null as RefVNo,  null as ClearingDate, null as ClearedBy,PIM.EnterBy ,null as Naration, Remarks, 'PR' as Source, chequeNo, ChequeDate,0 as IsBillCancel \n");
			strSql.Append(" FROM erp.PurchaseInvoiceReturnMaster as PIM,erp.PurchaseInvoiceReturnDetails as [SID],erp.SystemSetting,erp.Product where[SID].ProductId = erp.Product.ProductId And[SID].VoucherNo = PIM.VoucherNo and(PIM.VoucherNo = @VoucherNo) \n");
			strSql.Append(" group by PIM.VoucherNo ,PIM.VoucherNo, VDate, VMiti, VTime,CurrencyId, CurrencyRate,PIM.DepartmentId1, PIM.DepartmentId2, PIM.DepartmentId3, BranchId, SalesmanId, LedgerId, SubLedgerId,ReconcileDate, SNO ,PIM.EnterBy,PIM.Remarks,ChequeNo,ChequeDate \n");
			strSql.Append(" Union All \n");
			strSql.Append(" Select VoucherNo,VDate, VMiti, VTime,CurrencyId, CurrencyRate,DepartmentId1, DepartmentId2, DepartmentId3, BranchId, SalesmanId, LedgerId, SubLedgerId,  \n");
			strSql.Append(" Case when Amt < 0 then round(ABS(Amt), @RateLen) else 0 end as DrAmt,  \n");
			strSql.Append(" Case when Amt > 0 then round(Amt, @RateLen) else 0 end as CrAmt,  \n");
			strSql.Append(" Case when Amt < 0 then round((ABS(Amt) * CurrencyRate),@RateLen) else 0 end as Local_DrAmt,  \n");
			strSql.Append(" Case when Amt > 0 then round((Amt* CurrencyRate), @RateLen) else 0 end as Local_CrAmt,  \n");
			strSql.Append(" ReconcileDate, SNO,null as CbCode, 0 as TDueDate, null as RefVNo, null as ClearingDate, null as ClearedBy,EnterBy ,null as Naration, Remarks, 'PR' as Source, chequeNo, ChequeDate,0 as IsBillCancel from( \n");
			strSql.Append(" SELECT PIM.VoucherNo, VDate, VMiti, VTime, CurrencyId, CurrencyRate, PIM.DepartmentId1, PIM.DepartmentId2, PIM.DepartmentId3, BranchId, SalesmanId, PIM.LedgerId, SubLedgerId, \n");
			strSql.Append(" round(Sum(CASE WHEN PBT.PTSign = '+' THEN PIT.TermAmt ELSE -PIT.TermAmt  END),@RateLen) AS Amt, \n");
			strSql.Append(" ReconcileDate, SNO,null as CbCode, 0 as TDueDate, null as RefVNo, null as ClearingDate, null as ClearedBy,PIM.EnterBy ,null as Naration, Remarks, 'PR' as Source, chequeNo, ChequeDate,0 as IsBillCancel \n");
			strSql.Append(" FROM erp.PurchaseInvoiceReturnTerm as PIT,erp.PurchaseBillingTerm AS PBT,erp.PurchaseInvoiceReturnMaster as PIM where PIT.TermId = PBT.TermId and PIT.VoucherNo = PIM.VoucherNo and PIT.TermType <> 'BT' and(PIM.VoucherNo = @VoucherNo) \n");
			strSql.Append(" group by  PIM.VoucherNo ,PIM.VoucherNo,VDate, VMiti, VTime,CurrencyId, CurrencyRate,PIM.DepartmentId1, PIM.DepartmentId2, PIM.DepartmentId3, BranchId, SalesmanId, PIM.LedgerId, SubLedgerId,ReconcileDate, SNO ,PIM.EnterBy,PIM.Remarks,ChequeNo,ChequeDate \n");
			strSql.Append(" ) as Sb_Trm WHERE SOURCE = 'PR') as Data \n");


			strSql.Append("\n COMMIT TRANSACTION \n");
			strSql.Append("END TRY \n");
			strSql.Append("BEGIN CATCH \n");
			strSql.Append("ROLLBACK TRANSACTION \n");
			strSql.Append("Set @VoucherNo = '' \n");
			strSql.Append("END CATCH \n");

			SqlParameter[] p = new SqlParameter[1];
			p[0] = new SqlParameter("@VoucherNo", SqlDbType.VarChar, 25)
			{ Direction = ParameterDirection.Output };
			DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString(), p);
			return p[0].Value.ToString();
		}

		public string IsExistsVNumber(string VoucherNo)
		{
			DataTable dt = DAL.ExecuteDataset(CommandType.Text, "select VoucherNo from erp.PurchaseInvoiceReturnMaster WHERE VoucherNo='" + VoucherNo.Trim() + "'").Tables[0];
			if (dt.Rows.Count == 0)
				return "";
			else
				return dt.Rows[0]["VoucherNo"].ToString();
		}

		public DataSet GetDataPurchaseReturnVoucher(string VoucherNo)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append(" Select PIM.*,GLDesc,GlCategory,SubledgerDesc,SalesmanDesc,D1.DepartmentId as DepartmentId1,D1.DepartmentDesc as DepartmentDesc1,D2.DepartmentId as DepartmentId2,D2.DepartmentDesc as DepartmentDesc2,D3.DepartmentId as DepartmentId3,D3.DepartmentDesc as DepartmentDesc3,D4.DepartmentId as DepartmentId4,D4.DepartmentDesc as DepartmentDesc4  \n");
			strSql.Append(", CurrencyDesc,BranchName,CU.CmpUnitName  \n");
			strSql.Append("from erp.PurchaseInvoiceReturnMaster PIM  \n");
			strSql.Append("left Join erp.GeneralLedger GL on PIM.ledgerId = GL.LedgerID  \n");
			strSql.Append("left Join erp.Subledger SGL on PIM.SubledgerId = SGL.SubledgerId  \n");
			strSql.Append("left Join erp.Salesman SM on PIM.SalesmanId = SM.SalesmanId \n");
			strSql.Append("left Join erp.Department D1 on PIM.DepartmentId1 = D1.DepartmentID  \n");
			strSql.Append("left Join erp.Department D2  on PIM.DepartmentId2 = D2.DepartmentID  \n");
			strSql.Append("left Join erp.Department D3 on PIM.DepartmentId3 = D3.DepartmentID  \n");
			strSql.Append("left Join erp.Department D4 on PIM.DepartmentId4 = D4.DepartmentID  \n");
			strSql.Append("left Join erp.Currency CY on PIM.CurrencyId = CY.CurrencyId  \n");
			strSql.Append("left Join erp.Branch BR on PIM.BranchId = BR.BranchId  \n");
			strSql.Append("left Join erp.CompanyUnit CU on PIM.CompanyUnitId = CU.CompanyUnitId \n");
			if (!string.IsNullOrEmpty(VoucherNo))
				strSql.Append(" where voucherNo='" + VoucherNo + "' \n");

			strSql.Append("Select[PID].*,ProductShortName, ProductDesc,PD.AltConv,PAU.ProductUnitShortName as ProductAltUnitDesc,PU.ProductUnitShortName as ProductUnitDesc,GodownDesc from erp.PurchaseInvoiceReturnDetails [PID] \n");
			strSql.Append("left join erp.Product PD on[PID].ProductId = PD.ProductId  \n");
			strSql.Append("left join erp.ProductUnit PU on[PID].ProductUnit = PU.ProductUnitId  \n");
			strSql.Append("left join erp.ProductUnit PAU on[PID].ProductAltUnit = PAU.ProductUnitId  \n");
			strSql.Append("left join erp.Godown GD on[PID].GodownId = GD.GodownId  \n");
			if (!string.IsNullOrEmpty(VoucherNo))
				strSql.Append(" where voucherNo='" + VoucherNo + "' \n");

			strSql.Append("Select * from erp.PurchaseInvoiceReturnTerm  \n");
			if (!string.IsNullOrEmpty(VoucherNo))
				strSql.Append(" where voucherNo='" + VoucherNo + "' \n");

			strSql.Append("select* from[ERP].[UDFDataEntry] where VoucherNo = '" + VoucherNo + "' and EntryModule = 'PR'\n");

			strSql.Append("Select * from ERP.PurchaseInvoiceReturnOtherDetails  where VoucherNo = '" + VoucherNo + "' \n");
			strSql.Append("Select * from ERP.PurchaseInvoiceReturnBillingAddress  where VoucherNo = '" + VoucherNo + "' \n");


			return DAL.ExecuteDataset(CommandType.Text, strSql.ToString());
		}

        public DataSet GetDataPurchaseInvoiceVoucherDataToReturn(string VoucherNo,string BillNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Select PIM.*,GLDesc,GlCategory,SubledgerDesc,SalesmanDesc,D1.DepartmentId as DepartmentId1,D1.DepartmentDesc as DepartmentDesc1,D2.DepartmentId as DepartmentId2,D2.DepartmentDesc as DepartmentDesc2,D3.DepartmentId as DepartmentId3,D3.DepartmentDesc as DepartmentDesc3,D4.DepartmentId as DepartmentId4,D4.DepartmentDesc as DepartmentDesc4   \n");
            strSql.Append(" , CurrencyDesc, BranchName, CU.CmpUnitName \n");
            strSql.Append(" from erp.PurchaseInvoiceMaster PIM \n");
            strSql.Append(" left Join erp.GeneralLedger GL on PIM.ledgerId = GL.LedgerID \n");
            strSql.Append(" left Join erp.Subledger SGL on PIM.SubledgerId = SGL.SubledgerId \n");
            strSql.Append(" left Join erp.Salesman SM on PIM.SalesmanId = SM.SalesmanId \n");
            strSql.Append(" left Join erp.Department D1 on PIM.DepartmentId1 = D1.DepartmentID \n");
            strSql.Append(" left Join erp.Department D2  on PIM.DepartmentId2 = D2.DepartmentID \n");
            strSql.Append(" left Join erp.Department D3 on PIM.DepartmentId3 = D3.DepartmentID \n");
            strSql.Append(" left Join erp.Department D4 on PIM.DepartmentId4 = D4.DepartmentID \n");
            strSql.Append(" left Join erp.Currency CY on PIM.CurrencyId = CY.CurrencyId \n");
            strSql.Append(" left Join erp.Branch BR on PIM.BranchId = BR.BranchId \n");
            strSql.Append(" left Join erp.CompanyUnit CU on PIM.CompanyUnitId = CU.CompanyUnitId \n");
            if (!string.IsNullOrEmpty(VoucherNo))
                strSql.Append(" where voucherNo='" + VoucherNo + "' \n");

			strSql.Append("IF NOT EXISTS(select VoucherNo from erp.PurchaseInvoiceReturnDetails where VoucherNo= '" + BillNo + "' AND PurchaseInvoiceNo = '" + VoucherNo + "') \n");
			strSql.Append("BEGIN \n");
			strSql.Append("Select PID.VoucherNo,PID.Sno,PID.ProductId,ProductAltUnit,ProductUnit,G.GodownId, \n");
            strSql.Append("PID.AltQty, SUM(PID.Qty - isnull(CQty, 0)) as Qty, PID.PurchaseRate, PID.BasicAmount, PID.TermAmount, PID.NetAmount, PID.LocalNetAmount, PID.AdditionalDesc, PID.ConversionRatio, PID.FreeQty, PID.FreeQtyUnit, \n");
            strSql.Append("ProductShortName, ProductDesc, ProductPrintingName, P.AltConv, PAU.ProductUnitShortName as ProductAltUnitDesc, PU.ProductUnitShortName as ProductUnitDesc, GodownDesc, P.IsTaxable, OrderNo, OrderSNo, ChallanNo, ChallanSNo \n");
            strSql.Append("FROM ERP.PurchaseInvoiceDetails as PID \n");
            strSql.Append("Left Outer join( \n");
            strSql.Append("select PurchaseInvoiceNo, PurchaseInvoiceSNo, sum(Qty) as CQty from ERP.PurchaseInvoiceReturnDetails where PurchaseInvoiceNo is not Null \n");
            strSql.Append("group by PurchaseInvoiceNo, PurchaseInvoiceSNo \n");
            strSql.Append(") as PIR on PIR.PurchaseInvoiceNo = PID.VoucherNo and PIR.PurchaseInvoiceSNo = PID.SNo \n");
            strSql.Append("Left Outer join ERP.Product AS P on P.ProductId = PID.ProductId \n");
            strSql.Append("Left Outer join ERP.Godown AS G on G.GodownId = PID.GodownId \n");
            strSql.Append("left join erp.ProductUnit PU on[PID].ProductUnit = PU.ProductUnitId \n");
            strSql.Append("left join erp.ProductUnit PAU on[PID].ProductAltUnit = PAU.ProductUnitId \n");
            strSql.Append("where PID.VoucherNo IN(SELECT Value FROM fn_Splitstring('" + VoucherNo + "', ',')) \n");
            strSql.Append("group by PID.ProductId, ProductAltUnit, ProductUnit, PID.VoucherNo, PID.Sno, ProductDesc, G.GodownId, GodownDesc, \n");
            strSql.Append("PID.AltQty, ProductAltUnitId, PID.FreeQty, \n");
            strSql.Append("PID.BasicAmount, PID.NetAmount, PID.LocalNetAmount, PID.PurchaseRate, \n");
            strSql.Append("PID.AdditionalDesc, PID.TermAmount, PID.NetAmount,PID.OrderNo, PID.OrderSNo, PID.ChallanNo, PID.ChallanSNO, P.IsSerialWise, P.IsBatchwise, PID.ConversionRatio, PID.FreeQtyUnit, \n");
            strSql.Append("ProductShortName, ProductPrintingName, P.AltConv, PU.ProductUnitShortName, PAU.ProductUnitShortName, P.IsTaxable \n");
            strSql.Append("Having Sum(PID.Qty - IsNull(CQty, 0)) > 0 \n");
            strSql.Append("Order by PID.VoucherNo, PID.Sno  \n");

            strSql.Append(" Select * from erp.PurchaseInvoiceTerm  where voucherNo='" + VoucherNo + "' \n");
            strSql.Append("select* from[ERP].[UDFDataEntry] where VoucherNo = '" + VoucherNo + "' and EntryModule = 'PB'\n");
            strSql.Append("Select * from ERP.PurchaseInvoiceOtherDetails  where VoucherNo = '" + VoucherNo + "' \n");
            strSql.Append("Select * from ERP.PurchaseInvoiceBillingAddress  where VoucherNo = '" + VoucherNo + "' \n");
			strSql.Append("END\n");
			strSql.Append("ELSE\n");
			strSql.Append("BEGIN\n");
			strSql.Append("select VoucherNo,Sno,SOD.ProductId,ProductAltUnit,ProductUnit,SOD.GodownId,\n");
			strSql.Append("AltQty, Qty, SOD.PurchaseRate, BasicAmount, TermAmount, NetAmount, LocalNetAmount, AdditionalDesc, ConversionRatio, FreeQty, FreeQtyUnit,\n");
			strSql.Append("ProductShortName, ProductDesc, ProductPrintingName, P.AltConv, PAU.ProductUnitShortName as ProductAltUnitDesc, PU.ProductUnitShortName as ProductUnitDesc, GodownDesc, P.IsTaxable\n");
			strSql.Append(" OrderNo,OrderSno,ChallanNo,ChallanSNo from erp.PurchaseInvoiceReturnDetails SOD\n");
			strSql.Append(" LEFT JOIN erp.Product P ON P.ProductId = SOD.ProductId\n");
			strSql.Append("Left Outer join ERP.Godown AS G on G.GodownId = SOD.GodownId\n");
			strSql.Append("left join erp.ProductUnit PU on SOD.ProductUnit = PU.ProductUnitId\n");
			strSql.Append("left join erp.ProductUnit PAU on SOD.ProductAltUnit = PAU.ProductUnitId where VoucherNo = '" + BillNo + "'\n");
		
			strSql.Append("Select * from erp.PurchaseInvoiceReturnTerm where voucherNo='" + BillNo + "' \n");
			strSql.Append("select* from[ERP].[UDFDataEntry] where VoucherNo = '" + BillNo + "' and EntryModule = 'PR' \n");
			strSql.Append("Select * from ERP.PurchaseInvoiceReturnOtherDetails  where VoucherNo = '" + BillNo + "' \n");
			strSql.Append("Select * from ERP.PurchaseInvoiceReturnBillingAddress  where VoucherNo = '" + BillNo + "' \n");
			strSql.Append("END\n");

			return DAL.ExecuteDataset(CommandType.Text, strSql.ToString());
        }
        public class PurchaseInvoiceReturnMasterViewModel
		{
			public string Tag { get; set; }
			public int DocId { get; set; }
			public string EntryFromProject { get; set; }
			public string VoucherNo { get; set; }
			public DateTime VDate { get; set; }
			public DateTime VTime { get; set; }
			public string VMiti { get; set; }
			public string ReferenceNo { get; set; }
			public Nullable<DateTime> ReferenceDate { get; set; }
			public string ReferenceMiti { get; set; }
			public int DueDay { get; set; }
			public Nullable<DateTime> DueDate { get; set; }
			public string DueMiti { get; set; }
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
			public decimal LocalNetAmount { get; set; }
			public decimal TaxableAmount { get; set; }
			public decimal TaxFreeAmount { get; set; }
			public decimal VatAmount { get; set; }
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
			public string InvoiceType { get; set; }
			public string EnterBy { get; set; }
			public string EnterDate { get; set; }
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

			public int TableId { get; set; }
			//public BillingAddressViewModel PurchaseBillingAddress { get; set; }
			//public OtherDetailsViewModel PurchaseInvOtherDetails { get; set; }
			//public List<PurchaseInvoiceDetailsViewModel> PurchaseDetails { get; set; }
			//public List<TermViewModel> PurchaseTerm { get; set; }
			public DataTable UdfDetails { get; set; }
			public DataTable UdfMaster { get; set; }
		}

        public class PurchaseInvoiceReturnDetailsViewModel
        {
            public string VoucherNo { get; set; }
            public int Sno { get; set; }
            public int ProductId { get; set; }
            public int ProductAltUnitId { get; set; }
            public int ProductUnitId { get; set; }
            public decimal StockQuantity { get; set; }
            public decimal AltStockQuantity { get; set; }
            public decimal StockValue { get; set; }
            public int GodownId { get; set; }
            public decimal AltQty { get; set; }
            public decimal Qty { get; set; }
            public decimal PurchaseRate { get; set; }
            public decimal BasicAmount { get; set; }
            public decimal TermAmount { get; set; }
            public decimal NetAmount { get; set; }
            public decimal LocalNetAmount { get; set; }
            public decimal TaxableAmount { get; set; }
            public decimal TaxFreeAmount { get; set; }
            public decimal VatAmount { get; set; }
            public bool IsTaxable { get; set; }
            public string AdditionalDesc { get; set; }
            public decimal ConversionRatio { get; set; }
            public decimal FreeQty { get; set; }
            public int FreeQtyUnit { get; set; }
            public string OrderNo { get; set; }
            public int OrderSNo { get; set; }
            public string ChallanNo { get; set; }
            public int ChallanSNo { get; set; }
            public string PurchaseInvoiceNo { get; set; }
            public int PurchaseInvoiceSNo { get; set; }
        }
	}
}
