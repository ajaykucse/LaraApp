using DataAccessLayer.DataTransaction.Sales;
using DataAccessLayer.Interface.DataTransaction.Purchase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using static DataAccessLayer.DataTransaction.Purchase.ClsPurchaseInvoice;

namespace DataAccessLayer.DataTransaction.Purchase
{
    public class ClsPurchaseQuotation : IPurchaseQuotation
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public PurchaseQuotationMasterViewModel Model { get; set; }
        public List<PurchaseQuotationDetailsViewModel> ModelDetails { get; set; }
        public List<TermViewModel> ModelTerms { get; set; }
        public PartyInfoViewModel ModelPartyInfo { get; set; }
        public BillingAddressViewModel ModelBillAddress { get; set; }
        public OtherDetailsViewModel ModelOtherDetails { get; set; }

        public ClsPurchaseQuotation()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new PurchaseQuotationMasterViewModel();
            ModelDetails = new List<PurchaseQuotationDetailsViewModel>();
            ModelTerms = new List<TermViewModel>();
            ModelPartyInfo = new PartyInfoViewModel();
            ModelBillAddress = new BillingAddressViewModel();
            ModelOtherDetails = new OtherDetailsViewModel();
        }

        public string SavePurchaseQuotation()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            strSql.Append("Set @VoucherNo ='" + Model.VoucherNo.Trim().Replace("'", "''") + "' \n");
			Model.VoucherNo = Model.VoucherNo.Trim().Replace("'", "''");

			if (Model.Tag == "NEW")
            {
                strSql.Append("INSERT INTO ERP.PurchaseQuotationMaster([VoucherNo], [VDate], [VTime], [VMiti], \n");
                strSql.Append(" [LedgerId], [SubLedgerId], [SalesmanId], [DepartmentId1], [DepartmentId2], \n");
                strSql.Append(" [DepartmentId3], [DepartmentId4], [CurrencyId], [CurrencyRate], [BranchId], [CompanyUnitId], [BasicAmount], [TermAmount],  \n");
                strSql.Append("[NetAmount],[LocalNetAmount], [PartyName], [PartyVatNo], [PartyAddress], [PartyMobileNo], \n");
                strSql.Append(" [ChequeNo], [ChequeDate], [ChequeMiti], [Remarks], \n");
                strSql.Append(" [EnterBy], [EnterDate],[IsReconcile] ,[ReconcileBy], [ReconcileDate], [IsPosted], [PostedBy], [PostedDate], [IsAuthorized], [AuthorizedBy], \n");
                strSql.Append(" [AuthorizedDate], [AuthorizeRemarks], [Gadget],IndentNo)  \n");
                strSql.Append("Select @VoucherNo,'" + Model.VDate.ToString("yyyy-MM-dd") + "','" + Model.VDate.ToString("yyyy-MM-dd") + ' ' + DateTime.Now.ToShortTimeString() + "','" + Model.VMiti.ToString() + "', " + ((Model.LedgerId == 0) ? "null" : "'" + Model.LedgerId + "'") + ", \n");
                strSql.Append("" + ((Model.SubLedgerId == 0) ? "null" : "'" + Model.SubLedgerId + "'") + ", " + ((Model.SalesmanId == 0) ? "null" : "'" + Model.SalesmanId + "'") + "," + ((Model.DepartmentId1 == 0) ? "null" : "'" + Model.DepartmentId1 + "'") + ", " + ((Model.DepartmentId2 == 0) ? "null" : "'" + Model.DepartmentId2 + "'") + " ," + ((Model.DepartmentId3 == 0) ? "null" : "'" + Model.DepartmentId3 + "'") + ", " + ((Model.DepartmentId4 == 0) ? "null" : "'" + Model.DepartmentId4 + "'") + ", " + ((Model.CurrencyId == 0) ? "null" : "'" + Model.CurrencyId + "'") + ",'" + (Model.CurrencyRate == 0 ? 1 : Model.CurrencyRate) + "', " + ((Model.BranchId == 0) ? "null" : "'" + Model.BranchId + "'") + "," + ((Model.CompanyUnitId == 0) ? "null" : "'" + Model.CompanyUnitId + "'") + ", \n");
                strSql.Append("'" + Model.BasicAmount + "','" + Model.TermAmount + "', '" + Model.NetAmount + "','" + Model.LocalNetAmount + "',  \n");
                strSql.Append("" + (string.IsNullOrEmpty(Model.PartyName) ? "null" : "'" + Model.PartyName + "'") + ",  " + (string.IsNullOrEmpty(Model.PartyVatNo) ? "null" : "'" + Model.PartyVatNo + "'") + ",  " + (string.IsNullOrEmpty(Model.PartyAddress) ? "null" : "'" + Model.PartyAddress + "'") + ",  " + (string.IsNullOrEmpty(Model.PartyMobileNo) ? "null" : "'" + Model.PartyMobileNo + "'") + "," + (string.IsNullOrEmpty(Model.ChequeNo) ? "null" : "'" + Model.ChequeNo + "'") + ", " + ((string.IsNullOrEmpty(Model.ChequeDate.ToString())) ? "null" : "'" + Model.ChequeDate.Value.ToString("yyyy-MM-dd") + "'") + ",  " + (string.IsNullOrEmpty(Model.ChequeMiti) ? "null" : "'" + Model.ChequeMiti + "'") + ",\n");
                strSql.Append("" + (string.IsNullOrEmpty(Model.Remarks) ? "null" : "'" + Model.Remarks + "'") + ",'" + Model.EnterBy + "', GETDATE(),'" + Model.IsReconcile + "'," + (string.IsNullOrEmpty(Model.ReconcileBy) ? "null" : "'" + Model.ReconcileBy + "'") + ",  " + ((Model.ReconcileDate.ToString() == "") ? "null" : "'" + Model.ReconcileDate.ToString() + "'") + ", '" + Model.IsPosted + "',  " + (string.IsNullOrEmpty(Model.PostedBy) ? "null" : "'" + Model.PostedBy + "'") + ",  " + ((Model.PostedDate.ToString() == "") ? "null" : "'" + Model.PostedDate.ToString() + "'") + ",'" + Model.IsAuthorized + "',  " + (string.IsNullOrEmpty(Model.AuthorizedBy) ? "null" : "'" + Model.AuthorizedBy + "'") + ", \n");
                strSql.Append("" + ((Model.AuthorizedDate.ToString() == "") ? "null" : "'" + Model.AuthorizedDate.ToString() + "'") + ",  " + (string.IsNullOrEmpty(Model.AuthorizeRemarks) ? "null" : "'" + Model.AuthorizeRemarks + "'") + ", '" + Model.Gadget + "', " + (string.IsNullOrEmpty(Model.IndentNo) ? "null" : "'" + Model.IndentNo + "'") + " \n");

                strSql.Append("INSERT INTO [ERP].[PurchaseQuotationOtherDetails]([VoucherNo],[Transport],[VehicleNo],[Package],[CnNo],[CnDate],[CnFreight],[CnType]\n");
                strSql.Append(",[Advance],[BalFreight],[DriverName],[DriverLicNo],[DriverMobileNo],[ContractNo],[ContractDate],[ExpInvNo],[ExpInvDate],[PoNo],[PoDate],[DocBank],[LcNo],[CustomName],[Cofd])\n");
                strSql.Append("Select @VoucherNo," + (string.IsNullOrEmpty(ModelOtherDetails.Transport) ? "null" : "'" + ModelOtherDetails.Transport + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.VehicleNo) ? "null" : "'" + ModelOtherDetails.VehicleNo + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.Package) ? "null" : "'" + ModelOtherDetails.Package + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.CnNo) ? "null" : "'" + ModelOtherDetails.CnNo + "'") + "," + ((Convert.ToDateTime(ModelOtherDetails.CnDate).ToString() == "") ? "null" : "'" + Convert.ToDateTime(ModelOtherDetails.CnDate).ToString("yyyy-MM-dd") + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.CnFreight) ? "null" : "'" + ModelOtherDetails.CnFreight + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.CnType) ? "null" : "'" + ModelOtherDetails.CnType + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.Advance) ? "null" : "'" + ModelOtherDetails.Advance + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.BalFreight) ? "null" : "'" + ModelOtherDetails.BalFreight + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.DriverName) ? "null" : "'" + ModelOtherDetails.DriverName + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.DriverLicNo) ? "null" : "'" + ModelOtherDetails.DriverLicNo + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.DriverMobileNo) ? "null" : "'" + ModelOtherDetails.DriverMobileNo + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.ContractNo) ? "null" : "'" + ModelOtherDetails.ContractNo + "'") + "," + ((Convert.ToDateTime(ModelOtherDetails.ContractDate).ToString("yyyy-MM-dd") == null) ? "null" : "'" + Convert.ToDateTime(ModelOtherDetails.ContractDate).ToString("yyyy-MM-dd") + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.ExpInvNo) ? "null" : "'" + ModelOtherDetails.ExpInvNo + "'") + "," + ((Convert.ToDateTime(ModelOtherDetails.ExpInvDate).ToString("yyyy-MM-dd") == null) ? "null" : "'" + Convert.ToDateTime(ModelOtherDetails.ExpInvDate).ToString("yyyy-MM-dd") + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.PoNo) ? "null" : "'" + ModelOtherDetails.PoNo + "'") + "," + ((Convert.ToDateTime(ModelOtherDetails.PoDate).ToString("yyyy-MM-dd") == null) ? "null" : "'" + Convert.ToDateTime(ModelOtherDetails.PoDate).ToString("yyyy-MM-dd") + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.DocBank) ? "null" : "'" + ModelOtherDetails.DocBank + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.LcNo) ? "null" : "'" + ModelOtherDetails.LcNo + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.CustomName) ? "null" : "'" + ModelOtherDetails.CustomName + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.Cofd) ? "null" : "'" + ModelOtherDetails.Cofd + "'") + " \n");

                strSql.Append("INSERT INTO[ERP].[PurchaseQuotationBillingAddress] ([VoucherNo],[LedgerId],[BillingAddress],[BillingCity],[BillingState],[BillingCountry],[BillingEmail],[ShippingAddress],[ShippingCity],[ShippingState],[ShippingCountry],[ShippingEmail],[DeliveryDate],[Remarks])\n");
                strSql.Append("Select @VoucherNo," + ((ModelBillAddress.LedgerId == 0) ? "null" : "'" + ModelBillAddress.LedgerId + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingAddress) ? "null" : "'" + ModelBillAddress.BillingAddress + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingCity) ? "null" : "'" + ModelBillAddress.BillingCity + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingState) ? "null" : "'" + ModelBillAddress.BillingState + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingCountry) ? "null" : "'" + ModelBillAddress.BillingCountry + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingEmail) ? "null" : "'" + ModelBillAddress.BillingEmail + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingAddress) ? "null" : "'" + ModelBillAddress.ShippingAddress + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingCity) ? "null" : "'" + ModelBillAddress.ShippingCity + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingState) ? "null" : "'" + ModelBillAddress.ShippingState + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingCountry) ? "null" : "'" + ModelBillAddress.ShippingCountry + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingEmail) ? "null" : "'" + ModelBillAddress.ShippingEmail + "'") + "," + ((ModelBillAddress.DeliveryDate.ToString() == "") ? "null" : "'" + ModelBillAddress.DeliveryDate.ToString() + "'") + ", " + (string.IsNullOrEmpty(ModelBillAddress.Remarks) ? "null" : "'" + ModelBillAddress.Remarks + "'") + " \n");

                strSql.Append("Update ERP.DocumentNumbering set DocCurrentNo = DocCurrentNo + 1 where DocId =" + Model.DocId + "\n");

            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP.PurchaseQuotationMaster SET VDate='" + Model.VDate.ToString("yyyy-MM-dd") + "',VTime='" + Model.VDate.ToString("yyyy-MM-dd") + ' ' + DateTime.Now.ToShortTimeString() + "',VMiti='" + Model.VMiti.ToString() + "',LedgerId= " + ((Model.LedgerId == 0) ? "null" : "'" + Model.LedgerId + "'") + ", \n");
                strSql.Append("SubLedgerId=" + ((Model.SubLedgerId == 0) ? "null" : "'" + Model.SubLedgerId + "'") + ",SalesmanId= " + ((Model.SalesmanId == 0) ? "null" : "'" + Model.SalesmanId + "'") + ", DepartmentId1=" + ((Model.DepartmentId1 == 0) ? "null" : "'" + Model.DepartmentId1 + "'") + ", DepartmentId2=" + ((Model.DepartmentId2 == 0) ? "null" : "'" + Model.DepartmentId2 + "'") + ", DepartmentId3=" + ((Model.DepartmentId3 == 0) ? "null" : "'" + Model.DepartmentId3 + "'") + ", DepartmentId4=" + ((Model.DepartmentId4 == 0) ? "null" : "'" + Model.DepartmentId4 + "'") + ", CurrencyId=" + ((Model.CurrencyId == 0) ? "null" : "'" + Model.CurrencyId + "'") + ",CurrencyRate='" + Model.CurrencyRate + "', BranchId= " + ((Model.BranchId == 0) ? "null" : "'" + Model.BranchId + "'") + ",CompanyUnitId=" + ((Model.CompanyUnitId == 0) ? "null" : "'" + Model.CompanyUnitId + "'") + ", \n");
                strSql.Append("BasicAmount='" + Model.BasicAmount + "',TermAmount='" + Model.TermAmount + "',NetAmount= '" + Model.NetAmount + "',   \n");
                strSql.Append("PartyName=" + ((Model.PartyName == "") ? "null" : "'" + Model.PartyName + "'") + ", PartyVatNo= " + ((Model.PartyVatNo == "") ? "null" : "'" + Model.PartyVatNo + "'") + ", PartyAddress= " + ((Model.PartyAddress == "") ? "null" : "'" + Model.PartyAddress + "'") + ", PartyMobileNo= " + ((Model.PartyMobileNo == "") ? "null" : "'" + Model.PartyMobileNo + "'") + ",ChequeNo=" + ((Model.ChequeNo == "") ? "null" : "'" + Model.ChequeNo + "'") + ",ChequeDate= " + ((string.IsNullOrEmpty(Model.ChequeDate.ToString())) ? "null" : "'" + Model.ChequeDate.Value.ToString("yyyy-MM-dd") + "'") + ", ChequeMiti= " + ((Model.ChequeMiti == "") ? "null" : "'" + Model.ChequeMiti + "'") + ", \n");
                strSql.Append("Remarks=" + ((Model.Remarks == "") ? "null" : "'" + Model.Remarks + "'") + ", EnterBy=" + ((Model.EnterBy == "") ? "null" : "'" + Model.EnterBy + "'") + ",EnterDate= GETDATE(),IsReconcile='" + Model.IsReconcile + "', ReconcileBy= " + ((Model.ReconcileBy == "") ? "null" : "'" + Model.ReconcileBy + "'") + ",  ReconcileDate=" + ((Model.ReconcileDate.ToString() == "") ? "null" : "'" + Model.ReconcileDate.ToString() + "'") + ", IsPosted='" + Model.IsPosted + "', PostedBy= " + ((Model.PostedBy == "") ? "null" : "'" + Model.PostedBy + "'") + ",  PostedDate=" + ((Model.PostedDate.ToString() == "") ? "null" : "'" + Model.PostedDate.ToString() + "'") + ",IsAuthorized='" + Model.IsAuthorized + "', AuthorizedBy= " + ((Model.AuthorizedBy == "") ? "null" : "'" + Model.AuthorizedBy + "'") + ", \n");
                strSql.Append("AuthorizedDate= " + ((string.IsNullOrEmpty(Model.AuthorizedDate.ToString())) ? "null" : "'" + Model.AuthorizedDate.Value.ToString("yyyy-MM-dd") + "'") + ", AuthorizeRemarks= " + (string.IsNullOrEmpty(Model.AuthorizeRemarks) ? "null" : "'" + Model.AuthorizeRemarks.Trim() + "'") + ", Gadget='" + Model.Gadget.Trim() + "', IndentNo= " + ((Model.IndentNo == "") ? "null" : "'" + Model.IndentNo + "'") + " Where VoucherNo = '" + Model.VoucherNo + "' \n");

                strSql.Append("UPDATE [ERP].[PurchaseQuotationOtherDetails] SET Transport = " + (string.IsNullOrEmpty(ModelOtherDetails.Transport) ? "null" : "'" + ModelOtherDetails.Transport + "'") + ",VehicleNo = " + (string.IsNullOrEmpty(ModelOtherDetails.VehicleNo) ? "null" : "'" + ModelOtherDetails.VehicleNo + "'") + ",Package = " + (string.IsNullOrEmpty(ModelOtherDetails.Package) ? "null" : "'" + ModelOtherDetails.Package + "'") + ",CnNo = " + (string.IsNullOrEmpty(ModelOtherDetails.CnNo) ? "null" : "'" + ModelOtherDetails.CnNo + "'") + ",CnDate = " + ((string.IsNullOrEmpty(ModelOtherDetails.CnDate.ToString())) ? "null" : "'" + ModelOtherDetails.CnDate.Value.ToString("yyyy-MM-dd") + "'") + ",CnFreight = " + (string.IsNullOrEmpty(ModelOtherDetails.CnFreight) ? "null" : "'" + ModelOtherDetails.CnFreight + "'") + ",CnType = " + (string.IsNullOrEmpty(ModelOtherDetails.CnType) ? "null" : "'" + ModelOtherDetails.CnType + "'") + ",Advance = " + (string.IsNullOrEmpty(ModelOtherDetails.Advance) ? "null" : "'" + ModelOtherDetails.Advance + "'") + ",BalFreight = " + (string.IsNullOrEmpty(ModelOtherDetails.BalFreight) ? "null" : "'" + ModelOtherDetails.BalFreight + "'") + ",DriverName = " + (string.IsNullOrEmpty(ModelOtherDetails.DriverName) ? "null" : "'" + ModelOtherDetails.DriverName + "'") + ",DriverLicNo = " + (string.IsNullOrEmpty(ModelOtherDetails.DriverLicNo) ? "null" : "'" + ModelOtherDetails.DriverLicNo + "'") + ",DriverMobileNo = " + (string.IsNullOrEmpty(ModelOtherDetails.DriverMobileNo) ? "null" : "'" + ModelOtherDetails.DriverMobileNo + "'") + ",ContractNo = " + (string.IsNullOrEmpty(ModelOtherDetails.ContractNo) ? "null" : "'" + ModelOtherDetails.ContractNo + "'") + ",ContractDate = " + ((string.IsNullOrEmpty(ModelOtherDetails.ContractDate.ToString())) ? "null" : "'" + ModelOtherDetails.ContractDate.Value.ToString("yyyy-MM-dd") + "'") + ",ExpInvNo = " + (string.IsNullOrEmpty(ModelOtherDetails.ExpInvNo) ? "null" : "'" + ModelOtherDetails.ExpInvNo + "'") + ",ExpInvDate = " + ((string.IsNullOrEmpty(ModelOtherDetails.ExpInvDate.ToString())) ? "null" : "'" + ModelOtherDetails.ExpInvDate.Value.ToString("yyyy-MM-dd") + "'") + ",PoNo = " + (string.IsNullOrEmpty(ModelOtherDetails.PoNo) ? "null" : "'" + ModelOtherDetails.PoNo + "'") + ",PoDate = " + ((string.IsNullOrEmpty(ModelOtherDetails.PoDate.ToString())) ? "null" : "'" + ModelOtherDetails.PoDate.Value.ToString("yyyy-MM-dd") + "'") + ",DocBank = " + (string.IsNullOrEmpty(ModelOtherDetails.DocBank) ? "null" : "'" + ModelOtherDetails.DocBank + "'") + ",LcNo = " + (string.IsNullOrEmpty(ModelOtherDetails.LcNo) ? "null" : "'" + ModelOtherDetails.LcNo + "'") + ",CustomName = " + (string.IsNullOrEmpty(ModelOtherDetails.CustomName) ? "null" : "'" + ModelOtherDetails.CustomName + "'") + ",Cofd = " + (string.IsNullOrEmpty(ModelOtherDetails.Cofd) ? "null" : "'" + ModelOtherDetails.Cofd + "'") + " Where VoucherNo = '" + Model.VoucherNo + "'\n");
				strSql.Append("UPDATE[ERP].[PurchaseQuotationBillingAddress] SET LedgerId =" + ((ModelBillAddress.LedgerId == 0) ? "null" : "'" + ModelBillAddress.LedgerId + "'") + ", [BillingAddress] =" + (string.IsNullOrEmpty(ModelBillAddress.BillingAddress) ? "null" : "'" + ModelBillAddress.BillingAddress + "'") + ",[BillingCity] = " + (string.IsNullOrEmpty(ModelBillAddress.BillingCity) ? "null" : "'" + ModelBillAddress.BillingCity + "'") + ",[BillingState] = " + (string.IsNullOrEmpty(ModelBillAddress.BillingState) ? "null" : "'" + ModelBillAddress.BillingState + "'") + ",[BillingCountry] = " + (string.IsNullOrEmpty(ModelBillAddress.BillingCountry) ? "null" : "'" + ModelBillAddress.BillingCountry + "'") + ",[BillingEmail] = " + (string.IsNullOrEmpty(ModelBillAddress.BillingEmail) ? "null" : "'" + ModelBillAddress.BillingEmail + "'") + ",ShippingAddress=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingAddress) ? "null" : "'" + ModelBillAddress.ShippingAddress + "'") + ",ShippingCity=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingCity) ? "null" : "'" + ModelBillAddress.ShippingCity + "'") + ",ShippingState=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingState) ? "null" : "'" + ModelBillAddress.ShippingState + "'") + ",ShippingCountry=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingCountry) ? "null" : "'" + ModelBillAddress.ShippingCountry + "'") + ",ShippingEmail=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingEmail) ? "null" : "'" + ModelBillAddress.ShippingEmail + "'") + ",DeliveryDate=" + ((ModelBillAddress.DeliveryDate.ToString() == "") ? "null" : "'" + ModelBillAddress.DeliveryDate.ToString() + "'") + ", Remarks=" + (string.IsNullOrEmpty(ModelBillAddress.Remarks) ? "null" : "'" + ModelBillAddress.Remarks + "'") + " Where VoucherNo = '" + Model.VoucherNo + "' \n");

				strSql.Append("DELETE FROM [ERP].[PurchaseQuotationTerm] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
				strSql.Append("DELETE FROM [ERP].[PurchaseQuotationDetails] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");

			}
			else if (Model.Tag == "DELETE")
            {
                strSql.Append("DELETE FROM [ERP].[PurchaseQuotationTerm] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
                strSql.Append("DELETE FROM [ERP].[PurchaseQuotationDetails] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
                strSql.Append("DELETE FROM [ERP].[PurchaseQuotationBillingAddress] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
                strSql.Append("DELETE FROM [ERP].[PurchaseQuotationOtherDetails] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
                strSql.Append("DELETE FROM [ERP].[PurchaseQuotationMaster] WHERE VoucherNo = '" + Model.VoucherNo + "' \n");
                strSql.Append("SET @VoucherNo ='1'");
                ModelTerms.Clear();
                ModelDetails.Clear();
            }

            foreach (PurchaseQuotationDetailsViewModel det in ModelDetails)
            {
                strSql.Append("INSERT INTO ERP.PurchaseQuotationDetails(VoucherNo ,Sno,ProductId ,ProductAltUnit ,ProductUnit ,GodownId ,AltQty ,Qty ,PurchaseRate ,BasicAmount ,TermAmount ,NetAmount ,LocalNetAmount ,AdditionalDesc ,ConversionRatio ,FreeQty ,FreeQtyUnit,IndentNo,IndentSNo) \n");
                strSql.Append("Select @VoucherNo, '" + det.Sno + "', '" + det.ProductId + "'," + ((det.ProductAltUnitId == 0) ? "null" : "'" + det.ProductAltUnitId + "'") + ", " + ((det.ProductUnitId == 0) ? "null" : "'" + det.ProductUnitId + "'") + ", " + ((det.GodownId == 0) ? "null" : "'" + det.GodownId + "'") + ",'" + det.AltQty + "', '" + det.Qty + "', '" + det.PurchaseRate + "','" + det.BasicAmount + "', '" + det.TermAmount + "', '" + det.NetAmount + "', '" + det.LocalNetAmount + "','" + det.AdditionalDesc + "', '" + det.ConversionRatio + "' ,'" + det.FreeQty + "' ," + ((det.FreeQtyUnit == 0) ? "null" : "'" + det.FreeQtyUnit + "'") + " ," + "'" + det.IndentNo + "' ,'" + det.IndentSNo + "' \n");

            }
            foreach (TermViewModel det in ModelTerms)
            {
                strSql.Append("INSERT INTO ERP.PurchaseQuotationTerm(VoucherNo ,Sno ,ProductId ,TermId ,TermType ,PTSign ,TermRate ,TermAmt ,LocalTermAmt ) \n");
                strSql.Append("Select @VoucherNo, '" + det.Sno + "', " + ((det.ProductId == 0) ? "null" : "'" + det.ProductId + "'") + ", '" + det.TermId + "', '" + det.TermType + "', '" + det.PTSign + "', '" + det.TermRate + "', '" + det.TermAmt + "', '" + det.LocalTermAmt + "' \n");
            }
            ModelTerms.Clear();

            if (Model.UdfDetails.Rows.Count > 0)
            {
                strSql.Append("DELETE FROM ERP.UDFDataEntry WHERE VoucherNo=@VoucherNo AND EntryModule='PB' and SNO <> 0 \n");
                int _s = 0;
                foreach (DataRow ro in Model.UdfDetails.Rows)
                {
                    int j = 1;
                    for (int i = 0; i < (Model.UdfDetails.Columns.Count - 1) / 2; i++)
                    {
                        strSql.Append("INSERT INTO ERP.UDFDataEntry(VoucherNo,EntryModule,SNO,UDFCode,UDFData,ProductId) \n");
                        strSql.Append("Select @VoucherNo,'PB','" + ro[0].ToString() + "', ");
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
                strSql.Append("DELETE FROM ERP.UDFDataEntry WHERE VoucherNo=@VoucherNo AND EntryModule='PB' and SNO = 0 \n");
                foreach (DataRow ro in Model.UdfMaster.Rows)
                {
                    int j = 1;
                    for (int i = 0; i < (Model.UdfMaster.Columns.Count - 1) / 2; i++)
                    {
                        strSql.Append("INSERT INTO ERP.UDFDataEntry(VoucherNo,EntryModule,SNO,UDFCode,UDFData,ProductId) \n");
                        strSql.Append("Select @VoucherNo,'PB','0','" + ro[j].ToString() + "',");
                        j++;
                        strSql.Append("" + (string.IsNullOrEmpty(ro[j].ToString()) ? "null" : "'" + ro[j].ToString() + "'") + ",NULL \n");
                        j++;
                    }
                }
                Model.UdfMaster.Rows.Clear();
            }

            ModelDetails.Clear();

            //BT Posting
            strSql.Append("insert into erp.PurchaseQuotationTerm(VoucherNo, TermId, Sno, ProductId, TermType, PTSign, TermRate, TermAmt, LocalTermAmt)  \n");
            strSql.Append("(Select @VoucherNo as VoucherNo, TermId as TermId, Sno, Pbd1.ProductId, 'BT' as TermType, PTSign, TermRate  \n");
            strSql.Append(", isnull(abs(sum((Amt * Pbd1.Bamt1) / Bamt)), 0) as TermAmt1, 0 as LocalTermAmt from erp.PurchaseQuotationMaster as sm,  \n");
            strSql.Append("(Select Sno, SD.ProductId, SD.VoucherNo, sum(Case When SD.NetAmount <> 0 then SD.NetAmount else SD.BasicAmount end) as Bamt1 from erp.PurchaseQuotationDetails as SD, erp.PurchaseQuotationMaster as SM  where SD.VoucherNo = SM.VoucherNo  \n");
            strSql.Append("group by SD.ProductId, SD.VoucherNo, Sno) as Pbd1, (select SD.VoucherNo, CASE WHEN  sum(Case when SD.NetAmount <> 0 then SD.NetAmount * CurrencyRate else SD.BasicAmount * CurrencyRate end) = 0 THEN 1 ELSE sum(Case when SD.NetAmount<>0 then SD.NetAmount* CurrencyRate else SD.BasicAmount* CurrencyRate end ) END as Bamt from erp.PurchaseQuotationDetails as SD,erp.PurchaseQuotationMaster as SM  where SD.VoucherNo = SM.VoucherNo group by SD.VoucherNo) as Pbd,   \n");
            strSql.Append("(Select SD.VoucherNo,SD.TermId,SD.TermRate,sum((case when Ptm.PTSign = '+' then(SD.TermAmt * CurrencyRate) else -(SD.TermAmt * CurrencyRate) end)) as Amt,Ptm.PTSign from erp.PurchaseQuotationTerm as SD, erp.PurchaseQuotationMaster as Sm,erp.PurchaseBillingTerm as Ptm  \n");
            strSql.Append("where SD.VoucherNo = SM.VoucherNo and SD.TermId = Ptm.TermId and ProductId is Null and Basis <> 'Q' and Exists(Select* from erp.PurchaseQuotationDetails as Pbd where SD.VoucherNo = Pbd.VoucherNo group by ProductId) and SD.VoucherNo = @VoucherNo  \n");
            strSql.Append("group by SD.VoucherNo,SD.TermId,SD.TermRate,Ptm.PTSign) as Trm where sm.VoucherNo = Pbd1.VoucherNo and sm.VoucherNo = Trm.VoucherNo And Pbd.VoucherNo = Trm.VoucherNo  group by Pbd1.ProductId,TermId,TermRate,Sno,Trm.PTSign  \n");
            strSql.Append("Union All  \n");
            strSql.Append("Select @VoucherNo as VoucherNo,TermId as TermId,Sno,Pbd.ProductId,'BT' as TermType,Trm.PTSign ,TermRate,isnull(abs(sum(Case when TotQty <> 0 then(Amt / TotQty) * Bamt end)), 0) as TermAmt1,0 as LocalTermAmt  \n");
            strSql.Append("from erp.PurchaseQuotationMaster as Sm,(Select VoucherNo, Sum(Qty) as TotQty from erp.PurchaseQuotationDetails group by VoucherNo) as SD,   \n");
            strSql.Append("(select Sno, ProductId, VoucherNo, sum(Qty) as Bamt from erp.PurchaseQuotationDetails group by VoucherNo,ProductId,Sno) as Pbd,   \n");
            strSql.Append("(Select SD.VoucherNo,SD.TermId,SD.TermRate,sum((case when Ptm.PTSign = '+' then(SD.TermAmt * CurrencyRate) else -(SD.TermAmt * CurrencyRate) end)) as Amt,Ptm.PTSign  \n");
            strSql.Append("from erp.PurchaseQuotationTerm as SD,erp.PurchaseQuotationMaster as Sm,erp.PurchaseBillingTerm as Ptm where SD.VoucherNo = SM.VoucherNo and SD.TermId = Ptm.TermId and ProductId is Null and Basis = 'Q'  \n");
            strSql.Append("and Exists(Select* from erp.PurchaseQuotationDetails as Pbd where SD.VoucherNo = Pbd.VoucherNo group by ProductId) and SD.VoucherNo = @VoucherNo group by SD.VoucherNo,SD.TermId,SD.TermRate,Ptm.PTSign) as Trm  \n");
            strSql.Append("Where SM.VoucherNo = Trm.VoucherNo And Pbd.VoucherNo = Trm.VoucherNo and sm.VoucherNo = SD.VoucherNo  \n");
            strSql.Append("group by Pbd.ProductId,TermId,TermRate,Sno,Trm.PTSign)  \n");

            strSql.Append("Update erp.PurchaseQuotationTerm set LocalTermAmt = TermAmt * CurrencyRate from erp.PurchaseQuotationMaster where erp.PurchaseQuotationTerm.VoucherNo = erp.PurchaseQuotationMaster.VoucherNo and erp.PurchaseQuotationMaster.VoucherNo = @VoucherNo  \n");
            
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
            DataTable dt = DAL.ExecuteDataset(CommandType.Text, "select VoucherNo from erp.PurchaseQuotationMaster WHERE VoucherNo='" + VoucherNo.Trim().Replace("'", "''") + "'").Tables[0];
            if (dt.Rows.Count == 0)
            {
                return "";
            }
            else
            {
                return dt.Rows[0]["VoucherNo"].ToString();
            }
        }
		public string IsQuotationUsedInOrder(string VoucherNo)
		{
			DataTable dt = DAL.ExecuteDataset(CommandType.Text, "select TOP 1 QuotationNo from ERP.PurchaseOrderDetails where QuotationNo='" + VoucherNo.Trim().Replace("'", "''") + "'").Tables[0];
			return dt.Rows.Count == 0 ? "" : dt.Rows[0]["QuotationNo"].ToString();
		}

		public string IsQuotationUsedInChallan(string VoucherNo)
		{
			DataTable dt = DAL.ExecuteDataset(CommandType.Text, "select TOP 1 QuotationNo from ERP.PurchaseChallanDetails  where QuotationNo='" + VoucherNo.Trim().Replace("'", "''") + "'").Tables[0];
			return dt.Rows.Count == 0 ? "" : dt.Rows[0]["QuotationNo"].ToString();
		}
		public DataSet GetDataPurchaseQuotationVoucher(string VoucherNo)
        {
			VoucherNo = VoucherNo.Trim().Replace("'", "''");
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Select PIM.*,GLDesc,GlCategory,SubledgerDesc,SalesmanDesc,D1.DepartmentId as DepartmentId1,D1.DepartmentDesc as DepartmentDesc1,D2.DepartmentId as DepartmentId2,D2.DepartmentDesc as DepartmentDesc2,D3.DepartmentId as DepartmentId3,D3.DepartmentDesc as DepartmentDesc3,D4.DepartmentId as DepartmentId4,D4.DepartmentDesc as DepartmentDesc4  \n");
            strSql.Append(", CurrencyDesc,BranchName,CU.CmpUnitName  \n");
            strSql.Append("from erp.PurchaseQuotationMaster PIM  \n");
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
            {
                strSql.Append(" where voucherNo='" + VoucherNo + "' \n");
            }

            strSql.Append("Select[PID].*,ProductShortName, ProductDesc,PD.AltConv,PAU.ProductUnitShortName as ProductAltUnitDesc,PU.ProductUnitShortName as ProductUnitDesc,GodownDesc from erp.PurchaseQuotationDetails[PID] \n");
            strSql.Append("left join erp.Product PD on[PID].ProductId = PD.ProductId  \n");
            strSql.Append("left join erp.ProductUnit PU on[PID].ProductUnit = PU.ProductUnitId  \n");
            strSql.Append("left join erp.ProductUnit PAU on[PID].ProductAltUnit = PAU.ProductUnitId  \n");
            strSql.Append("left join erp.Godown GD on[PID].GodownId = GD.GodownId  \n");
            if (!string.IsNullOrEmpty(VoucherNo))
            {
                strSql.Append(" where voucherNo='" + VoucherNo + "' \n");
            }

            strSql.Append("Select * from erp.PurchaseQuotationTerm  \n");
            if (!string.IsNullOrEmpty(VoucherNo))
            {
                strSql.Append(" where voucherNo='" + VoucherNo + "' \n");
            }

            strSql.Append("select* from[ERP].[UDFDataEntry] where VoucherNo = '" + VoucherNo + "' and EntryModule = 'PB'\n");

            strSql.Append("Select * from ERP.PurchaseQuotationOtherDetails  where VoucherNo = '" + VoucherNo + "' \n");
            strSql.Append("Select * from ERP.PurchaseQuotationBillingAddress  where VoucherNo = '" + VoucherNo + "' \n");


            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString());
        }
		public DataSet GetDataPurchaseQuotationForOrder(string VoucherNo, string BillNo, string module)
		{
			VoucherNo = VoucherNo.Trim().Replace("'", "''");
			BillNo = BillNo.Trim().Replace("'", "''");
			
			StringBuilder strSql = new StringBuilder();
			strSql.Append(" Select SCM.*,GLDesc,GlCategory,SubledgerDesc,SalesmanDesc,D1.DepartmentId as DepartmentId1,D1.DepartmentDesc as DepartmentDesc1,D2.DepartmentId as DepartmentId2,D2.DepartmentDesc as DepartmentDesc2,D3.DepartmentId as DepartmentId3,D3.DepartmentDesc as DepartmentDesc3,D4.DepartmentId as DepartmentId4,D4.DepartmentDesc as DepartmentDesc4,  \n");
			strSql.Append(" CurrencyDesc,BranchName,CU.CmpUnitName \n");
			strSql.Append("from erp.PurchaseQuotationMaster SCM  \n");
			strSql.Append("left Join erp.GeneralLedger GL on SCM.ledgerId = GL.LedgerID \n");
			strSql.Append("left Join erp.Subledger SGL on SCM.SubledgerId = SGL.SubledgerId \n");
			strSql.Append("left Join erp.Salesman SM on SCM.SalesmanId = SM.SalesmanId \n");
			strSql.Append("left Join erp.Department D1 on SCM.DepartmentId1 = D1.DepartmentID \n");
			strSql.Append("left Join erp.Department D2  on SCM.DepartmentId2 = D2.DepartmentID \n");
			strSql.Append("left Join erp.Department D3 on SCM.DepartmentId3 = D3.DepartmentID \n");
			strSql.Append("left Join erp.Department D4 on SCM.DepartmentId4 = D4.DepartmentID \n");
			strSql.Append("left Join erp.Currency CY on SCM.CurrencyId = CY.CurrencyId \n");
			strSql.Append("left Join erp.Branch BR on SCM.BranchId = BR.BranchId  \n");
			strSql.Append("left Join erp.CompanyUnit CU on SCM.CompanyUnitId = CU.CompanyUnitId \n");
			if (!string.IsNullOrEmpty(VoucherNo))
				strSql.Append("where voucherNo IN (SELECT Value FROM fn_Splitstring('" + VoucherNo + "', ',')) \n\n");

			strSql.Append("BEGIN \n");
			if (module == "PC")
				strSql.Append("IF NOT EXISTS(select VoucherNo from erp.PurchaseChallanDetails where VoucherNo= '" + BillNo + "' AND QuotationNo = '" + VoucherNo + "') \n");
			if (module == "PO")
				strSql.Append("IF NOT EXISTS(select VoucherNo from erp.PurchaseOrderDetails where VoucherNo= '" + BillNo + "' AND QuotationNo = '" + VoucherNo + "') \n");

			strSql.Append("BEGIN \n");
			strSql.Append("Select SQD.VoucherNo,SQD.Sno,SQD.ProductId,ProductAltUnit,ProductUnit,G.GodownId,\n");
			strSql.Append("SQD.AltQty,SUM(SQD.Qty-isnull(CQty,0)) as Qty,SQD.PurchaseRate,SQD.BasicAmount,SQD.TermAmount,SQD.NetAmount,SQD.LocalNetAmount,SQD.AdditionalDesc,SQD.ConversionRatio,SQD.FreeQty,SQD.FreeQtyUnit,\n");
			strSql.Append("ProductShortName, ProductDesc,ProductPrintingName,P.AltConv,PAU.ProductUnitShortName as ProductAltUnitDesc,PU.ProductUnitShortName as ProductUnitDesc,GodownDesc,P.IsTaxable\n");
			strSql.Append("FROM ERP.PurchaseQuotationDetails as SQD\n");
			strSql.Append("Left Outer join(\n");
			strSql.Append("select QuotationNo,QuotationSNo, sum(Qty) as CQty from ERP.SalesOrderDetails where QuotationNo is not Null  group by QuotationNo,QuotationSNo\n");
			strSql.Append(") as OD on OD.QuotationNo=SQD.VoucherNo and OD.QuotationSNo=SQD.SNo\n");
			strSql.Append("Left Outer join ERP.Product AS P on P.ProductId=SQD.ProductId\n");
			strSql.Append("Left Outer join ERP.Godown AS G on G.GodownId=SQD.GodownId\n");
			strSql.Append("left join erp.ProductUnit PU on [SQD].ProductUnit = PU.ProductUnitId\n");
			strSql.Append("left join erp.ProductUnit PAU on [SQD].ProductAltUnit = PAU.ProductUnitId\n");
			strSql.Append("where SQD.VoucherNo IN (SELECT Value FROM fn_Splitstring('" + VoucherNo + "', ','))\n");
			strSql.Append("group by SQD.ProductId,ProductAltUnit,ProductUnit,SQD.VoucherNo,SQD.Sno,ProductDesc,G.GodownId,GodownDesc,\n");
			strSql.Append("SQD.AltQty,ProductAltUnitId,SQD.FreeQty,\n");
			strSql.Append("SQD.BasicAmount,SQD.NetAmount,SQD.LocalNetAmount,SQD.PurchaseRate,\n");
			strSql.Append("SQD.AdditionalDesc,SQD.TermAmount,SQD.NetAmount,P.IsSerialWise,P.IsBatchwise,SQD.ConversionRatio,SQD.FreeQtyUnit,\n");
			strSql.Append("ProductShortName,ProductPrintingName,P.AltConv,PU.ProductUnitShortName,PAU.ProductUnitShortName,P.IsTaxable\n");
			strSql.Append("Having Sum(SQD.Qty - IsNull(CQty, 0)) > 0\n");
			strSql.Append("Order by SQD.VoucherNo,SQD.Sno\n");

			strSql.Append("Select * from erp.PurchaseQuotationTerm where voucherNo='" + VoucherNo + "' \n\n");
			strSql.Append("select* from[ERP].[UDFDataEntry] where VoucherNo = '" + VoucherNo + "' and EntryModule = 'PQ' \n\n");
			strSql.Append("Select * from ERP.PurchaseQuotationOtherDetails  where VoucherNo = '" + VoucherNo + "' \n\n");
			strSql.Append("Select * from ERP.PurchaseQuotationBillingAddress  where VoucherNo = '" + VoucherNo + "'");

			strSql.Append("END\n");
			strSql.Append("ELSE\n");
			strSql.Append("BEGIN\n");
			strSql.Append("select VoucherNo,Sno,SOD.ProductId,ProductAltUnit,ProductUnit,SOD.GodownId,\n");
			strSql.Append("AltQty, Qty, SOD.PurchaseRate, BasicAmount, TermAmount, NetAmount, LocalNetAmount, AdditionalDesc, ConversionRatio, FreeQty, FreeQtyUnit,\n");
			strSql.Append("ProductShortName, ProductDesc, ProductPrintingName, P.AltConv, PAU.ProductUnitShortName as ProductAltUnitDesc, PU.ProductUnitShortName as ProductUnitDesc, GodownDesc, P.IsTaxable\n");
			if (module == "PC")
				strSql.Append(" from erp.PurchaseChallanDetails SOD\n");
			else if (module == "PO")
				strSql.Append(" from erp.PurchaseOrderDetails SOD\n");
			strSql.Append(" LEFT JOIN erp.Product P ON P.ProductId = SOD.ProductId\n");
			strSql.Append("Left Outer join ERP.Godown AS G on G.GodownId = SOD.GodownId\n");
			strSql.Append("left join erp.ProductUnit PU on SOD.ProductUnit = PU.ProductUnitId\n");
			strSql.Append("left join erp.ProductUnit PAU on SOD.ProductAltUnit = PAU.ProductUnitId where VoucherNo = '" + BillNo + "'\n");
			strSql.Append("END\n");
			strSql.Append("END\n");

			if (module == "PC")
			{
				strSql.Append("Select * from erp.PurchaseChallanTerm where voucherNo='" + BillNo + "' \\n");
				strSql.Append("select* from[ERP].[UDFDataEntry] where VoucherNo = '" + BillNo + "' and EntryModule = 'PC' \n");
				strSql.Append("Select * from ERP.PurchaseChallanOtherDetails  where VoucherNo = '" + BillNo + "' \n");
				strSql.Append("Select * from ERP.PurchaseChallanBillingAddress  where VoucherNo = '" + BillNo + "'");
			}
			if (module == "PO")
			{
				strSql.Append("Select * from erp.PurchaseOrderTerm where voucherNo='" + BillNo + "' \n\n");
				strSql.Append("select* from[ERP].[UDFDataEntry] where VoucherNo = '" + BillNo + "' and EntryModule = 'PO' \n");
				strSql.Append("Select * from ERP.PurchaseOrderOtherDetails  where VoucherNo = '" + BillNo + "' \n");
				strSql.Append("Select * from ERP.PurchaseOrderBillingAddress  where VoucherNo = '" + BillNo + "'");
			}
			return DAL.ExecuteDataset(CommandType.Text, strSql.ToString());
		}
		public class PurchaseQuotationMasterViewModel
        {
            public string Tag { get; set; }
            public int DocId { get; set; }
            public string EntryFromProject { get; set; }
            public string VoucherNo { get; set; }
            public DateTime VDate { get; set; }
            public DateTime VTime { get; set; }
            public string VMiti { get; set; }
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
            public string PartyName { get; set; }
            public string PartyVatNo { get; set; }
            public string PartyAddress { get; set; }
            public string PartyMobileNo { get; set; }
            public string ChequeNo { get; set; }
			public Nullable<DateTime> ChequeDate { get; set; }
			public string ChequeMiti { get; set; }
            public string Remarks { get; set; }
            public string EnterBy { get; set; }
            public string EnterDate { get; set; }
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
            public string IndentNo { get; set; }

            public DataTable UdfDetails { get; set; }
            public DataTable UdfMaster { get; set; }
        }

        public class PurchaseQuotationDetailsViewModel
        {
            public string VoucherNo { get; set; }
            public int Sno { get; set; }
            public int ProductId { get; set; }
            public int ProductAltUnitId { get; set; }
            public int ProductUnitId { get; set; }
            public int GodownId { get; set; }
            public decimal AltQty { get; set; }
            public decimal Qty { get; set; }
            public decimal PurchaseRate { get; set; }
            public decimal BasicAmount { get; set; }
            public decimal TermAmount { get; set; }
            public decimal NetAmount { get; set; }
            public decimal LocalNetAmount { get; set; }
            public string AdditionalDesc { get; set; }
            public decimal ConversionRatio { get; set; }
            public decimal FreeQty { get; set; }
            public int FreeQtyUnit { get; set; }
            public string IndentNo { get; set; }
            public int IndentSNo { get; set; }
        }
    }
}
