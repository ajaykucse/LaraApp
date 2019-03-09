﻿using acmedesktop.Common;
using acmedesktop.MasterSetup;
using DataAccessLayer.Common;
using DataAccessLayer.Interface.SystemSetting;
using DataAccessLayer.SystemSetting;
using System;
using System.Data;
using System.Windows.Forms;

namespace acmedesktop.SystemSetting
{
    public partial class FrmSystemSetting : Form
    {
        IEntryControl objEntryControl = new ClsEntryControl();
        private string _Tag = "", _SearchKey = "";
        public FrmSystemSetting()
        {
            InitializeComponent();
        }
        private void FrmSystemSetting_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
                return;
            }
        }
        private void BtnGOk_Click(object sender, EventArgs e)
        {
            if (RBEnglishBase.Checked == true)
            {
                objEntryControl.SystemControlModel.DateType = "D";
                ClsGlobal.DateType = "D";
            }
            else
            {
                objEntryControl.SystemControlModel.DateType = "M";
                ClsGlobal.DateType = "M";
            }

            if (ChkBranchWise.Checked == true)
            {
                objEntryControl.SystemControlModel.BranchOrCompanyUnitWise = "Branch";
                ClsGlobal.BranchOrCompanyUnitWise = "Branch";
            }
            else if(ChkCompanyUnitWise.Checked == true)
            {
                objEntryControl.SystemControlModel.BranchOrCompanyUnitWise = "CompanyUnit";
                ClsGlobal.BranchOrCompanyUnitWise = "CompanyUnit";
            }
			else
			{
				objEntryControl.SystemControlModel.BranchOrCompanyUnitWise = "";
				ClsGlobal.BranchOrCompanyUnitWise = "";
			}

            if (RBUDFYes.Checked == true)
            {
                objEntryControl.SystemControlModel.UDFSystem = 1;
                ClsGlobal.UDFSystem = 1;
            }
            else
            {
                objEntryControl.SystemControlModel.UDFSystem = 0;
                ClsGlobal.UDFSystem = 0;
            }

            if (ChkConfirmSave.Checked == true)
            {
                objEntryControl.SystemControlModel.ConfirmSave = 1;
            }
            else
            {
                objEntryControl.SystemControlModel.ConfirmSave = 0;
            }

            if (ChkConfirmFormCancel.Checked == true)
            {
                objEntryControl.SystemControlModel.ConfirmFormCancel = 1;
            }
            else
            {
                objEntryControl.SystemControlModel.ConfirmFormCancel = 0;
            }
            if (ChkConfirmFormClear.Checked == true)
            {
                objEntryControl.SystemControlModel.ConfirmFormClear = 1;
            }
            else
            {
                objEntryControl.SystemControlModel.ConfirmFormClear = 0;
            }

            objEntryControl.SystemControlModel.DefaultCurrencyId = ((TxtDefaultCurrency.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtDefaultCurrency.Tag.ToString()));
            objEntryControl.SystemControlModel.SBLedgerId = ((TxtSSalesAc.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtSSalesAc.Tag.ToString()));
            objEntryControl.SystemControlModel.SRLedgerId = ((TxtSSalesReturnAc.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtSSalesReturnAc.Tag.ToString()));
            objEntryControl.SystemControlModel.SBSubLedgerId = ((TxtSSalesSubledgerAc.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtSSalesSubledgerAc.Tag.ToString()));
            objEntryControl.SystemControlModel.SRSubLedgerId = ((TxtSSalesReturnSubledgerAc.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtSSalesReturnSubledgerAc.Tag.ToString()));

            objEntryControl.SystemControlModel.SBVatTermId = ((TxtSVATTerm.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtSVATTerm.Tag.ToString()));
            ClsGlobal.SBVatTermId = ((TxtSVATTerm.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtSVATTerm.Tag.ToString()));
            objEntryControl.SystemControlModel.SBBillDiscountTermId = ((TxtSBillDiscTerm.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtSBillDiscTerm.Tag.ToString()));
            ClsGlobal.SBBillDiscountTermId = ((TxtSBillDiscTerm.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtSBillDiscTerm.Tag.ToString()));
            objEntryControl.SystemControlModel.SBProductDiscountTermId = ((TxtSProductDiscTerm.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtSProductDiscTerm.Tag.ToString()));
            objEntryControl.SystemControlModel.SBSpecialDiscountTermId = ((TxtSProductSplDiscTerm.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtSProductSplDiscTerm.Tag.ToString()));
            objEntryControl.SystemControlModel.SBServiceChargeTermId = ((TxtSServiceChargeTerm.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtSServiceChargeTerm.Tag.ToString()));
            objEntryControl.SystemControlModel.InterBranchSales = ((TxtSInterBranchAc.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtSInterBranchAc.Tag.ToString()));

            objEntryControl.SystemControlModel.DefaultPrinter = "";
            objEntryControl.SystemControlModel.BackupSchIntvDays = 0;
            objEntryControl.SystemControlModel.BackupPath = "";
            objEntryControl.SystemControlModel.PLLedgerId = ((TxtFProfitAndLoss.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtFProfitAndLoss.Tag.ToString()));
			objEntryControl.SystemControlModel.CashLedgerId = ((TxtFCashAc.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtFCashAc.Tag.ToString()));
            ClsGlobal.CashLedgerId = ((TxtFCashAc.Tag.ToString() == "") ?0 :Convert.ToInt32( TxtFCashAc.Tag.ToString()));
            objEntryControl.SystemControlModel.CardLedgerId = ((TxtFCardAc.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtFCardAc.Tag.ToString()));
            ClsGlobal.CardLedgerId = ((TxtFCardAc.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtFCardAc.Tag.ToString()));
            objEntryControl.SystemControlModel.VatLedgerId = ((TxtFVATAc.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtFVATAc.Tag.ToString()));
            ClsGlobal.VatLedgerId = ((TxtFVATAc.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtFVATAc.Tag.ToString()));
            objEntryControl.SystemControlModel.PDCBankLedgerId = ((TxtFPDCBank.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtFPDCBank.Tag.ToString()));
			objEntryControl.SystemControlModel.FinNegBalance = false;

            objEntryControl.SystemControlModel.AmountFormate = CmbAmountFormat.Text;
            objEntryControl.SystemControlModel.RateFormat = CmbRateFormat.Text;
            objEntryControl.SystemControlModel.QtyFormat = CmbQuantityFormat.Text;
            objEntryControl.SystemControlModel.AltQtyFormat = CmbAltQuantityFormat.Text;
            objEntryControl.SystemControlModel.CurrencyFormat = CmbCurrencyFormat.Text;

            objEntryControl.SystemControlModel.FontName = "";
            objEntryControl.SystemControlModel.FontSize = 0;
            objEntryControl.SystemControlModel.PaperSize = "";
            objEntryControl.SystemControlModel.ReportFontStyle = "";
            objEntryControl.SystemControlModel.PrintingDateTime = 0;
            objEntryControl.SystemControlModel.PBLedgerId = ((TxtPPuchaseAc.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtPPuchaseAc.Tag.ToString()));
			objEntryControl.SystemControlModel.PRLedgerId = ((TxtPPuchaseReturnAc.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtPPuchaseReturnAc.Tag.ToString()));
			objEntryControl.SystemControlModel.PBVatTermId = ((TxtPVatTerm.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtPVatTerm.Tag.ToString()));
			objEntryControl.SystemControlModel.PABVatTermId = 0;// ((TxtPosDocumentNumber.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtPosDocumentNumber.Tag.ToString()));
			objEntryControl.SystemControlModel.PBCreditBalanceWarning = "";
            objEntryControl.SystemControlModel.PBCreditDaysWarning = "";
            objEntryControl.SystemControlModel.PBCarryRate = 0;
            objEntryControl.SystemControlModel.PBLastRate = 0;
            objEntryControl.SystemControlModel.PBBatchRate = 0;
            objEntryControl.SystemControlModel.PBGrpWiseBilling = 0;
            objEntryControl.SystemControlModel.PBAdvancePayment = 0;
            objEntryControl.SystemControlModel.SBCreditBalanceWarning = "";
            objEntryControl.SystemControlModel.SBCreditDaysWarning = "";
            objEntryControl.SystemControlModel.SBChangeRate = 0;
            objEntryControl.SystemControlModel.SBLastRate = 0;
            objEntryControl.SystemControlModel.SBCarryRate = 0;
            objEntryControl.SystemControlModel.DefaultInvoicePrintDesignId = 0;
            objEntryControl.SystemControlModel.DefaultPOSDocNumberingId = ((TxtPosDocumentNumber.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtPosDocumentNumber.Tag.ToString()));
			objEntryControl.SystemControlModel.DefaultOrderPrintDesignId = 0;
            objEntryControl.SystemControlModel.DefaultOrderDocNumberingId = ((TxtOrderDocumentNumber.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtOrderDocumentNumber.Tag.ToString()));
			objEntryControl.SystemControlModel.StockValueInSalesReturn = 0;
            objEntryControl.SystemControlModel.AvailableStock = 0;
            objEntryControl.SystemControlModel.SBGrpWiseBilling = 0;
            //objEntryControl.SystemControlModel.TenderAmount = false;
          
            objEntryControl.SystemControlModel.OpeningStockLedgerId = ((TxtIOpeingStockPLAc.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtIOpeingStockPLAc.Tag.ToString()));
			objEntryControl.SystemControlModel.ClosingStockLedgerId = ((TxtIClosingStockPLAc.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtIClosingStockPLAc.Tag.ToString()));
			objEntryControl.SystemControlModel.ClosingStockLedgerBSId = ((TxtIClosingStockBLAc.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtIClosingStockBLAc.Tag.ToString()));
			objEntryControl.SystemControlModel.ClosingStockSubLedgerId = ((TxtIClosingStockPLSubAc.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtIClosingStockPLSubAc.Tag.ToString()));
			objEntryControl.SystemControlModel.OpeningStockSubLedgerId = ((TxtIOpeingStockPLSubAc.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtIOpeingStockPLSubAc.Tag.ToString()));
			objEntryControl.SystemControlModel.ClosingStockSubLedgerBSId = ((TxtIClosingStockBLSubAc.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtIClosingStockBLSubAc.Tag.ToString()));


			objEntryControl.SystemControlModel.StockInHandLedgerId = 0;
			if (CmbNegativeWarning.Text == "Ignore")
				objEntryControl.SystemControlModel.NegativeStockWarning = "I";
			else if(CmbNegativeWarning.Text == "Warning")
				objEntryControl.SystemControlModel.NegativeStockWarning = "W";
			else if (CmbNegativeWarning.Text == "Block")
				objEntryControl.SystemControlModel.NegativeStockWarning = "B";
			else
				objEntryControl.SystemControlModel.NegativeStockWarning = "0";

			objEntryControl.SystemControlModel.AltQtyAlteration = 0;
            objEntryControl.SystemControlModel.AlterationPart = 0;
            objEntryControl.SystemControlModel.CarryBatchQty = 0;
            objEntryControl.SystemControlModel.BreakupQty = 0;
            objEntryControl.SystemControlModel.MfgDate = 0;
            objEntryControl.SystemControlModel.ExpDate = 0;
            objEntryControl.SystemControlModel.MfgDateValidation = 0;
            objEntryControl.SystemControlModel.ExpDateValidation = 0;
            objEntryControl.SystemControlModel.FreeQty = 0;
            objEntryControl.SystemControlModel.ExtraFreeQty = 0;
            objEntryControl.SystemControlModel.IGodownWiseFilter = 0;
            objEntryControl.SystemControlModel.SalaryLedgerId = 0;
            objEntryControl.SystemControlModel.TDSLedgerId = ((TxtFTDSAc.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtFTDSAc.Tag.ToString()));
			objEntryControl.SystemControlModel.SecurityDepositLedgerId = ((TxtFSecurityDepositAc.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtFSecurityDepositAc.Tag.ToString()));
			objEntryControl.SystemControlModel.CompanyPrintName = "";          
            objEntryControl.SystemControlModel.PBProductDiscountTermId = ((TxtPPDiscountTerm.Text.ToString() == "") ? 0 : Convert.ToInt32(TxtPPDiscountTerm.Tag.ToString()));
			objEntryControl.SystemControlModel.PBBillDiscountTermId = ((TxtPBDiscountTerm.Text.ToString() == "") ? 0 : Convert.ToInt32(TxtPBDiscountTerm.Tag.ToString()));
			objEntryControl.SystemControlModel.PBSubLedgerId = ((TxtPPuchaseSubledgerAc.Text.ToString() == "") ? 0 : Convert.ToInt32(TxtPPuchaseSubledgerAc.Tag.ToString()));
			objEntryControl.SystemControlModel.PRSubLedgerId = ((TxtPPuchaseReturnSubLedgerAc.Text.ToString() == "") ? 0 : Convert.ToInt32(TxtPPuchaseReturnSubLedgerAc.Tag.ToString()));
			objEntryControl.SystemControlModel.InterBranchPurchase = ((TxtPInterBranchAc.Text.ToString() == "") ? 0 : Convert.ToInt32(TxtPInterBranchAc.Tag.ToString()));
			objEntryControl.SystemControlModel.Gadget = "Desktop";
			objEntryControl.SystemControlModel.AbbreviatedAmount = (TxtAbbreivateAmount.Text=="")?0:Convert.ToDecimal(TxtAbbreivateAmount.Text);
			objEntryControl.SystemControlModel.FineAndPenaltyLedgerId= ((TxtFFineAndPenaltyAc.Text.ToString() == "") ? 0 : Convert.ToInt32(TxtFFineAndPenaltyAc.Tag.ToString()));
			objEntryControl.SystemControlModel.TDSPercent = (TxtFTDS.Text == "") ? 0 : Convert.ToDecimal(TxtFTDS.Text);
			objEntryControl.SystemControlModel.SecurityDepositPercent = (TxtFSecurityDeposit.Text == "") ? 0 : Convert.ToDecimal(TxtFSecurityDeposit.Text);
			objEntryControl.SystemControlModel.FineAndPenaltyPercent = (TxtFFineAndPenalty.Text == "") ? 0 : Convert.ToDecimal(TxtFFineAndPenalty.Text);
			objEntryControl.SystemControlModel.ProductionLedgerId= ((TxtIProductionAc.Text.ToString() == "") ? 0 : Convert.ToInt32(TxtIProductionAc.Tag.ToString()));
			EntryControlViewModel dtl = null;
            objEntryControl.EntryControl.Clear();

            #region ---------- FINANCE ------------

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "F";
            dtl.ControlName = "VoucherDate";
            dtl.ControlValue = ChkFVoucherDate.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "F";
            dtl.ControlName = "Currency";
            dtl.ControlValue = ChkFCurrency.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkFMCurrency.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "F";
            dtl.ControlName = "Department";
            dtl.ControlValue = ChkFDepartment.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkFMDepartment.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "F";
            dtl.ControlName = "DepartmentItem";
            dtl.ControlValue = ChkFDepartmentItem.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkFMDepartmentItem.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "F";
            dtl.ControlName = "Narration";
            dtl.ControlValue = ChkFNarration.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkFMNarration.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "F";
            dtl.ControlName = "Salesman";
            dtl.ControlValue = ChkFSalesman.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkFMSalesman.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "F";
            dtl.ControlName = "Subledger";
            dtl.ControlValue = ChkFSubledger.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkFMSubledger.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "F";
            dtl.ControlName = "ItemSubledger";
            dtl.ControlValue = ChkFItemSubledger.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkFMItemSubledger.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "F";
            dtl.ControlName = "Remarks";
            dtl.ControlValue = ChkFRemarks.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkFMRemarks.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

			dtl = new EntryControlViewModel();
			dtl.EntryModule = "F";
			dtl.ControlName = "Provisional";
			dtl.ControlValue = ChkFProvisional.Checked == true ? "Y" : "N";
			dtl.MandatoryOpt = ChkFMProvisional.Checked == true ? "Y" : "N";
			objEntryControl.EntryControl.Add(dtl);

			dtl = new EntryControlViewModel();
			dtl.EntryModule = "F";
			dtl.ControlName = "PDC";
			dtl.ControlValue = ChkFPDC.Checked == true ? "Y" : "N";
			dtl.MandatoryOpt = ChkFMPDC.Checked == true ? "Y" : "N";
			objEntryControl.EntryControl.Add(dtl);

			dtl = new EntryControlViewModel();
			dtl.EntryModule = "F";
			dtl.ControlName = "CashIndent";
			dtl.ControlValue = ChkFCashIndent.Checked == true ? "Y" : "N";
			dtl.MandatoryOpt = ChkFMCashIndent.Checked == true ? "Y" : "N";
			objEntryControl.EntryControl.Add(dtl);

			dtl = new EntryControlViewModel();
			dtl.EntryModule = "F";
			dtl.ControlName = "RefNumber";
			dtl.ControlValue = ChkFRefNumber.Checked == true ? "Y" : "N";
			dtl.MandatoryOpt = ChkFMRefNumber.Checked == true ? "Y" : "N";
			objEntryControl.EntryControl.Add(dtl);
			#endregion

			#region ---------- PURCHASE ------------

			dtl = new EntryControlViewModel();
            dtl.EntryModule = "P";
            dtl.ControlName = "BillType";
            dtl.ControlValue = ChkPBillType.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "P";
            dtl.ControlName = "ProductGroupWise";
            dtl.ControlValue = ChkPProductGroupWise.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "P";
            dtl.ControlName = "ProductSubGroupWise";
            dtl.ControlValue = ChkPProductSubGroupWise.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "P";
            dtl.ControlName = "UnitConversion";
            dtl.ControlValue = ChkPUnitConversion.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "P";
            dtl.ControlName = "AdditionalDesc";
            dtl.ControlValue = ChkPAdditionalDesc.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "P";
            dtl.ControlName = "ProductUnit";
            dtl.ControlValue = ChkPProductUnit.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "P";
            dtl.ControlName = "VoucherDate";
            dtl.ControlValue = ChkPVoucherDate.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "P";
            dtl.ControlName = "Indent";
            dtl.ControlValue = ChkPIndent.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkPMIndent.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "P";
            dtl.ControlName = "Quotation";
            dtl.ControlValue = ChkPQuotation.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkPMQuotation.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "P";
            dtl.ControlName = "Order";
            dtl.ControlValue = ChkPOrder.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkPMOrder.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "P";
            dtl.ControlName = "Challan";
            dtl.ControlValue = ChkPChallan.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkPMChallan.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "P";
            dtl.ControlName = "ReferenceNo";
            dtl.ControlValue = ChkPReferenceNo.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkPMReferenceNo.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "P";
            dtl.ControlName = "Department";
            dtl.ControlValue = ChkPDepartment.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkPMDepartment.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "P";
            dtl.ControlName = "Salesman";
            dtl.ControlValue = ChkPSalesman.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkPMSalesman.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "P";
            dtl.ControlName = "Subledger";
            dtl.ControlValue = ChkPSubledger.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkPMSubledger.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "P";
            dtl.ControlName = "Currency";
            dtl.ControlValue = ChkPCurrency.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkPMCurrency.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "P";
            dtl.ControlName = "Remarks";
            dtl.ControlValue = ChkPRemarks.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkPMRemarks.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "P";
            dtl.ControlName = "Godown";
            dtl.ControlValue = ChkPGodown.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkPMGodown.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            #endregion

            #region ---------- SALES ------------
            dtl = new EntryControlViewModel();
            dtl.EntryModule = "S";
            dtl.ControlName = "DispatchOrder";
            dtl.ControlValue = ChkSDispatchOrder.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "S";
            dtl.ControlName = "ProductGroupWise";
            dtl.ControlValue = ChkSProductGroupWise.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "S";
            dtl.ControlName = "ProductSubGroupWise";
            dtl.ControlValue = ChkSProductSubGroupWise.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "S";
            dtl.ControlName = "UnitConversion";
            dtl.ControlValue = ChkSUnitConversion.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "S";
            dtl.ControlName = "AdditionalDesc";
            dtl.ControlValue = ChkSAdditionalDesc.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "S";
            dtl.ControlName = "ProductUnit";
            dtl.ControlValue = ChkSProductUnit.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "S";
            dtl.ControlName = "VoucherDate";
            dtl.ControlValue = ChkSVoucherDate.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "S";
            dtl.ControlName = "ChangeBasicAmount";
            dtl.ControlValue = ChkChangeBasicAmount.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "S";
            dtl.ControlName = "Quotation";
            dtl.ControlValue = ChkSQuotation.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkSMQuotation.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "S";
            dtl.ControlName = "Order";
            dtl.ControlValue = ChkSOrder.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkSMOrder.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "S";
            dtl.ControlName = "Challan";
            dtl.ControlValue = ChkSChallan.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkSMChallan.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "S";
            dtl.ControlName = "ReferenceNo";
            dtl.ControlValue = ChkSReferenceNo.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkSMReferenceNo.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "S";
            dtl.ControlName = "Department";
            dtl.ControlValue = ChkSDepartment.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkSMDepartment.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "S";
            dtl.ControlName = "Salesman";
            dtl.ControlValue = ChkSSalesman.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkSMSalesman.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "S";
            dtl.ControlName = "Subledger";
            dtl.ControlValue = ChkSSubledger.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkSMSubledger.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "S";
            dtl.ControlName = "Currency";
            dtl.ControlValue = ChkSCurrency.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkSMCurrency.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "S";
            dtl.ControlName = "Remarks";
            dtl.ControlValue = ChkSRemarks.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkSMRemarks.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "S";
            dtl.ControlName = "Godown";
            dtl.ControlValue = ChkSGodown.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkSMGodown.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);
            #endregion

            #region ---------- INVENTORY ------------
            dtl = new EntryControlViewModel();
            dtl.EntryModule = "I";
            dtl.ControlName = "VoucherDate";
            dtl.ControlValue = ChkIVoucherDate.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "I";
            dtl.ControlName = "ProductGroupWise";
            dtl.ControlValue = ChkIProductGroupWise.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "I";
            dtl.ControlName = "ProductSubGroupWise";
            dtl.ControlValue = ChkIProductSubGroupWise.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "I";
            dtl.ControlName = "UnitConversion";
            dtl.ControlValue = ChkIUnitConversion.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "I";
            dtl.ControlName = "AdditionalDesc";
            dtl.ControlValue = ChkIAdditionalDesc.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "I";
            dtl.ControlName = "ProductUnit";
            dtl.ControlValue = ChkIProductUnit.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "I";
            dtl.ControlName = "FreeQty";
            dtl.ControlValue = ChkIFreeQty.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "I";
            dtl.ControlName = "ExtraFreeQty";
            dtl.ControlValue = ChkIExtraFreeQty.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "I";
            dtl.ControlName = "MfgDate";
            dtl.ControlValue = ChkIMfgDate.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "I";
            dtl.ControlName = "ExpDate";
            dtl.ControlValue = ChkIExpDate.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "I";
            dtl.ControlName = "Salesman";
            dtl.ControlValue = ChkISalesman.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkIMSalesman.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "I";
            dtl.ControlName = "Subledger";
            dtl.ControlValue = ChkISubledger.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkIMSubledger.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "I";
            dtl.ControlName = "Currency";
            dtl.ControlValue = ChkICurrency.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkIMCurrency.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "I";
            dtl.ControlName = "Department";
            dtl.ControlValue = ChkIDepartment.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkIMDepartment.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "I";
            dtl.ControlName = "Remarks";
            dtl.ControlValue = ChkIRemarks.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkIMRemarks.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "I";
            dtl.ControlName = "CostCenter";
            dtl.ControlValue = ChkICostCenter.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkIMCostCenter.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "I";
            dtl.ControlName = "CostCenterItem";
            dtl.ControlValue = ChkICostCenterItem.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkIMCostCenterItem.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "I";
            dtl.ControlName = "Godown";
            dtl.ControlValue = ChkIGodown.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkIMGodown.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "I";
            dtl.ControlName = "GodownItem";
            dtl.ControlValue = ChkIGodownItem.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkIMGodownItem.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "I";
            dtl.ControlName = "AltQtyConversion";
            dtl.ControlValue = ChkIAltQtyConversion.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkIAltQtyConversion.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);

            dtl = new EntryControlViewModel();
            dtl.EntryModule = "I";
            dtl.ControlName = "AltQtyConversionRatioChange";
            dtl.ControlValue = ChkIChangeAltQtyConversionRatio.Checked == true ? "Y" : "N";
            dtl.MandatoryOpt = ChkIChangeAltQtyConversionRatio.Checked == true ? "Y" : "N";
            objEntryControl.EntryControl.Add(dtl);


            


            #endregion

            objEntryControl.SaveEntryControl();

            ClsGlobal.EntryControl("");
            MessageBox.Show("Data submit successfully", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void FrmSystemSetting_Load(object sender, EventArgs e)
        {
            SetData();
            objEntryControl.GetEntryControl("");
            if (objEntryControl.EntryControl.Count > 0)
            {
                for (int i = 0; i < objEntryControl.EntryControl.Count; i++)
                {
                    if (objEntryControl.EntryControl[i].EntryModule.ToString() == "F" && objEntryControl.EntryControl[i].ControlName.ToString() == "Salesman")
                    {
                        ChkFSalesman.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkFMSalesman.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "F" && objEntryControl.EntryControl[i].ControlName.ToString() == "Currency")
                    {
                        ChkFCurrency.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkFMCurrency.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "F" && objEntryControl.EntryControl[i].ControlName.ToString() == "Department")
                    {
                        ChkFDepartment.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkFMDepartment.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "F" && objEntryControl.EntryControl[i].ControlName.ToString() == "DepartmentItem")
                    {
                        ChkFDepartmentItem.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkFMDepartmentItem.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "F" && objEntryControl.EntryControl[i].ControlName.ToString() == "Narration")
                    {
                        ChkFNarration.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkFMNarration.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "F" && objEntryControl.EntryControl[i].ControlName.ToString() == "Remarks")
                    {
                        ChkFRemarks.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkFMRemarks.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "F" && objEntryControl.EntryControl[i].ControlName.ToString() == "Subledger")
                    {
                        ChkFSubledger.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkFMSubledger.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "F" && objEntryControl.EntryControl[i].ControlName.ToString() == "ItemSubledger")
                    {
                        ChkFItemSubledger.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkFMItemSubledger.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
					else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "F" && objEntryControl.EntryControl[i].ControlName.ToString() == "Provisional")
					{
						ChkFProvisional.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
						ChkFMProvisional.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
					}
					else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "F" && objEntryControl.EntryControl[i].ControlName.ToString() == "PDC")
					{
						ChkFPDC.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
						ChkFMPDC.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
					}
					else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "F" && objEntryControl.EntryControl[i].ControlName.ToString() == "CashIndent")
					{
						ChkFCashIndent.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
						ChkFMCashIndent.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
					}
					else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "F" && objEntryControl.EntryControl[i].ControlName.ToString() == "RefNumber")
					{
						ChkFRefNumber.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
						ChkFMRefNumber.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
					}
					else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "F" && objEntryControl.EntryControl[i].ControlName.ToString() == "VoucherDate")
                    {
                        ChkFVoucherDate.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                    }


                    ///Pirchase
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "AdditionalDesc")
                    {
                        ChkPAdditionalDesc.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "Salesman")
                    {
                        ChkPSalesman.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkPMSalesman.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "BillType")
                    {
                        ChkPBillType.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "Challan")
                    {
                        ChkPChallan.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkPMChallan.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "Currency")
                    {
                        ChkPCurrency.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkPMCurrency.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "Department")
                    {
                        ChkPDepartment.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkPMDepartment.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "Godown")
                    {
                        ChkPGodown.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkPMGodown.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "Indent")
                    {
                        ChkPIndent.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkPMIndent.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "Order")
                    {
                        ChkPOrder.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkPMOrder.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "ProductGroupWise")
                    {
                        ChkPProductGroupWise.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "ProductSubGroupWise")
                    {
                        ChkPProductSubGroupWise.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "ProductUnit")
                    {
                        ChkPProductUnit.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "Quotation")
                    {
                        ChkPQuotation.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkPMQuotation.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "ReferenceNo")
                    {
                        ChkPReferenceNo.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkPMReferenceNo.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "Remarks")
                    {
                        ChkPRemarks.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkPMRemarks.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "Subledger")
                    {
                        ChkPSubledger.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkPMSubledger.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "UnitConversion")
                    {
                        ChkPUnitConversion.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "P" && objEntryControl.EntryControl[i].ControlName.ToString() == "VoucherDate")
                    {
                        ChkPVoucherDate.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                    }

                    ///Sales
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "AdditionalDesc")
                    {
                        ChkSAdditionalDesc.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "Salesman")
                    {
                        ChkSSalesman.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkSMSalesman.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "Challan")
                    {
                        ChkSChallan.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkSMChallan.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "Currency")
                    {
                        ChkSCurrency.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkSMCurrency.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "Department")
                    {
                        ChkSDepartment.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkSMDepartment.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "DispatchOrder")
                    {
                        ChkSDispatchOrder.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "Godown")
                    {
                        ChkSGodown.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkSMGodown.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "Order")
                    {
                        ChkSOrder.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkSMOrder.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "ProductGroupWise")
                    {
                        ChkSProductGroupWise.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "ProductSubGroupWise")
                    {
                        ChkSProductSubGroupWise.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "ProductUnit")
                    {
                        ChkSProductUnit.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "Quotation")
                    {
                        ChkSQuotation.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkSMQuotation.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "ReferenceNo")
                    {
                        ChkSReferenceNo.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkSMReferenceNo.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "Remarks")
                    {
                        ChkSRemarks.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkSMRemarks.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "Subledger")
                    {
                        ChkSSubledger.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkSMSubledger.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "UnitConversion")
                    {
                        ChkSUnitConversion.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "VoucherDate")
                    {
                        ChkSVoucherDate.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "S" && objEntryControl.EntryControl[i].ControlName.ToString() == "ChangeBasicAmount")
                    {
                        ChkChangeBasicAmount.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                    }
                    ///Inventory
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "AdditionalDesc")
                    {
                        ChkIAdditionalDesc.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "Salesman")
                    {
                        ChkISalesman.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkIMSalesman.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "CostCenter")
                    {
                        ChkICostCenter.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkIMCostCenter.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "CostCenterItem")
                    {
                        ChkICostCenterItem.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkIMCostCenterItem.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "Currency")
                    {
                        ChkICurrency.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkIMCurrency.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "Department")
                    {
                        ChkIDepartment.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkIMDepartment.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "ExpDate")
                    {
                        ChkIExpDate.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "ExtraFreeQty")
                    {
                        ChkIExtraFreeQty.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "FreeQty")
                    {
                        ChkIFreeQty.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "Godown")
                    {
                        ChkIGodown.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkIMGodown.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "GodownItem")
                    {
                        ChkIGodownItem.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkIMGodownItem.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "MfgDate")
                    {
                        ChkIMfgDate.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "ProductGroupWise")
                    {
                        ChkIProductGroupWise.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "ProductSubGroupWise")
                    {
                        ChkIProductSubGroupWise.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "ProductUnit")
                    {
                        ChkIProductUnit.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                    }

                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "Remarks")
                    {
                        ChkIRemarks.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkIMRemarks.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "Subledger")
                    {
                        ChkISubledger.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                        ChkIMSubledger.Checked = objEntryControl.EntryControl[i].MandatoryOpt == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "UnitConversion")
                    {
                        ChkIUnitConversion.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "VoucherDate")
                    {
                        ChkIVoucherDate.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "AltQtyConversion")
                    {
                        ChkIAltQtyConversion.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                    }
                    else if (objEntryControl.EntryControl[i].EntryModule.ToString() == "I" && objEntryControl.EntryControl[i].ControlName.ToString() == "AltQtyConversionRatioChange")
                    {
                        ChkIChangeAltQtyConversionRatio.Checked = objEntryControl.EntryControl[i].ControlValue == "Y" ? true : false;
                    }
                }
            }
			if (ClsGlobal.SoftwareFocus == "Restaurant")
				LblAbbOrder.Text = "Order Doc.Number";
			else if (ClsGlobal.SoftwareFocus == "POS")
				LblAbbOrder.Text = "Abb.Doc.Number";
		}

        #region ---------------Search Button click Event ------------------------------
        private void BtnSSalesReturnAc_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Generalledger", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtSSalesReturnAc.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
                    TxtSSalesReturnAc.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["ledgerId"].ToString().Trim());
                    TxtSSalesReturnAc.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Ledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtSSalesReturnAc.Focus();
                return;
            }
            _SearchKey = "";
            TxtSSalesReturnAc.Focus();

        }
        private void BtnSSalesAc_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Generalledger", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtSSalesAc.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
                    TxtSSalesAc.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["ledgerId"].ToString().Trim());
                    TxtSSalesAc.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Ledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtSSalesAc.Focus();
                return;
            }
            _SearchKey = "";
            TxtSSalesAc.Focus();

        }
        private void BtnSInterBranchAc_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Generalledger", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtSInterBranchAc.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
                    TxtSInterBranchAc.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["ledgerId"].ToString().Trim());
                    TxtSInterBranchAc.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Ledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtSInterBranchAc.Focus();
                return;
            }
            _SearchKey = "";
            TxtSInterBranchAc.Focus();

        }
        private void BtnSVATTerm_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("SalesBillingTerm", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {

                    TxtSVATTerm.Text = frmPickList.SelectedList[0]["TermDesc"].ToString().Trim();
                    TxtSVATTerm.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["TermId"].ToString().Trim());
                    TxtSVATTerm.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in SubLedger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtSVATTerm.Focus();
                return;
            }
            _SearchKey = "";
            TxtSVATTerm.Focus();

        }
        private void BtnSServiceChargeTerm_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("SalesBillingTerm", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {

                    TxtSServiceChargeTerm.Text = frmPickList.SelectedList[0]["TermDesc"].ToString().Trim();
                    TxtSServiceChargeTerm.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["TermId"].ToString().Trim());
                    TxtSServiceChargeTerm.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in SubLedger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtSServiceChargeTerm.Focus();
                return;
            }
            _SearchKey = "";
            TxtSServiceChargeTerm.Focus();

        }
        private void BtnSSalesSubledgerAc_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Subledger", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {

                    TxtSSalesSubledgerAc.Text = frmPickList.SelectedList[0]["SubledgerDesc"].ToString().Trim();
                    TxtSSalesSubledgerAc.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["SubledgerId"].ToString().Trim());
                    TxtSSalesSubledgerAc.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in SubLedger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtSSalesSubledgerAc.Focus();
                return;
            }
            _SearchKey = "";
            TxtSSalesSubledgerAc.Focus();
        }
        private void BtnSSalesReturnSubledgerAc_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Subledger", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {

                    TxtSSalesReturnSubledgerAc.Text = frmPickList.SelectedList[0]["SubledgerDesc"].ToString().Trim();
                    TxtSSalesReturnSubledgerAc.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["SubledgerId"].ToString().Trim());
                    TxtSSalesSubledgerAc.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in SubLedger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtSSalesReturnSubledgerAc.Focus();
                return;
            }
            _SearchKey = "";
            TxtSSalesReturnSubledgerAc.Focus();
        }
        private void BtnSBillDiscTerm_Click(object sender, EventArgs e)
        {
            ClsGlobal.IsBillWise = "Y";
            Common.PickList frmPickList = new Common.PickList("SalesBillingTerm", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    TxtSBillDiscTerm.Text = frmPickList.SelectedList[0]["TermDesc"].ToString().Trim();
                    TxtSBillDiscTerm.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["TermId"].ToString().Trim());
                    TxtSBillDiscTerm.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Term !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtSBillDiscTerm.Focus();
                return;
            }
            _SearchKey = "";
            TxtSBillDiscTerm.Focus();
        }
        private void BtnSProductDiscTerm_Click(object sender, EventArgs e)
        {
            ClsGlobal.IsBillWise = "N";
            Common.PickList frmPickList = new Common.PickList("SalesBillingTerm", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    TxtSProductDiscTerm.Text = frmPickList.SelectedList[0]["TermDesc"].ToString().Trim();
                    TxtSProductDiscTerm.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["TermId"].ToString().Trim());
                    TxtSProductDiscTerm.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Term !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtSProductDiscTerm.Focus();
                return;
            }
            _SearchKey = "";
            TxtSProductDiscTerm.Focus();
        }
        private void BtnSProductSplDiscTerm_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("SalesBillingTerm", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    TxtSProductSplDiscTerm.Text = frmPickList.SelectedList[0]["TermDesc"].ToString().Trim();
                    TxtSProductSplDiscTerm.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["TermId"].ToString().Trim());
                    TxtSProductSplDiscTerm.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Term !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtSProductSplDiscTerm.Focus();
                return;
            }
            _SearchKey = "";
            TxtSProductSplDiscTerm.Focus();

        }
        private void BtnFProfitAndLoss_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Generalledger", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    TxtFProfitAndLoss.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
                    TxtFProfitAndLoss.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["LedgerId"].ToString().Trim());
                    TxtFProfitAndLoss.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in General Ledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtFProfitAndLoss.Focus();
                return;
            }
            _SearchKey = "";
            TxtFProfitAndLoss.Focus();
        }

        private void BtnFCashAc_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Generalledger", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    TxtFCashAc.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
                    TxtFCashAc.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["LedgerId"].ToString().Trim());
                    TxtFCashAc.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in General Ledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtFCashAc.Focus();
                return;
            }
            _SearchKey = "";
            TxtFCashAc.Focus();
        }

        private void BtnFVATAc_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Generalledger", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    TxtFVATAc.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
                    TxtFVATAc.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["LedgerId"].ToString().Trim());
                    TxtFVATAc.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in General Ledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtFVATAc.Focus();
                return;
            }
            _SearchKey = "";
            TxtFVATAc.Focus();
        }

        private void BtnFPDCBank_Click(object sender, EventArgs e)
        {
			Common.PickList frmPickList = new Common.PickList("Generalledger", _SearchKey);
			if (Common.PickList.dt.Rows.Count > 0)
			{
				frmPickList.ShowDialog();
				if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
				{
					TxtFPDCBank.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
					TxtFPDCBank.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["LedgerId"].ToString().Trim());
					TxtFPDCBank.SelectAll();
				}
				frmPickList.Dispose();
			}
			else
			{
				MessageBox.Show("No List Available in General Ledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				TxtFPDCBank.Focus();
				return;
			}
			_SearchKey = "";
			TxtFPDCBank.Focus();
		}

        private void BtnFTDSAc_Click(object sender, EventArgs e)
        {
			Common.PickList frmPickList = new Common.PickList("Generalledger", _SearchKey);
			if (Common.PickList.dt.Rows.Count > 0)
			{
				frmPickList.ShowDialog();
				if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
				{
					TxtFTDSAc.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
					TxtFTDSAc.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["LedgerId"].ToString().Trim());
					TxtFTDSAc.SelectAll();
				}
				frmPickList.Dispose();
			}
			else
			{
				MessageBox.Show("No List Available in General Ledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				TxtFTDSAc.Focus();
				return;
			}
			_SearchKey = "";
			TxtFTDSAc.Focus();
		}

        private void BtnFSecurityDepositAc_Click(object sender, EventArgs e)
        {
			Common.PickList frmPickList = new Common.PickList("Generalledger", _SearchKey);
			if (Common.PickList.dt.Rows.Count > 0)
			{
				frmPickList.ShowDialog();
				if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
				{
					TxtFSecurityDepositAc.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
					TxtFSecurityDepositAc.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["LedgerId"].ToString().Trim());
					TxtFSecurityDepositAc.SelectAll();
				}
				frmPickList.Dispose();
			}
			else
			{
				MessageBox.Show("No List Available in General Ledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				TxtFSecurityDepositAc.Focus();
				return;
			}
			_SearchKey = "";
			TxtFSecurityDepositAc.Focus();

		}

        private void BtnFFineAndPenaltyAc_Click(object sender, EventArgs e)
        {
			Common.PickList frmPickList = new Common.PickList("Generalledger", _SearchKey);
			if (Common.PickList.dt.Rows.Count > 0)
			{
				frmPickList.ShowDialog();
				if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
				{
					TxtFFineAndPenaltyAc.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
					TxtFFineAndPenaltyAc.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["LedgerId"].ToString().Trim());
					TxtFFineAndPenaltyAc.SelectAll();
				}
				frmPickList.Dispose();
			}
			else
			{
				MessageBox.Show("No List Available in General Ledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				TxtFFineAndPenaltyAc.Focus();
				return;
			}
			_SearchKey = "";
			TxtFFineAndPenaltyAc.Focus();
		}
        private void BtnFCardAc_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Generalledger", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    TxtFCardAc.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
                    TxtFCardAc.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["LedgerId"].ToString().Trim());
                    TxtFCardAc.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in General Ledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtFCardAc.Focus();
                return;
            }
            _SearchKey = "";
            TxtFCardAc.Focus();
        }


		private void BtnPPuchaseAc_Click(object sender, EventArgs e)
		{
			Common.PickList frmPickList = new Common.PickList("Generalledger", _SearchKey);
			if (Common.PickList.dt.Rows.Count > 0)
			{
				frmPickList.ShowDialog();
				if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
				{
					TxtPPuchaseAc.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
					TxtPPuchaseAc.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["LedgerId"].ToString().Trim());
					TxtPPuchaseAc.SelectAll();
				}
				frmPickList.Dispose();
			}
			else
			{
				MessageBox.Show("No List Available in General Ledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				TxtPPuchaseAc.Focus();
				return;
			}
			_SearchKey = "";
			TxtPPuchaseAc.Focus();
		}

		private void BtnPPuchaseReturnAc_Click(object sender, EventArgs e)
		{
			Common.PickList frmPickList = new Common.PickList("Generalledger", _SearchKey);
			if (Common.PickList.dt.Rows.Count > 0)
			{
				frmPickList.ShowDialog();
				if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
				{
					TxtPPuchaseReturnAc.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
					TxtPPuchaseReturnAc.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["LedgerId"].ToString().Trim());
					TxtPPuchaseReturnAc.SelectAll();
				}
				frmPickList.Dispose();
			}
			else
			{
				MessageBox.Show("No List Available in General Ledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				TxtPPuchaseReturnAc.Focus();
				return;
			}
			_SearchKey = "";
			TxtPPuchaseReturnAc.Focus();
		}

		private void BtnPInterBranchAc_Click(object sender, EventArgs e)
		{
			Common.PickList frmPickList = new Common.PickList("Generalledger", _SearchKey);
			if (Common.PickList.dt.Rows.Count > 0)
			{
				frmPickList.ShowDialog();
				if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
				{
					TxtPInterBranchAc.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
					TxtPInterBranchAc.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["LedgerId"].ToString().Trim());
					TxtPInterBranchAc.SelectAll();
				}
				frmPickList.Dispose();
			}
			else
			{
				MessageBox.Show("No List Available in General Ledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				TxtPInterBranchAc.Focus();
				return;
			}
			_SearchKey = "";
			TxtPInterBranchAc.Focus();
		}

		private void BtnPVatTerm_Click(object sender, EventArgs e)
		{
			ClsGlobal.IsBillWise = "Y";
			Common.PickList frmPickList = new Common.PickList("PurchaseBillingTerm", _SearchKey);
			if (Common.PickList.dt.Rows.Count > 0)
			{
				frmPickList.ShowDialog();
				if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
				{
					TxtPVatTerm.Text = frmPickList.SelectedList[0]["TermDesc"].ToString().Trim();
					TxtPVatTerm.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["TermId"].ToString().Trim());
					TxtPVatTerm.SelectAll();
				}
				frmPickList.Dispose();
			}
			else
			{
				MessageBox.Show("No List Available in Term !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				TxtPVatTerm.Focus();
				return;
			}
			_SearchKey = "";
			TxtPVatTerm.Focus();
		}

		private void BtnPPuchaseSubledgerAc_Click(object sender, EventArgs e)
		{
			Common.PickList frmPickList = new Common.PickList("Subledger", _SearchKey);
			if (Common.PickList.dt.Rows.Count > 0)
			{
				frmPickList.ShowDialog();
				if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
				{
					TxtPPuchaseSubledgerAc.Text = frmPickList.SelectedList[0]["SubledgerDesc"].ToString().Trim();
					TxtPPuchaseSubledgerAc.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["SubledgerId"].ToString().Trim());
					TxtPPuchaseSubledgerAc.SelectAll();
				}
				frmPickList.Dispose();
			}
			else
			{
				MessageBox.Show("No List Available in Sub Ledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				TxtPPuchaseSubledgerAc.Focus();
				return;
			}
			_SearchKey = "";
			TxtPPuchaseSubledgerAc.Focus();
		}

		private void BtnPPuchaseReturnSubLedgerAc_Click(object sender, EventArgs e)
		{
			Common.PickList frmPickList = new Common.PickList("Subledger", _SearchKey);
			if (Common.PickList.dt.Rows.Count > 0)
			{
				frmPickList.ShowDialog();
				if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
				{
					TxtPPuchaseReturnSubLedgerAc.Text = frmPickList.SelectedList[0]["SubledgerDesc"].ToString().Trim();
					TxtPPuchaseReturnSubLedgerAc.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["SubledgerId"].ToString().Trim());
					TxtPPuchaseReturnSubLedgerAc.SelectAll();
				}
				frmPickList.Dispose();
			}
			else
			{
				MessageBox.Show("No List Available in Sub Ledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				TxtPPuchaseReturnSubLedgerAc.Focus();
				return;
			}
			_SearchKey = "";
			TxtPPuchaseReturnSubLedgerAc.Focus();
		}

		private void BtnPPDiscountTerm_Click(object sender, EventArgs e)
		{
			ClsGlobal.IsBillWise = "P";
			Common.PickList frmPickList = new Common.PickList("PurchaseBillingTerm", _SearchKey);
			if (Common.PickList.dt.Rows.Count > 0)
			{
				frmPickList.ShowDialog();
				if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
				{
					TxtPPDiscountTerm.Text = frmPickList.SelectedList[0]["TermDesc"].ToString().Trim();
					TxtPPDiscountTerm.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["TermId"].ToString().Trim());
					TxtPPDiscountTerm.SelectAll();
				}
				frmPickList.Dispose();
			}
			else
			{
				MessageBox.Show("No List Available in Term !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				TxtPPDiscountTerm.Focus();
				return;
			}
			_SearchKey = "";
			TxtPPDiscountTerm.Focus();

		}

		private void BtnPBDiscountTerm_Click(object sender, EventArgs e)
		{
			ClsGlobal.IsBillWise = "B";
			Common.PickList frmPickList = new Common.PickList("PurchaseBillingTerm", _SearchKey);
			if (Common.PickList.dt.Rows.Count > 0)
			{
				frmPickList.ShowDialog();
				if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
				{
					TxtPBDiscountTerm.Text = frmPickList.SelectedList[0]["TermDesc"].ToString().Trim();
					TxtPBDiscountTerm.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["TermId"].ToString().Trim());
					TxtPBDiscountTerm.SelectAll();
				}
				frmPickList.Dispose();
			}
			else
			{
				MessageBox.Show("No List Available in Term !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				TxtPBDiscountTerm.Focus();
				return;
			}
			_SearchKey = "";
			TxtPBDiscountTerm.Focus();
		}

		private void BtnSearchDefaultCurrency_Click(object sender, EventArgs e)
		{
			ClsButtonClick.CurrencyBtnClick(_SearchKey, TxtDefaultCurrency, e);
			_SearchKey = string.Empty;
		}
		private void BtnPosDocNumberSearch_Click(object sender, EventArgs e)
		{

			Common.PickList frmPickList = new Common.PickList("DocumentNumber.Sales Invoice", _SearchKey);
			if (Common.PickList.dt.Rows.Count > 0)
			{
				frmPickList.ShowDialog();
				if (frmPickList.SelectedList.Count > 0)
				{
					TxtPosDocumentNumber.Text = frmPickList.SelectedList[0]["DocDesc"].ToString().Trim();
					TxtPosDocumentNumber.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["DocId"].ToString().Trim());
					TxtPosDocumentNumber.SelectAll();
				}
				frmPickList.Dispose();
			}
			else
			{
				MessageBox.Show("No List Available in Documnet Numbering !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				TxtPosDocumentNumber.Focus();
				return;
			}
			_SearchKey = "";
			TxtPosDocumentNumber.Focus();

		}

		private void BtnOrderDocNumberSearch_Click(object sender, EventArgs e)
		{
			Common.PickList frmPickList = null;
			if (ClsGlobal.SoftwareFocus == "POS")
				frmPickList = new Common.PickList("DocumentNumber.Sales Invoice", _SearchKey);
			else
				frmPickList = new Common.PickList("DocumentNumber.Sales Order", _SearchKey);
			if (Common.PickList.dt.Rows.Count > 0)
			{
				frmPickList.ShowDialog();
				if (frmPickList.SelectedList.Count > 0)
				{
					TxtOrderDocumentNumber.Text = frmPickList.SelectedList[0]["DocDesc"].ToString().Trim();
					TxtOrderDocumentNumber.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["DocId"].ToString().Trim());
					TxtOrderDocumentNumber.SelectAll();
				}
				frmPickList.Dispose();
			}
			else
			{
				MessageBox.Show("No List Available in Document Numbering !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				TxtOrderDocumentNumber.Focus();
				return;
			}
			_SearchKey = "";
			TxtOrderDocumentNumber.Focus();

		}


		private void BtnIOpeingStockPLAc_Click(object sender, EventArgs e)
		{
			Common.PickList frmPickList = new Common.PickList("Generalledger", _SearchKey);
			if (Common.PickList.dt.Rows.Count > 0)
			{
				frmPickList.ShowDialog();
				if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
				{
					TxtIOpeingStockPLAc.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
					TxtIOpeingStockPLAc.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["LedgerId"].ToString().Trim());
					TxtIOpeingStockPLAc.SelectAll();
				}
				frmPickList.Dispose();
			}
			else
			{
				MessageBox.Show("No List Available in General Ledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				TxtIOpeingStockPLAc.Focus();
				return;
			}
			_SearchKey = "";
			TxtIOpeingStockPLAc.Focus();
		}

		private void BtnIClosingStockPLAc_Click(object sender, EventArgs e)
		{
			Common.PickList frmPickList = new Common.PickList("Generalledger", _SearchKey);
			if (Common.PickList.dt.Rows.Count > 0)
			{
				frmPickList.ShowDialog();
				if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
				{
					TxtIClosingStockPLAc.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
					TxtIClosingStockPLAc.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["LedgerId"].ToString().Trim());
					TxtIClosingStockPLAc.SelectAll();
				}
				frmPickList.Dispose();
			}
			else
			{
				MessageBox.Show("No List Available in General Ledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				TxtIClosingStockPLAc.Focus();
				return;
			}
			_SearchKey = "";
			TxtIClosingStockPLAc.Focus();
		}

		private void BtnIClosingStockBLAc_Click(object sender, EventArgs e)
		{
			Common.PickList frmPickList = new Common.PickList("Generalledger", _SearchKey);
			if (Common.PickList.dt.Rows.Count > 0)
			{
				frmPickList.ShowDialog();
				if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
				{
					TxtIClosingStockBLAc.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
					TxtIClosingStockBLAc.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["LedgerId"].ToString().Trim());
					TxtIClosingStockBLAc.SelectAll();
				}
				frmPickList.Dispose();
			}
			else
			{
				MessageBox.Show("No List Available in General Ledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				TxtIClosingStockBLAc.Focus();
				return;
			}
			_SearchKey = "";
			TxtIClosingStockBLAc.Focus();
		}

		private void BtnIProductionAc_Click(object sender, EventArgs e)
		{
			Common.PickList frmPickList = new Common.PickList("Generalledger", _SearchKey);
			if (Common.PickList.dt.Rows.Count > 0)
			{
				frmPickList.ShowDialog();
				if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
				{
					TxtIProductionAc.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
					TxtIProductionAc.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["LedgerId"].ToString().Trim());
					TxtIProductionAc.SelectAll();
				}
				frmPickList.Dispose();
			}
			else
			{
				MessageBox.Show("No List Available in General Ledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				TxtIProductionAc.Focus();
				return;
			}
			_SearchKey = "";
			TxtIProductionAc.Focus();
		}

		private void BtnIOpeingStockPLSubAc_Click(object sender, EventArgs e)
		{
			Common.PickList frmPickList = new Common.PickList("Subledger", _SearchKey);
			if (Common.PickList.dt.Rows.Count > 0)
			{
				frmPickList.ShowDialog();
				if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
				{
					TxtIOpeingStockPLSubAc.Text = frmPickList.SelectedList[0]["SubledgerDesc"].ToString().Trim();
					TxtIOpeingStockPLSubAc.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["SubledgerId"].ToString().Trim());
					TxtIOpeingStockPLSubAc.SelectAll();
				}
				frmPickList.Dispose();
			}
			else
			{
				MessageBox.Show("No List Available in Sub Ledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				TxtIOpeingStockPLSubAc.Focus();
				return;
			}
			_SearchKey = "";
			TxtIOpeingStockPLSubAc.Focus();
		}

		private void BtnIClosingStockPLSubAc_Click(object sender, EventArgs e)
		{
			Common.PickList frmPickList = new Common.PickList("Subledger", _SearchKey);
			if (Common.PickList.dt.Rows.Count > 0)
			{
				frmPickList.ShowDialog();
				if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
				{
					TxtIClosingStockPLSubAc.Text = frmPickList.SelectedList[0]["SubledgerDesc"].ToString().Trim();
					TxtIClosingStockPLSubAc.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["SubledgerId"].ToString().Trim());
					TxtIClosingStockPLSubAc.SelectAll();
				}
				frmPickList.Dispose();
			}
			else
			{
				MessageBox.Show("No List Available in Sub Ledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				TxtIClosingStockPLSubAc.Focus();
				return;
			}
			_SearchKey = "";
			TxtIClosingStockPLSubAc.Focus();
		}

		private void BtnIClosingStockBLSubAc_Click(object sender, EventArgs e)
		{
			Common.PickList frmPickList = new Common.PickList("Subledger", _SearchKey);
			if (Common.PickList.dt.Rows.Count > 0)
			{
				frmPickList.ShowDialog();
				if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
				{
					TxtIClosingStockBLSubAc.Text = frmPickList.SelectedList[0]["SubledgerDesc"].ToString().Trim();
					TxtIClosingStockBLSubAc.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["SubledgerId"].ToString().Trim());
					TxtIClosingStockBLSubAc.SelectAll();
				}
				frmPickList.Dispose();
			}
			else
			{
				MessageBox.Show("No List Available in Sub Ledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				TxtIClosingStockBLSubAc.Focus();
				return;
			}
			_SearchKey = "";
			TxtIClosingStockBLSubAc.Focus();
		}
		#endregion

		#region-------------Keydown Event-------------------------

		private void TxtSSalesAc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                MasterSetup.FrmGeneralledger frm = new MasterSetup.FrmGeneralledger();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtSSalesAc.Text = frm._NewLedger;
                TxtSSalesAc.Tag = frm._LedgerId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "Escape" ? "" : e.KeyCode.ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtSSalesAc, BtnSSalesAc, false);
            }
        }
        private void TxtSSalesReturnAc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                MasterSetup.FrmGeneralledger frm = new MasterSetup.FrmGeneralledger();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtSSalesReturnAc.Text = frm._NewLedger;
                TxtSSalesReturnAc.Tag = frm._LedgerId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "Escape" ? "" : e.KeyCode.ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtSSalesReturnAc, BtnSSalesReturnAc, false);
            }
        }
        private void TxtSSalesSubledgerAc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                MasterSetup.FrmSubledger frm = new MasterSetup.FrmSubledger();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtSSalesSubledgerAc.Text = frm._NewSubLedger;
                TxtSSalesSubledgerAc.Tag = frm._SubledgerId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "Escape" ? "" : e.KeyCode.ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtSSalesSubledgerAc, BtnSSalesSubledgerAc, false);
            }
        }
        private void TxtSInterBranchAc_KeyDown(object sender, KeyEventArgs e)
        {
            ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtSInterBranchAc, BtnSInterBranchAc, false);

        }
        private void TxtSBillDiscTerm_KeyDown(object sender, KeyEventArgs e)
        {
            ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtSBillDiscTerm, BtnSBillDiscTerm, false);

        }
        private void TxtSVATTerm_KeyDown(object sender, KeyEventArgs e)
        {
            ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtSVATTerm, BtnSVATTerm, false);

        }
        private void TxtSProductDiscTerm_KeyDown(object sender, KeyEventArgs e)
        {
            ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtSProductDiscTerm, BtnSProductDiscTerm, false);

        }
        private void TxtSServiceChargeTerm_KeyDown(object sender, KeyEventArgs e)
        {
            ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtSServiceChargeTerm, BtnSServiceChargeTerm, false);

        }
        private void TxtSProductSplDiscTerm_KeyDown(object sender, KeyEventArgs e)
        {
            ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtSProductSplDiscTerm, BtnSProductSplDiscTerm, false);

        }
        private void TxtSSalesReturnSubledgerAc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                MasterSetup.FrmSubledger frm = new MasterSetup.FrmSubledger();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtSSalesReturnSubledgerAc.Text = frm._NewSubLedger;
                TxtSSalesReturnSubledgerAc.Tag = frm._SubledgerId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "Escape" ? "" : e.KeyCode.ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtSSalesReturnSubledgerAc, BtnSSalesReturnSubledgerAc, false);
            }
        }

        private void TxtFProfitAndLoss_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                MasterSetup.FrmGeneralledger frm = new MasterSetup.FrmGeneralledger();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtFProfitAndLoss.Text = frm._NewLedger;
                TxtFProfitAndLoss.Tag = frm._LedgerId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "Escape" ? "" : e.KeyCode.ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtFProfitAndLoss, BtnFProfitAndLoss, false);
            }
        }

        private void TxtFCashAc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                MasterSetup.FrmGeneralledger frm = new MasterSetup.FrmGeneralledger();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtFCashAc.Text = frm._NewLedger;
                TxtFCashAc.Tag = frm._LedgerId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "Escape" ? "" : e.KeyCode.ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtFCashAc, BtnFCashAc, false);
            }
        }

        private void TxtFVATAc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                MasterSetup.FrmGeneralledger frm = new MasterSetup.FrmGeneralledger();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtFVATAc.Text = frm._NewLedger;
                TxtFVATAc.Tag = frm._LedgerId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "Escape" ? "" : e.KeyCode.ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtFVATAc, BtnFVATAc, false);
            }
        }

        private void TxtFPDCBank_KeyDown(object sender, KeyEventArgs e)
        {
			if (e.KeyData == (Keys.N | Keys.Control))
			{
				MasterSetup.FrmGeneralledger frm = new MasterSetup.FrmGeneralledger();
				frm._IsNew = 'Y';
				frm.ShowDialog();
				TxtFPDCBank.Text = frm._NewLedger;
				TxtFPDCBank.Tag = frm._LedgerId;
			}
			else
			{
				_SearchKey = e.KeyCode.ToString() == "Escape" ? "" : e.KeyCode.ToString();
				ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtFPDCBank, BtnFPDCBank, false);
			}
		}

        private void TxtFTDSAc_KeyDown(object sender, KeyEventArgs e)
        {
			if (e.KeyData == (Keys.N | Keys.Control))
			{
				MasterSetup.FrmGeneralledger frm = new MasterSetup.FrmGeneralledger();
				frm._IsNew = 'Y';
				frm.ShowDialog();
				TxtFTDSAc.Text = frm._NewLedger;
				TxtFTDSAc.Tag = frm._LedgerId;
			}
			else
			{
				_SearchKey = e.KeyCode.ToString() == "Escape" ? "" : e.KeyCode.ToString();
				ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtFTDSAc, BtnFTDSAc, false);
			}
		}

        private void TxtFSecurityDepositAc_KeyDown(object sender, KeyEventArgs e)
        {
			if (e.KeyData == (Keys.N | Keys.Control))
			{
				MasterSetup.FrmGeneralledger frm = new MasterSetup.FrmGeneralledger();
				frm._IsNew = 'Y';
				frm.ShowDialog();
				TxtFSecurityDepositAc.Text = frm._NewLedger;
				TxtFSecurityDepositAc.Tag = frm._LedgerId;
			}
			else
			{
				_SearchKey = e.KeyCode.ToString() == "Escape" ? "" : e.KeyCode.ToString();
				ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtFSecurityDepositAc, BtnFSecurityDepositAc, false);
			}
		}

        private void TxtFFineAndPenaltyAc_KeyDown(object sender, KeyEventArgs e)
        {
			if (e.KeyData == (Keys.N | Keys.Control))
			{
				MasterSetup.FrmGeneralledger frm = new MasterSetup.FrmGeneralledger();
				frm._IsNew = 'Y';
				frm.ShowDialog();
				TxtFFineAndPenaltyAc.Text = frm._NewLedger;
				TxtFFineAndPenaltyAc.Tag = frm._LedgerId;
			}
			else
			{
				_SearchKey = e.KeyCode.ToString() == "Escape" ? "" : e.KeyCode.ToString();
				ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtFFineAndPenaltyAc, BtnFFineAndPenaltyAc, false);
			}
		}

        private void TxtFCardAc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                MasterSetup.FrmGeneralledger frm = new MasterSetup.FrmGeneralledger();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtFCardAc.Text = frm._NewLedger;
                TxtFCardAc.Tag = frm._LedgerId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "Escape" ? "" : e.KeyCode.ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtFCardAc, BtnFCardAc, false);
            }
        }

        private void ChkFDepartment_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkFDepartment.Checked == true)
            {
                ChkFDepartmentItem.Checked = false;
                ChkFDepartmentItem.Enabled = false;
            }
            else
            {
                ChkFDepartmentItem.Enabled = true;
            }
        }

        private void ChkFDepartmentItem_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkFDepartmentItem.Checked == true)
            {
                ChkFDepartment.Checked = false;
                ChkFDepartment.Enabled = false;
            }
            else
            {
                ChkFDepartment.Enabled = true;
            }
        }

        private void TxtDefaultCurrency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmCurrency frm = new FrmCurrency();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtDefaultCurrency.Text = frm._NewCurrency;
                TxtDefaultCurrency.Tag = frm._CurrencyId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "Escape" ? "" : e.KeyCode.ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtDefaultCurrency, BtnSearchDefaultCurrency, false);
            }
        }

        private void ChkBranchWise_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkBranchWise.Checked == true)
            {
                ChkCompanyUnitWise.Checked = false;
                ChkCompanyUnitWise.Enabled = false;
            }
            else
            {
                ChkCompanyUnitWise.Enabled = true;
            }
        }

        private void ChkCompanyUnitWise_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkCompanyUnitWise.Checked == true)
            {
                ChkBranchWise.Checked = false;
                ChkBranchWise.Enabled = false;
            }
            else
            {
                ChkBranchWise.Enabled = true;
            }
        }

		private void TxtAbberivateAmount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{

		}

		private void TxtPosDocumentNumber_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == (Keys.N | Keys.Control))
			{
				//FrmDocumentNumbering frm = new FrmDocumentNumbering();
				//frm._IsNew = 'Y';
				//frm.ShowDialog();
				//TxtFCardAc.Text = frm._NewLedger;
				//TxtFCardAc.Tag = frm._LedgerId;
			}
			else
			{
				_SearchKey = e.KeyCode.ToString() == "Escape" ? "" : e.KeyCode.ToString();
				ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtPosDocumentNumber, BtnPosDocNumberSearch, false);
			}
		}

		private void TxtOrderDocumentNumber_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == (Keys.N | Keys.Control))
			{
				//FrmDocumentNumbering frm = new FrmDocumentNumbering();
				//frm._IsNew = 'Y';
				//frm.ShowDialog();
				//TxtFCardAc.Text = frm._NewLedger;
				//TxtFCardAc.Tag = frm._LedgerId;
			}
			else
			{
				_SearchKey = e.KeyCode.ToString() == "Escape" ? "" : e.KeyCode.ToString();
				ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtOrderDocumentNumber, BtnOrderDocNumberSearch, false);
			}
		}

		private void TxtPPuchaseAc_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == (Keys.N | Keys.Control))
			{
				MasterSetup.FrmGeneralledger frm = new MasterSetup.FrmGeneralledger();
				frm._IsNew = 'Y';
				frm.ShowDialog();
				TxtPPuchaseAc.Text = frm._NewLedger;
				TxtPPuchaseAc.Tag = frm._LedgerId;
			}
			else
			{
				_SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
				ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtPPuchaseAc, BtnPPuchaseAc, false);
			}
		}

		private void TxtPPuchaseReturnAc_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == (Keys.N | Keys.Control))
			{
				MasterSetup.FrmGeneralledger frm = new MasterSetup.FrmGeneralledger();
				frm._IsNew = 'Y';
				frm.ShowDialog();
				TxtPPuchaseReturnAc.Text = frm._NewLedger;
				TxtPPuchaseReturnAc.Tag = frm._LedgerId;
			}
			else
			{
				_SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
				ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtPPuchaseReturnAc, BtnPPuchaseReturnAc, false);
			}
		}

		private void TxtPInterBranchAc_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == (Keys.N | Keys.Control))
			{
				MasterSetup.FrmGeneralledger frm = new MasterSetup.FrmGeneralledger();
				frm._IsNew = 'Y';
				frm.ShowDialog();
				TxtPInterBranchAc.Text = frm._NewLedger;
				TxtPInterBranchAc.Tag = frm._LedgerId;
			}
			else
			{
				_SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
				ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtPInterBranchAc, BtnPInterBranchAc , false);
			}
		}

		private void TxtPVatTerm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == (Keys.N | Keys.Control))
			{
				//MasterSetup.FrmPurchaseTerm frm = new MasterSetup.FrmPurchaseTerm();
				//frm._IsNew = 'Y';
				//frm.ShowDialog();
				//TxtPInterBranchAc.Text = frm._NewLedger;
				//TxtPInterBranchAc.Tag = frm._LedgerId;
			}
			else
			{
				_SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
				ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtPVatTerm, BtnPVatTerm, false);
			}
		}

		private void TxtPPuchaseSubledgerAc_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == (Keys.N | Keys.Control))
			{
				MasterSetup.FrmSubledger frm = new MasterSetup.FrmSubledger();
				frm._IsNew = 'Y';
				frm.ShowDialog();
				TxtPPuchaseSubledgerAc.Text = frm._NewSubLedger;
				TxtPPuchaseSubledgerAc.Tag = frm._SubledgerId;
			}
			else
			{
				_SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
				ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtPPuchaseSubledgerAc, BtnPPuchaseSubledgerAc, false);
			}

		}

		private void TxtPPuchaseReturnSubLedgerAc_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == (Keys.N | Keys.Control))
			{
				MasterSetup.FrmSubledger frm = new MasterSetup.FrmSubledger();
				frm._IsNew = 'Y';
				frm.ShowDialog();
				TxtPPuchaseReturnSubLedgerAc.Text = frm._NewSubLedger; ;
				TxtPPuchaseReturnSubLedgerAc.Tag = frm._SubledgerId;
			}
			else
			{
				_SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
				ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtPPuchaseReturnSubLedgerAc, BtnPPuchaseReturnSubLedgerAc, false);
			}

		}
		private void TxtPPDiscountTerm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == (Keys.N | Keys.Control))
			{
				//MasterSetup.FrmPurchaseTerm frm = new MasterSetup.FrmPurchaseTerm();
				//frm._IsNew = 'Y';
				//frm.ShowDialog();
				//TxtPInterBranchAc.Text = frm._NewLedger;
				//TxtPInterBranchAc.Tag = frm._LedgerId;
			}
			else
			{
				_SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
				ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtPPDiscountTerm, BtnPPDiscountTerm, false);
			}
		}

		private void TxtPBDiscountTerm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == (Keys.N | Keys.Control))
			{
				//MasterSetup.FrmPurchaseTerm frm = new MasterSetup.FrmPurchaseTerm();
				//frm._IsNew = 'Y';
				//frm.ShowDialog();
				//TxtPInterBranchAc.Text = frm._NewLedger;
				//TxtPInterBranchAc.Tag = frm._LedgerId;
			}
			else
			{
				_SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
				ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtPBDiscountTerm, BtnPBDiscountTerm, false);
			}
		}

		private void TxtIOpeingStockPLAc_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == (Keys.N | Keys.Control))
			{
				//MasterSetup.FrmGeneralledger frm = new MasterSetup.FrmGeneralledger();
				//frm._IsNew = 'Y';
				//frm.ShowDialog();
				//TxtPPuchaseReturnSubLedgerAc.Text = frm._NewLedger;
				//TxtPPuchaseReturnSubLedgerAc.Tag = frm._LedgerId;
			}
			else
			{
				_SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
				ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtIOpeingStockPLAc, BtnIOpeingStockPLAc, false);
			}
		}

		private void TxtIClosingStockBLAc_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == (Keys.N | Keys.Control))
			{
				//MasterSetup.FrmGeneralledger frm = new MasterSetup.FrmGeneralledger();
				//frm._IsNew = 'Y';
				//frm.ShowDialog();
				//TxtPPuchaseReturnSubLedgerAc.Text = frm._NewLedger;
				//TxtPPuchaseReturnSubLedgerAc.Tag = frm._LedgerId;
			}
			else
			{
				_SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
				ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtIClosingStockBLAc, BtnIClosingStockBLAc, false);
			}
		}

		private void TxtClosingStockBLSubAc_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == (Keys.N | Keys.Control))
			{
				//MasterSetup.FrmGeneralledger frm = new MasterSetup.FrmGeneralledger();
				//frm._IsNew = 'Y';
				//frm.ShowDialog();
				//TxtPPuchaseReturnSubLedgerAc.Text = frm._NewLedger;
				//TxtPPuchaseReturnSubLedgerAc.Tag = frm._LedgerId;
			}
			else
			{
				_SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
				ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtIClosingStockBLSubAc, BtnIClosingStockBLSubAc, false);
			}
		}

		private void TxtIClosingStockPLSubAc_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == (Keys.N | Keys.Control))
			{
				//MasterSetup.FrmGeneralledger frm = new MasterSetup.FrmGeneralledger();
				//frm._IsNew = 'Y';
				//frm.ShowDialog();
				//TxtPPuchaseReturnSubLedgerAc.Text = frm._NewLedger;
				//TxtPPuchaseReturnSubLedgerAc.Tag = frm._LedgerId;
			}
			else
			{
				_SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
				ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtIClosingStockPLSubAc, BtnIClosingStockPLSubAc, false);
			}
		}

		private void TxtIOpeingStockPLSubAc_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == (Keys.N | Keys.Control))
			{
				//MasterSetup.FrmGeneralledger frm = new MasterSetup.FrmGeneralledger();
				//frm._IsNew = 'Y';
				//frm.ShowDialog();
				//TxtPPuchaseReturnSubLedgerAc.Text = frm._NewLedger;
				//TxtPPuchaseReturnSubLedgerAc.Tag = frm._LedgerId;
			}
			else
			{
				_SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
				ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtIOpeingStockPLSubAc, BtnIOpeingStockPLSubAc, false);
			}
		}

		private void TxtIProductionAc_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == (Keys.N | Keys.Control))
			{
				MasterSetup.FrmGeneralledger frm = new MasterSetup.FrmGeneralledger();
				frm._IsNew = 'Y';
				frm.ShowDialog();
				TxtIProductionAc.Text = frm._NewLedger;
				TxtIProductionAc.Tag = frm._LedgerId;
			}
			else
			{
				_SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
				ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtIProductionAc, BtnIProductionAc, false);
			}
		}

		private void TxtIClosingStockPLAc_KeyDown(object sender, KeyEventArgs e)
		{

			if (e.KeyData == (Keys.N | Keys.Control))
			{
			//	MasterSetup.FrmGeneralledger frm = new MasterSetup.FrmGeneralledger();
			//	frm._IsNew = 'Y';
			//	frm.ShowDialog();
			//	TxtPPuchaseReturnSubLedgerAc.Text = frm._NewLedger;
			//	TxtPPuchaseReturnSubLedgerAc.Tag = frm._LedgerId;
			}
			else
			{
				_SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
				ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtIClosingStockPLAc, BtnIClosingStockPLAc, false);
			}
		}



		#endregion

		#region ------------------Methods----------------------------
		private void SetData()
        {
            DataTable dt = objEntryControl.GetSystemSetting();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow ro in dt.Rows)
                {
					#region---------------General-------------------

					if (ro["DateType"] != DBNull.Value)
                    {
                        RBEnglishBase.Checked = (ro["DateType"].ToString() == "D") ? true : false;
                    }

                    if (ro["DateType"] != DBNull.Value)
                    {
                        RBMitiBase.Checked = (ro["DateType"].ToString() == "M") ? true : false;
                    }
                    if (ro["UDFSystem"] != DBNull.Value)
                    {
                        RBUDFYes.Checked = (Convert.ToInt32(ro["UDFSystem"].ToString()) == 1) ? true : false;
                    }

                    if (ro["UDFSystem"] != DBNull.Value)
                    {
                        RBUDFNo.Checked = (Convert.ToInt32(ro["UDFSystem"].ToString()) == 0) ? true : false;
                    }
                    if (ro["ConfirmSave"] != DBNull.Value)
                    {
                        ChkConfirmSave.Checked = (Convert.ToInt32(ro["ConfirmSave"].ToString()) == 1) ? true : false;
                    }
                    if (ro["ConfirmFormCancel"] != DBNull.Value)
                    {
                        ChkConfirmFormCancel.Checked = (Convert.ToInt32(ro["ConfirmFormCancel"].ToString()) == 1) ? true : false;
                    }
                    if (ro["ConfirmFormClear"] != DBNull.Value)
                    {
                        ChkConfirmFormClear.Checked =(Convert.ToInt32( ro["ConfirmFormClear"].ToString()) == 1) ? true : false;
                    }

                    if (ro["DefaultCurrencyId"] != DBNull.Value)
                    {
                        TxtDefaultCurrency.Tag = Convert.ToInt32(ro["DefaultCurrencyId"].ToString());
                    }

                    if (ro["DefaultCurrencyId"] != DBNull.Value)
                    {
                        TxtDefaultCurrency.Text = ro["DefaultCurrency"].ToString();
                    }
                    
                    if (ro["AmountFormate"] != DBNull.Value)
                    {
                        CmbAmountFormat.Text = ro["AmountFormate"].ToString();
                    }

                    if (ro["RateFormat"] != DBNull.Value)
                    {
                        CmbRateFormat.Text = ro["RateFormat"].ToString();
                    }

                    if (ro["QtyFormat"] != DBNull.Value)
                    {
                        CmbQuantityFormat.Text = ro["QtyFormat"].ToString();
                    }

                    if (ro["AltQtyFormat"] != DBNull.Value)
                    {
                        CmbAltQuantityFormat.Text = ro["AltQtyFormat"].ToString();
                    }

                    if (ro["CurrencyFormat"] != DBNull.Value)
                    {
                        CmbCurrencyFormat.Text = ro["CurrencyFormat"].ToString();
                    }

					if (ro["BranchOrCompanyUnitWise"] != DBNull.Value)
					{
						ChkBranchWise.Checked = (ro["BranchOrCompanyUnitWise"].ToString() == "Branch") ? true : false;
					}
					if (ro["BranchOrCompanyUnitWise"] != DBNull.Value)
					{
						ChkCompanyUnitWise.Checked = (ro["BranchOrCompanyUnitWise"].ToString() == "CompanyUnit") ? true : false;
					}
					#endregion

					#region---------Purchase-------------------
					if (ro["PBLedgerId"] != DBNull.Value)
					{
						TxtPPuchaseAc.Tag = Convert.ToInt32(ro["PBLedgerId"].ToString());
					}

					if (ro["PBLedgerId"] != DBNull.Value)
					{
						TxtPPuchaseAc.Text = ro["PBLedger"].ToString();
					}

					if (ro["PRLedgerId"] != DBNull.Value)
					{
						TxtPPuchaseReturnAc.Tag = Convert.ToInt32(ro["PRLedgerId"].ToString());
					}

					if (ro["PRLedgerId"] != DBNull.Value)
					{
						TxtPPuchaseReturnAc.Text = ro["PRLedger"].ToString();
					}

					if (ro["PBSubLedgerId"] != DBNull.Value)
					{
						TxtPPuchaseSubledgerAc.Tag = Convert.ToInt32(ro["PBSubLedgerId"].ToString());
					}

					if (ro["PBSubLedgerId"] != DBNull.Value)
					{
						TxtPPuchaseSubledgerAc.Text = ro["PBSubLedger"].ToString();
					}

					if (ro["PRSubLedgerId"] != DBNull.Value)
					{
						TxtPPuchaseReturnSubLedgerAc.Tag = Convert.ToInt32(ro["PRSubLedgerId"].ToString());
					}

					if (ro["PRSubLedgerId"] != DBNull.Value)
					{
						TxtPPuchaseReturnSubLedgerAc.Text = ro["PRSubLedger"].ToString();
					}

					if (ro["PBVatTermId"] != DBNull.Value)
					{
						TxtPVatTerm.Tag = Convert.ToInt32(ro["PBVatTermId"].ToString());
					}

					if (ro["PBVatTermId"] != DBNull.Value)
					{
						TxtPVatTerm.Text = ro["PBVatTerm"].ToString();
					}

					if (ro["PBProductDiscountTermId"] != DBNull.Value)
					{
						TxtPPDiscountTerm.Tag = Convert.ToInt32(ro["PBProductDiscountTermId"].ToString());
					}

					if (ro["PBProductDiscountTermId"] != DBNull.Value)
					{
						TxtPPDiscountTerm.Text = ro["PBProductDiscountTerm"].ToString();
					}

					if (ro["PBBillDiscountTermId"] != DBNull.Value)
					{
						TxtPBDiscountTerm.Tag = Convert.ToInt32(ro["PBBillDiscountTermId"].ToString());
					}

					if (ro["PBBillDiscountTermId"] != DBNull.Value)
					{
						TxtPBDiscountTerm.Text = ro["PBBillDiscountTerm"].ToString();
					}

					if (ro["InterBranchPurchaseLedgerId"] != DBNull.Value)
					{
						TxtPInterBranchAc.Tag = Convert.ToInt32(ro["InterBranchPurchaseLedgerId"].ToString());
					}

					if (ro["InterBranchPurchaseLedgerId"] != DBNull.Value)
					{
						TxtPInterBranchAc.Text = ro["InterBranchPurchase"].ToString();
					}

					#endregion

					#region----------Sales-----------------
					if (ro["SBLedgerId"] != DBNull.Value)
                    {
                        TxtSSalesAc.Tag = Convert.ToInt32(ro["SBLedgerId"].ToString());
                    }

                    if (ro["SBLedgerId"] != DBNull.Value)
                    {
                        TxtSSalesAc.Text = ro["SalesBillLedger"].ToString();
                    }

                    if (ro["SRLedgerId"] != DBNull.Value)
                    {
                        TxtSSalesReturnAc.Tag = Convert.ToInt32(ro["SRLedgerId"].ToString());
                    }

                    if (ro["SRLedgerId"] != DBNull.Value)
                    {
                        TxtSSalesReturnAc.Text = ro["SalesReturnLedger"].ToString();
                    }

                    if (ro["SBSubLedgerId"] != DBNull.Value)
                    {
                        TxtSSalesSubledgerAc.Tag = Convert.ToInt32(ro["SBSubLedgerId"].ToString());
                    }

                    if (ro["SBSubLedgerId"] != DBNull.Value)
                    {
                        TxtSSalesSubledgerAc.Text = ro["SalesBillSubLedger"].ToString();
                    }

                    if (ro["SRSubLedgerId"] != DBNull.Value)
                    {
                        TxtSSalesReturnSubledgerAc.Tag = Convert.ToInt32(ro["SRSubLedgerId"].ToString());
                    }

                    if (ro["SRSubLedgerId"] != DBNull.Value)
                    {
                        TxtSSalesReturnSubledgerAc.Text = ro["SalesReturnSubLedger"].ToString();
                    }

					if (ro["InterBranchSalesLedgerId"] != DBNull.Value)
					{
						TxtSInterBranchAc.Tag = ro["InterBranchSalesLedgerId"].ToString();
					}
					if (ro["InterBranchSalesLedgerId"] != DBNull.Value)
					{
						TxtSInterBranchAc.Text = ro["InterBranchSales"].ToString();
					}
					
					if (ro["SBVatTermId"] != DBNull.Value)
                    {
                        TxtSVATTerm.Tag = Convert.ToInt32(ro["SBVatTermId"].ToString());
                    }

                    if (ro["SBVatTermId"] != DBNull.Value)
                    {
                        TxtSVATTerm.Text = ro["SBVatTerm"].ToString();
                    }

                    if (ro["SBSpecialDiscountTermId"] != DBNull.Value)
                    {
                        TxtSProductSplDiscTerm.Tag = Convert.ToInt32(ro["SBSpecialDiscountTermId"].ToString());
                    }

                    if (ro["SBSpecialDiscountTermId"] != DBNull.Value)
                    {
                        TxtSProductSplDiscTerm.Text = ro["SBSpecialDiscountTerm"].ToString();
                    }

                    if (ro["SBServiceChargeTermId"] != DBNull.Value)
                    {
                        TxtSServiceChargeTerm.Tag = Convert.ToInt32(ro["SBServiceChargeTermId"].ToString());
                    }

                    if (ro["SBServiceChargeTermId"] != DBNull.Value)
                    {
                        TxtSServiceChargeTerm.Text = ro["SBServiceChargeTerm"].ToString();
                    }

                    if (ro["SBProductDiscountTermId"] != DBNull.Value)
                    {
                        TxtSProductDiscTerm.Tag = Convert.ToInt32(ro["SBProductDiscountTermId"].ToString());
                    }

                    if (ro["SBProductDiscountTermId"] != DBNull.Value)
                    {
                        TxtSProductDiscTerm.Text = ro["SBProductDiscountTerm"].ToString();
                    }

                    if (ro["SBBillDiscountTermId"] != DBNull.Value)
                    {
                        TxtSBillDiscTerm.Tag = Convert.ToInt32(ro["SBBillDiscountTermId"].ToString());
                    }

                    if (ro["SBBillDiscountTermId"] != DBNull.Value)
                    {
                        TxtSBillDiscTerm.Text = ro["SBBillDiscountTerm"].ToString();
                    }
                  

					if (ro["DefaultPOSDocNumberingId"] != DBNull.Value)
					{
						TxtPosDocumentNumber.Tag= ro["DefaultPOSDocNumberingId"].ToString();
					}
					if (ro["DefaultPOSDocNumberingId"] != DBNull.Value)
					{
						TxtPosDocumentNumber.Text = ro["DefaultPOSDocNumbering"].ToString();
					}

					if (ro["DefaultOrderDocNumberingId"] != DBNull.Value)
					{
						TxtOrderDocumentNumber.Tag = ro["DefaultPOSDocNumberingId"].ToString();
					}
					if (ro["DefaultOrderDocNumberingId"] != DBNull.Value)
					{
						TxtOrderDocumentNumber.Text = ro["DefaultOrderDocNumbering"].ToString();
					}

				    TxtAbbreivateAmount.Text =ClsGlobal.DecimalFormate(Convert.ToDecimal( ro["AbbreviatedAmount"].ToString()),1,ClsGlobal._AmountDecimalFormat ).ToString ();

					#endregion
					#region----------Inventory-----------------
					if (ro["OpeningStockLedgerId"] != DBNull.Value)
					{
						TxtIOpeingStockPLAc.Tag = Convert.ToInt32(ro["OpeningStockLedgerId"].ToString());
					}

					if (ro["OpeningStockLedgerId"] != DBNull.Value)
					{
						TxtIOpeingStockPLAc.Text = ro["OpeningStockLedger"].ToString();
					}

					if (ro["ClosingStockLedgerId"] != DBNull.Value)
					{
						TxtIClosingStockPLAc.Tag = Convert.ToInt32(ro["ClosingStockLedgerId"].ToString());
					}

					if (ro["ClosingStockLedgerId"] != DBNull.Value)
					{
						TxtIClosingStockPLAc.Text = ro["ClosingStockLedger"].ToString();
					}

					if (ro["ClosingStockLedgerBSId"] != DBNull.Value)
					{
						TxtIClosingStockBLAc.Tag = Convert.ToInt32(ro["ClosingStockLedgerBSId"].ToString());
					}

					if (ro["ClosingStockLedgerBSId"] != DBNull.Value)
					{
						TxtIClosingStockBLAc.Text = ro["CLosingStockLedgerBS"].ToString();
					}
					
					if (ro["OpeningStockSubLedgerId"] != DBNull.Value)
					{
						TxtIOpeingStockPLSubAc.Tag = Convert.ToInt32(ro["OpeningStockSubLedgerId"].ToString());
					}

					if (ro["OpeningStockSubLedgerId"] != DBNull.Value)
					{
						TxtIOpeingStockPLSubAc.Text = ro["OpeningStockSubLedger"].ToString();
					}

					if (ro["ClosingStockSubLedgerId"] != DBNull.Value)
					{
						TxtIClosingStockPLSubAc.Tag = Convert.ToInt32(ro["ClosingStockSubLedgerId"].ToString());
					}

					if (ro["ClosingStockSubLedgerId"] != DBNull.Value)
					{
						TxtIClosingStockPLSubAc.Text = ro["ClosingStockSubLedger"].ToString();
					}

					if (ro["ClosingStockSubLedgerBSId"] != DBNull.Value)
					{
						TxtIClosingStockBLSubAc.Tag = Convert.ToInt32(ro["ClosingStockSubLedgerBSId"].ToString());
					}

					if (ro["ClosingStockSubLedgerBSId"] != DBNull.Value)
					{
						TxtIClosingStockBLSubAc.Text = ro["ClosingStockSubLedgerBS"].ToString();
					}

					if (ro["ProductionLedgerId"] != DBNull.Value)
					{
						TxtIProductionAc.Tag = Convert.ToInt32(ro["ProductionLedgerId"].ToString());
					}

					if (ro["ProductionLedgerId"] != DBNull.Value)
					{
						TxtIProductionAc.Text = ro["ProductionLedger"].ToString();
					}

					if (ro["NegativeStockWarning"] != DBNull.Value)
					{
						if (ro["NegativeStockWarning"].ToString() == "I")
							CmbNegativeWarning.SelectedIndex = 0;
						else if (ro["NegativeStockWarning"].ToString() == "W")
							CmbNegativeWarning.SelectedIndex = 1;
						else if (ro["NegativeStockWarning"].ToString() == "B")
							CmbNegativeWarning.SelectedIndex = 2;
						else
							CmbNegativeWarning.SelectedText = "";
					}




					#endregion
					#region---------------Finance----------
					if (ro["PLLedgerId"] != DBNull.Value)
					{
						TxtFProfitAndLoss.Tag = Convert.ToInt32(ro["PLLedgerId"].ToString());
					}

					if (ro["PLLedgerId"] != DBNull.Value)
					{
						TxtFProfitAndLoss.Text = ro["PLLedger"].ToString();
					}

					if (ro["CashLedgerId"] != DBNull.Value)
					{
						TxtFCashAc.Tag = Convert.ToInt32(ro["CashLedgerId"].ToString());
					}

					if (ro["CashLedgerId"] != DBNull.Value)
					{
						TxtFCashAc.Text = ro["CashLedger"].ToString();
					}

					if (ro["CardLedgerId"] != DBNull.Value)
					{
						TxtFCardAc.Tag = Convert.ToInt32(ro["CardLedgerId"].ToString());
					}

					if (ro["CashLedgerId"] != DBNull.Value)
					{
						TxtFCardAc.Text = ro["CardLedger"].ToString();
					}

					if (ro["VatLedgerId"] != DBNull.Value)
					{
						TxtFVATAc.Tag = Convert.ToInt32(ro["VatLedgerId"].ToString());
					}

					if (ro["VatLedgerId"] != DBNull.Value)
					{
						TxtFVATAc.Text = ro["VatLedger"].ToString();
					}

					if (ro["PDCBankLedgerId"] != DBNull.Value)
					{
						TxtFPDCBank.Tag = Convert.ToInt32(ro["PDCBankLedgerId"].ToString());
					}

					if (ro["PDCBankLedgerId"] != DBNull.Value)
					{
						TxtFPDCBank.Text = ro["PDCBankLedger"].ToString();
					}

					if (ro["TDSLedgerId"] != DBNull.Value)
					{
						TxtFTDSAc.Tag = Convert.ToInt32(ro["TDSLedgerId"].ToString());
					}

					if (ro["TDSLedgerId"] != DBNull.Value)
					{
						TxtFTDSAc.Text = ro["TDSLedger"].ToString();
					}

					if (ro["SecurityDepositLedgerId"] != DBNull.Value)
					{
						TxtFSecurityDepositAc.Tag = Convert.ToInt32(ro["SecurityDepositLedgerId"].ToString());
					}

					if (ro["SecurityDepositLedgerId"] != DBNull.Value)
					{
						TxtFSecurityDepositAc.Text = ro["SecurityDepositLedger"].ToString();
					}

					if (ro["FineAndPenaltyLedgerId"] != DBNull.Value)
					{
						TxtFFineAndPenaltyAc.Tag = Convert.ToInt32(ro["FineAndPenaltyLedgerId"].ToString());
					}

					if (ro["FineAndPenaltyLedgerId"] != DBNull.Value)
					{
						TxtFFineAndPenaltyAc.Text = ro["FineAndPenaltyLedger"].ToString();
					}

					TxtFTDS.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(ro["TDSPercent"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
					TxtFSecurityDeposit.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(ro["SecurityDepositPercent"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
					TxtFFineAndPenalty.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(ro["FineAndPenaltyPercent"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();


					#endregion
				}
			}
        }

        #endregion
    }
}