using DataAccessLayer.Interface.SystemSetting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccessLayer.SystemSetting
{

    public class ClsEntryControl : IEntryControl
    {
        ActiveDataAccess.ActiveDataAccess DAL;
        public SystemControlView SystemControlModel { get; set; }
        public List<EntryControlViewModel> EntryControl { get; set; }

        public ClsEntryControl()
        {
            DAL = new ActiveDataAccess.ActiveDataAccess(Database.DBConnection);
            SystemControlModel = new SystemControlView();
            EntryControl = new List<EntryControlViewModel>();
        }

        public void GetEntryControl(string EntryModule)
        {
            EntryControlViewModel EntryControls = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from Erp.EntryControl");
            if (!string.IsNullOrEmpty(EntryModule)) strSql.Append(" WHERE EntryModule='" + EntryModule + "'");
            DataTable dt = DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow ro in dt.Rows)
                {
                    EntryControls = new EntryControlViewModel();
                    if (ro["EntryModule"] != DBNull.Value) EntryControls.EntryModule = ro["EntryModule"].ToString();
                    if (ro["ControlName"] != DBNull.Value) EntryControls.ControlName = ro["ControlName"].ToString();
                    if (ro["ControlValue"] != DBNull.Value) EntryControls.ControlValue = ro["ControlValue"].ToString();
                    if (ro["MandatoryOpt"] != DBNull.Value) EntryControls.MandatoryOpt = ro["MandatoryOpt"].ToString();
                    this.EntryControl.Add(EntryControls);
                }
            }
        }

        public void SaveEntryControl()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE ERP.SystemSetting set  \n");
            strSql.Append("[DateType] = '" + SystemControlModel.DateType.Trim() + "', \n");
            strSql.Append("[UDFSystem] = '" + SystemControlModel.UDFSystem + "', \n");
            strSql.Append("[ConfirmSave] = '" + SystemControlModel.ConfirmSave + "', \n");
            strSql.Append("[ConfirmFormCancel] = '" + SystemControlModel.ConfirmFormCancel + "', \n");
            strSql.Append("[ConfirmFormClear] = '" + SystemControlModel.ConfirmFormClear + "', \n");
            strSql.Append("[DefaultCurrencyId] = " + ((SystemControlModel.DefaultCurrencyId == 0) ? "null" : "'" + SystemControlModel.DefaultCurrencyId + "'") + ", \n");
            strSql.Append("[BackupSchIntvDays] = '" + SystemControlModel.BackupSchIntvDays + "', \n");
            strSql.Append("[BackupPath] = '" + SystemControlModel.BackupPath.Trim() + "',\n");
            strSql.Append("[PLLedgerId] = " + ((SystemControlModel.PLLedgerId == 0) ? "null" : "'" + SystemControlModel.PLLedgerId + "'") + ", \n");
            strSql.Append("[CashLedgerId] = " + ((SystemControlModel.CashLedgerId == 0) ? "null" : "'" + SystemControlModel.CashLedgerId + "'") + ",\n");
            strSql.Append("[CardLedgerId] = " + ((SystemControlModel.CardLedgerId == 0) ? "null" : "'" + SystemControlModel.CardLedgerId + "'") + ",\n");
            strSql.Append("[VatLedgerId] = " + ((SystemControlModel.VatLedgerId == 0) ? "null" : "'" + SystemControlModel.VatLedgerId + "'") + ",\n");
            strSql.Append("[PDCBankLedgerId] = " + ((SystemControlModel.PDCBankLedgerId == 0) ? "null" : "'" + SystemControlModel.PDCBankLedgerId + "'") + ",\n");
            strSql.Append("[AmountFormate] = '" + SystemControlModel.AmountFormate.Trim() + "', \n");
            strSql.Append("[RateFormat] = '" + SystemControlModel.RateFormat.Trim() + "',\n");
            strSql.Append("[QtyFormat] = '" + SystemControlModel.QtyFormat.Trim() + "',\n");
            strSql.Append("[AltQtyFormat] = '" + SystemControlModel.AltQtyFormat.Trim() + "', \n");
            strSql.Append("[CurrencyFormat] = '" + SystemControlModel.CurrencyFormat.Trim() + "',\n");
            strSql.Append("[FontName] = '" + SystemControlModel.FontName.Trim() + "', \n");
            strSql.Append("[FontSize] = '" + SystemControlModel.FontSize + "',\n");
            strSql.Append("[PaperSize] = '" + SystemControlModel.PaperSize.Trim() + "', \n");
            strSql.Append("[ReportFontStyle] = '" + SystemControlModel.ReportFontStyle.Trim() + "', \n");
            strSql.Append("[PrintingDateTime] = '" + SystemControlModel.PrintingDateTime + "',\n");
            strSql.Append("[PBLedgerId] = " + ((SystemControlModel.PBLedgerId == 0) ? "null" : "'" + SystemControlModel.PBLedgerId + "'") + ",\n");
            strSql.Append("[PRLedgerId] = " + ((SystemControlModel.PRLedgerId == 0) ? "null" : "'" + SystemControlModel.PRLedgerId + "'") + ",\n");
            strSql.Append("[PBSubLedgerId] = " + ((SystemControlModel.PBSubLedgerId == 0) ? "null" : "'" + SystemControlModel.PBSubLedgerId + "'") + ",\n");
            strSql.Append("[PRSubLedgerId] = " + ((SystemControlModel.PRSubLedgerId == 0) ? "null" : "'" + SystemControlModel.PRSubLedgerId + "'") + ",\n");
            strSql.Append("[PBVatTermId] = " + ((SystemControlModel.PBVatTermId == 0) ? "null" : "'" + SystemControlModel.PBVatTermId + "'") + ",\n");
            strSql.Append("[PABVatTermId] = " + ((SystemControlModel.PABVatTermId == 0) ? "null" : "'" + SystemControlModel.PABVatTermId + "'") + ", \n");
            strSql.Append("[PBProductDiscountTermId] = " + ((SystemControlModel.PBProductDiscountTermId == 0) ? "null" : "'" + SystemControlModel.PBProductDiscountTermId + "'") + ",\n");
            strSql.Append("[PBBillDiscountTermId] = " + ((SystemControlModel.PBBillDiscountTermId == 0) ? "null" : "'" + SystemControlModel.PBBillDiscountTermId + "'") + ",\n");
            strSql.Append("[PBCreditBalanceWarning] = '" + SystemControlModel.PBCreditBalanceWarning.Trim() + "',\n");
            strSql.Append("[PBCreditDaysWarning] = '" + SystemControlModel.PBCreditDaysWarning.Trim() + "',\n");
            strSql.Append("[PBCarryRate] = '" + SystemControlModel.PBCarryRate + "',\n");
            strSql.Append("[PBLastRate] = '" + SystemControlModel.PBLastRate + "',\n");
            strSql.Append("[PBBatchRate] = '" + SystemControlModel.PBBatchRate + "', \n");
            strSql.Append("[PBGrpWiseBilling] = '" + SystemControlModel.PBGrpWiseBilling + "',   \n");
            strSql.Append("[PBAdvancePayment] = '" + SystemControlModel.PBAdvancePayment + "',   \n");
            strSql.Append("[SBLedgerId] = " + ((SystemControlModel.SBLedgerId == 0) ? "null" : "'" + SystemControlModel.SBLedgerId + "'") + ",\n");
            strSql.Append("[SRLedgerId] = " + ((SystemControlModel.SRLedgerId == 0) ? "null" : "'" + SystemControlModel.SRLedgerId + "'") + ",\n");
            strSql.Append("[SBSubLedgerId] = " + ((SystemControlModel.SBSubLedgerId == 0) ? "null" : "'" + SystemControlModel.SBSubLedgerId + "'") + ",\n");
            strSql.Append("[SRSubLedgerId] = " + ((SystemControlModel.SRSubLedgerId == 0) ? "null" : "'" + SystemControlModel.SRSubLedgerId + "'") + ",\n");
            strSql.Append("[SBVatTermId] = " + ((SystemControlModel.SBVatTermId == 0) ? "null" : "'" + SystemControlModel.SBVatTermId + "'") + ", \n");
            strSql.Append("[SBProductDiscountTermId] = " + ((SystemControlModel.SBProductDiscountTermId == 0) ? "null" : "'" + SystemControlModel.SBProductDiscountTermId + "'") + ",\n");
            strSql.Append("[SBBillDiscountTermId] = " + ((SystemControlModel.SBBillDiscountTermId == 0) ? "null" : "'" + SystemControlModel.SBBillDiscountTermId + "'") + ",\n");
            strSql.Append("[SBSpecialDiscountTermId] = " + ((SystemControlModel.SBSpecialDiscountTermId == 0) ? "null" : "'" + SystemControlModel.SBSpecialDiscountTermId + "'") + ",\n");
            strSql.Append("[SBServiceChargeTermId] = " + ((SystemControlModel.SBServiceChargeTermId == 0) ? "null" : "'" + SystemControlModel.SBServiceChargeTermId + "'") + ", \n");
            strSql.Append("[SBCreditBalanceWarning] = '" + SystemControlModel.SBCreditBalanceWarning.Trim() + "',     \n");
            strSql.Append("[SBCreditDaysWarning] = '" + SystemControlModel.SBCreditDaysWarning.Trim() + "',\n");
            strSql.Append("[SBChangeRate] = '" + SystemControlModel.SBChangeRate + "', \n");
            strSql.Append("[SBLastRate] = '" + SystemControlModel.SBLastRate + "',\n");
            strSql.Append("[SBCarryRate] = '" + SystemControlModel.SBCarryRate + "', \n");
            strSql.Append("[DefaultInvoicePrintDesignId] = " + ((SystemControlModel.DefaultInvoicePrintDesignId == 0) ? "null" : "'" + SystemControlModel.DefaultInvoicePrintDesignId + "'") + ", \n");
            strSql.Append("[DefaultPOSDocNumberingId] = " + ((SystemControlModel.DefaultPOSDocNumberingId == 0) ? "null" : "'" + SystemControlModel.DefaultPOSDocNumberingId + "'") + ", \n");
            strSql.Append("[DefaultOrderPrintDesignId] = " + ((SystemControlModel.DefaultOrderPrintDesignId == 0) ? "null" : "'" + SystemControlModel.DefaultOrderPrintDesignId + "'") + ", \n");
            strSql.Append("[DefaultOrderDocNumberingId] = " + ((SystemControlModel.DefaultOrderDocNumberingId == 0) ? "null" : "'" + SystemControlModel.DefaultOrderDocNumberingId + "'") + ", \n");
            strSql.Append("[StockValueInSalesReturn] = '" + SystemControlModel.StockValueInSalesReturn + "',\n");
            strSql.Append("[AvailableStock] = '" + SystemControlModel.AvailableStock + "',\n");
            strSql.Append("[SBGrpWiseBilling] = '" + SystemControlModel.SBGrpWiseBilling + "',\n");
            strSql.Append("[OpeningStockLedgerId] = " + ((SystemControlModel.OpeningStockLedgerId == 0) ? "null" : "'" + SystemControlModel.OpeningStockLedgerId + "'") + ", \n");
            strSql.Append("[ClosingStockLedgerId] = " + ((SystemControlModel.ClosingStockLedgerId == 0) ? "null" : "'" + SystemControlModel.ClosingStockLedgerId + "'") + ", \n");
			strSql.Append("[ClosingStockLedgerBSId] = " + ((SystemControlModel.ClosingStockLedgerBSId == 0) ? "null" : "'" + SystemControlModel.ClosingStockLedgerBSId + "'") + ", \n");
			strSql.Append("[ClosingStockSubLedgerId] = " + ((SystemControlModel.ClosingStockSubLedgerId == 0) ? "null" : "'" + SystemControlModel.ClosingStockSubLedgerId + "'") + ", \n");
			strSql.Append("[OpeningStockSubLedgerId] = " + ((SystemControlModel.OpeningStockSubLedgerId == 0) ? "null" : "'" + SystemControlModel.OpeningStockSubLedgerId + "'") + ", \n");
			strSql.Append("[ClosingStockSubLedgerBSId] = " + ((SystemControlModel.ClosingStockSubLedgerBSId == 0) ? "null" : "'" + SystemControlModel.ClosingStockSubLedgerBSId + "'") + ", \n");
			strSql.Append("[StockInHandLedgerId] = " + ((SystemControlModel.StockInHandLedgerId == 0) ? "null" : "'" + SystemControlModel.StockInHandLedgerId + "'") + ", \n");
            strSql.Append("[NegativeStockWarning] = '" + SystemControlModel.NegativeStockWarning + "',   \n");
            strSql.Append("[AltQtyAlteration] = '" + SystemControlModel.AltQtyAlteration + "',    \n");
            strSql.Append("[AlterationPart] = '" + SystemControlModel.AlterationPart + "', \n");
            strSql.Append("[CarryBatchQty] = '" + SystemControlModel.CarryBatchQty + "', \n");
            strSql.Append("[BreakupQty] = '" + SystemControlModel.BreakupQty + "', \n");
            strSql.Append("[MfgDate] = '" + SystemControlModel.MfgDate + "',   \n");
            strSql.Append("[ExpDate] = '" + SystemControlModel.ExpDate + "', \n");
            strSql.Append("[MfgDateValidation] = '" + SystemControlModel.MfgDateValidation + "', \n");
            strSql.Append("[ExpDateValidation] = '" + SystemControlModel.ExpDateValidation + "', \n");
            strSql.Append("[FreeQty] = '" + SystemControlModel.FreeQty + "', \n");
            strSql.Append("[ExtraFreeQty] = '" + SystemControlModel.ExtraFreeQty + "',\n");
            strSql.Append("[IGodownWiseFilter] = '" + SystemControlModel.IGodownWiseFilter + "', \n");
            strSql.Append("[SalaryLedgerId] = " + ((SystemControlModel.SalaryLedgerId == 0) ? "null" : "'" + SystemControlModel.SalaryLedgerId + "'") + ", \n");
            strSql.Append("[TDSLedgerId] = " + ((SystemControlModel.TDSLedgerId == 0) ? "null" : "'" + SystemControlModel.TDSLedgerId + "'") + ",\n");
            strSql.Append("[SecurityDepositLedgerId] = " + ((SystemControlModel.SecurityDepositLedgerId == 0) ? "null" : "'" + SystemControlModel.SecurityDepositLedgerId + "'") + ", \n");
            strSql.Append("[BranchOrCompanyUnitWise] ='" + SystemControlModel.BranchOrCompanyUnitWise.Trim() + "',\n");
            strSql.Append("[CompanyPrintName] = '" + SystemControlModel.CompanyPrintName.Trim() + "',\n");         
            strSql.Append("[InterBranchPurchaseLedgerId] = " + ((SystemControlModel.InterBranchPurchase == 0) ? "null" : "'" + SystemControlModel.InterBranchPurchase + "'") + ",\n");
            strSql.Append("[InterBranchSalesLedgerId] = " + ((SystemControlModel.InterBranchSales == 0) ? "null" : "'" + SystemControlModel.InterBranchSales + "'") + ", \n");
            strSql.Append("[Gadget] = '" + SystemControlModel.Gadget.Trim() + "',\n");
			strSql.Append("[AbbreviatedAmount] = '" + SystemControlModel.AbbreviatedAmount + "' ,\n");
			strSql.Append("[FineAndPenaltyLedgerId] =  " + ((SystemControlModel.FineAndPenaltyLedgerId == 0) ? "null" : "'" + SystemControlModel.FineAndPenaltyLedgerId + "'") + ",\n");  
			strSql.Append("[TDSPercent] = '" + SystemControlModel.TDSPercent + "',\n");
			strSql.Append("[SecurityDepositPercent] = '" + SystemControlModel.SecurityDepositPercent + "',\n");
			strSql.Append("[FineAndPenaltyPercent] = '" + SystemControlModel.FineAndPenaltyPercent + "',\n");
			strSql.Append("[ProductionLedgerId] =  " + ((SystemControlModel.ProductionLedgerId == 0) ? "null" : "'" + SystemControlModel.ProductionLedgerId + "'") + "\n");

			strSql.Append("DELETE FROM ERP.EntryControl \n");
            for (int i = 0; i < EntryControl.Count; i++)
            {
                strSql.Append("INSERT INTO ERP.EntryControl \n");
                strSql.Append("SELECT '" + EntryControl[i].EntryModule.ToString() + "','" + EntryControl[i].ControlName.ToString() + "','" + EntryControl[i].ControlValue.ToString() + "','" + EntryControl[i].MandatoryOpt.ToString() + "' \n");
            }
            DAL.ExecuteNonQuery(CommandType.Text, strSql.ToString());
            EntryControl.Clear();
        }

        public DataTable GetSystemSetting()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select SS.*,GLSBL.GlDesc AS SalesBillLedger,GLSRL.GlDesc as SalesReturnLedger, \n");
            strSql.Append("GLSBSL.SubledgerDesc as SalesBillSubLedger,GLSRSL.SubledgerDesc as SalesReturnSubLedger,\n");
            strSql.Append("GLIBS.GlDesc as InterBranchSales,GLIBP.GlDesc as InterBranchPurchase,\n");
            strSql.Append("GLPBSL.SubledgerDesc as PBSubLedger,GLPRSL.SubledgerDesc as PRSubLedger,\n");
            strSql.Append("GLPBL.GlDesc as PBLedger,GLPRL.GlDesc as PRLedger,\n");
            strSql.Append("GLPLL.GlDesc as PLLedger,GLVATL.GlDesc as VatLedger,\n");
            strSql.Append("GLPDCL.GlDesc as PDCBankLedger,GLCBL.GlDesc as CashLedger,GLCardL.GlDesc as CardLedger,\n");

            strSql.Append("GLOSL.GlDesc as OpeningStockLedger,GLCSL.GlDesc as ClosingStockLedger,\n");
			strSql.Append("GLCSLBS.GlDesc as CLosingStockLedgerBS,GLCSLSUb.SubledgerDesc as ClosingStockSubledger,\n");
			strSql.Append("GLOSLSub.SubLedgerDesc as OpeningStockSubLedger,GLCSLBSSub.SubLedgerDesc as ClosingStockSubLedgerBS,\n");

			strSql.Append("GLSINL.GlDesc as StockInHandLedger,\n");
            strSql.Append("GLSL.GlDesc as SalaryLedger,\n");
            strSql.Append("GLTDSL.GlDesc as TDSLedger,GLPFL.GlDesc as SecurityDepositLedger, \n");
            strSql.Append("SBBDT.TermDesc AS SBBillDiscountTerm,SBPDT.TermDesc AS SBProductDiscountTerm ,\n");
            strSql.Append("SBVT.TermDesc AS SBVatTerm,SBSDT.TermDesc AS SBSpecialDiscountTerm ,\n");
            strSql.Append("SBSCT.TermDesc AS SBServiceChargeTerm, PBVAT.TermDesc AS PBVatTerm, \n");
			strSql.Append("PBPDSC.TermDesc AS PBProductDiscountTerm, PBBDSC.TermDesc AS PBBillDiscountTerm, \n");

			strSql.Append("DN.DocDesc AS DefaultPOSDocNumbering,DNO.DocDesc AS DefaultOrderDocNumbering, CURR.CurrencyDesc AS DefaultCurrency, \n");
            strSql.Append(" GLFAP.GlDesc as FineAndPenaltyLedger,GLPRO.GlDesc as ProductionLedger from ERP.SystemSetting SS \n");
			strSql.Append("left join ERP.GeneralLedger GLSBL on SS.SBLedgerId = GLSBL.LedgerId \n");
			strSql.Append("left join ERP.GeneralLedger GLSRL on SS.SRLedgerId = GLSRL.LedgerId \n");
			strSql.Append("left join ERP.SubLedger GLSBSL on SS.SBSubLedgerId = GLSBSL.SubledgerId \n");
			strSql.Append("left join ERP.SubLedger GLSRSL on SS.SRSubLedgerId = GLSRSL.SubledgerId \n");
			strSql.Append("left join ERP.GeneralLedger GLIBS on SS.InterBranchSalesLedgerId = GLIBS.LedgerId \n");
			strSql.Append("left join ERP.GeneralLedger GLIBP on SS.InterBranchPurchaseLedgerId = GLIBP.LedgerId \n");
			strSql.Append("left join ERP.SubLedger GLPBSL on SS.PBSubLedgerId = GLPBSL.SubledgerId \n");
			strSql.Append("left join ERP.SubLedger GLPRSL on SS.PRSubLedgerId = GLPRSL.SubledgerId \n");
			strSql.Append("left join ERP.GeneralLedger GLPBL on SS.PBLedgerId = GLPBL.LedgerId \n");
			strSql.Append("left join ERP.GeneralLedger GLPRL on SS.PRLedgerId = GLPRL.LedgerId \n");
			strSql.Append("left join ERP.GeneralLedger GLPLL on SS.PLLedgerId = GLPLL.LedgerId \n");
			strSql.Append("left join ERP.GeneralLedger GLVATL on SS.VatLedgerId = GLVATL.LedgerId \n");
			strSql.Append("left join ERP.GeneralLedger GLPDCL on SS.PDCBankLedgerId = GLPDCL.LedgerId \n");
			strSql.Append("left join ERP.GeneralLedger GLCBL on SS.CashLedgerId = GLCBL.LedgerId \n");
			strSql.Append("left join ERP.GeneralLedger GLCardL on SS.CardLedgerId = GLCardL.LedgerId \n");

			strSql.Append("left join ERP.GeneralLedger GLOSL on SS.OpeningStockLedgerId = GLOSL.LedgerId \n");
			strSql.Append("left join ERP.GeneralLedger GLCSL on SS.ClosingStockLedgerId = GLCSL.LedgerId \n");
			strSql.Append("left join ERP.GeneralLedger GLCSLBS on SS.ClosingStockLedgerBSId = GLCSLBS.LedgerId \n");
			strSql.Append("left join ERP.SubLedger GLCSLSUb on SS.ClosingStockSubLedgerId = GLCSLSUb.SubledgerId \n");
			strSql.Append("left join ERP.SubLedger GLOSLSub on SS.OpeningStockSubLedgerId = GLOSLSub.SubledgerId \n");
			strSql.Append("left join ERP.SubLedger GLCSLBSSub on SS.ClosingStockSubLedgerBSId = GLCSLBSSub.SubledgerId \n");
			strSql.Append("left join ERP.GeneralLedger GLSINL on SS.[StockInHandLedgerId] = GLSINL.ledgerId \n");
			strSql.Append("left join ERP.GeneralLedger GLSL on SS.SalaryLedgerId = GLSL.LedgerId \n");
			strSql.Append("left join ERP.GeneralLedger GLTDSL on SS.TDSLedgerId = GLTDSL.LedgerId \n");
			strSql.Append("left join ERP.GeneralLedger GLPFL on SS.SecurityDepositLedgerId = GLPFL.LedgerId \n");
			strSql.Append("left join ERP.SalesBillingTerm SBBDT on SS.SBBillDiscountTermId = SBBDT.TermId \n");
			strSql.Append("left join ERP.SalesBillingTerm SBPDT on SS.SBProductDiscountTermId = SBPDT.TermId \n");
			strSql.Append("left join ERP.SalesBillingTerm SBVT on SS.SBVatTermId = SBVT.TermId \n");
			strSql.Append("left join ERP.SalesBillingTerm SBSDT on SS.SBSpecialDiscountTermId = SBSDT.TermId \n");
			strSql.Append("left join ERP.SalesBillingTerm SBSCT on SS.SBServiceChargeTermId = SBSCT.TermId \n");
			strSql.Append("left join ERP.PurchaseBillingTerm PBVAT on SS.PBVatTermId = PBVAT.TermId \n");
			strSql.Append("left join ERP.PurchaseBillingTerm PBPDSC on SS.PBProductDiscountTermId = PBPDSC.TermId  \n");
			strSql.Append("left join ERP.PurchaseBillingTerm PBBDSC on SS.PBBillDiscountTermId = PBBDSC.TermId  \n");

			strSql.Append("left join ERP.DocumentNumbering DN on SS.DefaultPOSDocNumberingId = DN.DocId \n");
			strSql.Append("left join ERP.DocumentNumbering DNO on SS.DefaultPOSDocNumberingId = DNO.DocId \n");
			strSql.Append("left join ERP.Currency CURR on SS.DefaultCurrencyId = CURR.CurrencyId \n");
			strSql.Append("left join ERP.GeneralLedger GLFAP on SS.FineAndPenaltyLedgerId = GLFAP.ledgerId \n");
			strSql.Append("left join ERP.GeneralLedger GLPRO on SS.ProductionLedgerId = GLPRO.ledgerId \n");

			return DAL.ExecuteDataset(CommandType.Text, strSql.ToString()).Tables[0];
        }
    }

    public class EntryControlViewModel
    {
        public string EntryModule { get; set; }
        public string ControlName { get; set; }
        public string ControlValue { get; set; }
        public string MandatoryOpt { get; set; }
    }
    public class SystemControlView
    {
        public string DateType { get; set; }
        public int UDFSystem { get; set; }       
        public int ConfirmSave { get; set; }
        public int ConfirmFormCancel { get; set; }
        public int ConfirmFormClear { get; set; } 
        public int DefaultCurrencyId { get; set; }
        public string DefaultPrinter { get; set; }
        public int BackupSchIntvDays { get; set; }
        public string BackupPath { get; set; }
        public int PLLedgerId { get; set; }
        public int CashLedgerId { get; set; }
        public int CardLedgerId { get; set; }
        public int VatLedgerId { get; set; }
        public int PDCBankLedgerId { get; set; }
        public bool FinNegBalance { get; set; }
        public string AmountFormate { get; set; }
        public string RateFormat { get; set; }
        public string QtyFormat { get; set; }
        public string AltQtyFormat { get; set; }
        public string CurrencyFormat { get; set; }
        public string FontName { get; set; }
        public decimal FontSize { get; set; }
        public string PaperSize { get; set; }
        public string ReportFontStyle { get; set; }
        public int PrintingDateTime { get; set; }
        public int PBLedgerId { get; set; }
        public int PRLedgerId { get; set; }
        public int PBSubLedgerId { get; set; }
        public int PRSubLedgerId { get; set; }
        public int PBVatTermId { get; set; }
        public int PABVatTermId { get; set; }
        public int PBProductDiscountTermId { get; set; }
        public int PBBillDiscountTermId { get; set; }
        public string PBCreditBalanceWarning { get; set; }
        public string PBCreditDaysWarning { get; set; }
        public int PBCarryRate { get; set; }
        public int PBLastRate { get; set; }
        public int PBBatchRate { get; set; }
        public int PBGrpWiseBilling { get; set; }
        public int PBAdvancePayment { get; set; }
        public int SBLedgerId { get; set; }
        public int SRLedgerId { get; set; }
        public int SBSubLedgerId { get; set; }
        public int SRSubLedgerId { get; set; }
        public int SBVatTermId { get; set; }
        public int SBProductDiscountTermId { get; set; }
        public int SBBillDiscountTermId { get; set; }
        public int SBSpecialDiscountTermId { get; set; }
        public int SBServiceChargeTermId { get; set; }
        public string SBCreditBalanceWarning { get; set; }
        public string SBCreditDaysWarning { get; set; }
        public int SBChangeRate { get; set; }
        public int SBLastRate { get; set; }
        public int SBCarryRate { get; set; }
        public int DefaultInvoicePrintDesignId { get; set; }
        public int DefaultPOSDocNumberingId { get; set; }
        public int DefaultOrderPrintDesignId { get; set; }
        public int DefaultOrderDocNumberingId { get; set; }
        public int StockValueInSalesReturn { get; set; }
        public int AvailableStock { get; set; }
        public int SBGrpWiseBilling { get; set; }
        public int OpeningStockLedgerId { get; set; }
        public int ClosingStockLedgerId { get; set; }
		public int ClosingStockLedgerBSId { get; set; }
		public int OpeningStockSubLedgerId { get; set; }
		public int ClosingStockSubLedgerId { get; set; }
		public int ClosingStockSubLedgerBSId { get; set; }
		public int StockInHandLedgerId { get; set; }
        public string NegativeStockWarning { get; set; }
        public int AltQtyAlteration { get; set; }
        public int AlterationPart { get; set; }
        public int CarryBatchQty { get; set; }
        public int BreakupQty { get; set; }
        public int MfgDate { get; set; }
        public int ExpDate { get; set; }
        public int MfgDateValidation { get; set; }
        public int ExpDateValidation { get; set; }
        public int FreeQty { get; set; }
        public int ExtraFreeQty { get; set; }
        public int IGodownWiseFilter { get; set; }
        public int SalaryLedgerId { get; set; }
        public int TDSLedgerId { get; set; }
        public int SecurityDepositLedgerId { get; set; }
        public string BranchOrCompanyUnitWise { get; set; }
        public string CompanyPrintName { get; set; }
        public string Gadget { get; set; }
        public int InterBranchPurchase { get; set; }
        public int InterBranchSales { get; set; }
		public decimal AbbreviatedAmount { get; set; }
		public int FineAndPenaltyLedgerId { get; set; }
		public decimal TDSPercent { get; set; }
		public decimal SecurityDepositPercent { get; set; }
		public decimal FineAndPenaltyPercent { get; set; }
		public decimal ProductionLedgerId { get; set; }
	}
}
