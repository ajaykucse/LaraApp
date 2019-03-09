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
    public class ClsPurchaseChallan : IPurchaseChallan
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public PurchaseChallanMasterViewModel Model { get; set; }
        public List<PurchaseChallanDetailsViewModel> ModelDetails { get; set; }
        public List<TermViewModel> ModelTerms { get; set; }
        public PartyInfoViewModel ModelPartyInfo { get; set; }
        public BillingAddressViewModel ModelBillAddress { get; set; }
        public OtherDetailsViewModel ModelOtherDetails { get; set; }

        public ClsPurchaseChallan()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new PurchaseChallanMasterViewModel();
            ModelDetails = new List<PurchaseChallanDetailsViewModel>();
            ModelTerms = new List<TermViewModel>();
            ModelPartyInfo = new PartyInfoViewModel();
            ModelBillAddress = new BillingAddressViewModel();
            ModelOtherDetails = new OtherDetailsViewModel();
        }

        public string SavePurchaseChallan()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            strSql.Append("Set @VoucherNo ='" + Model.VoucherNo.Trim() + "' \n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("INSERT INTO ERP.PurchaseChallanMaster([VoucherNo], [VDate], [VTime], [VMiti],  \n");
                strSql.Append(" [LedgerId], [SubLedgerId], [SalesmanId], [DepartmentId1], [DepartmentId2], \n");
                strSql.Append(" [DepartmentId3], [DepartmentId4], [CurrencyId], [CurrencyRate], [BranchId], [CompanyUnitId], [BasicAmount], [TermAmount],  \n");
                strSql.Append("[NetAmount],[LocalNetAmount], [PartyName], [PartyVatNo], [PartyAddress], [PartyMobileNo], \n");
                strSql.Append(" [ChequeNo], [ChequeDate], [ChequeMiti], [Remarks], [QuotationNo], [OrderNo], \n");
                strSql.Append(" [EnterBy], [EnterDate],[IsReconcile], [ReconcileBy], [ReconcileDate], [IsPosted], [PostedBy], [PostedDate], [IsAuthorized], [AuthorizedBy], \n");
                strSql.Append(" [AuthorizedDate], [AuthorizeRemarks], [Gadget])  \n");// " + (string.IsNullOrEmpty(Model.ReferenceNo) ? "null" : "'" + Model.ReferenceNo + "'") + ", " + ((string.IsNullOrEmpty(Model.ReferenceDate.ToString())) ? "null" : "'" + Model.ReferenceDate.Value.ToString("yyyy-MM-dd") + "'") + ", " + (string.IsNullOrEmpty(Model.ReferenceMiti.ToString()) ? "null" : "'" + Model.ReferenceMiti.ToString() + "'") + "
                strSql.Append("Select @VoucherNo,'" + Model.VDate.ToString("yyyy-MM-dd") + "','" + Model.VDate.ToString("yyyy-MM-dd") + ' ' + DateTime.Now.ToShortTimeString() + "','" + Model.VMiti.ToString() + "', " + ((Model.LedgerId == 0) ? "null" : "'" + Model.LedgerId + "'") + ", \n");
                strSql.Append("" + ((Model.SubLedgerId == 0) ? "null" : "'" + Model.SubLedgerId + "'") + ", " + ((Model.SalesmanId == 0) ? "null" : "'" + Model.SalesmanId + "'") + "," + ((Model.DepartmentId1 == 0) ? "null" : "'" + Model.DepartmentId1 + "'") + ", " + ((Model.DepartmentId2 == 0) ? "null" : "'" + Model.DepartmentId2 + "'") + " ," + ((Model.DepartmentId3 == 0) ? "null" : "'" + Model.DepartmentId3 + "'") + ", " + ((Model.DepartmentId4 == 0) ? "null" : "'" + Model.DepartmentId4 + "'") + ", " + ((Model.CurrencyId == 0) ? "null" : "'" + Model.CurrencyId + "'") + ",'" + (Model.CurrencyRate == 0 ? 1 : Model.CurrencyRate) + "', " + ((Model.BranchId == 0) ? "null" : "'" + Model.BranchId + "'") + "," + ((Model.CompanyUnitId == 0) ? "null" : "'" + Model.CompanyUnitId + "'") + ", \n");
                strSql.Append("'" + Model.BasicAmount + "','" + Model.TermAmount + "', '" + Model.NetAmount + "','" + Model.LocalNetAmount + "',  \n");
                strSql.Append("" + (string.IsNullOrEmpty(Model.PartyName) ? "null" : "'" + Model.PartyName + "'") + ",  " + (string.IsNullOrEmpty(Model.PartyVatNo) ? "null" : "'" + Model.PartyVatNo + "'") + ",  " + (string.IsNullOrEmpty(Model.PartyAddress) ? "null" : "'" + Model.PartyAddress + "'") + ",  " + (string.IsNullOrEmpty(Model.PartyMobileNo) ? "null" : "'" + Model.PartyMobileNo + "'") + "," + (string.IsNullOrEmpty(Model.ChequeNo) ? "null" : "'" + Model.ChequeNo + "'") + ", " + ((string.IsNullOrEmpty(Model.ChequeDate.ToString())) ? "null" : "'" + Model.ChequeDate.Value.ToString("yyyy-MM-dd") + "'") + ",  " + (string.IsNullOrEmpty(Model.ChequeMiti) ? "null" : "'" + Model.ChequeMiti + "'") + ",\n");
                strSql.Append("" + (string.IsNullOrEmpty(Model.Remarks) ? "null" : "'" + Model.Remarks + "'") + ", " + (string.IsNullOrEmpty(Model.QuotationNo) ? "null" : "'" + Model.QuotationNo + "'") + ",  " + (string.IsNullOrEmpty(Model.OrderNo) ? "null" : "'" + Model.OrderNo + "'") + ", '" + Model.EnterBy + "', GETDATE(),'"+Model.IsReconcile+"'," + (string.IsNullOrEmpty(Model.ReconcileBy) ? "null" : "'" + Model.ReconcileBy + "'") + ",  " + ((Model.ReconcileDate.ToString() == "") ? "null" : "'" + Model.ReconcileDate.ToString() + "'") + ", '" + Model.IsPosted + "',  " + (string.IsNullOrEmpty(Model.PostedBy) ? "null" : "'" + Model.PostedBy + "'") + ",  " + ((Model.PostedDate.ToString() == "") ? "null" : "'" + Model.PostedDate.ToString() + "'") + ",'" + Model.IsAuthorized + "',  " + (string.IsNullOrEmpty(Model.AuthorizedBy) ? "null" : "'" + Model.AuthorizedBy + "'") + ", \n");
                strSql.Append("" + ((Model.AuthorizedDate.ToString() == "") ? "null" : "'" + Model.AuthorizedDate.ToString() + "'") + ",  " + (string.IsNullOrEmpty(Model.AuthorizeRemarks) ? "null" : "'" + Model.AuthorizeRemarks + "'") + ", '" + Model.Gadget + "' \n");

                strSql.Append("INSERT INTO [ERP].[PurchaseChallanOtherDetails]([VoucherNo],[Transport],[VehicleNo],[Package],[CnNo],[CnDate],[CnFreight],[CnType]\n");
                strSql.Append(",[Advance],[BalFreight],[DriverName],[DriverLicNo],[DriverMobileNo],[ContractNo],[ContractDate],[ExpInvNo],[ExpInvDate],[PoNo],[PoDate],[DocBank],[LcNo],[CustomName],[Cofd])\n");
				strSql.Append("Select @VoucherNo," + (string.IsNullOrEmpty(ModelOtherDetails.Transport) ? "null" : "'" + ModelOtherDetails.Transport + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.VehicleNo) ? "null" : "'" + ModelOtherDetails.VehicleNo + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.Package) ? "null" : "'" + ModelOtherDetails.Package + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.CnNo) ? "null" : "'" + ModelOtherDetails.CnNo + "'") + "," + ((Convert.ToDateTime(ModelOtherDetails.CnDate).ToString() == "") ? "null" : "'" + Convert.ToDateTime(ModelOtherDetails.CnDate).ToString("yyyy-MM-dd") + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.CnFreight) ? "null" : "'" + ModelOtherDetails.CnFreight + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.CnType) ? "null" : "'" + ModelOtherDetails.CnType + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.Advance) ? "null" : "'" + ModelOtherDetails.Advance + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.BalFreight) ? "null" : "'" + ModelOtherDetails.BalFreight + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.DriverName) ? "null" : "'" + ModelOtherDetails.DriverName + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.DriverLicNo) ? "null" : "'" + ModelOtherDetails.DriverLicNo + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.DriverMobileNo) ? "null" : "'" + ModelOtherDetails.DriverMobileNo + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.ContractNo) ? "null" : "'" + ModelOtherDetails.ContractNo + "'") + "," + ((Convert.ToDateTime(ModelOtherDetails.ContractDate).ToString("yyyy-MM-dd") == null) ? "null" : "'" + Convert.ToDateTime(ModelOtherDetails.ContractDate).ToString("yyyy-MM-dd") + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.ExpInvNo) ? "null" : "'" + ModelOtherDetails.ExpInvNo + "'") + "," + ((Convert.ToDateTime(ModelOtherDetails.ExpInvDate).ToString("yyyy-MM-dd") == null) ? "null" : "'" + Convert.ToDateTime(ModelOtherDetails.ExpInvDate).ToString("yyyy-MM-dd") + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.PoNo) ? "null" : "'" + ModelOtherDetails.PoNo + "'") + "," + ((Convert.ToDateTime(ModelOtherDetails.PoDate).ToString("yyyy-MM-dd") == null) ? "null" : "'" + Convert.ToDateTime(ModelOtherDetails.PoDate).ToString("yyyy-MM-dd") + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.DocBank) ? "null" : "'" + ModelOtherDetails.DocBank + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.LcNo) ? "null" : "'" + ModelOtherDetails.LcNo + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.CustomName) ? "null" : "'" + ModelOtherDetails.CustomName + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.Cofd) ? "null" : "'" + ModelOtherDetails.Cofd + "'") + " \n");

				strSql.Append("INSERT INTO[ERP].[PurchaseChallanBillingAddress] ([VoucherNo],[LedgerId],[BillingAddress],[BillingCity],[BillingState],[BillingCountry],[BillingEmail],[ShippingAddress],[ShippingCity],[ShippingState],[ShippingCountry],[ShippingEmail],[DeliveryDate],[Remarks])\n");
                strSql.Append("Select @VoucherNo," + ((ModelBillAddress.LedgerId == 0) ? "null" : "'" + ModelBillAddress.LedgerId + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingAddress) ? "null" : "'" + ModelBillAddress.BillingAddress + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingCity) ? "null" : "'" + ModelBillAddress.BillingCity + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingState) ? "null" : "'" + ModelBillAddress.BillingState + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingCountry) ? "null" : "'" + ModelBillAddress.BillingCountry + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingEmail) ? "null" : "'" + ModelBillAddress.BillingEmail + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingAddress) ? "null" : "'" + ModelBillAddress.ShippingAddress + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingCity) ? "null" : "'" + ModelBillAddress.ShippingCity + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingState) ? "null" : "'" + ModelBillAddress.ShippingState + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingCountry) ? "null" : "'" + ModelBillAddress.ShippingCountry + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingEmail) ? "null" : "'" + ModelBillAddress.ShippingEmail + "'") + "," + ((ModelBillAddress.DeliveryDate.ToString() == "") ? "null" : "'" + ModelBillAddress.DeliveryDate.ToString() + "'") + ", " + (string.IsNullOrEmpty(ModelBillAddress.Remarks) ? "null" : "'" + ModelBillAddress.Remarks + "'") + " \n");
                
                strSql.Append("Update ERP.DocumentNumbering set DocCurrentNo = DocCurrentNo + 1 where DocId =" + Model.DocId + "\n");

            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP.PurchaseChallanMaster SET VDate='" + Model.VDate.ToString("yyyy-MM-dd") + "',VTime='" + Model.VDate.ToString("yyyy-MM-dd") + ' ' + DateTime.Now.ToShortTimeString() + "',VMiti='" + Model.VMiti.ToString() + "',LedgerId= " + ((Model.LedgerId == 0) ? "null" : "'" + Model.LedgerId + "'") + ", \n");
                strSql.Append("SubLedgerId=" + ((Model.SubLedgerId == 0) ? "null" : "'" + Model.SubLedgerId + "'") + ",SalesmanId= " + ((Model.SalesmanId == 0) ? "null" : "'" + Model.SalesmanId + "'") + ", DepartmentId1=" + ((Model.DepartmentId1 == 0) ? "null" : "'" + Model.DepartmentId1 + "'") + ", DepartmentId2=" + ((Model.DepartmentId2 == 0) ? "null" : "'" + Model.DepartmentId2 + "'") + ", DepartmentId3=" + ((Model.DepartmentId3 == 0) ? "null" : "'" + Model.DepartmentId3 + "'") + ", DepartmentId4=" + ((Model.DepartmentId4 == 0) ? "null" : "'" + Model.DepartmentId4 + "'") + ", CurrencyId=" + ((Model.CurrencyId == 0) ? "null" : "'" + Model.CurrencyId + "'") + ",CurrencyRate='" + Model.CurrencyRate + "', BranchId= " + ((Model.BranchId == 0) ? "null" : "'" + Model.BranchId + "'") + ",CompanyUnitId=" + ((Model.CompanyUnitId == 0) ? "null" : "'" + Model.CompanyUnitId + "'") + ", \n");
                strSql.Append("BasicAmount='" + Model.BasicAmount + "',TermAmount='" + Model.TermAmount + "',NetAmount= '" + Model.NetAmount + "',   \n");
                strSql.Append("PartyName=" + ((Model.PartyName == "") ? "null" : "'" + Model.PartyName + "'") + ", PartyVatNo= " + ((Model.PartyVatNo == "") ? "null" : "'" + Model.PartyVatNo + "'") + ", PartyAddress= " + ((Model.PartyAddress == "") ? "null" : "'" + Model.PartyAddress + "'") + ", PartyMobileNo= " + ((Model.PartyMobileNo == "") ? "null" : "'" + Model.PartyMobileNo + "'") + ",ChequeNo=" + ((Model.ChequeNo == "") ? "null" : "'" + Model.ChequeNo + "'") + ",ChequeDate= " + ((string.IsNullOrEmpty(Model.ChequeDate.ToString())) ? "null" : "'" + Model.ChequeDate.Value.ToString("yyyy-MM-dd") + "'") + ", ChequeMiti= " + ((Model.ChequeMiti == "") ? "null" : "'" + Model.ChequeMiti + "'") + "  ,\n");
                strSql.Append("Remarks=" + ((Model.Remarks == "") ? "null" : "'" + Model.Remarks + "'") + ", QuotationNo=" + ((Model.QuotationNo == "") ? "null" : "'" + Model.QuotationNo + "'") + ",  OrderNo=" + ((Model.OrderNo == "") ? "null" : "'" + Model.OrderNo + "'") + ", EnterBy=" + ((Model.EnterBy == "") ? "null" : "'" + Model.EnterBy + "'") + ",EnterDate= GETDATE(),IsReconcile="+ Model.IsReconcile + ", ReconcileBy= " + ((Model.ReconcileBy == "") ? "null" : "'" + Model.ReconcileBy + "'") + ",  ReconcileDate=" + ((Model.ReconcileDate.ToString() == "") ? "null" : "'" + Model.ReconcileDate.ToString() + "'") + ", IsPosted='" + Model.IsPosted + "', PostedBy= " + ((Model.PostedBy == "") ? "null" : "'" + Model.PostedBy + "'") + ",  PostedDate=" + ((Model.PostedDate.ToString() == "") ? "null" : "'" + Model.PostedDate.ToString() + "'") + ",IsAuthorized='" + Model.IsAuthorized + "', AuthorizedBy= " + ((Model.AuthorizedBy == "") ? "null" : "'" + Model.AuthorizedBy + "'") + ", \n");
                strSql.Append("AuthorizedDate= " + ((string.IsNullOrEmpty(Model.AuthorizedDate.ToString())) ? "null" : "'" + Model.AuthorizedDate.Value.ToString("yyyy-MM-dd") + "'") + ", AuthorizeRemarks= " + (string.IsNullOrEmpty(Model.AuthorizeRemarks) ? "null" : "'" + Model.AuthorizeRemarks.Trim() + "'") + ", Gadget='" + Model.Gadget.Trim() + "' Where VoucherNo = '" + Model.VoucherNo + "' \n");

                strSql.Append("UPDATE [ERP].[PurchaseChallanOtherDetails] SET Transport = " + (string.IsNullOrEmpty(ModelOtherDetails.Transport) ? "null" : "'" + ModelOtherDetails.Transport + "'") + ",VehicleNo = " + (string.IsNullOrEmpty(ModelOtherDetails.VehicleNo) ? "null" : "'" + ModelOtherDetails.VehicleNo + "'") + ",Package = " + (string.IsNullOrEmpty(ModelOtherDetails.Package) ? "null" : "'" + ModelOtherDetails.Package + "'") + ",CnNo = " + (string.IsNullOrEmpty(ModelOtherDetails.CnNo) ? "null" : "'" + ModelOtherDetails.CnNo + "'") + ",CnDate = " + ((string.IsNullOrEmpty(ModelOtherDetails.CnDate.ToString())) ? "null" : "'" + ModelOtherDetails.CnDate.Value.ToString("yyyy-MM-dd") + "'") + ",CnFreight = " + (string.IsNullOrEmpty(ModelOtherDetails.CnFreight) ? "null" : "'" + ModelOtherDetails.CnFreight + "'") + ",CnType = " + (string.IsNullOrEmpty(ModelOtherDetails.CnType) ? "null" : "'" + ModelOtherDetails.CnType + "'") + ",Advance = " + (string.IsNullOrEmpty(ModelOtherDetails.Advance) ? "null" : "'" + ModelOtherDetails.Advance + "'") + ",BalFreight = " + (string.IsNullOrEmpty(ModelOtherDetails.BalFreight) ? "null" : "'" + ModelOtherDetails.BalFreight + "'") + ",DriverName = " + (string.IsNullOrEmpty(ModelOtherDetails.DriverName) ? "null" : "'" + ModelOtherDetails.DriverName + "'") + ",DriverLicNo = " + (string.IsNullOrEmpty(ModelOtherDetails.DriverLicNo) ? "null" : "'" + ModelOtherDetails.DriverLicNo + "'") + ",DriverMobileNo = " + (string.IsNullOrEmpty(ModelOtherDetails.DriverMobileNo) ? "null" : "'" + ModelOtherDetails.DriverMobileNo + "'") + ",ContractNo = " + (string.IsNullOrEmpty(ModelOtherDetails.ContractNo) ? "null" : "'" + ModelOtherDetails.ContractNo + "'") + ",ContractDate = " + ((string.IsNullOrEmpty(ModelOtherDetails.ContractDate.ToString())) ? "null" : "'" + ModelOtherDetails.ContractDate.Value.ToString("yyyy-MM-dd") + "'") + ",ExpInvNo = " + (string.IsNullOrEmpty(ModelOtherDetails.ExpInvNo) ? "null" : "'" + ModelOtherDetails.ExpInvNo + "'") + ",ExpInvDate = " + ((string.IsNullOrEmpty(ModelOtherDetails.ExpInvDate.ToString())) ? "null" : "'" + ModelOtherDetails.ExpInvDate.Value.ToString("yyyy-MM-dd") + "'") + ",PoNo = " + (string.IsNullOrEmpty(ModelOtherDetails.PoNo) ? "null" : "'" + ModelOtherDetails.PoNo + "'") + ",PoDate = " + ((string.IsNullOrEmpty(ModelOtherDetails.PoDate.ToString())) ? "null" : "'" + ModelOtherDetails.PoDate.Value.ToString("yyyy-MM-dd") + "'") + ",DocBank = " + (string.IsNullOrEmpty(ModelOtherDetails.DocBank) ? "null" : "'" + ModelOtherDetails.DocBank + "'") + ",LcNo = " + (string.IsNullOrEmpty(ModelOtherDetails.LcNo) ? "null" : "'" + ModelOtherDetails.LcNo + "'") + ",CustomName = " + (string.IsNullOrEmpty(ModelOtherDetails.CustomName) ? "null" : "'" + ModelOtherDetails.CustomName + "'") + ",Cofd = " + (string.IsNullOrEmpty(ModelOtherDetails.Cofd) ? "null" : "'" + ModelOtherDetails.Cofd + "'") + " Where VoucherNo = '" + Model.VoucherNo + "'\n");
				strSql.Append("UPDATE[ERP].[PurchaseChallanBillingAddress] SET LedgerId =" + ((ModelBillAddress.LedgerId == 0) ? "null" : "'" + ModelBillAddress.LedgerId + "'") + ", [BillingAddress] =" + (string.IsNullOrEmpty(ModelBillAddress.BillingAddress) ? "null" : "'" + ModelBillAddress.BillingAddress + "'") + ",[BillingCity] = " + (string.IsNullOrEmpty(ModelBillAddress.BillingCity) ? "null" : "'" + ModelBillAddress.BillingCity + "'") + ",[BillingState] = " + (string.IsNullOrEmpty(ModelBillAddress.BillingState) ? "null" : "'" + ModelBillAddress.BillingState + "'") + ",[BillingCountry] = " + (string.IsNullOrEmpty(ModelBillAddress.BillingCountry) ? "null" : "'" + ModelBillAddress.BillingCountry + "'") + ",[BillingEmail] = " + (string.IsNullOrEmpty(ModelBillAddress.BillingEmail) ? "null" : "'" + ModelBillAddress.BillingEmail + "'") + ",ShippingAddress=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingAddress) ? "null" : "'" + ModelBillAddress.ShippingAddress + "'") + ",ShippingCity=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingCity) ? "null" : "'" + ModelBillAddress.ShippingCity + "'") + ",ShippingState=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingState) ? "null" : "'" + ModelBillAddress.ShippingState + "'") + ",ShippingCountry=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingCountry) ? "null" : "'" + ModelBillAddress.ShippingCountry + "'") + ",ShippingEmail=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingEmail) ? "null" : "'" + ModelBillAddress.ShippingEmail + "'") + ",DeliveryDate=" + ((ModelBillAddress.DeliveryDate.ToString() == "") ? "null" : "'" + ModelBillAddress.DeliveryDate.ToString() + "'") + ", Remarks=" + (string.IsNullOrEmpty(ModelBillAddress.Remarks) ? "null" : "'" + ModelBillAddress.Remarks + "'") + " Where VoucherNo = '" + Model.VoucherNo + "' \n");

				strSql.Append("DELETE FROM [ERP].[PurchaseChallanDetails] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
				strSql.Append("DELETE FROM [ERP].[PurchaseChallanTerm] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");

			}
            else if (Model.Tag == "DELETE")
            {
				strSql.Append("Delete from ERP.InventoryTransaction Where Source = 'PC' and VoucherNo = @VoucherNo \n");
				strSql.Append("DELETE FROM [ERP].[PurchaseChallanTerm] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
                strSql.Append("DELETE FROM [ERP].[PurchaseChallanDetails] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
                strSql.Append("DELETE FROM [ERP].[PurchaseChallanBillingAddress] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
                strSql.Append("DELETE FROM [ERP].[PurchaseChallanOtherDetails] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
                strSql.Append("DELETE FROM [ERP].[PurchaseChallanMaster] WHERE VoucherNo = '" + Model.VoucherNo + "' \n");
                strSql.Append("SET @VoucherNo ='1'");
                ModelTerms.Clear();
                ModelDetails.Clear();
            }

            foreach (PurchaseChallanDetailsViewModel det in ModelDetails)
            {
                strSql.Append("INSERT INTO ERP.PurchaseChallanDetails(VoucherNo ,Sno,ProductId ,ProductAltUnit ,ProductUnit ,GodownId ,AltQty ,Qty ,PurchaseRate ,BasicAmount ,TermAmount ,NetAmount ,LocalNetAmount, AdditionalDesc ,ConversionRatio ,FreeQty ,FreeQtyUnit ,OrderNo ,OrderSNo ,QuotationNo ,QuotationSNo) \n");
                strSql.Append("Select @VoucherNo, '" + det.Sno + "', '" + det.ProductId + "'," + ((det.ProductAltUnit == 0) ? "null" : "'" + det.ProductAltUnit + "'") + ", " + ((det.ProductUnit == 0) ? "null" : "'" + det.ProductUnit + "'") + ", " + ((det.GodownId == 0) ? "null" : "'" + det.GodownId + "'") + ",'" + det.AltQty + "', '" + det.Qty + "', '" + det.PurchaseRate + "','" + det.BasicAmount + "', '" + det.TermAmount + "', '" + det.NetAmount + "', '" + det.LocalNetAmount + "','" + det.AdditionalDesc + "', '" + det.ConversionRatio + "' ,'" + det.FreeQty + "' ," + ((det.FreeQtyUnit == 0) ? "null" : "'" + det.FreeQtyUnit + "'") + " ,'" + det.OrderNo + "' ,'" + det.OrderSNo + "' ," + "'" + det.QuotationNo + "' ,'" + det.QuotationSNo + "' \n");

            }
            foreach (TermViewModel det in ModelTerms)
            {
                strSql.Append("INSERT INTO ERP.PurchaseChallanTerm(VoucherNo ,Sno ,ProductId ,TermId ,TermType ,PTSign ,TermRate ,TermAmt ,LocalTermAmt ) \n");
                strSql.Append("Select @VoucherNo, '" + det.Sno + "', " + ((det.ProductId == 0) ? "null" : "'" + det.ProductId + "'") + ", '" + det.TermId + "', '" + det.TermType + "', '" + det.PTSign + "', '" + det.TermRate + "', '" + det.TermAmt + "', '" + det.LocalTermAmt + "' \n");
            }
            ModelTerms.Clear();

            if (Model.UdfDetails.Rows.Count > 0)
            {
                strSql.Append("DELETE FROM ERP.UDFDataEntry WHERE VoucherNo=@VoucherNo AND EntryModule='PC' and SNO <> 0 \n");
                int _s = 0;
                foreach (DataRow ro in Model.UdfDetails.Rows)
                {
                    int j = 1;
                    for (int i = 0; i < (Model.UdfDetails.Columns.Count - 1) / 2; i++)
                    {
                        strSql.Append("INSERT INTO ERP.UDFDataEntry(VoucherNo,EntryModule,SNO,UDFCode,UDFData,ProductId) \n");
                        strSql.Append("Select @VoucherNo,'PC','" + ro[0].ToString() + "', ");
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
                strSql.Append("DELETE FROM ERP.UDFDataEntry WHERE VoucherNo=@VoucherNo AND EntryModule='PC' and SNO = 0 \n");
                foreach (DataRow ro in Model.UdfMaster.Rows)
                {
                    int j = 1;
                    for (int i = 0; i < (Model.UdfMaster.Columns.Count - 1) / 2; i++)
                    {
                        strSql.Append("INSERT INTO ERP.UDFDataEntry(VoucherNo,EntryModule,SNO,UDFCode,UDFData,ProductId) \n");
                        strSql.Append("Select @VoucherNo,'PC','0','" + ro[j].ToString() + "',");
                        j++;
                        strSql.Append("" + (string.IsNullOrEmpty(ro[j].ToString()) ? "null" : "'" + ro[j].ToString() + "'") + ",NULL \n");
                        j++;
                    }
                }
                Model.UdfMaster.Rows.Clear();
            }

            ModelDetails.Clear();

            //BT Posting
            strSql.Append("insert into erp.PurchaseChallanTerm(VoucherNo, TermId, Sno, ProductId, TermType, PTSign, TermRate, TermAmt, LocalTermAmt)  \n");
            strSql.Append("(Select @VoucherNo as VoucherNo, TermId as TermId, Sno, Pbd1.ProductId, 'BT' as TermType, PTSign, TermRate  \n");
            strSql.Append(", isnull(abs(sum((Amt * Pbd1.Bamt1) / Bamt)), 0) as TermAmt1, 0 as LocalTermAmt from erp.PurchaseChallanMaster as sm,  \n");
            strSql.Append("(Select Sno, SD.ProductId, SD.VoucherNo, sum(Case When SD.NetAmount <> 0 then SD.NetAmount else SD.BasicAmount end) as Bamt1 from erp.PurchaseChallanDetails as SD, erp.PurchaseChallanMaster as SM  where SD.VoucherNo = SM.VoucherNo  \n");
            strSql.Append("group by SD.ProductId, SD.VoucherNo, Sno) as Pbd1, (select SD.VoucherNo, CASE WHEN  sum(Case when SD.NetAmount <> 0 then SD.NetAmount * CurrencyRate else SD.BasicAmount * CurrencyRate end) = 0 THEN 1 ELSE sum(Case when SD.NetAmount<>0 then SD.NetAmount* CurrencyRate else SD.BasicAmount* CurrencyRate end ) END as Bamt from erp.PurchaseChallanDetails as SD,erp.PurchaseChallanMaster as SM  where SD.VoucherNo = SM.VoucherNo group by SD.VoucherNo) as Pbd,   \n");
            strSql.Append("(Select SD.VoucherNo,SD.TermId,SD.TermRate,sum((case when Ptm.PTSign = '+' then(SD.TermAmt * CurrencyRate) else -(SD.TermAmt * CurrencyRate) end)) as Amt,Ptm.PTSign from erp.PurchaseChallanTerm as SD, erp.PurchaseChallanMaster as Sm,erp.PurchaseBillingTerm as Ptm  \n");
            strSql.Append("where SD.VoucherNo = SM.VoucherNo and SD.TermId = Ptm.TermId and ProductId is Null and Basis <> 'Q' and Exists(Select* from erp.PurchaseChallanDetails as Pbd where SD.VoucherNo = Pbd.VoucherNo group by ProductId) and SD.VoucherNo = @VoucherNo  \n");
            strSql.Append("group by SD.VoucherNo,SD.TermId,SD.TermRate,Ptm.PTSign) as Trm where sm.VoucherNo = Pbd1.VoucherNo and sm.VoucherNo = Trm.VoucherNo And Pbd.VoucherNo = Trm.VoucherNo  group by Pbd1.ProductId,TermId,TermRate,Sno,Trm.PTSign  \n");
            strSql.Append("Union All  \n");
            strSql.Append("Select @VoucherNo as VoucherNo,TermId as TermId,Sno,Pbd.ProductId,'BT' as TermType,Trm.PTSign ,TermRate,isnull(abs(sum(Case when TotQty <> 0 then(Amt / TotQty) * Bamt end)), 0) as TermAmt1,0 as LocalTermAmt  \n");
            strSql.Append("from erp.PurchaseChallanMaster as Sm,(Select VoucherNo, Sum(Qty) as TotQty from erp.PurchaseChallanDetails group by VoucherNo) as SD,   \n");
            strSql.Append("(select Sno, ProductId, VoucherNo, sum(Qty) as Bamt from erp.PurchaseChallanDetails group by VoucherNo,ProductId,Sno) as Pbd,   \n");
            strSql.Append("(Select SD.VoucherNo,SD.TermId,SD.TermRate,sum((case when Ptm.PTSign = '+' then(SD.TermAmt * CurrencyRate) else -(SD.TermAmt * CurrencyRate) end)) as Amt,Ptm.PTSign  \n");
            strSql.Append("from erp.PurchaseChallanTerm as SD,erp.PurchaseChallanMaster as Sm,erp.PurchaseBillingTerm as Ptm where SD.VoucherNo = SM.VoucherNo and SD.TermId = Ptm.TermId and ProductId is Null and Basis = 'Q'  \n");
            strSql.Append("and Exists(Select* from erp.PurchaseChallanDetails as Pbd where SD.VoucherNo = Pbd.VoucherNo group by ProductId) and SD.VoucherNo = @VoucherNo group by SD.VoucherNo,SD.TermId,SD.TermRate,Ptm.PTSign) as Trm  \n");
            strSql.Append("Where SM.VoucherNo = Trm.VoucherNo And Pbd.VoucherNo = Trm.VoucherNo and sm.VoucherNo = SD.VoucherNo  \n");
            strSql.Append("group by Pbd.ProductId,TermId,TermRate,Sno,Trm.PTSign)  \n");

            strSql.Append("Update erp.PurchaseChallanTerm set LocalTermAmt = TermAmt * CurrencyRate from erp.PurchaseChallanMaster where erp.PurchaseChallanTerm.VoucherNo = erp.PurchaseChallanMaster.VoucherNo and erp.PurchaseChallanMaster.VoucherNo = @VoucherNo  \n");
            //strSql.Append("Update erp.PurchaseChallanDetails set TaxableAmount = (TaxableAmount - STerm.TermAmt) from(Select voucherno, sno, TermAmt, TermId from erp.PurchaseChallanterm  where voucherno = @VoucherNo and TermType = 'BT' and TermID = (Select  SBBillDiscountId from erp.SystemSetting ))STerm where STerm.voucherno = erp.PurchaseChallanDetails.VoucherNo and STerm.sno = erp.PurchaseChallanDetails.sno  \n");
            //strSql.Append("Update erp.PurchaseChallanDetails set VatAmount = STerm.TermAmt from(Select voucherno, sno, TermAmt, TermId from erp.PurchaseChallanterm  where voucherno = @VoucherNo and TermType = 'BT' and TermID = (Select  SBVatId from erp.SystemSetting ))STerm where STerm.VoucherNo = erp.PurchaseChallanDetails.VoucherNo and STerm.sno = erp.PurchaseChallanDetails.sno  \n");

            if (Model.Tag == "EDIT")
            {
                strSql.Append("Delete from ERP.InventoryTransaction Where Source = 'PC' and VoucherNo = @VoucherNo \n");
            }
            strSql.Append("Insert Into ERP.InventoryTransaction\n");
            strSql.Append("(VoucherNo, VDate, VMiti, VTime, LedgerId, SalesManId, DepartmentId1, DepartmentId2, DepartmentId3, CurrencyId, CurrencyRate, Sno, ProductId, GodownId, BranchId, CostCenterId, \n");
            strSql.Append("AltQuantity, AltUnitId, Quantity, ProductUnitId, AltStockQuantity, StockQuantity, FreeQuantity, StockFreeQuantity, FreeUnitId, ConversionRatio, Rate, BasicAmount, TermAmount, NetAmount, TransactionType, \n");
            strSql.Append("Source, GodownDetailId, DocumentValue, BillTerm, StockValue, TmpStockValue, ExtraFreeQty, ExtraStockFreeQty, ExtraFreeUnit, RefVoucherNo, ReferenceSource, Issueqty, IsBillCancel) \n");
            strSql.Append("Select SIM.VoucherNo,VDate,VMiti,VTime,LedgerId,SalesmanId,DepartmentId1,DepartmentId2,DepartmentId3, CurrencyId,CurrencyRate,Sno,ProductId,GodownId,BranchId, null as CostCenterId, \n");
            strSql.Append("AltQty,ProductAltUnit, Qty,ProductUnit,AltQty,Qty,0 as FreeQty,0 as StFreeQty,null as FreeUnitId ,1 as Ratio, [SID].PurchaseRate, [SID].BasicAmount,[SID].TermAmount as ProductTerm,[SID].NetAmount ,'I'as TransactionType  , \n");
            strSql.Append("'PC' as Source,SID.GodownId,0 as DocumentValue, SIM.TermAmount as BillTerm,0 as StockValue,0 as TmpStockValue, 0 as ExtraFreeQty, 0 as ExtraStockFreeQty,null as  ExtraFreeUnit,NULL as RefVoucherNo, NULL as ReferenceSource, 0 as  Issueqty, NULL as IsBillCancel \n");
            strSql.Append("from ERP.PurchaseChallanMaster SIM Left Outer Join ERP.PurchaseChallanDetails [SID] on[SID].VoucherNo= SIM.VoucherNo where ProductId in (Select ProductId from erp.Product where [ProductCategory] <> 'S') \n");
            strSql.Append("and SIM.VoucherNo=@VoucherNo \n");

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
            DataTable dt = DAL.ExecuteDataset(CommandType.Text, "select VoucherNo from erp.PurchaseChallanMaster WHERE VoucherNo='" + VoucherNo.Trim() + "'").Tables[0];
            if (dt.Rows.Count == 0)
                return "";
            else
                return dt.Rows[0]["VoucherNo"].ToString();
        }
		public string IsChallanUsedInBill(string VoucherNo)
		{
			DataTable dt = DAL.ExecuteDataset(CommandType.Text, "select top 1 ChallanNo from erp.PurchaseInvoiceDetails where ChallanNo = '" + VoucherNo.Trim() + "'").Tables[0];
			return dt.Rows.Count == 0 ? "" : dt.Rows[0]["ChallanNo"].ToString();
		}

		public DataSet GetDataPurchaseChallanVoucher(string VoucherNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Select PIM.*,GLDesc,GlCategory,SubledgerDesc,SalesmanDesc,D1.DepartmentId as DepartmentId1,D1.DepartmentDesc as DepartmentDesc1,D2.DepartmentId as DepartmentId2,D2.DepartmentDesc as DepartmentDesc2,D3.DepartmentId as DepartmentId3,D3.DepartmentDesc as DepartmentDesc3,D4.DepartmentId as DepartmentId4,D4.DepartmentDesc as DepartmentDesc4  \n");
            strSql.Append(", CurrencyDesc,BranchName,CU.CmpUnitName  \n");
            strSql.Append("from erp.PurchaseChallanMaster PIM  \n");
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

            strSql.Append("Select[PID].*,ProductShortName, ProductDesc,PD.AltConv,PAU.ProductUnitShortName as ProductAltUnitDesc,PU.ProductUnitShortName as ProductUnitDesc,GodownDesc from erp.PurchaseChallanDetails[PID] \n");
            strSql.Append("left join erp.Product PD on[PID].ProductId = PD.ProductId  \n");
            strSql.Append("left join erp.ProductUnit PU on[PID].ProductUnit = PU.ProductUnitId  \n");
            strSql.Append("left join erp.ProductUnit PAU on[PID].ProductAltUnit = PAU.ProductUnitId  \n");
            strSql.Append("left join erp.Godown GD on[PID].GodownId = GD.GodownId  \n");
            if (!string.IsNullOrEmpty(VoucherNo))
                strSql.Append(" where voucherNo='" + VoucherNo + "' \n");

            strSql.Append("Select * from erp.PurchaseChallanTerm  \n");
            if (!string.IsNullOrEmpty(VoucherNo))
                strSql.Append(" where voucherNo='" + VoucherNo + "' \n");

            strSql.Append("select* from[ERP].[UDFDataEntry] where VoucherNo = '" + VoucherNo + "' and EntryModule = 'PC'\n");

            strSql.Append("Select * from ERP.PurchaseChallanOtherDetails  where VoucherNo = '" + VoucherNo + "' \n");
            strSql.Append("Select * from ERP.PurchaseChallanBillingAddress  where VoucherNo = '" + VoucherNo + "' \n");

            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        public class PurchaseChallanMasterViewModel
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
            public string QuotationNo { get; set; }
            public string OrderNo { get; set; }
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
            
            public DataTable UdfDetails { get; set; }
            public DataTable UdfMaster { get; set; }
        }
        public class PurchaseChallanDetailsViewModel
        {
            public string VoucherNo { get; set; }
            public int Sno { get; set; }
            public int ProductId { get; set; }
            public int ProductAltUnit { get; set; }
            public int ProductUnit { get; set; }
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
            public string AdditionalDesc { get; set; }
            public decimal ConversionRatio { get; set; }
            public decimal FreeQty { get; set; }
            public int FreeQtyUnit { get; set; }
            public string OrderNo { get; set; }
            public int OrderSNo { get; set; }
            public string QuotationNo { get; set; }
            public int QuotationSNo { get; set; }
        }
        
    }
}
