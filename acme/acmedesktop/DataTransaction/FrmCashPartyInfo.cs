using acmedesktop.Common;
using acmedesktop.MasterSetup;
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

namespace acmedesktop.DataTransaction
{
    public partial class FrmCashPartyInfo : Form
	{
		string _SearchKey = "";
        public FrmCashPartyInfo()
        {
            InitializeComponent();
        }
        
        private void FrmCashPartyInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
            else if (e.KeyCode == Keys.Escape)
                BtnCancel.PerformClick();
        }

        private void FrmCashPartyInfo_Load(object sender, EventArgs e)
        {
            TxtPartyName.Text = DataAccessLayer.DataTransaction.Sales.CashPartyViewModel.PartyName;
            TxtPartyAddress.Text = DataAccessLayer.DataTransaction.Sales.CashPartyViewModel.PartyAddress;
            TxtPartyVatPanNo.Text = DataAccessLayer.DataTransaction.Sales.CashPartyViewModel.PartyVatNo;
            TxtChequeNo.Text = DataAccessLayer.DataTransaction.Sales.CashPartyViewModel.ChequeNo;
            TxtChequeDate.Text =DataAccessLayer.DataTransaction.Sales.CashPartyViewModel.ChequeDate.ToString();
            TxtPartyMobileNo.Text = DataAccessLayer.DataTransaction.Sales.CashPartyViewModel.PartyMobileNo;
            TxtPartyEmail.Text = DataAccessLayer.DataTransaction.Sales.CashPartyViewModel.PartyEmail;
        }

        private void TxtPartyName_KeyDown(object sender, KeyEventArgs e)
        {
			if (e.KeyData == (Keys.N | Keys.Control))
			{
				FrmGeneralledger frm = new FrmGeneralledger();
				frm._IsNew = 'Y';
				frm.ShowDialog();
				TxtPartyName.Text = frm._NewLedger;
				TxtPartyName.Tag = frm._LedgerId;
			}
			else
			{
				_SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
				ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtPartyName, BtnPartySearch, false);
			}
		}

        private void TxtPartyName_Validating(object sender, CancelEventArgs e)
        {

        }

        private void BtnPartySearch_Click(object sender, EventArgs e)
        {
            ClsButtonClick.PartyInfoBtnClick("", TxtPartyName, "SALES", e);
        }

        private void TxtChequeNo_Validating(object sender, CancelEventArgs e)
        {

        }

        private void TxtChequeDate_Validating(object sender, CancelEventArgs e)
        {

        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            DataAccessLayer.DataTransaction.Sales.CashPartyViewModel.PartyName = TxtPartyName.Text;
            DataAccessLayer.DataTransaction.Sales.CashPartyViewModel.PartyAddress = TxtPartyAddress.Text;
            DataAccessLayer.DataTransaction.Sales.CashPartyViewModel.PartyVatNo = TxtPartyVatPanNo.Text;
            if (!string.IsNullOrEmpty(TxtChequeNo.Text.Trim()))
            {
                DataAccessLayer.DataTransaction.Sales.CashPartyViewModel.ChequeNo = TxtChequeNo.Text;
                DataAccessLayer.DataTransaction.Sales.CashPartyViewModel.ChequeDate = Convert.ToDateTime(TxtChequeDate.Text);
            }
            DataAccessLayer.DataTransaction.Sales.CashPartyViewModel.PartyMobileNo = TxtPartyMobileNo.Text;
            DataAccessLayer.DataTransaction.Sales.CashPartyViewModel.PartyEmail = TxtPartyEmail.Text;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

		private void TxtPartyVatPanNo_Validating(object sender, CancelEventArgs e)
		{
			if(!string.IsNullOrEmpty (TxtPartyVatPanNo.Text))
			{
				if(TxtPartyVatPanNo.Text.Length !=9)
				{
					MessageBox.Show("Vat/Pan No must be nine digit...!", "Mr solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
					TxtPartyVatPanNo.Focus();
					return;
				}
			}
		}
	}
}
