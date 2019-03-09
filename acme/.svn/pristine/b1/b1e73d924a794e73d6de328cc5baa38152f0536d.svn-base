using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DataAccessLayer.Common;
using DataAccessLayer.MasterSetup;
namespace acmedesktop.MasterSetup
{
    public partial class FrmSalesTerm : Form
    {
        private ClsSalesBillingTerm _objTerm = new ClsSalesBillingTerm();
        ClsCommon _objCommon = new ClsCommon();
        public int _TermId;
        public char _IsNew;
        private string _Tag = "", _SearchKey = "", result ="";
        DataTable NavMenuDataList; int NavMenuDataRowPosition = 0;

        public FrmSalesTerm()
        {
            InitializeComponent();
        }

        private void FrmSalesTerm_Load(object sender, EventArgs e)
        {
            NavMenuDataList = _objTerm.GetDataSalesBillingTerm(0);
            ControlEnableDisable(true, false);
            ClearFld();
            if (_IsNew == 'Y')
            {
                BtnEdit.Enabled = false;
                BtnDelete.Enabled = false;
                BtnFirstData.Enabled = false;
                BtnNextData.Enabled = false;
                BtnPreviousData.Enabled = false;
                BtnLastData.Enabled = false;
            }
           
            BtnNew.Focus();
            CmbTermType.SelectedIndex = 0;
            CmbSTSign.SelectedIndex = 0;
            CmbCategory.SelectedIndex = 0;
            CmbBillwise.SelectedIndex = 0;
            CmbBasis.SelectedIndex = 0;
        }

        private void FrmSalesTerm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (BtnCancel.Enabled == true)
                {
                    _Tag = "";
                    BtnCancel.PerformClick();
                }
                else
                {
                    BtnExit.PerformClick();
                }

