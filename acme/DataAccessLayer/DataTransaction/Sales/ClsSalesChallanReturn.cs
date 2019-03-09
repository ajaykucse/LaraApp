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
    public class ClsSalesChallanReturn : ISalesChallanReturn
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public SalesChallanReturnMasterViewModel Model { get; set; }
        public List<SalesChallanReturnDetailsViewModel> ModelDetails { get; set; }
        public List<TermViewModel> ModelTerms { get; set; }
        public BillingAddressViewModel ModelBillAddress { get; set; }
        public OtherDetailsViewModel ModelOtherDetails { get; set; }

        public ClsSalesChallanReturn()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new SalesChallanReturnMasterViewModel();
            ModelDetails = new List<SalesChallanReturnDetailsViewModel>();
            ModelTerms = new List<TermViewModel>();
            ModelBillAddress = new BillingAddressViewModel();
            ModelOtherDetails = new OtherDetailsViewModel();

        }
        public string IsExistsVNumber(string VoucherNo)
        {
            DataTable dt = DAL.ExecuteDataset(CommandType.Text, "select VoucherNo from erp.SalesChallanReturnMaster WHERE VoucherNo='" + VoucherNo.Trim() + "'").Tables[0];
			return dt.Rows.Count == 0 ? "" : dt.Rows[0]["VoucherNo"].ToString();
		}
		public string SaveSalesChallanReturn()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");

            strSql.Append("Set @VoucherNo ='" + Model.VoucherNo.Trim() + "' \n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("INSERT INTO [ERP].[SalesChallanReturnMaster] ([VoucherNo],[VDate],[VTime],[VMiti],ReferenceNo,ReferenceDate,ReferenceMiti,[LedgerId] \n");
                strSql.Append(",[SubLedgerId],[SalesmanId],[DepartmentId1],[DepartmentId2],[DepartmentId3],[DepartmentId4],[CurrencyId],[CurrencyRate] \n");
                strSql.Append(",[BranchId],[CompanyUnitId],[BasicAmount],[TermAmount],[NetAmount],[LocalNetAmount],[PartyName],[PartyVatNo],[PartyAddress] \n");
                strSql.Append(",[PartyMobileNo],[ChequeNo],[ChequeDate],[ChequeMiti],[Remarks],[QuotationNo],[OrderNo],[EnterBy],[EnterDate],[IsReconcile]\n");
                strSql.Append(",[ReconcileBy],[ReconcileDate],[IsPosted],[PostedBy],[PostedDate],[IsAuthorized],[AuthorizedBy],[AuthorizedDate],[AuthorizeRemarks],[Gadget]) \n");

                strSql.Append("Select @VoucherNo,'" + Model.VDate.ToString("yyyy-MM-dd") + "','" + Model.VDate.ToString("yyyy-MM-dd") + ' ' + DateTime.Now.ToShortTimeString() + "','" + Model.VMiti.ToString() + "', " + ((Model.ReferenceNo == "") ? "null" : "'" + Model.ReferenceNo + "'") + "," + ((string.IsNullOrEmpty(Model.ReferenceDate.ToString())) ? "null" : "'" + Model.ReferenceDate.Value.ToString("yyyy-MM-dd") + "'") + ",'" + Model.ReferenceMiti.ToString() + "'," + ((Model.LedgerId == 0) ? "null" : "'" + Model.LedgerId + "'") + ", \n");
                strSql.Append("" + ((Model.SubLedgerId == 0) ? "null" : "'" + Model.SubLedgerId + "'") + ", " + ((Model.SalesmanId == 0) ? "null" : "'" + Model.SalesmanId + "'") + "," + ((Model.DepartmentId1 == 0) ? "null" : "'" + Model.DepartmentId1 + "'") + ", " + ((Model.DepartmentId2 == 0) ? "null" : "'" + Model.DepartmentId2 + "'") + " ," + ((Model.DepartmentId3 == 0) ? "null" : "'" + Model.DepartmentId3 + "'") + ", " + ((Model.DepartmentId4 == 0) ? "null" : "'" + Model.DepartmentId4 + "'") + ", " + ((Model.CurrencyId == 0) ? "null" : "'" + Model.CurrencyId + "'") + ",'" + (Model.CurrencyRate == 0 ? 1 : Model.CurrencyRate) + "', " + ((Model.BranchId == 0) ? "null" : "'" + Model.BranchId + "'") + "," + ((Model.CompanyUnitId == 0) ? "null" : "'" + Model.CompanyUnitId + "'") + ", \n");
                strSql.Append("'" + Model.BasicAmount + "','" + Model.TermAmount + "', '" + Model.NetAmount + "', '" + (Model.NetAmount * (Model.CurrencyRate == 0 ? 1 : Model.CurrencyRate)) + "' ,  \n");
                strSql.Append("" + (string.IsNullOrEmpty(Model.PartyName) ? "null" : "'" + Model.PartyName + "'") + ",  " + (string.IsNullOrEmpty(Model.PartyVatNo) ? "null" : "'" + Model.PartyVatNo + "'") + ",  " + (string.IsNullOrEmpty(Model.PartyAddress) ? "null" : "'" + Model.PartyAddress + "'") + ",  " + (string.IsNullOrEmpty(Model.PartyMobileNo) ? "null" : "'" + Model.PartyMobileNo + "'") + "," + (string.IsNullOrEmpty(Model.ChequeNo) ? "null" : "'" + Model.ChequeNo + "'") + ", " + ((string.IsNullOrEmpty(Model.ChequeDate.ToString())) ? "null" : "'" + Model.ChequeDate.Value.ToString("yyyy-MM-dd") + "'") + ",  " + (string.IsNullOrEmpty(Model.ChequeMiti) ? "null" : "'" + Model.ChequeMiti + "'") + ",\n");
                strSql.Append("" + (string.IsNullOrEmpty(Model.Remarks) ? "null" : "'" + Model.Remarks + "'") + ", " + (string.IsNullOrEmpty(Model.QuotationNo) ? "null" : "'" + Model.QuotationNo + "'") + ",  " + (string.IsNullOrEmpty(Model.OrderNo) ? "null" : "'" + Model.OrderNo + "'") + ", '" + Model.EnterBy + "', GETDATE(), '" + Model.IsReconcile + "'," + (string.IsNullOrEmpty(Model.ReconcileBy) ? "null" : "'" + Model.ReconcileBy + "'") + ",  " + ((Model.ReconcileDate.ToString() == "") ? "null" : "'" + Model.ReconcileDate.ToString() + "'") + ", '" + Model.IsPosted + "',  " + (string.IsNullOrEmpty(Model.PostedBy) ? "null" : "'" + Model.PostedBy + "'") + ",  " + ((Model.PostedDate.ToString() == "") ? "null" : "'" + Model.PostedDate.ToString() + "'") + ",'" + Model.IsAuthorized + "',  " + (string.IsNullOrEmpty(Model.AuthorizedBy) ? "null" : "'" + Model.AuthorizedBy + "'") + ", \n");
                strSql.Append("" + ((Model.AuthorizedDate.ToString() == "") ? "null" : "'" + Model.AuthorizedDate.ToString() + "'") + ",  " + (string.IsNullOrEmpty(Model.AuthorizeRemarks) ? "null" : "'" + Model.AuthorizeRemarks + "'") + ", '" + Model.Gadget + "' \n");

                strSql.Append("Update ERP.DocumentNumbering set DocCurrentNo = DocCurrentNo + 1 where DocId =" + Model.DocId + "\n");

                strSql.Append("INSERT INTO [ERP].[SalesChallanReturnOtherDetails]([VoucherNo],[Transport],[VehicleNo],[Package],[CnNo],[CnDate],[CnFreight],[CnType]\n");
                strSql.Append(",[Advance],[BalFreight],[DriverName],[DriverLicNo],[DriverMobileNo],[ContractNo],[ContractDate],[ExpInvNo],[ExpInvDate],[PoNo],[PoDate],[DocBank],[LcNo],[CustomName],[Cofd])\n");
                strSql.Append("Select @VoucherNo," + (string.IsNullOrEmpty(ModelOtherDetails.Transport) ? "null" : "'" + ModelOtherDetails.Transport + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.VehicleNo) ? "null" : "'" + ModelOtherDetails.VehicleNo + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.Package) ? "null" : "'" + ModelOtherDetails.Package + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.CnNo) ? "null" : "'" + ModelOtherDetails.CnNo + "'") + "," + ((Convert.ToDateTime(ModelOtherDetails.CnDate).ToString() == "") ? "null" : "'" + Convert.ToDateTime(ModelOtherDetails.CnDate).ToString("yyyy-MM-dd") + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.CnFreight) ? "null" : "'" + ModelOtherDetails.CnFreight + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.CnType) ? "null" : "'" + ModelOtherDetails.CnType + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.Advance) ? "null" : "'" + ModelOtherDetails.Advance + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.BalFreight) ? "null" : "'" + ModelOtherDetails.BalFreight + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.DriverName) ? "null" : "'" + ModelOtherDetails.DriverName + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.DriverLicNo) ? "null" : "'" + ModelOtherDetails.DriverLicNo + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.DriverMobileNo) ? "null" : "'" + ModelOtherDetails.DriverMobileNo + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.ContractNo) ? "null" : "'" + ModelOtherDetails.ContractNo + "'") + "," + ((Convert.ToDateTime(ModelOtherDetails.ContractDate).ToString("yyyy-MM-dd") == null) ? "null" : "'" + Convert.ToDateTime(ModelOtherDetails.ContractDate).ToString("yyyy-MM-dd") + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.ExpInvNo) ? "null" : "'" + ModelOtherDetails.ExpInvNo + "'") + "," + ((Convert.ToDateTime(ModelOtherDetails.ExpInvDate).ToString("yyyy-MM-dd") == null) ? "null" : "'" + Convert.ToDateTime(ModelOtherDetails.ExpInvDate).ToString("yyyy-MM-dd") + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.PoNo) ? "null" : "'" + ModelOtherDetails.PoNo + "'") + "," + ((Convert.ToDateTime(ModelOtherDetails.PoDate).ToString("yyyy-MM-dd") == null) ? "null" : "'" + Convert.ToDateTime(ModelOtherDetails.PoDate).ToString("yyyy-MM-dd") + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.DocBank) ? "null" : "'" + ModelOtherDetails.DocBank + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.LcNo) ? "null" : "'" + ModelOtherDetails.LcNo + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.CustomName) ? "null" : "'" + ModelOtherDetails.CustomName + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.Cofd) ? "null" : "'" + ModelOtherDetails.Cofd + "'") + " \n");
                strSql.Append("INSERT INTO[ERP].[SalesChallanReturnBillingAddress] ([VoucherNo],[LedgerId],[BillingAddress],[BillingCity],[BillingState],[BillingCountry],[BillingEmail],[ShippingAddress],[ShippingCity],[ShippingState],[ShippingCountry],[ShippingEmail],[DeliveryDate],[Remarks])\n");
                strSql.Append("Select @VoucherNo," + ((ModelBillAddress.LedgerId == 0) ? "null" : "'" + ModelBillAddress.LedgerId + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingAddress) ? "null" : "'" + ModelBillAddress.BillingAddress + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingCity) ? "null" : "'" + ModelBillAddress.BillingCity + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingState) ? "null" : "'" + ModelBillAddress.BillingState + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingCountry) ? "null" : "'" + ModelBillAddress.BillingCountry + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingEmail) ? "null" : "'" + ModelBillAddress.BillingEmail + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingAddress) ? "null" : "'" + ModelBillAddress.ShippingAddress + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingCity) ? "null" : "'" + ModelBillAddress.ShippingCity + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingState) ? "null" : "'" + ModelBillAddress.ShippingState + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingCountry) ? "null" : "'" + ModelBillAddress.ShippingCountry + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingEmail) ? "null" : "'" + ModelBillAddress.ShippingEmail + "'") + "," + ((ModelBillAddress.DeliveryDate.ToString() == "") ? "null" : "'" + ModelBillAddress.DeliveryDate.ToString() + "'") + ", " + (string.IsNullOrEmpty(ModelBillAddress.Remarks) ? "null" : "'" + ModelBillAddress.Remarks + "'") + " \n");
            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP.SalesChallanReturnMaster SET VDate='" + Model.VDate.ToString("yyyy-MM-dd") + "',VMiti='" + Model.VMiti.ToString() + "',ReferenceNo= " + ((Model.ReferenceNo == "") ? "null" : "'" + Model.ReferenceNo + "'") + ",ReferenceDate='" + Model.VDate.ToString("yyyy-MM-dd") + "', ReferenceMiti='" + Model.VMiti.ToString() + "',LedgerId= " + ((Model.LedgerId == 0) ? "null" : "'" + Model.LedgerId + "'") + ", \n");
                strSql.Append("SubLedgerId=" + ((Model.SubLedgerId == 0) ? "null" : "'" + Model.SubLedgerId + "'") + ",SalesmanId= " + ((Model.SalesmanId == 0) ? "null" : "'" + Model.SalesmanId + "'") + ", DepartmentId1=" + ((Model.DepartmentId1 == 0) ? "null" : "'" + Model.DepartmentId1 + "'") + ", DepartmentId2=" + ((Model.DepartmentId2 == 0) ? "null" : "'" + Model.DepartmentId2 + "'") + ", DepartmentId3=" + ((Model.DepartmentId3 == 0) ? "null" : "'" + Model.DepartmentId3 + "'") + ", DepartmentId4=" + ((Model.DepartmentId4 == 0) ? "null" : "'" + Model.DepartmentId4 + "'") + ", CurrencyId=" + ((Model.CurrencyId == 0) ? "null" : "'" + Model.CurrencyId + "'") + ",CurrencyRate='" + (Model.CurrencyRate == 0 ? 1 : Model.CurrencyRate) + "', BranchId= " + ((Model.BranchId == 0) ? "null" : "'" + Model.BranchId + "'") + ",CompanyUnitId=" + ((Model.CompanyUnitId == 0) ? "null" : "'" + Model.CompanyUnitId + "'") + ", \n");
                strSql.Append("BasicAmount='" + Model.BasicAmount + "',TermAmount='" + Model.TermAmount + "',NetAmount= '" + Model.NetAmount + "' ,LocalNetAmount ='" + (Model.NetAmount * (Model.CurrencyRate == 0 ? 1 : Model.CurrencyRate)) + "',  \n");
                strSql.Append("PartyName=" + ((Model.PartyName == "") ? "null" : "'" + Model.PartyName + "'") + ", PartyVatNo= " + (string.IsNullOrEmpty(Model.PartyVatNo) ? "null" : "'" + Model.PartyVatNo + "'") + ", PartyAddress= " + (string.IsNullOrEmpty(Model.PartyAddress) ? "null" : "'" + Model.PartyAddress + "'") + ", PartyMobileNo= " + (string.IsNullOrEmpty(Model.PartyMobileNo) ? "null" : "'" + Model.PartyMobileNo + "'") + ",ChequeNo=" + (string.IsNullOrEmpty(Model.ChequeNo) ? "null" : "'" + Model.ChequeNo + "'") + ",ChequeDate= " + ((string.IsNullOrEmpty(Model.ChequeDate.ToString())) ? "null" : "'" + Model.ChequeDate.Value.ToString("yyyy-MM-dd") + "'") + ", ChequeMiti= " + (string.IsNullOrEmpty(Model.ChequeMiti) ? "null" : "'" + Model.ChequeMiti + "'") + ",\n");
                strSql.Append("Remarks=" + (string.IsNullOrEmpty(Model.Remarks) ? "null" : "'" + Model.Remarks + "'") + ", QuotationNo=" + (string.IsNullOrEmpty(Model.QuotationNo) ? "null" : "'" + Model.QuotationNo + "'") + ",  OrderNo=" + (string.IsNullOrEmpty(Model.OrderNo) ? "null" : "'" + Model.OrderNo + "'") + ", ReconcileBy= " + (string.IsNullOrEmpty(Model.ReconcileBy) ? "null" : "'" + Model.ReconcileBy + "'") + ",  ReconcileDate=" + ((string.IsNullOrEmpty(Model.ReconcileDate.ToString())) ? "null" : "'" + Model.ReconcileDate.Value.ToString("yyyy-MM-dd") + "'") + ", IsPosted='" + Model.IsPosted + "', PostedBy= " + (string.IsNullOrEmpty(Model.PostedBy) ? "null" : "'" + Model.PostedBy + "'") + ",  PostedDate=" + ((string.IsNullOrEmpty(Model.PostedDate.ToString())) ? "null" : "'" + Model.PostedDate.Value.ToString("yyyy-MM-dd") + "'") + ",IsAuthorized='" + Model.IsAuthorized + "', AuthorizedBy= " + (string.IsNullOrEmpty(Model.AuthorizedBy) ? "null" : "'" + Model.AuthorizedBy + "'") + ", \n");
                strSql.Append("AuthorizedDate= " + ((string.IsNullOrEmpty(Model.AuthorizedDate.ToString())) ? "null" : "'" + Model.AuthorizedDate.Value.ToString("yyyy-MM-dd") + "'") + ", AuthorizeRemarks= " + (string.IsNullOrEmpty(Model.AuthorizeRemarks) ? "null" : "'" + Model.AuthorizeRemarks.Trim() + "'") + ", Gadget='" + Model.Gadget.Trim() + "'  WHERE VoucherNo = '" + Model.VoucherNo + "' \n");
                strSql.Append("UPDATE [ERP].[SalesChallanReturnOtherDetails] SET Transport = " + (string.IsNullOrEmpty(ModelOtherDetails.Transport) ? "null" : "'" + ModelOtherDetails.Transport + "'") + ",VehicleNo = " + (string.IsNullOrEmpty(ModelOtherDetails.VehicleNo) ? "null" : "'" + ModelOtherDetails.VehicleNo + "'") + ",Package = " + (string.IsNullOrEmpty(ModelOtherDetails.Package) ? "null" : "'" + ModelOtherDetails.Package + "'") + ",CnNo = " + (string.IsNullOrEmpty(ModelOtherDetails.CnNo) ? "null" : "'" + ModelOtherDetails.CnNo + "'") + ",CnDate = " + ((string.IsNullOrEmpty(ModelOtherDetails.CnDate.ToString())) ? "null" : "'" + ModelOtherDetails.CnDate.Value.ToString("yyyy-MM-dd") + "'") + ",CnFreight = " + (string.IsNullOrEmpty(ModelOtherDetails.CnFreight) ? "null" : "'" + ModelOtherDetails.CnFreight + "'") + ",CnType = " + (string.IsNullOrEmpty(ModelOtherDetails.CnType) ? "null" : "'" + ModelOtherDetails.CnType + "'") + ",Advance = " + (string.IsNullOrEmpty(ModelOtherDetails.Advance) ? "null" : "'" + ModelOtherDetails.Advance + "'") + ",BalFreight = " + (string.IsNullOrEmpty(ModelOtherDetails.BalFreight) ? "null" : "'" + ModelOtherDetails.BalFreight + "'") + ",DriverName = " + (string.IsNullOrEmpty(ModelOtherDetails.DriverName) ? "null" : "'" + ModelOtherDetails.DriverName + "'") + ",DriverLicNo = " + (string.IsNullOrEmpty(ModelOtherDetails.DriverLicNo) ? "null" : "'" + ModelOtherDetails.DriverLicNo + "'") + ",DriverMobileNo = " + (string.IsNullOrEmpty(ModelOtherDetails.DriverMobileNo) ? "null" : "'" + ModelOtherDetails.DriverMobileNo + "'") + ",ContractNo = " + (string.IsNullOrEmpty(ModelOtherDetails.ContractNo) ? "null" : "'" + ModelOtherDetails.ContractNo + "'") + ",ContractDate = " + ((string.IsNullOrEmpty(ModelOtherDetails.ContractDate.ToString())) ? "null" : "'" + ModelOtherDetails.ContractDate.Value.ToString("yyyy-MM-dd") + "'") + ",ExpInvNo = " + (string.IsNullOrEmpty(ModelOtherDetails.ExpInvNo) ? "null" : "'" + ModelOtherDetails.ExpInvNo + "'") + ",ExpInvDate = " + ((string.IsNullOrEmpty(ModelOtherDetails.ExpInvDate.ToString())) ? "null" : "'" + ModelOtherDetails.ExpInvDate.Value.ToString("yyyy-MM-dd") + "'") + ",PoNo = " + (string.IsNullOrEmpty(ModelOtherDetails.PoNo) ? "null" : "'" + ModelOtherDetails.PoNo + "'") + ",PoDate = " + ((string.IsNullOrEmpty(ModelOtherDetails.PoDate.ToString())) ? "null" : "'" + ModelOtherDetails.PoDate.Value.ToString("yyyy-MM-dd") + "'") + ",DocBank = " + (string.IsNullOrEmpty(ModelOtherDetails.DocBank) ? "null" : "'" + ModelOtherDetails.DocBank + "'") + ",LcNo = " + (string.IsNullOrEmpty(ModelOtherDetails.LcNo) ? "null" : "'" + ModelOtherDetails.LcNo + "'") + ",CustomName = " + (string.IsNullOrEmpty(ModelOtherDetails.CustomName) ? "null" : "'" + ModelOtherDetails.CustomName + "'") + ",Cofd = " + (string.IsNullOrEmpty(ModelOtherDetails.Cofd) ? "null" : "'" + ModelOtherDetails.Cofd + "'") + "  WHERE VoucherNo = '" + Model.VoucherNo + "'\n");
                strSql.Append("UPDATE[ERP].[SalesChallanReturnBillingAddress] SET LedgerId =" + ((ModelBillAddress.LedgerId == 0) ? "null" : "'" + ModelBillAddress.LedgerId + "'") + ", [BillingAddress] =" + (string.IsNullOrEmpty(ModelBillAddress.BillingAddress) ? "null" : "'" + ModelBillAddress.BillingAddress + "'") + ",[BillingCity] = " + (string.IsNullOrEmpty(ModelBillAddress.BillingCity) ? "null" : "'" + ModelBillAddress.BillingCity + "'") + ",[BillingState] = " + (string.IsNullOrEmpty(ModelBillAddress.BillingState) ? "null" : "'" + ModelBillAddress.BillingState + "'") + ",[BillingCountry] = " + (string.IsNullOrEmpty(ModelBillAddress.BillingCountry) ? "null" : "'" + ModelBillAddress.BillingCountry + "'") + ",[BillingEmail] = " + (string.IsNullOrEmpty(ModelBillAddress.BillingEmail) ? "null" : "'" + ModelBillAddress.BillingEmail + "'") + ",ShippingAddress=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingAddress) ? "null" : "'" + ModelBillAddress.ShippingAddress + "'") + ",ShippingCity=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingCity) ? "null" : "'" + ModelBillAddress.ShippingCity + "'") + ",ShippingState=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingState) ? "null" : "'" + ModelBillAddress.ShippingState + "'") + ",ShippingCountry=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingCountry) ? "null" : "'" + ModelBillAddress.ShippingCountry + "'") + ",ShippingEmail=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingEmail) ? "null" : "'" + ModelBillAddress.ShippingEmail + "'") + ",DeliveryDate=" + ((ModelBillAddress.DeliveryDate.ToString() == "") ? "null" : "'" + ModelBillAddress.DeliveryDate.ToString() + "'") + ", Remarks=" + (string.IsNullOrEmpty(ModelBillAddress.Remarks) ? "null" : "'" + ModelBillAddress.Remarks + "'") + "  WHERE VoucherNo = '" + Model.VoucherNo + "' \n");
            }
            else if (Model.Tag == "DELETE")
            {
                strSql.Append("Delete FROM [ERP].InventoryTransaction Where Source = 'SB' and VoucherNo = @VoucherNo \n");
                strSql.Append("DELETE FROM [ERP].[SalesChallanReturnTerm] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
                strSql.Append("DELETE FROM [ERP].[SalesChallanReturnDetails] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
                strSql.Append("DELETE FROM [ERP].[SalesChallanReturnBillingAddress] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
                strSql.Append("DELETE FROM [ERP].[SalesChallanReturnOtherDetails] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
                strSql.Append("DELETE FROM [ERP].[SalesChallanReturnMaster] WHERE VoucherNo = '" + Model.VoucherNo + "' \n");
                strSql.Append("SET @VoucherNo ='1'");
                ModelTerms.Clear();
                ModelDetails.Clear();
            }

            if (Model.Tag == "EDIT")
                strSql.Append("DELETE FROM [ERP].[SalesChallanReturnDetails] WHERE VoucherNo =@VoucherNo \n");
            foreach (SalesChallanReturnDetailsViewModel det in ModelDetails)
            {
                strSql.Append("INSERT INTO [ERP].[SalesChallanReturnDetails]([VoucherNo],[Sno],[ProductId],[ProductAltUnit],[ProductUnit],[GodownId],[AltQty],[Qty],[SalesRate],[BasicAmount],[TermAmount],[NetAmount],[LocalNetAmount],[AdditionalDesc],[ConversionRatio],[FreeQty],[FreeQtyUnit],[OrderNo],[OrderSNo],[DispatchOrderNo],[DispatchOrderSNo],QuotationNo,QuotationSno, ChallanNo, ChallanSNo) \n");
                strSql.Append("Select @VoucherNo, '" + det.Sno + "', '" + det.ProductId + "'," + ((det.ProductAltUnit == 0) ? "null" : "'" + det.ProductAltUnit + "'") + ", " + ((det.ProductUnit == 0) ? "null" : "'" + det.ProductUnit + "'") + ", " + ((det.GodownId == 0) ? "null" : "'" + det.GodownId + "'") + ",'" + det.AltQty + "', '" + det.Qty + "', '" + det.SalesRate + "', '" + det.BasicAmount + "', '" + det.TermAmount + "', '" + det.NetAmount + "', '" + det.LocalNetAmount + "', '" + det.AdditionalDesc + "','" + det.ConversionRatio + "', '" + det.FreeQty + "',  " + ((det.FreeQtyUnit == 0) ? "null" : "'" + det.FreeQtyUnit + "'") + ",  " + (string.IsNullOrEmpty(det.OrderNo) ? "null" : "'" + det.OrderNo + "'") + ",  " + ((det.OrderSNo == 0) ? "null" : "'" + det.OrderSNo + "'") + ",  " + (string.IsNullOrEmpty(det.DispatchOrderNo) ? "null" : "'" + det.DispatchOrderNo + "'") + ",  " + ((det.DispatchOrderSNo == 0) ? "null" : "'" + det.DispatchOrderSNo + "'") + "," + (string.IsNullOrEmpty(det.QuotationNo) ? "null" : "'" + det.QuotationNo + "'") + "," + ((det.QuotationSNo == 0) ? "null" : "'" + det.QuotationSNo + "'")+ ", " + (string.IsNullOrEmpty(det.ChallanNo) ? "null" : "'" + det.ChallanNo + "'") + "," + ((det.ChallanSNo == 0) ? "null" : "'" + det.ChallanSNo + "'") + " \n");
            }

            if (ModelTerms.Count > 0)
            {
                strSql.Append("DELETE FROM [ERP].[SalesChallanReturnTerm] WHERE VoucherNo =@VoucherNo \n");
                foreach (TermViewModel det in ModelTerms)
                {
                    strSql.Append("INSERT INTO ERP.SalesChallanReturnTerm(VoucherNo, Sno, ProductId, TermId, TermType, STSign, TermRate, TermAmt, LocalTermAmt) \n");
                    strSql.Append("Select @VoucherNo, '" + det.Sno + "', " + ((det.ProductId == 0) ? "null" : "'" + det.ProductId + "'") + ", '" + det.TermId + "', '" + det.TermType + "', '" + det.STSign + "', '" + det.TermRate + "', '" + det.TermAmt + "', '" + det.LocalTermAmt + "' \n");
                }
                ModelTerms.Clear();
            }

            if (Model.UdfDetails != null)
            {
                if (Model.UdfDetails.Rows.Count > 0)
                {
                    strSql.Append("DELETE FROM ERP.UDFDataEntry WHERE VoucherNo=@VoucherNo AND EntryModule='SC' AND SNO<>0 \n");
                    int _s = 0;
                    foreach (DataRow ro in Model.UdfDetails.Rows)
                    {
                        int j = 1;
                        for (int i = 0; i < (Model.UdfDetails.Columns.Count - 1) / 2; i++)
                        {
                            strSql.Append("INSERT INTO ERP.UDFDataEntry(VoucherNo,EntryModule,SNO,UDFCode,UDFData,ProductId) \n");
                            strSql.Append("Select @VoucherNo,'SC','" + ro[0].ToString() + "', ");
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
            }

            if (Model.UdfMaster != null)
            {
                if (Model.UdfMaster.Rows.Count > 0)
                {
                    strSql.Append("DELETE FROM ERP.UDFDataEntry WHERE VoucherNo=@VoucherNo AND EntryModule='SC' AND SNO=0 \n");
                    foreach (DataRow ro in Model.UdfMaster.Rows)
                    {
                        int j = 1;
                        for (int i = 0; i < (Model.UdfMaster.Columns.Count - 1) / 2; i++)
                        {
                            strSql.Append("INSERT INTO ERP.UDFDataEntry(VoucherNo,EntryModule,SNO,UDFCode,UDFData,ProductId) \n");
                            strSql.Append("Select @VoucherNo,'SC','0','" + ro[j].ToString() + "',");
                            j++;
                            strSql.Append("" + (string.IsNullOrEmpty(ro[j].ToString()) ? "null" : "'" + ro[j].ToString() + "'") + ",NULL \n");
                            j++;
                        }
                    }
                    Model.UdfMaster.Rows.Clear();
                }
            }

            ModelDetails.Clear();

            //BT Posting
            strSql.Append("Insert into erp.SalesChallanReturnTerm(VoucherNo, TermId, Sno, ProductId, TermType, STSign, TermRate, TermAmt) \n");
            strSql.Append("(Select @VoucherNo as VoucherNo, TermId as TermId, Sno, SBD1.ProductId, 'BT' as TermType, STSign, TermRate \n");
            strSql.Append(", isnull(abs(sum((Amt * SBD1.Bamt1) / Bamt)), 0) as TermAmt1 from erp.SalesChallanReturnMaster as scm, \n");
            strSql.Append("(Select Sno, SCD.ProductId, SCD.VoucherNo, sum(Case When SCD.NetAmount <> 0 then SCD.NetAmount else SCD.BasicAmount end) as Bamt1 \n");
            strSql.Append(" from erp.SalesChallanReturnDetails as SCD, erp.SalesChallanReturnMaster as scm  \n");
            strSql.Append(" where SCD.VoucherNo = scm.VoucherNo   \n");
            strSql.Append("group by SCD.ProductId, SCD.VoucherNo, Sno) as SBD1, (select SCD.VoucherNo, CASE WHEN  sum(Case when SCD.NetAmount <> 0 then SCD.NetAmount * CurrencyRate else SCD.BasicAmount * CurrencyRate end) = 0 THEN 1 ELSE sum(Case when SCD.NetAmount<>0 then SCD.NetAmount* CurrencyRate else SCD.BasicAmount* CurrencyRate end ) END as Bamt from erp.SalesChallanReturnDetails as SCD,erp.SalesChallanReturnMaster as scm  where SCD.VoucherNo = scm.VoucherNo group by SCD.VoucherNo) as Sbd, \n");
            strSql.Append("(Select SCD.VoucherNo,SCD.TermId,SCD.TermRate,sum((case when STM.STSign = '+' then(SCD.TermAmt * CurrencyRate) else -(SCD.TermAmt * CurrencyRate) end)) as Amt,Stm.STSign from erp.SalesInvoiceTerm as SCD, erp.SalesChallanReturnMaster as scm,erp.SalesBillingTerm as Stm \n");
            strSql.Append("where SCD.VoucherNo = scm.VoucherNo and SCD.TermId = STM.TermId and ProductId is Null and Basis <> 'Q' and Exists(Select* from erp.SalesChallanReturnDetails as SBD where SCD.VoucherNo = SBD.VoucherNo group by ProductId) and SCD.VoucherNo = @VoucherNo \n");
            strSql.Append("group by SCD.VoucherNo,SCD.TermId,SCD.TermRate,STM.STSign) as Trm where scm.VoucherNo = SBD1.VoucherNo and scm.VoucherNo = Trm.VoucherNo And Sbd.VoucherNo = Trm.VoucherNo  group by SBD1.ProductId,TermId,TermRate,Sno,Trm.STSign \n");
            strSql.Append("Union All \n");
            strSql.Append("Select @VoucherNo as VoucherNo,TermId as TermId,Sno,Sbd.ProductId,'BT' as TermType,Trm.STSign ,TermRate,isnull(abs(sum(Case when TotQty <> 0 then(Amt / TotQty) * Bamt end)), 0) as TermAmt1 \n");
            strSql.Append("from erp.SalesChallanReturnMaster as scm,(Select VoucherNo, Sum(Qty) as TotQty from erp.SalesChallanReturnDetails group by VoucherNo) as SCD, \n");
            strSql.Append("(select Sno, ProductId, VoucherNo, sum(Qty) as Bamt from erp.SalesChallanReturnDetails group by VoucherNo,ProductId,Sno) as Sbd, \n");
            strSql.Append("(Select SCD.VoucherNo,SCD.TermId,SCD.TermRate,sum((case when STM.STSign = '+' then(SCD.TermAmt * CurrencyRate) else -(SCD.TermAmt * CurrencyRate) end)) as Amt,Stm.STSign  \n");
            strSql.Append("from erp.SalesInvoiceTerm as SCD,erp.SalesChallanReturnMaster as scm,erp.SalesBillingTerm as Stm where SCD.VoucherNo = scm.VoucherNo and SCD.TermId = STM.TermId and ProductId is Null and Basis = 'Q'  \n");
            strSql.Append("and Exists(Select* from erp.SalesChallanReturnDetails as SBD where SCD.VoucherNo = SBD.VoucherNo group by ProductId) and SCD.VoucherNo = @VoucherNo group by SCD.VoucherNo,SCD.TermId,SCD.TermRate,STm.STSign) as Trm  \n");
            strSql.Append("Where scm.VoucherNo = Trm.VoucherNo And Sbd.VoucherNo = Trm.VoucherNo and scm.VoucherNo = SCD.VoucherNo \n");
            strSql.Append("group by Sbd.ProductId,TermId,TermRate,Sno,Trm.STSign) \n");


            if (Model.Tag == "EDIT")
            {
                strSql.Append("Delete from ERP.InventoryTransaction Where Source = 'SC' and VoucherNo = @VoucherNo \n");
            }

            strSql.Append("Insert Into ERP.InventoryTransaction  \n");
            strSql.Append("(VoucherNo, VDate, VMiti, VTime, LedgerId, SalesManId, DepartmentId1, DepartmentId2, DepartmentId3, CurrencyId, CurrencyRate, Sno, ProductId, GodownId, BranchId, CostCenterId, \n");
            strSql.Append("AltQuantity, AltUnitId, Quantity, ProductUnitId, AltStockQuantity, StockQuantity, FreeQuantity, StockFreeQuantity, FreeUnitId, ConversionRatio, Rate, BasicAmount, TermAmount, NetAmount, TransactionType, \n");
            strSql.Append("Source, GodownDetailId, DocumentValue, BillTerm, StockValue, TmpStockValue, ExtraFreeQty, ExtraStockFreeQty, ExtraFreeUnit, RefVoucherNo, ReferenceSource, Issueqty,IsBillCancel) \n");
            strSql.Append("Select SCM.VoucherNo,VDate,VMiti,VTime,LedgerId,SalesmanId,DepartmentId1,DepartmentId2,DepartmentId3, CurrencyId,CurrencyRate,Sno,ProductId,GodownId,BranchId, null as CostCenterId, \n");
            strSql.Append("AltQty,ProductAltUnit, Qty,ProductUnit,AltQty,Qty,0 as FreeQty,0 as StFreeQty,null as FreeUnitId ,1 as Ratio, [SCD].SalesRate, [SCD].BasicAmount,[SCD].TermAmount as ProductTerm,[SCD].NetAmount ,'O'as TransactionType  , \n");
            strSql.Append("'SC' as Source,SCD.GodownId,0 as DocumentValue, SCM.TermAmount as BillTerm,0 as StockValue,0 as TmpStockValue, 0 as ExtraFreeQty, 0 as ExtraStockFreeQty,null as  ExtraFreeUnit,null as RefVoucherNo, null as ReferenceSource, 0 as  Issueqty, null as IsBillCancel \n");
            strSql.Append("from ERP.SalesChallanReturnMaster SCM Left Outer Join ERP.SalesChallanReturnDetails [SCD] on[SCD].VoucherNo= SCM.VoucherNo where ProductId in (Select ProductId from erp.Product where [ProductCategory] <> 'S') \n");
            strSql.Append("and SCM.VoucherNo=@VoucherNo \n");


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
        public DataSet GetDataSalesChallanReturnVoucher(string VoucherNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Select SCM.*,GLDesc,SubledgerDesc,SalesmanDesc,D1.DepartmentId as DepartmentId1,D1.DepartmentDesc as DepartmentDesc1,D2.DepartmentId as DepartmentId2,D2.DepartmentDesc as DepartmentDesc2,D3.DepartmentId as DepartmentId3,D3.DepartmentDesc as DepartmentDesc3,D4.DepartmentId as DepartmentId4,D4.DepartmentDesc as DepartmentDesc4,  \n");
            strSql.Append(" CurrencyDesc,BranchName,CU.CmpUnitName  \n");
            strSql.Append("from erp.SalesChallanReturnMaster SCM  \n");
            strSql.Append("left Join erp.GeneralLedger GL on SCM.ledgerId = GL.LedgerID  \n");
            strSql.Append("left Join erp.Subledger SGL on SCM.SubledgerId = SGL.SubledgerId  \n");
            strSql.Append("left Join erp.Salesman SM on SCM.SalesmanId = SM.SalesmanId \n");
            strSql.Append("left Join erp.Department D1 on SCM.DepartmentId1 = D1.DepartmentID  \n");
            strSql.Append("left Join erp.Department D2  on SCM.DepartmentId2 = D2.DepartmentID  \n");
            strSql.Append("left Join erp.Department D3 on SCM.DepartmentId3 = D3.DepartmentID  \n");
            strSql.Append("left Join erp.Department D4 on SCM.DepartmentId4 = D4.DepartmentID  \n");
            strSql.Append("left Join erp.Currency CY on SCM.CurrencyId = CY.CurrencyId  \n");
            strSql.Append("left Join erp.Branch BR on SCM.BranchId = BR.BranchId  \n");
            strSql.Append("left Join erp.CompanyUnit CU on SCM.CompanyUnitId = CU.CompanyUnitId \n");
            if (!string.IsNullOrEmpty(VoucherNo))
                strSql.Append(" where voucherNo='" + VoucherNo + "' \n");

            strSql.Append("Select [SCD].*,ProductShortName, ProductDesc,PD.AltConv,PAU.ProductUnitDesc as ProductAltUnitDesc,PU.ProductUnitDesc as ProductUnitDesc,GodownDesc from erp.SalesChallanReturnDetails [SCD] \n");
            strSql.Append("left join erp.Product PD on [SCD].ProductId = PD.ProductId  \n");
            strSql.Append("left join erp.ProductUnit PU on [SCD].ProductUnit = PU.ProductUnitId  \n");
            strSql.Append("left join erp.ProductUnit PAU on [SCD].ProductAltUnit = PAU.ProductUnitId  \n");
            strSql.Append("left join erp.Godown GD on [SCD].GodownId = GD.GodownId  \n");
            if (!string.IsNullOrEmpty(VoucherNo))
                strSql.Append(" where voucherNo='" + VoucherNo + "' \n");

            strSql.Append("Select * from erp.SalesChallanReturnTerm  \n");
            if (!string.IsNullOrEmpty(VoucherNo))
                strSql.Append(" where voucherNo='" + VoucherNo + "' \n");

            strSql.Append("select* from[ERP].[UDFDataEntry] where VoucherNo = '" + VoucherNo + "' and EntryModule = 'SC'\n");

            strSql.Append("Select * from ERP.SalesChallanReturnOtherDetails  where VoucherNo = '" + VoucherNo + "' \n");
            strSql.Append("Select * from ERP.SalesChallanReturnBillingAddress  where VoucherNo = '" + VoucherNo + "' \n");


            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString());
        }
        public DataSet GetDataSalesChallanVoucherDataForReturn(string VoucherNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Select PIM.*,GLDesc,GlCategory,SubledgerDesc,SalesmanDesc,D1.DepartmentId as DepartmentId1,D1.DepartmentDesc as DepartmentDesc1,D2.DepartmentId as DepartmentId2,D2.DepartmentDesc as DepartmentDesc2,D3.DepartmentId as DepartmentId3,D3.DepartmentDesc as DepartmentDesc3,D4.DepartmentId as DepartmentId4,D4.DepartmentDesc as DepartmentDesc4   \n");
            strSql.Append(" , CurrencyDesc, BranchName, CU.CmpUnitName \n");
            strSql.Append(" from erp.SalesChallanMaster PIM \n");
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

            strSql.Append("Select PID.VoucherNo,PID.Sno,PID.ProductId,ProductAltUnit,ProductUnit,G.GodownId, \n");
            strSql.Append("PID.AltQty, SUM(PID.Qty - isnull(CQty, 0)) as Qty, PID.SalesRate, PID.BasicAmount, PID.TermAmount, PID.NetAmount, PID.LocalNetAmount, PID.AdditionalDesc, PID.ConversionRatio, PID.FreeQty, PID.FreeQtyUnit, \n");
            strSql.Append("ProductShortName, ProductDesc, ProductPrintingName, P.AltConv, PAU.ProductUnitDesc as ProductAltUnitDesc, PU.ProductUnitDesc as ProductUnitDesc, GodownDesc, P.IsTaxable, OrderNo, OrderSNo, QuotationNo, QuotationSNo,DispatchOrderNo,DispatchOrderSNo \n");
            strSql.Append("FROM ERP.SalesChallanDetails as PID \n");
            strSql.Append("Left Outer join( \n");
            strSql.Append("select ChallanNo, ChallanSNo, sum(Qty) as CQty from ERP.SalesChallanReturnDetails where ChallanNo is not Null \n");
            strSql.Append("group by ChallanNo, ChallanSNo \n");
            strSql.Append(") as PIR on PIR.ChallanNo = PID.VoucherNo and PIR.ChallanSNo = PID.SNo \n");
            strSql.Append("Left Outer join ERP.Product AS P on P.ProductId = PID.ProductId \n");
            strSql.Append("Left Outer join ERP.Godown AS G on G.GodownId = PID.GodownId \n");
            strSql.Append("left join erp.ProductUnit PU on[PID].ProductUnit = PU.ProductUnitId \n");
            strSql.Append("left join erp.ProductUnit PAU on[PID].ProductAltUnit = PAU.ProductUnitId \n");
            strSql.Append("where PID.VoucherNo IN(SELECT Value FROM fn_Splitstring('" + VoucherNo + "', ',')) \n");
            strSql.Append("group by PID.ProductId, ProductAltUnit, ProductUnit, PID.VoucherNo, PID.Sno, ProductDesc, G.GodownId, GodownDesc, \n");
            strSql.Append("PID.AltQty, ProductAltUnitId, PID.FreeQty, \n");
            strSql.Append("PID.BasicAmount, PID.NetAmount, PID.LocalNetAmount, PID.SalesRate, \n");
            strSql.Append("PID.AdditionalDesc, PID.TermAmount, PID.NetAmount,PID.OrderNo, PID.OrderSNo, PID.QuotationNo, PID.QuotationSNo, PID.DispatchOrderNo, PID.DispatchOrderSNo, P.IsSerialWise, P.IsBatchwise, PID.ConversionRatio, PID.FreeQtyUnit, \n");
            strSql.Append("ProductShortName, ProductPrintingName, P.AltConv, PU.ProductUnitDesc, PAU.ProductUnitDesc, P.IsTaxable \n");
            strSql.Append("Having Sum(PID.Qty - IsNull(CQty, 0)) > 0 \n");
            strSql.Append("Order by PID.VoucherNo, PID.Sno  \n");

            strSql.Append(" Select * from erp.SalesChallanReturnTerm  \n");
            if (!string.IsNullOrEmpty(VoucherNo))
                strSql.Append(" where voucherNo='" + VoucherNo + "' \n");

            strSql.Append("select* from[ERP].[UDFDataEntry] where VoucherNo = '" + VoucherNo + "' and EntryModule = 'PC'\n");

            strSql.Append("Select * from ERP.SalesChallanReturnOtherDetails  where VoucherNo = '" + VoucherNo + "' \n");
            strSql.Append("Select * from ERP.SalesChallanReturnBillingAddress  where VoucherNo = '" + VoucherNo + "' \n");

            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString());
        }
    }
    public class SalesChallanReturnMasterViewModel
    {
        public string Tag { get; set; }
        public string EntryFromProject { get; set; }
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
        public decimal LocalNetAmount { get; set; }
        public string PartyName { get; set; }
        public string PartyVatNo { get; set; }
        public string PartyAddress { get; set; }
        public string PartyMobileNo { get; set; }
		public string PartyEmail { get; set; }
		
		public string ChequeNo { get; set; }
        public Nullable<DateTime> ChequeDate { get; set; }
        public string ChequeMiti { get; set; }
        public string Remarks { get; set; }
        public string QuotationNo { get; set; }
        public string OrderNo { get; set; }
        public string EnterBy { get; set; }
        public Nullable<DateTime> EnterDate { get; set; }
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
    public class SalesChallanReturnDetailsViewModel
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
        public string OrderNo { get; set; }
        public int OrderSNo { get; set; }
        public string DispatchOrderNo { get; set; }
        public int DispatchOrderSNo { get; set; }
        public string QuotationNo { get; set; }
		public int QuotationSNo { get; set; }
		public string ChallanNo { get; set; }
        public int ChallanSNo { get; set; }
    }
}
