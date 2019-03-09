using DataAccessLayer.Common;
using DataAccessLayer.MasterSetup;
using System;
using System.Data;
using System.Windows.Forms;
namespace acmedesktop.MasterSetup
{
    public partial class FrmSubledger : Form
    {
        private ClsSubledger _objSubledger = new ClsSubledger();
        ClsCommon _objCommon = new ClsCommon();
        public char _IsNew;
        public int _SubledgerId;
        private string _Tag = "", _SearchKey = "", result = "";
        DataTable NavMenuDataList; int NavMenuDataRowPosition = 0;
        public string _NewSubLedger = "";

        public FrmSubledger()
        {
            InitializeComponent();
        }
        private void FrmSubledger_Load(object sender, EventArgs e)
        {
            NavMenuDataList = _objSubledger.GetDataSubledger(0);
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
        }
        private void FrmSubledger_KeyDown(object sender, KeyEventArgs e)
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

            if (BtnNew.Enabled == true)
            {
                BtnNew.Focus();
            }

            TxtDescription.Enabled = fld;
            BtnSearcAccountDesc.Enabled = fld;
            Utility.EnableDesibleColor(TxtDescription, fld);
            TxtShortName.Enabled = fld;
            Utility.EnableDesibleColor(TxtShortName, fld);
            CbActive.Enabled = fld;
            TxtCountry.Enabled = fld;
            Utility.EnableDesibleColor(TxtCountry, fld);
            TxtAddress.Enabled = fld;
            Utility.EnableDesibleColor(TxtAddress, fld);

            TxtBankAccountNo.Enabled = fld;
            Utility.EnableDesibleColor(TxtBankAccountNo, fld);

            TxtEmailId.Enabled = fld;
            Utility.EnableDesibleColor(TxtEmailId, fld);

            TxtFax.Enabled = fld;
            Utility.EnableDesibleColor(TxtFax, fld);

            TxtInterestRate.Enabled = fld;
            Utility.EnableDesibleColor(TxtInterestRate, fld);

            TxtLedger.Enabled = fld;
            BtnLedgerSearch.Enabled = fld;
            Utility.EnableDesibleColor(TxtLedger, fld);

            TxtMobileNo.Enabled = fld;
            Utility.EnableDesibleColor(TxtMobileNo, fld);

            TxtNationalId.Enabled = fld;
            Utility.EnableDesibleColor(TxtNationalId, fld);

            TxtPanNo.Enabled = fld;
            Utility.EnableDesibleColor(TxtPanNo, fld);

