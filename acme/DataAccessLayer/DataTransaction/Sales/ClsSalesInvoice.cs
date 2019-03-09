﻿using DataAccessLayer.Interface.DataTransaction.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataTransaction.Sales
{
    public class ClsSalesInvoice : ISalesInvoice
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public SalesInvoiceMasterViewModel Model { get; set; }
        public List<SalesInvoiceDetailsViewModel> ModelDetails { get; set; }
        public List<TermViewModel> ModelTerms { get; set; }
        public BillingAddressViewModel ModelBillAddress { get; set; }
        public OtherDetailsViewModel ModelOtherDetails { get; set; }
        public SalesIrdViewModel SalesIrd { get; set; }

        public ClsSalesInvoice()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            Model = new SalesInvoiceMasterViewModel();
            ModelDetails = new List<SalesInvoiceDetailsViewModel>();
            ModelTerms = new List<TermViewModel>();
            ModelBillAddress = new BillingAddressViewModel();
            ModelOtherDetails = new OtherDetailsViewModel();
            SalesIrd = new SalesIrdViewModel();
        }
        public string IsExistsVNumber(string VoucherNo)
        {
            DataTable dt = DAL.ExecuteDataset(CommandType.Text, "select VoucherNo from erp.SalesInvoiceMaster WHERE VoucherNo='" + VoucherNo.Trim() + "'").Tables[0];
			return dt.Rows.Count == 0 ? "" : dt.Rows[0]["VoucherNo"].ToString();
		}

        public string SaveSalesInvoice()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("BEGIN TRANSACTION \n");
            strSql.Append("BEGIN TRY \n");
            strSql.Append("Set @VoucherNo ='" + Model.VoucherNo.Trim() + "'\n");
            if (Model.Tag == "NEW")
            {
                strSql.Append("INSERT INTO ERP.SalesInvoiceMaster(VoucherNo, VDate, VTime, VMiti, ReferenceNo, ReferenceDate, ReferenceMiti,DueDate , DueDay, DueMiti, LedgerId, \n");
                strSql.Append("SubLedgerId, SalesmanId, DepartmentId1, DepartmentId2, DepartmentId3, DepartmentId4, CurrencyId, CurrencyRate, BranchId, CompanyUnitId,  \n");
                strSql.Append("BasicAmount,TermAmount, NetAmount,LocalNetAmount, TenderAmount, ReturnAmount,TaxableAmount,TaxFreeAmount,VatAmount, \n");
                strSql.Append("PartyName, PartyVatNo, PartyAddress, PartyMobileNo,PartyEmail, ChequeNo, ChequeDate, ChequeMiti, PaymentType,\n");
                strSql.Append("Remarks, QuotationNo, OrderNo, ChallanNo, InvoiceType, EnterBy, EnterDate, ReconcileBy, ReconcileDate, IsPosted, PostedBy, PostedDate, IsAuthorized, AuthorizedBy, \n");
                strSql.Append("AuthorizedDate, AuthorizeRemarks, Gadget,IsBillCancel,EntryFromProject) \n");
                strSql.Append("Select @VoucherNo,'" + Model.VDate.ToString("yyyy-MM-dd") + "','" + Model.VDate.ToString("yyyy-MM-dd") + ' ' + DateTime.Now.ToShortTimeString() + "','" + Model.VMiti.ToString() + "', " + (string.IsNullOrEmpty(Model.ReferenceNo) ? "null" : "'" + Model.ReferenceNo + "'") + ", " + ((string.IsNullOrEmpty(Model.ReferenceDate.ToString())) ? "null" : "'" + Model.ReferenceDate.Value.ToString("yyyy-MM-dd") + "'") + ", " + (string.IsNullOrEmpty(Model.ReferenceMiti.ToString()) ? "null" : "'" + Model.ReferenceMiti.ToString() + "'") + ", " + ((string.IsNullOrEmpty(Model.DueDate.ToString())) ? "null" : "'" + Model.DueDate.Value.ToString("yyyy-MM-dd") + "'") + ", '" + Model.DueDay.ToString() + "'," + (string.IsNullOrEmpty(Model.DueMiti) ? "null" : "'" + Model.DueMiti + "'") + ", " + ((Model.LedgerId == 0) ? "null" : "'" + Model.LedgerId + "'") + ", \n");
                strSql.Append("" + ((Model.SubLedgerId == 0) ? "null" : "'" + Model.SubLedgerId + "'") + ", " + ((Model.SalesmanId == 0) ? "null" : "'" + Model.SalesmanId + "'") + "," + ((Model.DepartmentId1 == 0) ? "null" : "'" + Model.DepartmentId1 + "'") + ", " + ((Model.DepartmentId2 == 0) ? "null" : "'" + Model.DepartmentId2 + "'") + " ," + ((Model.DepartmentId3 == 0) ? "null" : "'" + Model.DepartmentId3 + "'") + ", " + ((Model.DepartmentId4 == 0) ? "null" : "'" + Model.DepartmentId4 + "'") + ", " + ((Model.CurrencyId == 0) ? "null" : "'" + Model.CurrencyId + "'") + ",'" + (Model.CurrencyRate == 0 ? 1 : Model.CurrencyRate) + "', " + ((Model.BranchId == 0) ? "null" : "'" + Model.BranchId + "'") + "," + ((Model.CompanyUnitId == 0) ? "null" : "'" + Model.CompanyUnitId + "'") + ", \n");
                strSql.Append("'" + Model.BasicAmount + "','" + Model.TermAmount + "', '" + Model.NetAmount + "', '" + (Model.NetAmount * (Model.CurrencyRate == 0 ? 1 : Model.CurrencyRate)) + "' , '" + Model.TenderAmount + "', '" + Model.ReturnAmount + "','" + Model.TaxableAmount + "','" + Model.TaxFreeAmount + "','" + Model.VatAmount + "',  \n");
                strSql.Append("" + (string.IsNullOrEmpty(Model.PartyName) ? "null" : "'" + Model.PartyName + "'") + ",  " + (string.IsNullOrEmpty(Model.PartyVatNo) ? "null" : "'" + Model.PartyVatNo + "'") + ",  " + (string.IsNullOrEmpty(Model.PartyAddress) ? "null" : "'" + Model.PartyAddress + "'") + "," + (string.IsNullOrEmpty(Model.PartyMobileNo) ? "null" : "'" + Model.PartyMobileNo + "'") + "," + (string.IsNullOrEmpty(Model.PartyEmail) ? "null" : "'" + Model.PartyEmail + "'") + "," + (string.IsNullOrEmpty(Model.ChequeNo) ? "null" : "'" + Model.ChequeNo + "'") + ", " + ((string.IsNullOrEmpty(Model.ChequeDate.ToString())) ? "null" : "'" + Model.ChequeDate.Value.ToString("yyyy-MM-dd") + "'") + ",  " + (string.IsNullOrEmpty(Model.ChequeMiti) ? "null" : "'" + Model.ChequeMiti + "'") + ",  " + (string.IsNullOrEmpty(Model.PaymentType) ? "null" : "'" + Model.PaymentType + "'") + ",\n");
                strSql.Append("" + (string.IsNullOrEmpty(Model.Remarks) ? "null" : "'" + Model.Remarks + "'") + ", " + (string.IsNullOrEmpty(Model.QuotationNo) ? "null" : "'" + Model.QuotationNo + "'") + ",  " + (string.IsNullOrEmpty(Model.OrderNo) ? "null" : "'" + Model.OrderNo + "'") + ",  " + (string.IsNullOrEmpty(Model.ChallanNo) ? "null" : "'" + Model.ChallanNo + "'") + ",'" + Model.InvoiceType + "','" + Model.EnterBy + "', GETDATE(),  " + (string.IsNullOrEmpty(Model.ReconcileBy) ? "null" : "'" + Model.ReconcileBy + "'") + ",  " + ((Model.ReconcileDate.ToString() == "") ? "null" : "'" + Model.ReconcileDate.ToString() + "'") + ", '" + Model.IsPosted + "',  " + (string.IsNullOrEmpty(Model.PostedBy) ? "null" : "'" + Model.PostedBy + "'") + ",  " + ((Model.PostedDate.ToString() == "") ? "null" : "'" + Model.PostedDate.ToString() + "'") + ",'" + Model.IsAuthorized + "',  " + (string.IsNullOrEmpty(Model.AuthorizedBy) ? "null" : "'" + Model.AuthorizedBy + "'") + ", \n");
                strSql.Append("" + ((Model.AuthorizedDate.ToString() == "") ? "null" : "'" + Model.AuthorizedDate.ToString() + "'") + ",  " + (string.IsNullOrEmpty(Model.AuthorizeRemarks) ? "null" : "'" + Model.AuthorizeRemarks + "'") + ", '" + Model.Gadget + "'," + Model.IsBillCancel + ",'" + Model.EntryFromProject + "' \n");
                               
                strSql.Append("Update ERP.DocumentNumbering set DocCurrentNo = DocCurrentNo + 1 where DocId =" + Model.DocId + "\n");
                strSql.Append("Insert Into [ERP].[SalesIrd] (VoucherNo, IsIRDSync, IsRealTimeIRDSync, PrintCopy, PrintedBy, PrintedDate) \n");
                strSql.Append("Select  '" + Model.VoucherNo + "', '" + SalesIrd.IsIRDSync + "', '" + SalesIrd.IsRealTimeIRDSync + "', '" + SalesIrd.PrintCopy + "',  " + (string.IsNullOrEmpty(SalesIrd.PrintedBy) ? "null" : "'" + SalesIrd.PrintedBy + "'") + ",  " + ((SalesIrd.PrintedDate.ToString() == "") ? "null" : "'" + SalesIrd.PrintedDate.ToString() + "'") + " \n");

                if (Model.EntryFromProject != "Restaurant")  
                {
                    strSql.Append("INSERT INTO [ERP].[SalesInvoiceOtherDetails]([VoucherNo],[Transport],[VehicleNo],[Package],[CnNo],[CnDate],[CnFreight],[CnType]\n");
                    strSql.Append(",[Advance],[BalFreight],[DriverName],[DriverLicNo],[DriverMobileNo],[ContractNo],[ContractDate],[ExpInvNo],[ExpInvDate],[PoNo],[PoDate],[DocBank],[LcNo],[CustomName],[Cofd])\n");
                    strSql.Append("Select @VoucherNo," + (string.IsNullOrEmpty(ModelOtherDetails.Transport) ? "null" : "'" + ModelOtherDetails.Transport + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.VehicleNo) ? "null" : "'" + ModelOtherDetails.VehicleNo + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.Package) ? "null" : "'" + ModelOtherDetails.Package + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.CnNo) ? "null" : "'" + ModelOtherDetails.CnNo + "'") + "," + ((string.IsNullOrEmpty(ModelOtherDetails.CnDate.ToString())) ? "null" : "'" + ModelOtherDetails.CnDate.Value.ToString("yyyy-MM-dd") + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.CnFreight) ? "null" : "'" + ModelOtherDetails.CnFreight + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.CnType) ? "null" : "'" + ModelOtherDetails.CnType + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.Advance) ? "null" : "'" + ModelOtherDetails.Advance + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.BalFreight) ? "null" : "'" + ModelOtherDetails.BalFreight + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.DriverName) ? "null" : "'" + ModelOtherDetails.DriverName + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.DriverLicNo) ? "null" : "'" + ModelOtherDetails.DriverLicNo + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.DriverMobileNo) ? "null" : "'" + ModelOtherDetails.DriverMobileNo + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.ContractNo) ? "null" : "'" + ModelOtherDetails.ContractNo + "'") + "," + ((string.IsNullOrEmpty(ModelOtherDetails.ContractDate.ToString())) ? "null" : "'" + ModelOtherDetails.ContractDate.Value.ToString("yyyy-MM-dd") + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.ExpInvNo) ? "null" : "'" + ModelOtherDetails.ExpInvNo + "'") + "," + ((string.IsNullOrEmpty(ModelOtherDetails.ExpInvDate.ToString())) ? "null" : "'" + ModelOtherDetails.ExpInvDate.Value.ToString("yyyy-MM-dd") + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.PoNo) ? "null" : "'" + ModelOtherDetails.PoNo + "'") + "," + ((string.IsNullOrEmpty(ModelOtherDetails.PoDate.ToString())) ? "null" : "'" + ModelOtherDetails.PoDate.Value.ToString("yyyy-MM-dd") + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.DocBank) ? "null" : "'" + ModelOtherDetails.DocBank + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.LcNo) ? "null" : "'" + ModelOtherDetails.LcNo + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.CustomName) ? "null" : "'" + ModelOtherDetails.CustomName + "'") + "," + (string.IsNullOrEmpty(ModelOtherDetails.Cofd) ? "null" : "'" + ModelOtherDetails.Cofd + "'") + " \n");

                    strSql.Append("INSERT INTO[ERP].[SalesInvoiceBillingAddress] ([VoucherNo],[LedgerId],[BillingAddress],[BillingCity],[BillingState],[BillingCountry],[BillingEmail],[ShippingAddress],[ShippingCity],[ShippingState],[ShippingCountry],[ShippingEmail],[DeliveryDate],[Remarks])\n");
                    strSql.Append("Select @VoucherNo," + ((ModelBillAddress.LedgerId == 0) ? "null" : "'" + ModelBillAddress.LedgerId + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingAddress) ? "null" : "'" + ModelBillAddress.BillingAddress + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingCity) ? "null" : "'" + ModelBillAddress.BillingCity + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingState) ? "null" : "'" + ModelBillAddress.BillingState + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingCountry) ? "null" : "'" + ModelBillAddress.BillingCountry + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.BillingEmail) ? "null" : "'" + ModelBillAddress.BillingEmail + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingAddress) ? "null" : "'" + ModelBillAddress.ShippingAddress + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingCity) ? "null" : "'" + ModelBillAddress.ShippingCity + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingState) ? "null" : "'" + ModelBillAddress.ShippingState + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingCountry) ? "null" : "'" + ModelBillAddress.ShippingCountry + "'") + "," + (string.IsNullOrEmpty(ModelBillAddress.ShippingEmail) ? "null" : "'" + ModelBillAddress.ShippingEmail + "'") + "," + ((ModelBillAddress.DeliveryDate.ToString() == "") ? "null" : "'" + ModelBillAddress.DeliveryDate.ToString() + "'") + ", " + (string.IsNullOrEmpty(ModelBillAddress.Remarks) ? "null" : "'" + ModelBillAddress.Remarks + "'") + " \n");
                }
            }
            else if (Model.Tag == "EDIT")
            {
                strSql.Append("UPDATE ERP.SalesInvoiceMaster SET VDate='" + Model.VDate.ToString("yyyy-MM-dd") + "',VMiti='" + Model.VMiti.ToString() + "',ReferenceNo= " + ((Model.ReferenceNo == "") ? "null" : "'" + Model.ReferenceNo + "'") + ", ReferenceDate=" + ((string.IsNullOrEmpty(Model.ReferenceDate.ToString())) ? "null" : "'" + Model.ReferenceDate.Value.ToString("yyyy-MM-dd") + "'") + ", ReferenceMiti= " + (string.IsNullOrEmpty(Model.ReferenceMiti.ToString()) ? "null" : "'" + Model.ReferenceMiti.ToString() + "'") + ", DueDate=" + ((string.IsNullOrEmpty(Model.DueDate.ToString())) ? "null" : "'" + Model.DueDate.Value.ToString("yyyy-MM-dd") + "'") + ", DueDay='" + Model.DueDay.ToString() + "', DueMiti=" + (string.IsNullOrEmpty(Model.DueMiti) ? "null" : "'" + Model.DueMiti + "'") + ",LedgerId= " + ((Model.LedgerId == 0) ? "null" : "'" + Model.LedgerId + "'") + ", \n");
                strSql.Append("SubLedgerId=" + ((Model.SubLedgerId == 0) ? "null" : "'" + Model.SubLedgerId + "'") + ",SalesmanId= " + ((Model.SalesmanId == 0) ? "null" : "'" + Model.SalesmanId + "'") + ", DepartmentId1=" + ((Model.DepartmentId1 == 0) ? "null" : "'" + Model.DepartmentId1 + "'") + ", DepartmentId2=" + ((Model.DepartmentId2 == 0) ? "null" : "'" + Model.DepartmentId2 + "'") + ", DepartmentId3=" + ((Model.DepartmentId3 == 0) ? "null" : "'" + Model.DepartmentId3 + "'") + ", DepartmentId4=" + ((Model.DepartmentId4 == 0) ? "null" : "'" + Model.DepartmentId4 + "'") + ", CurrencyId=" + ((Model.CurrencyId == 0) ? "null" : "'" + Model.CurrencyId + "'") + ",CurrencyRate='" + (Model.CurrencyRate == 0 ? 1 : Model.CurrencyRate) + "', BranchId= " + ((Model.BranchId == 0) ? "null" : "'" + Model.BranchId + "'") + ",CompanyUnitId=" + ((Model.CompanyUnitId == 0) ? "null" : "'" + Model.CompanyUnitId + "'") + ", \n");
                strSql.Append("BasicAmount='" + Model.BasicAmount + "',TermAmount='" + Model.TermAmount + "',NetAmount= '" + Model.NetAmount + "' ,LocalNetAmount ='" + (Model.NetAmount * (Model.CurrencyRate == 0 ? 1 : Model.CurrencyRate)) + "', TenderAmount= '" + Model.TenderAmount + "', ReturnAmount='" + Model.ReturnAmount + "',  \n");
                strSql.Append("PartyName=" + ((Model.PartyName == "") ? "null" : "'" + Model.PartyName + "'") + ", PartyVatNo= " + (string.IsNullOrEmpty(Model.PartyVatNo) ? "null" : "'" + Model.PartyVatNo + "'") + ", PartyAddress= " + (string.IsNullOrEmpty(Model.PartyAddress) ? "null" : "'" + Model.PartyAddress + "'") + ", PartyMobileNo= " + (string.IsNullOrEmpty(Model.PartyMobileNo) ? "null" : "'" + Model.PartyMobileNo + "'") + ",PartyEmail=" + (string.IsNullOrEmpty(Model.PartyEmail) ? "null" : "'" + Model.PartyEmail + "'") + ",ChequeNo=" + (string.IsNullOrEmpty(Model.ChequeNo) ? "null" : "'" + Model.ChequeNo + "'") + ",ChequeDate= " + ((string.IsNullOrEmpty(Model.ChequeDate.ToString())) ? "null" : "'" + Model.ChequeDate.Value.ToString("yyyy-MM-dd") + "'") + ", ChequeMiti= " + (string.IsNullOrEmpty(Model.ChequeMiti) ? "null" : "'" + Model.ChequeMiti + "'") + ",  PaymentType=" + (string.IsNullOrEmpty(Model.PaymentType) ? "null" : "'" + Model.PaymentType + "'") + ",\n");
                strSql.Append("Remarks=" + (string.IsNullOrEmpty(Model.Remarks) ? "null" : "'" + Model.Remarks + "'") + ", QuotationNo=" + (string.IsNullOrEmpty(Model.QuotationNo) ? "null" : "'" + Model.QuotationNo + "'") + ",  OrderNo=" + (string.IsNullOrEmpty(Model.OrderNo) ? "null" : "'" + Model.OrderNo + "'") + ", ChallanNo= " + (string.IsNullOrEmpty(Model.ChallanNo) ? "null" : "'" + Model.ChallanNo + "'") + ",InvoiceType = '" + Model.InvoiceType + "', ReconcileBy= " + (string.IsNullOrEmpty(Model.ReconcileBy) ? "null" : "'" + Model.ReconcileBy + "'") + ",  ReconcileDate=" + ((string.IsNullOrEmpty(Model.ReconcileDate.ToString())) ? "null" : "'" + Model.ReconcileDate.Value.ToString("yyyy-MM-dd") + "'") + ", IsPosted='" + Model.IsPosted + "', PostedBy= " + (string.IsNullOrEmpty(Model.PostedBy) ? "null" : "'" + Model.PostedBy + "'") + ",  PostedDate=" + ((string.IsNullOrEmpty(Model.PostedDate.ToString())) ? "null" : "'" + Model.PostedDate.Value.ToString("yyyy-MM-dd") + "'") + ",IsAuthorized='" + Model.IsAuthorized + "', AuthorizedBy= " + (string.IsNullOrEmpty(Model.AuthorizedBy) ? "null" : "'" + Model.AuthorizedBy + "'") + ", \n");
                strSql.Append("AuthorizedDate= " + ((string.IsNullOrEmpty(Model.AuthorizedDate.ToString())) ? "null" : "'" + Model.AuthorizedDate.Value.ToString("yyyy-MM-dd") + "'") + ", AuthorizeRemarks= " + (string.IsNullOrEmpty(Model.AuthorizeRemarks) ? "null" : "'" + Model.AuthorizeRemarks.Trim() + "'") + ", Gadget='" + Model.Gadget.Trim() + "'  WHERE VoucherNo = '" + Model.VoucherNo + "'\n");
                if (Model.EntryFromProject != "Restaurant")
                {
                    strSql.Append("UPDATE [ERP].[SalesInvoiceOtherDetails] SET Transport = " + (string.IsNullOrEmpty(ModelOtherDetails.Transport) ? "null" : "'" + ModelOtherDetails.Transport + "'") + ",VehicleNo = " + (string.IsNullOrEmpty(ModelOtherDetails.VehicleNo) ? "null" : "'" + ModelOtherDetails.VehicleNo + "'") + ",Package = " + (string.IsNullOrEmpty(ModelOtherDetails.Package) ? "null" : "'" + ModelOtherDetails.Package + "'") + ",CnNo = " + (string.IsNullOrEmpty(ModelOtherDetails.CnNo) ? "null" : "'" + ModelOtherDetails.CnNo + "'") + ",CnDate = " + ((string.IsNullOrEmpty(ModelOtherDetails.CnDate.ToString())) ? "null" : "'" + ModelOtherDetails.CnDate.Value.ToString("yyyy-MM-dd") + "'") + ",CnFreight = " + (string.IsNullOrEmpty(ModelOtherDetails.CnFreight) ? "null" : "'" + ModelOtherDetails.CnFreight + "'") + ",CnType = " + (string.IsNullOrEmpty(ModelOtherDetails.CnType) ? "null" : "'" + ModelOtherDetails.CnType + "'") + ",Advance = " + (string.IsNullOrEmpty(ModelOtherDetails.Advance) ? "null" : "'" + ModelOtherDetails.Advance + "'") + ",BalFreight = " + (string.IsNullOrEmpty(ModelOtherDetails.BalFreight) ? "null" : "'" + ModelOtherDetails.BalFreight + "'") + ",DriverName = " + (string.IsNullOrEmpty(ModelOtherDetails.DriverName) ? "null" : "'" + ModelOtherDetails.DriverName + "'") + ",DriverLicNo = " + (string.IsNullOrEmpty(ModelOtherDetails.DriverLicNo) ? "null" : "'" + ModelOtherDetails.DriverLicNo + "'") + ",DriverMobileNo = " + (string.IsNullOrEmpty(ModelOtherDetails.DriverMobileNo) ? "null" : "'" + ModelOtherDetails.DriverMobileNo + "'") + ",ContractNo = " + (string.IsNullOrEmpty(ModelOtherDetails.ContractNo) ? "null" : "'" + ModelOtherDetails.ContractNo + "'") + ",ContractDate = " + ((string.IsNullOrEmpty(ModelOtherDetails.ContractDate.ToString())) ? "null" : "'" + ModelOtherDetails.ContractDate.Value.ToString("yyyy-MM-dd") + "'") + ",ExpInvNo = " + (string.IsNullOrEmpty(ModelOtherDetails.ExpInvNo) ? "null" : "'" + ModelOtherDetails.ExpInvNo + "'") + ",ExpInvDate = " + ((string.IsNullOrEmpty(ModelOtherDetails.ExpInvDate.ToString())) ? "null" : "'" + ModelOtherDetails.ExpInvDate.Value.ToString("yyyy-MM-dd") + "'") + ",PoNo = " + (string.IsNullOrEmpty(ModelOtherDetails.PoNo) ? "null" : "'" + ModelOtherDetails.PoNo + "'") + ",PoDate = " + ((string.IsNullOrEmpty(ModelOtherDetails.PoDate.ToString())) ? "null" : "'" + ModelOtherDetails.PoDate.Value.ToString("yyyy-MM-dd") + "'") + ",DocBank = " + (string.IsNullOrEmpty(ModelOtherDetails.DocBank) ? "null" : "'" + ModelOtherDetails.DocBank + "'") + ",LcNo = " + (string.IsNullOrEmpty(ModelOtherDetails.LcNo) ? "null" : "'" + ModelOtherDetails.LcNo + "'") + ",CustomName = " + (string.IsNullOrEmpty(ModelOtherDetails.CustomName) ? "null" : "'" + ModelOtherDetails.CustomName + "'") + ",Cofd = " + (string.IsNullOrEmpty(ModelOtherDetails.Cofd) ? "null" : "'" + ModelOtherDetails.Cofd + "'") + "  WHERE VoucherNo = '" + Model.VoucherNo + "' \n");
                    strSql.Append("UPDATE[ERP].[SalesInvoiceBillingAddress] SET LedgerId =" + ((ModelBillAddress.LedgerId == 0) ? "null" : "'" + ModelBillAddress.LedgerId + "'") + ", [BillingAddress] =" + (string.IsNullOrEmpty(ModelBillAddress.BillingAddress) ? "null" : "'" + ModelBillAddress.BillingAddress + "'") + ",[BillingCity] = " + (string.IsNullOrEmpty(ModelBillAddress.BillingCity) ? "null" : "'" + ModelBillAddress.BillingCity + "'") + ",[BillingState] = " + (string.IsNullOrEmpty(ModelBillAddress.BillingState) ? "null" : "'" + ModelBillAddress.BillingState + "'") + ",[BillingCountry] = " + (string.IsNullOrEmpty(ModelBillAddress.BillingCountry) ? "null" : "'" + ModelBillAddress.BillingCountry + "'") + ",[BillingEmail] = " + (string.IsNullOrEmpty(ModelBillAddress.BillingEmail) ? "null" : "'" + ModelBillAddress.BillingEmail + "'") + ",ShippingAddress=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingAddress) ? "null" : "'" + ModelBillAddress.ShippingAddress + "'") + ",ShippingCity=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingCity) ? "null" : "'" + ModelBillAddress.ShippingCity + "'") + ",ShippingState=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingState) ? "null" : "'" + ModelBillAddress.ShippingState + "'") + ",ShippingCountry=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingCountry) ? "null" : "'" + ModelBillAddress.ShippingCountry + "'") + ",ShippingEmail=" + (string.IsNullOrEmpty(ModelBillAddress.ShippingEmail) ? "null" : "'" + ModelBillAddress.ShippingEmail + "'") + ",DeliveryDate=" + ((ModelBillAddress.DeliveryDate.ToString() == "") ? "null" : "'" + ModelBillAddress.DeliveryDate.ToString() + "'") + ", Remarks=" + (string.IsNullOrEmpty(ModelBillAddress.Remarks) ? "null" : "'" + ModelBillAddress.Remarks + "'") + "  WHERE VoucherNo = '" + Model.VoucherNo + "' \n");
                }
            }
            else if (Model.Tag == "DELETE")
            {
				strSql.Append("Delete FROM [ERP].InventoryTransaction Where Source = 'SB' and VoucherNo = @VoucherNo \n");
				strSql.Append("Delete FROM [ERP].[FinanceTransaction] Where Source = 'SB' and VoucherNo = @VoucherNo \n");
				strSql.Append("DELETE FROM [ERP].[SalesIrd] WHERE VoucherNo = '" + Model.VoucherNo + "' \n");
                strSql.Append("DELETE FROM [ERP].[SalesInvoiceTerm] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
                strSql.Append("DELETE FROM [ERP].[SalesInvoiceDetails] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
                strSql.Append("DELETE FROM [ERP].[SalesInvoiceBillingAddress] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
                strSql.Append("DELETE FROM [ERP].[SalesInvoiceOtherDetails] WHERE VoucherNo ='" + Model.VoucherNo + "' \n");
                strSql.Append("DELETE FROM [ERP].[SalesInvoiceMaster] WHERE VoucherNo = '" + Model.VoucherNo + "' \n");
                strSql.Append("SET @VoucherNo ='1'");
                ModelTerms.Clear();
                ModelDetails.Clear();
            }

            if (Model.Tag == "EDIT")
                strSql.Append("DELETE FROM [ERP].[SalesInvoiceDetails] WHERE VoucherNo =@VoucherNo \n");
            foreach (SalesInvoiceDetailsViewModel det in ModelDetails)
            {
                strSql.Append("INSERT INTO ERP.SalesInvoiceDetails(VoucherNo, Sno, ProductId, ProductAltUnit, ProductUnit, GodownId, AltQty, Qty, SalesRate, BasicAmount, TermAmount, NetAmount, LocalNetAmount, AdditionalDesc,ConversionRatio, FreeQty, FreeQtyUnit, OrderNo, OrderSNo, DispatchOrderNo, DispatchOrderSNo, ChallanNo, ChallanSNo,TaxableAmount,TaxFreeAmount,VatAmount,IsTaxable) \n");
                strSql.Append("Select @VoucherNo, '" + det.Sno + "', '" + det.ProductId + "'," + ((det.ProductAltUnitId == 0) ? "null" : "'" + det.ProductAltUnitId + "'") + ", " + ((det.ProductUnitId == 0) ? "null" : "'" + det.ProductUnitId + "'") + ", " + ((det.GodownId == 0) ? "null" : "'" + det.GodownId + "'") + ",'" + det.AltQty + "', '" + det.Qty + "', '" + det.SalesRate + "', '" + det.BasicAmount + "', '" + det.TermAmount + "', '" + det.NetAmount + "', '" + det.LocalNetAmount + "', '" + det.AdditionalDesc + "','" + det.ConversionRatio + "', '" + det.FreeQty + "',  " + ((det.FreeQtyUnit == 0) ? "null" : "'" + det.FreeQtyUnit + "'") + ",  " + (string.IsNullOrEmpty(det.OrderNo) ? "null" : "'" + det.OrderNo + "'") + ",  " + ((det.OrderSNo == 0) ? "null" : "'" + det.OrderSNo + "'") + ",  " + (string.IsNullOrEmpty(det.DispatchOrderNo) ? "null" : "'" + det.DispatchOrderNo + "'") + ",  " + ((det.DispatchOrderSNo == 0) ? "null" : "'" + det.DispatchOrderSNo + "'") + ",  " + (string.IsNullOrEmpty(det.ChallanNo) ? "null" : "'" + det.ChallanNo + "'") + ",  " + ((det.ChallanSNo == 0) ? "null" : "'" + det.ChallanSNo + "'") + ", '" + det.TaxableAmount + "','" + det.TaxFreeAmount + "','" + det.VatAmount + "','" + det.IsTaxable + "' \n");
            }

            if (ModelTerms.Count > 0)
            {
                strSql.Append("DELETE FROM [ERP].[SalesInvoiceTerm] WHERE VoucherNo =@VoucherNo \n");
                foreach (TermViewModel det in ModelTerms)
                {
                    strSql.Append("INSERT INTO ERP.SalesInvoiceTerm(VoucherNo, Sno, ProductId, TermId, TermType, STSign, TermRate, TermAmt, LocalTermAmt) \n");
                    strSql.Append("Select @VoucherNo, '" + det.Sno + "', " + ((det.ProductId == 0) ? "null" : "'" + det.ProductId + "'") + ", '" + det.TermId + "', '" + det.TermType + "', '" + det.STSign + "', '" + det.TermRate + "', '" + det.TermAmt + "', '" + det.LocalTermAmt + "' \n");
                }
                ModelTerms.Clear();
            }

            if (Model.UdfDetails != null)
            {
                if (Model.UdfDetails.Rows.Count > 0)
                {
                    strSql.Append("DELETE FROM ERP.UDFDataEntry WHERE VoucherNo=@VoucherNo AND EntryModule='SB' AND SNO<>0 \n");
                    int _s = 0;
                    foreach (DataRow ro in Model.UdfDetails.Rows)
                    {
                        int j = 1;
                        for (int i = 0; i < (Model.UdfDetails.Columns.Count - 1) / 2; i++)
                        {
                            strSql.Append("INSERT INTO ERP.UDFDataEntry(VoucherNo,EntryModule,SNO,UDFCode,UDFData,ProductId) \n");
                            strSql.Append("Select @VoucherNo,'SB','" + ro[0].ToString() + "', ");
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
                    strSql.Append("DELETE FROM ERP.UDFDataEntry WHERE VoucherNo=@VoucherNo AND EntryModule='SB' AND SNO=0 \n");
                    foreach (DataRow ro in Model.UdfMaster.Rows)
                    {
                        int j = 1;
                        for (int i = 0; i < (Model.UdfMaster.Columns.Count - 1) / 2; i++)
                        {
                            strSql.Append("INSERT INTO ERP.UDFDataEntry(VoucherNo,EntryModule,SNO,UDFCode,UDFData,ProductId) \n");
                            strSql.Append("Select @VoucherNo,'SB','0','" + ro[j].ToString() + "',");
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
            strSql.Append("insert into erp.SalesInvoiceTerm(VoucherNo, TermId, Sno, ProductId, TermType, STSign, TermRate, TermAmt, LocalTermAmt)  \n");
            strSql.Append("(Select @VoucherNo as VoucherNo, TermId as TermId, Sno, SBD1.ProductId, 'BT' as TermType, STSign, TermRate  \n");
            strSql.Append(", isnull(abs(sum((Amt * SBD1.Bamt1) / Bamt)), 0) as TermAmt1, 0 as LocalTermAmt from erp.SalesInvoiceMaster as sm,  \n");
            strSql.Append("(Select Sno, SD.ProductId, SD.VoucherNo, sum(Case When SD.NetAmount <> 0 then SD.NetAmount else SD.BasicAmount end) as Bamt1 from erp.SalesInvoiceDetails as SD, erp.SalesInvoiceMaster as SM  where SD.VoucherNo = SM.VoucherNo  \n");
            strSql.Append("group by SD.ProductId, SD.VoucherNo, Sno) as SBD1, (select SD.VoucherNo, CASE WHEN  sum(Case when SD.NetAmount <> 0 then SD.NetAmount * CurrencyRate else SD.BasicAmount * CurrencyRate end) = 0 THEN 1 ELSE sum(Case when SD.NetAmount<>0 then SD.NetAmount* CurrencyRate else SD.BasicAmount* CurrencyRate end ) END as Bamt from erp.SalesInvoiceDetails as SD,erp.SalesInvoiceMaster as SM  where SD.VoucherNo = SM.VoucherNo group by SD.VoucherNo) as Sbd, \n");
            strSql.Append("(Select SD.VoucherNo,SD.TermId,SD.TermRate,sum((case when STM.STSign = '+' then(SD.TermAmt * CurrencyRate) else -(SD.TermAmt * CurrencyRate) end)) as Amt,Stm.STSign from erp.SalesInvoiceTerm as SD, erp.SalesInvoiceMaster as Sm,erp.SalesBillingTerm as Stm \n");
            strSql.Append("where SD.VoucherNo = SM.VoucherNo and SD.TermId = STM.TermId and ProductId is Null and Basis <> 'Q' and Exists(Select* from erp.SalesInvoiceDetails as SBD where SD.VoucherNo = SBD.VoucherNo group by ProductId) and SD.VoucherNo = @VoucherNo \n");
            strSql.Append("group by SD.VoucherNo,SD.TermId,SD.TermRate,STM.STSign) as Trm where sm.VoucherNo = SBD1.VoucherNo and sm.VoucherNo = Trm.VoucherNo And Sbd.VoucherNo = Trm.VoucherNo  group by SBD1.ProductId,TermId,TermRate,Sno,Trm.STSign \n");
            strSql.Append("Union All \n");
            strSql.Append("Select @VoucherNo as VoucherNo,TermId as TermId,Sno,Sbd.ProductId,'BT' as TermType,Trm.STSign ,TermRate,isnull(abs(sum(Case when TotQty <> 0 then(Amt / TotQty) * Bamt end)), 0) as TermAmt1,0 as LocalTermAmt \n");
            strSql.Append("from erp.SalesInvoiceMaster as Sm,(Select VoucherNo, Sum(Qty) as TotQty from erp.SalesInvoiceDetails group by VoucherNo) as SD, \n");
            strSql.Append("(select Sno, ProductId, VoucherNo, sum(Qty) as Bamt from erp.SalesInvoiceDetails group by VoucherNo,ProductId,Sno) as Sbd, \n");
            strSql.Append("(Select SD.VoucherNo,SD.TermId,SD.TermRate,sum((case when STM.STSign = '+' then(SD.TermAmt * CurrencyRate) else -(SD.TermAmt * CurrencyRate) end)) as Amt,Stm.STSign \n");
            strSql.Append("from erp.SalesInvoiceTerm as SD,erp.SalesInvoiceMaster as Sm,erp.SalesBillingTerm as Stm where SD.VoucherNo = SM.VoucherNo and SD.TermId = STM.TermId and ProductId is Null and Basis = 'Q' \n");
            strSql.Append("and Exists(Select* from erp.SalesInvoiceDetails as SBD where SD.VoucherNo = SBD.VoucherNo group by ProductId) and SD.VoucherNo = @VoucherNo group by SD.VoucherNo,SD.TermId,SD.TermRate,STm.STSign) as Trm \n");
            strSql.Append("Where SM.VoucherNo = Trm.VoucherNo And Sbd.VoucherNo = Trm.VoucherNo and sm.VoucherNo = SD.VoucherNo \n");
            strSql.Append("group by Sbd.ProductId,TermId,TermRate,Sno,Trm.STSign) \n");

            strSql.Append("Update erp.SalesInvoiceTerm set LocalTermAmt = TermAmt * CurrencyRate from erp.SalesInvoiceMaster where erp.SalesInvoiceTerm.VoucherNo = erp.SalesInvoiceMaster.VoucherNo and erp.SalesInvoiceMaster.VoucherNo = @VoucherNo \n");
            strSql.Append("Update erp.salesinvoicedetails set TaxableAmount = (TaxableAmount - STerm.TermAmt) from(Select voucherno, sno, TermAmt, TermId from erp.salesinvoiceterm  where voucherno = @VoucherNo and TermType = 'BT' and TermID = (Select  SBBillDiscountTermId from erp.SystemSetting ))STerm where STerm.voucherno = erp.salesinvoicedetails.VoucherNo and STerm.sno = erp.salesinvoicedetails.sno \n");
            strSql.Append("Update erp.salesinvoicedetails set VatAmount = STerm.TermAmt from(Select voucherno, sno, TermAmt, TermId from erp.salesinvoiceterm  where voucherno = @VoucherNo and TermType = 'BT' and TermID = (Select  SBVatTermId from erp.SystemSetting ))STerm where STerm.VoucherNo = erp.salesinvoicedetails.VoucherNo and STerm.sno = erp.salesinvoicedetails.sno \n");

            if (Model.Tag == "EDIT")
            {
                strSql.Append("Delete from ERP.InventoryTransaction Where Source = 'SB' and VoucherNo = @VoucherNo \n");
                strSql.Append("Delete from ERP.[FinanceTransaction] Where Source = 'SB' and VoucherNo = @VoucherNo \n");
            }

			if (string.IsNullOrEmpty(Model.ChallanNo))
			{
				strSql.Append("Insert Into ERP.InventoryTransaction \n");
				strSql.Append("(VoucherNo, VDate, VMiti, VTime, LedgerId, SalesManId, DepartmentId1, DepartmentId2, DepartmentId3, CurrencyId, CurrencyRate, Sno, ProductId, GodownId, BranchId, CostCenterId, \n");
				strSql.Append("AltQuantity, AltUnitId, Quantity, ProductUnitId, AltStockQuantity, StockQuantity, FreeQuantity, StockFreeQuantity, FreeUnitId, ConversionRatio, Rate, BasicAmount, TermAmount, NetAmount, TransactionType, \n");
				strSql.Append("Source, GodownDetailId, DocumentValue, BillTerm, StockValue, TmpStockValue, ExtraFreeQty, ExtraStockFreeQty, ExtraFreeUnit, RefVoucherNo, ReferenceSource, Issueqty,IsBillCancel) \n");
				strSql.Append("Select SIM.VoucherNo,VDate,VMiti,VTime,LedgerId,SalesmanId,DepartmentId1,DepartmentId2,DepartmentId3, CurrencyId,CurrencyRate,Sno,ProductId,GodownId,BranchId, null as CostCenterId, \n");
				strSql.Append("AltQty,ProductAltUnit, Qty,ProductUnit,AltQty,Qty,0 as FreeQty,0 as StFreeQty,null as FreeUnitId ,1 as Ratio, [SID].SalesRate, [SID].BasicAmount,[SID].TermAmount as ProductTerm,[SID].NetAmount ,'O'as TransactionType  , \n");
				strSql.Append("'SB' as Source,SID.GodownId,0 as DocumentValue, SIM.TermAmount as BillTerm,0 as StockValue,0 as TmpStockValue, 0 as ExtraFreeQty, 0 as ExtraStockFreeQty,null as  ExtraFreeUnit,null as RefVoucherNo, null as ReferenceSource, 0 as  Issueqty, 0 as IsBillCancel \n");
				strSql.Append("from ERP.SalesInvoiceMaster SIM Left Outer Join ERP.SalesInvoiceDetails [SID] on[SID].VoucherNo= SIM.VoucherNo where ProductId in (Select ProductId from erp.Product where [ProductCategory] <> 'S') \n");
				strSql.Append("and SIM.VoucherNo=@VoucherNo \n");
			}
			else
			{
				strSql.Append("delete from ERP.InventoryTransaction where VoucherNo='" + Model.ChallanNo + "' and [Source]='SC'\n");
				strSql.Append("Insert Into ERP.InventoryTransaction\n");
				strSql.Append("(VoucherNo, VDate, VMiti, VTime, LedgerId, SalesManId, DepartmentId1, DepartmentId2, DepartmentId3, CurrencyId, CurrencyRate, Sno, ProductId, GodownId, BranchId, CostCenterId,\n");
				strSql.Append("AltQuantity, AltUnitId, Quantity, ProductUnitId, AltStockQuantity, StockQuantity, FreeQuantity, StockFreeQuantity, FreeUnitId, ConversionRatio, Rate, BasicAmount, TermAmount, NetAmount, TransactionType,\n");
				strSql.Append("Source, GodownDetailId, DocumentValue, BillTerm, StockValue, TmpStockValue, ExtraFreeQty, ExtraStockFreeQty, ExtraFreeUnit, RefVoucherNo, ReferenceSource, Issueqty, IsBillCancel)\n");
				strSql.Append("Select '" + Model.ChallanNo + "' as VoucherNo,VDate,VMiti,VTime,LedgerId,SalesmanId,DepartmentId1,DepartmentId2,DepartmentId3, CurrencyId,CurrencyRate,Sno,ProductId,GodownId,BranchId, null as CostCenterId,\n");
				strSql.Append("AltQty,ProductAltUnit, Qty,ProductUnit,AltQty,Qty,0 as FreeQty,0 as StFreeQty,null as FreeUnitId ,1 as Ratio, [SID].SalesRate, [SID].BasicAmount,[SID].TermAmount as ProductTerm,[SID].NetAmount ,'O'as TransactionType,\n");
				strSql.Append("'SC' as Source,SID.GodownId,0 as DocumentValue, SIM.TermAmount as BillTerm,0 as StockValue,0 as TmpStockValue, 0 as ExtraFreeQty, 0 as ExtraStockFreeQty,null as  ExtraFreeUnit,@VoucherNo as RefVoucherNo, 'SB' as ReferenceSource, 0 as  Issueqty, NULL as IsBillCancel\n");
				strSql.Append("from ERP.SalesChallanMaster SIM Left Outer Join ERP.SalesChallanDetails [SID] on[SID].VoucherNo= SIM.VoucherNo where ProductId in (Select ProductId from erp.Product where [ProductCategory] <> 'S')\n");
				strSql.Append("and SIM.VoucherNo='" + Model.ChallanNo + "'\n\n");
			}

            strSql.Append("Insert into  ERP.FinanceTransaction (VoucherNo, VDate, VMiti, VTime, CurrencyId, CurrencyRate, DepartmentId1, DepartmentId2, DepartmentId3, DepartmentId4, BranchId, CompanyUnitId, \n");
            strSql.Append("SalesmanId, LedgerId, SubLedgerId, DrAmt, CrAmt, LocalDrAmt, LocalCrAmt, ReconcileDate, SNo, CbCode, EffecDate, TDueDate, RefVNo, ClearingDate, ClearedBy, EnterBy, Naration, Remarks, Source, ChequeNo, ChequeDate, ChequeMiti, IsBillCancel) \n");
            strSql.Append("select VoucherNo,VDate,VMiti,VTime,CurrencyId, CurrencyRate,DepartmentId1,DepartmentId2,DepartmentId3,DepartmentId4,BranchId,CompanyUnitId, \n");
            strSql.Append("SalesmanId,LedgerId,SubLedgerId,DrAmt,CrAmt, \n");
            strSql.Append("LocalDrAmt,LocalCrAmt,ReconcileDate,Sno,NULL AS CbCode, NULL AS EffecDate, NULL AS  TDueDate,NULL AS RefVNo, NULL AS ClearingDate,NULL AS ClearedBy,EnterBy, Naration,Remarks,Source,null as ChequeNo, null as ChequeDate, null as  ChequeMiti,IsBillCancel \n");
            strSql.Append("from ( \n");
            strSql.Append("SELECT VoucherNo, VDate,VMiti,VTime, CurrencyId,CurrencyRate,DepartmentId1,DepartmentId2,DepartmentId3,DepartmentId4, \n");
            strSql.Append("BranchId,CompanyUnitId, LedgerId,SubLedgerId, NetAmount AS DrAmt, 0  AS CrAmt, NetAmount * CurrencyRate \n");
            strSql.Append("AS LocalDrAmt, 0 AS LocalCrAmt, '' as Naration,Remarks,'SB' as Source,EnterBy,SalesmanId, \n");
            strSql.Append("0 as Sno,ReconcileDate,IsBillCancel \n");
            strSql.Append("From ERP.SalesInvoiceMaster \n");
            strSql.Append("WHERE VoucherNo=@VoucherNo \n");
            strSql.Append("Union All \n");
            strSql.Append("SELECT SIM.VoucherNo, VDate,VMiti,VTime, CurrencyId,CurrencyRate,SIM.DepartmentId1,SIM.DepartmentId2,SIM.DepartmentId3,SIM.DepartmentId4, \n");
            strSql.Append("BranchId,CompanyUnitId, ISNULL(SalesLedgerId,SBLedgerId) as LedgerId,SubLedgerId, 0 AS DrAmt, \n");
            strSql.Append("Sum(P_DT.BasicAmount)  AS CrAmt, 0 AS Local_DrAmt, Sum(P_DT.BasicAmount * SIM.CurrencyRate) \n");
            strSql.Append("AS LocalCrAmt, '' as Naration,SIM.Remarks,'SB' as Source,SIM.EnterBy,SIM.SalesmanId,0 As Sno,ReconcileDate,IsBillCancel \n");
            strSql.Append("FROM ERP.SalesInvoiceMaster as SIM,ERP.SalesInvoiceDetails as P_DT,ERP.SystemSetting,ERP.Product \n");
            strSql.Append("where P_DT.ProductId =  Product.ProductId And P_DT.VoucherNo = SIM.VoucherNo \n");
            strSql.Append("AND SIM.VoucherNo=@VoucherNo \n");
            strSql.Append("group by SIM.VoucherNo,SBLedgerId, VDate ,VMiti, VTime, CurrencyId, CurrencyRate, SIM.DepartmentId1,SIM.DepartmentId2,SIM.DepartmentId3,SIM.DepartmentId4, \n");
            strSql.Append("BranchId,CompanyUnitId, SIM.Remarks, SalesLedgerId,SubLedgerId,SIM.EnterBy,SalesmanId,ReconcileDate,IsBillCancel \n");
            strSql.Append("Union All \n");
            strSql.Append("Select VoucherNo,VDate,VMiti,VTime,CurrencyId,CurrencyRate,DepartmentId1,DepartmentId2,DepartmentId3,DepartmentId4,BranchId,CompanyUnitId, LedgerId,SubLedgerId, \n");
            strSql.Append("Case when Amt < 0 then ABS(Amt) else 0 end as DrAmt, Case when Amt > 0 then Amt else 0 end as CrAmt, \n");
            strSql.Append("Case when Amt < 0 then (ABS(Amt) * CurrencyRate) else 0 end as Local_DrAmt, Case when Amt > 0 \n");
            strSql.Append("then (Amt * CurrencyRate) else 0 end as Local_CrAmt, Naration,Remarks,Source,EnterBy,SalesmanId,0 as Sno,ReconcileDate,IsBillCancel \n");
            strSql.Append("from( \n");
            strSql.Append("SELECT SIM.VoucherNo, VDate,VMiti, \n");
            strSql.Append("VTime, CurrencyId,CurrencyRate,SIM.DepartmentId1,SIM.DepartmentId2,SIM.DepartmentId3,SIM.DepartmentId4,BranchId,CompanyUnitId, \n");
            strSql.Append("ISNULL(( \n");
            strSql.Append("Select Distinct LedgerId from ERP.SalesProductTerm where TermId is not null and \n");
            strSql.Append("SalesProductTerm.TermId = SBT.TermId and  SalesProductTerm.ProductId  = SIT.ProductId),SBT.LedgerId) as LedgerId, \n");
            strSql.Append("SubLedgerId, Sum(CASE WHEN SBT.STSign= '+' THEN SIT.LocalTermAmt ELSE - SIT.LocalTermAmt END) AS Amt, '' as Naration, \n");
            strSql.Append("SIM.Remarks,'SB' as Source,SIM.EnterBy,NULL as SalesmanId,0 As Sno,ReconcileDate,IsBillCancel \n");
            strSql.Append("FROM ERP.SalesInvoiceTerm as SIT,ERP.SalesBillingTerm AS SBT, \n");
            strSql.Append("ERP.SalesInvoiceMaster as SIM \n");
            strSql.Append("where SIT.TermId = SBT.TermId and SIT.VoucherNo =  SIM.VoucherNo  and SIT.TermType<>'BT' \n");
            strSql.Append("and SIM.VoucherNo=@VoucherNo \n");
            strSql.Append("group by SBT.TermId,SIM.VoucherNo,SIM.VDate,SIM.VMiti,SIM.VTime, \n");
            strSql.Append("CurrencyId,CurrencyRate,SIM.DepartmentId1,SIM.DepartmentId2,SIM.DepartmentId3,SIM.DepartmentId4,BranchId,CompanyUnitId, \n");
            strSql.Append("SBT.LedgerId,SIM.Remarks,SubLedgerId,ProductId,SIM.EnterBy,Sno,ReconcileDate,IsBillCancel \n");
            strSql.Append(") as SbTerm \n");
            strSql.Append(")as FinTransaction \n");

            if (Model.EntryFromProject == "Restaurant")
            {
                strSql.Append("Update Erp.TableMaster Set TableStatus='A' where TableId='" + Model.TableId + "' \n");
                strSql.Append("Update Erp.SalesOrderMaster Set ResIsCurrentOrder='N' where VoucherNo=@VoucherNo \n");
            }

			strSql.Append("Update ERP.InventoryTransaction set DocumentValue = DocValue from(\n");
			strSql.Append("Select Sum(LocalNetAmount) + Isnull(TAmt, 0) as DocValue, SalesInvoiceDetails.VoucherNo, SalesInvoiceDetails.ProductId, SalesInvoiceDetails.SNo\n");
			strSql.Append("from ERP.SalesInvoiceDetails Left Outer join (\n");
			strSql.Append("select VoucherNo,Sno,ProductId,sum(Case when stsign = '+' then LocalTermAmt else -LocalTermAmt end) as TAmt from ERP.SalesInvoiceTerm\n");
			strSql.Append("where TermId in (\n");
			strSql.Append("Select TermId from ERP.SalesBillingTerm where Profitability = 1\n");
			strSql.Append(") and TermType in ('P', 'BT')\n");
			strSql.Append("and LocalTermAmt<> 0 and VoucherNo = @VoucherNo Group by VoucherNo,Sno,ProductId ) as Tab on Tab.ProductId = SalesInvoiceDetails.ProductId\n");
			strSql.Append("and Tab.Sno = SalesInvoiceDetails.Sno and Tab.VoucherNo = SalesInvoiceDetails.VoucherNo where SalesInvoiceDetails.VoucherNo = @VoucherNo \n");
			strSql.Append("group by TAmt,SalesInvoiceDetails.VoucherNo,SalesInvoiceDetails.ProductId,SalesInvoiceDetails.SNo\n");
			strSql.Append(") as Tab1 where InventoryTransaction.VoucherNo = Tab1.VoucherNo and InventoryTransaction.ProductId = Tab1.ProductId and InventoryTransaction.SNo = Tab1.Sno and Source = 'SB'\n");

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

        public DataSet GetDataSalesVoucher(string VoucherNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" Select SIM.*,GLDesc,GlCategory,SubledgerDesc,SalesmanDesc,D1.DepartmentId as DepartmentId1,D1.DepartmentDesc as DepartmentDesc1,D2.DepartmentId as DepartmentId2,D2.DepartmentDesc as DepartmentDesc2,D3.DepartmentId as DepartmentId3,D3.DepartmentDesc as DepartmentDesc3,D4.DepartmentId as DepartmentId4,D4.DepartmentDesc as DepartmentDesc4,  \n");
            strSql.Append(" CurrencyDesc,BranchName,CU.CmpUnitName  \n");
            strSql.Append("from erp.salesInvoiceMaster SIM  \n");
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
                strSql.Append(" where voucherNo='" + VoucherNo + "' \n");
            strSql.Append("Select[SID].*,ProductShortName, ProductDesc,PD.AltConv,PAU.ProductUnitShortName as ProductAltUnitDesc,PU.ProductUnitShortName as ProductUnitDesc,GodownDesc from erp.SalesInvoiceDetails[SID] \n");
            strSql.Append("left join erp.Product PD on[SID].ProductId = PD.ProductId  \n");
            strSql.Append("left join erp.ProductUnit PU on[SID].ProductUnit = PU.ProductUnitId  \n");
            strSql.Append("left join erp.ProductUnit PAU on[SID].ProductAltUnit = PAU.ProductUnitId  \n");
            strSql.Append("left join erp.Godown GD on[SID].GodownId = GD.GodownId  \n");
            if (!string.IsNullOrEmpty(VoucherNo))
                strSql.Append("where voucherNo='" + VoucherNo + "' \n");
            strSql.Append("Select * from erp.SalesInvoiceTerm  \n");
            if (!string.IsNullOrEmpty(VoucherNo))
                strSql.Append("where voucherNo='" + VoucherNo + "' \n");
            strSql.Append("select * from[ERP].[UDFDataEntry] where VoucherNo = '" + VoucherNo + "' and EntryModule = 'SB'\n");
            strSql.Append("Select * from ERP.SalesInvoiceOtherDetails  where VoucherNo = '" + VoucherNo + "' \n");
            strSql.Append("Select * from ERP.SalesInvoiceBillingAddress  where VoucherNo = '" + VoucherNo + "' \n");
            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        public string BillCancel(string VoucherNo)
        {
            StringBuilder strSql = new StringBuilder();
            try
            {
                strSql.Append(" Update [ERP].SalesInvoiceMaster set IsBillCancel=1  where VoucherNo='" + VoucherNo + "' \n ");
                strSql.Append(" Update [ERP].[FinanceTransaction] set IsBillCancel=1  where VoucherNo='" + VoucherNo + "' \n ");
                strSql.Append(" Update [ERP].[InventoryTransaction] set IsBillCancel=1  where VoucherNo='" + VoucherNo + "' \n ");
                DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString());
                return VoucherNo;
            }
            catch
            {
                return "";
            }
        }

        public DataTable GetMemberPercent(string member)
        {
            return DAL.ExecuteDataset(CommandType.Text, "Select * from erp.Salesman left join  erp.MemberType on erp.MemberType.MemberTypeId =  erp.Salesman.MemberTypeId where SalesmanDesc ='" + member + "'").Tables[0];
        }
        public DataSet GetDataRestaurantSalesVoucher(string VoucherNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select SIM.*,SOM.TableId,TM.TableDesc,SOM.ResNoOfPacks,GLDesc,SubledgerDesc,SalesmanDesc,D1.DepartmentShortName as DepartmentShortName1 ,D2.DepartmentShortName as DepartmentShortName2 ,D3.DepartmentShortName as DepartmentShortName3   \n");
            strSql.Append(", D4.DepartmentShortName as DepartmentShortName4, CurrencyDesc,BranchName,CU.CmpUnitName  \n");
            strSql.Append("from erp.salesInvoiceMaster SIM  \n");
            strSql.Append("left join erp.SalesOrderMaster SOM on SOM.VoucherNo = SIM.OrderNo  \n");
            strSql.Append("left Join erp.GeneralLedger GL on SIM.ledgerId = GL.LedgerID  \n");
            strSql.Append("left Join erp.Subledger SGL on SIM.SubledgerId = SGL.SubledgerId  \n");
            strSql.Append("left Join erp.Salesman SM on SIM.ledgerId = SM.SalesmanId \n");
            strSql.Append("left Join erp.Department D1 on SIM.DepartmentId1 = D1.DepartmentID  \n");
            strSql.Append("left Join erp.Department D2  on SIM.DepartmentId2 = D2.DepartmentID  \n");
            strSql.Append("left Join erp.Department D3 on SIM.DepartmentId3 = D3.DepartmentID  \n");
            strSql.Append("left Join erp.Department D4 on SIM.DepartmentId4 = D4.DepartmentID  \n");
            strSql.Append("left Join erp.Currency CY on SIM.CurrencyId = CY.CurrencyId  \n");
            strSql.Append("left Join erp.Branch BR on SIM.BranchId = BR.BranchId  \n");
            strSql.Append("left Join erp.CompanyUnit CU on SIM.CompanyUnitId = CU.CompanyUnitId \n");
            strSql.Append(" left join erp.TableMaster TM on TM.TableId = SOM.TableId \n");
            if (!string.IsNullOrEmpty(VoucherNo))
                strSql.Append(" where SIM.voucherNo='" + VoucherNo + "' \n");

            strSql.Append("Select [SID].*,ProductShortName,ProductPrintingName,SOD.TermDetails, SOD.ResOrderTime,SOD.ResIsFirePrinter,SOD.ResIsPrinted,SOD.ResKOTNo,SOD.ResOrderBy,SOD.ResOrderNotes,SOD.ResOrderTime, ProductDesc,PAU.ProductUnitDesc as ProductAltUnitDesc,PU.ProductUnitDesc as ProductUnitDesc,GodownDesc from erp.SalesInvoiceDetails[SID]  \n");
            strSql.Append("left join erp.SalesOrderDetails SOD on SOD.VoucherNo =[SID].OrderNo and SOD.sno =[SID].Sno \n");
            strSql.Append("left join erp.Product PD on[SID].ProductId = PD.ProductId  \n");
            strSql.Append("left join erp.ProductUnit PU on[SID].ProductUnit = PU.ProductUnitId  \n");
            strSql.Append("left join erp.ProductUnit PAU on[SID].ProductAltUnit = PAU.ProductUnitId  \n");
            strSql.Append("left join erp.Godown GD on[SID].GodownId = GD.GodownId  \n");
            if (!string.IsNullOrEmpty(VoucherNo))
                strSql.Append(" where [SID].voucherNo='" + VoucherNo + "' \n");

            strSql.Append("Select * from erp.SalesInvoiceTerm  \n");
            if (!string.IsNullOrEmpty(VoucherNo))
                strSql.Append(" where voucherNo='" + VoucherNo + "' \n");

            return DAL.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        public int GetSalesQuantityProductWise(string VoucherNo, int ProductId, int Sno)
        {
            return Convert.ToInt32(DAL.ExecuteDataset(CommandType.Text, "select Qty from ERP.SalesChallanDetails where VoucherNo='" + VoucherNo+"' and ProductId='"+ ProductId + "' and Sno='"+ Sno + "'").Tables[0].Rows[0]["Qty"]);
        }
    }

    public class SalesInvoiceMasterViewModel
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
        public decimal TenderAmount { get; set; }
        public decimal TaxableAmount { get; set; }
        public decimal TaxFreeAmount { get; set; }
        public decimal VatAmount { get; set; }
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
        public string InvoiceType { get; set; }
        public string EnterBy { get; set; }
        public DateTime EnterDate { get; set; }
        public int PrintCopy { get; set; }
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
        public int IsBillCancel { get; set; }
        public string CancelRemarks { get; set; }
        public Nullable<DateTime> CancelInvoiceDate { get; set; }
        public Nullable<DateTime> CancelInvoiceTime { get; set; }
        public string EntryFromProject { get; set; }
        public DataTable UdfDetails { get; set; }
        public DataTable UdfMaster { get; set; }
        public int TableId { get; set; }
    }
    public class SalesInvoiceDetailsViewModel
    {
        public string VoucherNo { get; set; }
        public int Sno { get; set; }
        public int ProductId { get; set; }
        public int ProductAltUnitId { get; set; }
        public int ProductUnitId { get; set; }
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
        public decimal StockQty { get; set; }
        public decimal AltStockQty { get; set; }
        public string OrderNo { get; set; }
        public int OrderSNo { get; set; }
        public string DispatchOrderNo { get; set; }
        public int DispatchOrderSNo { get; set; }
        public string ChallanNo { get; set; }
        public int ChallanSNo { get; set; }
        public decimal TaxableAmount { get; set; }
        public decimal TaxFreeAmount { get; set; }
        public decimal VatAmount { get; set; }
        public bool IsTaxable { get; set; }
    }
    public class TermViewModel
    {
        public string VoucherNo { get; set; }
        public int Sno { get; set; }
        public int ProductId { get; set; }
        public int TermId { get; set; }
        public string TermType { get; set; }
        public string STSign { get; set; }
        public string PTSign { get; set; }
        public decimal TermRate { get; set; }
        public decimal TermAmt { get; set; }
        public decimal LocalTermAmt { get; set; }
    }
    public class BillingAddressViewModel
    {
        public string VoucherNo { get; set; }
        public int LedgerId { get; set; }
        public string GlDesc { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        public string BillingEmail { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingEmail { get; set; }
        public Nullable<DateTime> DeliveryDate { get; set; }
        public string Remarks { get; set; }
    }
    public class OtherDetailsViewModel
    {
        public string VoucherNo { get; set; }
        public string Transport { get; set; }
        public string VehicleNo { get; set; }
        public string Package { get; set; }
        public string CnNo { get; set; }
        public Nullable<DateTime> CnDate { get; set; }
        public string CnFreight { get; set; }
        public string CnType { get; set; }
        public string Advance { get; set; }
        public string BalFreight { get; set; }
        public string DriverName { get; set; }
        public string DriverLicNo { get; set; }
        public string DriverMobileNo { get; set; }
        public string ContractNo { get; set; }
        public Nullable<DateTime> ContractDate { get; set; }
        public string ExpInvNo { get; set; }
        public Nullable<DateTime> ExpInvDate { get; set; }
        public string PoNo { get; set; }
        public Nullable<DateTime> PoDate { get; set; }
        public string DocBank { get; set; }
        public string LcNo { get; set; }
        public string CustomName { get; set; }
        public string Cofd { get; set; }
    }
    public class SalesIrdViewModel
    {
        public string VoucherNo { get; set; }
        public int IsIRDSync { get; set; }
        public int IsRealTimeIRDSync { get; set; }
        public int PrintCopy { get; set; }
        public string PrintedBy { get; set; }
        public Nullable<DateTime> PrintedDate { get; set; }
    }

    public static class CashPartyViewModel
    {
        public static string PartyName { get; set; }
        public static string PartyVatNo { get; set; }
        public static string PartyAddress { get; set; }
        public static string PartyMobileNo { get; set; }
        public static string PartyEmail { get; set; }
        public static string ChequeNo { get; set; }
        public static Nullable<DateTime> ChequeDate { get; set; }
        public static string ChequeMiti { get; set; }
    }
}