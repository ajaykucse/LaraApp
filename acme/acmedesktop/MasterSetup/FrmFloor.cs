using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DataAccessLayer.Common;
using DataAccessLayer.MasterSetup;
namespace acmedesktop.MasterSetup
{
    public partial class FrmFloor : Form
    {
        private ClsFloor _objFloor = new ClsFloor();
        ClsCommon _objCommon = new ClsCommon();
        public char _IsNew;
        public int _FloorId;
        private string _Tag = "", _SearchKey = "", result="";
        DataTable NavMenuDataList; int NavMenuDataRowPosition = 0;
        public string _NewFloor = "";

        public FrmFloor()
        {
            InitializeComponent();
        }
        private void FrmFloor_Load(object sender, EventArgs e)
        {
            NavMenuDataList = _objFloor.GetDataFloor(0);
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
        private void FrmFloor_KeyDown(object sender, KeyEventArgs e)
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
            Text = "Floor Master [NEW]";
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _Tag = "EDIT";
            ControlEnableDisable(false, true);
            Text = "Floor Master [EDIT]";
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _Tag = "DELETE";
            ControlEnableDisable(false, false);
            Text = "Floor Master [DELETE]";
            TxtDescription.Enabled = true;
            BtnSearcFloorDesc.Enabled = true;
            TxtDescription.Focus();
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
        }
        private void BtnFirstData_Click(object sender, EventArgs e)
        {
            if (NavMenuDataList.Rows.Count > 0)
            {
                this.NavMenuDataRowPosition = 0;              
                DataTable dt = _objFloor.GetDataFloor(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["FloorId"].ToString()));
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
                DataTable dt = _objFloor.GetDataFloor(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["FloorId"].ToString()));
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
                DataTable dt = _objFloor.GetDataFloor(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["FloorId"].ToString()));
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
            DataTable dt = _objFloor.GetDataFloor(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["FloorId"].ToString()));
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
                MessageBox.Show("Floor Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TxtShortName.Text))
            {
                MessageBox.Show("Floor is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtShortName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(TxtDescription.Text))
            {
                MessageBox.Show("Floor Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TxtShortName.Text))
            {
                MessageBox.Show("Floor ShortName is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtShortName.Focus();
                return;
            }

            _objFloor.Model.Tag = _Tag;
            _objFloor.Model.FloorId = Convert.ToInt32(TxtDescription.Tag.ToString());
            _objFloor.Model.FloorDesc = TxtDescription.Text;
            _objFloor.Model.FloorShortName = TxtShortName.Text;           
            _objFloor.Model.EnterBy = ClsGlobal.LoginUserCode;
            _objFloor.Model.Status = CbActive.Checked == true ? true : false;
            _objFloor.Model.Gadget = "Desktop";
            if (_Tag == "NEW")
            {
                if (ClsGlobal.ConfirmSave == 1)
                {
                    var dialogResult = MessageBox.Show("Are you sure want to Save New Record..??", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dialogResult == DialogResult.Yes)
                        result = _objFloor.SaveFloor();
                    else
                        return;
                }
                else
                {
                    result = _objFloor.SaveFloor();
                }
            }
            else
            {
                result = _objFloor.SaveFloor();
            }
         
            if (!string.IsNullOrEmpty(result))
            {
                if (_IsNew == 'Y')
                {
                    _NewFloor = TxtDescription.Text.Trim();
                    _FloorId = Convert.ToInt32(result);
                    this.Close();
                }
                else
                {
                    NavMenuDataList = _objFloor.GetDataFloor(0);
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
                    Text = "Floor Master";
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
                Text = "Floor Master";
            }
          
        }
        private void BtnSearcFloorDesc_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("FloorMaster", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    DataTable dt = _objFloor.GetDataFloor(Convert.ToInt32(frmPickList.SelectedList[0]["FloorId"].ToString().Trim()));
                    SetData(dt);
                }
                else
                {
                    TxtDescription.Text = "";
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Floor !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            _SearchKey = "";
            TxtDescription.Focus();
        }
        private void TxtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (_Tag == "NEW" && (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1"))
            {
                _SearchKey = string.Empty;
                BtnSearcFloorDesc.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtDescription, BtnSearcFloorDesc, true);
            }
        }
        private void TxtDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || this.ActiveControl == TxtDescription) return;
            if (TxtDescription.Enabled == false) return;

            if (string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Floor Description Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "Floor", "FloorDesc", "FloorId") == 1)
                {
                    MessageBox.Show("Floor Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
                else
                {
                    TxtShortName.Text = _objCommon.GenerateShortName(TxtDescription.Text.Trim(), "FloorDesc", "FloorShortName", "Floor");
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "Floor", "FloorDesc", "FloorId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Floor Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }
        private void TxtShortName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || this.ActiveControl == TxtShortName) return;
            if (TxtShortName.Enabled == false) return;

            if (string.IsNullOrEmpty(TxtShortName.Text.Trim()) && !string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Floor ShortName Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "Floor", "FloorShortName", "FloorId") == 1)
                {
                    MessageBox.Show("Floor ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "Floor", "FloorDesc", "FloorId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Floor ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }
        private void SetData(DataTable dt)
        {
            TxtDescription.Tag = dt.Rows[0]["FloorId"].ToString();
            TxtDescription.Text = dt.Rows[0]["FloorDesc"].ToString();
            TxtShortName.Text = dt.Rows[0]["FloorShortName"].ToString();
            CbActive.Checked = Convert.ToBoolean(dt.Rows[0]["Status"].ToString());
            TxtDescription.SelectAll();
        }
        private void ClearFld()
        {
            _FloorId = 0;
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
            BtnSearcFloorDesc.Enabled = fld;
            Utility.EnableDesibleColor(TxtDescription, fld);
            TxtShortName.Enabled = fld;
            Utility.EnableDesibleColor(TxtShortName, fld);
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
    }
}
