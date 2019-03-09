using DataAccessLayer.Common;
using DataAccessLayer.MasterSetup;
using System;
using System.Data;
using System.Windows.Forms;
namespace acmedesktop.MasterSetup
{
    public partial class FrmAccountSubGroup : Form
    {
        private ClsAccountSubGroup _objAccountSubGroup = new ClsAccountSubGroup();
        private ClsCommon _objCommon = new ClsCommon();
        public char _IsNew;
        public int _AccountSubGrpId;
        public int _AccountGrpId;
        private string _Tag = "", _SearchKey = "", result = "";
        private DataTable NavMenuDataList;
        private int NavMenuDataRowPosition = 0; public string _NewAccountSubGroup = "";
        private ClsFormControl ClsForm = null;
        public FrmAccountSubGroup()
        {
            InitializeComponent();
            ClsForm = new ClsFormControl(this);
        }
        private void FrmAccountSubGroup_Load(object sender, EventArgs e)
        {
            NavMenuDataList = _objAccountSubGroup.GetDataAccountSubGroup(0);
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
        private void FrmAccountSubGroup_KeyDown(object sender, KeyEventArgs e)
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
            ClearFld();
            _Tag = "NEW";
            ControlEnableDisable(false, true);
            Text = "Account SubGroup [NEW]";
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _Tag = "EDIT";
            ControlEnableDisable(false, true);
            Text = "Account SubGroup [EDIT]";
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _Tag = "DELETE";
            ControlEnableDisable(false, false);
            Text = "Account SubGroup [DELETE]";
            TxtDescription.Enabled = true;
            BtnSearchSubAccDesc.Enabled = true;
            TxtDescription.Focus();
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
        }
        private void BtnFirstData_Click(object sender, EventArgs e)
        {
            if (NavMenuDataList.Rows.Count > 0)
            {
                NavMenuDataRowPosition = 0;
                DataTable dt = _objAccountSubGroup.GetDataAccountSubGroup(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["AccountSubGrpId"].ToString()));
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
                DataTable dt = _objAccountSubGroup.GetDataAccountSubGroup(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["AccountSubGrpId"].ToString()));
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
                DataTable dt = _objAccountSubGroup.GetDataAccountSubGroup(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["AccountSubGrpId"].ToString()));
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
            DataTable dt = _objAccountSubGroup.GetDataAccountSubGroup(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["AccountSubGrpId"].ToString()));
            SetData(dt);
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            ClsGlobal.ConfirmFormCloseing(this);
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Account SubGroup Description is Required.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TxtShortName.Text.Trim()))
            {
                MessageBox.Show("Account SubGroup ShortName is Required.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtShortName.Focus();
                return;
            }

            _objAccountSubGroup.Model.Tag = _Tag;
            _objAccountSubGroup.Model.AccountSubGrpId = Convert.ToInt32(TxtDescription.Tag.ToString());
            if ((_Tag == "EDIT" || _Tag == "DELETE") && Convert.ToInt32(TxtDescription.Tag.ToString()) == 0)
            {
                ClearFld();
                TxtDescription.Focus();
                return;
            }
            _objAccountSubGroup.Model.AccountSubGrpDesc = TxtDescription.Text;
            _objAccountSubGroup.Model.AccountSubGrpShortName = TxtShortName.Text;
            _objAccountSubGroup.Model.AccountGrpId = Convert.ToInt32(TxtAccountGroup.Tag.ToString());
            _objAccountSubGroup.Model.EnterBy = ClsGlobal.LoginUserCode;
            _objAccountSubGroup.Model.Status = CbActive.Checked == true ? true : false;
            _objAccountSubGroup.Model.Gadget = "Desktop";
            if (_Tag == "NEW")
            {
                if (ClsGlobal.ConfirmSave == 1)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure want to Save New Record..??", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dialogResult == DialogResult.Yes)
                    {
                        result = _objAccountSubGroup.SaveAccountSubGroup();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    result = _objAccountSubGroup.SaveAccountSubGroup();
                }
            }
            else
            {
                result = _objAccountSubGroup.SaveAccountSubGroup();
            }

            if (!string.IsNullOrEmpty(result))
            {
                if (_IsNew == 'Y')
                {
                    _NewAccountSubGroup = TxtDescription.Text.Trim();
                    _AccountSubGrpId = Convert.ToInt32(result);
                    Close();
                }
                else
                {
                    NavMenuDataList = _objAccountSubGroup.GetDataAccountSubGroup(0);
                    ClsGlobal.SaveMessage(_Tag);
                    ClearFld();
                }
            }
            else
            {
                MessageBox.Show("Account sub group already in used.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Text = "Account SubGroup";
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
                Text = "Account SubGroup";
            }
        }
        private void TxtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (_Tag == "NEW" && e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1")
            {
                _SearchKey = string.Empty;
                BtnSearchSubAccDesc.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtDescription, BtnSearchSubAccDesc, true);
            }
        }
        private void TxtDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtDescription)
            {
                return;
            }

            if (TxtDescription.Enabled == false)
            {
                return;
            }

            if (string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Account SubGroup Description Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "AccountSubGroup", "AccountSubGrpDesc", "AccountSubGrpId") == 1)
                {
                    MessageBox.Show("Account SubGroup Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
                else
                {
                    TxtShortName.Text = _objCommon.GenerateShortName(TxtDescription.Text.Trim(), "AccountSubGrpDesc", "AccountSubGrpShortName", "AccountSubGroup");
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "AccountSubGroup", "AccountSubGrpDesc", "AccountSubGrpId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Account Group Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }
        private void BtnSearchSubAccDesc_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("AccountSubGroup", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    DataTable dt = _objAccountSubGroup.GetDataAccountSubGroup(Convert.ToInt32(frmPickList.SelectedList[0]["AccountSubGrpId"].ToString().Trim()));
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
                MessageBox.Show("No List Available in Account SubGroup !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            TxtDescription.Focus();
        }
        private void TxtShortName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtShortName)
            {
                return;
            }

            if (TxtShortName.Enabled == false)
            {
                return;
            }

            if (string.IsNullOrEmpty(TxtShortName.Text.Trim()) && !string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Account SubGroup ShortName Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "AccountSubGroup", "AccountSubGrpShortName", "AccountSubGrpId") == 1)
                {
                    MessageBox.Show("Account SubGroup ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "AccountSubGroup", "AccountSubGrpShortName", "AccountSubGrpId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Account SubGroup ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }
        private void TxtAccountGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmAccountGroup frm = new FrmAccountGroup
                {
                    _IsNew = 'Y'
                };
                frm.ShowDialog();
                TxtAccountGroup.Text = frm._NewAccountGroup;
                TxtAccountGroup.Tag = frm._AccountGrpId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtAccountGroup, BtnSearchAccount, false);
            }
        }
        private void TxtAccountGroup_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtAccountGroup)
            {
                return;
            }

            if (TxtAccountGroup.Enabled == false)
            {
                return;
            }

            if (TxtAccountGroup.Text.Trim() == "")
            {
                MessageBox.Show("Account Group Cannot Left Blank...!", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
        }
        private void BtnSearchAccount_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("AccountGroup", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtAccountGroup.Text = frmPickList.SelectedList[0]["AccountGrpDesc"].ToString().Trim();
                    TxtAccountGroup.Tag = frmPickList.SelectedList[0]["AccountGrpId"].ToString().Trim();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Account Group !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtAccountGroup.Focus();
                return;
            }
            TxtAccountGroup.Focus();
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
            BtnSearchSubAccDesc.Enabled = fld;
            TxtDescription.Enabled = fld;
            Utility.EnableDesibleColor(TxtDescription, fld);
            TxtShortName.Enabled = fld;
            Utility.EnableDesibleColor(TxtShortName, fld);
            TxtAccountGroup.Enabled = fld;
            Utility.EnableDesibleColor(TxtAccountGroup, fld);
            CbActive.Enabled = fld;

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
            _AccountSubGrpId = 0;
            TxtDescription.Tag = "0";
            TxtAccountGroup.Tag = "0";
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
        private void SetData(DataTable dt)
        {
            TxtDescription.Tag = dt.Rows[0]["AccountSubGrpId"].ToString();
            TxtDescription.Text = dt.Rows[0]["AccountSubGrpDesc"].ToString();
            TxtShortName.Text = dt.Rows[0]["AccountSubGrpShortName"].ToString();
            TxtAccountGroup.Text = dt.Rows[0]["AccountGrpDesc"].ToString();
            TxtAccountGroup.Tag = dt.Rows[0]["AccountGrpId"].ToString();
            CbActive.Checked = Convert.ToBoolean(dt.Rows[0]["Status"].ToString());
            TxtDescription.SelectAll();
        }
    }
}