using DataAccessLayer.Common;
using DataAccessLayer.MasterSetup;
using System;
using System.Data;
using System.Windows.Forms;

namespace acmedesktop.MasterSetup
{
    public partial class FrmDepartment : Form
    {
        private ClsDepartment _objDepartment = new ClsDepartment();
        private ClsCommon _objCommon = new ClsCommon();
        public char _IsNew;
        public int _DepartmentId;
        private string _Tag = "", _SearchKey = "", result = "";
        private DataTable NavMenuDataList;
        private int NavMenuDataRowPosition = 0; public string _NewDepartment = "";
        private ClsFormControl ClsForm = null;
        public FrmDepartment()
        {
            InitializeComponent();
            ClsForm = new ClsFormControl(this);
        }
        private void FrmDepartment_Load(object sender, EventArgs e)
        {
            NavMenuDataList = _objDepartment.GetDataDepartment(0);
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
        private void FrmDepartment_KeyDown(object sender, KeyEventArgs e)
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
            Text = "Department [NEW]";
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _Tag = "EDIT";
            ControlEnableDisable(false, true);
            Text = "Department [EDIT]";
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _Tag = "DELETE";
            ControlEnableDisable(false, false);
            Text = "Department [DELETE]";
            TxtDescription.Enabled = true;
            BtnSearchDepartmentDesc.Enabled = true;
            TxtDescription.Focus();
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
        }
        private void BtnFirstData_Click(object sender, EventArgs e)
        {
            if (NavMenuDataList.Rows.Count > 0)
            {
                NavMenuDataRowPosition = 0;
                DataTable dt = _objDepartment.GetDataDepartment(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["DepartmentId"].ToString()));
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
                DataTable dt = _objDepartment.GetDataDepartment(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["DepartmentId"].ToString()));
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
                DataTable dt = _objDepartment.GetDataDepartment(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["DepartmentId"].ToString()));
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
            DataTable dt = _objDepartment.GetDataDepartment(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["DepartmentId"].ToString()));
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
                MessageBox.Show("Department Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TxtShortName.Text))
            {
                MessageBox.Show("Department ShortName is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtShortName.Focus();
                return;
            }

            try
            {
                _objDepartment.Model.Tag = _Tag;
                _objDepartment.Model.DepartmentId = Convert.ToInt32(TxtDescription.Tag.ToString());
                if ((_Tag == "EDIT" || _Tag == "DELETE") && Convert.ToInt32(TxtDescription.Tag.ToString()) == 0)
                {
                    ClearFld();
                    TxtDescription.Focus();
                    return;
                }
                _objDepartment.Model.DepartmentDesc = TxtDescription.Text;
                _objDepartment.Model.DepartmentShortName = TxtShortName.Text;
                _objDepartment.Model.DepartmentLevel = CmbType.Text;
                _objDepartment.Model.EnterBy = ClsGlobal.LoginUserCode;
                _objDepartment.Model.Status = CbActive.Checked == true ? true : false;
                _objDepartment.Model.Gadget = "Desktop";
                if (_Tag == "NEW")
                {
                    if (ClsGlobal.ConfirmSave == 1)
                    {
                        DialogResult dialogResult = MessageBox.Show("Are you sure want to Save New Record..??", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (dialogResult == DialogResult.Yes)
                        {
                            result = _objDepartment.SaveDepartment();
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        result = _objDepartment.SaveDepartment();
                    }
                }
                else
                {
                    result = _objDepartment.SaveDepartment();
                }
                if (!string.IsNullOrEmpty(result))
                {
                    if (_IsNew == 'Y')
                    {
                        _NewDepartment = TxtDescription.Text.Trim();
                        _DepartmentId = Convert.ToInt32(result);
                        Close();
                    }
                    else
                    {
                        NavMenuDataList = _objDepartment.GetDataDepartment(0);
                        MessageBox.Show("Data submit successfully", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFld();

                    }
                }
                else
                {
                    MessageBox.Show("Error occured during data submit", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Text = "Department";
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
                Text = "Department";
            }

        }
        private void TxtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (_Tag == "NEW" && (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1"))
            {
                _SearchKey = string.Empty;
                BtnSearchDepartmentDesc.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtDescription, BtnSearchDepartmentDesc, true);
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
                MessageBox.Show("Department Description Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "Department", "DepartmentDesc", "DepartmentId") == 1)
                {
                    MessageBox.Show("Department Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
                else
                {
                    TxtShortName.Text = _objCommon.GenerateShortName(TxtDescription.Text.Trim(), "DepartmentDesc", "DepartmentShortName", "Department");
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "Department", "DepartmentDesc", "DepartmentId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Department Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }
        private void BtnSearchDepartmentDesc_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("Department", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    DataTable dt = _objDepartment.GetDataDepartment(Convert.ToInt32(frmPickList.SelectedList[0]["DepartmentId"].ToString().Trim()));
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
                MessageBox.Show("No List Available in Department !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Department ShortName Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "Department", "DepartmentShortName", "DepartmentId") == 1)
                {
                    MessageBox.Show("Department ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "Department", "DepartmentShortName", "DepartmentId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Department ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }
        private void SetData(DataTable dt)
        {
            TxtDescription.Tag = dt.Rows[0]["DepartmentId"].ToString();
            TxtDescription.Text = dt.Rows[0]["DepartmentDesc"].ToString();
            TxtShortName.Text = dt.Rows[0]["DepartmentShortName"].ToString();
            CmbType.Text = dt.Rows[0]["DepartmentLevel"].ToString();
            CbActive.Checked = Convert.ToBoolean(dt.Rows[0]["Status"].ToString());
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

            if (BtnNew.Enabled == true)
            {
                BtnNew.Focus();
            }

            BtnSearchDepartmentDesc.Enabled = fld;
            TxtDescription.Enabled = fld;
            Utility.EnableDesibleColor(TxtDescription, fld);
            TxtShortName.Enabled = fld;
            Utility.EnableDesibleColor(TxtShortName, fld);
            CmbType.Enabled = fld;
            Utility.EnableDesibleComboBoxColor(CmbType, fld);
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
            _DepartmentId = 0;
            TxtDescription.Tag = "0";
            foreach (Control control in PanelContainer.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
            }
            CbActive.Checked = true;
            CmbType.SelectedIndex = 0;
            TxtDescription.Focus();
        }
    }
}
