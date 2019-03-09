﻿using acmedesktop.Common;
using DataAccessLayer.Common;
using DataAccessLayer.DataTransaction;
using DataAccessLayer.DataTransaction.Sales;
using DataAccessLayer.Interface.DataTransaction;
using DataAccessLayer.Interface.DataTransaction.Sales;
using DataAccessLayer.Interface.MasterSetup;
using DataAccessLayer.MasterSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acmedesktop.DataTransaction.BillingTransaction
{
    public partial class POSBilling : Form
    {
        ClsDateMiti _objDate = new ClsDateMiti();
        ISalesInvoice _objSalesInvoice = new ClsSalesInvoice();
        ISalesBillingTerm _objSalesBillingTerm = new ClsSalesBillingTerm();
        IProduct _objProduct = new ClsProduct();
        IProductScheme _objScheme = new ClsProductScheme();
        string _SearchKey = "";
        string _Tag = "";
        bool isBillcancel = false;
        int _IsSaveAndPrint = 0;
        public POSBilling()
        {
            InitializeComponent();
        }

        private void POSBilling_Load(object sender, EventArgs e)
        {
            ClearFld();
            ControlEnableDisable(false, true);
            this.Text = "POS Billing [NEW]";
            _Tag = "NEW";
            TxtInvMiti.Text = _objDate.GetMiti(_objDate.GetServerDate());
            TxtInvDate.Text = _objDate.GetServerDate().ToShortDateString();
            Utility.GetVoucherNo2("Sales Invoice", TxtInvoiceNo, TxtProductCode, "NEW", _SearchKey,ClsGlobal.DefaultPOSDocNumberingId);
        }
        
        public void ControlEnableDisable(bool btn, bool fld)
        {
            BtnBillCancel.Enabled = fld;
            BtnPrint.Enabled = fld;
            BtnNew.Enabled = btn;
            BtnExit.Enabled = fld;

            TxtInvoiceNo.Enabled = false;
            Utility.EnableDesibleColor(TxtInvoiceNo, false);
            TxtInvMiti.Enabled = false;
            Utility.EnableDesibleDateColor(TxtInvMiti, false);
            TxtInvDate.Enabled = false;
            Utility.EnableDesibleDateColor(TxtInvDate, false);
            TxtMember.Enabled = fld;
            Utility.EnableDesibleColor(TxtMember, fld);
            BtnMemberSearch.Enabled = fld;
            ChkPrintTaxInvoice.Enabled = fld;
            TxtProductCode.Enabled = fld;
            Utility.EnableDesibleColor(TxtProductCode, fld);
            BtnProductSearch.Enabled = fld;
            TxtBillDiscPer.Enabled = false;
            Utility.EnableDesibleColor(TxtBillDiscPer, false);
            TxtBillDiscAmt.Enabled = false;
            Utility.EnableDesibleColor(TxtBillDiscAmt, false);
            TxtRemarks.Enabled = false;
            Utility.EnableDesibleColor(TxtRemarks, false);
            BtnCashPayment.Enabled = fld;
            BtnCardPayment.Enabled = fld;
            BtnCreditPayment.Enabled = fld;
            BtnCancel.Enabled = fld;
            btnOk.Visible = false;
            BtnRate.Enabled = false;
            BtnQty.Enabled = false;
            BtnDiscount.Enabled = false;
            Grid.Enabled = true;
            //TxtBillAmount.Enabled = false;
            if (TxtProductCode.Enabled == true)
                TxtProductCode.Focus();
        }
        private void ClearFld()
        {
            foreach (Control control in PanelContainer.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
            }
            TxtBillAmount.Text = "0.00";
            TxtBillDiscPer.Text = "0.00";
            TxtBillDiscAmt.Text = "0.00";
            lblTotalProductNetAmt.Text = "0.00";
            lblTotalProductTerm.Text = "0.00";
            lblTotalQty.Text = "0.00";
            lblTotalBasicAmt.Text = "0.00";
            lblBillTerm.Text = "0.00";
            lblTaxableAmount.Text = "0.00";
            lblTaxFreeAmount.Text = "0.00";
            _Tag = "NEW";
            Grid.Rows.Clear();
            Grid.Rows.Add();
        }

        private void LoadProduct(string pcode)
        {
            DataSet ds = _objProduct.GetDataProduct(Convert.ToInt32(pcode));
            DataTable dt = ds.Tables[0];
            DataGridViewRow ro = new DataGridViewRow();
            decimal salesrate = 0, basicamt = 0;
            ro = Grid.Rows[Grid.Rows.Count - 1];
            if (dt.Rows.Count > 0)
            {
                DataTable dtScheme = _objScheme.CurrentProductScheme(Convert.ToInt32(pcode), ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
                if (dtScheme.Rows.Count > 0)
                {
                    salesrate = Convert.ToDecimal(dtScheme.Rows[0]["SchemeRate"].ToString());
                }
                else if (ClsGlobal.BranchId == 0)
                {
                    salesrate = Convert.ToDecimal(dt.Rows[0]["SalesRate"].ToString());
                }
                else
                {
                    DataTable dtrate = _objProduct.ProductBranchRate(pcode.ToString(), ClsGlobal.BranchId.ToString());
                    salesrate = (dtrate.Rows.Count > 0) ? Convert.ToDecimal(dtrate.Rows[0]["ProductRate"].ToString()) : Convert.ToDecimal(dt.Rows[0]["SalesRate"].ToString());
                }

                DataTable dtProductDiscount, dtVat, dtBillDiscount;
                decimal billdiscountpercent = 0;

                dtProductDiscount = _objSalesBillingTerm.GetDataSalesBillingTerm(Convert.ToInt32(ClsGlobal.SBProductDiscountTermId));
                dtVat = _objSalesBillingTerm.GetDataSalesBillingTerm(Convert.ToInt32(ClsGlobal.SBVatTermId));
                dtBillDiscount = _objSalesBillingTerm.GetDataSalesBillingTerm(Convert.ToInt32(ClsGlobal.SBBillDiscountTermId));
                billdiscountpercent = Convert.ToDecimal(dtBillDiscount.Rows[0]["TermRate"].ToString());

                foreach (DataGridViewRow gro in Grid.Rows)
                {
                    if (Convert.ToInt32(gro.Cells["ProductId"].Value) == Convert.ToInt32(pcode))
                    {
                        gro.Cells["Qty"].Value = Convert.ToDecimal(gro.Cells["Qty"].Value) + 1;
                        gro.Cells["Rate"].Value = ClsGlobal.DecimalFormate(salesrate, 1, ClsGlobal._AmountDecimalFormat);
                        basicamt = Convert.ToDecimal(gro.Cells["Qty"].Value) * salesrate;
                        ro.Cells["DiscPercent"].Value = dtProductDiscount.Rows[0]["TermRate"].ToString();
                        ro.Cells["DiscAmount"].Value = (Convert.ToDecimal(dtProductDiscount.Rows[0]["TermRate"].ToString()) == 0) ? 0 : basicamt * (Convert.ToDecimal(dtProductDiscount.Rows[0]["TermRate"].ToString()) / 100);
                        ro.Cells["BillDisc"].Value = (billdiscountpercent == 0) ? 0 : billdiscountpercent;
                        ro.Cells["VatRate"].Value = dtVat.Rows[0]["TermRate"].ToString();
                        TermCalculation(gro.Index, basicamt, Convert.ToDecimal(ro.Cells["DiscPercent"].Value), Convert.ToDecimal(ro.Cells["BillDisc"].Value));
                        TxtProductCode.Clear();
                        TotalCalculate();
                        return;
                    }
                }
                ro.Cells["Qty"].Value = "1";
                ro.Cells["SNo"].Value = Grid.Rows.Count;
                ro.Cells["Particular"].Value = dt.Rows[0]["ProductDesc"].ToString();
                ro.Cells["ProductId"].Value = pcode;
                ro.Cells["GodownId"].Value = "";
                ro.Cells["Unit"].Value = dt.Rows[0]["ProductUnitShortName"].ToString();
                ro.Cells["ProductUnitId"].Value = dt.Rows[0]["ProductUnitId"].ToString();
                ro.Cells["Rate"].Value = ClsGlobal.DecimalFormate(salesrate, 1, ClsGlobal._AmountDecimalFormat);
                basicamt = Convert.ToDecimal(ro.Cells["Qty"].Value) * salesrate;
                ro.Cells["DiscPercent"].Value = dtProductDiscount.Rows[0]["TermRate"].ToString();
                ro.Cells["DiscAmount"].Value = (Convert.ToDecimal(dtProductDiscount.Rows[0]["TermRate"].ToString()) == 0) ? 0 : basicamt * (Convert.ToDecimal(dtProductDiscount.Rows[0]["TermRate"].ToString()) / 100);
                ro.Cells["BillDisc"].Value = (billdiscountpercent == 0) ? 0 : billdiscountpercent;
                ro.Cells["VatRate"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(dtVat.Rows[0]["TermRate"]), 1, ClsGlobal._AmountDecimalFormat).ToString();
                ro.Cells["IsTaxable"].Value = dt.Rows[0]["IsTaxable"].ToString();
                TermCalculation(ro.Index, basicamt, Convert.ToDecimal(ro.Cells["DiscPercent"].Value), Convert.ToDecimal(ro.Cells["BillDisc"].Value));
                Grid.Rows[Grid.Rows.Count - 1].Selected = true;
                TotalCalculate();
                Grid.Rows.Add();
                TxtProductCode.Clear();
            }
        }

        private void TermCalculation(int gridIndex, decimal basicAmount, decimal discountPercent, decimal BillDiscount)
        {
            decimal TermAmt = 0, discountAmt = 0, basicAmt = 0, netAmt = 0, taxableAmt = 0, billdisc = 0;
            if (discountPercent > 0 || BillDiscount > 0)
            {
                billdisc = (BillDiscount == 0) ? 0 : ((basicAmount) * (BillDiscount / 100));
                discountAmt = (discountPercent == 0) ? 0 : ((basicAmount - billdisc) * discountPercent / 100);
                taxableAmt = (basicAmount - (discountAmt + billdisc)) / Convert.ToDecimal(1.13);
                basicAmt = taxableAmt;
            }
            else
            {
                taxableAmt = Convert.ToDecimal(basicAmount) / Convert.ToDecimal(1.13);
                basicAmt = taxableAmt;
                discountAmt = 0;
            }

            TermAmt = basicAmount - taxableAmt;
            netAmt = basicAmount - discountAmt;
            Grid["BasicAmt", gridIndex].Value = ClsGlobal.DecimalFormate(basicAmount, 1, ClsGlobal._AmountDecimalFormat).ToString();
            Grid["DiscPercent", gridIndex].Value = ClsGlobal.DecimalFormate(discountPercent, 1, ClsGlobal._AmountDecimalFormat).ToString();
            Grid["DiscAmount", gridIndex].Value = ClsGlobal.DecimalFormate(discountAmt, 1, ClsGlobal._AmountDecimalFormat).ToString();
            Grid["BillDisc", gridIndex].Value = BillDiscount;
            Grid["NetAmt", gridIndex].Value = ClsGlobal.DecimalFormate(netAmt, 1, ClsGlobal._AmountDecimalFormat).ToString();
            Grid["TaxableAmt", gridIndex].Value = taxableAmt.ToString();
            Grid["TaxFreeAmount", gridIndex].Value = (Grid["IsTaxable", gridIndex].Value.ToString() == "true") ? "0" : ClsGlobal.DecimalFormate(netAmt, 1, ClsGlobal._AmountDecimalFormat).ToString();
            Grid["VatAmt", gridIndex].Value = (Convert.ToDecimal(taxableAmt) * Convert.ToDecimal(0.13)).ToString(); ;
        }

        private void TotalCalculate()
        {
            lblTotalQty.Text = "0.00";
            lblTotalBasicAmt.Text = "0.00";
            lblTotalProductTerm.Text = "0.00";
            lblTotalProductNetAmt.Text = "0.00";
            lblTaxFreeAmount.Text = "0.00";
            lblTaxableAmount.Text = "0.00";
            lblBillTerm.Text = "0.00";
            for (int i = 0; i < Grid.Rows.Count; i++)
            {
                decimal billDisc = 0;
                if (i < (Grid.Rows.Count - 1))
                    Grid["SNo", i].Value = i + 1;
                if (Grid["ProductId", i].Value != null)
                {
                    lblTotalQty.Text = (Convert.ToDecimal(lblTotalQty.Text) + Convert.ToDecimal(Grid["Qty", i].Value.ToString())).ToString();
                    if (Convert.ToDecimal(Grid["BillDisc", i].Value.ToString()) != 0)
                    {
                        billDisc = Convert.ToDecimal(Grid["NetAmt", i].Value.ToString()) * (Convert.ToDecimal(Grid["BillDisc", i].Value.ToString()) / 100);
                        lblTotalBasicAmt.Text = (Convert.ToDecimal(lblTotalBasicAmt.Text) + (Convert.ToDecimal(Grid["NetAmt", i].Value.ToString()) - billDisc) / Convert.ToDecimal(1.13)).ToString();
                    }
                    else
                    {
                        lblTotalBasicAmt.Text = (Convert.ToDecimal(lblTotalBasicAmt.Text) + (Convert.ToDecimal(Grid["NetAmt", i].Value.ToString()) / Convert.ToDecimal(1.13))).ToString();
                    }
                    if (Grid["IsTaxable", i].Value.ToString() == "True")
                    {
                        decimal TaxableValue = 0;
                        if (Convert.ToDecimal(TxtBillDiscAmt.Text) > 0)
                        {
                            lblTotalProductNetAmt.Text = (Convert.ToDecimal(lblTotalProductNetAmt.Text) + (Convert.ToDecimal(Grid["NetAmt", i].Value.ToString()) - billDisc) / Convert.ToDecimal(1.13)).ToString();
                            TaxableValue = (Convert.ToDecimal(Grid["NetAmt", i].Value.ToString()) - billDisc) / Convert.ToDecimal(1.13);
                            lblTaxableAmount.Text = (Convert.ToDecimal(lblTaxableAmount.Text) + TaxableValue).ToString();
                            lblTotalProductTerm.Text = (Convert.ToDecimal(lblTotalProductTerm.Text) + (TaxableValue * Convert.ToDecimal(0.13))).ToString();
                        }
                        else
                        {
                            lblTotalProductNetAmt.Text = (Convert.ToDecimal(lblTotalProductNetAmt.Text) + Convert.ToDecimal(Grid["NetAmt", i].Value.ToString())).ToString();
                            lblTaxableAmount.Text = (Convert.ToDecimal(lblTaxableAmount.Text) + Convert.ToDecimal(Grid["TaxableAmt", i].Value.ToString())).ToString();
                            lblTotalProductTerm.Text = (Convert.ToDecimal(lblTotalProductTerm.Text) + Convert.ToDecimal(Grid["VatAmt", i].Value.ToString())).ToString();
                        }
                    }
                    else
                    {
                        lblTaxFreeAmount.Text = (Convert.ToDecimal(lblTaxFreeAmount.Text) + Convert.ToDecimal(Grid["TaxFreeAmount", i].Value.ToString())).ToString();
                    }
                }
            }

            lblTotalBasicAmt.Text = (Convert.ToDecimal(lblTotalBasicAmt.Text) + Convert.ToDecimal(TxtBillDiscAmt.Text)).ToString();
            TxtBillAmount.Text = Convert.ToDecimal(lblTotalProductNetAmt.Text).ToString(); // + Convert.ToDecimal(TxtBillDiscAmt.Text)).ToString() ;
            TxtBillAmount.Text = ClsGlobal.DecimalFormate((Convert.ToDecimal(TxtBillAmount.Text)), 1, ClsGlobal._AmountDecimalFormat).ToString();
            lblTotalProductNetAmt.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(lblTotalProductNetAmt.Text), 1, ClsGlobal._AmountDecimalFormat);
            lblBillTerm.Text = lblTotalProductTerm.Text;
        }
        private void BillTermCalc()
        {
            TxtBillDiscAmt.Text = ClsGlobal.DecimalFormate((Convert.ToDecimal(TxtBillAmount.Text) * (Convert.ToDecimal(TxtBillDiscPer.Text) / 100)), 1, ClsGlobal._AmountDecimalFormat).ToString();
            for (int i = 0; i < Grid.Rows.Count; i++)
            {
                if (i < (Grid.Rows.Count - 1))
                    Grid["SNo", i].Value = i + 1;
                if (Grid["ProductId", i].Value != null)
                {
                    Grid["BillDisc", i].Value = Convert.ToDecimal(TxtBillDiscPer.Text);
                }
            }
            TotalCalculate();
            lblBillTerm.Text = (Convert.ToDecimal(lblTotalProductTerm.Text) - Convert.ToDecimal(TxtBillDiscAmt.Text)).ToString();
            TxtBillAmount.Text = ClsGlobal.DecimalFormate((Convert.ToDecimal(lblTotalBasicAmt.Text) + Convert.ToDecimal(lblBillTerm.Text)), 1, ClsGlobal._AmountDecimalFormat).ToString();
        }
        private void AddControlMode()
        {
            if (Grid.Rows.Count == 2)
            {
                if (Grid["ProductId", 0].Value != null)
                {
                    BtnCashPayment.Enabled = true;
                    BtnCardPayment.Enabled = true;
                    BtnCreditPayment.Enabled = true;
                    BtnRate.Enabled = true;
                    BtnQty.Enabled = true;
                    BtnDiscount.Enabled = true;
                    TxtBillDiscAmt.Enabled = true;
                    TxtBillDiscPer.Enabled = true;
                    TxtRemarks.Enabled = true;
                }
            }
        }

        private void SaveBill(string paymentMode, string tenderAmount, string returnAmount, string customerName, int ledgerId, string partyName, string address, string vatNo)
        {
            if (string.IsNullOrEmpty(TxtInvoiceNo.Text))
            {
                MessageBox.Show("Voucher No Cannot Left Blank.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtInvoiceNo.Focus();
                return;
            }
            if (ClsGlobal.CheckDateInsideCompanyPeriod(Convert.ToDateTime(TxtInvDate.Text)) == 1)
            {
                ClsGlobal.DateMitiRangeMsg();
                return;
            }
            if (string.IsNullOrEmpty(TxtInvDate.Text))
            {
                MessageBox.Show("Date Cannot Left Blank.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtInvDate.Focus();
                return;
            }
            if (Grid.Rows.Count > 1)
            {
                if (Grid["ProductId", 0].Value == null)
                {
                    MessageBox.Show("Detail Data not enter...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtProductCode.Focus();
                    return;
                }
            }
            Utility.GetVoucherNo2("Sales Invoice", TxtInvoiceNo, TxtProductCode, "NEW", _SearchKey);
            _objSalesInvoice.Model.Tag = this._Tag;
            _objSalesInvoice.Model.VoucherNo = TxtInvoiceNo.Text;
            _objSalesInvoice.Model.DocId = Convert.ToInt32(TxtInvoiceNo.Tag);
            _objSalesInvoice.Model.VDate = Convert.ToDateTime(TxtInvDate.Text.ToString());
            _objSalesInvoice.Model.VTime = Convert.ToDateTime(TxtInvDate.Text.ToString());
            _objSalesInvoice.Model.VMiti = TxtInvMiti.Text;
            _objSalesInvoice.Model.ReferenceNo = null;
            _objSalesInvoice.Model.ReferenceDate = null;
            _objSalesInvoice.Model.ReferenceMiti = "";
            _objSalesInvoice.Model.DueDay = 0;
            _objSalesInvoice.Model.DueDate = null;
            _objSalesInvoice.Model.DueMiti = "";
            if (paymentMode == "Cash")
            {
                _objSalesInvoice.Model.LedgerId = Convert.ToInt32(ClsGlobal.CashLedgerId);
                _objSalesInvoice.Model.PaymentType = "Cash";
            }
            else if (paymentMode == "Card")
            {
                _objSalesInvoice.Model.LedgerId = Convert.ToInt32(ClsGlobal.CardLedgerId);
                _objSalesInvoice.Model.PaymentType = "Card";
            }
            else if (paymentMode == "Credit")
            {
                _objSalesInvoice.Model.LedgerId = ledgerId;
                _objSalesInvoice.Model.PaymentType = "Credit";
            }

                _objSalesInvoice.Model.PartyName = !string.IsNullOrEmpty(partyName) ?  partyName : customerName;
            _objSalesInvoice.Model.SubLedgerId = 0;
            _objSalesInvoice.Model.SalesmanId = 0;
            _objSalesInvoice.Model.DepartmentId1 = 0;
            _objSalesInvoice.Model.DepartmentId2 = 0;
            _objSalesInvoice.Model.DepartmentId3 = 0;
            _objSalesInvoice.Model.DepartmentId4 = 0;
            _objSalesInvoice.Model.CurrencyId = 0;
            _objSalesInvoice.Model.CurrencyRate = 1;
            _objSalesInvoice.Model.BranchId = ClsGlobal.BranchId;
            _objSalesInvoice.Model.CompanyUnitId = ClsGlobal.CompanyUnitId;
            decimal.TryParse(lblTotalBasicAmt.Text, out decimal BasicAmount);
            decimal.TryParse(lblBillTerm.Text, out decimal TermAmt);
            decimal.TryParse(TxtBillAmount.Text, out decimal NetAmount);
            decimal.TryParse(TxtBillDiscAmt.Text, out decimal BillDiscount);
            _objSalesInvoice.Model.BasicAmount = BasicAmount;
            _objSalesInvoice.Model.TermAmount = Convert.ToDecimal(lblBillTerm.Text);
            _objSalesInvoice.Model.NetAmount = Convert.ToDecimal(TxtBillAmount.Text);
            _objSalesInvoice.Model.TenderAmount = Convert.ToDecimal(tenderAmount);
            _objSalesInvoice.Model.ReturnAmount = Convert.ToDecimal(returnAmount);
            _objSalesInvoice.Model.TaxableAmount = Convert.ToDecimal(lblTaxableAmount.Text);
            _objSalesInvoice.Model.TaxFreeAmount = Convert.ToDecimal(lblTaxFreeAmount.Text);
            _objSalesInvoice.Model.VatAmount = (Convert.ToDecimal(lblTaxableAmount.Text) * Convert.ToDecimal(0.13));
            _objSalesInvoice.Model.PartyVatNo = vatNo;
            _objSalesInvoice.Model.PartyAddress = address;
            _objSalesInvoice.Model.PartyMobileNo = "";
            _objSalesInvoice.Model.ChequeNo = "";
            _objSalesInvoice.Model.ChequeDate = null;
            _objSalesInvoice.Model.ChequeMiti = "";
            _objSalesInvoice.Model.InvoiceType = "Local";
            _objSalesInvoice.Model.Remarks = "";
            _objSalesInvoice.Model.QuotationNo = "";
            _objSalesInvoice.Model.OrderNo = "";
            _objSalesInvoice.Model.ChallanNo = "";
            _objSalesInvoice.Model.EnterBy = ClsGlobal.LoginUserCode;
            _objSalesInvoice.Model.PrintCopy = 0;
            _objSalesInvoice.Model.ReconcileBy = "";
            _objSalesInvoice.Model.ReconcileDate = null;
            _objSalesInvoice.Model.IsPosted = 0;
            _objSalesInvoice.Model.PostedBy = "";
            _objSalesInvoice.Model.PostedDate = null;
            _objSalesInvoice.Model.IsAuthorized = 0;
            _objSalesInvoice.Model.AuthorizedBy = "";
            _objSalesInvoice.Model.AuthorizedDate = null;
            _objSalesInvoice.Model.AuthorizeRemarks = "";
            _objSalesInvoice.Model.Gadget = "Desktop";
            _objSalesInvoice.Model.IsBillCancel = 0;
            _objSalesInvoice.Model.EntryFromProject = "POS";
            _objSalesInvoice.SalesIrd.IsIRDSync = 0;
            _objSalesInvoice.SalesIrd.IsRealTimeIRDSync = 0;
            _objSalesInvoice.SalesIrd.PrintCopy = 0;
            _objSalesInvoice.SalesIrd.PrintedBy = "";
            _objSalesInvoice.SalesIrd.PrintedDate = null;
            SalesInvoiceDetailsViewModel DetailsModel = null;
            TermViewModel TermModel = null;
            foreach (DataGridViewRow ro in Grid.Rows)
            {
                decimal discountAamount = 0;
                if (ro.Cells["ProductId"].Value != null)
                {
                    DetailsModel = new SalesInvoiceDetailsViewModel();
                    DetailsModel.VoucherNo = _objSalesInvoice.Model.VoucherNo;
                    DetailsModel.Sno = Grid.Rows.IndexOf(ro) + 1;
                    DetailsModel.ProductId = Convert.ToInt32(ro.Cells["ProductId"].Value);
                    DetailsModel.ProductAltUnitId = 0;
                    DetailsModel.ProductUnitId = ro.Cells["ProductUnitId"].Value.ToString() != "" ? Convert.ToInt32(ro.Cells["ProductUnitId"].Value.ToString()) : 0;
                    DetailsModel.GodownId = 0;
                    DetailsModel.AltQty = 0;
                    DetailsModel.Qty = Convert.ToInt32(ro.Cells["Qty"].Value);
                    DetailsModel.SalesRate = Convert.ToDecimal(ro.Cells["Rate"].Value.ToString());
                    if (Convert.ToDecimal(TxtBillDiscPer.Text) > 0)
                    {
                        discountAamount = Convert.ToDecimal(ro.Cells["NetAmt"].Value.ToString()) * (Convert.ToDecimal(ro.Cells["BillDisc"].Value.ToString()) / 100);
                        DetailsModel.NetAmount = (Convert.ToDecimal(ro.Cells["NetAmt"].Value.ToString()) - discountAamount) / Convert.ToDecimal(1.13);
                        DetailsModel.NetAmount = DetailsModel.NetAmount + discountAamount;
                    }
                    else
                        DetailsModel.NetAmount = Convert.ToDecimal(ro.Cells["NetAmt"].Value.ToString()) / Convert.ToDecimal(1.13);

                    DetailsModel.TermAmount = -Convert.ToDecimal(ro.Cells["DiscAmount"].Value.ToString());
                    DetailsModel.BasicAmount = DetailsModel.NetAmount - DetailsModel.TermAmount;
                    DetailsModel.LocalNetAmount = DetailsModel.NetAmount;
                    DetailsModel.AdditionalDesc = "";
                    DetailsModel.FreeQty = 0;
                    DetailsModel.FreeQtyUnit = 0;
                    DetailsModel.OrderNo = "";
                    DetailsModel.OrderSNo = 0;
                    DetailsModel.DispatchOrderNo = "";
                    DetailsModel.DispatchOrderSNo = 0;
                    DetailsModel.ChallanNo = "";
                    DetailsModel.ChallanSNo = 0;
                    DetailsModel.TaxableAmount = (Convert.ToBoolean(ro.Cells["IsTaxable"].Value) == true) ? DetailsModel.NetAmount : 0;
                    DetailsModel.TaxFreeAmount = (Convert.ToBoolean(ro.Cells["IsTaxable"].Value) == true) ? 0 : Convert.ToDecimal(ro.Cells["TaxFreeAmount"].Value.ToString());
                    DetailsModel.VatAmount = Convert.ToDecimal(ro.Cells["VatAmt"].Value.ToString());
                    DetailsModel.IsTaxable = (Convert.ToBoolean(ro.Cells["IsTaxable"].Value) == true) ? true : false;

                    DataTable dtSalesTerm = _objSalesBillingTerm.GetProductTerm();
                    foreach (DataRow roTerm in dtSalesTerm.Rows)
                    {
                        TermModel = new TermViewModel();
                        TermModel.VoucherNo = DetailsModel.VoucherNo;
                        TermModel.TermId = Convert.ToInt32(roTerm["TermId"].ToString());
                        TermModel.ProductId = DetailsModel.ProductId;
                        TermModel.Sno = DetailsModel.Sno;
                        TermModel.TermType = "P";
                        TermModel.STSign = roTerm["Sign"].ToString();
                        TermModel.TermRate = Convert.ToDecimal(ro.Cells["DiscPercent"].Value.ToString());
                        TermModel.TermAmt = Convert.ToDecimal(ro.Cells["DiscAmount"].Value.ToString());    // (TermModel.TermRate / 100) * DetailsModel.BasicAmount;
                        TermModel.LocalTermAmt = TermModel.TermAmt;

                        _objSalesInvoice.ModelTerms.Add(TermModel);
                    }
                    _objSalesInvoice.ModelDetails.Add(DetailsModel);
                }
            }
            DataTable dtSalesBillTerm = _objSalesBillingTerm.GetBillTerm();
            foreach (DataRow roTerm in dtSalesBillTerm.Rows)
            {
                TermModel = new TermViewModel();
                TermModel.VoucherNo = _objSalesInvoice.Model.VoucherNo;
                TermModel.TermId = Convert.ToInt32(roTerm["TermId"].ToString());
                TermModel.ProductId = 0;
                TermModel.Sno = 0;
                TermModel.TermType = "B";
                TermModel.STSign = roTerm["Sign"].ToString();
                if (TermModel.TermId == Convert.ToInt32(ClsGlobal.SBVatTermId))
                {
                    TermModel.TermRate = Convert.ToDecimal(roTerm["Rate"].ToString());
                    TermModel.TermAmt = (_objSalesInvoice.Model.TaxableAmount * (TermModel.TermRate / 100));
                }
                else
                {
                    TermModel.TermRate = (Convert.ToDecimal(TxtBillDiscPer.Text) != 0) ? Convert.ToDecimal(TxtBillDiscPer.Text) : Convert.ToDecimal(roTerm["Rate"].ToString());
                    TermModel.TermAmt = Convert.ToDecimal(TxtBillDiscAmt.Text);
                }
                // TermModel.TermAmt = (_objSalesInvoice.Model.BasicAmount * (TermModel.TermRate / 100));
                TermModel.LocalTermAmt = TermModel.TermAmt;

                _objSalesInvoice.ModelTerms.Add(TermModel);
            }

            string result = _objSalesInvoice.SaveSalesInvoice();
            if (!string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Data submit successfully", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (_IsSaveAndPrint == 1)
                {
                    DocPrintingOption frm = new DocPrintingOption("SB", "Sales Invoice", TxtInvoiceNo.Text);
                    frm.ShowDialog();
                }
                ClearFld();
                BtnNew.Enabled = true;
                BtnNew.PerformClick();
                TxtProductCode.Focus();
            }
            else
            {
                MessageBox.Show("Error occured during data submit", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GetData(string InvoiceNo)
        {
            DataSet ds = _objSalesInvoice.GetDataSalesVoucher(InvoiceNo);
            DataTable dtMaster = ds.Tables[0];
            DataTable dtDetails = ds.Tables[1];
            DataTable dtTerm = ds.Tables[2];
            foreach (DataRow drMaster in dtMaster.Rows)
            {
                TxtInvMiti.Text = drMaster["VMiti"].ToString();
                TxtInvDate.Text = drMaster["VDate"].ToString();

                decimal ProductNetAmount = 0, ProductDiscountAmount = 0, BillDiscountAmount = 0, BillDiscountPercent = 0;
                foreach (DataRow drDetails in dtDetails.Rows)
                {
                    Grid.Rows[Grid.Rows.Count - 1].Cells["SNo"].Value = Grid.Rows.Count.ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["Particular"].Value = drDetails["ProductDesc"].ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["ProductId"].Value = drDetails["ProductId"].ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["Qty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["Qty"].ToString()), 1, ClsGlobal._QtyDecimalFormat).ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["Unit"].Value = drDetails["ProductUnitDesc"].ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["Rate"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["SalesRete"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["BasicAmt"].Value = ClsGlobal.DecimalFormate((Convert.ToDecimal(drDetails["Qty"].ToString()) * Convert.ToDecimal(drDetails["SalesRete"].ToString())), 1, ClsGlobal._AmountDecimalFormat).ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["GodownId"].Value = "";
                    Grid.Rows[Grid.Rows.Count - 1].Cells["DiscAmount"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["TermAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["NetAmt"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["NetAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["TaxableAmt"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["TaxableAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["TaxFreeAmount"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["TaxFreeAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["VatAmt"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["VatAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["IsTaxable"].Value = drDetails["IsTaxable"].ToString();

                    ProductNetAmount += Convert.ToDecimal(drDetails["NetAmount"].ToString());
                    ProductDiscountAmount += Convert.ToDecimal(drDetails["TermAmount"].ToString());

                    foreach (DataRow drTerms in dtTerm.Select("TermType<>'B' and ProductId='" + drDetails["ProductId"].ToString() + "'"))
                    {
                        if (drTerms["TermType"].ToString().Trim() == "P")
                            Grid.Rows[Grid.Rows.Count - 1].Cells["DIscPercent"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drTerms["TermRate"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                        if (drTerms["TermType"].ToString().Trim() == "BT" && (Convert.ToInt32(drTerms["TermId"].ToString()) != ClsGlobal.SBVatTermId))
                        {
                            Grid.Rows[Grid.Rows.Count - 1].Cells["BillDisc"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drTerms["TermRate"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                            BillDiscountPercent = Convert.ToDecimal(drTerms["TermRate"].ToString());
                            BillDiscountAmount += Convert.ToDecimal(drTerms["TermAmt"].ToString());
                        }
                        if (drTerms["TermType"].ToString() == "BT" && (Convert.ToInt32(drTerms["TermId"].ToString()) == ClsGlobal.SBVatTermId))
                            Grid.Rows[Grid.Rows.Count - 1].Cells["VatRate"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drTerms["TermRate"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                    }
                    Grid.Rows.Add();
                }

                TxtBillAmount.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(drMaster["NetAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                TxtBillDiscAmt.Text = ClsGlobal.DecimalFormate(BillDiscountAmount, 1, ClsGlobal._AmountDecimalFormat).ToString();
                TxtBillDiscPer.Text = ClsGlobal.DecimalFormate(BillDiscountPercent, 1, ClsGlobal._AmountDecimalFormat).ToString();
            }
        }

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Grid.Columns[e.ColumnIndex].Name == "RemoveRow")
            {
                Grid.Focus();
                Grid.Rows.RemoveAt(e.RowIndex);
                TotalCalculate();
            }
        }
        private void Grid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            //Grid.Focus();
            //CalcTotal();
        }
        private void Grid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //FrmDialogBox frm = new FrmDialogBox("Quantity", "Quantity:", "100");
            //frm.ShowDialog();
        }
       
        private void BtnCounterSearch_Click(object sender, EventArgs e)
        {
            ClsGlobal.SalesmanType = "Member";
            Common.PickList frmPickList = new Common.PickList("SalesMan", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtMember.Text = frmPickList.SelectedList[0]["SalesmanDesc"].ToString().Trim();
                    TxtMember.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["SalesmanId"].ToString().Trim());
                    TxtMember.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Member !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtMember.Focus();
                return;
            }
            ClsGlobal.SalesmanType = "";
            _SearchKey = "";
            TxtMember.Focus();

        }
        private void BtnProductSearch_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Product", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtProductCode.Text = frmPickList.SelectedList[0]["ProductShortName"].ToString().Trim();
                    TxtProductCode.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["ProductId"].ToString().Trim());
                    LoadProduct(frmPickList.SelectedList[0]["ProductId"].ToString().Trim());
                    AddControlMode();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Product !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtProductCode.Focus();
                return;
            }
            _SearchKey = "";
            TxtProductCode.Focus();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (ClsGlobal.ConfirmFormClear == 1)
            {
                DialogResult dialog = ClsGlobal.ConfirmFormClearing(); //MessageBox.Show("Do You Want To Cancel?", "Swastik", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    ControlEnableDisable(true, false);
                    ClearFld();
                    TxtInvoiceNo.Text = "";
                    this.Text = "POS Billing";
                }
                else
                    return;
            }
            else if (ClsGlobal.ConfirmFormClear == 0)
            {
                ControlEnableDisable(true, false);
                ClearFld();
                TxtInvoiceNo.Text = "";
                this.Text = "POS Billing";
                BtnBillCancel.Enabled = true;
                BtnExit.Enabled = true;
                BtnPrint.Enabled = true;
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearFld();
            ControlEnableDisable(false, true);
            this.Text = "POS Billing [NEW]";
            _Tag = "NEW";
            BtnBillCancel.Enabled = false;
            BtnPrint.Enabled = false;
            Grid.Enabled = true;
            TxtInvMiti.Text = _objDate.GetMiti(_objDate.GetServerDate());
            TxtInvDate.Text = _objDate.GetServerDate().ToShortDateString();
            Utility.GetVoucherNo2("Sales Invoice", TxtInvoiceNo, TxtProductCode, "NEW", _SearchKey);
        }

        private void BtnCardPayment_Click(object sender, EventArgs e)
        {
            FrmInvoiceReceipt frm = new FrmInvoiceReceipt("Card", TxtBillAmount.Text);
            frm.ShowDialog();
            if (frm._clickbutton == "Ok")
                SaveBill("Card", frm._tenderamount, frm._returnamount, frm._customerName, frm.ledgerId, frm._partyName, frm._Address, frm._vatNo);
        }

        private void BtnCashPayment_Click(object sender, EventArgs e)
        {
            FrmInvoiceReceipt frm = new FrmInvoiceReceipt("Cash", TxtBillAmount.Text);
            frm.ShowDialog();
            if (frm._clickbutton == "Ok")
                SaveBill("Cash", frm._tenderamount, frm._returnamount, frm._customerName, frm.ledgerId, frm._partyName, frm._Address, frm._vatNo);
        }

        private void BtnBillCancel_Click(object sender, EventArgs e)
        {
            ClearFld();
            _Tag = "";
            ControlEnableDisable(false, true);
            TxtInvoiceNo.Enabled = true;
            TxtInvoiceNo.Focus();
            TxtInvDate.Text = "";
            TxtInvMiti.Text = "";
            this.Text = "POS Billing [BILL CANCEL]";
            _Tag = "BILL CANCEL";
            Grid.Enabled = false;
            //TxtBillAmount.Enabled = false;
            TxtBillDiscAmt.Enabled = false;
            TxtBillDiscPer.Enabled = false;
            BtnCashPayment.Enabled = false;
            BtnCardPayment.Enabled = false;
            BtnCreditPayment.Enabled = false;
            TxtProductCode.Enabled = false;
            TxtMember.Enabled = false;
            btnOk.Visible = true;
            btnOk.Enabled = false;
            isBillcancel = true;
        }

        private void BtnCreditPayment_Click(object sender, EventArgs e)
        {
            FrmInvoiceReceipt frm = new FrmInvoiceReceipt("Credit", TxtBillAmount.Text);
            frm.ShowDialog();
            if (frm._clickbutton == "Ok")
                SaveBill("Credit", frm._tenderamount, frm._returnamount, frm._customerName, frm.ledgerId, frm._partyName, frm._Address, frm._vatNo);
        }

        private void BtnRate_Click(object sender, EventArgs e)
        {
            if (Grid["ProductId", 0].Value != null)
            {
                FrmDialogBox frm = new FrmDialogBox("Rate", "Rate:", Grid.CurrentRow.Cells["Rate"].Value.ToString());
                frm.ShowDialog();
                if (!string.IsNullOrEmpty(frm._textDialog))
                {
                    Grid.CurrentRow.Cells["Rate"].Value = (frm._textDialog != "") ? frm._textDialog : Grid.CurrentRow.Cells["Rate"].Value;
                    Grid.CurrentRow.Cells["BasicAmt"].Value = Convert.ToDecimal(Grid.CurrentRow.Cells["Rate"].Value) * Convert.ToDecimal(Grid.CurrentRow.Cells["Qty"].Value);
                    TermCalculation(Grid.CurrentRow.Index, Convert.ToDecimal(Grid.CurrentRow.Cells["BasicAmt"].Value), Convert.ToDecimal(Grid.CurrentRow.Cells["DiscPercent"].Value), Convert.ToDecimal(Grid.CurrentRow.Cells["BillDisc"].Value));
                    TotalCalculate();
                }
                BillTermCalc();
            }
        }

        private void BtnQty_Click(object sender, EventArgs e)
        {
            if (Grid["ProductId", 0].Value != null)
            {
                FrmDialogBox frm = new FrmDialogBox("Quantity", "Quantity:", Grid.CurrentRow.Cells["Qty"].Value.ToString());
                frm.ShowDialog();
                {
                    Grid.CurrentRow.Cells["Qty"].Value = (frm._textDialog != "") ? frm._textDialog : Grid.CurrentRow.Cells["Qty"].Value;
                    Grid.CurrentRow.Cells["BasicAmt"].Value = Convert.ToDecimal(Grid.CurrentRow.Cells["Rate"].Value) * Convert.ToDecimal(Grid.CurrentRow.Cells["Qty"].Value);
                    TermCalculation(Grid.CurrentRow.Index, Convert.ToDecimal(Grid.CurrentRow.Cells["BasicAmt"].Value), Convert.ToDecimal(Grid.CurrentRow.Cells["DiscPercent"].Value), Convert.ToDecimal(Grid.CurrentRow.Cells["BillDisc"].Value));
                    TotalCalculate();
                }
                BillTermCalc();
            }
        }

        private void BtnDiscount_Click(object sender, EventArgs e)
        {
            if (Grid["ProductId", 0].Value != null)
            {
                FrmDialogBox frm = new FrmDialogBox("Discount", "Discount:", Grid.CurrentRow.Cells["DiscPercent"].Value.ToString());
                frm.ShowDialog();
                decimal basicAmount = 0;
                if (!string.IsNullOrEmpty(frm._textDialog))
                {
                    basicAmount = Convert.ToDecimal(Grid.CurrentRow.Cells["Rate"].Value) * Convert.ToDecimal(Grid.CurrentRow.Cells["Qty"].Value);
                    TermCalculation(Grid.CurrentRow.Index, basicAmount, Convert.ToDecimal(frm._textDialog), Convert.ToDecimal(Grid.CurrentRow.Cells["BillDisc"].Value));
                    TotalCalculate();
                }
                BillTermCalc();
            }
        }
        

        private void TxtProductCode_Validating(object sender, CancelEventArgs e)
        {
            if (_Tag == "" || this.ActiveControl == TxtProductCode) return;
            if (TxtProductCode.Enabled == false) return;

            if (Grid.Rows.Count > 0)
            {
                if (Grid["ProductId", 0].Value == null)
                {
                    MessageBox.Show("Product details cannot Left Blank...!", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
                else
                {
                    if (!string.IsNullOrEmpty(TxtProductCode.Text))
                    {
                        DataTable dt = _objProduct.GetProductFromShortName(TxtProductCode.Text);
                        if (dt.Rows.Count > 0)
                        {
                            LoadProduct(dt.Rows[0]["ProductId"].ToString());
                        }
                        else
                        {
                            MessageBox.Show("Product with this ShortName not exist!", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TxtProductCode.Text = "";
                        }
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(TxtProductCode.Text))
                {
                    MessageBox.Show("Product Code Cannot Left Blank...!", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
                else
                {
                    DataTable dt = _objProduct.GetProductFromShortName(TxtProductCode.Text);
                    if (dt.Rows.Count > 0)
                    {
                        LoadProduct(dt.Rows[0]["ProductId"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("Product with this ShortName not exist!", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TxtProductCode.Text = "";
                    }
                    e.Cancel = true;
                }
                BtnCashPayment.Focus();
            }
        }
        private void TxtInvoiceNo_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtInvoiceNo.Text))
            {
                Grid.Rows.Clear();
                Grid.Rows.Add();
                GetData(TxtInvoiceNo.Text);
                TxtRemarks.Enabled = true;
                TxtRemarks.Focus();
            }
            if (isBillcancel == true) btnOk.Enabled = true;
        }
        private void TxtBillDiscPer_Validating(object sender, CancelEventArgs e)
        {
            BillTermCalc();
        }
        private void TxtBillDiscAmt_Validating(object sender, CancelEventArgs e)
        {
            decimal _billdiscountPercent = 0;
            if (Convert.ToDecimal(TxtBillDiscAmt.Text) > 0 && Convert.ToDecimal(TxtBillDiscPer.Text) == 0)
            {
                _billdiscountPercent = (Convert.ToDecimal(TxtBillDiscAmt.Text) / Convert.ToDecimal(TxtBillAmount.Text) * 100);
                for (int i = 0; i < Grid.Rows.Count; i++)
                {
                    if (i < (Grid.Rows.Count - 1))
                        Grid["SNo", i].Value = i + 1;
                    if (Grid["ProductId", i].Value != null)
                    {
                        Grid["BillDisc", i].Value = _billdiscountPercent;
                    }
                }

                TotalCalculate();
                lblBillTerm.Text = (Convert.ToDecimal(lblTotalProductTerm.Text) - Convert.ToDecimal(TxtBillDiscAmt.Text)).ToString();
                TxtBillAmount.Text = ClsGlobal.DecimalFormate((Convert.ToDecimal(lblTotalBasicAmt.Text) + Convert.ToDecimal(lblBillTerm.Text)), 1, ClsGlobal._AmountDecimalFormat).ToString();
            }
        }

        private void TxtCounter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1")
            {
                _SearchKey = string.Empty;
                BtnMemberSearch.PerformClick();
            }
            else
            {
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "NEW", _SearchKey, TxtMember, BtnMemberSearch, true);
            }
        }

        private void TxtProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1")
            {
                _SearchKey = string.Empty;
                BtnProductSearch.PerformClick();
            }
            else
            {
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "NEW", _SearchKey, TxtProductCode, BtnProductSearch, true);
            }
        }

        private void POSBilling_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.ActiveControl != Grid)
                SendKeys.Send("{Tab}");
            else if (e.KeyCode == Keys.Escape)
            {
                if (BtnCancel.Enabled == true)
                {
                    _Tag = "";
                    BtnCancel.PerformClick();
                }
                else if (BtnCancel.Enabled == false)
                    BtnExit.PerformClick();

                DialogResult = DialogResult.Cancel;
                return;
            }
        }
        private void TxtInvoiceNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                Common.PickList frmPickList = new Common.PickList("SalesVoucher", _SearchKey);
                if (Common.PickList.dt.Rows.Count > 0)
                {
                    frmPickList.ShowDialog();
                    if (frmPickList.SelectedList.Count > 0)
                    {
                        TxtInvoiceNo.Text = frmPickList.SelectedList[0]["VoucherNo"].ToString().Trim();
                        TxtInvoiceNo.SelectAll();
                    }
                    frmPickList.Dispose();
                }
                else
                {
                    MessageBox.Show("No List Available in SalesInvoice !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtInvoiceNo.Focus();
                    return;
                }
                _SearchKey = "";
                TxtInvoiceNo.Focus();
            }
        }

        private void TxtRemarks_Validating(object sender, CancelEventArgs e)
        {
            if (this._Tag == "BILL CANCEL")
            {
                if (string.IsNullOrEmpty(TxtRemarks.Text))
                {
                    MessageBox.Show("Please provide remarks before bill cancel...!", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to cancel this bill?", "Mr.Solution", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string cancelbill = _objSalesInvoice.BillCancel(TxtInvoiceNo.Text);
                if (!string.IsNullOrEmpty(cancelbill))
                {
                    MessageBox.Show("Invoice No: '" + cancelbill + "' Cancel Successfully...!", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFld();
                    ControlEnableDisable(false, true);
                    this.Text = "POS Billing [NEW]";
                    _Tag = "NEW";
                    BtnBillCancel.Enabled = false;
                    BtnPrint.Enabled = false;
                    Grid.Enabled = true;
                    TxtInvMiti.Text = _objDate.GetMiti(Convert.ToDateTime(_objDate.GetServerDate()));
                    TxtInvDate.Text = Convert.ToDateTime(_objDate.GetServerDate()).ToShortDateString();
                    Utility.GetVoucherNo2("Sales Invoice", TxtInvoiceNo, TxtProductCode, "NEW", _SearchKey);
                }
            }
            isBillcancel = false;
        }

        private void TxtCounter_Validating(object sender, CancelEventArgs e)
        {
            DataTable dt = (!string.IsNullOrEmpty(TxtMember.Text)) ? (_objSalesInvoice.GetMemberPercent(TxtMember.Text)) : null;
            if (dt != null && dt.Rows.Count > 0)
                TxtBillDiscPer.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["DiscountPercent"].ToString()), 1, ClsGlobal._AmountDecimalFormat);
        }
    }
}
