using DataAccessLayer.Common;
using DataAccessLayer.DataTransaction;
using DataAccessLayer.DataTransaction.Sales;
using DataAccessLayer.Interface.Common;
using DataAccessLayer.Interface.DataTransaction;
using DataAccessLayer.Interface.DataTransaction.Sales;
using DataAccessLayer.Interface.MasterSetup;
using DataAccessLayer.Interface.SystemSetting;
using DataAccessLayer.MasterSetup;
using DataAccessLayer.SystemSetting;
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
    public partial class FrmRestaurantBilling : Form
    {
        IRestaurantBilling _objRestaurantBilling = new ClsRestaurantBilling();
        ClsDateMiti _objDate = new ClsDateMiti();
        ISalesInvoice _objSalesInvoice = new ClsSalesInvoice();
        ISalesOrder _objSalesOrder = new ClsSalesOrder();
        ISalesBillingTerm _objSalesBillingTerm = new ClsSalesBillingTerm();
        IProduct _objProduct = new ClsProduct();
        IProductScheme _objScheme = new ClsProductScheme();
        ClsCommon _objCommon = new ClsCommon();
        IDocPrintSetting _objDocPrintSetting = new ClsDocPrintSetting();
        ICounter _counter = new ClsCounter();
        IKOTAssign _objKOt = new ClsKOTAssign();
        IUserMaster _objUserMaster = new ClsUserMaster();
        ISalesman _objSalesMan = new ClsSalesman();


        string _Tag = "", voucherNo = "", _SearchKey = "", _PrinterName = "", filterbuttonclick = "";
        int _FloorId = 0, TableID = 0, CurrentRowAdd = 0, _IsSaveAndPrint = 0;
        decimal TotalTaxFreeAmount = 0;
        bool isBillcancel = false, isSplitted = false;
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        public FrmRestaurantBilling()
        {
            InitializeComponent();
			ISalesBillingTerm objSaleBillingTerm = new ClsSalesBillingTerm();
			if (ClsGlobal.CardLedgerId == 0 || ClsGlobal.CashLedgerId == 0 || ClsGlobal.SBVatTermId == 0 || ClsGlobal.SBBillDiscountTermId == 0 || ClsGlobal.SBProductDiscountTermId == 0 || ClsGlobal.SBServiceChargeTermId == 0)
			{
				MessageBox.Show("Please tag Cash A/C, Card A/C, Sales Vat A/C, Sales Product Discount , Sales Bill Discount and Service Charge in System Setting.", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
				ClsGlobal.PosBillValid = false;
			}

			DataTable dt = objSaleBillingTerm.GetDataSalesBillingTerm(Convert.ToInt32(ClsGlobal.SBVatTermId));
			if (dt.Rows.Count > 0)
			{
				if (dt.Rows[0]["BillWise"].ToString() != "Bill Wise")
				{
					MessageBox.Show("Please tag Billwise Sales Vat A/C in System Setting.", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
					ClsGlobal.PosBillValid = false;
				}
			}
		}
        private void FrmRestaurantBilling_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.ActiveControl != Grid)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (BtnCancel.Enabled == true)
                {
                    _Tag = "";
                    t.Stop();
                    BtnCancel.PerformClick();
                }
                else
                {
                    t.Stop();
                    this.Close();
                    DialogResult = DialogResult.Cancel;
                    return;
                }
            }
        }
        private void FrmRestaurantBilling_Load(object sender, EventArgs e)
        {
            ClearFld();
            ControlEnableDisable(true, false);
            _Tag = "NEW";
            TxtMiti.Text = _objDate.GetMiti(_objDate.GetServerDate());
            TxtDate.Text = _objDate.GetServerDate().ToShortDateString();

            BindTableList();
            BindFloorList();
            t.Interval = 3000;
            t.Tick += new EventHandler(Timer_Tick);
            t.Start();

        }
        void Timer_Tick(object sender, EventArgs e)
        {
            ChangeTableStatusColor();
        }

        private void TxtProduct_Validating(object sender, CancelEventArgs e)
        {
            if (this.ActiveControl == TxtProduct || string.IsNullOrEmpty(TxtProduct.Text.Trim())) return;
            if (TxtProduct.Enabled == false) return;

            if (string.IsNullOrEmpty(TxtTable.Text) && !string.IsNullOrEmpty(TxtProduct.Text.Trim()))
            {
                MessageBox.Show("Select table before adding product...!", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtProduct.Focus();
                return;
            }

            DataTable dt = _objProduct.GetProductFromShortName(TxtProduct.Text);
            if (dt.Rows.Count > 0)
            {
                BindProductToGrid(dt.Rows[0]["ProductId"].ToString());
                TxtProduct.Focus();
            }
            else
            {
                MessageBox.Show("Product with this ShortName not exist!", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtProduct.Text = "";
                e.Cancel = true;
                return;
            }
        }

        private void TxtProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1")
            {
                _SearchKey = string.Empty;
                BtnProductSearch.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "NEW", _SearchKey, TxtProduct, BtnProductSearch, true);
            }
        }
        private void BtnProductSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtTable.Text))
            {
                ClsGlobal.billingType = "RestaurantBill";
                Common.PickList frmPickList = new Common.PickList("RestaurantProduct", _SearchKey);
                if (Common.PickList.dt.Rows.Count > 0)
                {
                    frmPickList.ShowDialog();
                    if (frmPickList.SelectedList.Count > 0)
                    {
                        TxtProduct.Text = frmPickList.SelectedList[0]["ProductShortName"].ToString().Trim();
                        TxtProduct.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["ProductId"].ToString().Trim());
                        BindProductToGrid(frmPickList.SelectedList[0]["ProductId"].ToString().Trim());
                        if (Grid.CurrentRow.Index == 0 && _Tag == "NEW")
                        {
                            DataTable dtbillterm = _objSalesBillingTerm.GetDataSalesBillingTerm(Convert.ToInt32(ClsGlobal.SBBillDiscountTermId));
                            if (dtbillterm.Rows.Count > 0)
                            {
                                decimal BasicAmount = 0;
                                if (!string.IsNullOrEmpty(dtbillterm.Rows[0]["TermRate"].ToString()))
                                {
                                    TxtBillDiscountPercent.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dtbillterm.Rows[0]["TermRate"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();

                                    decimal.TryParse(TxtBillDiscountPercent.Text, out decimal discpercent);
                                    BasicAmount = Convert.ToDecimal(TxtTotalBasicAmt.Text) + Convert.ToDecimal(TxtTotalTermAmt.Text);
                                    TxtBillDiscount.Text = ClsGlobal.DecimalFormate((BasicAmount * discpercent / 100), 1, ClsGlobal._AmountDecimalFormat).ToString();
                                }
                            }
                            CalculateOnBillDiscount("NEW");
                        }

                        SaveSalesOrder();
                        _Tag = "";
                    }
                    frmPickList.Dispose();
                }
                else
                {
                    MessageBox.Show("No List Available in Product...!", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtProduct.Focus();
                    return;
                }
                _SearchKey = "";
                ClsGlobal.billingType = "";
                TxtProduct.Focus();
            }
            else
            {
                MessageBox.Show("Select table before adding product...!", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtProduct.Focus();
                return;
            }

        }


        private void TxtWaiter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1")
            {
                _SearchKey = string.Empty;
                BtnWaiterSearch.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtWaiter, BtnWaiterSearch, true);
            }
        }

        private void BtnWaiterSearch_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Waiter", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtWaiter.Text = frmPickList.SelectedList[0]["UserCode"].ToString().Trim();
                    TxtWaiter.Tag = frmPickList.SelectedList[0]["UserCode"].ToString().Trim();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Waiter ...!", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtWaiter.Focus();
                return;
            }
            _SearchKey = "";
            TxtWaiter.Focus();
        }

        private void TxtMember_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1")
            {
                _SearchKey = string.Empty;
                BtnMemberSearch.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtMember, BtnMemberSearch, true);
            }
        }

        private void BtnMemberSearch_Click(object sender, EventArgs e)
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
                MessageBox.Show("No List Available in Member...!", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtMember.Focus();
                return;
            }
            ClsGlobal.SalesmanType = "";
            _SearchKey = "";
            TxtMember.Focus();
        }



        private void RecalculateTermAmount(int productId)
        {
            decimal basicamount = 0, qty = 0, rate = 0;
            qty = Convert.ToDecimal(Grid.CurrentRow.Cells["Qty"].Value.ToString());
            rate = Convert.ToDecimal(Grid.CurrentRow.Cells["Rate"].Value.ToString());
            basicamount = qty * rate;
            FrmTerm frmterm = new FrmTerm("SALES", Convert.ToDecimal(Grid.CurrentRow.Cells["BasicAmt"].Value.ToString()), Grid.CurrentRow.Cells["TermsDetails"].Value.ToString(), Convert.ToDecimal(Grid.CurrentRow.Cells["Qty"].Value.ToString()), productId);
            Grid.CurrentRow.Cells["TermAmt"].Value = ClsGlobal.DecimalFormate(frmterm.TermAmount(), 1, ClsGlobal._AmountDecimalFormat).ToString();
            Grid.CurrentRow.Cells["TermsDetails"].Value = frmterm.TermDetails;

            Grid.CurrentRow.Cells["NetAmt"].Value = ClsGlobal.DecimalFormate(basicamount + Convert.ToDecimal(Grid.CurrentRow.Cells["TermAmt"].Value.ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
        }
        #region---------------Button Click-------------------------
        private void BtnDiscount_Click(object sender, EventArgs e)
        {
            if (Grid["ProductId", Grid.CurrentRow.Index].Value != null)
            {
                FrmDialogBox frm = new FrmDialogBox("Discount", "Discount:", ClsGlobal.DecimalFormate(Convert.ToDecimal(GetIndivisualTermRate("Discount", Grid.CurrentRow.Cells["TermsDetails"].Value.ToString())), 1, ClsGlobal._RateDecimalFormat).ToString());
                frm.ShowDialog();
                if (!string.IsNullOrEmpty(frm._textDialog))
                {
                    if (!string.IsNullOrEmpty(Grid.CurrentRow.Cells["TermsDetails"].Value.ToString()))
                    {
                        string[] val = Grid.CurrentRow.Cells["TermsDetails"].Value.ToString().Split('|');
                        string sign = val[0];
                        string sn = val[1];
                        string ratepercent = val[2];
                        string amount = val[3];
                        string[] arrsign = sign.Split(',');
                        string[] arrsn = sn.Split(',');
                        string[] arrRatepercent = ratepercent.Split(',');
                        string[] arrAmount = amount.Split(',');
                        arrRatepercent[0] = frm._textDialog.ToString();
                        arrAmount[0] = "0";

                        string changeRatePercent = "", changeAmount = "";
                        for (int i = 0; i < arrRatepercent.Length; i++)
                        {
                            changeRatePercent += ',' + arrRatepercent[i];
                            changeAmount += ',' + arrAmount[i];
                        }
                        Grid.CurrentRow.Cells["TermsDetails"].Value = sign + "|" + sn + "|" + changeRatePercent.Substring(1) + "|" + changeAmount.Substring(1);
                    }

                    RecalculateTermAmount(Convert.ToInt32(Grid.CurrentRow.Cells["ProductId"].Value.ToString()));
                    //CurrentRowAdd = Grid.CurrentRow.Index+1;
                    _objSalesOrder.DeleteOrderDetails(this.voucherNo);
                    CurrentRowAdd = -1;
                    TotalCalculate();
                    SaveSalesOrder();

                }
            }
            TxtProduct.Focus();
        }

        private void BtnServiceCharge_Click(object sender, EventArgs e)
        {
            if (Grid["ProductId", Grid.CurrentRow.Index].Value != null)
            {
                FrmDialogBox frm = new FrmDialogBox("Service Charge", "S.Charge:", ClsGlobal.DecimalFormate(Convert.ToDecimal(GetIndivisualTermRate("Service Charge", Grid.CurrentRow.Cells["TermsDetails"].Value.ToString())), 1, ClsGlobal._RateDecimalFormat).ToString());
                frm.ShowDialog();
                decimal basicAmount = 0;
                if (!string.IsNullOrEmpty(frm._textDialog))
                {
                    if (!string.IsNullOrEmpty(Grid.CurrentRow.Cells["TermsDetails"].Value.ToString()))
                    {
                        string[] val = Grid.CurrentRow.Cells["TermsDetails"].Value.ToString().Split('|');
                        string sign = val[0];
                        string sn = val[1];
                        string ratepercent = val[2];
                        string amount = val[3];
                        string[] arrsign = sign.Split(',');
                        string[] arrsn = sn.Split(',');
                        string[] arrRatepercent = ratepercent.Split(',');
                        string[] arrAmount = amount.Split(',');
                        arrRatepercent[1] = frm._textDialog.ToString();
                        arrAmount[1] = "0";

                        string changeRatePercent = "", changeAmount = "";
                        for (int i = 0; i < arrRatepercent.Length; i++)
                        {
                            changeRatePercent += ',' + arrRatepercent[i];
                            changeAmount += ',' + arrAmount[i];
                        }
                        Grid.CurrentRow.Cells["TermsDetails"].Value = sign + "|" + sn + "|" + changeRatePercent.Substring(1) + "|" + changeAmount.Substring(1);
                    }

                    RecalculateTermAmount(Convert.ToInt32(Grid.CurrentRow.Cells["ProductId"].Value.ToString()));
                    _objSalesOrder.DeleteOrderDetails(this.voucherNo);
                    CurrentRowAdd = -1;
                    TotalCalculate();
                    SaveSalesOrder();
                }

            }
            TxtProduct.Focus();
        }

        private void BtnVat_Click(object sender, EventArgs e)
        {
            if (Grid["ProductId", Grid.CurrentRow.Index].Value != null)
            {
                FrmDialogBox frm = new FrmDialogBox("Vat", "Vat:", Grid.CurrentRow.Cells["TermAmt"].Value.ToString());
                frm.ShowDialog();
                decimal basicAmount = 0;
                if (!string.IsNullOrEmpty(frm._textDialog))
                {
                    basicAmount = Convert.ToDecimal(Grid.CurrentRow.Cells["TermAmt"].Value);
                    //TermCalculation(Grid.CurrentRow.Index, basicAmount, Convert.ToDecimal(frm._textDialog), Convert.ToDecimal(Grid.CurrentRow.Cells["BillDisc"].Value));
                    TotalCalculate();
                }
                // BillTermCalc();
            }
            TxtProduct.Focus();
        }

        private void BtnRate_Click(object sender, EventArgs e)
        {
            if (Grid["ProductId", Grid.CurrentRow.Index].Value != null)
            {
                if (ClsGlobal.AccessSalesRateChange == 1)
                {
                    FrmDialogBox frm = new FrmDialogBox("Rate", "Rate:", Grid.CurrentRow.Cells["Rate"].Value.ToString());
                    frm.ShowDialog();
                    if (!string.IsNullOrEmpty(frm._textDialog))
                    {
                        Grid.CurrentRow.Cells["Rate"].Value = (frm._textDialog != "") ? ClsGlobal.DecimalFormate(Convert.ToDecimal(frm._textDialog), 1, ClsGlobal._AmountDecimalFormat).ToString() : ClsGlobal.DecimalFormate(Convert.ToDecimal(Grid.CurrentRow.Cells["Rate"].Value.ToString()), 1, ClsGlobal._QtyDecimalFormat).ToString();
                        Grid.CurrentRow.Cells["BasicAmt"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(Grid.CurrentRow.Cells["Rate"].Value) * Convert.ToDecimal(Grid.CurrentRow.Cells["Qty"].Value), 1, ClsGlobal._AmountDecimalFormat).ToString();
                        RecalculateTermAmount(Convert.ToInt32(Grid.CurrentRow.Cells["ProductId"].Value.ToString()));
                        _objSalesOrder.DeleteOrderDetails(this.voucherNo);
                        CurrentRowAdd = -1;
                        TotalCalculate();
                        SaveSalesOrder();
                    }
                }
                else
                {
                    MessageBox.Show("You have not rights to modify rate...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            TxtProduct.Focus();
        }

        private void BtnQty_Click(object sender, EventArgs e)
        {
            if (Grid["ProductId", Grid.CurrentRow.Index].Value != null && Grid["IsPrintKot", Grid.CurrentRow.Index].Value.ToString() == "N")
            {
                FrmDialogBox frm = new FrmDialogBox("Quantity", "Quantity:", Grid.CurrentRow.Cells["Qty"].Value.ToString());
                frm.ShowDialog();
                {
                    Grid.CurrentRow.Cells["Qty"].Value = (frm._textDialog != "") ? ClsGlobal.DecimalFormate(Convert.ToDecimal(frm._textDialog), 1, ClsGlobal._QtyDecimalFormat).ToString() : ClsGlobal.DecimalFormate(Convert.ToDecimal(Grid.CurrentRow.Cells["Qty"].Value.ToString()), 1, ClsGlobal._QtyDecimalFormat).ToString();
                    Grid.CurrentRow.Cells["BasicAmt"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(Grid.CurrentRow.Cells["Rate"].Value) * Convert.ToDecimal(Grid.CurrentRow.Cells["Qty"].Value), 1, ClsGlobal._AmountDecimalFormat).ToString();
                    RecalculateTermAmount(Convert.ToInt32(Grid.CurrentRow.Cells["ProductId"].Value.ToString()));
                    _objSalesOrder.DeleteOrderDetails(this.voucherNo);
                    CurrentRowAdd = -1;
                    TotalCalculate();
                    SaveSalesOrder();
                }
                // BillTermCalc();
            }
            TxtProduct.Focus();
        }
        private void BtnNote_Click(object sender, EventArgs e)
        {
            if (Grid["ProductId", Grid.CurrentRow.Index].Value != null && Grid["IsPrintKot", Grid.CurrentRow.Index].Value.ToString() == "N")
            {
                FrmDialogBox frm = new FrmDialogBox("Note", "Note:", Grid.CurrentRow.Cells["Notes"].Value.ToString());
                frm.ShowDialog();
                if (!string.IsNullOrEmpty(frm._textDialog))
                {
                    Grid.CurrentRow.Cells["Notes"].Value = (frm._textDialog.Trim() != "") ? frm._textDialog.Trim() : Grid.CurrentRow.Cells["Notes"].Value;
                    _objSalesOrder.DeleteOrderDetails(this.voucherNo);
                    CurrentRowAdd = -1;
                    TotalCalculate();
                    SaveSalesOrder();
                }

            }
        }

        private void BtnPrintKOT_Click(object sender, EventArgs e)
        {
            _IsSaveAndPrint = _objDocPrintSetting.CheckIsSaveAndPrint("KOT");
            DataTable dtcounter = _counter.GetDataCounter(Convert.ToInt32(ClsGlobal.CounterId));
            if (dtcounter.Rows.Count > 0)
                _PrinterName = dtcounter.Rows[0]["PrinterName"].ToString();
            if (_IsSaveAndPrint == 1)
            {
                DataAccessLayer.DLLPrinting.DllInvoicePrint a = new DataAccessLayer.DLLPrinting.DllInvoicePrint(TxtVoucherNo.Text, _PrinterName, "KOT/BOTdll", ClsGlobal.LoginUserCode, ClsGlobal.TodayDateTime, 2);
            }

            for (int i = 0; i < Grid.Rows.Count; i++)
            {
                if (Grid["ProductId", i].Value != null)
                {
                    if (Grid["IsPrintKot", i].Value != "Y")
                        Grid["IsPrintKot", i].Value = "Y";
                }
                else break;
            }
            _objSalesOrder.DeleteOrderDetails(this.voucherNo);
            CurrentRowAdd = -1;
            TotalCalculate();
            SaveSalesOrder();
            GetOrderData(TxtVoucherNo.Text);
        }

        private void BtnSplitTable_Click(object sender, EventArgs e)
        {
            decimal mainbasicamount = Convert.ToDecimal(TxtTotalBasicAmt.Text) + Convert.ToDecimal(TxtTotalTermAmt.Text);
            FrmSplit _objSplit = new FrmSplit(TxtVoucherNo.Text, TxtTable.Text);
            _objSplit.ShowDialog();

            if (_objSplit.buttonClick == "Conform")
            {
                DataTable dtSplitProduct = _objSplit.dtSplitProduct;
                DataTable dtOrderProduct = _objSplit.dtOrderProduct;
                decimal.TryParse(TxtBillDiscountPercent.Text, out decimal billdiscountpercent);
                decimal.TryParse(TxtBillDiscount.Text, out decimal billdiscountAmt);
                decimal BasicAmount = 0;
                string waitercode = TxtWaiter.Text;

                if (dtOrderProduct.Rows.Count > 0)
                {

                    _objSalesOrder.DeleteOrderDetails(this.voucherNo);
                    Grid.Rows.Clear();
                    int gridHeight = Grid.Height;
                    for (int i = 0; i < gridHeight / 24; i++)
                    {
                        Grid.Rows.Add();
                    }
                    foreach (DataRow ro in dtOrderProduct.Rows)
                    {
                        BindProductToGrid(ro["ProductId"].ToString(), ro["TermDetails"].ToString(), ro["Rate"].ToString(), ro["Qty"].ToString());
                    }
                    CurrentRowAdd = -1;
                    SaveSalesOrder();
                    TxtBillDiscountPercent.Text = ClsGlobal.DecimalFormate(billdiscountpercent, 1, ClsGlobal._AmountDecimalFormat);
                    BasicAmount = Convert.ToDecimal(TxtTotalBasicAmt.Text) + Convert.ToDecimal(TxtTotalTermAmt.Text);
                    if (billdiscountpercent > 0)
                        TxtBillDiscount.Text = ClsGlobal.DecimalFormate((BasicAmount * billdiscountpercent / 100), 1, ClsGlobal._AmountDecimalFormat).ToString();
                    else
                        TxtBillDiscount.Text = ClsGlobal.DecimalFormate(BasicAmount / mainbasicamount * billdiscountAmt, 1, ClsGlobal._AmountDecimalFormat);

                    CalculateOnBillDiscount();

                    _Tag = "";
                }

                if (dtSplitProduct.Rows.Count > 0)
                {
                    TxtRemarks.Text = "Current Order is Splited from OrderNo:'" + TxtVoucherNo + "' and Table='" + TxtTable.Name + "'";
                    Button newButton = new Button();
                    newButton.Tag = "A";
                    newButton.Name = "Table" + _objSplit.SplitTableId.ToString();
                    newButton.Text = _objSplit.SplitTableDesc.ToString();
                    isSplitted = true;
                    OnTableButtonClick(newButton, null);
                    isSplitted = false;
                    TxtWaiter.Text = waitercode;
                    TxtWaiter.Tag = waitercode;
                    foreach (DataRow ro in dtSplitProduct.Rows)
                    {
                        BindProductToGrid(ro["ProductId"].ToString(), ro["TermDetails"].ToString(), ro["RateSplit"].ToString(), ro["Qty"].ToString());
                    }
                    _Tag = "NEW";
                    CurrentRowAdd = -1;
                    SaveSalesOrder();
                    TxtBillDiscountPercent.Text = ClsGlobal.DecimalFormate(billdiscountpercent, 1, ClsGlobal._AmountDecimalFormat);
                    BasicAmount = Convert.ToDecimal(TxtTotalBasicAmt.Text) + Convert.ToDecimal(TxtTotalTermAmt.Text);
                    if (billdiscountpercent > 0)
                        TxtBillDiscount.Text = ClsGlobal.DecimalFormate((BasicAmount * billdiscountpercent / 100), 1, ClsGlobal._AmountDecimalFormat).ToString();
                    else
                        TxtBillDiscount.Text = ClsGlobal.DecimalFormate(BasicAmount / mainbasicamount * billdiscountAmt, 1, ClsGlobal._AmountDecimalFormat);

                    CalculateOnBillDiscount();
                    _Tag = "";
                }
                else
                {
                    MessageBox.Show("Split table are in used, for billing clear any Split table and Proceed...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void BtnMergeTable_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TableID.ToString()))
            {
                FrmMerge _objMerge = new FrmMerge(TableID.ToString(), TxtTable.Text, "Merge Table");
                _objMerge.ShowDialog();
                if (_objMerge.clickButton == "Conform")
                {
                    string OrderNo = _objSalesOrder.GetOrderVoucherNo(Convert.ToInt32(_objMerge.MergeTableId));
                    DataSet dsMergeTable = _objSalesOrder.GetDataOrderVoucher(OrderNo);
                    DataTable dtDetails = dsMergeTable.Tables[1];
                    DataTable dtTerms = dsMergeTable.Tables[2];
                    decimal billdiscountpercent = 0, billdiscountAmt = 0;
                    decimal ProductBasicAmount = 0, ProductTermAmount = 0, TotalQty = 0;
                    decimal.TryParse(TxtBillDiscount.Text, out decimal existingOrderBillDiscountAmount);
                    foreach (DataRow drDetails in dtDetails.Rows)
                    {
                        DataGridViewRow ro = new DataGridViewRow();
                        int sno = 0;
                        for (int i = 0; i < Grid.Rows.Count; i++)
                        {
                            if (Grid["ProductId", i].Value == null)
                            {
                                i = Grid.Rows.Count;
                            }
                            sno++;
                        }

                        if (sno == Grid.Rows.Count)
                        {
                            Grid.Rows.Add();
                        }

                        ro = Grid.Rows[sno - 1];

                        CurrentRowAdd = sno;
                        ro.Cells["SNo"].Value = sno;
                        ro.Cells["ProductShortName"].Value = drDetails["ProductShortName"].ToString();
                        ro.Cells["Particular"].Value = drDetails["ProductDesc"].ToString();
                        ro.Cells["ProductId"].Value = drDetails["ProductId"].ToString();
                        ro.Cells["Qty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["Qty"].ToString()), 1, ClsGlobal._QtyDecimalFormat).ToString();
                        ro.Cells["Unit"].Value = drDetails["ProductUnitDesc"].ToString();
                        ro.Cells["ProductUnitId"].Value = drDetails["ProductUnit"].ToString();
                        ro.Cells["Rate"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["SalesRate"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                        ro.Cells["BasicAmt"].Value = ClsGlobal.DecimalFormate((Convert.ToDecimal(drDetails["Qty"].ToString()) * Convert.ToDecimal(drDetails["SalesRate"].ToString())), 1, ClsGlobal._AmountDecimalFormat).ToString();
                        ro.Cells["GodownId"].Value = "";
                        ro.Cells["TermAmt"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["TermAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                        ro.Cells["NetAmt"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["NetAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                        ro.Cells["IsNote"].Value = Properties.Resources.note_16;
                        ro.Cells["Notes"].Value = drDetails["ResOrderNotes"].ToString();
                        ro.Cells["Kot"].Value = drDetails["ResKOTNo"].ToString();
                        ro.Cells["PrintKot"].Value = (drDetails["ResIsPrinted"].ToString() == "Y") ? null : Properties.Resources.printer_go;
                        ro.Cells["IsPrintKot"].Value = (drDetails["ResIsPrinted"].ToString() == "Y") ? 'Y' : 'N';
                        ro.Cells["RemoveRow"].Value = Properties.Resources.Delete_16;
                        ro.Cells["OrderTime"].Value = Convert.ToDateTime(drDetails["ResOrderTime"].ToString()).ToString("hh:mm:ss");
                        ro.Cells["TermsDetails"].Value = drDetails["TermDetails"].ToString();
                        ro.Cells["TaxFreeAmount"].Value = (drDetails["IsTaxable"].ToString() == "True") ? "0" : ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["NetAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();

                        TotalCalculate();
                        SaveSalesOrder();
                        _Tag = "";

                    }

                    TxtBillDiscountPercent.Text = billdiscountpercent.ToString();       // ClsGlobal.DecimalFormate(billdiscountpercent, 1, ClsGlobal._AmountDecimalFormat);
                    billdiscountAmt = 0;
                    foreach (DataRow roTerm in dtTerms.Select("TermType='B' and TermId<>'" + ClsGlobal.SBVatTermId + "'"))
                    {
                        billdiscountAmt += Convert.ToDecimal(roTerm["TermAmt"].ToString());
                    }

                    TxtBillDiscount.Text = ClsGlobal.DecimalFormate(billdiscountAmt + existingOrderBillDiscountAmount, 1, ClsGlobal._AmountDecimalFormat);
                    CalculateOnBillDiscount();

                    _objSalesOrder.CancelOrder(OrderNo, Convert.ToInt32(_objMerge.MergeTableId), "This Order is merge to order no : " + TxtVoucherNo.Text + "");
                }
            }
            else
            {
                MessageBox.Show("Please Select Order Table to merge another order bill...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void BtnTransferTable_Click(object sender, EventArgs e)
        {
            FrmMerge _objMerge = new FrmMerge(TableID.ToString(), TxtTable.Text, "Transfer Table");
            _objMerge.ShowDialog();
            if (_objMerge.clickButton == "Conform")
            {
                _objSalesOrder.UpdateTransferTable(TxtVoucherNo.Text, Convert.ToInt32(TableID), Convert.ToInt32(_objMerge.MergeTableId));
                TxtTable.Text = _objMerge.MergerTableDesc;
                TxtTable.Tag = "O";
                TableID = Convert.ToInt32(_objMerge.MergeTableId);
            }
            TableFocusIndicate.Visible = false;
        }

        private void BtnCashPayment_Click(object sender, EventArgs e)
        {
            FrmInvoiceReceipt frm = new FrmInvoiceReceipt("Cash", TxtBillAmt.Text);
            frm.ShowDialog();
            if (frm._clickbutton == "Ok")
            {
                this._Tag = "NEW";
                SaveBill("Cash", frm._tenderamount, frm._returnamount, frm._customerName, frm.ledgerId, frm._partyName, frm._Address, frm._vatNo);
            }
        }

        private void BtnCardPayment_Click(object sender, EventArgs e)
        {
            FrmInvoiceReceipt frm = new FrmInvoiceReceipt("Card", TxtBillAmt.Text);
            frm.ShowDialog();
            if (frm._clickbutton == "Ok")
            {
                this._Tag = "NEW";
                SaveBill("Card", frm._tenderamount, frm._returnamount, frm._customerName, frm.ledgerId, frm._partyName, frm._Address, frm._vatNo);
            }
        }

        private void BtnCreditPayment_Click(object sender, EventArgs e)
        {
            FrmInvoiceReceipt frm = new FrmInvoiceReceipt("Credit", TxtBillAmt.Text);
            frm.ShowDialog();
            if (frm._clickbutton == "Ok")
            {
                this._Tag = "NEW";
                SaveBill("Credit", frm._tenderamount, frm._returnamount, frm._customerName, frm.ledgerId, frm._partyName, frm._Address, frm._vatNo);
            }
        }

        private void BtnCancelBill_Click(object sender, EventArgs e)
        {
            ClearFld();
            _Tag = "";
            ControlEnableDisable(false, true);

            TxtVoucherNo.Enabled = true;
            BtnVoucherNoSearch.Enabled = true;
            TxtVoucherNo.Text = "";
            lblVoucherNo.Text = "Bill No";
            TxtVoucherNo.Focus();
            TxtInvoiceNo.Text = "";
            TxtDate.Text = "";
            TxtMiti.Text = "";
            this.Text = "POS Billing [BILL CANCEL]";
            _Tag = "BILL CANCEL";
            Grid.Enabled = false;

            TxtBillDiscount.Enabled = false;
            TxtBillDiscountPercent.Enabled = false;
            BtnCashPayment.Enabled = false;
            BtnCardPayment.Enabled = false;
            BtnCreditPayment.Enabled = false;
            TxtProduct.Enabled = false;
            TxtMember.Enabled = false;
            BtnMemberSearch.Enabled = false;
            BtnProductSearch.Enabled = false;
            BtnCancelOrder.Enabled = false;
            BtnCashPayment.Enabled = false;
            BtnCardPayment.Enabled = false;
            BtnCardPayment.Enabled = false;
            BtnPrintOrder.Enabled = false;
            EnableDisableTerms(false);
            BtnQty.Enabled = false;
            BtnRate.Enabled = false;
            BtnSplitTable.Enabled = false;
            BtnMergeTable.Enabled = false;
            BtnTransferTable.Enabled = false;
            BtnPrintKOT.Enabled = false;
            BtnNote.Enabled = false;
            isBillcancel = true;

            btnOk.Visible = true;
            btnOk.Enabled = false;
        }

        private void BtnPrintOrder_Click(object sender, EventArgs e)
        {
            // Default3InchOrderDesign()
            _IsSaveAndPrint = _objDocPrintSetting.CheckIsSaveAndPrint("SO");
            DataTable dtcounter = _counter.GetDataCounter(Convert.ToInt32(ClsGlobal.CounterId));
            if (dtcounter.Rows.Count > 0)
                _PrinterName = dtcounter.Rows[0]["PrinterName"].ToString();
            if (_IsSaveAndPrint == 1)
            {
                DataAccessLayer.DLLPrinting.DllInvoicePrint a = new DataAccessLayer.DLLPrinting.DllInvoicePrint(TxtVoucherNo.Text, _PrinterName, "3InchRestaurantOrderdll", ClsGlobal.LoginUserCode, ClsGlobal.TodayDateTime, 2);
            }
        }

        private void BtnCancelOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtRemarks.Text))
            {
                MessageBox.Show("Please provide remarks before order cancel.", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtRemarks.Focus();
                return;
            }
            var dialogResult = MessageBox.Show("Are you sure want to cancel order no:" + TxtVoucherNo.Text + "...?", "Mr.Solution", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                _objSalesOrder.DeleteOrderDetails(TxtVoucherNo.Text, "FullCancel");
                _objSalesOrder.CancelOrder(TxtVoucherNo.Text, TableID);
                BtnCancel.PerformClick();
            }

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            _Tag = "NEW";
            _FloorId = 0;
            BindTableList();
            BindFloorList();
            ControlEnableDisable(true, false);
            ClearFld();
            TxtVoucherNo.Text = "";
            TxtProduct.Focus();
        }

        private void BtnAllTable_Click(object sender, EventArgs e)
        {
            filterbuttonclick = "";
            PnlTableList.Controls.Clear();
            IndicateFocus.Location = new System.Drawing.Point(7, 34);
            IndicateFocus.Size = new System.Drawing.Size(67, 5);

            BtnAllTable.BackColor = Color.ForestGreen;
            BtnPackingTable.BackColor = Color.SeaGreen;
            BtnDiningTable.BackColor = Color.SeaGreen;

            BindTableList();

        }

        private void BtnDiningTable_Click(object sender, EventArgs e)
        {
            filterbuttonclick = "Dining";
            IndicateFocus.Location = new System.Drawing.Point(78, 34);
            IndicateFocus.Size = new System.Drawing.Size(67, 5);

            BtnAllTable.BackColor = Color.SeaGreen;
            BtnPackingTable.BackColor = Color.SeaGreen;
            BtnDiningTable.BackColor = Color.ForestGreen;
            PnlTableList.Controls.Clear();
            BindTableList("", filterbuttonclick);
        }

        private void BtnPackingTable_Click(object sender, EventArgs e)
        {
            filterbuttonclick = "Packing";
            IndicateFocus.Location = new System.Drawing.Point(151, 34);
            IndicateFocus.Size = new System.Drawing.Size(67, 5);

            BtnAllTable.BackColor = Color.SeaGreen;
            BtnPackingTable.BackColor = Color.ForestGreen;
            BtnDiningTable.BackColor = Color.SeaGreen;
            PnlTableList.Controls.Clear();
            BindTableList("", filterbuttonclick);
        }

        private void BtnOccupiedTable_Click(object sender, EventArgs e)
        {
            filterbuttonclick = "Occupied";
            IndicateFocus.Location = new System.Drawing.Point(223, 34);
            IndicateFocus.Size = new System.Drawing.Size(67, 5);
            PnlTableList.Controls.Clear();
            BindTableList("O");
        }

        private void BtnReceiptTable_Click(object sender, EventArgs e)
        {
            IndicateFocus.Location = new System.Drawing.Point(251, 34);
            IndicateFocus.Size = new System.Drawing.Size(52, 5);
        }


        #endregion
        #region-------------Functions--------------
        private void BindProductToGrid(string ProductId, string termdetails = "", string Rate = "", string Qty = "")
        {
            DataSet ds = _objProduct.GetDataProduct(Convert.ToInt32(ProductId));
            DataTable dt = ds.Tables[0];
            DataGridViewRow ro = new DataGridViewRow();
            decimal salesrate = 0, basicamt = 0, termamt = 0, netamt = 0;

            int sno = 0;

            for (int i = 0; i < Grid.Rows.Count; i++)
            {
                if (Grid["ProductId", i].Value == null)
                {
                    i = Grid.Rows.Count;
                }
                sno++;
            }

            if (sno == Grid.Rows.Count)
            {
                Grid.Rows.Add();
            }

            ro = Grid.Rows[sno - 1];
            if (dt.Rows.Count > 0)
            {
                DataTable dtScheme = _objScheme.CurrentProductScheme(Convert.ToInt32(ProductId), ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
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
                    DataTable dtrate = _objProduct.ProductBranchRate(ProductId.ToString(), ClsGlobal.BranchId.ToString());
                    salesrate = (dtrate.Rows.Count > 0) ? Convert.ToDecimal(dtrate.Rows[0]["ProductRate"].ToString()) : Convert.ToDecimal(dt.Rows[0]["SalesRate"].ToString());
                }

                if (!string.IsNullOrEmpty(Rate))
                    salesrate = Convert.ToDecimal(Rate);


                ro.Cells["Qty"].Value = string.IsNullOrEmpty(Qty) ? "1" : Qty;
                ro.Cells["SNo"].Value = sno;
                CurrentRowAdd = sno;

                ro.Cells["Particular"].Value = dt.Rows[0]["ProductDesc"].ToString();
                ro.Cells["ProductShortName"].Value = dt.Rows[0]["ProductShortName"].ToString();
                ro.Cells["ProductId"].Value = ProductId;
                ro.Cells["GodownId"].Value = dt.Rows[0]["GodownId"].ToString();
                ro.Cells["Unit"].Value = dt.Rows[0]["ProductUnitShortName"].ToString();
                ro.Cells["ProductUnitId"].Value = dt.Rows[0]["ProductUnitId"].ToString();
                ro.Cells["Rate"].Value = ClsGlobal.DecimalFormate(salesrate, 1, ClsGlobal._AmountDecimalFormat);

                basicamt = Convert.ToDecimal(ro.Cells["Qty"].Value) * salesrate;
                FrmTerm frmterm = new FrmTerm("SALES", basicamt, termdetails, Convert.ToDecimal(ro.Cells["Qty"].Value.ToString()), Convert.ToInt32(ProductId));
                ro.Cells["TermAmt"].Value = ClsGlobal.DecimalFormate(frmterm.TermAmount(), 1, ClsGlobal._AmountDecimalFormat).ToString();
                ro.Cells["TermsDetails"].Value = frmterm.TermDetails;

                ro.Cells["BasicAmt"].Value = ClsGlobal.DecimalFormate(basicamt, 1, ClsGlobal._AmountDecimalFormat);
                termamt = Convert.ToDecimal(ro.Cells["TermAmt"].Value.ToString());
                netamt = basicamt + termamt;
                ro.Cells["NetAmt"].Value = ClsGlobal.DecimalFormate(netamt, 1, ClsGlobal._AmountDecimalFormat);
                ro.Cells["Notes"].Value = "";
                ro.Cells["IsNote"].Value = Properties.Resources.note_16;
                ro.Cells["Kot"].Value = TxtKotNo.Text;
                ro.Cells["PrintKot"].Value = Properties.Resources.printer_go;
                ro.Cells["IsPrintKot"].Value = 'N';
                ro.Cells["RemoveRow"].Value = Properties.Resources.Delete_16;
                ro.Cells["OrderTime"].Value = DateTime.Now.ToString("hh:mm:ss");
                ro.Cells["IsTaxable"].Value = dt.Rows[0]["IsTaxable"].ToString();
                ro.Cells["TaxFreeAmount"].Value = (ro.Cells["IsTaxable"].Value.ToString() == "True") ? "0" : netamt.ToString();
                ro.Selected = true;
                TxtProduct.Clear();
                TotalCalculate();

            }
            ControlEnableDisable(false, true);
            EnableDisableTerms(true);
        }
        void ChangeTableStatusColor()
        {
            DataTable dtTableList = new DataTable();
            if (!string.IsNullOrEmpty(filterbuttonclick))
            {
                if (filterbuttonclick == "Occupied")
                    dtTableList = _objRestaurantBilling.TableList(_FloorId, "O");
            }
            else
                dtTableList = _objRestaurantBilling.TableList(_FloorId);

            int r = 0;
            foreach (Control control in PnlTableList.Controls)
            {
                if (control is Button)
                {
                    if (r < dtTableList.Rows.Count)
                    {
                        string tableStatus = dtTableList.Rows[r]["TableStatus"].ToString();
                        if (tableStatus == "O")
                        {
                            control.BackColor = System.Drawing.Color.Brown;
                        }
                        else if (tableStatus == "A")
                        {
                            control.BackColor = System.Drawing.Color.ForestGreen;
                        }
                        else if (tableStatus == "R")
                        {
                            control.BackColor = System.Drawing.Color.MidnightBlue;
                        }
                        control.Tag = tableStatus;
                        r++;
                    }
                }
            }
        }
        private void BindTableList(string TableStatus = "", string TableType = "")
        {
            int x = 5;
            int y = 7;
            List<Button> buttons = new List<Button>();
            DataTable dtTableList = new DataTable();
            if (!string.IsNullOrEmpty(TableStatus))
                dtTableList = _objRestaurantBilling.TableList(_FloorId, TableStatus);
            else if (!string.IsNullOrEmpty(TableType))
                dtTableList = _objRestaurantBilling.TableList(_FloorId, TableStatus, TableType);
            else
                dtTableList = _objRestaurantBilling.TableList(_FloorId);
            int i = 1; int j = 5;
            foreach (DataRow item in dtTableList.Rows)
            {
                if (i == 1)
                {
                    x = 5;
                }
                else if (i == j)
                {
                    x = 5; y = y + 40; j = j + 4;
                }
                else
                {
                    x = x + 72;
                }

                Button newButton = new Button();
                newButton.Location = new System.Drawing.Point(x, y);
                newButton.Size = new System.Drawing.Size(67, 35);
                newButton.TabIndex = 0;
                newButton.TabStop = false;
                newButton.CausesValidation = false;
                if (item["TableStatus"].ToString() == "O")
                {
                    newButton.BackColor = System.Drawing.Color.Brown;
                }
                else if (item["TableStatus"].ToString() == "A")
                {
                    newButton.BackColor = System.Drawing.Color.ForestGreen;
                }
                else if (item["TableStatus"].ToString() == "R")
                {
                    newButton.BackColor = System.Drawing.Color.MidnightBlue;
                }
                newButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                newButton.ForeColor = System.Drawing.Color.White;
                newButton.UseVisualStyleBackColor = false;
                newButton.Tag = item["TableStatus"].ToString();
                newButton.Name = "Table" + item["TableId"].ToString();
                newButton.Text = item["TableDesc"].ToString();
                newButton.Click += new EventHandler(OnTableButtonClick);
                buttons.Add(newButton);
                PnlTableList.Controls.Add(newButton);
                i++;
            }
        }
        private void BindFloorList()
        {
            int a = 4;
            List<Button> button = new List<Button>();
            DataTable dtFloorList = _objRestaurantBilling.FloorList();
            foreach (DataRow item in dtFloorList.Rows)
            {
                if (a == 4)
                {
                    Button newButtonAll = new Button();
                    newButtonAll.Location = new System.Drawing.Point(a, 4);
                    newButtonAll.Size = new System.Drawing.Size(67, 35);
                    newButtonAll.TabIndex = 0;
                    newButtonAll.TabStop = false;
                    newButtonAll.CausesValidation = false;
                    newButtonAll.AutoSize = true;
                    newButtonAll.BackColor = System.Drawing.Color.ForestGreen;
                    newButtonAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    newButtonAll.ForeColor = System.Drawing.Color.White;
                    newButtonAll.UseVisualStyleBackColor = false;
                    newButtonAll.Tag = "0";
                    newButtonAll.Name = "BtnAllFloor";
                    newButtonAll.Text = "ALL";
                    newButtonAll.Click += new EventHandler(OnFloorButtonClick);
                    button.Add(newButtonAll);
                    PnlTableFilter.Controls.Add(newButtonAll);
                    FloorFocusIndicate.Location = new System.Drawing.Point(a + 1, 33);
                    a = a + newButtonAll.Size.Width + 5;

                }

                Button newButton = new Button();
                newButton.Location = new System.Drawing.Point(a, 4);
                newButton.Size = new System.Drawing.Size(67, 35);
                newButton.TabIndex = 0;
                newButton.TabStop = false;
                newButton.AutoSize = true;
                newButton.BackColor = System.Drawing.Color.SeaGreen;
                newButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                newButton.ForeColor = System.Drawing.Color.White;
                newButton.UseVisualStyleBackColor = false;
                newButton.Tag = item["FloorId"].ToString();
                newButton.Name = "Floor" + item["FloorId"].ToString();
                newButton.Text = item["FloorDesc"].ToString();
                newButton.Click += new EventHandler(OnFloorButtonClick);
                button.Add(newButton);
                PnlTableFilter.Controls.Add(newButton);
                a = a + newButton.Size.Width + 5;
            }

            //foreach (Control control in PnlTableFilter.Controls)
            //{
            //    if (control is Button)
            //    {
            //        string ss = control.Name;
            //        if (control.Name == "")
            //        {
            //FloorFocusIndicate.Location = new System.Drawing.Point(btnTable.Location.X + 1, btnTable.Location.Y + 29);
            //        }
            //    }
            //}

        }

        private void OnTableButtonClick(object sender, EventArgs e)
        {
            ClearFld();
            Button btnTable = (Button)sender;
            if (btnTable.Tag.ToString() != "O" && isSplitted == false)
            {
                if (btnTable.Text.Substring(0, btnTable.Text.Length - 1).ToUpper() == "Split".ToUpper())
                {
                    MessageBox.Show("Restricted to take new order on Split table...! ", "MrSolution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            TableFocusIndicate.Location = new System.Drawing.Point(btnTable.Location.X + 1, btnTable.Location.Y + 75);
            TableFocusIndicate.Visible = true;
            TableFocusIndicate.BringToFront();
            TxtTable.Text = btnTable.Text;
            TxtTable.Tag = btnTable.Tag;
            TableID = Convert.ToInt32(btnTable.Name.Substring(5, btnTable.Name.Length - 5));

            if (TxtTable.Tag.ToString() == "O")
            {
                this.voucherNo = _objSalesOrder.GetOrderVoucherNo(TableID);
                if (!string.IsNullOrEmpty(voucherNo))
                {
                    GetOrderData(voucherNo);
                    EnableDisableTerms(true);
                    TxtMember.Enabled = true;
                    TxtKotNo.Enabled = true;
                    TxtRemarks.Enabled = true;
                    TxtWaiter.Enabled = true;
                    BtnWaiterSearch.Enabled = true;
                    BtnMemberSearch.Enabled = true;
                    Grid.Enabled = true;
                    BtnRate.Enabled = true;
                    BtnQty.Enabled = true;
                    BtnTransferTable.Enabled = true;
                    BtnSplitTable.Enabled = true;
                    BtnMergeTable.Enabled = true;
                    BtnNote.Enabled = true;
                    BtnPrintKOT.Enabled = true;
                    BtnCashPayment.Enabled = true;
                    BtnCreditPayment.Enabled = true;
                    BtnCardPayment.Enabled = true;
                    BtnCancelOrder.Enabled = true;
                    BtnPrintOrder.Enabled = true;
                    BtnCancelBill.Enabled = false;
                    BtnCancel.Enabled = true;
                    TxtAdjustAmount.Enabled = true;
                    TxtBillDiscountPercent.Enabled = true;
                    _Tag = "";

                    TxtKotNo.Focus();

                }
                else
                    MessageBox.Show("Cannot find any order on this table...! ", "MrSolution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                ControlEnableDisable(true, false);
                BtnCancel.Enabled = false;
                TxtWaiter.Enabled = true;
                Utility.EnableDesibleColor(TxtWaiter, true);
                BtnWaiterSearch.Enabled = true;
                TxtKotNo.Enabled = true;
                Utility.EnableDesibleColor(TxtKotNo, true);
                TxtBillDiscountPercent.Enabled = true;
                Utility.EnableDesibleColor(TxtBillDiscountPercent, true);

                _Tag = "NEW";
                TxtKotNo.Focus();

            }


        }

        private void OnFloorButtonClick(object sender, EventArgs e)
        {
            TableFocusIndicate.Visible = false;
            PnlTableList.Controls.Clear();
            Button btnFloor = (Button)sender;
            _FloorId = Convert.ToInt32(btnFloor.Tag.ToString());
            foreach (Control control in PnlTableFilter.Controls)
            {
                if (control is Button)
                {
                    control.BackColor = System.Drawing.Color.SeaGreen;
                }
            }
            btnFloor.BackColor = System.Drawing.Color.ForestGreen;
            BindTableList();
        }
        private void TotalCalculate()
        {
            TxtBillAmt.Text = "0.00";
            TxtTotalBasicAmt.Text = "0.00";
            TxtTotalQty.Text = "0.00";
            TxtTotalTermAmt.Text = "0.00";
            TotalTaxFreeAmount = 0;

            for (int i = 0; i < Grid.Rows.Count; i++)
            {
                if (Grid["ProductId", i].Value != null)
                {
                    Grid["Sno", i].Value = i + 1;
                    TxtTotalQty.Text = (Convert.ToDecimal(TxtTotalQty.Text) + Convert.ToDecimal(Grid["Qty", i].Value.ToString())).ToString();
                    TxtTotalBasicAmt.Text = (Convert.ToDecimal(TxtTotalBasicAmt.Text) + Convert.ToDecimal(Grid["BasicAmt", i].Value.ToString())).ToString();
                    TxtTotalTermAmt.Text = (Convert.ToDecimal(TxtTotalTermAmt.Text) + Convert.ToDecimal(Grid["TermAmt", i].Value.ToString())).ToString();
                    TotalTaxFreeAmount = TotalTaxFreeAmount + Convert.ToDecimal(Grid["TaxFreeAmount", i].Value.ToString());
                }
                else return;

                decimal BasicAmount = Convert.ToDecimal(TxtTotalBasicAmt.Text) + Convert.ToDecimal(TxtTotalTermAmt.Text);
                decimal.TryParse(TxtBillDiscountPercent.Text, out decimal discountpercent);
                if (discountpercent > 0)
                    TxtBillDiscount.Text = ClsGlobal.DecimalFormate((BasicAmount * discountpercent / 100), 1, ClsGlobal._AmountDecimalFormat).ToString();

                decimal.TryParse(TxtBillDiscount.Text, out decimal billdiscountamount);
                if (TotalTaxFreeAmount == 0)
                {
                    TxtVat.Text = ClsGlobal.DecimalFormate((BasicAmount - billdiscountamount) * Convert.ToDecimal(0.13), 1, ClsGlobal._AmountDecimalFormat).ToString();
                }
                else
                {
                    decimal taxfreeamountdiscount = TotalTaxFreeAmount / BasicAmount * billdiscountamount;
                    decimal taxableamountdiscount = (BasicAmount - TotalTaxFreeAmount) / BasicAmount * billdiscountamount;
                    decimal taxableamount = (BasicAmount - TotalTaxFreeAmount) - taxableamountdiscount;
                    TotalTaxFreeAmount = TotalTaxFreeAmount - taxfreeamountdiscount;
                    TxtVat.Text = ClsGlobal.DecimalFormate(taxableamount * Convert.ToDecimal(0.13), 1, ClsGlobal._AmountDecimalFormat).ToString();
                }
                TxtTotalNetAmt.Text = ClsGlobal.DecimalFormate(BasicAmount, 1, ClsGlobal._AmountDecimalFormat).ToString();
                TxtBillAmt.Text = ClsGlobal.DecimalFormate(BasicAmount + Convert.ToDecimal(TxtVat.Text) - billdiscountamount, 1, ClsGlobal._AmountDecimalFormat).ToString();
            }

        }
        public void StartTermCalculation()
        {
            //if (_StartTermCalculation == true)
            //{
            //    decimal.TryParse(TxtGridQty.Text, out decimal _Qty);
            //    decimal.TryParse(TxtGridRate.Text, out decimal _Rate);
            //    TxtGridBasicAmt.Text = ClsGlobal.DecimalFormate((_Qty * _Rate), 1, ClsGlobal._AmountDecimalFormat).ToString();
            //    FrmTerm frmterm = new FrmTerm("SALES", (_Qty * _Rate), TxtGridTermsDetails.Text, _Qty, Convert.ToInt32(TxtGridParticular.Tag.ToString()));
            //    TxtGridTermsAmt.Text = ClsGlobal.DecimalFormate(frmterm.TermAmount(), 1, ClsGlobal._AmountDecimalFormat).ToString();
            //    TxtGridTermsDetails.Text = frmterm.TermDetails;
            //    decimal.TryParse(TxtGridTermsAmt.Text, out decimal Termamount);
            //    TxtGridNetAmt.Text = ClsGlobal.DecimalFormate(((_Qty * _Rate) + Termamount), 1, ClsGlobal._AmountDecimalFormat).ToString();
            //    _StartTermCalculation = false;
            //}
        }
        private void CalculateOnBillDiscount(string tagval = "")
        {
            decimal BasicAmount = 0;
            decimal.TryParse(TxtBillDiscountPercent.Text, out decimal discpercent);
            BasicAmount = Convert.ToDecimal(TxtTotalBasicAmt.Text) + Convert.ToDecimal(TxtTotalTermAmt.Text);
            decimal.TryParse(TxtBillDiscount.Text, out decimal billdiscountamount);

            if (TotalTaxFreeAmount == 0)
            {
                TxtVat.Text = ClsGlobal.DecimalFormate((BasicAmount - billdiscountamount) * Convert.ToDecimal(0.13), 1, ClsGlobal._AmountDecimalFormat).ToString();
            }
            else
            {
                decimal taxfreeamountdiscount = TotalTaxFreeAmount / BasicAmount * billdiscountamount;
                decimal taxableamountdiscount = (BasicAmount - TotalTaxFreeAmount) / BasicAmount * billdiscountamount;
                decimal taxableamount = (BasicAmount - TotalTaxFreeAmount) - taxableamountdiscount;
                TotalTaxFreeAmount = TotalTaxFreeAmount - taxfreeamountdiscount;
                TxtVat.Text = ClsGlobal.DecimalFormate(taxableamount * Convert.ToDecimal(0.13), 1, ClsGlobal._AmountDecimalFormat).ToString();
            }
            TxtBillAmt.Text = ClsGlobal.DecimalFormate(BasicAmount + Convert.ToDecimal(TxtVat.Text) - billdiscountamount, 1, ClsGlobal._AmountDecimalFormat).ToString();
            _Tag = (tagval == "NEW") ? "NEW" : "TERMEDIT";
            SaveSalesOrder();
            _Tag = "";
            TotalTaxFreeAmount = 0;
        }

        private void SaveBill(string paymentMode, string tenderAmount, string returnAmount, string customerName, int ledgerId, string partyName, string address, string vatNo)
        {
            //decimal TermAmt = 0, BasicAmount = 0, NetAmount = 0, BillDiscount = 0;
            //string SalesVoucherNo = "";
            if (string.IsNullOrEmpty(TxtVoucherNo.Text))
            {
                MessageBox.Show("Voucher No Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtVoucherNo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TxtDate.Text))
            {
                MessageBox.Show("Date Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDate.Focus();
                return;
            }
            if (ClsGlobal.CheckDateInsideCompanyPeriod(Convert.ToDateTime(TxtDate.Text)) == 1)
            {
                ClsGlobal.DateMitiRangeMsg();
                return;
            }
            if (Grid.Rows.Count > 1)
            {
                if (Grid["ProductId", 0].Value == null)
                {
                    MessageBox.Show("Detail Data not enter...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtProduct.Focus();
                    return;
                }
            }
            Utility.GetVoucherNo2("Sales Invoice", TxtInvoiceNo, TxtProduct, "NEW", _SearchKey);
            _objSalesInvoice.Model.Tag = this._Tag;
            _objSalesInvoice.Model.VoucherNo = TxtInvoiceNo.Text;
            _objSalesInvoice.Model.DocId = Convert.ToInt32(TxtInvoiceNo.Tag);
            _objSalesInvoice.Model.VDate = Convert.ToDateTime(TxtDate.Text.ToString());
            _objSalesInvoice.Model.VTime = Convert.ToDateTime(TxtDate.Text.ToString());
            _objSalesInvoice.Model.VMiti = TxtMiti.Text;
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

            if (!string.IsNullOrEmpty(partyName))
                _objSalesInvoice.Model.PartyName = partyName;
            else
                _objSalesInvoice.Model.PartyName = "Cash Party";

            _objSalesInvoice.Model.SubLedgerId = 0;
            _objSalesInvoice.Model.SalesmanId = string.IsNullOrEmpty(TxtMember.Text) ? 0 : Convert.ToInt32(TxtMember.Tag.ToString());
            _objSalesInvoice.Model.DepartmentId1 = 0;
            _objSalesInvoice.Model.DepartmentId2 = 0;
            _objSalesInvoice.Model.DepartmentId3 = 0;
            _objSalesInvoice.Model.DepartmentId4 = 0;
            _objSalesInvoice.Model.CurrencyId = 0;
            _objSalesInvoice.Model.CurrencyRate = 1;
            _objSalesInvoice.Model.BranchId = ClsGlobal.BranchId;
            _objSalesInvoice.Model.CompanyUnitId = ClsGlobal.CompanyUnitId;


            decimal.TryParse(TxtBillDiscount.Text, out decimal billdiscount);
            decimal.TryParse(TxtVat.Text, out decimal vatamt);
            decimal.TryParse(TxtBillAmt.Text, out decimal NetAmount);


            _objSalesInvoice.Model.BasicAmount = Convert.ToDecimal(TxtTotalBasicAmt.Text) + Convert.ToDecimal(TxtTotalTermAmt.Text);
            _objSalesInvoice.Model.TermAmount = vatamt - billdiscount;
            _objSalesInvoice.Model.NetAmount = NetAmount;
            _objSalesInvoice.Model.TenderAmount = Convert.ToDecimal(tenderAmount);
            _objSalesInvoice.Model.ReturnAmount = Convert.ToDecimal(returnAmount);

            _objSalesInvoice.Model.TaxableAmount = _objSalesInvoice.Model.BasicAmount - billdiscount;
            _objSalesInvoice.Model.TaxFreeAmount = 0;
            _objSalesInvoice.Model.VatAmount = vatamt;

            //_objSalesInvoice.Model.PartyName = "Cash Party";
            _objSalesInvoice.Model.PartyVatNo = vatNo;
            _objSalesInvoice.Model.PartyAddress = address;
            _objSalesInvoice.Model.PartyMobileNo = "";
            _objSalesInvoice.Model.ChequeNo = "";
            _objSalesInvoice.Model.ChequeDate = null;
            _objSalesInvoice.Model.ChequeMiti = "";
            _objSalesInvoice.Model.InvoiceType = "Local";
            _objSalesInvoice.Model.Remarks = "";
            _objSalesInvoice.Model.QuotationNo = "";
            _objSalesInvoice.Model.OrderNo = TxtVoucherNo.Text;
            _objSalesInvoice.Model.ChallanNo = "";
            _objSalesInvoice.Model.EnterBy = ClsGlobal.LoginUserCode;
            // _objSalesInvoice.Model.EnterDate="";
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
            _objSalesInvoice.Model.EntryFromProject = "Restaurant";
            _objSalesInvoice.Model.TableId = TableID;
            _objSalesInvoice.SalesIrd.IsIRDSync = 0;
            _objSalesInvoice.SalesIrd.IsRealTimeIRDSync = 0;
            _objSalesInvoice.SalesIrd.PrintCopy = 0;
            _objSalesInvoice.SalesIrd.PrintedBy = "";
            _objSalesInvoice.SalesIrd.PrintedDate = null;


            SalesInvoiceDetailsViewModel DetailsModel = null;
            TermViewModel TermModel = null;
            DataSet dSSalesTerm = _objSalesOrder.GetDataOrderVoucher(TxtVoucherNo.Text);
            DataTable dtSalesTerm = dSSalesTerm.Tables[2];
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
                    DetailsModel.ProductUnitId = string.IsNullOrEmpty(ro.Cells["ProductUnitId"].Value.ToString()) ? Convert.ToInt32(ro.Cells["ProductUnitId"].Value.ToString()) : 0;
                    DetailsModel.GodownId = ro.Cells["GodownId"].Value.ToString() != "" ? Convert.ToInt32(ro.Cells["GodownId"].Value.ToString()) : 0;
                    DetailsModel.AltQty = 0;
                    DetailsModel.Qty = Convert.ToDecimal(ro.Cells["Qty"].Value.ToString());
                    DetailsModel.SalesRate = Convert.ToDecimal(ro.Cells["Rate"].Value.ToString());

                    DetailsModel.NetAmount = Convert.ToDecimal(ro.Cells["NetAmt"].Value.ToString());
                    DetailsModel.TermAmount = Convert.ToDecimal(ro.Cells["TermAmt"].Value.ToString());
                    DetailsModel.BasicAmount = Convert.ToDecimal(ro.Cells["BasicAmt"].Value.ToString());
                    DetailsModel.LocalNetAmount = DetailsModel.NetAmount;
                    DetailsModel.AdditionalDesc = ro.Cells["Particular"].Value.ToString();
                    DetailsModel.FreeQty = 0;
                    DetailsModel.FreeQtyUnit = 0;
                    DetailsModel.OrderNo = TxtVoucherNo.Text;
                    DetailsModel.OrderSNo = DetailsModel.Sno;
                    DetailsModel.DispatchOrderNo = "";
                    DetailsModel.DispatchOrderSNo = 0;
                    DetailsModel.ChallanNo = "";
                    DetailsModel.ChallanSNo = 0;
                    DetailsModel.TaxableAmount = (Convert.ToBoolean(ro.Cells["IsTaxable"].Value) == true) ? (DetailsModel.NetAmount - TotalTaxFreeAmount) : 0;
                    DetailsModel.TaxFreeAmount = (Convert.ToBoolean(ro.Cells["IsTaxable"].Value) == true) ? 0 : TotalTaxFreeAmount;
                    DetailsModel.VatAmount = 0;
                    DetailsModel.IsTaxable = (Convert.ToBoolean(ro.Cells["IsTaxable"].Value) == true) ? true : false;


                    foreach (DataRow roTerm in dtSalesTerm.Select("TermType='P' and sno='" + DetailsModel.Sno + "'"))
                    {
                        TermModel = new TermViewModel();
                        TermModel.VoucherNo = DetailsModel.VoucherNo;
                        TermModel.TermId = Convert.ToInt32(roTerm["TermId"].ToString());
                        TermModel.ProductId = DetailsModel.ProductId;
                        TermModel.Sno = DetailsModel.Sno;
                        TermModel.TermType = "P";
                        TermModel.STSign = roTerm["STSign"].ToString();
                        TermModel.TermRate = Convert.ToDecimal(roTerm["TermRate"].ToString());
                        TermModel.TermAmt = Convert.ToDecimal(roTerm["TermAmt"].ToString());    // (TermModel.TermRate / 100) * DetailsModel.BasicAmount;
                        TermModel.LocalTermAmt = TermModel.TermAmt;

                        _objSalesInvoice.ModelTerms.Add(TermModel);
                    }
                    _objSalesInvoice.ModelDetails.Add(DetailsModel);
                }
                else break;
            }

            foreach (DataRow roTerm in dtSalesTerm.Select("TermType='B'"))
            {
                TermModel = new TermViewModel();
                TermModel.VoucherNo = _objSalesInvoice.Model.VoucherNo;
                TermModel.TermId = Convert.ToInt32(roTerm["TermId"].ToString());
                TermModel.ProductId = 0;
                TermModel.Sno = 0;
                TermModel.TermType = "B";
                TermModel.STSign = roTerm["STSign"].ToString();
                TermModel.TermRate = Convert.ToDecimal(roTerm["TermRate"].ToString());
                TermModel.TermAmt = Convert.ToDecimal(roTerm["TermAmt"].ToString());
                TermModel.LocalTermAmt = TermModel.TermAmt;

                _objSalesInvoice.ModelTerms.Add(TermModel);
            }

            _IsSaveAndPrint = _objDocPrintSetting.CheckIsSaveAndPrint("SB");
            DataTable dtcounter = _counter.GetDataCounter(Convert.ToInt32(ClsGlobal.CounterId));
            if (dtcounter.Rows.Count > 0)
                _PrinterName = dtcounter.Rows[0]["PrinterName"].ToString();

			string _PrintDesignName = _objDocPrintSetting.GetOrginalDllDesignName( Convert.ToInt32(ClsGlobal.DefaultInvoicePrintDesignId));

            string result = _objSalesInvoice.SaveSalesInvoice();
            if (!string.IsNullOrEmpty(result))
            {
                MessageBox.Show(" Invoice No: " + TxtInvoiceNo.Text + " has been generated and save successfully ...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (_IsSaveAndPrint == 1)
                {
                    DataAccessLayer.DLLPrinting.DllInvoicePrint a = new DataAccessLayer.DLLPrinting.DllInvoicePrint(result, _PrinterName, _PrintDesignName, ClsGlobal.LoginUserCode, ClsGlobal.TodayDateTime, 1);
                }
                ClearFld();
                //BtnNew.Enabled = true;
                //BtnNew.PerformClick();
                TxtProduct.Focus();
            }
            else
            {
                MessageBox.Show("Error occured during data submit ...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void SaveSalesOrder()
        {
            SalesOrderDetailsViewModel DetailsModel = null;
            TermViewModel TermModel = null;
            DataTable dtSalesBillTerm = _objSalesBillingTerm.GetBillTerm();
            if (_Tag == "NEW")
            {
                string[] VoucherNoDetails = _objCommon.GetVoucherNo(TxtVoucherNo.Tag.ToString(), "Sales Order", ClsGlobal.BranchId, ClsGlobal.CompanyUnitId);
                _objSalesOrder.Model.DocId = ((TxtVoucherNo.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtVoucherNo.Tag.ToString()));
                _objSalesOrder.Model.VoucherNo = VoucherNoDetails[0];
                this.voucherNo = VoucherNoDetails[0];
            }
            else
            {
                _objSalesOrder.Model.VoucherNo = this.voucherNo;

            }

            if (_Tag == "" || _Tag == "NEW")
            {
                _objSalesOrder.Model.Tag = _Tag;
                _objSalesOrder.Model.VDate = Convert.ToDateTime(TxtDate.Text.ToString());
                _objSalesOrder.Model.VTime = Convert.ToDateTime(TxtDate.Text.ToString());
                _objSalesOrder.Model.VMiti = TxtMiti.Text;
                _objSalesOrder.Model.ReferenceNo = null;
                _objSalesOrder.Model.ReferenceDate = null;
                _objSalesOrder.Model.ReferenceMiti = "";
                _objSalesOrder.Model.LedgerId = Convert.ToInt32(ClsGlobal.CashLedgerId);

                _objSalesOrder.Model.SubLedgerId = 0;
                _objSalesOrder.Model.SalesmanId = string.IsNullOrEmpty(TxtMember.Text) ? 0 : Convert.ToInt32(TxtMember.Tag.ToString());
                _objSalesOrder.Model.DepartmentId1 = 0;
                _objSalesOrder.Model.DepartmentId2 = 0;
                _objSalesOrder.Model.DepartmentId3 = 0;
                _objSalesOrder.Model.DepartmentId4 = 0;
                _objSalesOrder.Model.CurrencyId = 0;
                _objSalesOrder.Model.CurrencyRate = 1;
                _objSalesOrder.Model.BranchId = ClsGlobal.BranchId;
                _objSalesOrder.Model.CompanyUnitId = ClsGlobal.CompanyUnitId;

                decimal.TryParse(TxtTotalBasicAmt.Text, out decimal TotalBasicAmount);
                decimal.TryParse(TxtTotalTermAmt.Text, out decimal TotalProductterms);
                decimal.TryParse(TxtBillAmt.Text, out decimal TotalNetAmount);
                decimal.TryParse(TxtBillDiscount.Text, out decimal BillDiscount);

                decimal Taxable = TotalBasicAmount + TotalProductterms - BillDiscount;
                decimal Vat = Taxable * Convert.ToDecimal(0.13);
                decimal Totalbillterms = Vat - BillDiscount;

                _objSalesOrder.Model.BasicAmount = TotalBasicAmount + TotalProductterms;
                _objSalesOrder.Model.TermAmount = Totalbillterms;
                _objSalesOrder.Model.NetAmount = TotalBasicAmount + TotalProductterms + Totalbillterms;

                _objSalesOrder.Model.PartyName = "CashParty";
                _objSalesOrder.Model.PartyVatNo = "";
                _objSalesOrder.Model.PartyAddress = "";
                _objSalesOrder.Model.PartyMobileNo = "";
                _objSalesOrder.Model.ChequeNo = "";
                _objSalesOrder.Model.ChequeDate = null;
                _objSalesOrder.Model.ChequeMiti = "";
                _objSalesOrder.Model.Remarks = TxtRemarks.Text;
                _objSalesOrder.Model.QuotationNo = "";
                _objSalesOrder.Model.EnterBy = ClsGlobal.LoginUserCode;
                _objSalesOrder.Model.EnterDate = DateTime.Now;
                _objSalesOrder.Model.PrintCopy = 0;
                _objSalesOrder.Model.IsReconcile = 0;
                _objSalesOrder.Model.ReconcileBy = "";
                _objSalesOrder.Model.ReconcileDate = null;
                _objSalesOrder.Model.IsPosted = 0;
                _objSalesOrder.Model.PostedBy = "";
                _objSalesOrder.Model.PostedDate = null;
                _objSalesOrder.Model.IsAuthorized = 0;
                _objSalesOrder.Model.AuthorizedBy = "";
                _objSalesOrder.Model.AuthorizedDate = null;
                _objSalesOrder.Model.AuthorizeRemarks = "";
                _objSalesOrder.Model.Gadget = "Desktop";
                _objSalesOrder.Model.EntryFromProject = "Restaurant";
                _objSalesOrder.Model.TableId = TableID;
                _objSalesOrder.Model.ResIsCurrentOrder = 'Y';
                _objSalesOrder.Model.ResNoOfPacks = 0;
                _objSalesOrder.Model.CounterId = 0;
                _objSalesOrder.Model.IsOrderCancel = 0;



                foreach (DataGridViewRow ro in Grid.Rows)
                {
                    decimal discountAamount = 0;
                    if (ro.Cells["ProductId"].Value != null)
                    {
                        if (Convert.ToInt32(ro.Cells["Sno"].Value.ToString()) == CurrentRowAdd || CurrentRowAdd < 0)
                        {
                            DetailsModel = new SalesOrderDetailsViewModel();
                            DetailsModel.VoucherNo = _objSalesOrder.Model.VoucherNo;
                            DetailsModel.Sno = Grid.Rows.IndexOf(ro) + 1;
                            DetailsModel.ProductId = Convert.ToInt32(ro.Cells["ProductId"].Value);
                            DetailsModel.ProductAltUnit = 0;//ro.Cells["AltUOM"].Value.ToString() != "" ? Convert.ToInt32(ro.Cells["AltUOM"].Value.ToString()) : 0;
                            DetailsModel.ProductUnit = ro.Cells["ProductUnitId"].Value.ToString() != "" ? Convert.ToInt32(ro.Cells["ProductUnitId"].Value.ToString()) : 0;
                            DetailsModel.GodownId = ro.Cells["GodownId"].Value.ToString() != "" ? Convert.ToInt32(ro.Cells["GodownId"].Value.ToString()) : 0;
                            DetailsModel.AltQty = 0;
                            DetailsModel.Qty = Convert.ToDecimal(ro.Cells["Qty"].Value);
                            DetailsModel.SalesRate = Convert.ToDecimal(ro.Cells["Rate"].Value.ToString());
                            DetailsModel.NetAmount = Convert.ToDecimal(ro.Cells["NetAmt"].Value.ToString()); //- discountAamount) / Convert.ToDecimal(1.13);
                                                                                                             // DetailsModel.NetAmount = DetailsModel.NetAmount + discountAamount;
                            DetailsModel.TermAmount = Convert.ToDecimal(ro.Cells["TermAmt"].Value.ToString());
                            DetailsModel.BasicAmount = Convert.ToDecimal(ro.Cells["BasicAmt"].Value.ToString());
                            DetailsModel.LocalNetAmount = DetailsModel.NetAmount;
                            DetailsModel.AdditionalDesc = ro.Cells["Particular"].Value.ToString();
                            DetailsModel.ConversionRatio = 0;
                            DetailsModel.FreeQty = 0;
                            DetailsModel.FreeQtyUnit = 0;
                            DetailsModel.QuotationNo = "";
                            DetailsModel.QuotationSNo = 0;
                            DetailsModel.ResOrderBy = string.IsNullOrEmpty(TxtWaiter.Text) ? "" : TxtWaiter.Tag.ToString();
                            DetailsModel.ResOrderNotes = ro.Cells["Notes"].Value.ToString();
                            DetailsModel.ResOrderTime = Convert.ToDateTime(ro.Cells["OrderTime"].Value.ToString());
                            DetailsModel.ResKOTNo = (ro.Cells["Kot"].Value.ToString() != "") ? ro.Cells["Kot"].Value.ToString() : "";
                            DetailsModel.ResIsPrinted = ro.Cells["IsPrintKot"].Value.ToString() == "N" ? 'N' : 'Y';
                            DetailsModel.TermDetails = ro.Cells["TermsDetails"].Value.ToString();

                            DataTable dtSalesTerm = _objSalesBillingTerm.GetProductTerm();
                            foreach (DataRow roTerm in dtSalesTerm.Rows)
                            {
                                TermModel = new TermViewModel();
                                TermModel.VoucherNo = DetailsModel.VoucherNo;
                                TermModel.ProductId = DetailsModel.ProductId;
                                TermModel.Sno = DetailsModel.Sno;
                                TermModel.TermType = "P";
                                TermModel.TermId = Convert.ToInt32(roTerm["TermId"].ToString());

                                if (!string.IsNullOrEmpty(ro.Cells["TermsDetails"].Value.ToString()))
                                {
                                    string[] val = ro.Cells["TermsDetails"].Value.ToString().Split('|');
                                    string sign = val[0];
                                    string sn = val[1];
                                    string ratepercent = val[2];
                                    string amount = val[3];
                                    string[] arrsign = sign.Split(',');
                                    string[] arrsn = sn.Split(',');
                                    string[] arrRatepercent = ratepercent.Split(',');
                                    string[] arrAmount = amount.Split(',');

                                    for (int i = 0; i < arrsn.Length; i++)
                                    {
                                        if (arrsn[i].ToString() == roTerm["TermId"].ToString())
                                        {
                                            TermModel.STSign = arrsign[i].ToString();
                                            TermModel.TermRate = Convert.ToDecimal(arrRatepercent[i].ToString());
                                            TermModel.TermAmt = Convert.ToDecimal(arrAmount[i].ToString());
                                            TermModel.LocalTermAmt = 0;
                                        }
                                    }
                                }
                                _objSalesOrder.ModelTerms.Add(TermModel);
                            }
                            _objSalesOrder.ModelDetails.Add(DetailsModel);
                        }

                    }
                    else break;
                }
            }
            if (_Tag == "NEW" || _Tag == "" || _Tag == "DELETE" || _Tag == "TERMEDIT")
            {
                _objSalesOrder.Model.Tag = _Tag;
                _objSalesOrder.Model.EntryFromProject = "Restaurant";
                _objSalesOrder.Model.SalesmanId = string.IsNullOrEmpty(TxtMember.Text) ? 0 : Convert.ToInt32(TxtMember.Tag.ToString());
                foreach (DataRow roTerm in dtSalesBillTerm.Rows)
                {
                    TermModel = new TermViewModel();
                    TermModel.VoucherNo = _objSalesOrder.Model.VoucherNo;
                    TermModel.TermId = Convert.ToInt32(roTerm["TermId"].ToString());
                    TermModel.ProductId = 0;
                    TermModel.Sno = 0;
                    TermModel.TermType = "B";
                    TermModel.STSign = roTerm["Sign"].ToString();
                    if (TermModel.TermId == Convert.ToInt32(ClsGlobal.SBVatTermId))
                    {
                        TermModel.TermRate = Convert.ToDecimal(roTerm["Rate"].ToString());
                        TermModel.TermAmt = Convert.ToDecimal(TxtVat.Text);
                    }
                    else
                    {
                        TermModel.TermRate = TxtBillDiscountPercent.Text == "" ? 0 : Convert.ToDecimal(TxtBillDiscountPercent.Text);
                        TermModel.TermAmt = TxtBillDiscount.Text == "" ? 0 : Convert.ToDecimal(TxtBillDiscount.Text);
                    }
                    TermModel.LocalTermAmt = TermModel.TermAmt;

                    _objSalesOrder.ModelTerms.Add(TermModel);
                }
            }
            string result = _objSalesOrder.SaveSalesOrder();

        }
        private void GetOrderData(string InvoiceNo)
        {
            DataSet ds = _objSalesOrder.GetDataOrderVoucher(InvoiceNo);
            DataTable dtMaster = ds.Tables[0];
            DataTable dtDetails = ds.Tables[1];
            DataTable dtTerm = ds.Tables[2];

            foreach (DataRow drMaster in dtMaster.Rows)
            {
                TxtVoucherNo.Text = drMaster["VoucherNo"].ToString();
                this.voucherNo = TxtVoucherNo.Text;
                TxtMiti.Text = drMaster["VMiti"].ToString();
                TxtDate.Text = drMaster["VDate"].ToString();
                TxtMember.Text = drMaster["SalesmanDesc"].ToString();
                TxtMember.Tag = drMaster["SalesmanId"].ToString();
                CalculateOrderTime(Convert.ToDateTime(drMaster["VTime"].ToString()));

                TxtBillAmt.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(drMaster["NetAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();

                decimal ProductBasicAmount = 0, ProductTermAmount = 0, TotalQty = 0, TotalNetAmt = 0;

                foreach (DataRow drDetails in dtDetails.Rows)
                {
                    int CurrentRowNumber = Convert.ToInt32(drDetails["Sno"].ToString());
                    Grid.Rows[CurrentRowNumber - 1].Cells["SNo"].Value = drDetails["Sno"].ToString();
                    Grid.Rows[CurrentRowNumber - 1].Cells["ProductShortName"].Value = drDetails["ProductShortName"].ToString();
                    // string ss= drDetails["ProductDesc"].ToString().Substring(0, drDetails["ProductDesc"].ToString().Length - 2);
                    Grid.Rows[CurrentRowNumber - 1].Cells["Particular"].Value = (drDetails["ProductDesc"].ToString().Substring(0, drDetails["ProductDesc"].ToString().Length - 2) == "New Item") ? drDetails["AdditionalDesc"].ToString() : drDetails["ProductDesc"].ToString();
                    Grid.Rows[CurrentRowNumber - 1].Cells["ProductId"].Value = drDetails["ProductId"].ToString();
                    Grid.Rows[CurrentRowNumber - 1].Cells["GodownId"].Value = drDetails["GodownId"].ToString();
                    Grid.Rows[CurrentRowNumber - 1].Cells["Qty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["Qty"].ToString()), 1, ClsGlobal._QtyDecimalFormat).ToString();
                    Grid.Rows[CurrentRowNumber - 1].Cells["Unit"].Value = drDetails["ProductUnitDesc"].ToString();
                    Grid.Rows[CurrentRowNumber - 1].Cells["ProductUnitId"].Value = drDetails["ProductUnit"].ToString();
                    Grid.Rows[CurrentRowNumber - 1].Cells["Rate"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["SalesRate"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                    Grid.Rows[CurrentRowNumber - 1].Cells["BasicAmt"].Value = ClsGlobal.DecimalFormate((Convert.ToDecimal(drDetails["Qty"].ToString()) * Convert.ToDecimal(drDetails["SalesRate"].ToString())), 1, ClsGlobal._AmountDecimalFormat).ToString();
                    Grid.Rows[CurrentRowNumber - 1].Cells["GodownId"].Value = "";
                    Grid.Rows[CurrentRowNumber - 1].Cells["TermAmt"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["TermAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                    Grid.Rows[CurrentRowNumber - 1].Cells["NetAmt"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["NetAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                    Grid.Rows[CurrentRowNumber - 1].Cells["IsNote"].Value = Properties.Resources.note_16;
                    Grid.Rows[CurrentRowNumber - 1].Cells["Notes"].Value = drDetails["ResOrderNotes"].ToString();
                    Grid.Rows[CurrentRowNumber - 1].Cells["PrintKot"].Value = (drDetails["ResIsPrinted"].ToString() == "Y") ? null : Properties.Resources.printer_go;
                    Grid.Rows[CurrentRowNumber - 1].Cells["IsPrintKot"].Value = (drDetails["ResIsPrinted"].ToString() == "Y") ? "Y" : "N";
                    Grid.Rows[CurrentRowNumber - 1].Cells["RemoveRow"].Value = Properties.Resources.Delete_16;
                    Grid.Rows[CurrentRowNumber - 1].Cells["OrderTime"].Value = Convert.ToDateTime(drDetails["ResOrderTime"].ToString()).ToString("hh:mm:ss");
                    Grid.Rows[CurrentRowNumber - 1].Cells["TermsDetails"].Value = drDetails["TermDetails"].ToString();
                    Grid.Rows[CurrentRowNumber - 1].Cells["TaxFreeAmount"].Value = (drDetails["IsTaxable"].ToString() == "True") ? "0" : ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["NetAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                    Grid.Rows[CurrentRowNumber - 1].Cells["Kot"].Value = drDetails["ResKOTNo"].ToString();
                    if (CurrentRowNumber >= Grid.Rows.Count)
                        Grid.Rows.Add();

                    TxtKotNo.Text = drDetails["ResKOTNo"].ToString();
                    TxtWaiter.Text = drDetails["ResOrderBy"].ToString();
                    TxtWaiter.Tag = drDetails["ResOrderBy"].ToString();


                    ProductBasicAmount += Convert.ToDecimal(drDetails["BasicAmount"].ToString());
                    ProductTermAmount += Convert.ToDecimal(drDetails["TermAmount"].ToString());
                    TotalQty += Convert.ToDecimal(drDetails["Qty"].ToString());
                    TotalNetAmt += Convert.ToDecimal(drDetails["NetAmount"].ToString());
                }
                TxtTotalBasicAmt.Text = ClsGlobal.DecimalFormate(ProductBasicAmount, 1, ClsGlobal._AmountDecimalFormat).ToString();
                TxtTotalTermAmt.Text = ClsGlobal.DecimalFormate(ProductTermAmount, 1, ClsGlobal._AmountDecimalFormat).ToString();
                TxtTotalQty.Text = ClsGlobal.DecimalFormate(TotalQty, 1, ClsGlobal._AmountDecimalFormat).ToString();
                TxtTotalNetAmt.Text = ClsGlobal.DecimalFormate(TotalNetAmt, 1, ClsGlobal._AmountDecimalFormat).ToString();


                foreach (DataRow drTerms in dtTerm.Select("TermType='B'"))
                {
                    if (Convert.ToInt32(drTerms["TermId"].ToString()) == ClsGlobal.SBVatTermId)
                    {
                        TxtVat.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(drTerms["TermAmt"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                    }
                    else
                    {
                        TxtBillDiscountPercent.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(drTerms["TermRate"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                        TxtBillDiscount.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(drTerms["TermAmt"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                    }
                }
            }
        }
        private void GetInvoiceData(string InvoiceNo)
        {
            DataSet ds = _objSalesInvoice.GetDataRestaurantSalesVoucher(InvoiceNo);
            DataTable dtMaster = ds.Tables[0];
            DataTable dtDetails = ds.Tables[1];
            DataTable dtTerm = ds.Tables[2];

            foreach (DataRow drMaster in dtMaster.Rows)
            {
                TxtMiti.Text = drMaster["VMiti"].ToString();
                TxtDate.Text = drMaster["VDate"].ToString();

                decimal ProductBasicAmount = 0, ProductTermAmount = 0, TotalQty = 0;
                foreach (DataRow drDetails in dtDetails.Rows)
                {

                    int CurrentRowNumber = Convert.ToInt32(drDetails["Sno"].ToString());
                    Grid.Rows[CurrentRowNumber - 1].Cells["SNo"].Value = drDetails["Sno"].ToString();
                    Grid.Rows[CurrentRowNumber - 1].Cells["ProductShortName"].Value = drDetails["ProductShortName"].ToString();
                    Grid.Rows[CurrentRowNumber - 1].Cells["Particular"].Value = (drDetails["ProductDesc"].ToString().Substring(0, drDetails["ProductDesc"].ToString().Length - 2) == "New Item") ? drDetails["AdditionalDesc"].ToString() : drDetails["ProductDesc"].ToString();
                    Grid.Rows[CurrentRowNumber - 1].Cells["ProductId"].Value = drDetails["ProductId"].ToString();
                    Grid.Rows[CurrentRowNumber - 1].Cells["GodownId"].Value = drDetails["GodownId"].ToString();
                    Grid.Rows[CurrentRowNumber - 1].Cells["Qty"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["Qty"].ToString()), 1, ClsGlobal._QtyDecimalFormat).ToString();
                    Grid.Rows[CurrentRowNumber - 1].Cells["Unit"].Value = drDetails["ProductUnitDesc"].ToString();
                    Grid.Rows[CurrentRowNumber - 1].Cells["ProductUnitId"].Value = drDetails["ProductUnit"].ToString();
                    Grid.Rows[CurrentRowNumber - 1].Cells["Rate"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["SalesRate"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                    Grid.Rows[CurrentRowNumber - 1].Cells["BasicAmt"].Value = ClsGlobal.DecimalFormate((Convert.ToDecimal(drDetails["Qty"].ToString()) * Convert.ToDecimal(drDetails["SalesRate"].ToString())), 1, ClsGlobal._AmountDecimalFormat).ToString();
                    Grid.Rows[CurrentRowNumber - 1].Cells["GodownId"].Value = "";
                    Grid.Rows[CurrentRowNumber - 1].Cells["TermAmt"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["TermAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                    Grid.Rows[CurrentRowNumber - 1].Cells["NetAmt"].Value = ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["NetAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                    Grid.Rows[CurrentRowNumber - 1].Cells["IsNote"].Value = Properties.Resources.note_16;
                    Grid.Rows[CurrentRowNumber - 1].Cells["Notes"].Value = drDetails["ResOrderNotes"].ToString();
                    Grid.Rows[CurrentRowNumber - 1].Cells["PrintKot"].Value = (drDetails["ResIsPrinted"].ToString() == "Y") ? null : Properties.Resources.printer_go;
                    Grid.Rows[CurrentRowNumber - 1].Cells["IsPrintKot"].Value = (drDetails["ResIsPrinted"].ToString() == "Y") ? 'Y' : 'N';
                    Grid.Rows[CurrentRowNumber - 1].Cells["RemoveRow"].Value = Properties.Resources.Delete_16;
                    Grid.Rows[CurrentRowNumber - 1].Cells["OrderTime"].Value = Convert.ToDateTime(drDetails["ResOrderTime"].ToString()).ToString("hh:mm:ss");
                    Grid.Rows[CurrentRowNumber - 1].Cells["TermsDetails"].Value = drDetails["TermDetails"].ToString();
                    Grid.Rows[CurrentRowNumber - 1].Cells["TaxFreeAmount"].Value = (drDetails["IsTaxable"].ToString() == "True") ? "0" : ClsGlobal.DecimalFormate(Convert.ToDecimal(drDetails["NetAmount"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();

                    TxtKotNo.Text = drDetails["ResKOTNo"].ToString();
                    TxtWaiter.Text = drDetails["ResOrderBy"].ToString();
                    TxtWaiter.Tag = drDetails["ResOrderBy"].ToString();

                    ProductBasicAmount += Convert.ToDecimal(drDetails["BasicAmount"].ToString());
                    ProductTermAmount += Convert.ToDecimal(drDetails["TermAmount"].ToString());
                    TotalQty += Convert.ToDecimal(drDetails["Qty"].ToString());

                    Grid.Rows.Add();
                }
                TxtTotalBasicAmt.Text = ClsGlobal.DecimalFormate(ProductBasicAmount, 1, ClsGlobal._AmountDecimalFormat).ToString();
                TxtTotalTermAmt.Text = ClsGlobal.DecimalFormate(ProductTermAmount, 1, ClsGlobal._AmountDecimalFormat).ToString();
                TxtTotalQty.Text = ClsGlobal.DecimalFormate(TotalQty, 1, ClsGlobal._AmountDecimalFormat).ToString();

                foreach (DataRow drTerms in dtTerm.Select("TermType='B'"))
                {
                    if (Convert.ToInt32(drTerms["TermId"].ToString()) == ClsGlobal.SBVatTermId)
                    {
                        TxtVat.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(drTerms["TermAmt"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                    }
                    else
                    {
                        TxtBillDiscountPercent.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(drTerms["TermRate"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                        TxtBillDiscount.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(drTerms["TermAmt"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
                    }
                }
            }
        }
        private decimal GetIndivisualTermRate(string btnclick, string _ExistTermData)
        {
            decimal RatePercent = 0;
            string[] val = _ExistTermData.Split('|');
            string sign = val[0];
            string sn = val[1];
            string ratepercent = val[2];
            string amount = val[3];

            string[] arrsign = sign.Split(',');
            string[] arrsn = sn.Split(',');
            string[] arrRatepercent = ratepercent.Split(',');
            string[] arrAmount = amount.Split(',');

            for (int j = 0; j < arrsn.Length; j++)
            {
                if (btnclick == "Discount" && j == 0)
                    RatePercent = Convert.ToDecimal(arrRatepercent[0].ToString());
                else if (btnclick == "Service Charge" && j == 1)
                    RatePercent = Convert.ToDecimal(arrRatepercent[1].ToString());
            }
            return RatePercent;
        }
        private void ClearFld()
        {
            t.Start();
            _Tag = "NEW";
            Grid.Rows.Clear();
            int gridHeight = Grid.Height;
            for (int i = 0; i < gridHeight / 24; i++)
            {
                Grid.Rows.Add();
            }
            TxtMiti.Text = _objDate.GetMiti(_objDate.GetServerDate());
            TxtDate.Text = _objDate.GetServerDate().ToShortDateString();

            lblVoucherNo.Text = "Order No";
            TxtVoucherNo.Text = "";
            TxtInvoiceNo.Text = "";
            TxtWaiter.Text = "";
            TxtWaiter.Tag = 0;
            TxtMember.Text = "";
            TxtMember.Tag = "";
            TxtKotNo.Text = "";
            TxtTable.Text = "";
            TxtRemarks.Text = "";
            TxtOrderTime.Text = "";

            IndicateFocus.Location = new System.Drawing.Point(7, 34);
            IndicateFocus.Size = new System.Drawing.Size(48, 5);
            Utility.GetVoucherNo2("Sales Order", TxtVoucherNo, TxtProduct, "NEW", _SearchKey);
            TxtBillDiscount.Text = ClsGlobal.DecimalFormate(0, 1, ClsGlobal._AmountDecimalFormat).ToString();
            TxtBillDiscountPercent.Text = ClsGlobal.DecimalFormate(0, 1, ClsGlobal._AmountDecimalFormat).ToString();
            TxtBillAmt.Text = ClsGlobal.DecimalFormate(0, 1, ClsGlobal._AmountDecimalFormat).ToString();
            TxtTotalBasicAmt.Text = ClsGlobal.DecimalFormate(0, 1, ClsGlobal._AmountDecimalFormat).ToString();
            TxtTotalQty.Text = ClsGlobal.DecimalFormate(0, 1, ClsGlobal._AmountDecimalFormat).ToString();
            TxtTotalTermAmt.Text = ClsGlobal.DecimalFormate(0, 1, ClsGlobal._AmountDecimalFormat).ToString();
            TxtVat.Text = ClsGlobal.DecimalFormate(0, 1, ClsGlobal._AmountDecimalFormat).ToString();
            TxtTotalNetAmt.Text = ClsGlobal.DecimalFormate(0, 1, ClsGlobal._AmountDecimalFormat).ToString();
            TxtAdjustAmount.Text = ClsGlobal.DecimalFormate(0, 1, ClsGlobal._AmountDecimalFormat).ToString();
        }

        public void ControlEnableDisable(bool btn, bool fld)
        {
            TxtProduct.Enabled = true;
            Utility.EnableDesibleColor(TxtProduct, true);
            BtnProductSearch.Enabled = true;
            TxtVoucherNo.Enabled = false;
            Utility.EnableDesibleColor(TxtVoucherNo, false);
            BtnVoucherNoSearch.Enabled = false;
            TxtMiti.Enabled = false;
            Utility.EnableDesibleDateColor(TxtMiti, false);
            TxtDate.Enabled = false;
            Utility.EnableDesibleDateColor(TxtDate, false);
            TxtTable.Enabled = false;
            TxtMember.Enabled = fld;
            Utility.EnableDesibleColor(TxtMember, fld);
            BtnMemberSearch.Enabled = fld;
            TxtWaiter.Enabled = fld;
            Utility.EnableDesibleColor(TxtWaiter, fld);
            BtnWaiterSearch.Enabled = fld;


            BtnDiscount.Enabled = fld;
            BtnServiceCharge.Enabled = fld;
            BtnVat.Enabled = false;
            BtnRate.Enabled = fld;
            BtnQty.Enabled = fld;
            BtnNote.Enabled = fld;
            BtnPrintKOT.Enabled = fld;
            BtnSplitTable.Enabled = fld;
            BtnMergeTable.Enabled = fld;
            BtnTransferTable.Enabled = fld;
            Grid.Enabled = fld;
            TxtRemarks.Enabled = fld;
            Utility.EnableDesibleColor(TxtRemarks, fld);
            //BtnSaveBill.Enabled = fld;
            BtnCashPayment.Enabled = fld;
            BtnCardPayment.Enabled = fld;
            BtnCreditPayment.Enabled = fld;
            BtnCancelBill.Enabled = btn;
            BtnPrintOrder.Enabled = fld;
            BtnCancelOrder.Enabled = fld;
            BtnCancel.Enabled = fld;
            btnOk.Enabled = false;
            btnOk.Visible = false;
        }

        private void EnableDisableTerms(bool Val)
        {
            BtnDiscount.Enabled = Val;
            BtnServiceCharge.Enabled = Val;
            TxtBillDiscountPercent.Enabled = Val;
            Utility.EnableDesibleColor(TxtBillDiscountPercent, Val);
            TxtAdjustAmount.Enabled = Val;
            Utility.EnableDesibleColor(TxtAdjustAmount, Val);

        }
        #endregion

        #region --------------- Enabled Changed --------------------
        private void BtnDiscount_EnabledChanged(object sender, EventArgs e)
        {
            BtnDiscount.ForeColor = BtnDiscount.Enabled == false ? Color.DarkSeaGreen : Color.White;
        }

        private void BtnDiscount_Paint(object sender, PaintEventArgs e)
        {
            dynamic btn = (Button)sender;
            dynamic drawBrush = new SolidBrush(btn.ForeColor);
            dynamic sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            BtnDiscount.Text = string.Empty;
            e.Graphics.DrawString("DISCOUNT", btn.Font, drawBrush, e.ClipRectangle, sf);
            drawBrush.Dispose();
            sf.Dispose();
        }

        private void BtnServiceCharge_EnabledChanged(object sender, EventArgs e)
        {
            BtnServiceCharge.ForeColor = BtnServiceCharge.Enabled == false ? Color.DarkSeaGreen : Color.White;
        }

        private void BtnServiceCharge_Paint(object sender, PaintEventArgs e)
        {
            dynamic btn = (Button)sender;
            dynamic drawBrush = new SolidBrush(btn.ForeColor);
            dynamic sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            BtnServiceCharge.Text = string.Empty;
            e.Graphics.DrawString("SERVICE CHARGE", btn.Font, drawBrush, e.ClipRectangle, sf);
            drawBrush.Dispose();
            sf.Dispose();
        }

        private void BtnVat_EnabledChanged(object sender, EventArgs e)
        {
            BtnVat.ForeColor = BtnVat.Enabled == false ? Color.DarkSeaGreen : Color.White;
        }

        private void BtnVat_Paint(object sender, PaintEventArgs e)
        {
            dynamic btn = (Button)sender;
            dynamic drawBrush = new SolidBrush(btn.ForeColor);
            dynamic sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            BtnVat.Text = string.Empty;
            e.Graphics.DrawString("VAT", btn.Font, drawBrush, e.ClipRectangle, sf);
            drawBrush.Dispose();
            sf.Dispose();
        }

        private void BtnRate_EnabledChanged(object sender, EventArgs e)
        {
            BtnRate.ForeColor = BtnRate.Enabled == false ? Color.DarkSeaGreen : Color.White;
        }

        private void BtnRate_Paint(object sender, PaintEventArgs e)
        {
            dynamic btn = (Button)sender;
            dynamic drawBrush = new SolidBrush(btn.ForeColor);
            dynamic sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            BtnRate.Text = string.Empty;
            e.Graphics.DrawString("RATE", btn.Font, drawBrush, e.ClipRectangle, sf);
            drawBrush.Dispose();
            sf.Dispose();
        }

        private void BtnQty_EnabledChanged(object sender, EventArgs e)
        {
            BtnQty.ForeColor = BtnQty.Enabled == false ? Color.DarkSeaGreen : Color.White;
        }

        private void BtnQty_Paint(object sender, PaintEventArgs e)
        {
            dynamic btn = (Button)sender;
            dynamic drawBrush = new SolidBrush(btn.ForeColor);
            dynamic sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            BtnQty.Text = string.Empty;
            e.Graphics.DrawString("QTY", btn.Font, drawBrush, e.ClipRectangle, sf);
            drawBrush.Dispose();
            sf.Dispose();
        }

        private void BtnSplitTable_EnabledChanged(object sender, EventArgs e)
        {
            BtnSplitTable.ForeColor = BtnSplitTable.Enabled == false ? Color.DarkSeaGreen : Color.White;
        }

        private void BtnSplitTable_Paint(object sender, PaintEventArgs e)
        {
            dynamic btn = (Button)sender;
            dynamic drawBrush = new SolidBrush(btn.ForeColor);
            dynamic sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            BtnSplitTable.Text = string.Empty;
            e.Graphics.DrawString("SPLIT TABLE", btn.Font, drawBrush, e.ClipRectangle, sf);
            drawBrush.Dispose();
            sf.Dispose();
        }

        private void BtnMergeTable_EnabledChanged(object sender, EventArgs e)
        {
            BtnMergeTable.ForeColor = BtnMergeTable.Enabled == false ? Color.DarkSeaGreen : Color.White;
        }

        private void BtnMergeTable_Paint(object sender, PaintEventArgs e)
        {
            dynamic btn = (Button)sender;
            dynamic drawBrush = new SolidBrush(btn.ForeColor);
            dynamic sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            BtnMergeTable.Text = string.Empty;
            e.Graphics.DrawString("MERGE TABLE", btn.Font, drawBrush, e.ClipRectangle, sf);
            drawBrush.Dispose();
            sf.Dispose();
        }

        private void BtnTransferTable_EnabledChanged(object sender, EventArgs e)
        {
            BtnTransferTable.ForeColor = BtnTransferTable.Enabled == false ? Color.DarkSeaGreen : Color.White;
        }

        private void BtnTransferTable_Paint(object sender, PaintEventArgs e)
        {
            dynamic btn = (Button)sender;
            dynamic drawBrush = new SolidBrush(btn.ForeColor);
            dynamic sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            BtnTransferTable.Text = string.Empty;
            e.Graphics.DrawString("TRANSFER TABLE", btn.Font, drawBrush, e.ClipRectangle, sf);
            drawBrush.Dispose();
            sf.Dispose();
        }

        #endregion

        private void TxtBillDiscountPercent_Validating(object sender, CancelEventArgs e)
        {
            decimal BasicAmount = 0;
            decimal.TryParse(TxtBillDiscountPercent.Text, out decimal discpercent);
            if (discpercent > 100)
            {
                MessageBox.Show("Discount Percent Cannot be greater than 100...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }

            BasicAmount = Convert.ToDecimal(TxtTotalBasicAmt.Text) + Convert.ToDecimal(TxtTotalTermAmt.Text);
            decimal.TryParse(TxtBillDiscount.Text, out decimal billdiscountamount);
            TxtBillDiscount.Text = ClsGlobal.DecimalFormate((BasicAmount * discpercent / 100), 1, ClsGlobal._AmountDecimalFormat).ToString();
            TxtAdjustAmount.Text = ClsGlobal.DecimalFormate(0, 1, ClsGlobal._AmountDecimalFormat).ToString();
            CalculateOnBillDiscount();
            BtnCashPayment.Focus();
        }

        private void TxtBillDiscount_Validating(object sender, CancelEventArgs e)
        {
            decimal.TryParse(TxtBillDiscount.Text, out decimal billdiscount);
            if (billdiscount > Convert.ToDecimal(TxtBillAmt.Text))
            {
                MessageBox.Show("Discount Amount Cannot be greater than Bill Amount...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
            TxtBillDiscountPercent.Text = "0";
            CalculateOnBillDiscount();
            BtnCashPayment.Focus();
        }

        private void TxtMember_Validating(object sender, CancelEventArgs e)
        {
            if (this.ActiveControl == TxtMember) return;
            if (TxtMember.Enabled == false) return;
            if (!string.IsNullOrEmpty(TxtMember.Text))
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtMember.Text.Trim(), "Salesman", "SalesmanDesc", "SalesManId") != 1)
                {
                    MessageBox.Show("Member Not Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    TxtMember.Text = "";
                    return;
                }
            }
            DataTable dt = (!string.IsNullOrEmpty(TxtMember.Text)) ? (_objSalesInvoice.GetMemberPercent(TxtMember.Text)) : null;
            if (dt != null && dt.Rows.Count > 0)
            {
                if (Convert.ToDateTime(dt.Rows[0]["MemberFromDate"].ToString()) < DateTime.Now && Convert.ToDateTime(dt.Rows[0]["MemberToDate"].ToString()) > DateTime.Now)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["DiscountPercent"].ToString()))
                    {
                        TxtBillDiscountPercent.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["DiscountPercent"].ToString()), 1, ClsGlobal._AmountDecimalFormat);
                    }
                }
                else
                {
                    MessageBox.Show("'" + TxtMember.Text + "' Member ID is already expire...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    TxtMember.Text = "";
                    return;
                }
            }
            else
            {
                TxtBillDiscountPercent.Text = ClsGlobal.DecimalFormate(0, 1, ClsGlobal._AmountDecimalFormat);
                //CalculateOnBillDiscount();
            }
            decimal.TryParse(TxtBillDiscountPercent.Text, out decimal discpercent);
            decimal BasicAmount = Convert.ToDecimal(TxtTotalBasicAmt.Text) + Convert.ToDecimal(TxtTotalTermAmt.Text);
            TxtBillDiscount.Text = ClsGlobal.DecimalFormate((BasicAmount * discpercent / 100), 1, ClsGlobal._AmountDecimalFormat).ToString();
            CalculateOnBillDiscount();
        }

        private void TxtWaiter_Validating(object sender, CancelEventArgs e)
        {
            if (this.ActiveControl == TxtWaiter) return;
            if (TxtWaiter.Enabled == false) return;
            if (string.IsNullOrEmpty(TxtWaiter.Text))
            {
                MessageBox.Show("Waiter cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                TxtWaiter.Focus();
                return;
            }
            else if (_objUserMaster.CheckDuplicateUserCode(TxtWaiter.Text) != 1)
            {
                MessageBox.Show("Waiter Not Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                TxtWaiter.Text = "";
                return;
            }
        }

        private void BtnVoucherNoSearch_Click(object sender, EventArgs e)
        {

            Common.PickList frmPickList = new Common.PickList("SalesVoucher", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtInvoiceNo.Text = frmPickList.SelectedList[0]["VoucherNo"].ToString().Trim();
                    TxtVoucherNo.Text = frmPickList.SelectedList[0]["VoucherNo"].ToString().Trim();
                    TxtVoucherNo.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in SalesInvoice !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtVoucherNo.Focus();
                return;
            }
            _SearchKey = "";
            TxtVoucherNo.Focus();

        }

        private void TxtVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1")
            {
                _SearchKey = string.Empty;
                BtnVoucherNoSearch.PerformClick();
            }
            else
            {
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtVoucherNo, BtnVoucherNoSearch, true);
            }
        }


        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (Grid.Columns[e.ColumnIndex].Name == "Particular")
                {
                    if (Grid.Rows[e.RowIndex].Cells["Particular"].Value.ToString().Substring(0, Grid.Rows[e.RowIndex].Cells["Particular"].Value.ToString().Length - 2) == "New Item")
                    {
                        FrmDialogBox frm = new FrmDialogBox("Product", "Product:", Grid.CurrentRow.Cells["Particular"].Value.ToString());
                        frm.ShowDialog();
                        if (!string.IsNullOrEmpty(frm._textDialog.Trim()))
                        {
                            Grid.CurrentRow.Cells["Particular"].Value = (frm._textDialog.Trim() != "") ? frm._textDialog.Trim() : Grid.CurrentRow.Cells["Particular"].Value;
                            //_objProduct.UpdateProductPrintingName(Grid.Rows[e.RowIndex].Cells["ProductId"].Value.ToString(), Grid.Rows[e.RowIndex].Cells["Particular"].Value.ToString());
                            _objSalesOrder.DeleteOrderDetails(this.voucherNo);
                            CurrentRowAdd = -1;
                            TotalCalculate();
                            SaveSalesOrder();
                        }
                    }
                }
            }
        }

        private void TxtKotNo_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtKotNo.Text))
            {
                DataTable dtKot = _objKOt.GetDataKOTAssign(Convert.ToDateTime(TxtDate.Text));
                if (dtKot.Rows.Count > 0)
                {
                    foreach (DataRow row in dtKot.Rows)
                    {
                        if ((Convert.ToInt32(row["StartNo"].ToString()) > Convert.ToInt32(this.TxtKotNo.Text) ? false : Convert.ToInt32(row["EndNo"].ToString()) >= Convert.ToInt32(this.TxtKotNo.Text)))
                        {
                            TxtWaiter.Text = row["Waiter"].ToString();
                            TxtWaiter.Tag = row["Waiter"].ToString();
                            TxtWaiter.Enabled = false;
                            TxtProduct.Focus();
                        }
                    }
                    if (string.IsNullOrEmpty(this.TxtWaiter.Text))
                    {
                        MessageBox.Show("This Kot slip is not assign to any Waiter...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        TxtKotNo.Focus();
                        return;
                    }

                }
            }
        }

        private void TxtAdjustAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtAdjustAmount_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtAdjustAmount.Text))
            {
                if (Convert.ToDecimal(TxtAdjustAmount.Text) > 0)
                {
                    TxtBillDiscountPercent.Text = "0";
                    TxtBillDiscount.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(TxtAdjustAmount.Text) / Convert.ToDecimal(1.13), 1, ClsGlobal._AmountDecimalFormat).ToString();
                    CalculateOnBillDiscount();
                }
            }
        }

        private void TxtTotalBasicAmt_TextChanged(object sender, EventArgs e)
        {

        }

        private void myTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtTotalQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void TxtBillDiscountPercent_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void TxtVoucherNo_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtInvoiceNo.Text))
            {
                Grid.Rows.Clear();
                Grid.Rows.Add();
                GetInvoiceData(TxtInvoiceNo.Text);
                TxtRemarks.Enabled = true;
                TxtRemarks.Focus();
            }
            if (isBillcancel == true) btnOk.Enabled = true;
        }

        private void TxtRemarks_Validating(object sender, CancelEventArgs e)
        {
            if (_Tag == "" || this.ActiveControl == TxtRemarks) return;
            if (this._Tag == "BILL CANCEL")
            {
                if (string.IsNullOrEmpty(TxtRemarks.Text))
                {
                    MessageBox.Show("Please provide remarks before bill cancel...!", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
                else
                {
                    btnOk.Enabled = true;
                    btnOk.Focus();
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtRemarks.Text))
            {
                MessageBox.Show("Please provide remarks before bill cancel...!", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtRemarks.Focus();
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Do you want to cancel bill No:'" + TxtVoucherNo.Text + "'?", "Mr.Solution", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string cancelbill = _objSalesInvoice.BillCancel(TxtInvoiceNo.Text);
                if (!string.IsNullOrEmpty(cancelbill))
                {
                    MessageBox.Show("Invoice No: '" + cancelbill + "' Cancel Successfully...!", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFld();
                    ControlEnableDisable(false, true);
                    this.Text = "Restaurant Billing [NEW]";
                    _Tag = "NEW";
                    BtnCancel.PerformClick();
                }
            }
            isBillcancel = false;
        }

        private void TxtInvoiceNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (Grid.Rows[Grid.CurrentRow.Index].Cells["ProductId"].Value != null)
                {
                    var dialogResult = MessageBox.Show("Are you sure want to cancel product : " + Grid["Particular", Grid.CurrentRow.Index].Value.ToString() + "...?", "Mr.Solution", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (Grid.CurrentRow.Index > 0 || Grid.Rows[1].Cells["ProductId"].Value != null)
                        {
                            _objSalesOrder.DeleteOrderDetails(this.voucherNo, "PartialCancel", (Grid.CurrentRow.Index + 1).ToString());
                            Grid.Rows.RemoveAt(Grid.CurrentRow.Index);
                            CurrentRowAdd = -1;
                            TotalCalculate();
                            SaveSalesOrder();
                            this._Tag = "";
                        }
                        else if (Grid.CurrentRow.Index == 0 && Grid.Rows[1].Cells["ProductId"].Value == null)
                        {
                            MessageBox.Show("You must cancel Order in order to delete single row data...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
        }

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (Grid.Columns[e.ColumnIndex].Name == "RemoveRow")
                {
                    Grid.Focus();

                    var dialogResult = MessageBox.Show("Are you sure want to cancel product : " + Grid["Particular", Grid.CurrentRow.Index].Value.ToString() + "...?", "Mr.Solution", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (e.RowIndex > 0 || Grid.Rows[1].Cells["ProductId"].Value != null)
                        {
                            _objSalesOrder.DeleteOrderDetails(this.voucherNo, "PartialCancel", (e.RowIndex + 1).ToString());
                            Grid.Rows.RemoveAt(e.RowIndex);
                            CurrentRowAdd = -1;
                            TotalCalculate();
                            SaveSalesOrder();
                            this._Tag = "";
                        }
                        else if (e.RowIndex == 0 && Grid.Rows[1].Cells["ProductId"].Value == null)
                        {
                            MessageBox.Show("You must cancel Order in order to delete single row data...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
                if (Grid.Columns[e.ColumnIndex].Name == "IsNote")
                {
                    Grid.Focus();
                    BtnNote.PerformClick();
                }
                if (Grid.Columns[e.ColumnIndex].Name == "PrintKot")
                {
                    _IsSaveAndPrint = _objDocPrintSetting.CheckIsSaveAndPrint("KOT");
                    DataTable dtcounter = _counter.GetDataCounter(Convert.ToInt32(ClsGlobal.CounterId));
                    if (dtcounter.Rows.Count > 0)
                        _PrinterName = dtcounter.Rows[0]["PrinterName"].ToString();
                    if (_IsSaveAndPrint == 1)
                    {
                        DataAccessLayer.DLLPrinting.DllInvoicePrint a = new DataAccessLayer.DLLPrinting.DllInvoicePrint(TxtVoucherNo.Text, _PrinterName, "KOT/BOTdll", ClsGlobal.LoginUserCode, ClsGlobal.TodayDateTime, 1);
                    }
                    Grid.Focus();
                    if (Grid["ProductId", Grid.CurrentRow.Index].Value != null && Grid["IsPrintKot", Grid.CurrentRow.Index].Value.ToString() == "N")
                    {
                        Grid.CurrentRow.Cells["IsPrintKot"].Value = "Y";
                    }
                    _objSalesOrder.DeleteOrderDetails(this.voucherNo);
                    CurrentRowAdd = -1;
                    TotalCalculate();
                    SaveSalesOrder();
                    GetOrderData(TxtVoucherNo.Text);
                }
            }
        }
        private void CalculateOrderTime(DateTime OrderTime)
        {
            var CurrentTime = DateTime.Now;
            var LastOrderTime = OrderTime;
            var diff = CurrentTime.Subtract(LastOrderTime);
            TxtOrderTime.Text = String.Format("{0}:{1}:{2}", diff.Hours, diff.Minutes, diff.Seconds);
        }
    }
}
