using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DataAccessLayer.Common;
using DataAccessLayer.MasterSetup;
namespace acmedesktop.MasterSetup
{
    public partial class FrmGodown : Form
    {
        private ClsGodown _objGodown = new ClsGodown();
        ClsCommon _objCommon = new ClsCommon();
        public char _IsNew;
        public int _GodownId;
        private string _Tag = "", _SearchKey = "", result = "";
        DataTable NavMenuDataList; int NavMenuDataRowPosition = 0; public string _NewGodown = "";

        public FrmGodown()
        {
            InitializeComponent();
        }
        private void FrmGodown_Load(object sender, EventArgs e)
        {
            NavMenuDataList = _objGodown.GetDataGodown(0);
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
        private void FrmGodown_KeyDown(object sender, KeyEventArgs e)
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
        private void BtnNew_Click(object sender, EventArgs e)
        {
            _Tag = "NEW";
            ControlEnableDisable(false, true);
            Text = "Godown [NEW]";
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _Tag = "EDIT";
            ControlEnableDisable(false, true);
            Text = "Godown [EDIT]";
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _Tag = "DELETE";
            ControlEnableDisable(false, false);
            Text = "Godown [DELETE]";
            TxtDescription.Enabled = true;
            BtnSearcGodownDesc.Enabled = true;
            TxtDescription.Focus();
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
        }
        private void BtnFirstData_Click(object sender, EventArgs e)
        {
            if (NavMenuDataList.Rows.Count > 0)
            {
                this.NavMenuDataRowPosition = 0;
                DataTable dt = _objGodown.GetDataGodown(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["GodownId"].ToString()));
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
                DataTable dt = _objGodown.GetDataGodown(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["GodownId"].ToString()));
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
                DataTable dt = _objGodown.GetDataGodown(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["GodownId"].ToString()));
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
            DataTable dt = _objGodown.GetDataGodown(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["GodownId"].ToString()));
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
                MessageBox.Show("Godwon Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TxtShortName.Text))
            {
                MessageBox.Show("Godwon ShortName is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtShortName.Focus();
                return;
            }

            _objGodown.Model.Tag = _Tag;
            _objGodown.Model.GodownId = Convert.ToInt32(TxtDescription.Tag.ToString());
            if ((_Tag == "EDIT" || _Tag == "DELETE") && Convert.ToInt32(TxtDescription.Tag.ToString()) == 0)
            {
                ClearFld();
                TxtDescription.Focus();
                return;
            }

            _objGodown.Model.GodownDesc = TxtDescription.Text;
            _objGodown.Model.GodownShortName = TxtShortName.Text;
            _objGodown.Model.LedgerId = ((TxtLedger.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtLedger.Tag.ToString()));
            _objGodown.Model.Country = TxtCountry.Text;
            _objGodown.Model.Address = TxtAddress.Text;
            _objGodown.Model.PhoneNo = TxtPhoneNo.Text;
            _objGodown.Model.Fax = TxtFax.Text;
            _objGodown.Model.ContactPerson = TxtContactPerson.Text;
            _objGodown.Model.ContactPersonAdd = TxtContactPersonAdd.Text;
            _objGodown.Model.ContPersonPhoneNo = TxtContPersonPhoneNo.Text;
            _objGodown.Model.EnterBy = ClsGlobal.LoginUserCode;
            _objGodown.Model.Status = CbActive.Checked == true ? true : false;
            _objGodown.Model.Gadget = "Desktop";
            if (_Tag == "NEW")
            {
                if (ClsGlobal.ConfirmSave == 1)
                {
                    var dialogResult = MessageBox.Show("Are you sure want to Save New Record..??", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dialogResult == DialogResult.Yes)
                        result = _objGodown.SaveGodown();
                    else
                        return;
                }
                else
                {
                    result = _objGodown.SaveGodown();
                }
            }
            else
            {
                result = _objGodown.SaveGodown();
            }
           
            if (!string.IsNullOrEmpty(result))
            {
                if (_IsNew == 'Y')
                {
                    _NewGodown = TxtDescription.Text.Trim();
                    _GodownId = Convert.ToInt32(result);
                    this.Close();
                }
                else
                {
                    NavMenuDataList = _objGodown.GetDataGodown(0);
                    MessageBox.Show("Data submit successfully", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFld();
                }
            }
            else
            {
                MessageBox.Show("Error occured during data submit", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Text = "Godown";
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
                Text = "Godown";
            }         
        }
        private void BtnSearcGodownDesc_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Godown", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    DataTable dt = _objGodown.GetDataGodown(Convert.ToInt32(frmPickList.SelectedList[0]["GodownId"].ToString().Trim()));
                    SetData(dt);
                    TxtDescription.SelectAll();
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
                MessageBox.Show("No List Available in Godown !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                BtnSearcGodownDesc.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtDescription, BtnSearcGodownDesc,true);
            }
        }
        private void TxtDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || this.ActiveControl == TxtDescription) return;
            if (TxtDescription.Enabled == false) return;

            if (string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Godown Description Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "Godown", "GodownDesc", "GodownId") == 1)
                {
                    MessageBox.Show("Godown Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
                else
                {
                    TxtShortName.Text = _objCommon.GenerateShortName(TxtDescription.Text.Trim(), "GodownDesc", "GodownShortName", "Godown");
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "Godown", "GodownDesc", "GodownId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Godown Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (_Tag == "" || this.ActiveControl == TxtShortName) return;
            if (TxtShortName.Enabled == false) return;

            if (string.IsNullOrEmpty(TxtShortName.Text.Trim()) && !string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Godown ShortName Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "Godown", "GodownShortName", "GodownId") == 1)
                {
                    MessageBox.Show("Godown ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "Godown", "GodownShortName", "GodownId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Godown ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }
        private void SetData(DataTable dt)
        {
            TxtDescription.Tag = dt.Rows[0]["GodownId"].ToString();
            TxtDescription.Text = dt.Rows[0]["GodownDesc"].ToString();
            TxtShortName.Text = dt.Rows[0]["GodownShortName"].ToString();
            CbActive.Checked = Convert.ToBoolean(dt.Rows[0]["Status"].ToString());
            TxtLedger.Text = dt.Rows[0]["Gldesc"].ToString();
            TxtCountry.Text = dt.Rows[0]["Country"].ToString();
            TxtAddress.Text = dt.Rows[0]["Address"].ToString();
            TxtPhoneNo.Text = dt.Rows[0]["PhoneNo"].ToString();
            TxtContactPerson.Text = dt.Rows[0]["ContactPerson"].ToString();
            TxtFax.Text = dt.Rows[0]["Fax"].ToString();
            TxtContactPersonAdd.Text = dt.Rows[0]["ContactPersonAdd"].ToString();
            TxtContPersonPhoneNo.Text = dt.Rows[0]["ContPersonPhoneNo"].ToString();
            TxtDescription.SelectAll();
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
            BtnSearcGodownDesc.Enabled = fld;
            Utility.EnableDesibleColor(TxtDescription, fld);
            TxtShortName.Enabled = fld;
            Utility.EnableDesibleColor(TxtShortName, fld);
            CbActive.Enabled = fld;
            TxtCountry.Enabled = fld;
            Utility.EnableDesibleColor(TxtCountry, fld);
            TxtAddress.Enabled = fld;
            Utility.EnableDesibleColor(TxtAddress, fld);

            TxtFax.Enabled = fld;
            Utility.EnableDesibleColor(TxtFax, fld);

            TxtLedger.Enabled = fld;
            BtnLedgerSearch.Enabled = fld;
            Utility.EnableDesibleColor(TxtLedger, fld);

            TxtPhoneNo.Enabled = fld;
            Utility.EnableDesibleColor(TxtPhoneNo, fld);

            TxtContactPerson.Enabled = fld;
            Utility.EnableDesibleColor(TxtContactPerson, fld);

            TxtContactPersonAdd.Enabled = fld;
            Utility.EnableDesibleColor(TxtContactPersonAdd, fld);

            TxtContPersonPhoneNo.Enabled = fld;
            Utility.EnableDesibleColor(TxtContPersonPhoneNo, fld);

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
            this._GodownId = 0;
            TxtDescription.Tag = "0";
            TxtLedger.Tag = "";
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
    }
}
