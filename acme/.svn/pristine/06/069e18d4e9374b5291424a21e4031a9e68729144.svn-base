using DataAccessLayer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer.MasterSetup;

namespace acmedesktop.DataTransaction.BillingTransaction
{
    public partial class FrmInvoiceReceipt : Form
    {
        ClsGeneralLedger _objGeneralLedger = new ClsGeneralLedger();
        public string _billamount = "", _tenderamount = "", _returnamount = "", _clickbutton="",_customerName="",_partyName="",_Address="",_vatNo="";
        string _SearchKey = "";
        string _PaymentType = "";
        public int ledgerId = 0;
        public FrmInvoiceReceipt( string paymentType, string billamount)
        {
            InitializeComponent();
            _PaymentType = paymentType;
            _billamount = billamount;
            if(paymentType=="Credit" || paymentType == "Card")
            {
                TxtCustomer.Enabled = true;
                TxtTenderAmount.Enabled = false;
                TxtCustomer.TabStop = true;
                TxtCustomer.Focus();
            }
            else
            {
                TxtCustomer.Enabled = false;
                TxtCustomer.TabStop = false ;
                BtnSearchCustomer.Enabled = false;
                TxtTenderAmount.Enabled = true;
                TxtTenderAmount.Focus();
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            _tenderamount = (TxtTenderAmount.Text=="") ? "0" : TxtTenderAmount.Text;
            _returnamount = (TxtReturnAmount.Text == "") ? "0" : TxtReturnAmount.Text;
            _customerName = TxtCustomer.Text;
            ledgerId = Convert.ToInt32 (TxtCustomer.Tag);
            _partyName = TxtPartyName.Text;
            _Address = TxtAddress.Text;
            _vatNo = TxtVat.Text;
            _clickbutton = "Ok";
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
             _tenderamount = ""; _returnamount = ""; _customerName = ""; _partyName = ""; _Address = ""; _vatNo = "";
            _clickbutton = "Cancel";
            this.Close();
        }

        private void FrmInvoiceReceipt_Load(object sender, EventArgs e)
        {
            if (_PaymentType == "Cash")
            {
                this.Text = "Sales Invoice Receipt (Cash)";
                DataTable dtCustomer = _objGeneralLedger.GetDataGeneralLedger(Convert.ToInt32(ClsGlobal.CashLedgerId));
                TxtCustomer.Text = dtCustomer.Rows[0]["GlDesc"].ToString();
                TxtCustomer.Tag = Convert.ToInt32(ClsGlobal.CashLedgerId);
            }
            else if (_PaymentType == "Card")
            {
                this.Text = "Sales Invoice Receipt (Card)";
                DataTable dtCustomer = _objGeneralLedger.GetDataGeneralLedger(Convert.ToInt32(ClsGlobal.CardLedgerId));
                TxtCustomer.Text = dtCustomer.Rows[0]["GlDesc"].ToString();
                TxtCustomer.Tag = Convert.ToInt32(ClsGlobal.CardLedgerId);
                // TxtCustomer.Text = "Card";
            }
            else if (_PaymentType == "Credit")
            {
                this.Text = "Sales Invoice Receipt (Credit)";
                TxtCustomer.Text = "";
            }
            TxtBillAmount.Text = _billamount.ToString ();
            TxtTenderAmount.Focus();
        }

        private void TxtCustomer_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                MasterSetup.FrmGeneralledger frm = new MasterSetup.FrmGeneralledger();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtCustomer.Text = frm._NewLedger;
                TxtCustomer.Tag = frm._LedgerId;
            }
            else
            {
				_SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
				ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtCustomer, BtnSearchCustomer, false);
            }
        }

        private void TxtTenderAmount_TextChanged(object sender, EventArgs e)
        {
            decimal.TryParse(TxtTenderAmount.Text, out decimal tenderamount);
            TxtReturnAmount.Text = (tenderamount - Convert.ToDecimal(TxtBillAmount.Text)).ToString();
        }

        

        private void FrmInvoiceReceipt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
            else if (e.KeyCode == Keys.Escape)
            {
                if (BtnCancel.Enabled == true)
                {
                    BtnCancel.PerformClick();
                }
                else
                    this.Close();
                DialogResult = DialogResult.Cancel;
                return;
            }
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
            TxtCustomer.Focus();
        }

        private void BtnSearchCustomer_Click(object sender, EventArgs e)
        {
            string GLCategory = (_PaymentType == "Credit") ? "Customer,Both" : "Bank Book";
            Common.PickList frmPickList = new Common.PickList("Generalledger."+ GLCategory, _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtCustomer.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
                    TxtCustomer.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["ledgerId"].ToString().Trim());
                    TxtCustomer.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Ledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtCustomer.Focus();
                return;
            }
            TxtCustomer.Focus();
        }

        private void TxtTenderAmount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtTenderAmount.Text))
            {
                MessageBox.Show("Tender Amount  Cannot Left Balank...!", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                TxtTenderAmount.Focus();
                return;
            }
            else if (Convert.ToDecimal(TxtTenderAmount.Text) < Convert.ToDecimal(TxtBillAmount.Text))
            {
                MessageBox.Show("Tender Amount Cannot be less then Bill Amount...!", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                TxtTenderAmount.Focus();
                return;
            }
            TxtReturnAmount.Text = (Convert.ToDecimal(TxtTenderAmount.Text) - Convert.ToDecimal(TxtBillAmount.Text)).ToString();
        }

        private void TxtVat_Validating(object sender, CancelEventArgs e)
        {
            if(!string.IsNullOrEmpty(TxtVat.Text ))
            {
                if(TxtVat.Text.Length <9)
                {
                    MessageBox.Show("Vat/Pan No Must Be Nine Digit...!", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    TxtVat.Focus();
                    return;
                }
            }
        }

        private void TxtCustomer_Validating(object sender, CancelEventArgs e)
        {
            if ( this.ActiveControl == TxtCustomer) return;
            if (TxtCustomer.Enabled == false) return;
            if (TxtCustomer.Text.Trim() == "")
            {
                MessageBox.Show("Customer Cannot Left Blank...!", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                TxtCustomer.Focus();
                return;
            }
        }

        private void TxtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtCustomer, BtnSearchCustomer, false);
        }
    }
}
