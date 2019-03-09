using DataAccessLayer.Interface.MasterSetup;
using DataAccessLayer.MasterSetup;
using DataAccessLayer.SystemSetting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DataAccessLayer.Common
{
    public static class ClsGlobal
    {
        public static bool ShowMdiForm = false;
        public static bool ShowLoginForm = false;
        public static bool ShowCompanyList = false;
        public static bool ShowCompanyCreate = false;
        public static string LoginUserCode = "";
        public static string Initial = "";
        public static string CompanyName = "";
        public static string CompanyAddress = "";
        public static string CompanyPhoneNo = "";
        public static string CompanyFiscalYear = "";
        public static string BranchDesc = "";
        public static string CompanyUnitDesc = "";
        public static string CompanyStartDate = "";
        public static string CompanyEndDate = "";
        public static string CompanyStartMiti = "";
        public static string CompanyEndMiti = "";
        public static string DatabaseName = "";

        public static string CounterDesc = "";
        public static int CounterId = 0;
        public static int BranchId = 0;
        public static int CompanyUnitId = 0;

        public static DateTime TodayDate;
        public static DateTime TodayDateTime;

        public static bool _Transby_Code = false;
        public static bool _Product_Code = false;

        public static string GLDesc = "";
        public static string FilterGlCategory = "";

        public static int LedgerId = 0;
        public static string ModuleName = "";

        public static string IsBillWise = "";
        public static byte[] Departmentlen;
        public static string SalesmanType = "";
        public static string billingType = "";
        public static string ProductGroup = "";
        public static string SoftwareFocus = "";
		public static bool PosBillValid = true;


        #region -------------- ENTRY CONTROL VARIABLE  ------------------
        //------------------- START UDF ------------------------
        public static DataTable UDFExistingDataMaster = new DataTable();
        public static DataTable UDFExistingDataTableDetails = new DataTable();

        public static List<string> FieldNameArrMaster = new List<string>();
        public static List<string> UDFDataArrMaster = new List<string>();
        public static List<string> UDFDuplicateOptArrMaster = new List<string>();

        public static List<string> UDFCodeArrayDetails = new List<string>();
        public static List<string> UDFDataArrayDetails = new List<string>();
        //------------------- END UDF ------------------------

        //------------------- PDC ------------------------
        public static string PdcLedgerControlVal = "";
        //------------------- END PDC ------------------------

        public static char FinanceVoucherDateControlVal = 'N';
        public static char FinanceCurrencyControlVal = 'N';
        public static char FinanceMCurrencyControlVal = 'N';
        public static char FinanceDepartmentControlVal = 'N';
        public static char FinanceMDepartmentControlVal = 'N';
        public static char FinanceDepartmentItemControlVal = 'N';
        public static char FinanceMDepartmentItemControlVal = 'N';
        public static char FinanceNarrationControlVal = 'Y';
        public static char FinanceMNarrationControlVal = 'N';
        public static char FinanceSalesmanControlVal = 'N';
        public static char FinanceMSalesmanControlVal = 'N';
        public static char FinanceSubledgerControlVal = 'N';
        public static char FinanceMSubledgerControlVal = 'N';
        public static char FinanceItemSubledgerControlVal = 'N';
        public static char FinanceMItemSubledgerControlVal = 'N';
        public static char FinanceRemarksControlVal = 'N';
        public static char FinanceMRemarksControlVal = 'N';
		public static char FinanceProvisionalControlVal = 'N';
		public static char FinanceMProvisionalControlVal = 'N';
		public static char FinancePDCControlVal = 'N';
		public static char FinanceMPDCControlVal = 'N';
		public static char FinanceCashIndentControlVal = 'N';
		public static char FinanceMCashIndentControlVal = 'N';
		public static char FinanceRefNumberControlVal = 'N';
		public static char FinanceMRefNumberControlVal = 'N';

		public static char PurchaseBillTypeControlVal = 'N';
        public static char PurchaseProductGroupWiseControlVal = 'N';
        public static char PurchaseProductSubGroupWiseControlVal = 'N';
        public static char PurchaseUnitConversionControlVal = 'N';
        public static char PurchaseAdditionalDescControlVal = 'N';
        public static char PurchaseProductUnitControlVal = 'N';
        public static char PurchaseVoucherDateControlVal = 'N';
        public static char PurchaseIndentControlVal = 'N';
        public static char PurchaseMIndentControlVal = 'N';
        public static char PurchaseQuotationControlVal = 'N';
        public static char PurchaseMQuotationControlVal = 'N';
        public static char PurchaseOrderControlVal = 'N';
        public static char PurchaseMOrderControlVal = 'N';
        public static char PurchaseChallanControlVal = 'N';
        public static char PurchaseMChallanControlVal = 'N';
        public static char PurchaseReferenceNoControlVal = 'N';
        public static char PurchaseMReferenceNoControlVal = 'N';
        public static char PurchaseDepartmentControlVal = 'N';
        public static char PurchaseMDepartmentControlVal = 'N';
        public static char PurchaseSalesmanControlVal = 'N';
        public static char PurchaseMSalesmanControlVal = 'N';
        public static char PurchaseSubledgerControlVal = 'N';
        public static char PurchaseMSubledgerControlVal = 'N';
        public static char PurchaseCurrencyControlVal = 'N';
        public static char PurchaseMCurrencyControlVal = 'N';
        public static char PurchaseRemarksControlVal = 'N';
        public static char PurchaseMRemarksControlVal = 'N';
        public static char PurchaseGodownControlVal = 'N';
        public static char PurchaseMGodownControlVal = 'N';

        public static char SalesDispatchOrderControlVal = 'N';
        public static char SalesProductGroupWiseControlVal = 'N';
        public static char SalesProductSubGroupWiseControlVal = 'N';
        public static char SalesUnitConversionControlVal = 'N';
        public static char SalesAdditionalDescControlVal = 'N';
        public static char SalesProductUnitControlVal = 'N';
        public static char SalesVoucherDateControlVal = 'N';
        public static char SalesChangeBasicAmountControlVal = 'N';
        public static char SalesQuotationControlVal = 'N';
        public static char SalesMQuotationControlVal = 'N';
        public static char SalesOrderControlVal = 'N';
        public static char SalesMOrderControlVal = 'N';
        public static char SalesChallanControlVal = 'N';
        public static char SalesMChallanControlVal = 'N';
        public static char SalesReferenceNoControlVal = 'N';
        public static char SalesMReferenceNoControlVal = 'N';
        public static char SalesDepartmentControlVal = 'N';
        public static char SalesMDepartmentControlVal = 'N';
        public static char SalesSalesmanControlVal = 'N';
        public static char SalesMSalesmanControlVal = 'N';
        public static char SalesSubledgerControlVal = 'N';
        public static char SalesMSubledgerControlVal = 'N';
        public static char SalesCurrencyControlVal = 'N';
        public static char SalesMCurrencyControlVal = 'N';
        public static char SalesRemarksControlVal = 'N';
        public static char SalesMRemarksControlVal = 'N';
        public static char SalesGodownControlVal = 'N';
        public static char SalesMGodownControlVal = 'N';

        public static char InventoryVoucherDateControlVal = 'N';
        public static char InventoryProductGroupWiseControlVal = 'N';
        public static char InventoryProductSubGroupWiseControlVal = 'N';
        public static char InventoryUnitConversionControlVal = 'N';
        public static char InventoryAdditionalDescControlVal = 'N';
        public static char InventoryProductUnitControlVal = 'N';
        public static char InventoryFreeQtyControlVal = 'N';
        public static char InventoryExtraFreeQtyControlVal = 'N';
        public static char InventoryMfgDateControlVal = 'N';
        public static char InventoryExpDateControlVal = 'N';

        public static char InventorySalesmanControlVal = 'N';
        public static char InventoryMSalesmanControlVal = 'N';
        public static char InventorySubledgerControlVal = 'N';
        public static char InventoryMSubledgerControlVal = 'N';
        public static char InventoryCurrencyControlVal = 'N';
        public static char InventoryMCurrencyControlVal = 'N';
        public static char InventoryDepartmentControlVal = 'N';
        public static char InventoryMDepartmentControlVal = 'N';
        public static char InventoryRemarksControlVal = 'N';
        public static char InventoryMRemarksControlVal = 'N';
        public static char InventoryCostCenterControlVal = 'N';
        public static char InventoryMCostCenterControlVal = 'N';
        public static char InventoryCostCenterItemControlVal = 'N';
        public static char InventoryMCostCenterItemControlVal = 'N';
        public static char InventoryGodownControlVal = 'N';
        public static char InventoryMGodownControlVal = 'N';
        public static char InventoryGodownItemControlVal = 'N';
        public static char InventoryMGodownItemControlVal = 'N';
        public static string InventoryAltQtyConversion = "N";
        public static string InventoryAltQtyConversionRatioChange = "N";

        #endregion

        #region -------------- SYSTEM CONTROL VARIABLE ------------------
        public static int _AmountDecimalFormat = 3;
        public static int _RateDecimalFormat = 2;
        public static int _QtyDecimalFormat = 2;
        public static int _AltQtyDecimalFormat = 2;
        public static int _CurrencyDecimalFormat = 3;
        public static string DateType = "M";
        public static string BranchOrCompanyUnitWise = "";
        public static int ConfirmSave = 0;
        public static int ConfirmFormClose = 0;
        public static int ConfirmFormClear = 0;
        public static string Audit_Trial = "";
        public static int UDFSystem = 0;
        public static int SBBillDiscountTermId = 0;
        public static int SBVatTermId = 0;
        public static string CurrentDate = "";
        public static string CurrCode = "";
        public static int DefaultCurrency = 0;
        public static int BackupSchIntvDays = 0;
        public static int CardLedgerId = 0;
        public static string BackupPath = "";
        public static int PLLedgerId = 0;
        public static int CashLedgerId = 0;
        public static int VatLedgerId = 0;
        public static int PDCBankLedgerId = 0;
        public static string FontName = "";
        public static decimal FontSize = 0;
        public static decimal PaperSize = 0;
        public static string ReportFontStyle = "";
        public static int PrintingDateTime = 0;
        public static int PBLedgerId = 0;
        public static int PRLedgerId = 0;
        public static int PBVatTermId = 0;
        public static int PABVatTermId = 0;
        public static string PBCreditBalanceWarning = "";
        public static string PBCreditDaysWarning = "";
        public static int PBCarryRate = 0;
        public static int PBLastRate = 0;
        public static int PBBatchRate = 0;
        public static int PBGrpWiseBilling = 0;
        public static int PBAdvancePayment = 0;
        public static int SBLedgerId = 0;
        public static int SRLedgerId = 0;
        public static int SBSpecialDiscountTermId = 0;
        public static int SBServiceChargeTermId = 0;
        public static string SBCreditBalanceWarning = "";
        public static string SBCreditDaysWarning = "";
        public static int SBChangeRate = 0;
        public static int SBLastRate = 0;
        public static int SBCarryRate = 0;
        public static int DefaultInvoicePrintDesignId = 0;
        public static int DefaultPOSDocNumberingId = 0;
        public static int DefaultOrderPrintDesignId = 0;
        public static int DefaultOrderDocNumberingId = 0;
        public static int StockValueInSalesReturn = 0;
        public static int AvailableStock = 0;
        public static int SBGrpWiseBilling = 0;
        public static int OpeningStockLedgerId = 0;
        public static int ClosingStockLedgerId = 0;
        public static int StockInHandLedgerId = 0;
        public static string NegativeStockWarning = "";
        public static int AltQtyAlteration = 0;
        public static int AlterationPart = 0;
        public static int CarryBatchQty = 0;
        public static int BreakupQty = 0;
        public static int MfgDate = 0;
        public static int ExpDate = 0;
        public static int MfgDateValidation = 0;
        public static int ExpDateValidation = 0;
        public static int FreeQty = 0;
        public static int ExtraFreeQty = 0;
        public static int IGodownWiseFilter = 0;
        public static int SalaryLedgerId = 0;
        public static int TDSLedgerId = 0;
        public static int PFLedgerId = 0;
        public static string CompanyPrintName = "";
        public static string Gadget = "";
        public static int PBProductDiscountTermId = 0;
        public static int PBBillDiscountTermId = 0;
        public static int SBProductDiscountTermId = 0;
        public static int PBSubLedgerId = 0;
        public static int PRSubLedgerId = 0;
        public static int SBSubLedgerId = 0;
        public static int SRSubLedgerId = 0;
        public static int InterBranchPurchaseLedgerId = 0;
        public static int InterBranchSalesLedgerId = 0;

        //-----------
        //public static string AltQtyConversion = "N";
        //public static string AltQtyConversionRatioChange = "N";
        #endregion

        #region -------------- USER RESTRICTION VARIABLE ------------------
        public static int AccessSalesRateChange = 0;
        public static int AccessSalesTermChange = 0;
        public static int AccessPurchaseRateChange = 0;
        public static int AccessPurchaseTermChange = 0;
        #endregion

        public static void EntryControl(string Module)
        {
            ClsEntryControl objEntryControl = new ClsEntryControl();

            objEntryControl.GetEntryControl(Module);
            DataTable dt = objEntryControl.GetSystemSetting();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow ro in dt.Rows)
                {
                    ClsGlobal.DateType = ro["DateType"].ToString();
                    ClsGlobal.UDFSystem = string.IsNullOrEmpty(ro["UDFSystem"].ToString()) ? 0 : Convert.ToInt32(ro["UDFSystem"].ToString());
                    ClsGlobal.ConfirmSave = string.IsNullOrEmpty(ro["ConfirmSave"].ToString()) ? 0 : Convert.ToInt32(ro["ConfirmSave"].ToString());
                    ClsGlobal.ConfirmFormClose = string.IsNullOrEmpty(ro["ConfirmFormCancel"].ToString()) ? 0 : Convert.ToInt32(ro["ConfirmFormCancel"].ToString());
                    ClsGlobal.ConfirmFormClear = string.IsNullOrEmpty(ro["ConfirmFormClear"].ToString()) ? 0 : Convert.ToInt32(ro["ConfirmFormClear"].ToString());
                    ClsGlobal.DefaultCurrency = string.IsNullOrEmpty(ro["DefaultCurrencyId"].ToString()) ? 0 : Convert.ToInt32(ro["DefaultCurrencyId"].ToString());
                    ClsGlobal.BackupSchIntvDays = string.IsNullOrEmpty(ro["BackupSchIntvDays"].ToString()) ? 0 : Convert.ToInt32(ro["BackupSchIntvDays"].ToString());
                    ClsGlobal.BackupPath = ro["BackupPath"].ToString();
                    ClsGlobal.PLLedgerId = string.IsNullOrEmpty(ro["PLLedgerId"].ToString()) ? 0 : Convert.ToInt32(ro["PLLedgerId"].ToString());
                    ClsGlobal.CashLedgerId = string.IsNullOrEmpty(ro["CashLedgerId"].ToString()) ? 0 : Convert.ToInt32(ro["CashLedgerId"].ToString());
                    ClsGlobal.CardLedgerId = string.IsNullOrEmpty(ro["CardLedgerId"].ToString()) ? 0 : Convert.ToInt32(ro["CardLedgerId"].ToString());
                    ClsGlobal.VatLedgerId = string.IsNullOrEmpty(ro["VatLedgerId"].ToString()) ? 0 : Convert.ToInt32(ro["VatLedgerId"].ToString());
                    ClsGlobal.PDCBankLedgerId = string.IsNullOrEmpty(ro["PDCBankLedgerId"].ToString()) ? 0 : Convert.ToInt32(ro["PDCBankLedgerId"].ToString());
                    ClsGlobal._AmountDecimalFormat = string.IsNullOrEmpty(ro["AmountFormate"].ToString()) ? 3 : ro["AltQtyFormat"].ToString().Length - 1;
                    ClsGlobal._RateDecimalFormat = string.IsNullOrEmpty(ro["RateFormat"].ToString()) ? 2 : ro["RateFormat"].ToString().Length - 1;
                    ClsGlobal._QtyDecimalFormat = string.IsNullOrEmpty(ro["QtyFormat"].ToString()) ? 2 : ro["QtyFormat"].ToString().Length - 1;
                    ClsGlobal._AltQtyDecimalFormat = string.IsNullOrEmpty(ro["AltQtyFormat"].ToString()) ? 2 : ro["AltQtyFormat"].ToString().Length - 1;
                    ClsGlobal._CurrencyDecimalFormat = string.IsNullOrEmpty(ro["CurrencyFormat"].ToString()) ? 3 : ro["CurrencyFormat"].ToString().Length - 1;
                    ClsGlobal.FontName = ro["FontName"].ToString();
                    ClsGlobal.FontSize = string.IsNullOrEmpty(ro["FontSize"].ToString()) ? 0 : Convert.ToDecimal(ro["FontSize"].ToString());
                    ClsGlobal.PaperSize = string.IsNullOrEmpty(ro["PaperSize"].ToString()) ? 0 : Convert.ToDecimal(ro["PaperSize"].ToString());
                    ClsGlobal.ReportFontStyle = ro["ReportFontStyle"].ToString();
                    //ClsGlobal.PrintingDateTime = string.IsNullOrEmpty(ro["PrintingDateTime"].ToString()) ? 0 : Convert.ToInt32(ro["PrintingDateTime"].ToString());
                    ClsGlobal.PBLedgerId = string.IsNullOrEmpty(ro["PBLedgerId"].ToString()) ? 0 : Convert.ToInt32(ro["PBLedgerId"].ToString());
                    ClsGlobal.PRLedgerId = string.IsNullOrEmpty(ro["PRLedgerId"].ToString()) ? 0 : Convert.ToInt32(ro["PRLedgerId"].ToString());
                    ClsGlobal.PBVatTermId = string.IsNullOrEmpty(ro["PBVatTermId"].ToString()) ? 0 : Convert.ToInt32(ro["PBVatTermId"].ToString());
                    ClsGlobal.PABVatTermId = string.IsNullOrEmpty(ro["PABVatTermId"].ToString()) ? 0 : Convert.ToInt32(ro["PABVatTermId"].ToString());
                    ClsGlobal.PBCreditBalanceWarning = ro["PBCreditBalanceWarning"].ToString();
                    ClsGlobal.PBCreditDaysWarning = ro["PBCreditDaysWarning"].ToString();
                    ClsGlobal.PBCarryRate = string.IsNullOrEmpty(ro["PBCarryRate"].ToString()) ? 0 : Convert.ToInt32(ro["PBCarryRate"].ToString());
                    ClsGlobal.PBLastRate = string.IsNullOrEmpty(ro["PBLastRate"].ToString()) ? 0 : Convert.ToInt32(ro["PBLastRate"].ToString());
                    ClsGlobal.PBBatchRate = string.IsNullOrEmpty(ro["PBBatchRate"].ToString()) ? 0 : Convert.ToInt32(ro["PBBatchRate"].ToString());
                    ClsGlobal.PBGrpWiseBilling = string.IsNullOrEmpty(ro["PBGrpWiseBilling"].ToString()) ? 0 : Convert.ToInt32(ro["PBGrpWiseBilling"].ToString());
                    ClsGlobal.PBAdvancePayment = string.IsNullOrEmpty(ro["PBAdvancePayment"].ToString()) ? 0 : Convert.ToInt32(ro["PBAdvancePayment"].ToString());
                    ClsGlobal.SBLedgerId = string.IsNullOrEmpty(ro["SBLedgerId"].ToString()) ? 0 : Convert.ToInt32(ro["SBLedgerId"].ToString());
                    ClsGlobal.SRLedgerId = string.IsNullOrEmpty(ro["SRLedgerId"].ToString()) ? 0 : Convert.ToInt32(ro["SRLedgerId"].ToString());
                    ClsGlobal.SBVatTermId = string.IsNullOrEmpty(ro["SBVatTermId"].ToString()) ? 0 : Convert.ToInt32(ro["SBVatTermId"].ToString());
                    ClsGlobal.SBSpecialDiscountTermId = string.IsNullOrEmpty(ro["SBSpecialDiscountTermId"].ToString()) ? 0 : Convert.ToInt32(ro["SBSpecialDiscountTermId"].ToString());
                    ClsGlobal.SBServiceChargeTermId = string.IsNullOrEmpty(ro["SBServiceChargeTermId"].ToString()) ? 0 : Convert.ToInt32(ro["SBServiceChargeTermId"].ToString());
                    ClsGlobal.SBCreditBalanceWarning = ro["SBCreditBalanceWarning"].ToString();
                    ClsGlobal.SBCreditDaysWarning = ro["SBCreditDaysWarning"].ToString();
                    ClsGlobal.SBChangeRate = string.IsNullOrEmpty(ro["SBChangeRate"].ToString()) ? 0 : Convert.ToInt32(ro["SBChangeRate"].ToString());
                    ClsGlobal.SBLastRate = string.IsNullOrEmpty(ro["SBLastRate"].ToString()) ? 0 : Convert.ToInt32(ro["SBLastRate"].ToString());
                    ClsGlobal.SBCarryRate = string.IsNullOrEmpty(ro["SBCarryRate"].ToString()) ? 0 : Convert.ToInt32(ro["SBCarryRate"].ToString());
                    ClsGlobal.DefaultInvoicePrintDesignId = string.IsNullOrEmpty(ro["DefaultInvoicePrintDesignId"].ToString()) ? 0 : Convert.ToInt32(ro["DefaultInvoicePrintDesignId"].ToString());
                    ClsGlobal.DefaultPOSDocNumberingId = string.IsNullOrEmpty(ro["DefaultPOSDocNumberingId"].ToString()) ? 0 : Convert.ToInt32(ro["DefaultPOSDocNumberingId"].ToString());
                    ClsGlobal.DefaultOrderPrintDesignId = string.IsNullOrEmpty(ro["DefaultOrderPrintDesignId"].ToString()) ? 0 : Convert.ToInt32(ro["DefaultOrderPrintDesignId"].ToString());
                    ClsGlobal.DefaultOrderDocNumberingId = string.IsNullOrEmpty(ro["DefaultOrderDocNumberingId"].ToString()) ? 0 : Convert.ToInt32(ro["DefaultOrderDocNumberingId"].ToString());
                    ClsGlobal.StockValueInSalesReturn = string.IsNullOrEmpty(ro["StockValueInSalesReturn"].ToString()) ? 0 : Convert.ToInt32(ro["StockValueInSalesReturn"].ToString());
                    ClsGlobal.AvailableStock = string.IsNullOrEmpty(ro["AvailableStock"].ToString()) ? 0 : Convert.ToInt32(ro["AvailableStock"].ToString());
                    ClsGlobal.SBGrpWiseBilling = string.IsNullOrEmpty(ro["SBGrpWiseBilling"].ToString()) ? 0 : Convert.ToInt32(ro["SBGrpWiseBilling"].ToString());
                    ClsGlobal.OpeningStockLedgerId = string.IsNullOrEmpty(ro["OpeningStockLedgerId"].ToString()) ? 0 : Convert.ToInt32(ro["OpeningStockLedgerId"].ToString());
                    ClsGlobal.ClosingStockLedgerId = string.IsNullOrEmpty(ro["ClosingStockLedgerId"].ToString()) ? 0 : Convert.ToInt32(ro["ClosingStockLedgerId"].ToString());
                    ClsGlobal.StockInHandLedgerId = string.IsNullOrEmpty(ro["StockInHandLedgerId"].ToString()) ? 0 : Convert.ToInt32(ro["StockInHandLedgerId"].ToString());
                    ClsGlobal.NegativeStockWarning = ro["NegativeStockWarning"].ToString();
                    ClsGlobal.AltQtyAlteration = string.IsNullOrEmpty(ro["AltQtyAlteration"].ToString()) ? 0 : Convert.ToInt32(ro["AltQtyAlteration"].ToString());
                    ClsGlobal.AlterationPart = string.IsNullOrEmpty(ro["AlterationPart"].ToString()) ? 0 : Convert.ToInt32(ro["AlterationPart"].ToString());
                    ClsGlobal.CarryBatchQty = string.IsNullOrEmpty(ro["CarryBatchQty"].ToString()) ? 0 : Convert.ToInt32(ro["CarryBatchQty"].ToString());
                    ClsGlobal.BreakupQty = string.IsNullOrEmpty(ro["BreakupQty"].ToString()) ? 0 : Convert.ToInt32(ro["BreakupQty"].ToString());
                    ClsGlobal.MfgDate = string.IsNullOrEmpty(ro["MfgDate"].ToString()) ? 0 : Convert.ToInt32(ro["MfgDate"].ToString());
                    ClsGlobal.ExpDate = string.IsNullOrEmpty(ro["ExpDate"].ToString()) ? 0 : Convert.ToInt32(ro["ExpDate"].ToString());
                    ClsGlobal.MfgDateValidation = string.IsNullOrEmpty(ro["MfgDateValidation"].ToString()) ? 0 : Convert.ToInt32(ro["MfgDateValidation"].ToString());
                    ClsGlobal.ExpDateValidation = string.IsNullOrEmpty(ro["ExpDateValidation"].ToString()) ? 0 : Convert.ToInt32(ro["ExpDateValidation"].ToString());
                    ClsGlobal.FreeQty = string.IsNullOrEmpty(ro["FreeQty"].ToString()) ? 0 : Convert.ToInt32(ro["FreeQty"].ToString());
                    ClsGlobal.ExtraFreeQty = string.IsNullOrEmpty(ro["ExtraFreeQty"].ToString()) ? 0 : Convert.ToInt32(ro["ExtraFreeQty"].ToString());
                    ClsGlobal.IGodownWiseFilter = string.IsNullOrEmpty(ro["IGodownWiseFilter"].ToString()) ? 0 : Convert.ToInt32(ro["IGodownWiseFilter"].ToString());
                    ClsGlobal.SalaryLedgerId = string.IsNullOrEmpty(ro["SalaryLedgerId"].ToString()) ? 0 : Convert.ToInt32(ro["SalaryLedgerId"].ToString());
                    ClsGlobal.TDSLedgerId = string.IsNullOrEmpty(ro["TDSLedgerId"].ToString()) ? 0 : Convert.ToInt32(ro["TDSLedgerId"].ToString());
                    ClsGlobal.PFLedgerId = string.IsNullOrEmpty(ro["SecurityDepositLedgerId"].ToString()) ? 0 : Convert.ToInt32(ro["SecurityDepositLedgerId"].ToString());
                    ClsGlobal.BranchOrCompanyUnitWise = ro["BranchOrCompanyUnitWise"].ToString();
                    ClsGlobal.CompanyPrintName = ro["CompanyPrintName"].ToString();
                    ClsGlobal.Gadget = ro["Gadget"].ToString();
                    ClsGlobal.PBProductDiscountTermId = string.IsNullOrEmpty(ro["PBProductDiscountTermId"].ToString()) ? 0 : Convert.ToInt32(ro["PBProductDiscountTermId"].ToString());
                    ClsGlobal.PBBillDiscountTermId = string.IsNullOrEmpty(ro["PBBillDiscountTermId"].ToString()) ? 0 : Convert.ToInt32(ro["PBBillDiscountTermId"].ToString());
                    ClsGlobal.SBProductDiscountTermId = string.IsNullOrEmpty(ro["SBProductDiscountTermId"].ToString()) ? 0 : Convert.ToInt32(ro["SBProductDiscountTermId"].ToString());
                    ClsGlobal.SBBillDiscountTermId = string.IsNullOrEmpty(ro["SBBillDiscountTermId"].ToString()) ? 0 : Convert.ToInt32(ro["SBBillDiscountTermId"].ToString());
                    ClsGlobal.PBSubLedgerId = string.IsNullOrEmpty(ro["PBSubLedgerId"].ToString()) ? 0 : Convert.ToInt32(ro["PBSubLedgerId"].ToString());
                    ClsGlobal.PRSubLedgerId = string.IsNullOrEmpty(ro["PRSubLedgerId"].ToString()) ? 0 : Convert.ToInt32(ro["PRSubLedgerId"].ToString());
                    ClsGlobal.SBSubLedgerId = string.IsNullOrEmpty(ro["SBSubLedgerId"].ToString()) ? 0 : Convert.ToInt32(ro["SBSubLedgerId"].ToString());
                    ClsGlobal.SRSubLedgerId = string.IsNullOrEmpty(ro["SRSubLedgerId"].ToString()) ? 0 : Convert.ToInt32(ro["SRSubLedgerId"].ToString());
                    ClsGlobal.InterBranchPurchaseLedgerId = string.IsNullOrEmpty(ro["InterBranchPurchaseLedgerId"].ToString()) ? 0 : Convert.ToInt32(ro["InterBranchPurchaseLedgerId"].ToString());
                    ClsGlobal.InterBranchSalesLedgerId = string.IsNullOrEmpty(ro["InterBranchSalesLedgerId"].ToString()) ? 0 : Convert.ToInt32(ro["InterBranchSalesLedgerId"].ToString());
                }
            }

            if (objEntryControl.EntryControl.Count > 0)
            {
                for (int i = 0; i < objEntryControl.EntryControl.Count; i++)
                {
                    if (objEntryControl.EntryControl[i].EntryModule.ToString() == "F" && objEntryControl.EntryControl[i].ControlName.ToString() == "Salesman")
                    {
                        ClsGlobal.FinanceSalesmanControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.FinanceMSalesmanControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "F" && objEntryControl.EntryControl[i].ControlName.ToString() == "Currency")
                    {
                        ClsGlobal.FinanceCurrencyControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.FinanceMCurrencyControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "F" && objEntryControl.EntryControl[i].ControlName.ToString() == "Department")
                    {
                        ClsGlobal.FinanceDepartmentControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.FinanceMDepartmentControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "F" && objEntryControl.EntryControl[i].ControlName.ToString() == "DepartmentItem")
                    {
                        ClsGlobal.FinanceDepartmentItemControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.FinanceMDepartmentItemControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "F" && objEntryControl.EntryControl[i].ControlName.ToString() == "Narration")
                    {
                        ClsGlobal.FinanceNarrationControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.FinanceMNarrationControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "F" && objEntryControl.EntryControl[i].ControlName.ToString() == "Remarks")
                    {
                        ClsGlobal.FinanceRemarksControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.FinanceMRemarksControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "F" && objEntryControl.EntryControl[i].ControlName.ToString() == "Subledger")
                    {
                        ClsGlobal.FinanceSubledgerControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.FinanceMSubledgerControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "F" && objEntryControl.EntryControl[i].ControlName.ToString() == "ItemSubledger")
                    {
                        ClsGlobal.FinanceItemSubledgerControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.FinanceMItemSubledgerControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "F" && objEntryControl.EntryControl[i].ControlName.ToString() == "VoucherDate")
                    {
                        ClsGlobal.FinanceVoucherDateControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                    }

                    //// purchase

                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "AdditionalDesc")
                    {
                        ClsGlobal.PurchaseAdditionalDescControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "Salesman")
                    {
                        ClsGlobal.PurchaseSalesmanControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.PurchaseMSalesmanControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "BillType")
                    {
                        ClsGlobal.PurchaseBillTypeControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "Challan")
                    {
                        ClsGlobal.PurchaseChallanControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.PurchaseMChallanControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "Currency")
                    {
                        ClsGlobal.PurchaseCurrencyControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.PurchaseMCurrencyControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "Department")
                    {
                        ClsGlobal.PurchaseDepartmentControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.PurchaseMDepartmentControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "Godown")
                    {
                        ClsGlobal.PurchaseGodownControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.PurchaseMGodownControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "Indent")
                    {
                        ClsGlobal.PurchaseIndentControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.PurchaseMIndentControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "Order")
                    {
                        ClsGlobal.PurchaseOrderControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.PurchaseMOrderControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "ProductGroupWise")
                    {
                        ClsGlobal.PurchaseProductGroupWiseControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "ProductSubGroupWise")
                    {
                        ClsGlobal.PurchaseProductSubGroupWiseControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "ProductUnit")
                    {
                        ClsGlobal.PurchaseProductUnitControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "Quotation")
                    {
                        ClsGlobal.PurchaseQuotationControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.PurchaseMQuotationControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "ReferenceNo")
                    {
                        ClsGlobal.PurchaseReferenceNoControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.PurchaseMReferenceNoControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "Remarks")
                    {
                        ClsGlobal.PurchaseRemarksControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.PurchaseMRemarksControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "Subledger")
                    {
                        ClsGlobal.PurchaseSubledgerControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.PurchaseMSubledgerControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "UnitConversion")
                    {
                        ClsGlobal.PurchaseUnitConversionControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "VoucherDate")
                    {
                        ClsGlobal.PurchaseVoucherDateControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                    }

                    ///Sales
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "AdditionalDesc")
                    {
                        ClsGlobal.SalesAdditionalDescControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "Salesman")
                    {
                        ClsGlobal.SalesSalesmanControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.SalesMSalesmanControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "Challan")
                    {
                        ClsGlobal.SalesChallanControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.SalesMChallanControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "Currency")
                    {
                        ClsGlobal.SalesCurrencyControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.SalesMCurrencyControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "Department")
                    {
                        ClsGlobal.SalesDepartmentControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.SalesMDepartmentControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "DispatchOrder")
                    {
                        ClsGlobal.SalesDispatchOrderControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "Godown")
                    {
                        ClsGlobal.SalesGodownControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.SalesMGodownControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "Order")
                    {
                        ClsGlobal.SalesOrderControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.SalesMOrderControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "ProductGroupWise")
                    {
                        ClsGlobal.SalesProductGroupWiseControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "ProductSubGroupWise")
                    {
                        ClsGlobal.SalesProductSubGroupWiseControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "ProductUnit")
                    {
                        ClsGlobal.SalesProductUnitControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "Quotation")
                    {
                        ClsGlobal.SalesQuotationControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.SalesMQuotationControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "ReferenceNo")
                    {
                        ClsGlobal.SalesReferenceNoControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.SalesMReferenceNoControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "Remarks")
                    {
                        ClsGlobal.SalesRemarksControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.SalesMRemarksControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "Subledger")
                    {
                        ClsGlobal.SalesSubledgerControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.SalesMSubledgerControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "UnitConversion")
                    {
                        ClsGlobal.SalesUnitConversionControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "VoucherDate")
                    {
                        ClsGlobal.SalesVoucherDateControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "ChangeBasicAmount")
                    {
                        ClsGlobal.SalesChangeBasicAmountControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                    }

                    ///Inventory
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "AdditionalDesc")
                    {
                        ClsGlobal.InventoryAdditionalDescControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "Salesman")
                    {
                        ClsGlobal.InventorySalesmanControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.InventoryMSalesmanControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "CostCenter")
                    {
                        ClsGlobal.InventoryCostCenterControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.InventoryMCostCenterControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "CostCenterItem")
                    {
                        ClsGlobal.InventoryCostCenterItemControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.InventoryMCostCenterItemControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "Currency")
                    {
                        ClsGlobal.InventoryCurrencyControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.InventoryMCurrencyControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "Department")
                    {
                        ClsGlobal.InventoryDepartmentControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.InventoryMDepartmentControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "ExpDate")
                    {
                        ClsGlobal.InventoryExpDateControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "ExtraFreeQty")
                    {
                        ClsGlobal.InventoryExtraFreeQtyControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "FreeQty")
                    {
                        ClsGlobal.InventoryFreeQtyControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "Godown")
                    {
                        ClsGlobal.InventoryGodownControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.InventoryMGodownControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "GodownItem")
                    {
                        ClsGlobal.InventoryGodownItemControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.InventoryMGodownItemControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "MfgDate")
                    {
                        ClsGlobal.InventoryMfgDateControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "ProductGroupWise")
                    {
                        ClsGlobal.InventoryProductGroupWiseControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "ProductSubGroupWise")
                    {
                        ClsGlobal.InventoryProductSubGroupWiseControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "ProductUnit")
                    {
                        ClsGlobal.InventoryProductUnitControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "Remarks")
                    {
                        ClsGlobal.InventoryRemarksControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.InventoryMRemarksControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "Subledger")
                    {
                        ClsGlobal.InventorySubledgerControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                        ClsGlobal.InventoryMSubledgerControlVal = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "UnitConversion")
                    {
                        ClsGlobal.InventoryUnitConversionControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "VoucherDate")
                    {
                        ClsGlobal.InventoryVoucherDateControlVal = objEntryControl.EntryControl[i].ControlValue == "Y" ? 'Y' : 'N';
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "AltQtyConversion")
                    {
                        ClsGlobal.InventoryAltQtyConversion = objEntryControl.EntryControl[i].ControlValue == "Y" ? "Y" : "N";
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "AltQtyConversionRatioChange")
                    {
                        ClsGlobal.InventoryAltQtyConversionRatioChange = objEntryControl.EntryControl[i].ControlValue == "Y" ? "Y" : "N";
                    }

                }
            }
        }
        public static void UserRestriction(string UserCode, string IniTial)
        {
            Interface.SystemSetting.IUserRestriction _objUserRestriction = new ClsUserRestriction();
            DataTable dataTable = _objUserRestriction.GetUserRestriction(UserCode, IniTial);
            if (dataTable.Rows.Count > 0)
            {
                AccessSalesRateChange = Convert.ToInt32(dataTable.Rows[0]["AccessSalesRateChange"].ToString());  // 0 for NO  1 YES
                AccessSalesTermChange = Convert.ToInt32(dataTable.Rows[0]["AccessSalesTermChange"].ToString());
                AccessPurchaseRateChange = Convert.ToInt32(dataTable.Rows[0]["AccessPurchaseRateChange"].ToString());
                AccessPurchaseTermChange = Convert.ToInt32(dataTable.Rows[0]["AccessPurchaseTermChange"].ToString());
            }
            else
            {
                AccessSalesRateChange = 0;
                AccessSalesTermChange = 0;
                AccessPurchaseRateChange = 0;
                AccessPurchaseTermChange = 0;
            }
        }
        public static void MyKeyDown(char key, int KeyValue, string KeyData, string _Tag, string _SearchKey, TextBox txtBox, Button btn, bool isPrimary)
        {
            //System.Diagnostics.Debug.WriteLine(KeyData);
            if ((key >= 113 && key <= 123) || (key >= 32 && key <= 40) || key == 13 || key == 16 || key == 17 || key == 18 || key == 20 || key == 27 || key == 45 || key == 46 || key == 144)
            {
                _SearchKey = string.Empty;
                return;
            }
            else if (KeyValue == 8)
            {
                if (isPrimary == false)
                {
                    txtBox.Text = ""; txtBox.Tag = "";
                }
            }
            else if (KeyData == "Keys.O | Keys.Alt" || KeyData == "O, Alt" || KeyData == "Keys.Alt | Keys.Tab" || KeyData == "X, Control" || KeyData == "V, Control")
            {
                return;
            }
            else if (KeyData == "A, Control")
            {
                txtBox.SelectAll();
                return;
            }
            else
            {
                if (((key >= 65 && key <= 90) || (key >= 48 && key <= 57) || (key >= 96 && key <= 105) || key == 112) && (_Tag == "EDIT" || _Tag == "DELETE"))
                {
                    _SearchKey = key.ToString(); int val = -1;
                    if (KeyValue >= ((int)Keys.NumPad0) && KeyValue <= ((int)Keys.NumPad9)) { val = KeyValue - ((int)Keys.NumPad0); _SearchKey = val.ToString(); }
                    else if (KeyValue >= ((int)Keys.D0) && KeyValue <= ((int)Keys.D9)) { val = KeyValue - ((int)Keys.D0); _SearchKey = val.ToString(); }
                    if (txtBox.Tag == null)
                    {
                        txtBox.Tag = "0";
                    }

                    if ((_Tag == "EDIT" && txtBox.Text.Trim() == "" && txtBox.Tag.ToString() == "0") || KeyData == "F1")
                    {
                        btn.PerformClick();
                    }
                    else if (_Tag == "DELETE")
                    {
                        btn.PerformClick();
                    }
                }
            }
        }
        public static DialogResult ConfirmFormClearing()
        {
            DialogResult dialogResult1 = MessageBox.Show("Are you sure want to clear form...?", "Mr Solution", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return dialogResult1;
        }
        public static void ConfirmFormCloseing(Form frm)
        {
            if (ClsGlobal.ConfirmFormClose == 1)
            {
                DialogResult dialog = MessageBox.Show("Are you sure want to close form...?", "Mr Solution", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    frm.Close();
                }
            }
            else
            {
                frm.Close();
            }
        }
        public static DialogResult InvalidDateMsg()
        {
            return MessageBox.Show("Invalid Date Formate, Enter dd/mm/yyyy Date Format.", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult MandatoryMsg(string msg)
        {
            return MessageBox.Show("" + msg + " is required.", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult AlreadyExistMsg(string msg)
        {
            return MessageBox.Show("" + msg + " already exist !", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult NotExistMsg(string msg)
        {
            return MessageBox.Show("" + msg + " doesnot exist !", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static string DecimalFormate(decimal val1, int Formate, int RoundFigure)
        {
            decimal val = Math.Round(val1, RoundFigure);
            string value = "";
            if (Formate == 1)
            {
                decimal parsed = decimal.Parse(val.ToString(), CultureInfo.InvariantCulture);
                CultureInfo hindi = new CultureInfo("hi-IN");
                if (RoundFigure == 1)
                {
                    value = string.Format(hindi, "{0:#,0.#}", parsed).Replace("रु ", string.Empty);
                }
                else if (RoundFigure == 2)
                {
                    value = string.Format(hindi, "{0:#,0.##}", parsed).Replace("रु ", string.Empty);
                }
                else if (RoundFigure == 3)
                {
                    value = string.Format(hindi, "{0:#,0.###}", parsed).Replace("रु ", string.Empty);
                }
                else if (RoundFigure == 4)
                {
                    value = string.Format(hindi, "{0:#,0.####}", parsed).Replace("रु ", string.Empty);
                }
                else if (RoundFigure == 5)
                {
                    value = string.Format(hindi, "{0:#,0.#####}", parsed).Replace("रु ", string.Empty);
                }
                else if (RoundFigure == 6)
                {
                    value = string.Format(hindi, "{0:#,0.######}", parsed).Replace("रु ", string.Empty);
                }
				else if (RoundFigure == 7)
				{
					value = string.Format(hindi, "{0:#,0.#######}", parsed).Replace("रु ", string.Empty);
				}
			}
            else if (Formate == 2)
            {
                if (RoundFigure == 1)
                {
                    value = string.Format("{0:0,0.#}", val);
                }
                else if (RoundFigure == 2)
                {
                    value = string.Format("{0:0,0.##}", val);
                }
                else if (RoundFigure == 3)
                {
                    value = string.Format("{0:0,0.###}", val);
                }
                else if (RoundFigure == 4)
                {
                    value = string.Format("{0:0,0.####}", val);
                }
                else if (RoundFigure == 5)
                {
                    value = string.Format("{0:0,0.#####}", val);
                }
                else if (RoundFigure == 6)
                {
                    value = string.Format("{0:0,0.######}", val);
                }
				else if (RoundFigure == 7)
				{
					value = string.Format("{0:0,0.#######}", val);
				}
				else
                {
                    value = val.ToString();
                }
            }

			decimal.TryParse(value, out decimal _val);
           // decimal _val = Convert.ToDecimal(value);
            string _val1 = "";
            if (RoundFigure == 1)
            {
                _val1 = _val.ToString("0.0");
            }
            else if (RoundFigure == 2)
            {
                _val1 = _val.ToString("0.00");
            }
            else if (RoundFigure == 3)
            {
                _val1 = _val.ToString("0.000");
            }
            else if (RoundFigure == 4)
            {
                _val1 = _val.ToString("0.0000");
            }
            else if (RoundFigure == 5)
            {
                _val1 = _val.ToString("0.00000");
            }
            else if (RoundFigure == 6)
            {
                _val1 = _val.ToString("0.000000");
            }
			else if (RoundFigure == 7)
			{
				_val1 = _val.ToString("0.0000000");
			}
			return _val1;
        }
		public static decimal ReturnDecimalVal(string Value)
		{
			return Value == "" ? 0 : Convert.ToDecimal(Value);
		}

		public static string Val(string Value)
		{
			if (Value == "")
				Value = "0";
			return Value;
		}
        public static bool ValidateEmailId(string verify)
        {
            return Regex.IsMatch(verify, "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$");
        }
        public static bool ValidateUrl(string Validate)
        {
            Regex urlCheck = new Regex(@"^[a-zA-Z0-9\-\.]+\.(com|org|net|mil|edu|COM|ORG|NET|MIL|EDU|com.np|com.in)$");
            if (urlCheck.IsMatch(Validate))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
        public static PictureBox Previewpic;
        public static string Title;
        public static PictureBox FetchPic(PictureBox pic, string title)
        {
            pic.Image = Previewpic.Image;
            return pic;
        }
        public static void PreviewPicture(PictureBox pic, string title)
        {
            Previewpic = null;
            Previewpic = pic;
            Title = title;
            //Common.FrmPreview FP = new Common.FrmPreview();
            //FP.ShowDialog();
        }
        /// <summary>
        /// convert picture in binary code
        /// </summary>
        /// <param name="pic"></param>
        /// <param name="imageColumn"></param>
        /// <param name="photo"></param>
        ///

        public static byte[] GetPic(Image img, PictureBox picture)
        {
            byte[] data = null;
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    Bitmap bmp = new Bitmap(picture.Image);
                    bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    stream.Position = 0;
                    data = new byte[stream.Length];
                    stream.Read(data, 0, data.Length);
                    return data;
                }
            }
            catch (Exception)
            {
                return data;
            }
        }
        public static byte[] ReadFile(string sPath)
        {
            byte[] data = null;
            try
            {
                FileInfo fInfo = new FileInfo(sPath);
                long numBytes = fInfo.Length;
                FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                data = br.ReadBytes((int)numBytes);
                return data;
            }
            catch (Exception)
            {
                return data;
            }
        }
        public static void BindPrinter(ComboBox cb_PrinterName)
        {
            cb_PrinterName.Items.Clear();
            cb_PrinterName.Items.Clear();
            if (PrinterSettings.InstalledPrinters.Count <= 0)
            {
                MessageBox.Show("Printer not found!");
                return;
            }
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                cb_PrinterName.Items.Add(printer.ToString());
            }
            cb_PrinterName.SelectedIndex = 0;
        }
        public static void BindDrivePath(ComboBox cb_DrivePath)
        {
            cb_DrivePath.Items.Clear();
            cb_DrivePath.Items.Clear();
            DriveInfo[] drives = DriveInfo.GetDrives();
            if (drives.Length <= 0)
            {
                MessageBox.Show("Drive not found!");
                return;
            }
            for (int i = 0; i <= drives.Length - 1; i++)
            {
                cb_DrivePath.Items.Add(drives[i].Name);
            }
            cb_DrivePath.SelectedIndex = 0;
        }
        public static DataTable ModuleCode()
        {
            DataTable DtModule = new DataTable();
            DtModule.Columns.Add("ModuleName");
            DtModule.Columns.Add("ModuleCode");
            DtModule.Rows.Add("Cash Indent", "CI");
            DtModule.Rows.Add("Provisional Journal Voucher", "PIV");
            DtModule.Rows.Add("Provisional Cash Bank", "PCB");
            DtModule.Rows.Add("Provisional Debit Note", "PDN");
            DtModule.Rows.Add("Provisional Credit Note", "PCN");
            DtModule.Rows.Add("PDC", "PDC");
            DtModule.Rows.Add("Cash Bank ", "CB");
            DtModule.Rows.Add("Journal Voucher", "JV");
            DtModule.Rows.Add("Debit Note", "DN");
            DtModule.Rows.Add("Credit Note", "CN");
            DtModule.Rows.Add("Purchase Indent", "PI");
            DtModule.Rows.Add("Purchase Quotation", "PQ");
            DtModule.Rows.Add("Purchase Order", "PO");
            DtModule.Rows.Add("Purchase Challan", "PC");
            DtModule.Rows.Add("Goods In Transit", "GIT");
            DtModule.Rows.Add("Purchase Invoice", "PB");
            DtModule.Rows.Add("Purchase Return", "PR");
            DtModule.Rows.Add("Purchase Indent Cancel", "PIC");
            DtModule.Rows.Add("Purchase Quotation Cancel", "PQC");
            DtModule.Rows.Add("Purchase Order Cancel", "POC");
            DtModule.Rows.Add("Purchase Challan Return", "PCR");
            DtModule.Rows.Add("Purchase Invoice Cancel", "PBC");
            DtModule.Rows.Add("Purchase Additional Invoice", "PAB");
            DtModule.Rows.Add("Purchase Return Cancel", "PRC");
            DtModule.Rows.Add("Sales Quotation", "SQ");
            DtModule.Rows.Add("Sales Order", "SO");
            DtModule.Rows.Add("Sales Dispatch Order", "SDO");
            DtModule.Rows.Add("Sales Challan", "SC");
            DtModule.Rows.Add("Sales Invoice", "SB");
            DtModule.Rows.Add("Sales Return", "SB");
            DtModule.Rows.Add("Sales Additional Invoice", "SAB");
            DtModule.Rows.Add("Sales Quotation cancel", "SQC");
            DtModule.Rows.Add("Sales Order Cancel", "SOC");
            DtModule.Rows.Add("Sales Dispatch Order Cancel", "SDOC");
            DtModule.Rows.Add("Sales Challan Return", "SCR");
            DtModule.Rows.Add("Sales Invoice Cancel", "SBC");
            DtModule.Rows.Add("Sales Return Cancel", "SBC");
            DtModule.Rows.Add("Godown Transfer ", "GT");
            DtModule.Rows.Add("Stock Adjustment", "SA");
            DtModule.Rows.Add("Physical Stock", "PSA");
            DtModule.Rows.Add("Stock Expiry Breakage", "STEB");
            DtModule.Rows.Add("Assembly Master", "ASSM");
            DtModule.Rows.Add("Memo", "BOM");
            DtModule.Rows.Add("Inventory Requisition", "SREQ");
            DtModule.Rows.Add("Inventory Issue", "II");
            DtModule.Rows.Add("Inventory Issue Return", "IIR");
            DtModule.Rows.Add("Inventory Receive", "IR");
            DtModule.Rows.Add("Inventory Receive Return", "IRR");
            DtModule.Rows.Add("Production Master Memo", "MBOM");
            DtModule.Rows.Add("Production BOM", "PBOM");
            DtModule.Rows.Add("Production Requisition", "PREQ");
            DtModule.Rows.Add("Production Order", "IPO");
            DtModule.Rows.Add("Rawmaterial Issue", "RMIR");
            DtModule.Rows.Add("Rawmaterial Issue Return", "RMIR");
            DtModule.Rows.Add("Finished Goods Receive", "FGR");
            DtModule.Rows.Add("Finished Goods Receive Return", "FGRR");
            return DtModule;
        }
        public static DataTable GridToDataTable(DataGridView gv)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in gv.Columns)
            {
                DataColumn dc = new DataColumn(col.Name.ToString());
                dt.Columns.Add(dc);
            }

            object[] cellValue = new object[gv.Columns.Count];
            foreach (DataGridViewRow row in gv.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValue[i] = row.Cells[i].Value;
                }
                dt.Rows.Add(cellValue);
            }
            return dt;
        }
        public static void DisableGridColumnsSorting(DataGridView Grid)
        {
            foreach (DataGridViewColumn Col in Grid.Columns)
            {
                Col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        public static void LoadDateByOption(string DateOption, MaskedTextBox _txtFromDate, MaskedTextBox _TxtToDate)
        {
            ClsDateMiti _objDate = new ClsDateMiti();
            DateTime fromDate = new DateTime();
            DateTime toDate = new DateTime();
            if (DateOption == "Today")
            {
                fromDate = DateTime.Now;
                toDate = DateTime.Now;
            }
            else if (DateOption == "Yesterday")
            {
                fromDate = DateTime.Now.AddDays(-1);
                toDate = DateTime.Now;
            }
            else if (DateOption == "Current Week")
            {
                fromDate = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek);
                toDate = DateTime.Now.AddDays(6 - (int)DateTime.Now.DayOfWeek);
            }
            else if (DateOption == "Last Week")
            {
                fromDate = DateTime.Now.AddDays(-1 - (int)DateTime.Now.DayOfWeek);
                toDate = DateTime.Now.AddDays(-7 - (int)DateTime.Now.DayOfWeek);
            }
            //else if (DateOption == "Current Month")
            //{
            //    fromDate = Convert.ToDateTime(clsGlobal.FetchSingleData("SELECT CONVERT(nvarchar(11),DATEADD(Month, DATEDIFF(Month, 0, GETDATE()), 0),105) "));
            //    toDate = DateTime.Now;
            //}
            //else if (DateOption == "Last Month")
            //{
            //    fromDate = Convert.ToDateTime(clsGlobal.FetchSingleData("select CONVERT(nvarchar(11), DATEADD(month,-1, DATEADD(Month, DATEDIFF(Month, 0, GETDATE()), 0)),105)"));
            //    toDate = Convert.ToDateTime(clsGlobal.FetchSingleData("select CONVERT(nvarchar(11),DATEADD(Month, DATEDIFF(Month, 0, GETDATE()), -1),105) "));
            //}
            else if (DateOption == "Upto Date")
            {
                fromDate = Convert.ToDateTime(CompanyStartDate);
                toDate = DateTime.Now;
            }
            else if (DateOption == "Accounting Period")
            {
                fromDate = Convert.ToDateTime(CompanyStartDate);
                toDate = Convert.ToDateTime(CompanyEndDate);
            }

            if (DateOption == "Custom Date")
            {
                _txtFromDate.Text = string.Empty;
                _TxtToDate.Text = string.Empty;
                _txtFromDate.Enabled = true;
                _TxtToDate.Enabled = true;
            }
            else
            {
                if (DateType == "D")
                {
                    _txtFromDate.Text = fromDate.ToString("dd/MM/yyyy");
                    _TxtToDate.Text = toDate.ToString("dd/MM/yyyy");
                }
                else
                {
                    _txtFromDate.Text = _objDate.GetMiti(Convert.ToDateTime(fromDate.ToString("dd/MM/yyyy")));
                    _txtFromDate.Tag = fromDate.ToString("dd/MM/yyyy");
                    _TxtToDate.Text = _objDate.GetMiti(Convert.ToDateTime(toDate.ToString("dd/MM/yyyy")));
                    _TxtToDate.Tag = toDate.ToString("dd/MM/yyyy");
                }
                _txtFromDate.Enabled = false;
                _TxtToDate.Enabled = false;
            }
        }
        public static string GetOrderNoFrmGrid(DataGridView dgv)
        {
            DataTable _dt = new DataTable();
            _dt.Columns.Add("OrderNo");
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["OrderNo"].Value != null)
                {
                    if (!string.IsNullOrEmpty(row.Cells["OrderNo"].Value.ToString()))
                    {
                        _dt.Rows.Add(row.Cells["OrderNo"].Value.ToString());
                    }
                }
            }
            DataView v = new DataView(_dt);
            DataTable distinctDt = v.ToTable(true, "OrderNo");
            string _odrno = "";
            foreach (DataRow dritem in distinctDt.Rows)
            {
                _odrno = _odrno + "," + dritem["OrderNo"].ToString();
            }
            return _odrno;
        }
        public static int CheckDateInsideCompanyPeriod(DateTime _date)
        {
            if (_date < Convert.ToDateTime(CompanyStartDate) || _date > Convert.ToDateTime(CompanyEndDate))
                return 1;
            else
                return 0;
        }
        public static DialogResult DateMitiRangeMsg()
        {
            string startDate, endDate;
            ClsDateMiti _objDate = new ClsDateMiti();
            if (DateType == "M")
            {
                startDate = _objDate.GetMiti(Convert.ToDateTime(CompanyStartDate));
                endDate = _objDate.GetMiti(Convert.ToDateTime(CompanyEndDate));
            }
            else
            {
                startDate = CompanyStartDate;
                endDate = CompanyEndDate;
            }
            return MessageBox.Show("Transaction date must be between company fiscal year " + startDate + " and " + endDate + "", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult DateRangeMsg()
        {
            return MessageBox.Show("Transaction date must be between company fiscal year  " + CompanyStartDate + " and " + CompanyEndDate + "", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult MitiRangeMsg()
        {
            ClsDateMiti _objDate = new ClsDateMiti();
            return MessageBox.Show("Transaction miti must be between company fiscal year  " + _objDate.GetMiti(Convert.ToDateTime(CompanyStartDate)) + " and " + _objDate.GetMiti(Convert.ToDateTime(CompanyEndDate)) + "", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static ComboBox BindCurrency(ComboBox CmbCurrency)
        {
            ICurrency _ObjCurrency = new ClsCurrency();
            CmbCurrency.DataSource = _ObjCurrency.GetDataCurrency(0);
            CmbCurrency.DisplayMember = "CurrencyDesc";
            CmbCurrency.ValueMember = "CurrencyId";
            return CmbCurrency;
        }
        public static void LoadGroupCategory(ComboBox CmbType)
        {
            DataTable rs = new DataTable();
            rs.Columns.Add("Id");
            rs.Columns.Add("Description");

            rs.Rows.Add("BS", "Balance Sheet");
            rs.Rows.Add("PL", "Profit & Loss");
            rs.Rows.Add("TD", "Trading");

            CmbType.DataSource = rs;
            CmbType.DisplayMember = "Description";
            CmbType.ValueMember = "Id";

        }
        public static void LoadGroupCategoryType(ComboBox CmbType, ComboBox CmbPrimaryGroup)
        {

            if (CmbType.SelectedIndex == -1)
            {
                return;
            }

            DataTable rs = new DataTable();
            rs.Columns.Add("Id");
            rs.Columns.Add("Description");

            if (CmbType.SelectedIndex == 0)
            {
                rs.Rows.Add("Assets", "Assets");
                rs.Rows.Add("Liability", "Liability");
            }
            else if (CmbType.SelectedIndex == 1)
            {
                rs.Rows.Add("Expenditure", "Expenditure");
                rs.Rows.Add("Income", "Income");
            }
            else if (CmbType.SelectedIndex == 2)
            {
                rs.Rows.Add("Expenditure", "Expenditure");
                rs.Rows.Add("Income", "Income");
            }
            CmbPrimaryGroup.DataSource = rs;
            CmbPrimaryGroup.ValueMember = "Id";
            CmbPrimaryGroup.DisplayMember = "Description";
        }
        public static DialogResult SaveMessage(string Tag)
        {
            if (Tag == "NEW") Tag = "saved";
            else if (Tag == "EDIT") Tag = "updated";
            else if (Tag == "DELETE") Tag = "deleted";
            return MessageBox.Show(@"Data " + Tag + " successfully.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ErrorMessage(string ex)
        {
            if (ex != "")
            {
                MessageBox.Show(ex.ToString(), "MrSolution", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {
                MessageBox.Show("Error Occurs while Saving Data Contact With your Vendor..!!", "MrSolution", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        public static void DateValidation(MaskedTextBox TxtDate, MaskedTextBox TxtMiti)
        {
            if (TxtDate.Text != "  /  /")
            {
                try
                {
                    if (ClsGlobal.CheckDateInsideCompanyPeriod(Convert.ToDateTime(TxtDate.Text)) == 1)
                    {
                        ClsGlobal.DateRangeMsg();
                        TxtDate.Focus();
                    }
                    else 
                    {
                        ClsDateMiti _objDate = new ClsDateMiti();
                        TxtMiti.Text = _objDate.GetMiti(Convert.ToDateTime(TxtDate.Text));
                    }
                }
                catch
                {
                    MessageBox.Show("Please enter valid date.", "Mr. Solutions", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtDate.Focus();
                }
            }
            else
            {
                ClsGlobal.DateRangeMsg();
                TxtDate.Focus();
            }
        }

        public static void MitiValidation(MaskedTextBox TxtMiti, MaskedTextBox TxtDate)
        {
            ClsDateMiti _objDate = new ClsDateMiti();
            if (TxtMiti.Text != "  /  /")
            {
                try
                {
                    DateTime dt = Convert.ToDateTime(_objDate.GetDate(TxtMiti.Text).Value.ToString());
                    if (ClsGlobal.CheckDateInsideCompanyPeriod(dt) == 1)
                    {
                        ClsGlobal.MitiRangeMsg();
                        TxtMiti.Focus();
                    }
                    else
                    {
                        TxtDate.Text = dt.ToShortDateString();
                    }
                }
                catch
                {
                    MessageBox.Show("Please enter valid miti.", "Mr. Solutions", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtMiti.Focus();
                }
            }
            else
            {
                ClsGlobal.MitiRangeMsg();
                TxtMiti.Focus();
            }
        }
    }
}
