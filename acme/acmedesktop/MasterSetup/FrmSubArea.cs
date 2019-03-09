using DataAccessLayer.Common;
using DataAccessLayer.MasterSetup;
using System;
using System.Data;
using System.Windows.Forms;
namespace acmedesktop.MasterSetup
{
    public partial class FrmSubArea : Form
    {
        private ClsArea _objArea = new ClsArea();
        ClsCommon _objCommon = new ClsCommon();
        public char _IsNew;
        public int _AreaId;
        private string _Tag = "", _SearchKey = "", result ="";
        DataTable NavMenuDataList; int NavMenuDataRowPosition = 0; public string _NewArea = "";
        public FrmSubArea()
        {
            InitializeComponent();
        }
        private void FrmSubArea_Load(object sender, EventArgs e)
        {
            NavMenuDataList = _objArea.GetDataArea(0);
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
        private void FrmSubArea_KeyDown(object sender, KeyEventArgs e)
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

            BtnSearcSubAreaDesc.Enabled = fld;
            TxtDescription.Enabled = fld;
            Utility.EnableDesibleColor(TxtDescription, fld);
            TxtShortName.Enabled = fld;
            Utility.EnableDesibleColor(TxtShortName, fld);
            TxtCountry.Enabled = fld;
            Utility.EnableDesibleColor(TxtCountry, fld);
            TxtLocation.Enabled = fld;
            Utility.EnableDesibleColor(TxtLocation, fld);
            TxtMainArea.Enabled = fld;
            Utility.EnableDesibleColor(TxtMainArea, fld);
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
            _AreaId = 0;
            TxtMainArea.Tag = "0";
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
            Text = "Sub Area [NEW]";
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            _Tag = "EDIT";
            ControlEnableDisable(false, true);
            Text = "Sub Area [EDIT]";
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _Tag = "DELETE";
            ControlEnableDisable(false, false);
            Text = "Sub Area [DELETE]";
            TxtDescription.Enabled = true;
            BtnSearcSubAreaDesc.Enabled = true;
            TxtDescription.Focus();
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
        }
        private void BtnFirstData_Click(object sender, EventArgs e)
        {
            if (NavMenuDataList.Rows.Count > 0)
            {
                NavMenuDataRowPosition = 0;
                DataTable dt = _objArea.GetDataArea(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["AreaId"].ToString()));
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
                DataTable dt = _objArea.GetDataArea(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["AreaId"].ToString()));
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
                DataTable dt = _objArea.GetDataArea(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["AreaId"].ToString()));
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
            DataTable dt = _objArea.GetDataArea(Convert.ToInt32(NavMenuDataList.Rows[NavMenuDataRowPosition]["AreaId"].ToString()));
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
                MessageBox.Show("SubArea Description is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TxtShortName.Text))
            {
                MessageBox.Show("SubArea ShortName is Required..!!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtShortName.Focus();
                return;
            }

            _objArea.Model.Tag = _Tag;
            _objArea.Model.AreaId = Convert.ToInt32(TxtDescription.Tag.ToString());
            if ((_Tag == "EDIT" || _Tag == "DELETE") && Convert.ToInt32(TxtDescription.Tag.ToString()) == 0)
            {
                ClearFld();
                TxtDescription.Focus();
                return;
            }
            _objArea.Model.AreaDesc = TxtDescription.Text;
            _objArea.Model.AreaShortName = TxtShortName.Text;
            _objArea.Model.Country = TxtCountry.Text;
            _objArea.Model.Location = TxtLocation.Text;
            _objArea.Model.MainAreaId = ((TxtMainArea.Tag.ToString() == "") ? 0 : Convert.ToInt32(TxtMainArea.Tag.ToString()));
            _objArea.Model.EnterBy = ClsGlobal.LoginUserCode;
            _objArea.Model.Status = CbActive.Checked == true ? true : false;
            _objArea.Model.Gadget = "Desktop";
            if (_Tag == "NEW")
            {
                if (ClsGlobal.ConfirmSave ==1)
                {
                    var dialogResult = MessageBox.Show("Are you sure want to Save New Record..??", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dialogResult == DialogResult.Yes)
                        result = _objArea.SaveArea();
                    else
                        return;
                }
                else
                {
                    result = _objArea.SaveArea();
                }
            }
            else
            {
                result = _objArea.SaveArea();
            }

            if (!string.IsNullOrEmpty(result))
            {
                if (_IsNew == 'Y')
                {
                    _NewArea = TxtDescription.Text.Trim();
                    _AreaId = Convert.ToInt32(result);
                    this.Close();
                }
                else
                {
                    NavMenuDataList = _objArea.GetDataArea(0);
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
                    Text = "Sub Area";
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
                Text = "Sub Area";
            }
         
        }

        private void BtnSearcSubAreaDesc_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("SubArea", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0 && _Tag != "NEW")
                {
                    DataTable dt = _objArea.GetDataArea(Convert.ToInt32(frmPickList.SelectedList[0]["AreaId"].ToString().Trim()));
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
                MessageBox.Show("No List Available in Area !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtDescription.Focus();
                return;
            }
            TxtDescription.Focus();
        }

        private void TxtMainArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.N | Keys.Control))
            {
                FrmMainArea frm = new FrmMainArea();
                frm._IsNew = 'Y';
                frm.ShowDialog();
                TxtMainArea.Text = frm._NewMainArea;
                TxtMainArea.Tag = frm._MainAreaId;
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), "DELETE", _SearchKey, TxtMainArea, BtnMainAreaSearch, false);
            }
        }

        private void BtnMainAreaSearch_Click(object sender, EventArgs e)
        {
            Common.PickList frmPickList = new Common.PickList("MainArea", _SearchKey);
            if (Common.PickList.dt.Rows.Count > 0)
            {
                frmPickList.ShowDialog();
                if (frmPickList.SelectedList.Count > 0)
                {
                    TxtMainArea.Text = frmPickList.SelectedList[0]["MainAreaDesc"].ToString().Trim();
                    TxtMainArea.Tag = frmPickList.SelectedList[0]["MainAreaId"].ToString().Trim();
                }
                frmPickList.Dispose();
            }
            else
            {
                MessageBox.Show("No List Available in Main Area !", "Mr. Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtMainArea.Focus();
                return;
            }
            TxtMainArea.Focus();
        }

        private void TxtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (_Tag == "NEW" && (e.KeyCode.ToString() == "" || e.KeyCode.ToString() == "F1"))
            {
                _SearchKey = string.Empty;
                BtnSearcSubAreaDesc.PerformClick();
            }
            else
            {
                _SearchKey = e.KeyCode.ToString() == "F1" || e.KeyCode.ToString() == "Escape" ? string.Empty : ((char)e.KeyCode).ToString();
                ClsGlobal.MyKeyDown((char)e.KeyCode, e.KeyValue, e.KeyData.ToString(), _Tag, _SearchKey, TxtDescription, BtnSearcSubAreaDesc, true);
            }
        }

        private void TxtDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtDescription) return;
            if (TxtDescription.Enabled == false) return;

            if (string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Area Description Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "Area", "AreaDesc", "AreaId") == 1)
                {
                    MessageBox.Show("Area Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
                else
                {
                    TxtShortName.Text = _objCommon.GenerateShortName(TxtDescription.Text, "AreaDesc", "AreaShortName", "Area");
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckDescriptionDuplicateRecord(TxtDescription.Text.Trim(), "Area", "AreaDesc", "AreaId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Area Description Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }
        private void TxtShortName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Tag == "" || ActiveControl == TxtShortName) return;
            if (TxtShortName.Enabled == false) return;

            if (string.IsNullOrEmpty(TxtShortName.Text.Trim()) && !string.IsNullOrEmpty(TxtDescription.Text.Trim()))
            {
                MessageBox.Show("Area ShortName Cannot Left Blank...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;
            }
            else if (_Tag == "NEW")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "Area", "AreaShortName", "AreaId") == 1)
                {
                    MessageBox.Show("Area ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
            else if (_Tag == "EDIT")
            {
                if (_objCommon.CheckShortNameDuplicateRecord(TxtShortName.Text.Trim(), "Area", "AreaShortName", "AreaId", Convert.ToInt32(TxtDescription.Tag.ToString())) != 0)
                {
                    MessageBox.Show("Area ShortName Already Exist...!", "Mr Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void SetData(DataTable dt)
        {
            TxtDescription.Tag = dt.Rows[0]["AreaId"].ToString();
            TxtDescription.Text = dt.Rows[0]["AreaDesc"].ToString();
            TxtShortName.Text = dt.Rows[0]["AreaShortName"].ToString();
            TxtCountry.Text = dt.Rows[0]["Country"].ToString();
            TxtLocation.Text = dt.Rows[0]["Location"].ToString();
            TxtMainArea.Tag = dt.Rows[0]["MainAreaId"].ToString();
            TxtMainArea.Text = dt.Rows[0]["MainAreaDesc"].ToString();
            CbActive.Checked = Convert.ToBoolean(dt.Rows[0]["Status"].ToString());
            TxtDescription.SelectAll();
        }
    }
}