                DialogResult = DialogResult.Cancel;
                return;
            }
        }

        public void ControlEnableDisable(bool trb, bool fld)
        {
            BtnNew.Enabled = trb;
            BtnEdit.Enabled = trb;
            BtnDelete.Enabled = trb;
            BtnExit.Enabled = trb;
            BtnFirstData.Enabled = trb;
            BtnNextData.Enabled = trb;
            BtnLastData.Enabled = trb;
            BtnPreviousData.Enabled = trb;
            
            TxtDescription.Enabled = fld;
            BtnSearcDescription.Enabled = fld;
            Utility.EnableDesibleColor(TxtDescription, fld);
            TxtTermPosition .Enabled = fld;
            Utility.EnableDesibleColor(TxtTermPosition, fld);
            ChkActive.Enabled = fld;
            ChkProfitability.Enabled = fld;
            ChkSupressZero.Enabled = fld;
            TxtTermRate .Enabled = fld;
            Utility.EnableDesibleColor(TxtTermRate, fld);
            TxtFormula.Enabled = fld;
            Utility.EnableDesibleColor(TxtFormula, fld);

            CmbBasis .Enabled = fld;
            Utility.EnableDesibleComboBoxColor(CmbBasis, fld);

            CmbBillwise.Enabled = fld;
            Utility.EnableDesibleComboBoxColor(CmbBillwise, fld);

            CmbCategory.Enabled = fld;
            Utility.EnableDesibleComboBoxColor(CmbCategory, fld);

            CmbSTSign.Enabled = fld;
            Utility.EnableDesibleComboBoxColor(CmbSTSign, fld);

            TxtLedger.Enabled = fld;
            BtnLedgerSearch.Enabled = fld;
            Utility.EnableDesibleColor(TxtLedger, fld);

            CmbTermType.Enabled = fld;
            Utility.EnableDesibleComboBoxColor(CmbTermType, fld);

            BtnSave.Enabled = fld;
            BtnCancel.Enabled = fld;

            if (BtnNew.Enabled == true)
            {
                BtnNew.Focus();
            }
            else if (TxtDescription.Enabled == true)
            {
                TxtDescription.Focus();
            }
        }

        private void ClearFld()
        {
            this._TermId = 0;
            TxtLedger.Tag = "";
            TxtDescription.Tag = "0";
            foreach (Control control in PanelContainer.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
            }
            TxtDescription.Focus();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            _Tag = "NEW";
            ControlEnableDisable(false, true);
            Text = "Sales Billing Term [NEW]";
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _Tag = "EDIT";
            ControlEnableDisable(false, true);
            Text = "Sales Billing Term [EDIT]";
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _Tag = "DELETE";
            ControlEnableDisable(false, false);
            Text = "Sales Billing Term [DELETE]";
            TxtDescription.Enabled = true;
            BtnSearcDescription.Enabled = true;
            TxtDescription.Focus();
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
        }
        private void BtnFirstData_Click(object sender, EventArgs e)
        {
            if (NavMenuDataList.Rows.Count > 0)
            {
                this.NavMenuDataRowPosition = 0;
                DataTable dt = _objTerm.GetDataSalesBillingTerm(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["TermId"].ToString()));
                SetData(dt);
            }
            else
            {
                MessageBox.Show("No record is found to display.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnNextData_Click(object sender, EventArgs e)
        {
            if (NavMenuDataList.Rows.Count == 0)
            {
                MessageBox.Show("No record is found to display.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.NavMenuDataRowPosition < NavMenuDataList.Rows.Count - 1)
            {
                this.NavMenuDataRowPosition++;
                DataTable dt = _objTerm.GetDataSalesBillingTerm(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["TermId"].ToString()));
                SetData(dt);
            }
            else
            {
                MessageBox.Show("This is the last record.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnPreviousData_Click(object sender, EventArgs e)
        {
            if (NavMenuDataList.Rows.Count == 0)
            {
                MessageBox.Show("No record is found to display.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (NavMenuDataList.Rows.Count == 1)
            {
                MessageBox.Show("This is the frist record.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.NavMenuDataRowPosition == NavMenuDataList.Rows.Count - 1 || this.NavMenuDataRowPosition != 0)
            {
                this.NavMenuDataRowPosition--;
                DataTable dt = _objTerm.GetDataSalesBillingTerm(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["TermId"].ToString()));
                SetData(dt);
            }
            else
            {
                MessageBox.Show("This is the frist record.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnLastData_Click(object sender, EventArgs e)
        {
            if (NavMenuDataList.Rows.Count <= 0)
            {
                MessageBox.Show("No record is found to display.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.NavMenuDataRowPosition = NavMenuDataList.Rows.Count - 1;
            DataTable dt = _objTerm.GetDataSalesBillingTerm(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["TermId"].ToString()));
            SetData(dt);
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            ClsGlobal.ConfirmFormCloseing(this);
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtDescription.Text))
            {
                MessageBox.Show("Term Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TxtTermPosition.Text))
            {
                MessageBox.Show("Term Position is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtTermPosition.Focus();
                return;
            }

            if (string.IsNullOrEmpty(TxtLedger.Text))
            {
                MessageBox.Show("Ledger is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtLedger.Focus();
                return;
            }

            _objTerm.Model.Tag = _Tag;
            _objTerm.Model.TermId = Convert.ToInt32(TxtDescription.Tag.ToString());
            _objTerm.Model.TermDesc = TxtDescription.Text;
            _objTerm.Model.TermPosition = Convert.ToInt32(TxtTermPosition.Text);
            _objTerm.Model.LedgerId = ((TxtLedger.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtLedger.Tag.ToString()));
            _objTerm.Model.Category = CmbCategory.Text;
            _objTerm.Model.Basis = CmbBasis.Text.ToString() == "Value" ? "V" : "Q";
            _objTerm.Model.STSign = CmbSTSign.Text.ToString() == "+" ? "+" : "-";
            _objTerm.Model.Billwise = CmbBillwise.Text.ToString() == "Bill Wise" ? "Y" : "N";
            _objTerm.Model.TermType = CmbTermType.Text.ToString() == "Invoice" ? "I" : CmbTermType.Text.ToString() == "Return"? "R":"B";
            _objTerm.Model.Formula = TxtFormula.Text;
            _objTerm.Model.TermRate = ((TxtTermRate.Text.Trim() == "") ? 0 : Convert.ToDecimal(TxtTermRate.Text));
            _objTerm.Model.EnterBy = ClsGlobal.LoginUserCode;
            _objTerm.Model.SupressZero = ChkSupressZero.Checked == true ? true : false;
            _objTerm.Model.Profitability = ChkProfitability.Checked == true ? true : false;
            _objTerm.Model.Status = ChkActive.Checked == true ? true : false;
            _objTerm.Model.Gadget = "Desktop";
			if (_Tag == "NEW")
			{
				if (ClsGlobal.ConfirmSave == 1)
				{
					var dialogResult = MessageBox.Show("Are you sure want to Save New Record..??", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
					if (dialogResult == DialogResult.Yes)
					{
						result = _objTerm.SaveSalesBillingTerm();
					}
					else
					{
						return;
					}
				}
				else
				{
					result = _objTerm.SaveSalesBillingTerm();
				}
			}
			else
			{
				result = _objTerm.SaveSalesBillingTerm();
			}
          
            if (!string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Data Submit Successfully", "Mr Solution");
                ClearFld();
                TxtDescription.Focus();
            }
            else
            {
                MessageBox.Show("Error Occured During Data Submit", "Mr Solution");
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (ClsGlobal.ConfirmFormClear == 1)
            {
                DialogResult dialog = ClsGlobal.ConfirmFormClearing();
                if (dialog == DialogResult.Yes)
                {
                    _Tag = "";
                    ControlEnableDisable(true, false);
                    ClearFld();
                    Text = "Sales Billing Term";
                }
                else
                {
                    return;
                }
            }
            else if (ClsGlobal.ConfirmFormClear == 0)
            {
                _Tag = "";
                ControlEnableDisable(true, false);
                ClearFld();
                Text = "Sales Billing Term";
            }
        
        }

        private void BtnDescription_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("SalesBillingTerm", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    DataTable dt = _objTerm.GetDataSalesBillingTerm(Convert.ToInt32(frmPickList.SelectedList[0]["TermId"].ToString().Trim()));
                    SetData(dt);
                }
                else
                {
                    TxtDescription.Text = "";
                    TxtDescription.Tag = "0";
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Term !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            TxtDescription.Focus();
        }

        private void SetData(DataTable dt)
        {
            TxtDescription.Tag = dt.Rows[0]["TermId"].ToString();
            TxtDescription.Text = dt.Rows[0]["TermDesc"].ToString();
            TxtTermPosition.Text = dt.Rows[0]["TermPosition"].ToString();
            ChkActive.Checked = Convert.ToBoolean(dt.Rows[0]["Status"].ToString());
            ChkProfitability.Checked = Convert.ToBoolean(dt.Rows[0]["Profitability"].ToString());
            ChkSupressZero.Checked = Convert.ToBoolean(dt.Rows[0]["SupressZero"].ToString());
            TxtLedger.Text = dt.Rows[0]["ledgerdesc"].ToString();
            TxtLedger.Tag = dt.Rows[0]["ledgerId"].ToString();
            CmbBasis.Text = dt.Rows[0]["Basis"].ToString();
            CmbBillwise.Text = dt.Rows[0]["Billwise"].ToString();
            CmbCategory.Text = dt.Rows[0]["Category"].ToString();
            CmbSTSign.Text = dt.Rows[0]["STSign"].ToString();
            CmbTermType.Text = dt.Rows[0]["TermType"].ToString();
            TxtTermRate.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["TermRate"].ToString()), 1, ClsGlobal._AmountDecimalFormat);
            TxtFormula.Text = dt.Rows[0]["Formula"].ToString();
            TxtDescription.SelectAll();
        }

        private void TxtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (_Tag == "NEW" && e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1")
            {
                _SearchKey = string.Empty;
                BtnSearcDescription.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtDescription, BtnSearcDescription, true);
            }
        }

        private void TxtDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || this.ActiveControl == TxtDescription) return;
            if (TxtDescription.Enabled == false) return;

            if (string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Term Description Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "SalesBillingTerm", "TermDesc", "TermId") == 1)
                {
                    MessageBox.Show("Term Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
               
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "SalesBillingTerm", "TermDesc", "TermId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Term Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void BtnLedgerSearch_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Generalledger", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtLedger.Text = frmPickList.SelectedList[0]["GlDesc"].ToString().Trim();
                    TxtLedger.Tag = Convert.ToInt32(frmPickList.SelectedList[0]["ledgerId"].ToString().Trim());
                    TxtLedger.SelectAll();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Term !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtLedger.Focus();
                return;
            }
            TxtLedger.Focus();
        }

        private void TxtLedger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmGeneralledger frm = new FrmGeneralledger();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtLedger.Text = frm._NewLedger;
                TxtLedger.Tag = frm._LedgerId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtLedger, BtnLedgerSearch, false);
            }
        }
        private void TxtLedger_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || this.ActiveControl == TxtLedger) return;
            if (TxtLedger.Enabled == false) return;

            if (string.IsNullOrEmpty(TxtLedger.Text))
            {
                MessageBox.Show("Ledger Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtLedger.Focus();
                return;
            }
        }

		private void CmbCategory_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (CmbCategory.Text == "RoundOff")
			{
				CmbBasis.Text = "Value";
				CmbBasis.Enabled = false;
				TxtTermRate.Text = "0.00";
				TxtTermRate.Enabled = false;
			}
			else
			{
				TxtTermRate.Enabled = true;
				CmbBasis.Enabled = true;
			}
		}

		private void TxtTermRate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {           
            if (_Tag == "" || this.ActiveControl == TxtTermRate) return;
            if (TxtTermRate.Enabled == false) return;
            decimal.TryParse(TxtTermRate.Text, out decimal _TermRate);
            if (_TermRate > 100)
            {
                MessageBox.Show("Term Rate Can Not More then 100 Percent...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtTermRate.Focus();
                return;
            }
        }

        private void TxtTermPosition_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || this.ActiveControl == TxtTermPosition) return;
            if (TxtTermPosition.Enabled == false) return;

            if (string.IsNullOrEmpty(TxtTermPosition.Text.Trim()))
            {
                MessageBox.Show("Term Position Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtTermPosition.Text.Trim(), "SalesBillingTerm", "TermPosition", "TermId") == 1)
                {
                    MessageBox.Show("Term Position Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtTermPosition.Text.Trim(), "SalesBillingTerm", "TermPosition", "TermId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Term Position Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }
    }
}
