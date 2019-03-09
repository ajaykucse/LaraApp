using DataAccessLayer.Common;
using DataAccessLayer.Interface.MasterSetup;
using DataAccessLayer.MasterSetup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
namespace acmedesktop.MasterSetup
{
    public partial class FrmAccountGroup : Form
    {
        private IAccountGroup _objAccountGroup = new ClsAccountGroup();
        private ClsCommon _objCommon = new ClsCommon();
        public char _IsNew;
        public int _AccountGrpId;
        private string _Tag = "", _SearchKey = "", result = "";
        private DataTable NavMenuDataList;
        private int NavMenuDataRowPosition = 0; public string _NewAccountGroup = "";
        private ClsFormControl clsForm = null;
        public FrmAccountGroup()
        {
            InitializeComponent();
            clsForm = new ClsFormControl(this);
            CmbType.SelectedValueChanged += CmbType_SelectedValueChanged;
        }

        private void CmbType_SelectedValueChanged(object sender, EventArgs e)
        {
            ClsGlobal.LoadGroupCategoryType(CmbType, CmbPrimaryGroup);
        }

        private void AccountGroup_Load(object sender, EventArgs e)
        {
            NavMenuDataList = _objAccountGroup.GetDataAccountGroup(0);
            ControlEnableDisable(true, false);
            //AddList();
            ClsGlobal.LoadGroupCategory(CmbType);
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
        private void AccountGroup_KeyDown(object sender, KeyEventArgs e)
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
            Text = "Account Group [NEW]";
            TxtSchedule.Text = _objAccountGroup.GetSchedule();
            CmbType_SelectionChangeCommitted(CmbType, EventArgs.Empty);
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _Tag = "EDIT";
            ControlEnableDisable(false, true);
            Text = "Account Group [EDIT]";
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _Tag = "DELETE";
            ControlEnableDisable(false, false);
            Text = "Account Group [DELETE]";
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
                DataTable dt = _objAccountGroup.GetDataAccountGroup(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["AccountGrpId"].ToString()));
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
                DataTable dt = _objAccountGroup.GetDataAccountGroup(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["AccountGrpId"].ToString()));
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
                DataTable dt = _objAccountGroup.GetDataAccountGroup(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["AccountGrpId"].ToString()));
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
            DataTable dt = _objAccountGroup.GetDataAccountGroup(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["AccountGrpId"].ToString()));
            SetData(dt);
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            ClsGlobal.ConfirmFormCloseing(this);
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Account Group Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TxtShortName.Text.Trim()))
            {
                MessageBox.Show("Account Group ShortName is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtShortName.Focus();
                return;
            }

            _objAccountGroup.Model.Tag = _Tag;
            _objAccountGroup.Model.AccountGrpId = Convert.ToInt32(TxtDescription.Tag.ToString());
            if ((_Tag == "EDIT" || _Tag == "DELETE") && Convert.ToInt32(TxtDescription.Tag.ToString()) == 0)
            {
                ClearFld();
                return;
            }
            _objAccountGroup.Model.AccountGrpDesc = TxtDescription.Text.Trim();
            _objAccountGroup.Model.AccountGrpShortName = TxtShortName.Text.Trim();
            _objAccountGroup.Model.Schedule = TxtSchedule.Text == "" ? 0 : Convert.ToInt32(TxtSchedule.Text);
            _objAccountGroup.Model.EnterBy = ClsGlobal.LoginUserCode;
            _objAccountGroup.Model.GrpType = CmbType.SelectedValue.ToString();//((KeyValuePair<string, string>)CmbType.SelectedItem).Key;
            _objAccountGroup.Model.PrimaryGrp = CmbPrimaryGroup.SelectedValue.ToString();//((KeyValuePair<string, string>) CmbPrimaryGroup.SelectedItem).Key;
            _objAccountGroup.Model.Status = CbActive.Checked == true ? true : false;
            _objAccountGroup.Model.Gadget = "Desktop";
            if (_Tag == "NEW")
            {
                if (ClsGlobal.ConfirmSave == 1)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure want to Save New Record..??", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dialogResult == DialogResult.Yes)
                    {
                        result = _objAccountGroup.SaveAccountGroup();
                    }
                }
                else
                {
                    result = _objAccountGroup.SaveAccountGroup();
                }
            }
            else
            {
                result = _objAccountGroup.SaveAccountGroup();
            }

            if (!string.IsNullOrEmpty(result))
            {
                if (_IsNew == 'Y')
                {
                    _NewAccountGroup = TxtDescription.Text.Trim();
                    _AccountGrpId = Convert.ToInt32(result);
                    Close();
                }
                else
                {
                    NavMenuDataList = _objAccountGroup.GetDataAccountGroup(0);
                    ClsGlobal.SaveMessage(_Tag);
                    ClearFld();
                    if (_Tag == "NEW")
                    {
                        TxtSchedule.Text = _objAccountGroup.GetSchedule();
                    }
                }
            }
            else
            {
                MessageBox.Show("Account group already in used.", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Text = "Account Group";
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
                Text = "Account Group";
            }
        }
        private void CmbType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //SelectedType();
        }
        //private void SelectedType()
        //{
        //    if (CmbType.Text == "Balance Sheet")
        //    {
        //        Dictionary<string, string> _CmbPrimaryGroup = new Dictionary<string, string>
        //        {
        //            { "Assets", "Assets" },
        //            { "Liability", "Liability" }
        //        };
        //        CmbPrimaryGroup.DataSource = new BindingSource(_CmbPrimaryGroup, null);
        //        CmbPrimaryGroup.DisplayMember = "Value";
        //        CmbPrimaryGroup.ValueMember = "Key";
        //        CmbPrimaryGroup.SelectedIndex = 0;
        //    }
        //    else if (CmbType.Text == "Profit & Loss" || CmbType.Text == "Trading")
        //    {
        //        Dictionary<string, string> _CmbPrimaryGroup = new Dictionary<string, string>
        //        {
        //            { "Income", "Income" },
        //            { "Expenditure", "Expenditure" }
        //        };
        //        CmbPrimaryGroup.DataSource = new BindingSource(_CmbPrimaryGroup, null);
        //        CmbPrimaryGroup.DisplayMember = "Value";
        //        CmbPrimaryGroup.ValueMember = "Key";
        //        CmbPrimaryGroup.SelectedIndex = 0;
        //    }
        //}
        private void BtnSearcAccountDesc_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("AccountGroup", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    DataTable dt = _objAccountGroup.GetDataAccountGroup(Convert.ToInt32(frmPickList.SelectedList[0]["AccountGrpId"].ToString().Trim()));
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
                MessageBox.Show("No List Available in Account Group !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Account Group Description Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "AccountGroup", "AccountGrpDesc", "AccountGrpId") == 1)
                {
                    MessageBox.Show("Account Group Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
                else
                {
                    TxtShortName.Text = _objCommon.GenerateShortName(TxtDescription.Text.Trim(), "AccountGrpDesc", "AccountGrpShortName", "AccountGroup");
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "AccountGroup", "AccountGrpDesc", "AccountGrpId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Account Group Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
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
                MessageBox.Show("Account Group ShortName Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "AccountGroup", "AccountGrpShortName", "AccountGrpId") == 1)
                {
                    MessageBox.Show("Account Group ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "AccountGroup", "AccountGrpShortName", "AccountGrpId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Account Group ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }
        //private void AddList()
        //{
        //    Dictionary<string, string> _CmbType = new Dictionary<string, string>
        //    {
        //        { "BS", "Balance Sheet" },
        //        { "PL", "Profit & Loss" },
        //        { "TD", "Trading" }
        //    };
        //    CmbType.Items.Clear();
        //    CmbType.DataSource = new BindingSource(_CmbType, null);
        //    CmbType.DisplayMember = "Value";
        //    CmbType.ValueMember = "Key";
        //    CmbType.SelectedIndex = 0;

        //    Dictionary<string, string> _CmbPrimaryGroup = new Dictionary<string, string>
        //    {
        //        { "Assets", "Assets" },
        //        { "Liability", "Liability" },
        //        { "Income", "Income" },
        //        { "Expenditure", "Expenditure" }
        //    };
        //    CmbPrimaryGroup.Items.Clear();
        //    CmbPrimaryGroup.DataSource = new BindingSource(_CmbPrimaryGroup, null);
        //    CmbPrimaryGroup.DisplayMember = "Value";
        //    CmbPrimaryGroup.ValueMember = "Key";
        //    CmbPrimaryGroup.SelectedIndex = 0;
        //}
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
            BtnSearcAccountDesc.Enabled = fld;
            TxtDescription.Enabled = fld;
            Utility.EnableDesibleColor(TxtDescription, fld);
            TxtShortName.Enabled = fld;
            Utility.EnableDesibleColor(TxtShortName, fld);
            CmbType.Enabled = fld;
            CmbPrimaryGroup.Enabled = fld;
            TxtSchedule.Enabled = fld;
            Utility.EnableDesibleColor(TxtSchedule, fld);
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

        private void TxtSchedule_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtSchedule)
            {
                return;
            }

            if (TxtSchedule.Enabled == false)
            {
                return;
            }

            if (string.IsNullOrEmpty(TxtSchedule.Text.Trim()))
            {
                MessageBox.Show("Schedule Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtSchedule.Text.Trim(), "AccountGroup", "Schedule", "AccountGrpId") == 1)
                {
                    MessageBox.Show("Schedule Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtSchedule.Text.Trim(), "AccountGroup", "Schedule", "AccountGrpId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Schedule Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
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
            CbActive.Checked = true;
            _AccountGrpId = 0;
            TxtDescription.Tag = "0";
            TxtDescription.Focus();
        }
        private void SetData(DataTable dt)
        {
            //AddList();
            TxtDescription.Text = dt.Rows[0]["AccountGrpDesc"].ToString();
            TxtDescription.Tag = dt.Rows[0]["AccountGrpId"].ToString();
            TxtShortName.Text = dt.Rows[0]["AccountGrpShortName"].ToString();
            CmbType.SelectedValue = dt.Rows[0]["GrpType"].ToString();
            CmbType_SelectionChangeCommitted(CmbType, EventArgs.Empty);
            CmbPrimaryGroup.SelectedValue = dt.Rows[0]["PrimaryGrp"].ToString();
            TxtSchedule.Text = dt.Rows[0]["Schedule"].ToString();
            CbActive.Checked = Convert.ToBoolean(dt.Rows[0]["Status"].ToString());
            TxtDescription.SelectAll();
        }
    }
}