            TxtPhoneNo.Enabled = fld;
            Utility.EnableDesibleColor(TxtPhoneNo, fld);

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
            _SubledgerId = 0;
            TxtLedger.Tag = "";
            TxtDescription.Tag = "0";
            foreach (Control control in PanelContainer.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
            }
            CbActive.Checked = true;
            TxtDescription.Focus();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            _Tag = "NEW";
            ControlEnableDisable(false, true);
            Text = "Subledger [NEW]";
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _Tag = "EDIT";
            ControlEnableDisable(false, true);
            Text = "Subledger [EDIT]";
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _Tag = "DELETE";
            ControlEnableDisable(false, false);
            Text = "Subledger [DELETE]";
            TxtDescription.Enabled = true;
            BtnSearcAccountDesc.Enabled = true;
            TxtDescription.Focus();
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
        }
        private void BtnFirstData_Click(object sender, EventArgs e)
        {
            if (NavMenuDataList.Rows.Count > 0)
            {
                NavMenuDataRowPosition = 0;
                DataTable dt = _objSubledger.GetDataSubledger(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["SubledgerId"].ToString()));
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

            if (NavMenuDataRowPosition < NavMenuDataList.Rows.Count - 1)
            {
                NavMenuDataRowPosition++;
                DataTable dt = _objSubledger.GetDataSubledger(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["SubledgerId"].ToString()));
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

            if (NavMenuDataRowPosition == NavMenuDataList.Rows.Count - 1 || NavMenuDataRowPosition != 0)
            {
                NavMenuDataRowPosition--;
                DataTable dt = _objSubledger.GetDataSubledger(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["SubledgerId"].ToString()));
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
            NavMenuDataRowPosition = NavMenuDataList.Rows.Count - 1;
            DataTable dt = _objSubledger.GetDataSubledger(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["SubledgerId"].ToString()));
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
                MessageBox.Show("SubLedger Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TxtShortName.Text))
            {
                MessageBox.Show("SubLedger ShortName is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtShortName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(TxtDescription.Text))
            {
                MessageBox.Show("Subledger Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TxtShortName.Text))
            {
                MessageBox.Show("Subledger ShortName is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtShortName.Focus();
                return;
            }

            _objSubledger.Model.Tag = _Tag;
            _objSubledger.Model.SubledgerId = Convert.ToInt32(TxtDescription.Tag.ToString());
            _objSubledger.Model.SubledgerDesc = TxtDescription.Text;
            _objSubledger.Model.SubledgerShortName = TxtShortName.Text;
            _objSubledger.Model.LedgerId = ((TxtLedger.Tag.ToString() == "") ? 0 : Convert.ToInt64(TxtLedger.Tag.ToString()));
            _objSubledger.Model.Country = TxtCountry.Text;
            _objSubledger.Model.Address = TxtAddress.Text;
            _objSubledger.Model.PhoneNo = TxtPhoneNo.Text;
            _objSubledger.Model.MobileNo = TxtMobileNo.Text;
            _objSubledger.Model.Fax = TxtFax.Text;
            _objSubledger.Model.EmailId = TxtEmailId.Text;
            _objSubledger.Model.BankAccountNo = TxtBankAccountNo.Text;
            _objSubledger.Model.InterestRate = ((TxtInterestRate.Text.ToString() == "") ? 0 : Convert.ToDecimal(TxtInterestRate.Text));
            _objSubledger.Model.NationalId = TxtNationalId.Text;
            _objSubledger.Model.PanNo = TxtPanNo.Text;
            _objSubledger.Model.EnterBy = ClsGlobal.LoginUserCode;
            _objSubledger.Model.Status = CbActive.Checked == true ? true : false;
            _objSubledger.Model.Gadget = "Desktop";
            if (_Tag == "NEW")
            {
                if (ClsGlobal.ConfirmSave == 1)
                {
                    var dialogResult = MessageBox.Show("Are you sure want to Save New Record..??", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dialogResult == DialogResult.Yes)
                        result = _objSubledger.SaveSubledger();
                    else
                        return;
                }
                else
                {
                    result = _objSubledger.SaveSubledger();
                }
            }
            else
            {
                result = _objSubledger.SaveSubledger();
            }

            if (!string.IsNullOrEmpty(result))
            {
                if (_IsNew == 'Y')
                {
                    _NewSubLedger = TxtDescription.Text.Trim();
                    _SubledgerId = Convert.ToInt32(result);
                    Close();
                }
                else
                {
                    NavMenuDataList = _objSubledger.GetDataSubledger(0);
                    MessageBox.Show("Data Submit Successfully", "Mr Solution");
                    ClearFld();
                    TxtDescription.Focus();
                }
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
                    Text = "Subledger";
                }
            }
            else if (ClsGlobal.ConfirmFormClear == 0)
            {
                _Tag = "";
                ControlEnableDisable(true, false);
                ClearFld();
                Text = "Subledger";
            }
        }

        private void BtnDescription_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Subledger", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    DataTable dt = _objSubledger.GetDataSubledger(Convert.ToInt32(frmPickList.SelectedList[0]["SubledgerId"].ToString().Trim()));
                    SetData(dt);
                }
                else
                {
                    TxtDescription.Tag = "0";
                    TxtDescription.Text = "";
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in SubLedger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            TxtDescription.Focus();
        }
        private void TxtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (_Tag == "NEW" && (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1"))
            {
                _SearchKey = string.Empty;
                BtnSearcAccountDesc.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtDescription, BtnSearcAccountDesc, true);
            }
        }

        private void TxtDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtDescription) return;
            if (TxtDescription.Enabled == false) return;

            if (string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Subledger Description Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "SubLedger", "SubledgerDesc", "SubledgerId") == 1)
                {
                    MessageBox.Show("Subledger Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
                else
                {
                    TxtShortName.Text = _objCommon.GenerateShortName(TxtDescription.Text.Trim(), "SubledgerDesc", "SubledgerShortName", "SubLedger");
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "SubLedger", "SubledgerDesc", "SubledgerId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Subledger Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("No List Available in Ledger !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void TxtShortName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtShortName) return;
            if (TxtShortName.Enabled == false) return;

            if (string.IsNullOrEmpty(TxtShortName.Text.Trim()) && !string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Subledger ShortName Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "SubLedger", "SubledgerShortName", "SubledgerId") == 1)
                {
                    MessageBox.Show("Subledger ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "SubLedger", "SubledgerShortName", "SubledgerId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Subledger ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }
        private void SetData(DataTable dt)
        {
            TxtDescription.Tag = dt.Rows[0]["SubLedgerId"].ToString();
            TxtDescription.Text = dt.Rows[0]["SubledgerDesc"].ToString();
            TxtShortName.Text = dt.Rows[0]["SubledgerShortName"].ToString();
            CbActive.Checked = Convert.ToBoolean(dt.Rows[0]["Status"].ToString());
            TxtLedger.Text = dt.Rows[0]["Gldesc"].ToString();
            TxtCountry.Text = dt.Rows[0]["Country"].ToString();
            TxtAddress.Text = dt.Rows[0]["Address"].ToString();
            TxtPhoneNo.Text = dt.Rows[0]["PhoneNo"].ToString();
            TxtMobileNo.Text = dt.Rows[0]["MobileNo"].ToString();
            TxtFax.Text = dt.Rows[0]["Fax"].ToString();
            TxtEmailId.Text = dt.Rows[0]["EmailId"].ToString();
            TxtBankAccountNo.Text = dt.Rows[0]["BankAccountNo"].ToString();
            TxtInterestRate.Text = ClsGlobal.DecimalFormate(Convert.ToDecimal(dt.Rows[0]["InterestRate"].ToString()), 1, ClsGlobal._AmountDecimalFormat).ToString();
            TxtNationalId.Text = dt.Rows[0]["NationalId"].ToString();
            TxtPanNo.Text = dt.Rows[0]["PanNo"].ToString();
            TxtDescription.SelectAll();
        }

    }
}
