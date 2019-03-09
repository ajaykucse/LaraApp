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

namespace acmedesktop.ARAPReport
{
    public partial class FilterRptSalesOrderRegister : Form
    {
        public string ButtonAction = "";
        public FilterRptSalesOrderRegister()
        {
            ButtonAction = "";
            InitializeComponent();
        }

        private void FilterRptSalesOrderRegister_Load(object sender, EventArgs e)
        {
            CmbDateOption.SelectedIndex = 0;
            CmbSortOn.SelectedIndex = 0;
            CmbCurrency.SelectedIndex = 0;
            CmbInvoiceType.SelectedIndex = 0;
            CmbNarration.SelectedIndex = 0;
            ClsGlobal.LoadDateByOption("Today", TxtFromDate, TxtToDate);
        }

        private void FilterRptSalesOrderRegister_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
            else if (e.KeyCode == Keys.Escape)
                BtnCancel.PerformClick();
        }
		private void TxtFromDate_Validating(object sender, CancelEventArgs e)
		{
			if (ActiveControl == TxtFromDate) return;
			if (TxtFromDate.Text != "  /  /")
				ClsGlobal.DateValidation(TxtFromDate, null);
		}

		private void TxtToDate_Validating(object sender, CancelEventArgs e)
		{
			if (ActiveControl == TxtToDate) return;
			if (TxtToDate.Text != "  /  /")
				ClsGlobal.DateValidation(TxtToDate, null);
		}
		private void BtnOk_Click(object sender, EventArgs e)
        {
            if (TxtFromDate.Text == "  /  /")
            {
                MessageBox.Show("From Date Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtFromDate.Focus();
                return;
            }
            else if (TxtToDate.Text == "  /  /")
            {
                MessageBox.Show("To Date Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtToDate.Focus();
                return;
            }
            ButtonAction = "OK";
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmbDateOption_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ClsGlobal.LoadDateByOption(CmbDateOption.Text, TxtFromDate, TxtToDate);
        }

        private void CmbDateOption_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
                SendKeys.Send("{F4}");
        }

        private void ChkDetails_CheckStateChanged(object sender, EventArgs e)
        {
            if (ChkDetails.Checked == true)
            {
                ChkHorizontal.Enabled = true;
            }
            else
            {
                ChkHorizontal.Enabled = false;
                ChkHorizontal.Checked = false;
            }
        }
    }
}
